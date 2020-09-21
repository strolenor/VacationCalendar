using EmployeeVacationCalendar.Areas.Identity.Data;
using EmployeeVacationCalendar.Data;
using EmployeeVacationCalendar.Data.Model;
using EmployeeVacationCalendar.Enums;
using EmployeeVacationCalendar.Models;
using EmployeeVacationCalendar.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeVacationCalendar.Services
{
    public interface ICalendarService
    {
        CalendarListViewModel GetAll(DateTime date);

        Task<EditCalendarEntryDto> Get(DateTime date, Guid userId, ApplicationUser user);

        void Save(EditCalendarEntryDto model, ApplicationUser user);
    }

    public class CalendarService : ICalendarService
    {
        private readonly VacationDbContext _context;
        private readonly AuthDbContext _authDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CalendarService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            VacationDbContext context,
            AuthDbContext authDbContext)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._context = context;
            this._authDbContext = authDbContext;
        }

        public CalendarListViewModel GetAll(DateTime date)
        {
            //TODO there is max and min year edge case
            //TODO extract this check to external validator(Fluent validation)
            if (date.Month == 0)
            {
                throw new ArgumentException("Month cannot be 0");
            }

            if (date.Year == 0)
            {
                throw new ArgumentException("Year cannot be 0");
            }

            int year = date.Year;
            int month = date.Month;

            DateTime currentMonthStartDate = new DateTime(year, month, 1);
            DateTime currentMonthEndDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            // TODO: extract to method
            List<ApplicationUser> users = _authDbContext.ApplicationUser
                    .OrderBy(b => b.CountryId)
                    .Where(x => (
                    x.IsActive.HasValue && x.IsActive == true) ||
                    x.IsActive.HasValue && x.IsActive == false && x.InactiveAfter > currentMonthStartDate).ToList();

            List<Vacation> allVacationsInMonth = GetVacations(year, month, null).ToList();
            List<Holiday> allHollidaysInMonth = GetHolidays(year, month).ToList();
            List<int> weekendDays = GetWeekendDays(year, month);

            List<EmployeeDays> employees = new List<EmployeeDays>();
            foreach (ApplicationUser user in users)
            {
                Dictionary<int, DayType> specialDays = new Dictionary<int, DayType>();

                foreach (Holiday holliday in allHollidaysInMonth.Where(x => x.CountryId == user.CountryId))
                {
                    if (holliday.Day != null && holliday.Month != null)
                    {
                        if (!weekendDays.Contains(holliday.Day.Value))
                        {
                            specialDays.TryAdd(holliday.Day.Value, DayType.Holiday);
                        }
                    }
                    else if (holliday.DateActiveOnly != null && holliday.DateActiveOnly <= currentMonthEndDate)
                    {
                        if (!weekendDays.Contains(holliday.DateActiveOnly.Value.Day))
                        {
                            specialDays.TryAdd(holliday.DateActiveOnly.Value.Day, DayType.Holiday);
                        }
                    }
                    else
                    {
                        //log error in logic
                    }
                }

                var userVacations = allVacationsInMonth.Where(x => x.UserId == user.Id).Select(c => new { c.DateFrom, c.DateTo }).ToList();
                foreach (var vacation in userVacations)
                {
                    if (vacation.DateFrom == vacation.DateTo && !weekendDays.Contains(vacation.DateFrom.Day))
                    {
                        specialDays.Add(vacation.DateFrom.Day, DayType.VacationLeave);
                    }
                    else
                    {
                        DateTime vacationStartDate = GetVacationStartDate(vacation.DateFrom, year, month);
                        DateTime vacationEndDate = GetVacationEndDate(vacation.DateTo, year, month);

                        for (int i = vacationStartDate.Day; i <= vacationEndDate.Day; i++)
                        {
                            if (!weekendDays.Contains(i))
                                specialDays.TryAdd(i, DayType.VacationLeave);
                        }
                    }
                }

                EmployeeDays employee = new EmployeeDays()
                {
                    Id = new Guid(user.Id),
                    FullName = user.FirstName + " " + user.LastName,
                    IsAdmin = user.IsAdmin,
                    SpecialDays = GetDayStatus(specialDays, year, month)
                };

                employees.Add(employee);
            }

            CalendarListViewModel vm = new CalendarListViewModel()
            {
                Employees = employees,
                SelectedMonth = month,
                CurrentMonthAndYear = GetCurrentMonthAndYear(year, month),
                CurrentMonthMaxDays = DateTime.DaysInMonth(year, month),
                CurrrentYear = year,
                PreviousMonth = SetMonth(year, month, false),
                NextMonth = SetMonth(year, month, true),
                DaysInMonth = DateTime.DaysInMonth(year, month)
            };

            return vm;
        }

        private string GetCurrentMonthAndYear(int year, int month)
        {
            return new DateTime(year, month, 1).ToString("MMMM", CultureInfo.CreateSpecificCulture("en-Us")) + " " + year;
        }

        public async Task<EditCalendarEntryDto> Get(DateTime date, Guid userId, ApplicationUser applicationUser)
        {
            var roles = await _userManager.GetRolesAsync(applicationUser);
            if (applicationUser.Id != userId.ToString() && roles.Contains("Admin") == false)
            {
                throw new Exception("User has insufficeint rights");
            }
            //TODO there is max and min year edge case
            //TODO extract this check to external validator(Fluent validation)
            if (date < DateTime.MinValue || date > DateTime.MaxValue)
            {
                throw new ArgumentException("Incorrect Date format");
            }

            //DateTime currentMonthStartDate = new DateTime(date.Year, date.Month, 1);
            //DateTime currentMonthEndDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            var user = _authDbContext.ApplicationUser
                    .OrderBy(b => b.CountryId)
                    .Where(x => x.Id == userId.ToString()).FirstOrDefault();

            if (user == null)
            {
                //handle somehow
            }

            EditCalendarEntryDto result = new EditCalendarEntryDto();
            result.OriginalVacationType = GetAbsences();
            result.UpdatedVacationType = result.OriginalVacationType;

            //Tuple negdje avbsences
            Vacation userVacationsInMonth = GetVacations(date.Year, date.Month, userId.ToString()).FirstOrDefault();
            if (userVacationsInMonth == null)
            {
                var holliday = GetHolidays(date);
                if (holliday == null)
                {
                    result.OriginalDateFrom = date;
                    result.OriginalDateTo = date;
                    result.UpdatedDateFrom = date;
                    result.UpdatedDateTo = date;
                }
                else
                {
                    DateTime hollidayDate = GetHolidayDate(holliday, date.Year);

                    result.OriginalDateFrom = hollidayDate;
                    result.OriginalDateTo = hollidayDate;
                    result.UpdatedDateFrom = result.OriginalDateFrom;
                    result.UpdatedDateTo = result.OriginalDateTo;
                    foreach (var item in result.OriginalVacationType.VacationType.Where(x => x.Text == "Holiday"))
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
            else
            {
                result.OriginalDateFrom = userVacationsInMonth.DateFrom;
                result.OriginalDateTo = userVacationsInMonth.DateTo;
                result.UpdatedDateFrom = result.OriginalDateFrom;
                result.UpdatedDateTo = result.OriginalDateTo;
                result.Id = userVacationsInMonth.Id;
                foreach (var item in result.OriginalVacationType.VacationType.Where(x => x.Value == userVacationsInMonth.VacationType.Id.ToString()))
                {
                    item.Selected = true;
                    break;
                }
            }

            return result;
        }

        public void Save(EditCalendarEntryDto model, ApplicationUser user)
        {
            Guid updatedVacationTypeId = new Guid(model.UpdatedVacationType.Vacation);

            if (model.Id != null && model.Id != Guid.Empty)
            {
                Vacation absenceDay = _context.Vacation
                    .Where(x => x.Id == model.Id)
                    .FirstOrDefault();

                VacationType vacationType = _context.VacationType
                    .Where(x => x.Id == updatedVacationTypeId)
                    .FirstOrDefault();

                if (absenceDay == null)
                {
                    // handle this exception
                    throw new ArgumentException("No such absence day exists");
                }
                if (model.OriginalDateFrom != absenceDay.DateFrom ||
                    model.OriginalDateTo != absenceDay.DateTo ||
                    model.OriginalVacationType.Vacation != vacationType.Id.ToString())
                {
                    throw new Exception("Entry has been updated in the meantime");
                }
                else
                {
                    absenceDay.DateFrom = model.UpdatedDateFrom.Value;
                    absenceDay.DateTo = model.UpdatedDateTo.Value;
                    absenceDay.VacationTypeId = vacationType.Id;
                    _context.Entry(absenceDay).State = EntityState.Modified;
                    _context.Vacation.Update(absenceDay);
                    _context.SaveChanges();
                }
            }
            else
            {
                var vacationType = _context.VacationType.Where(x => x.Id == updatedVacationTypeId).FirstOrDefault();
                Vacation newVacation = new Vacation()
                {
                    Id = new Guid(user.Id), //get user
                    DateFrom = model.UpdatedDateFrom.Value,
                    DateTo = model.UpdatedDateTo.Value,
                    VacationTypeId = updatedVacationTypeId
                };
                _context.Entry(newVacation).State = EntityState.Added;
                _context.Vacation.Add(newVacation);
                _context.SaveChanges();
            }
        }

        private DateTime GetHolidayDate(Holiday holliday, int year)
        {
            if (holliday.Day != null && holliday.Month != null)
            {
                return new DateTime(year, holliday.Month.Value, holliday.Day.Value);
            }
            else
            {
                return holliday.DateActiveOnly.Value;
            }
        }

        private List<int> GetWeekendDays(int year, int month)
        {
            List<int> result = Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                    .Select(dt => new DateTime(year, month, dt))
                    .Where(dw => dw.DayOfWeek == DayOfWeek.Sunday &&
                                 dw.DayOfWeek == DayOfWeek.Saturday).Select(day => day.Day)
                    .ToList();
            return result;
        }

        private DateTime GetVacationEndDate(DateTime endDate, int year, int month)
        {
            int lastDayInMonth = DateTime.DaysInMonth(year, month);

            if (endDate.Year > year || endDate.Month > month)
            {
                return new DateTime(year, month, lastDayInMonth);
            }

            return endDate;
        }

        private DateTime GetVacationStartDate(DateTime startDate, int year, int month)
        {
            if (startDate.Year < year || startDate.Month < month)
            {
                return new DateTime(year, month, 1);
            }

            return startDate;
        }

        private IQueryable<Holiday> GetHolidays(int year, int month)
        {
            DateTime startDate = GetDateAtTheBeginingOfTheMonth(year, month);
            DateTime endDate = GetDateAtTheEndOfTheMonth(year, month);

            IQueryable<Holiday> query = from h in _context.Set<Holiday>().Where(x => (x.Month == month && x.IsActive) ||
                        (x.IsActive &&
                        x.DateActiveOnly > startDate &&
                        x.DateActiveOnly < endDate))
                                        select h;

            return query;
        }

        private Holiday GetHolidays(DateTime holliday)
        {
            Holiday result = _context.Holiday.FirstOrDefault(x =>
                (x.Month == holliday.Month && x.Day == holliday.Day && x.IsActive) ||
                (x.IsActive && x.DateActiveOnly == holliday));

            return result;
        }


        private IQueryable<Vacation> GetVacations(int year, int month, string userId)
        {
            DateTime startDate = GetDateAtTheBeginingOfTheMonth(year, month);
            DateTime endDate = GetDateAtTheEndOfTheMonth(year, month);

            IQueryable<Vacation> query;
            if (string.IsNullOrEmpty(userId))
            {
                query = from u in _context.Set<ApplicationUser>()
                        from h in _context.Set<Vacation>().Where(x =>
                        x.UserId == u.Id &&
                        x.DateFrom.Year <= year &&
                        x.DateFrom.Month <= month &&
                        x.DateTo.Year >= year &&
                        x.DateTo.Month >= month
                        )
                        select h;
            }
            else
            {
                query = from h in _context.Set<Vacation>().Where(x =>
                        x.UserId == userId &&
                        x.DateFrom.Year <= year &&
                        x.DateFrom.Month <= month &&
                        x.DateTo.Year >= year &&
                        x.DateTo.Month >= month
                        )
                        select h;
            }

            return query;
        }

        private bool FilterByUser(Vacation x, ApplicationUser u, Guid? userId)
        {
            return (userId == null || userId == Guid.Empty) ?
                x.UserId == u.Id :
                x.UserId == userId.ToString();
        }

        private DateTime GetDateAtTheEndOfTheMonth(int year, int month)
        {
            return new DateTime(year, month, DateTime.DaysInMonth(2020, month));
        }

        private DateTime GetDateAtTheBeginingOfTheMonth(int year, int month)
        {
            return new DateTime(year, month, 1);
        }

        private List<DayInMonthDto> GetDayStatus(Dictionary<int, DayType> specialDays, int year, int month)
        {
            int daysInMont = DateTime.DaysInMonth(year, month);
            List<DayInMonthDto> result = new List<DayInMonthDto>(daysInMont);
            for (int i = 1; i <= daysInMont; i++)
            {
                DayType dt;
                bool specialDayPresent = specialDays.TryGetValue(i, out dt);
                DayInMonthDto newDay = new DayInMonthDto()
                {
                    Day = i
                };

                DateTime dayInWeek = new DateTime(year, month, i);
                if (dayInWeek.DayOfWeek == DayOfWeek.Saturday || dayInWeek.DayOfWeek == DayOfWeek.Sunday)
                {
                    SetSpecialDay(newDay, DayType.Weekend);
                }
                else if (specialDayPresent)
                {
                    SetSpecialDay(newDay, dt);
                }
                else
                {
                    SetSpecialDay(newDay, DayType.WorkDay);
                }

                result.Add(newDay);
            }

            return result;
        }

        private void SetSpecialDay(DayInMonthDto newDay, DayType dayType)
        {
            // call translation service to translate days to current user language
            switch (dayType)
            {
                case DayType.WorkDay:
                    newDay.DayStatus = "Work Day";
                    newDay.DayStatusBackroundColor = "workday";
                    break;
                case DayType.VacationLeave:
                    newDay.DayStatus = "Vacation";
                    newDay.DayStatusBackroundColor = "vacation";
                    break;
                case DayType.SickLeave:
                    newDay.DayStatus = "Sick leave";
                    newDay.DayStatusBackroundColor = "sickLeave";
                    break;
                case DayType.Holiday:
                    newDay.DayStatus = "Holiday";
                    newDay.DayStatusBackroundColor = "holiday";
                    break;
                case DayType.Weekend:
                    newDay.DayStatus = "Weekend";
                    newDay.DayStatusBackroundColor = "weekend";
                    break;
                default:
                    newDay.DayStatus = "Unknown";
                    newDay.DayStatusBackroundColor = "workday";
                    break;
            }
        }

        private DateTime SetMonth(int year, int month, bool increment)
        {
            DateTime date;

            if (increment && month == 12)
            {
                date = new DateTime(year + 1, 1, 1);
            }
            else if (increment)
            {
                date = new DateTime(year, month + 1, 1);
            }
            else if (!increment && month == 1)
            {
                date = new DateTime(year - 1, 12, 1);
            }
            else
            {
                date = new DateTime(year, month -1 , 1);
            }

            return date;
        }

        private AbesencesViewModel GetAbsences()
        {
            var absences = _context.VacationType.ToList();
            AbesencesViewModel abesence = new AbesencesViewModel() { VacationType = new List<SelectListItem>() };
            var selectedItems = new List<SelectListItem>();
            foreach (var item in absences)
            {
                var absence = new SelectListItem()
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                };
                selectedItems.Add(absence);
            }
            abesence.VacationType.AddRange(selectedItems);

            return abesence;
        }
    }
}

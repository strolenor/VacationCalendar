using System;
using System.Threading.Tasks;
using EmployeeVacationCalendar.Areas.Identity.Data;
using EmployeeVacationCalendar.Data;
using EmployeeVacationCalendar.Models;
using EmployeeVacationCalendar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeVacationCalendar.Controllers
{
    public class CalendarController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly VacationDbContext _context;
        private readonly AuthDbContext _authDbContext;
        private readonly ICalendarService _calendarService;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CalendarController(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            VacationDbContext context, 
            AuthDbContext authDbContext,
            ICalendarService calendarService)
        {
            this._userManager = userManager;
            this._context = context;
            this._authDbContext = authDbContext;
            this._calendarService = calendarService;
            this._roleManager = roleManager;
        }

        // GET: Calendar
        public async Task<ActionResult> Index(DateTime? date = null )
        {
            // hack to save time on creating form 
            // for user and role management
            await TryCreateRole("Admin");
            await TryCreateRole("User");

            if (date == null)
            {
                date = DateTime.Now;
            }

            var vm = _calendarService.GetAll(date.Value);
            return View(vm);
        }


        public ActionResult Details(int id)
        {
            return View();
        }

        public async Task<ActionResult> Edit(Guid userId, DateTime date)
        {
            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            EditCalendarEntryDto vm = await _calendarService.Get(date, userId, user);
            return View(vm);
        }


        public async Task<ActionResult> Save(EditCalendarEntryDto model)
        {
            if (model.OriginalDateFrom == model.UpdatedDateFrom &&
                model.OriginalDateTo == model.UpdatedDateTo &&
                model.OriginalVacationType == model.UpdatedVacationType)
            {
                return RedirectToAction("Index", "Calendar");
            }

            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);
            _calendarService.Save(model, user);

            return RedirectToAction("Index", "Calendar");
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        private async Task TryCreateRole(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName) == false)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }
    }
}
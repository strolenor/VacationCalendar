using EmployeeVacationCalendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeVacationCalendar.ViewModel
{
    public class CalendarListViewModel
    {
        public List<EmployeeDays> Employees { get; set; }

        public int DaysInMonth { get; set; }

        public int SelectedMonth { get; set; }

        public string CurrentMonthAndYear { get; internal set; }

        public DateTime NextMonth { get; set; }

        public DateTime PreviousMonth { get; set; }

        public int CurrrentYear { get; set; }

        public int NextYear { get; set; }

        public int PreviousYear { get; set; }

        public int CurrentMonthMaxDays { get; internal set; }

        public Colors Colors { get; internal set; }
    }
}

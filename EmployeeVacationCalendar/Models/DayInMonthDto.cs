using EmployeeVacationCalendar.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeVacationCalendar.Models
{
    public class DayInMonthDto
    {
        public int Day { get; set; }

        public DayType DayType { get; set; }

        public string DayStatus { get; set; }

        public string DayStatusBackroundColor { get; set; }
    }
}

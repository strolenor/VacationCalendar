using System;
using System.Collections.Generic;

namespace EmployeeVacationCalendar.Models
{
    public class EmployeeDays
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public bool IsAdmin { get; set; }

        public List<DayInMonthDto> SpecialDays { get; set; }
    }
}

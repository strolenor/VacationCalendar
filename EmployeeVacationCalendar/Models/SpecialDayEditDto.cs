using EmployeeVacationCalendar.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeVacationCalendar.Models
{
    public class SpecialDayEditDto
    {
        public string Id { get; set; }
        public DateTime OriginalDateFrom { get; set; }
        public DateTime OriginalDateTo { get; set; }
        public DayType OriginalDayType { get; set; }
        public DateTime UpdatedDateFrom { get; set; }
        public DateTime UpdatedDateTo { get; set; }
        public DayType UpdatedDayType { get; set; }
        public DayType DayType { get; set; }
    }
}

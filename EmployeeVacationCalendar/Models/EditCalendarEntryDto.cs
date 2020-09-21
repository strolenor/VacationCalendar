using EmployeeVacationCalendar.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeVacationCalendar.Models
{
    public class EditCalendarEntryDto
    {
        public Guid? Id { get; set; }

        public DateTime? OriginalDateFrom { get; set; }

        public DateTime? OriginalDateTo { get; set; }

        public AbesencesViewModel OriginalVacationType { get; set; }

        public DateTime? UpdatedDateFrom { get; set; }

        public DateTime? UpdatedDateTo { get; set; }

        public AbesencesViewModel UpdatedVacationType { get; set; }
    }
}

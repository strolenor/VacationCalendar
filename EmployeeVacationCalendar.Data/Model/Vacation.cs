using EmployeeVacationCalendar.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeVacationCalendar.Data.Model
{
    public class Vacation
    {
        public Guid  Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public Guid VacationTypeId { get; set; }

        public VacationType VacationType { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}

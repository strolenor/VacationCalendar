using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EmployeeVacationCalendar.ViewModel
{
    public class AbesencesViewModel
    {
        public string Vacation { get; set; }

        public List<SelectListItem> VacationType { get; set; }
    }
}

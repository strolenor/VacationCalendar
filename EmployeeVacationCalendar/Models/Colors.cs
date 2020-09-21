using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeVacationCalendar.Models
{
    public class Colors
    {
        public Colors()
        {
            Vacation = "F09300";
            Holiday = "7986CB";
            SickLeave = "3F51B5";
            WorkDay = "9E69AF";
        }

        public string Vacation { get; set; }
        public string Holiday { get; set; }
        public string SickLeave { get; set; }
        public string WorkDay { get; set; }
    }
}

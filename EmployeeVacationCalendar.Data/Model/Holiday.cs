using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeVacationCalendar.Data.Model
{
    public class Holiday
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int? Day { get; set; }

        public int? Month { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }

        public bool IsActive { get; set; }

        public DateTime? ActiveFrom { get; set; }

        public DateTime? ActiveTo { get; set; }

        public DateTime? DateActiveOnly { get; set; }
    }
}

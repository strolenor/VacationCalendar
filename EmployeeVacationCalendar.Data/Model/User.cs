using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeVacationCalendar.Data.Model
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool IsAdmin { get; set; }

        public Guid CountryId { get; set; }

        public Country Country { get; set; }
    }
}

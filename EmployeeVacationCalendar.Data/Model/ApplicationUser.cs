using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using EmployeeVacationCalendar.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace EmployeeVacationCalendar.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        public bool IsAdmin { get; set; }

        [PersonalData]
        public Guid CountryId { get; set; }

        [PersonalData]
        public Country Country { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? InactiveAfter { get; set; }
    }
}

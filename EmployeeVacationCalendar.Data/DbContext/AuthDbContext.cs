using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeVacationCalendar.Areas.Identity.Data;
using EmployeeVacationCalendar.Data.Configuration;
using EmployeeVacationCalendar.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeVacationCalendar.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.Entity<ApplicationUser>()
         .Property(b => b.IsActive)
         .HasDefaultValue(true).IsRequired(false);

            builder.Entity<Country>().HasData(
                        new Country() { Id = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), Name = "Croatia" },
                        new Country() { Id = new Guid("71c5b630-6196-4743-a556-5833e8fde3d0"), Name = "USA" }
                        );

            builder.Entity<ApplicationUser>().HasData(
                        new ApplicationUser() { Id = new Guid("943e6ef0-d8dd-46fc-9884-8a7cb597ebb6").ToString(), FirstName = "Darko", LastName = "Subić", Email = "dsubic@gmail.com", IsAdmin = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new ApplicationUser() { Id = new Guid("928db46e-aee0-4835-8022-8df5a28f293d").ToString(), FirstName = "John", LastName = "Doe", Email = "testdoe@gmail.com", IsAdmin = false, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new ApplicationUser() { Id = new Guid("acf3528d-020b-49bd-9990-5ccef31cc7af").ToString(), FirstName = "Nepoznati", LastName = "Netko", Email = "testnetko@gmail.com", IsAdmin = false, CountryId = new Guid("71c5b630-6196-4743-a556-5833e8fde3d0") },
                        new ApplicationUser() { Id = new Guid("89401184-f1a0-419d-bd66-b20062f5edb4").ToString(), FirstName = "Fired", LastName = "Employee", Email = "fired@gmail.com", IsAdmin = false, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), IsActive = false, InactiveAfter = new DateTime(2020, 03, 20) }
                        );
        }
    }
}

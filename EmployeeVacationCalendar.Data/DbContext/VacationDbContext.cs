using EmployeeVacationCalendar.Areas.Identity.Data;
using EmployeeVacationCalendar.Data.Configuration;
using EmployeeVacationCalendar.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeVacationCalendar.Data
{
    public class VacationDbContext : DbContext
    {
        public VacationDbContext(DbContextOptions<VacationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Holiday> Holiday { get; set; }
        //public DbSet<User> User { get; set; }
        public DbSet<VacationType> VacationType { get; set; }

        public DbSet<Vacation> Vacation { get; set; }

        public DbSet<PageTemplate> PageTemplate { get; set; }

        public DbSet<PageField> PageField { get; set; }

        public DbSet<PageFieldTranslation> PageFieldTranslation { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new VacationTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VacationConfiguration());
            modelBuilder.ApplyConfiguration(new PageTemplateConfiguration());
            modelBuilder.ApplyConfiguration(new PageFieldConfiguration());
            modelBuilder.ApplyConfiguration(new PageFieldTranslationConfiguration());

            //proširi seed metodu s novim konfiguracijama

            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Holiday>().HasData(
                        new Holiday() { Id = new Guid("0e8e75f7-0162-4d4d-9ab9-202a0fd9f233"), Name = "Nova godina", Day = 1, Month = 1, IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("976114ca-89f1-4c1f-978f-d2c193feb9ba"), Name = "Sveta tri kralja", Day = 6, Month = 1, IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("14e06b01-4d94-4611-a770-2221a9615a84"), Name = "Uskrs", DateActiveOnly = new DateTime(2020, 4, 13), IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("01b80707-8064-4cdb-850b-e14dcd001694"), Name = "Uskrsni ponedjeljak", DateActiveOnly = new DateTime(2020, 4, 14), IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("b9bf9f06-e4e2-4554-a9cf-8c489abe2b5f"), Name = "Praznik rada", Day = 1, Month = 5, IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("eb562f61-7f4a-4081-a111-affcd0c34fa8"), Name = "Dan državnosti", Day = 30, Month = 5, IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("f6201f94-7869-4fae-9010-ea5bdcd42f88"), Name = "Tijelovo", DateActiveOnly = new DateTime(2020, 6, 11), IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("86f75a58-a4bd-43f4-9ae1-54f7bcf3ff54"), Name = "Dan antifašističke borbe", Day = 22, Month = 6, IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("41bcc359-f8c3-4295-bed0-159bedf387de"), Name = "Dan pobjede i domovinske zahvalnosti i Dan hrvatskih branitelja", Day = 5, Month = 8, IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("a9f885f7-51ed-4c52-894c-76d186d4f13e"), Name = "Velika Gospa", Day = 15, Month = 8, IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("4d3dc849-26cb-4567-8673-4dcfb9bbac02"), Name = "Dan svih svetih", Day = 1, Month = 11, IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("a528e711-4941-4b07-84ae-b3cc2b65a485"), Name = "Dan sjećanja na žrtve Domovinskog rata i Dan sjećanja na žrtvu Vukovara i Škabrnje", Day = 18, Month = 11, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("03781dfa-7b6c-451a-8336-4b85642bc90f"), Name = "Božić", Day = 25, Month = 12, IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new Holiday() { Id = new Guid("837a9d1e-b129-4b12-8d55-8d64899df8a6"), Name = "Sveti Stjepan", Day = 26, Month = 12, IsActive = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") }
                        );

            modelBuilder.Entity<ApplicationUser>().HasData(
                        new ApplicationUser() { Id = new Guid("943e6ef0-d8dd-46fc-9884-8a7cb597ebb6").ToString(), FirstName = "Darko", LastName = "Subić", Email = "dsubic@gmail.com", IsAdmin = true, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new ApplicationUser() { Id = new Guid("928db46e-aee0-4835-8022-8df5a28f293d").ToString(), FirstName = "John", LastName = "Doe", Email = "testdoe@gmail.com", IsAdmin = false, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee") },
                        new ApplicationUser() { Id = new Guid("acf3528d-020b-49bd-9990-5ccef31cc7af").ToString(), FirstName = "Nepoznati", LastName = "Netko", Email = "testnetko@gmail.com", IsAdmin = false, CountryId = new Guid("71c5b630-6196-4743-a556-5833e8fde3d0") },
                        new ApplicationUser() { Id = new Guid("89401184-f1a0-419d-bd66-b20062f5edb4").ToString(), FirstName = "Fired", LastName = "Employee", Email = "fired@gmail.com", IsAdmin = false, CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), IsActive = false, InactiveAfter = new DateTime(2020,03,20) }
                        );

            modelBuilder.Entity<VacationType>().HasData(
                        new VacationType() { Id = new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d"), Name = "Vacation Leave" },
                        new VacationType() { Id = new Guid("08e635bc-f6eb-4462-8db2-0754113b28b2"), Name = "Sick Leave" },
                        new VacationType() { Id = new Guid("b256ac8c-ada0-42a5-aa68-97beca81a1e9"), Name = "Holiday" }
                        );


            modelBuilder.Entity<Vacation>().HasData(
                        new Vacation() { Id = new Guid("da3e24f3-c82c-4347-9af9-622fd4429f68"), DateFrom = new DateTime(2020, 3, 2), DateTo = new DateTime(2020, 3, 7), UserId = new Guid("943e6ef0-d8dd-46fc-9884-8a7cb597ebb6").ToString(), VacationTypeId = new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d") },
                        new Vacation() { Id = new Guid("bbf20b7a-700d-4fbe-ae2b-d296f3def6bd"), DateFrom = new DateTime(2020, 7, 1), DateTo = new DateTime(2020, 7, 18), UserId = new Guid("943e6ef0-d8dd-46fc-9884-8a7cb597ebb6").ToString(), VacationTypeId = new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d") },
                        new Vacation() { Id = new Guid("87fd50ba-a5f8-4e64-ad4e-575d3024a651"), DateFrom = new DateTime(2020, 1, 1), DateTo = new DateTime(2020, 2, 1), UserId = new Guid("928db46e-aee0-4835-8022-8df5a28f293d").ToString(), VacationTypeId = new Guid("08e635bc-f6eb-4462-8db2-0754113b28b2") },
                        new Vacation() { Id = new Guid("e27e7599-2b69-49e6-b0a3-05b70d064381"), DateFrom = new DateTime(2020, 4, 4), DateTo = new DateTime(2020, 5, 1), UserId = new Guid("928db46e-aee0-4835-8022-8df5a28f293d").ToString(), VacationTypeId = new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d") },
                        new Vacation() { Id = new Guid("483de956-387e-456f-b445-89c80762dd0b"), DateFrom = new DateTime(2020, 6, 6), DateTo = new DateTime(2020, 6, 10), UserId = new Guid("943e6ef0-d8dd-46fc-9884-8a7cb597ebb6").ToString(), VacationTypeId = new Guid("b256ac8c-ada0-42a5-aa68-97beca81a1e9") },
                        new Vacation() { Id = new Guid("e31e1b95-8b47-4836-b8e9-9a36fd5b1ea9"), DateFrom = new DateTime(2020, 9, 9), DateTo = new DateTime(2020, 9, 12), UserId = new Guid("943e6ef0-d8dd-46fc-9884-8a7cb597ebb6").ToString(), VacationTypeId = new Guid("b256ac8c-ada0-42a5-aa68-97beca81a1e9") }
                        );
        }
    }
}

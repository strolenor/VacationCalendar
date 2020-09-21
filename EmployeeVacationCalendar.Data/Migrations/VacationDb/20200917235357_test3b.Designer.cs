﻿// <auto-generated />
using System;
using EmployeeVacationCalendar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeVacationCalendar.Data.Migrations.VacationDb
{
    [DbContext(typeof(VacationDbContext))]
    [Migration("20200917235357_test3b")]
    partial class test3b
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeVacationCalendar.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("ApplicationUser");

                    b.HasData(
                        new
                        {
                            Id = "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f4716341-add3-41c3-9812-6fcb9c330b1c",
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            EmailConfirmed = false,
                            FirstName = "Darko",
                            IsAdmin = true,
                            LastName = "Subić",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d1cab2e6-3c85-467b-9dbd-c9e8ff9aa6ef",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "928db46e-aee0-4835-8022-8df5a28f293d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c61da50f-dbf6-4d4b-85a4-4b2b825dadc7",
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            EmailConfirmed = false,
                            FirstName = "John",
                            IsAdmin = false,
                            LastName = "Doe",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d38574a9-db48-4e9c-b6a9-86a6f3afa6fc",
                            TwoFactorEnabled = false
                        },
                        new
                        {
                            Id = "acf3528d-020b-49bd-9990-5ccef31cc7af",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "93946909-7c06-4b7b-9d5b-fac8969ced55",
                            CountryId = new Guid("71c5b630-6196-4743-a556-5833e8fde3d0"),
                            EmailConfirmed = false,
                            FirstName = "Nepoznati",
                            IsAdmin = false,
                            LastName = "Netko",
                            LockoutEnabled = false,
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "4712a289-a6d2-4a33-b1ac-70fc8019863c",
                            TwoFactorEnabled = false
                        });
                });

            modelBuilder.Entity("EmployeeVacationCalendar.Data.Model.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("EmployeeVacationCalendar.Data.Model.Holiday", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ActiveFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ActiveTo")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateActiveOnly")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Day")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("Month")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Holiday");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0e8e75f7-0162-4d4d-9ab9-202a0fd9f233"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 1,
                            IsActive = true,
                            Month = 1,
                            Name = "Nova godina"
                        },
                        new
                        {
                            Id = new Guid("976114ca-89f1-4c1f-978f-d2c193feb9ba"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 6,
                            IsActive = true,
                            Month = 1,
                            Name = "Sveta tri kralja"
                        },
                        new
                        {
                            Id = new Guid("14e06b01-4d94-4611-a770-2221a9615a84"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            DateActiveOnly = new DateTime(2020, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "Uskrs"
                        },
                        new
                        {
                            Id = new Guid("01b80707-8064-4cdb-850b-e14dcd001694"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            DateActiveOnly = new DateTime(2020, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "Uskrsni ponedjeljak"
                        },
                        new
                        {
                            Id = new Guid("b9bf9f06-e4e2-4554-a9cf-8c489abe2b5f"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 1,
                            IsActive = true,
                            Month = 5,
                            Name = "Praznik rada"
                        },
                        new
                        {
                            Id = new Guid("eb562f61-7f4a-4081-a111-affcd0c34fa8"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 30,
                            IsActive = true,
                            Month = 5,
                            Name = "Dan državnosti"
                        },
                        new
                        {
                            Id = new Guid("f6201f94-7869-4fae-9010-ea5bdcd42f88"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            DateActiveOnly = new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "Tijelovo"
                        },
                        new
                        {
                            Id = new Guid("86f75a58-a4bd-43f4-9ae1-54f7bcf3ff54"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 22,
                            IsActive = true,
                            Month = 6,
                            Name = "Dan antifašističke borbe"
                        },
                        new
                        {
                            Id = new Guid("41bcc359-f8c3-4295-bed0-159bedf387de"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 5,
                            IsActive = true,
                            Month = 8,
                            Name = "Dan pobjede i domovinske zahvalnosti i Dan hrvatskih branitelja"
                        },
                        new
                        {
                            Id = new Guid("a9f885f7-51ed-4c52-894c-76d186d4f13e"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 15,
                            IsActive = true,
                            Month = 18,
                            Name = "Velika Gospa"
                        },
                        new
                        {
                            Id = new Guid("4d3dc849-26cb-4567-8673-4dcfb9bbac02"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 1,
                            IsActive = true,
                            Month = 11,
                            Name = "Dan svih svetih"
                        },
                        new
                        {
                            Id = new Guid("a528e711-4941-4b07-84ae-b3cc2b65a485"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 18,
                            IsActive = false,
                            Month = 11,
                            Name = "Dan sjećanja na žrtve Domovinskog rata i Dan sjećanja na žrtvu Vukovara i Škabrnje"
                        },
                        new
                        {
                            Id = new Guid("03781dfa-7b6c-451a-8336-4b85642bc90f"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 25,
                            IsActive = true,
                            Month = 12,
                            Name = "Božić"
                        },
                        new
                        {
                            Id = new Guid("837a9d1e-b129-4b12-8d55-8d64899df8a6"),
                            CountryId = new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"),
                            Day = 26,
                            IsActive = true,
                            Month = 12,
                            Name = "Sveti Stjepan"
                        });
                });

            modelBuilder.Entity("EmployeeVacationCalendar.Data.Model.Vacation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("VacationTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VacationTypeId");

                    b.ToTable("Vacation");

                    b.HasData(
                        new
                        {
                            Id = new Guid("da3e24f3-c82c-4347-9af9-622fd4429f68"),
                            DateFrom = new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2020, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6",
                            VacationTypeId = new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d")
                        },
                        new
                        {
                            Id = new Guid("bbf20b7a-700d-4fbe-ae2b-d296f3def6bd"),
                            DateFrom = new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2020, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6",
                            VacationTypeId = new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d")
                        },
                        new
                        {
                            Id = new Guid("87fd50ba-a5f8-4e64-ad4e-575d3024a651"),
                            DateFrom = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "928db46e-aee0-4835-8022-8df5a28f293d",
                            VacationTypeId = new Guid("08e635bc-f6eb-4462-8db2-0754113b28b2")
                        },
                        new
                        {
                            Id = new Guid("e27e7599-2b69-49e6-b0a3-05b70d064381"),
                            DateFrom = new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "928db46e-aee0-4835-8022-8df5a28f293d",
                            VacationTypeId = new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d")
                        },
                        new
                        {
                            Id = new Guid("483de956-387e-456f-b445-89c80762dd0b"),
                            DateFrom = new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6",
                            VacationTypeId = new Guid("b256ac8c-ada0-42a5-aa68-97beca81a1e9")
                        },
                        new
                        {
                            Id = new Guid("e31e1b95-8b47-4836-b8e9-9a36fd5b1ea9"),
                            DateFrom = new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateTo = new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6",
                            VacationTypeId = new Guid("b256ac8c-ada0-42a5-aa68-97beca81a1e9")
                        });
                });

            modelBuilder.Entity("EmployeeVacationCalendar.Data.Model.VacationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("VacationType");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d"),
                            Name = "Vacation Leave"
                        },
                        new
                        {
                            Id = new Guid("08e635bc-f6eb-4462-8db2-0754113b28b2"),
                            Name = "Sick Leave"
                        },
                        new
                        {
                            Id = new Guid("b256ac8c-ada0-42a5-aa68-97beca81a1e9"),
                            Name = "Holiday"
                        });
                });

            modelBuilder.Entity("EmployeeVacationCalendar.Areas.Identity.Data.ApplicationUser", b =>
                {
                    b.HasOne("EmployeeVacationCalendar.Data.Model.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EmployeeVacationCalendar.Data.Model.Vacation", b =>
                {
                    b.HasOne("EmployeeVacationCalendar.Areas.Identity.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeeVacationCalendar.Data.Model.VacationType", "VacationType")
                        .WithMany()
                        .HasForeignKey("VacationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

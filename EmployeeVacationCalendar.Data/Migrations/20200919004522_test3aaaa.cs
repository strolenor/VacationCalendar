using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeVacationCalendar.Data.Migrations
{
    public partial class test3aaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CountryId", "Email", "EmailConfirmed", "FirstName", "InactiveAfter", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6", 0, "0a940045-cfd7-400e-a3f1-b7a42e4f11aa", new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), "dsubic@gmail.com", false, "Darko", null, true, "Subić", false, null, null, null, null, null, false, "02569f04-eeb3-43dd-b4a6-32118eb2990a", false, null },
                    { "928db46e-aee0-4835-8022-8df5a28f293d", 0, "8282c82b-7b0a-45c7-99a2-a8cea66c9b02", new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), "testdoe@gmail.com", false, "John", null, false, "Doe", false, null, null, null, null, null, false, "80d6b671-01de-442c-b1ff-292fb87bad17", false, null },
                    { "acf3528d-020b-49bd-9990-5ccef31cc7af", 0, "62d4586f-d8c1-43d5-a494-8a7a2e66dc06", new Guid("71c5b630-6196-4743-a556-5833e8fde3d0"), "testnetko@gmail.com", false, "Nepoznati", null, false, "Netko", false, null, null, null, null, null, false, "30626547-bb25-4773-87fd-7b8f20ad2048", false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CountryId", "Email", "EmailConfirmed", "FirstName", "InactiveAfter", "IsActive", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "89401184-f1a0-419d-bd66-b20062f5edb4", 0, "f21d34b4-8c85-4570-93de-aed4d2029c8c", new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), "fired@gmail.com", false, "Fired", new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Employee", false, null, null, null, null, null, false, "2b4d9089-2a22-40ae-9933-9a7116b7adea", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "89401184-f1a0-419d-bd66-b20062f5edb4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "928db46e-aee0-4835-8022-8df5a28f293d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acf3528d-020b-49bd-9990-5ccef31cc7af");
        }
    }
}

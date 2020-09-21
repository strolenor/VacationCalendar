using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeVacationCalendar.Data.Migrations.VacationDb
{
    public partial class test3bbbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "InactiveAfter",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ApplicationUser",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "928db46e-aee0-4835-8022-8df5a28f293d",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "92b8b4be-fb4c-457e-9c71-acca681b107c", "testdoe@gmail.com", "c087c38e-a165-403e-9189-05c44a91cf3a" });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "8adbb3a4-42f7-4343-96e2-ed2c1ce20076", "dsubic@gmail.com", "369f4f7f-e4ac-47b1-be1e-396f772d39bb" });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "acf3528d-020b-49bd-9990-5ccef31cc7af",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "d924dba3-1f05-4e4a-8294-bc12b919e620", "testnetko@gmail.com", "676fb807-0916-4d0c-aed0-303cf0828d6b" });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CountryId", "Email", "EmailConfirmed", "FirstName", "InactiveAfter", "IsActive", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "89401184-f1a0-419d-bd66-b20062f5edb4", 0, "10a2eeff-5538-4edb-9cda-5571eec2962c", new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), "fired@gmail.com", false, "Fired", new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Employee", false, null, null, null, null, null, false, "4c7c6efc-ee88-4ff1-a56c-c3ab82b6cccb", false, null });

            migrationBuilder.UpdateData(
                table: "Holiday",
                keyColumn: "Id",
                keyValue: new Guid("a9f885f7-51ed-4c52-894c-76d186d4f13e"),
                column: "Month",
                value: 8);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "89401184-f1a0-419d-bd66-b20062f5edb4");

            migrationBuilder.DropColumn(
                name: "InactiveAfter",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ApplicationUser");

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "928db46e-aee0-4835-8022-8df5a28f293d",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "67f1869a-530a-442e-9ca7-dd3f9c4bac76", null, "83ac1e3a-b996-4bda-a331-cad26d4d688e" });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "a570fa96-934f-465d-917d-f58b4aa7284c", null, "718dba15-b6c2-4b7c-9d1f-569d4eefcdb0" });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "acf3528d-020b-49bd-9990-5ccef31cc7af",
                columns: new[] { "ConcurrencyStamp", "Email", "SecurityStamp" },
                values: new object[] { "43ef87de-1e38-49d0-bae9-f1700755f036", null, "50f068f0-f6d7-4ca8-b675-a767a5a29481" });

            migrationBuilder.UpdateData(
                table: "Holiday",
                keyColumn: "Id",
                keyValue: new Guid("a9f885f7-51ed-4c52-894c-76d186d4f13e"),
                column: "Month",
                value: 18);
        }
    }
}

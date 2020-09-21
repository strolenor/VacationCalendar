using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeVacationCalendar.Data.Migrations.VacationDb
{
    public partial class test3bbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "928db46e-aee0-4835-8022-8df5a28f293d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "67f1869a-530a-442e-9ca7-dd3f9c4bac76", "83ac1e3a-b996-4bda-a331-cad26d4d688e" });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a570fa96-934f-465d-917d-f58b4aa7284c", "718dba15-b6c2-4b7c-9d1f-569d4eefcdb0" });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "acf3528d-020b-49bd-9990-5ccef31cc7af",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "43ef87de-1e38-49d0-bae9-f1700755f036", "50f068f0-f6d7-4ca8-b675-a767a5a29481" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "928db46e-aee0-4835-8022-8df5a28f293d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7da8b8b3-b691-4c87-8d26-f74f1a669a12", "90645940-3249-4566-8fab-fc8f4db4c554" });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3eeb0ece-19aa-430e-bffe-b6178264819a", "e48c7043-84a4-4541-9c82-7fd93ed40eeb" });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "acf3528d-020b-49bd-9990-5ccef31cc7af",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "affa3836-83c5-4cb2-b895-9c7645a76833", "d526e5d6-92b9-4b44-b098-76a730c000df" });
        }
    }
}

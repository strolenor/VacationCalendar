using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeVacationCalendar.Data.Migrations.VacationDb
{
    public partial class test3bb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_CountryId",
                table: "Holiday",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Holiday_Country_CountryId",
                table: "Holiday",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holiday_Country_CountryId",
                table: "Holiday");

            migrationBuilder.DropIndex(
                name: "IX_Holiday_CountryId",
                table: "Holiday");

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "928db46e-aee0-4835-8022-8df5a28f293d",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c61da50f-dbf6-4d4b-85a4-4b2b825dadc7", "d38574a9-db48-4e9c-b6a9-86a6f3afa6fc" });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f4716341-add3-41c3-9812-6fcb9c330b1c", "d1cab2e6-3c85-467b-9dbd-c9e8ff9aa6ef" });

            migrationBuilder.UpdateData(
                table: "ApplicationUser",
                keyColumn: "Id",
                keyValue: "acf3528d-020b-49bd-9990-5ccef31cc7af",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "93946909-7c06-4b7b-9d5b-fac8969ced55", "4712a289-a6d2-4a33-b1ac-70fc8019863c" });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeVacationCalendar.Data.Migrations.VacationDb
{
    public partial class test3b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Day = table.Column<int>(nullable: true),
                    Month = table.Column<int>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ActiveFrom = table.Column<DateTime>(nullable: true),
                    ActiveTo = table.Column<DateTime>(nullable: true),
                    DateActiveOnly = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vacation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateFrom = table.Column<DateTime>(nullable: false),
                    DateTo = table.Column<DateTime>(nullable: false),
                    VacationTypeId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vacation_ApplicationUser_UserId",
                        column: x => x.UserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vacation_VacationType_VacationTypeId",
                        column: x => x.VacationTypeId,
                        principalTable: "VacationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CountryId", "Email", "EmailConfirmed", "FirstName", "IsAdmin", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6", 0, "f4716341-add3-41c3-9812-6fcb9c330b1c", new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, false, "Darko", true, "Subić", false, null, null, null, null, null, false, "d1cab2e6-3c85-467b-9dbd-c9e8ff9aa6ef", false, null },
                    { "928db46e-aee0-4835-8022-8df5a28f293d", 0, "c61da50f-dbf6-4d4b-85a4-4b2b825dadc7", new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, false, "John", false, "Doe", false, null, null, null, null, null, false, "d38574a9-db48-4e9c-b6a9-86a6f3afa6fc", false, null },
                    { "acf3528d-020b-49bd-9990-5ccef31cc7af", 0, "93946909-7c06-4b7b-9d5b-fac8969ced55", new Guid("71c5b630-6196-4743-a556-5833e8fde3d0"), null, false, "Nepoznati", false, "Netko", false, null, null, null, null, null, false, "4712a289-a6d2-4a33-b1ac-70fc8019863c", false, null }
                });

            migrationBuilder.InsertData(
                table: "Holiday",
                columns: new[] { "Id", "ActiveFrom", "ActiveTo", "CountryId", "DateActiveOnly", "Day", "IsActive", "Month", "Name" },
                values: new object[,]
                {
                    { new Guid("837a9d1e-b129-4b12-8d55-8d64899df8a6"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 26, true, 12, "Sveti Stjepan" },
                    { new Guid("03781dfa-7b6c-451a-8336-4b85642bc90f"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 25, true, 12, "Božić" },
                    { new Guid("a528e711-4941-4b07-84ae-b3cc2b65a485"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 18, false, 11, "Dan sjećanja na žrtve Domovinskog rata i Dan sjećanja na žrtvu Vukovara i Škabrnje" },
                    { new Guid("4d3dc849-26cb-4567-8673-4dcfb9bbac02"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 1, true, 11, "Dan svih svetih" },
                    { new Guid("a9f885f7-51ed-4c52-894c-76d186d4f13e"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 15, true, 18, "Velika Gospa" },
                    { new Guid("41bcc359-f8c3-4295-bed0-159bedf387de"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 5, true, 8, "Dan pobjede i domovinske zahvalnosti i Dan hrvatskih branitelja" },
                    { new Guid("86f75a58-a4bd-43f4-9ae1-54f7bcf3ff54"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 22, true, 6, "Dan antifašističke borbe" },
                    { new Guid("f6201f94-7869-4fae-9010-ea5bdcd42f88"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), new DateTime(2020, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, "Tijelovo" },
                    { new Guid("eb562f61-7f4a-4081-a111-affcd0c34fa8"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 30, true, 5, "Dan državnosti" },
                    { new Guid("b9bf9f06-e4e2-4554-a9cf-8c489abe2b5f"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 1, true, 5, "Praznik rada" },
                    { new Guid("01b80707-8064-4cdb-850b-e14dcd001694"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), new DateTime(2020, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, "Uskrsni ponedjeljak" },
                    { new Guid("14e06b01-4d94-4611-a770-2221a9615a84"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), new DateTime(2020, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, "Uskrs" },
                    { new Guid("976114ca-89f1-4c1f-978f-d2c193feb9ba"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 6, true, 1, "Sveta tri kralja" },
                    { new Guid("0e8e75f7-0162-4d4d-9ab9-202a0fd9f233"), null, null, new Guid("2d2bf15e-4ecb-404a-9008-05b9d7408cee"), null, 1, true, 1, "Nova godina" }
                });

            migrationBuilder.InsertData(
                table: "VacationType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d"), "Vacation Leave" },
                    { new Guid("08e635bc-f6eb-4462-8db2-0754113b28b2"), "Sick Leave" },
                    { new Guid("b256ac8c-ada0-42a5-aa68-97beca81a1e9"), "Holiday" }
                });

            migrationBuilder.InsertData(
                table: "Vacation",
                columns: new[] { "Id", "DateFrom", "DateTo", "UserId", "VacationTypeId" },
                values: new object[,]
                {
                    { new Guid("da3e24f3-c82c-4347-9af9-622fd4429f68"), new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6", new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d") },
                    { new Guid("bbf20b7a-700d-4fbe-ae2b-d296f3def6bd"), new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6", new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d") },
                    { new Guid("e27e7599-2b69-49e6-b0a3-05b70d064381"), new DateTime(2020, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "928db46e-aee0-4835-8022-8df5a28f293d", new Guid("ed4c240c-3ad4-473c-a865-7989bdded53d") },
                    { new Guid("87fd50ba-a5f8-4e64-ad4e-575d3024a651"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "928db46e-aee0-4835-8022-8df5a28f293d", new Guid("08e635bc-f6eb-4462-8db2-0754113b28b2") },
                    { new Guid("483de956-387e-456f-b445-89c80762dd0b"), new DateTime(2020, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6", new Guid("b256ac8c-ada0-42a5-aa68-97beca81a1e9") },
                    { new Guid("e31e1b95-8b47-4836-b8e9-9a36fd5b1ea9"), new DateTime(2020, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "943e6ef0-d8dd-46fc-9884-8a7cb597ebb6", new Guid("b256ac8c-ada0-42a5-aa68-97beca81a1e9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_CountryId",
                table: "ApplicationUser",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_UserId",
                table: "Vacation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacation_VacationTypeId",
                table: "Vacation",
                column: "VacationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationType_Name",
                table: "VacationType",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "Vacation");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "VacationType");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}

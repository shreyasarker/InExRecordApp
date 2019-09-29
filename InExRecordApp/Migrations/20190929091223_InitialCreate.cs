using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InExRecordApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    ContactNo = table.Column<string>(type: "varchar(11)", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Designation = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExpenseType = table.Column<string>(type: "varchar(20)", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    ChequeNo = table.Column<string>(type: "varchar(100)", nullable: true),
                    BankName = table.Column<string>(type: "varchar(250)", nullable: true),
                    Particular = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IncomeType = table.Column<string>(type: "varchar(20)", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    ChequeNo = table.Column<string>(type: "varchar(100)", nullable: true),
                    BankName = table.Column<string>(type: "varchar(250)", nullable: true),
                    Particular = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "ContactNo", "Designation", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Banani", "01713747775", "Sr. Accountant", "siddharthya@gmail.com", "Siddharthya Chowdhury", "$2b$10$skj3F34wsh1Ibp1w7YkWRuUxIl1E.lmyAMbkjARJNxnkECa7s5MjK" },
                    { 2, "Dhanmondi", "01916747456", "Jr. Accountant", "sohini@gmail.com", "Sohini Azam", "$2b$10$zaN7m9AYrgPa8aqPBeZLd.AVonVuWcvuFxowLqGuNDhCwTEK.1NPK" },
                    { 3, "Mohakhali DOHS", "01816749274", "Jr. Accountant", "sen@gmail.com", "A K Sen", "$2b$10$w5X8zTKisxAWuYJ/rp5W0Ong0S.GU6Veht1/XN5ed28by0p/P3Ntm" },
                    { 4, "Gulshan", "01772939284", "Sr. Accountant", "thomas@gmail.com", "Thomas Barua", "$2b$10$OqP8jyPp189i13aQ7xsYAu06D4JuSUCZn3ilT8IT5odmXrpobMWAi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_UserId",
                table: "Expenses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_UserId",
                table: "Incomes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProcessPensionModule.Migrations
{
    public partial class ProcessPension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PensionerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AadharNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PAN = table.Column<string>(nullable: true),
                    SalaryEarned = table.Column<double>(nullable: false),
                    Allowances = table.Column<double>(nullable: false),
                    PensionType = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    BankType = table.Column<string>(nullable: true),
                    PensionAmount = table.Column<double>(nullable: false),
                    BankServiceCharge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PensionerDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PensionerDetails");
        }
    }
}

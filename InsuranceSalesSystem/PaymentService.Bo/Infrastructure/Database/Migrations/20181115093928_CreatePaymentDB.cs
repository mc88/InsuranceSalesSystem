using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentService.Bo.Infrastructure.Database.Migrations
{
    public partial class CreatePaymentDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyAccount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolicyNumber = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountOperation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EffectiveDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    RegistrationDate = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    PolicyAccountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountOperation_PolicyAccount_PolicyAccountId",
                        column: x => x.PolicyAccountId,
                        principalTable: "PolicyAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountOperation_PolicyAccountId",
                table: "AccountOperation",
                column: "PolicyAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountOperation");

            migrationBuilder.DropTable(
                name: "PolicyAccount");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PricingService.Bo.Infrastructure.Database.Migrations
{
    public partial class CreatePolicyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tariff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tariff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TariffVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoverFrom = table.Column<DateTime>(nullable: false),
                    CoverTo = table.Column<DateTime>(nullable: false),
                    TariffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TariffVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TariffVersion_Tariff_TariffId",
                        column: x => x.TariffId,
                        principalTable: "Tariff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoverPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 25, nullable: false),
                    AgeFrom = table.Column<int>(nullable: false),
                    AgeTo = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(19,4)", nullable: false),
                    TariffVersionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoverPrice_TariffVersion_TariffVersionId",
                        column: x => x.TariffVersionId,
                        principalTable: "TariffVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tariff",
                columns: new[] { "Id", "Code" },
                values: new object[] { 1, "GOLDEN_HEALTH" });

            migrationBuilder.InsertData(
                table: "TariffVersion",
                columns: new[] { "Id", "CoverFrom", "CoverTo", "TariffId" },
                values: new object[] { 1, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "TariffVersion",
                columns: new[] { "Id", "CoverFrom", "CoverTo", "TariffId" },
                values: new object[] { 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "CoverPrice",
                columns: new[] { "Id", "AgeFrom", "AgeTo", "Code", "Price", "TariffVersionId" },
                values: new object[,]
                {
                    { 1, 18, 28, "COVER1", 100m, 1 },
                    { 2, 29, 45, "COVER1", 120m, 1 },
                    { 3, 46, 65, "COVER1", 150m, 1 },
                    { 4, 18, 45, "COVER2", 200m, 1 },
                    { 5, 46, 65, "COVER2", 300m, 1 },
                    { 6, 18, 65, "COVER3", 135m, 1 },
                    { 7, 66, 999, "COVER3", 300m, 1 },
                    { 8, 18, 28, "COVER1", 110m, 2 },
                    { 9, 29, 45, "COVER1", 130m, 2 },
                    { 10, 46, 65, "COVER1", 160m, 2 },
                    { 11, 18, 45, "COVER2", 210m, 2 },
                    { 12, 46, 65, "COVER2", 310m, 2 },
                    { 13, 18, 65, "COVER3", 145m, 2 },
                    { 14, 66, 999, "COVER3", 310m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoverPrice_TariffVersionId",
                table: "CoverPrice",
                column: "TariffVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_TariffVersion_TariffId",
                table: "TariffVersion",
                column: "TariffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverPrice");

            migrationBuilder.DropTable(
                name: "TariffVersion");

            migrationBuilder.DropTable(
                name: "Tariff");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolicyService.Bo.Infrastructure.Database.Migrations
{
    public partial class CreatePolicyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolicyNumber = table.Column<string>(maxLength: 25, nullable: false),
                    ProductCode = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PolicyHolder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Pesel = table.Column<string>(maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyHolder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OfferNumber = table.Column<string>(maxLength: 25, nullable: false),
                    ProductCode = table.Column<string>(maxLength: 25, nullable: false),
                    PolicyHolderId = table.Column<int>(nullable: true),
                    OfferStatus = table.Column<int>(maxLength: 25, nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false),
                    ValidTo = table.Column<DateTime>(nullable: false),
                    PolicyFrom = table.Column<DateTime>(nullable: false),
                    PolicyTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offer_PolicyHolder_PolicyHolderId",
                        column: x => x.PolicyHolderId,
                        principalTable: "PolicyHolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicyVersion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PolicyNumber = table.Column<string>(maxLength: 25, nullable: false),
                    VersionNumber = table.Column<string>(maxLength: 25, nullable: false),
                    PolicyFrom = table.Column<DateTime>(nullable: false),
                    PolicyTo = table.Column<DateTime>(nullable: false),
                    VersionFrom = table.Column<DateTime>(nullable: false),
                    VersionTo = table.Column<DateTime>(nullable: false),
                    ProductCode = table.Column<string>(maxLength: 25, nullable: false),
                    PolicyStatus = table.Column<int>(maxLength: 25, nullable: false),
                    PolicyHolderId = table.Column<int>(nullable: true),
                    TotalPremium = table.Column<decimal>(nullable: false),
                    PolicyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyVersion_PolicyHolder_PolicyHolderId",
                        column: x => x.PolicyHolderId,
                        principalTable: "PolicyHolder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PolicyVersion_Policy_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OfferCover",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoverCode = table.Column<string>(maxLength: 25, nullable: false),
                    CoverFrom = table.Column<DateTime>(nullable: false),
                    CoverTo = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    OfferId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferCover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfferCover_Offer_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PolicyCover",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CoverCode = table.Column<string>(maxLength: 25, nullable: false),
                    CoverFrom = table.Column<DateTime>(nullable: false),
                    CoverTo = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PolicyVersionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyCover", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolicyCover_PolicyVersion_PolicyVersionId",
                        column: x => x.PolicyVersionId,
                        principalTable: "PolicyVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offer_PolicyHolderId",
                table: "Offer",
                column: "PolicyHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCover_OfferId",
                table: "OfferCover",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyCover_PolicyVersionId",
                table: "PolicyCover",
                column: "PolicyVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyVersion_PolicyHolderId",
                table: "PolicyVersion",
                column: "PolicyHolderId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyVersion_PolicyId",
                table: "PolicyVersion",
                column: "PolicyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferCover");

            migrationBuilder.DropTable(
                name: "PolicyCover");

            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "PolicyVersion");

            migrationBuilder.DropTable(
                name: "PolicyHolder");

            migrationBuilder.DropTable(
                name: "Policy");
        }
    }
}

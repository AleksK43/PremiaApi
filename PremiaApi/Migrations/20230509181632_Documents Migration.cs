using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremiaApi.Migrations
{
    /// <inheritdoc />
    public partial class DocumentsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Income = table.Column<double>(type: "float", nullable: false),
                    TimeConsuming = table.Column<float>(type: "real", nullable: false),
                    Drive = table.Column<double>(type: "float", nullable: true),
                    Month = table.Column<int>(type: "int", nullable: false),
                    InvoiceStatus = table.Column<bool>(type: "bit", nullable: false),
                    IsBonusCleared = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SettlementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documents");
        }
    }
}

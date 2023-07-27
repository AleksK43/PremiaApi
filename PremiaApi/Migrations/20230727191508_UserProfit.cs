using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremiaApi.Migrations
{
    /// <inheritdoc />
    public partial class UserProfit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "documents",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NewInvoice",
                table: "documents",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PreAccept",
                table: "documents",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "documents");

            migrationBuilder.DropColumn(
                name: "NewInvoice",
                table: "documents");

            migrationBuilder.DropColumn(
                name: "PreAccept",
                table: "documents");
        }
    }
}

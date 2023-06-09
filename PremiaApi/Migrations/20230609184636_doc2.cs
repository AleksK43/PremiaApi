using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremiaApi.Migrations
{
    /// <inheritdoc />
    public partial class doc2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBonusCleared",
                table: "documents");

            migrationBuilder.AlterColumn<string>(
                name: "InvoiceStatus",
                table: "documents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "InvoiceStatus",
                table: "documents",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsBonusCleared",
                table: "documents",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

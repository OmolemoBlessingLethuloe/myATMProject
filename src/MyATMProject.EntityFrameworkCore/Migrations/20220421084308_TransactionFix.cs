using Microsoft.EntityFrameworkCore.Migrations;

namespace MyATMProject.Migrations
{
    public partial class TransactionFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferAccount",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "RemainingBalance",
                table: "Transactions",
                newName: "CurrentBalance");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CurrentBalance",
                table: "Transactions",
                newName: "RemainingBalance");

            migrationBuilder.AddColumn<string>(
                name: "TransferAccount",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Ccd.Bidding.Manager.Library.Migrations
{
    public partial class ChangedResponseItemQuantityToAlternateQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ResponseItems",
                newName: "AlternateQuantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlternateQuantity",
                table: "ResponseItems",
                newName: "Quantity");
        }
    }
}

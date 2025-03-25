using Microsoft.EntityFrameworkCore.Migrations;

namespace Ccd.Bidding.Manager.Library.Migrations
{
    public partial class ChangedResponseItemUnitToAlternateUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ResponseItems");

            migrationBuilder.AddColumn<string>(
                name: "AlternateUnit",
                table: "ResponseItems",
                maxLength: 30,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AlternateUnit",
                table: "ResponseItems");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "ResponseItems",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}

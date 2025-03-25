using Microsoft.EntityFrameworkCore.Migrations;

namespace Ccd.Bidding.Manager.Library.Migrations
{
    public partial class importUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonElected",
                table: "ResponseItems");

            migrationBuilder.RenameColumn(
                name: "Building_Name",
                table: "Requestors",
                newName: "Building");

            migrationBuilder.AddColumn<string>(
                name: "ElectionReason",
                table: "ResponseItems",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Requestors",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldMaxLength: 255);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectionReason",
                table: "ResponseItems");

            migrationBuilder.RenameColumn(
                name: "Building",
                table: "Requestors",
                newName: "Building_Name");

            migrationBuilder.AddColumn<string>(
                name: "ReasonElected",
                table: "ResponseItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Requestors",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}

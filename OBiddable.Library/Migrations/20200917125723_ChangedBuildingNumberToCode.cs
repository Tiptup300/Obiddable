namespace Ccd.Bidding.Manager.Library.Migrations;

public partial class ChangedBuildingNumberToCode : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Building_Number",
            table: "Requestors",
            newName: "Code");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Code",
            table: "Requestors",
            newName: "Building_Number");
    }
}

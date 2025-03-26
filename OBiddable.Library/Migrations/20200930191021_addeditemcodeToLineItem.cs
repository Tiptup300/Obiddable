namespace Ccd.Bidding.Manager.Library.Migrations;

public partial class addeditemcodeToLineItem : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "ItemCode",
            table: "LineItems",
            type: "varchar(255)",
            maxLength: 255,
            nullable: true);

        migrationBuilder.AddColumn<int>(
            name: "ItemId",
            table: "LineItems",
            nullable: false,
            defaultValue: 0);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ItemCode",
            table: "LineItems");

        migrationBuilder.DropColumn(
            name: "ItemId",
            table: "LineItems");
    }
}

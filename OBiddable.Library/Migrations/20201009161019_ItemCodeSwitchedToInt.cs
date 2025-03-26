namespace Ccd.Bidding.Manager.Library.Migrations;

public partial class ItemCodeSwitchedToInt : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<int>(
            name: "ItemCode",
            table: "LineItems",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255,
            oldNullable: true);

        migrationBuilder.AlterColumn<int>(
            name: "Code",
            table: "Items",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(255)",
            oldMaxLength: 255);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<string>(
            name: "ItemCode",
            table: "LineItems",
            type: "varchar(255)",
            maxLength: 255,
            nullable: true,
            oldClrType: typeof(int));

        migrationBuilder.AlterColumn<string>(
            name: "Code",
            table: "Items",
            type: "varchar(255)",
            maxLength: 255,
            nullable: false,
            oldClrType: typeof(int));
    }
}

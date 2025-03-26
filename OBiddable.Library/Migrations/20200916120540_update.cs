namespace Ccd.Bidding.Manager.Library.Migrations;

public partial class update : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<decimal>(
            name: "Quantity",
            table: "LineItems",
            type: "decimal(18,5)",
            nullable: true,
            oldClrType: typeof(decimal),
            oldType: "decimal(18,5)");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AlterColumn<decimal>(
            name: "Quantity",
            table: "LineItems",
            type: "decimal(18,5)",
            nullable: false,
            oldClrType: typeof(decimal),
            oldType: "decimal(18,5)",
            oldNullable: true);
    }
}

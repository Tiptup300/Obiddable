namespace Ccd.Bidding.Manager.Library.Migrations;

public partial class addedElections : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MarkedElections",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                ItemId = table.Column<int>(nullable: false),
                ElectedResponseItemId = table.Column<int>(nullable: false),
                Reason = table.Column<string>(maxLength: 255, nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MarkedElections", x => x.Id);
                table.ForeignKey(
                    name: "FK_MarkedElections_ResponseItems_ElectedResponseItemId",
                    column: x => x.ElectedResponseItemId,
                    principalTable: "ResponseItems",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
                table.ForeignKey(
                    name: "FK_MarkedElections_Items_ItemId",
                    column: x => x.ItemId,
                    principalTable: "Items",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
            });

        migrationBuilder.CreateIndex(
            name: "IX_MarkedElections_ElectedResponseItemId",
            table: "MarkedElections",
            column: "ElectedResponseItemId");

        migrationBuilder.CreateIndex(
            name: "IX_MarkedElections_ItemId",
            table: "MarkedElections",
            column: "ItemId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MarkedElections");
    }
}

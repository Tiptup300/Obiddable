using Microsoft.EntityFrameworkCore.Migrations;

namespace Ccd.Bidding.Manager.Library.Migrations;
public partial class Init : Migration
 {
     protected override void Up(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.CreateTable(
             name: "Bids",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Bids", x => x.Id);
             });

         migrationBuilder.CreateTable(
             name: "Items",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 BidId = table.Column<int>(nullable: true),
                 Code = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                 Category = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                 Description = table.Column<string>(nullable: false),
                 Substitutable = table.Column<bool>(nullable: false),
                 Unit = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                 Last_Order_Price = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                 Price = table.Column<decimal>(type: "decimal(18,5)", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Items", x => x.Id);
                 table.ForeignKey(
                     name: "FK_Items_Bids_BidId",
                     column: x => x.BidId,
                     principalTable: "Bids",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);
             });

         migrationBuilder.CreateTable(
             name: "PurchaseOrders",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 BidId = table.Column<int>(nullable: true),
                 Vendor = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                 Building = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                 CreationDate = table.Column<DateTime>(nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                 table.ForeignKey(
                     name: "FK_PurchaseOrders_Bids_BidId",
                     column: x => x.BidId,
                     principalTable: "Bids",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);
             });

         migrationBuilder.CreateTable(
             name: "Requestors",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 BidId = table.Column<int>(nullable: true),
                 Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                 Building_Number = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                 Building_Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                 Password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Requestors", x => x.Id);
                 table.ForeignKey(
                     name: "FK_Requestors_Bids_BidId",
                     column: x => x.BidId,
                     principalTable: "Bids",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);
             });

         migrationBuilder.CreateTable(
             name: "VendorResponses",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 BidId = table.Column<int>(nullable: true),
                 VendorName = table.Column<string>(maxLength: 100, nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_VendorResponses", x => x.Id);
                 table.ForeignKey(
                     name: "FK_VendorResponses_Bids_BidId",
                     column: x => x.BidId,
                     principalTable: "Bids",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);
             });

         migrationBuilder.CreateTable(
             name: "LineItems",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 PurchaseOrderId = table.Column<int>(nullable: true),
                 Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                 PartNumber = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                 Unit = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                 Quantity = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                 Price = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                 AccountNumber = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                 Note = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_LineItems", x => x.Id);
                 table.ForeignKey(
                     name: "FK_LineItems_PurchaseOrders_PurchaseOrderId",
                     column: x => x.PurchaseOrderId,
                     principalTable: "PurchaseOrders",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);
             });

         migrationBuilder.CreateTable(
             name: "Requests",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 RequestorId = table.Column<int>(nullable: true),
                 Account_Number = table.Column<string>(type: "varchar(22)", maxLength: 22, nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Requests", x => x.Id);
                 table.ForeignKey(
                     name: "FK_Requests_Requestors_RequestorId",
                     column: x => x.RequestorId,
                     principalTable: "Requestors",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);
             });

         migrationBuilder.CreateTable(
             name: "ResponseItems",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 VendorResponseId = table.Column<int>(nullable: true),
                 ItemId = table.Column<int>(nullable: false),
                 Code = table.Column<string>(maxLength: 50, nullable: false),
                 Price = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                 Quantity = table.Column<decimal>(type: "decimal(18,5)", nullable: false),
                 Unit = table.Column<string>(maxLength: 30, nullable: false),
                 IsAlternate = table.Column<bool>(nullable: false),
                 AlternateDescription = table.Column<string>(maxLength: 500, nullable: true),
                 Elected = table.Column<bool>(nullable: false),
                 ReasonElected = table.Column<string>(nullable: true)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_ResponseItems", x => x.Id);
                 table.ForeignKey(
                     name: "FK_ResponseItems_Items_ItemId",
                     column: x => x.ItemId,
                     principalTable: "Items",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Cascade);
                 table.ForeignKey(
                     name: "FK_ResponseItems_VendorResponses_VendorResponseId",
                     column: x => x.VendorResponseId,
                     principalTable: "VendorResponses",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);
             });

         migrationBuilder.CreateTable(
             name: "RequestItems",
             columns: table => new
             {
                 Id = table.Column<int>(nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                 RequestId = table.Column<int>(nullable: true),
                 ItemId = table.Column<int>(nullable: false),
                 Quantity = table.Column<int>(nullable: false),
                 OverridePrice = table.Column<decimal>(type: "decimal(18,5)", nullable: false)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_RequestItems", x => x.Id);
                 table.ForeignKey(
                     name: "FK_RequestItems_Items_ItemId",
                     column: x => x.ItemId,
                     principalTable: "Items",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Cascade);
                 table.ForeignKey(
                     name: "FK_RequestItems_Requests_RequestId",
                     column: x => x.RequestId,
                     principalTable: "Requests",
                     principalColumn: "Id",
                     onDelete: ReferentialAction.Restrict);
             });

         migrationBuilder.CreateIndex(
             name: "IX_Items_BidId",
             table: "Items",
             column: "BidId");

         migrationBuilder.CreateIndex(
             name: "IX_LineItems_PurchaseOrderId",
             table: "LineItems",
             column: "PurchaseOrderId");

         migrationBuilder.CreateIndex(
             name: "IX_PurchaseOrders_BidId",
             table: "PurchaseOrders",
             column: "BidId");

         migrationBuilder.CreateIndex(
             name: "IX_RequestItems_ItemId",
             table: "RequestItems",
             column: "ItemId");

         migrationBuilder.CreateIndex(
             name: "IX_RequestItems_RequestId",
             table: "RequestItems",
             column: "RequestId");

         migrationBuilder.CreateIndex(
             name: "IX_Requestors_BidId",
             table: "Requestors",
             column: "BidId");

         migrationBuilder.CreateIndex(
             name: "IX_Requests_RequestorId",
             table: "Requests",
             column: "RequestorId");

         migrationBuilder.CreateIndex(
             name: "IX_ResponseItems_ItemId",
             table: "ResponseItems",
             column: "ItemId");

         migrationBuilder.CreateIndex(
             name: "IX_ResponseItems_VendorResponseId",
             table: "ResponseItems",
             column: "VendorResponseId");

         migrationBuilder.CreateIndex(
             name: "IX_VendorResponses_BidId",
             table: "VendorResponses",
             column: "BidId");
     }

     protected override void Down(MigrationBuilder migrationBuilder)
     {
         migrationBuilder.DropTable(
             name: "LineItems");

         migrationBuilder.DropTable(
             name: "RequestItems");

         migrationBuilder.DropTable(
             name: "ResponseItems");

         migrationBuilder.DropTable(
             name: "PurchaseOrders");

         migrationBuilder.DropTable(
             name: "Requests");

         migrationBuilder.DropTable(
             name: "Items");

         migrationBuilder.DropTable(
             name: "VendorResponses");

         migrationBuilder.DropTable(
             name: "Requestors");

         migrationBuilder.DropTable(
             name: "Bids");
     }
 }

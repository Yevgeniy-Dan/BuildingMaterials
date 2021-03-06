using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingMaterials.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    ChiefFullName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Manufacturer = table.Column<string>(maxLength: 50, nullable: false),
                    UnitCost = table.Column<decimal>(type: "money", nullable: false),
                    MinimumBatch = table.Column<int>(nullable: false),
                    ShelfLife = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Material_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    AmountToPay = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_Material_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Material",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_SupplierID",
                table: "Material",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MaterialID",
                table: "Order",
                column: "MaterialID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingMaterials.Migrations
{
    public partial class RegistrationIDGeneratedOptionNone : Migration
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
                name: "Facility",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    MaterialID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Facility_Material_MaterialID",
                        column: x => x.MaterialID,
                        principalTable: "Material",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Warehouse_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    RegistrationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityID = table.Column<int>(nullable: false),
                    WarehouseID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.RegistrationID);
                    table.ForeignKey(
                        name: "FK_Registration_Facility_FacilityID",
                        column: x => x.FacilityID,
                        principalTable: "Facility",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registration_Warehouse_WarehouseID",
                        column: x => x.WarehouseID,
                        principalTable: "Warehouse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Facility_MaterialID",
                table: "Facility",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SupplierID",
                table: "Material",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MaterialID",
                table: "Order",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_FacilityID",
                table: "Registration",
                column: "FacilityID");

            migrationBuilder.CreateIndex(
                name: "IX_Registration_WarehouseID",
                table: "Registration",
                column: "WarehouseID");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_OrderID",
                table: "Warehouse",
                column: "OrderID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}

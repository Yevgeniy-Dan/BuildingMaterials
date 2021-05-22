using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingMaterials.Migrations
{
    public partial class NewFieldRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMessageQty",
                table: "Registration");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErrorMessageQty",
                table: "Registration",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

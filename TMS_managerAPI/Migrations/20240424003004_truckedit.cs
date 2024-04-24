using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS_managerAPI.Migrations
{
    /// <inheritdoc />
    public partial class truckedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TruckId",
                table: "Trucks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TruckId",
                table: "Trucks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

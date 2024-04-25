using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS_managerAPI.Migrations
{
    /// <inheritdoc />
    public partial class editAssignments3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_Hauliers_HaulierId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_HaulierId",
                table: "Trucks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trucks_HaulierId",
                table: "Trucks",
                column: "HaulierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_Hauliers_HaulierId",
                table: "Trucks",
                column: "HaulierId",
                principalTable: "Hauliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

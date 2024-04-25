using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TMS_managerAPI.Migrations
{
    /// <inheritdoc />
    public partial class id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Drivers_DriverId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Hauliers_HaulierId",
                table: "Assignments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_Trucks_TruckId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_DriverId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_HaulierId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_TruckId",
                table: "Assignments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Assignments_DriverId",
                table: "Assignments",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_HaulierId",
                table: "Assignments",
                column: "HaulierId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TruckId",
                table: "Assignments",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Drivers_DriverId",
                table: "Assignments",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Hauliers_HaulierId",
                table: "Assignments",
                column: "HaulierId",
                principalTable: "Hauliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_Trucks_TruckId",
                table: "Assignments",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id");
        }
    }
}

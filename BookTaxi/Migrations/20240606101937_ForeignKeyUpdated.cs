using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTaxi.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Rides_UserId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_VehicleId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_RideId",
                table: "Ratings");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_UserId",
                table: "Rides",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_VehicleId",
                table: "Rides",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RideId",
                table: "Ratings",
                column: "RideId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Rides_UserId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_VehicleId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_RideId",
                table: "Ratings");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicles",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_UserId",
                table: "Rides",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rides_VehicleId",
                table: "Rides",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RideId",
                table: "Ratings",
                column: "RideId",
                unique: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTaxi.Migrations
{
    /// <inheritdoc />
    public partial class VehicleForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Rides_RideId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_RideId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RideId",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehcileId",
                table: "Rides",
                newName: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rides_VehicleId",
                table: "Rides",
                column: "VehicleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Vehicles_VehicleId",
                table: "Rides",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Vehicles_VehicleId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Rides_VehicleId",
                table: "Rides");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Rides",
                newName: "VehcileId");

            migrationBuilder.AddColumn<Guid>(
                name: "RideId",
                table: "Vehicles",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RideId",
                table: "Vehicles",
                column: "RideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Rides_RideId",
                table: "Vehicles",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "RideId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTaxi.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Rides_UserId",
                table: "Rides",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_RideId",
                table: "Ratings",
                column: "RideId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Rides_RideId",
                table: "Ratings",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "RideId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rides_Users_UserId",
                table: "Rides",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Rides_RideId",
                table: "Vehicles",
                column: "RideId",
                principalTable: "Rides",
                principalColumn: "RideId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_Rides_RideId",
                table: "Ratings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rides_Users_UserId",
                table: "Rides");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Rides_RideId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_RideId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Rides_UserId",
                table: "Rides");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_RideId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "RideId",
                table: "Vehicles");
        }
    }
}

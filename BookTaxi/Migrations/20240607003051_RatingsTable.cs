using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookTaxi.Migrations
{
    /// <inheritdoc />
    public partial class RatingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RiderRating",
                table: "Ratings",
                newName: "Ratings");

            migrationBuilder.RenameColumn(
                name: "DriverRating",
                table: "Ratings",
                newName: "RatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ratings",
                table: "Ratings",
                newName: "RiderRating");

            migrationBuilder.RenameColumn(
                name: "RatedBy",
                table: "Ratings",
                newName: "DriverRating");
        }
    }
}

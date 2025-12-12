using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class FinalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TourOffers",
                table: "TourOffers");

            migrationBuilder.RenameTable(
                name: "TourOffers",
                newName: "tourOffers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tourOffers",
                table: "tourOffers",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tourOffers",
                table: "tourOffers");

            migrationBuilder.RenameTable(
                name: "tourOffers",
                newName: "TourOffers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TourOffers",
                table: "TourOffers",
                column: "Id");
        }
    }
}

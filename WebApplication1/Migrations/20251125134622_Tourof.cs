using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Tourof : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "TourOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    heading = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourImages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationPng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RatingText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourOffers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropTable(
                name: "TourOffers");
        }
    }
}

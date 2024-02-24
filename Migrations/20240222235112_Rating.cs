using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovies.Migrations
{
    /// <summary>
    /// Migration for adding Rating column to the Movie table.
    /// </summary>
    public partial class Rating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Adding a new column for Rating to the Movie table
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Dropping the Rating column from the Movie table
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movie");
        }
    }
}

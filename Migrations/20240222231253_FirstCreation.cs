using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovies.Migrations
{
    /// <summary>
    /// Represents the initial migration for creating the Movie table.
    /// </summary>
    public partial class FirstCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create the 'Movie' table with specific columns
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    // Define 'Id' column as primary key with auto-increment
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    // 'Title' column for storing movie title
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    // 'ReleaseDate' column for storing movie release date
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    // 'Genre' column for storing movie genre
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    // 'Price' column for storing movie price
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                // Set primary key constraint for 'Id' column
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the 'Movie' table if the migration is rolled back
            migrationBuilder.DropTable(
                name: "Movie");
        }
    }
}

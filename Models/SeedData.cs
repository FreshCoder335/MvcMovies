using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovies.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        // Method to initialize database with seed data
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // Using statement ensures resources are properly released
            using (var context = new MvcMoviesContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMoviesContext>>()))
            {
                // Check if there are any movies in the database
                if (context.Movie.Any())
                {
                    return;   // Database has been seeded, no need to proceed
                }

                // If no movies exist in the database, add seed data
                context.Movie.AddRange(
                    // Sample movie entries
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "R",
                        Price = 7.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "PG",
                        Price = 8.99M
                    },
                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "PG",
                        Price = 9.99M
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "R",
                        Price = 3.99M
                    }
                );

                // Save changes to the database
                context.SaveChanges();
            }
        }
    }
}

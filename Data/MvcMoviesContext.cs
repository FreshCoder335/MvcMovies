using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovies.Data
{
    /// <summary>
    /// Represents the database context for the MvcMovies application.
    /// </summary>
    public class MvcMoviesContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MvcMoviesContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public MvcMoviesContext(DbContextOptions<MvcMoviesContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet of movies.
        /// </summary>
        public DbSet<Movie> Movie { get; set; } = default!;
    }
}

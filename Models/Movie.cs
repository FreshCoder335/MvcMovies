using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    /// <summary>
    /// Represents a movie entity.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Unique identifier for the movie.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the movie.
        /// </summary>
        public string? Title { get; set; }

        
        /// <summary>
        /// The release date of the movie.
        /// </summary>
        
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// The genre of the movie.
        /// </summary>
        public string? Genre { get; set; }

        /// <summary>
        /// The price of the movie.
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// The rating of the movie.
        /// </summary>
        public string? Rating { get; set; }
    }
}

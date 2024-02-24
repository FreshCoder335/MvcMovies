using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    
    // View model for displaying movies with filtering options.
    
    public class MovieGenreViewModel
    {
       
        // Gets or sets the list of movies.
        
        public List<Movie>? Movies { get; set; }

        
        // Gets or sets the select list of genres.
        
        public SelectList? Genres { get; set; }

        
        // Gets or sets the selected movie genre.
    
        public string? MovieGenre { get; set; }

        
        // Gets or sets the search string for filtering movies.
       
        public string? SearchString { get; set; }
    }
}

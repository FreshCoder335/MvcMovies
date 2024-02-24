using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using MvcMovies.Data;

namespace MvcMovies.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MvcMoviesContext _context;

        // Constructor to initialize the controller with DbContext
        public MoviesController(MvcMoviesContext context)
        {
            _context = context;
        }

        // GET: Movies
        // Index Action Method
        public async Task<IActionResult> Index(string movieGenre, string searchString)
        {
            // Checking if the movie entity set is null
            if (_context.Movie == null)
            {
                // Returning a problem response if the entity set is null
                return Problem("Entity set 'MvcMovieContext.Movie' is null.");
            }

            // LINQ query to retrieve distinct genres
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            // Querying for movies based on search criteria
            var movies = from m in _context.Movie
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            // Creating ViewModel to pass data to the view
            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            // Checking if movie id is null
            if (id == null)
            {
                return NotFound();
            }

            // Querying for a movie with the given id
            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);

            // If movie not found, return NotFound response
            if (movie == null)
            {
                return NotFound();
            }

            // Return the movie details view
            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            // Return the create movie view
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            // Validating model state and saving movie data
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Checking if movie id is null
            if (id == null)
            {
                return NotFound();
            }

            // Querying for a movie with the given id
            var movie = await _context.Movie.FindAsync(id);

            // If movie not found, return NotFound response
            if (movie == null)
            {
                return NotFound();
            }

            // Return the edit movie view
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            // Checking if movie id matches the provided id
            if (id != movie.Id)
            {
                return NotFound();
            }

            // Validating model state and updating movie data
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            // Checking if movie id is null
            if (id == null)
            {
                return NotFound();
            }

            // Querying for a movie with the given id
            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);

            // If movie not found, return NotFound response
            if (movie == null)
            {
                return NotFound();
            }

            // Return the delete movie view
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Querying for a movie with the given id
            var movie = await _context.Movie.FindAsync(id);

            // If movie found, remove it from the context
            if (movie != null)
            {
                _context.Movie.Remove(movie);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Redirect to the movie index page
            return RedirectToAction(nameof(Index));
        }

        // Method to check if a movie with a given id exists
        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}

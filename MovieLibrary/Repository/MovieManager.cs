using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Services;


namespace MovieLibrary.Repository
{
    public class MovieManager
    {
        static List<Movie> movies = new List<Movie>();
        public static void ManageMovies()
        {
            movies = DataSerializer.DeserializeMovies();
        }
        public static void AddNewMovie(int movieId, string movieName, string genre, int yearOfRelease)
        {
            int maxMovies = 5;
            if (movies.Count < maxMovies)
            {
                Movie newMovie = Movie.AddNewMoiveInfo(movieId, movieName, genre, yearOfRelease);
                movies.Add(newMovie);
            }
            else
                throw new CapacityFullException("You Can Add Upto Five Movies Only..\n" +
                    ".....................................................");
        }

        public static List<Movie> DisplayMovies()
        {
            if (movies.Count() == 0)
            {
                throw new MovieStoreIsEmptyException("Movie store is empty..Nothing to display..\n" +
                    ".....................................................");
            }
            else
                return movies;
        }
        public static Movie FindMovieById(int id)
        {
            Movie findMovie = null;
            foreach (Movie movie in movies)
            {
                if (movie.Id == id)
                    findMovie = movie;
            }
            if (findMovie != null)
            {
                return findMovie;
            }
            else
                throw new MovieNotFoundException("Movie Not Found..\n" +
                    ".....................................................");
        }
        public static void RemoveMovieById(int id) 
        {
            Movie findMovie = FindMovieById(id);
            if (findMovie == null)
                throw new MovieNotFoundException("Movie Not Found..\n" +
                    ".....................................................");
            else
                movies.Remove(findMovie);
        }
        public static void ClearAllMovies()
        {
            if (movies.Count() == 0)
                throw new MovieStoreIsEmptyException("Movie store is already empty..Nothing to clear..\n" +
                    ".....................................................");
            else
                movies.Clear();
        }
        public static void ExitMovies()
        {
            DataSerializer.SerializeMovies(movies);
        }
    }
}

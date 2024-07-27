using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibrary.Exceptions;
using MovieLibrary.Models;
using MovieLibrary.Repository;

namespace MovieStoreManagement.ViewControllers
{
    internal class MovieStore
    {
        public static void DisplayMenu()
        {
            MovieManager.ManageMovies();
            Console.WriteLine("----------------------WELCOME----------------------\n");
            while (true)
            {
                Console.WriteLine("What do you wish to do?\n" +
                    "1.Add New Movie\n" +
                    "2.Display All Movies\n" +
                    "3.Find Movie By Id\n" +
                    "4.Remove Movie By Id\n" +
                    "5.Clear All Movies\n" +
                    "6.Exit\n\n" +
                    "Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(".....................................................");
                try
                {
                    DoTask(choice);
                }
                catch (CapacityFullException cf) { Console.WriteLine(cf.Message); }
                catch (MovieStoreIsEmptyException mse) { Console.WriteLine(mse.Message); }
                catch (MovieNotFoundException mnf) { Console.WriteLine(mnf.Message); }
                catch (FormatException fe) { Console.WriteLine(fe.Message); }
            }
        }
        static void DoTask(int choice)
        {
            switch (choice)
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    Find();
                    break;
                case 4:
                    Remove();
                    break;
                case 5:
                    MovieManager.ClearAllMovies();
                    Console.WriteLine("All Movies Were Cleared Successfully\n" +
                        ".....................................................");
                    break;
                case 6:
                    MovieManager.ExitMovies();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Please enter valid input..");
                    break;
            }
        }
        public static void Add()
        {
            int movieId = 0, yearOfRelease = 0;
            Console.WriteLine("Enter Movie Id: ");
            movieId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Movie Name: ");
            string movieName = Console.ReadLine();
            Console.WriteLine("Enter Genre: ");
            string genre = Console.ReadLine();
            Console.WriteLine("Enter Year of Release (YYYY): ");
            yearOfRelease = Convert.ToInt32(Console.ReadLine());
            MovieManager.AddNewMovie(movieId, movieName, genre, yearOfRelease);
            Console.WriteLine("New Movie Added Successfully..\n" +
                ".....................................................");

        }
        public static void Display()
        {
            var movies = MovieManager.DisplayMovies();
            foreach (Movie movie in movies)
            {
                Console.WriteLine(movie);
                Console.WriteLine(".....................................................");
            }
        }
        public static void Find()
        {
            Console.WriteLine("Enter Movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(MovieManager.FindMovieById(id));
        }
        public static void Remove()
        {
            Console.WriteLine("Enter Movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            MovieManager.RemoveMovieById(id);
            Console.WriteLine("Movie Deleted Successfully..\n" +
                ".....................................................");
        }
    }
}

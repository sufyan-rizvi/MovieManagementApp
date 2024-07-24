using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MovieStoreManagementApp.Exceptions;
using MovieStoreManagementApp.Models;
using MovieStoreManagementApp.Repository;
using MovieStoreManagementApp.Services;

namespace MovieStoreManagementApp.ViewController
{
    internal class MovieController
    {
        static Movie findMovie;
        public static void ShowMenu()
        {
            new MovieManager();
            Console.WriteLine("Welcome to movie store developed by: Sufyan Rizvi");

            while (true)
            {
                findMovie = null;

                Console.WriteLine("1. Add new Movie\r\n" +
                    "2. Display All Movies\r\n" +
                    "3. Find Movie by ID\r\n" +
                    "4. Remove Movie by ID\r\n" +
                    "5. Clear All Movies\r\n" +
                    "6. Exit");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    ChooseOption(choice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }


        static void ChooseOption(int choice)
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
                    Clear();
                    break;

                case 6:
                    Exit();
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Enter a valid option !");
                    break;
            }

        }

        static void Add()
        {
            if (MovieManager.movies.Count >= Movie.MAX_MOVIES)//Ask maam
                throw new CapacityFullException("The movie store is full ! Cannot add new Movies !");

            Console.WriteLine("Enter Movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Movie Name: ");
            string name = Console.ReadLine()!;

            Console.WriteLine("Enter year of release: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Genre: ");
            string genre = Console.ReadLine()!;

            MovieManager.AddMovie(id, year, name, genre);
            Console.WriteLine("Account Added !");
        }

        static void Display()
        {
            var movies = MovieManager.DisplayAllMovies();
            movies.ForEach(Console.WriteLine);
        }

        static void Find()
        {
            Console.Write("Enter the movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(MovieManager.FindMovieByID(id));            
        }

        static void Remove()
        {
            Console.Write("Enter the movie Id: ");
            int id = Convert.ToInt32(Console.ReadLine());

            MovieManager.RemoveMovie(id);
            Console.WriteLine("Movie removed successfully !");
        }

        static void Clear()
        {
            MovieManager.ClearAllMovies();
            Console.WriteLine("Movie List Cleared");
        }

        static void Exit()
        {
            MovieManager.SerializeMovie();
            Console.WriteLine("Exiting...");
        }
    }
}

using System.Security.Principal;
using System.Threading.Channels;
using MovieManagementApp.Models;

namespace MovieManagementApp
{
    internal class Program
    {
        public static List<Movie> movies = new List<Movie>();
        static Movie findMovie;
        static void Main(string[] args)
        {
            ShowMenu();
        }

        static void ShowMenu()
        {
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

                int choice = Convert.ToInt32(Console.ReadLine());
                ChooseOption(choice);

            }
        }

        static void ChooseOption(int choice)
        {

            switch (choice)
            {
                case 1:

                    if (movies.Count >= Movie.MAX_MOVIES)
                        Console.WriteLine("Maximum limit of movies reached in list !");
                    else
                        AddMovie();
                    break;

                case 2:
                    if (movies.Count == 0)
                        Console.WriteLine("No Movies in list, add a Movie first !");
                    else
                        DisplayAllMovies();
                    break;

                case 3:

                    findMovie = FindMovieByID();

                    if (findMovie == null)
                        Console.WriteLine("No movie found with that id !");
                    else
                    {
                        Console.WriteLine(findMovie);
                    }
                    break;

                case 4:

                    findMovie = FindMovieByID();
                    if (findMovie == null)
                        Console.WriteLine("No movie found");
                    else
                    {
                        movies.Remove(findMovie);
                        Console.WriteLine("Movie removed successfully !");
                    }
                    break;

                case 5:

                    movies.Clear();
                    Console.WriteLine("Movie List Cleared");
                    break;

                case 6:

                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Enter a valid option !");
                    break;
            }



            static Movie FindMovieByID()
            {

                Console.Write("Enter the movie Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                findMovie = movies.Where(movie => movie.Id == id).FirstOrDefault();

                return findMovie;

            }
            static void DisplayAllMovies()
            {
                if (movies.Count == 0)
                    Console.WriteLine("No movies to display !");
                else
                    movies.ForEach(movie => Console.WriteLine(movie));
            }
            static void AddMovie()
            {
                Console.WriteLine("Enter Movie Id: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Movie Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter year of release: ");
                int year = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Genre: ");
                string genre = Console.ReadLine();


                movies.Add(new Movie { Id = id, Name = name, YearOfRelease = year, Genre = genre });
            }


        }
    }
}

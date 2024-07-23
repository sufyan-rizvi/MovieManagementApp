using System.Configuration;
using System.Security.Principal;
using System.Text.Json;
using System.Threading.Channels;
using MovieStoreManagementApp.Models;
using MovieStoreManagementApp.Exceptions;


namespace MovieStoreManagementApp
{
    internal class Program
    {
        static string path = ConfigurationManager.AppSettings["filePath"]!.ToString();
        public static List<Movie> movies = new List<Movie>();
        static Movie findMovie;
        static void Main(string[] args)
        {
            ShowMenu();
        }


        static void ShowMenu()
        {
            Deserialize();
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
                try
                {
                    ChooseOption(choice);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        static void Serialize()
        {
            string toJson = JsonSerializer.Serialize(movies);
            File.WriteAllText(path, Environment.NewLine + toJson);
        }

        static void Deserialize()
        {
            if (!File.Exists(path))
            {
                movies = new List<Movie>();
            }
            else
            {
                movies = JsonSerializer.Deserialize<List<Movie>>(File.ReadAllText(path))!;
            }
        }
        static void ChooseOption(int choice)
        {

            switch (choice)
            {
                case 1:
                    if (movies.Count >= Movie.MAX_MOVIES)
                        throw new CapacityFullException("The movie store is full ! Cannot add new Movies !");
                    try
                    {
                        AddMovie();
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine(fe.Message);
                    }
                    break;


                case 2:
                    if (movies.Count == 0)
                        throw new MovieStoreEmptyException("No Movies in the store ! ");
                    DisplayAllMovies();
                    break;


                case 3:
                    findMovie = FindMovieByID();
                    if (findMovie == null)
                        throw new MovieNotFoundException("No Movie with the specified ID !");
                    Console.WriteLine(findMovie);
                    break;


                case 4:
                    try
                    {
                        findMovie = FindMovieByID();
                    }
                    catch (FormatException fe) { Console.WriteLine(fe.Message); }
                    if (findMovie == null)
                        throw new MovieNotFoundException("No Movie with the specified ID ! ");
                    movies.Remove(findMovie);
                    Console.WriteLine("Movie removed successfully !");
                    break;


                case 5:
                    if (movies.Count == 0)
                        throw new MovieStoreEmptyException("No movies in store ! Nothing to Clear !");
                    movies.Clear();
                    Console.WriteLine("Movie List Cleared");
                    break;

                case 6:
                    Serialize();
                    Console.WriteLine("Exiting...");
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Enter a valid option !");
                    break;
            }



            static Movie FindMovieByID()
            {
                int id = 0;
                Console.Write("Enter the movie Id: ");

                id = Convert.ToInt32(Console.ReadLine());

                findMovie = movies.Where(movie => movie.Id == id).FirstOrDefault()!;
                return findMovie;
            }

            static void DisplayAllMovies()
            {
                movies.ForEach(movie => Console.WriteLine(movie));
            }


            static void AddMovie()
            {
                int id = 0, year = 0;
                string genre = "", name = "";

                Console.WriteLine("Enter Movie Id: ");
                id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Movie Name: ");
                name = Console.ReadLine()!;

                Console.WriteLine("Enter year of release: ");
                year = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Genre: ");
                genre = Console.ReadLine()!;



                movies.Add(new Movie { Id = id, Name = name, YearOfRelease = year, Genre = genre });
            }


        }
    }
}

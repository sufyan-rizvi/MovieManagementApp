using System.Configuration;
using System.Security.Principal;
using System.Text.Json;
using System.Threading.Channels;
using MovieStoreManagementApp.Models;
using MovieStoreManagementApp.Exceptions;
using MovieStoreManagementApp.Services;
using MovieStoreManagementApp.Repository;
using MovieStoreManagementApp.ViewController;


namespace MovieStoreManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieController.ShowMenu();
        }
    }
}

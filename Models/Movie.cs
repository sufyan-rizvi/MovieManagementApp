using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreManagementApp.Models
{
    internal class Movie
    {
         
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Genre {  get; set; }

        public override string ToString()
        {
            return $"===================================================\n" +
                $"Movie Id: {Id}\n" +
                $"Movie Name: {Name}\n" +
                $"Year of Release: {YearOfRelease}\n" +
                $"Genre: {Genre}\n";
        }


    }
}

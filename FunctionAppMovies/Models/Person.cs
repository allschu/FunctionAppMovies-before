using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppMovies.Models
{
    public class Person
    {
        public int id { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public string known_for_department { get; set; }
        public string deathday { get; set; }
        public string[] also_known_as { get; set; }
        public string biography { get; set; }
        public string place_of_birth { get; set; }
        public string profile_path  { get; set; }
        public string imdb_id { get; set; }
        public string homepage { get; set;}
    }
}

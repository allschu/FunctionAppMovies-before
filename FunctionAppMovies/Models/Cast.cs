using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppMovies.Models
{
    public class Cast
    {
        public int id { get; set; }
        public string name { get; set; }
        public string original_name { get; set; }
        public string character { get; set; }
        public int order { get; set; }
        public string profile_path { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppMovies.Models
{
    public class CastSelection
    {
        public int Id { get; set; }
        public ICollection<Cast> Cast { get; set; }
    }
}

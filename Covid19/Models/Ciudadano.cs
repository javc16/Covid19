using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class Ciudadano
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string numeroIdentidad { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int edad { get; set; }
        public int estado { get; set; }

    }
}

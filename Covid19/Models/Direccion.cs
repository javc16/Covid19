using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class Direccion
    {
        public int id { get; set; }
        public string ciudad { get; set; }
        public string colonia { get; set; }
        public string centroVacunacion { get; set; }
        public int estado { get; set; }
    }
}

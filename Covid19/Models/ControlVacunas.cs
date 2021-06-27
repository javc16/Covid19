using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.Models
{
    public class ControlVacunas
    {
        public int id { get; set; }
        public int idCiudadano { get; set; }
        public Ciudadano ciudadano { get; set; }
        public int idDireccion { get; set; }
        public Direccion direccion { get; set; }
        public int primeraDosis { get; set; }
        public int segundaDosis { get; set; }
        public int estado { get; set; }
    }
}

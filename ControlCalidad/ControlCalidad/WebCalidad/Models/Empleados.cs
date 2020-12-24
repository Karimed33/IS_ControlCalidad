using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalidad.Modelo
{
   public class Empleados
    {
      
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public int Dni { get; set; }
        public string Mail { get; set; }
        public string Estado { get; set; }
        public string Cargo { get; set; }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidadDominio.Modelo
{
    public class Empleados
    {
      
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombres { get; set; }
        public int DNI { get; set; }
        public string Mail { get; set; }
        public int IdCargo { get; set; }
       
    }
}

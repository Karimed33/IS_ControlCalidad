using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidadDominio.Modelo
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario{ get; set; }
        public string Contrase { get; set; }
        public int Dni { get; set; }   
        public int IdCargo { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalidadDispositivo.Modelo
{
    class Usuarios
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public int IdCargo { get; set; }
        public string Usuario1 { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; }
        public string ConPassword { get; set; }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Modelo
{
   public class Turno
    {
        public int Id { set; get; }
        public string Denominacion { set; get; }
        public string HoraInicio { set; get; }
        public string HoraFin { set; get; }

    }
}

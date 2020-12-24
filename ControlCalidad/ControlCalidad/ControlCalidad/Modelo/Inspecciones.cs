using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Modelo
{
    public class Inspecciones
    {
        public int Id { get; set; }
        public int IdDefecto  { get; set; }
        public int Cantidad { get; set; }
        public string Hora  { get; set; }
        public string Fecha { get; set; }
        public string Pie { get; set; }
        public int CodOP { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorControlCalidad.Models
{
    public class AdministrarInspeccion
    {
        public int Id { get; set; }
        public int NumeroOP { get; set; }
        public int Dni { get; set; }
        public string Estado { get; set; }
        public string Hora { get; set; }
        public string Fecha { get; set; }
    }
}
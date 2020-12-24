using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorControlCalidad.Models
{
    public class OrdenProduccion
    {
        public int Id { get; set; }
        public int CodOP { get; set; }
        public string Detalle { get; set; }
        public string EstadoOP { get; set; }
        public string Color { get; set; }
        public string Modelo { get; set; }
        public int Objetivo { get; set; }
        public int DNI { get; set; }
        public int Linea { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }

    }
}
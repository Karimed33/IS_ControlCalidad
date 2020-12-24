using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalidadDispositivo.Modelo
{
    class AdministrarInspeccion
    {
        public int Id { get; set; }
        public int NumOP { get; set; }
        public int DniSupCalidad { get; set; }
        public string EstadoInspeccion {get;set;}
        public int Linea { get; set; } 

    }
}

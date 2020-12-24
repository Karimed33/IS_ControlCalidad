using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidadSistemaExterno.Adaptador
{
    public class AdapterModelo
    {
        Conectar conectar = new Conectar();
        public string CodigoModelo(string dato)
        {
            var api = "https://localhost:44315/api/Modelo_CodigoModelo{dato}?dato=" + dato;
            var resultado = conectar.Gets(api);
            return resultado;
        }

        public int CargarObjetivo(string modelo)
        {
            
            var api = "https://localhost:44315/api/Modelo_CargarObjetico{modelo}?modelo=" + modelo;
            var resultado = conectar.Gets(api);
            return int.Parse(resultado);
        }
    }
}

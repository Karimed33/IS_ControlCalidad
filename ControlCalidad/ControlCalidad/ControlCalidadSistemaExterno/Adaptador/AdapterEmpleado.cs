using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ControlCalidadDominio.Modelo;
using Newtonsoft.Json;

namespace ControlCalidadSistemaExterno.Adaptador
{
    public class AdapterEmpleado
    {
        Conectar conectar = new Conectar();

        public List<Cargos> ComboCargos()
        {
            var api = "https://localhost:44315/api/Empleado_MostrarCargos";
            var resultado = conectar.Gets(api);
            List<Cargos> list = new List<Cargos>();
            list = JsonConvert.DeserializeObject<List<Cargos>>(resultado);
            return list;
        }
    }
}

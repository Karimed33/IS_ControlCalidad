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
    public class AdapterrEmpleado
    {

        Conectar conectar = new Conectar();

        public List<CargosUsuarios> ComboCargos()
        {
            var api = "https://localhost:44315/api/Empleado_MostrarCargos";
            var resultado = conectar.Gets(api);
            List<CargosUsuarios> list = new List<CargosUsuarios>();
            list = JsonConvert.DeserializeObject<List<CargosUsuarios>>(resultado);
            return list;
        }

       
        public List<Empleados> Consulta(string dato)
        {
            var api = "https://localhost:44315/api/Empleados_Consulta{dato}?dato=" + dato;
            var resultado = conectar.Gets(api);
            List<Empleados> list = new List<Empleados>();
            list = JsonConvert.DeserializeObject<List<Empleados>>(resultado);
            return list;
        }

        public string Insertar(Empleados empleado)
        {
            var api = "https://localhost:44315/api/Empleados_Insertar{datos}";
            var resultado = conectar.Posts(api, empleado);
            return resultado;
        }

        public string Actualizar(Empleados empleado)
        {
            var api = "https://localhost:44315/api/Empleados_Actualizar{datos}";
            var resultado = conectar.Put(api, empleado);
            return resultado;
        }

        public string Eliminar(int id)
        {
            var api = "https://localhost:44315/api/Empleado_Eliminar{id}?id=" + id;
            var resultado = conectar.Delete(api);
            return resultado;
        }
    }
}

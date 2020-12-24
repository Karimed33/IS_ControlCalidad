using ControlCalidadDominio.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidadSistemaExterno.Adaptador
{
    public class AdapterModels
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

        public List<Modelos> ConsultaModelo(string dato)
        {
            var api = "https://localhost:44315/api/Modelo_ConsultaModelo{dato}?dato="+ dato;
            var resultado = conectar.Gets(api);
            List<Modelos> list = new List<Modelos>();
            list = JsonConvert.DeserializeObject<List<Modelos>>(resultado);
            return list;
        }

        public string Insertar(Modelos model)
        {
            var api = "https://localhost:44315/api/Modelo_InsertarModelo{modelo}";
            var resultado = conectar.Posts(api, model);
            return resultado;
        }

        public string Actualizar(Modelos model)
        {
            var api = "https://localhost:44315/api/Modelo_ActualizarModelo{datos}";
            var resultado = conectar.Put(api, model);
            return resultado;
        }

        public string Eliminar(int id)
        {
            var api = "https://localhost:44315/api/Modelo_EliminarModelo{id}?id=" + id;
            var resultado = conectar.Delete(api);
            return resultado;
        }
    }
}

using ControlCalidadDominio.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidadSistemaExterno.Adaptador
{
        public class AdapterColor
        {
            Conectar conectar = new Conectar();
            public List<Colores> Consulta(string dato)
            {
                var api = "https://localhost:44315/api/Color_ConsultaColor{dato}?dato=" + dato;
                var resultado = conectar.Gets(api);
                List<Colores> list = new List<Colores>();
                list = JsonConvert.DeserializeObject<List<Colores>>(resultado);
                return list;
            }

            public string Insertar(Colores color)
            {
                var api = "https://localhost:44315/api/Color_InsertarColor{color}";
                var resultado = conectar.Posts(api, color);
                return resultado;
            }

            public string Actualizar(Colores color)
            {
                var api = "https://localhost:44315/api/Color_Actualizar{datos}";
                var resultado = conectar.Put(api, color);
                return resultado;
            }

            public string Eliminar(int id)
            {
                var api = "https://localhost:44315/api/Color_EliminarColor{id}?id=" + id;
                var resultado = conectar.Delete(api);
                return resultado;
            }
        }
    }

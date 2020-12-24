using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using ControlCalidadDominio.Modelo;
using Newtonsoft.Json;

namespace ControlCalidadSistemaExterno.Adaptador
{
    public class AdapterUser
    {
        Conectar conectar = new Conectar();

        public string RegistrarUsuario(Usuarios user)
        {
            var api = "https://localhost:44315/api/Usuario_RegistrarUsuario";
            var resultado = conectar.Posts(api, user);
            return resultado;
        }

        public string ExisteUsuario(string user)
        {
            var api = "https://localhost:44315/api/Usuario_ExisteUsuario{usuario}?usuario=" + user;
            var resultado = conectar.Gets(api);
            return resultado;
        }
        public Usuarios GetLogueo(string usuario)
        {
            Usuarios user;
            var api = "https://localhost:44315/api/Usuario_Loguin{usuario}?usuario=";
            var apis = api + usuario;
            var resultado = conectar.Gets(apis);
            user = JsonConvert.DeserializeObject<Usuarios>(resultado);
            return user;
        }


        public CargosUsuarios TraerCargos(string usuario)
        {
            CargosUsuarios user;
            var api = "https://localhost:44315/api/Usuario_TraerCargos{usuario}?usuario=" + usuario;
            var resultado = conectar.Gets(api);
            user = JsonConvert.DeserializeObject<CargosUsuarios>(resultado);
            return user;
        }
        
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using ControlCalidadDominio.Modelo;
using Newtonsoft.Json;
using System.Net.Http.Formatting;


namespace ControlCalidadSistemaExterno.Adaptador
{
    public class AdapterOrdenProduccion
    {
        Conectar conectar = new Conectar();

        public string ValidaEmpleado(string estado, int dni)
        {
            var api = "https://localhost:44315/api/OrdenProduccion_ConsultaEmpleadoEnOP{estado,dni}?estado=" + estado + "&dni=" + dni;
            var resultado = conectar.Gets(api);
            return resultado;
        }
        public string AgregarOP(OrdenProduccion orden)
        {
            var api = "https://localhost:44315/api/OrdenProduccion_InsertarOP";
            var resultado = conectar.Posts(api, orden);
            return resultado;
        }

        public List<Modelos> ComboModelo()
        {
            var api = "https://localhost:44315/api/OrdenProduccion_MostrarModelos";
            var resultado = conectar.Gets(api);
            List<Modelos> list = new List<Modelos>();
            list = JsonConvert.DeserializeObject<List<Modelos>>(resultado);
            return list;
        }

        public List<Colores> MostrarColores()
        {
            var api = "https://localhost:44315/api/OrdenProduccion_MostrarColores";
            var resultado = conectar.Gets(api);
            List<Colores> list = new List<Colores>();
            list = JsonConvert.DeserializeObject<List<Colores>>(resultado);
            return list;
        }

        public List<LineaTrabajo> ConsultarLineasCreadas()
        {
            var api = "https://localhost:44315/api/OrdenProduccion_ConsultaLineasCreadas";
            var resultado = conectar.Gets(api);
            List<LineaTrabajo> list = new List<LineaTrabajo>();
            list = JsonConvert.DeserializeObject<List<LineaTrabajo>>(resultado);
            return list;
        }

        public List<OrdenProduccion> ConsultaOPActivas()
        {
            var api = "https://localhost:44315/api/OrdenProduccion_ConsultaOPActiva";
            var resultado = conectar.Gets(api);
            List<OrdenProduccion> list = new List<OrdenProduccion>();
            list = JsonConvert.DeserializeObject<List<OrdenProduccion>>(resultado);
            return list;
        }

         public OrdenProduccion TraerDatosSupLinea(int dni)
        {
            var api = "https://localhost:44315/api/OrdenProduccion_TraerDatos{dni}?dni="+dni;
            var resultado = conectar.Gets(api);
            OrdenProduccion op = new OrdenProduccion();
            op = JsonConvert.DeserializeObject<OrdenProduccion>(resultado);
            return op;

        }

        public AdministrarInspeccion TraerSupCalidad(int dni)
        {
            var api = "https://localhost:44315/api/OrdenProduccion_TraerInspecciones{dni}?dni=" + dni;
            var resultado = conectar.Gets(api);
            AdministrarInspeccion op = new AdministrarInspeccion();
            op = JsonConvert.DeserializeObject<AdministrarInspeccion>(resultado);
            return op;

        }

        public string ActualizarEstadosOP(string estado, int codOP, string fecha)
        {
            var api = "https://localhost:44315/api/OrdenProduccion_ActualizarEstadosOP{codOP,estado,fecha}?codOP=" + codOP + "&estado=" + estado + "&fecha=" + fecha;
            var resultado = conectar.Puts(api, codOP);
            return resultado;
        }

        public string ActualizarEstadosInspeccion(int numeroOP, string estado)
        {
            var api = "https://localhost:44315/api/OrdenProduccion_ActualizarEstadosInspeccion{numeroOP,estado}" + numeroOP + "&estado=" + estado;
            var resultado = conectar.Puts(api, numeroOP);
            return resultado;
        }
    }
}

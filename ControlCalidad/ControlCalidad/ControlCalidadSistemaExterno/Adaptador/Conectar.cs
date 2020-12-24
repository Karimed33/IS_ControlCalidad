using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidadSistemaExterno.Adaptador
{
    public class Conectar
    {
        HttpClient client = new HttpClient();

        public string Gets(string api)
        {

            var resquet = client.GetAsync(api).Result;
            var stream = "";

            if (resquet.IsSuccessStatusCode)
            {
                stream = resquet.Content.ReadAsStringAsync().Result;
            }
            return stream;
        }

        /*public string GetsValidaEmpleado(string estado, int dni)
        {
            var api = "https://localhost:44315/api/OrdenProduccion_ConsultaEmpleadoEnOP{estado,dni}?estado=" + estado + "&dni=" + dni;
            var resquet = client.GetAsync(api).Result;
            var stream = "";

            if (resquet.IsSuccessStatusCode)
            {
                stream = resquet.Content.ReadAsStringAsync().Result;
            }
            return stream;
        }*/


        public string Posts<T>(string api, T orden)
        {

            var resquet = client.PostAsync(api, orden, new JsonMediaTypeFormatter()).Result;
            var stream = "";

            if (resquet.IsSuccessStatusCode)
            {
                stream = resquet.Content.ReadAsStringAsync().Result;
            }
            return stream;
        }

        public string Put<T>(string api, T orden)
        {

            var resquet = client.PutAsync(api, orden, new JsonMediaTypeFormatter()).Result;
            var stream = "";

            if (resquet.IsSuccessStatusCode)
            {
                stream = resquet.Content.ReadAsStringAsync().Result;
            }
            return stream;
        }


        public string Puts(string api, int codOP)
        {

            var resquet = client.PutAsync(api, codOP, new JsonMediaTypeFormatter()).Result;
            var stream = "";

            if (resquet.IsSuccessStatusCode)
            {
                stream = resquet.Content.ReadAsStringAsync().Result;
            }
            return stream;
        }

        public string Delete(string api)
        {
            var resquet = client.DeleteAsync(api).Result;
            var stream = "";

            if (resquet.IsSuccessStatusCode)
            {
                stream = resquet.Content.ReadAsStringAsync().Result;
            }
            return stream;
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using ServidorControlCalidad.Models;
using System.Data;

namespace ServidorControlCalidad.Controllers
{
    public class OrdenProduccionController : ApiController
    {
        string _conexion =@"Data Source=localhost; Database = calidadis; User Id=root; Password= karimed3344";
        public readonly DateTime hoy = DateTime.Now;

        [HttpGet]
        [Route ("api/OrdenProduccion_ConsultaLinea{dato}")]
        public List<OrdenProduccion> ConsultaLinea( string dato)
        {
            List<OrdenProduccion> lista = new List<OrdenProduccion>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color, Objetivo, DNI, Linea, FechaInicio, FechaFin, HoraInicio, HoraFin FROM ordenpoduccion";
            }
            else
            {
                sql = "SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color, Objetivo, DNI, Linea, FechaInicio, FechaFin, HoraInicio, HoraFin FROM ordenpoduccion WHERE  EstadoOP = '"+dato+"'";
            }

            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
              
                    lista = (List<OrdenProduccion>)db.Query<OrdenProduccion>(sql);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
        }


        [HttpGet]
        [Route("api/OrdenProduccion_MostrarModelos")]
        public List<Modelos> MostrarModelos()
        {
            List<Modelos> dt = new List<Modelos>();
            string sql = "SELECT Id, CodigoModelo, Denominacion, Objetivo FROM modelos";
            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    dt = (List<Modelos>)db.Query<Modelos>(sql);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return dt;
        }

        [HttpGet]
        [Route("api/OrdenProduccion_MostrarColores")]
        public List<Colores> MostrarColores()
        {
            List<Colores> dt = new List<Colores>();
            string sql = "SELECT Id, CodigoColor, Descripcion FROM colores ORDER BY CodigoColor ASC";
            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    dt = (List<Colores>)db.Query<Colores>(sql);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return dt;
        }

        [HttpGet]
        [Route("api/OrdenProduccion_VerOP{codOP}")]
        public OrdenProduccion VerOP(int codOP)
        {
            OrdenProduccion _op = null;
            string sql = " SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color, Objetivo, DNI, Linea, FechaInicio, FechaFin, HoraInicio, HoraFin  FROM ordenpoduccion WHERE CodOP='" + codOP + "' ";

            try
            {
                using (var db = new MySqlConnection(_conexion))
                
                
                {
                    _op = (OrdenProduccion)db.QuerySingle<OrdenProduccion>(sql, codOP);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return _op;
        }

        [HttpGet]
        [Route("api/OrdenProduccion_TraerDatos{dni}")]
        public OrdenProduccion TraerDatos(int dni)
        {
            string estado = "Finalizado";
            OrdenProduccion _op = null;
            string sql = " SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color, Objetivo, DNI, Linea, FechaInicio, FechaFin, HoraInicio, HoraFin  FROM ordenpoduccion WHERE DNI='" + dni + "' AND EstadoOP != '" + estado + "' ";

            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    _op = (OrdenProduccion)db.QuerySingle<OrdenProduccion>(sql, dni);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return _op;
        }

        [HttpGet]
        [Route("api/OrdenProduccion_TraerInspecciones{dni}")]
        public AdministrarInspeccion TraerInspecciones(int dni)
        {
            var estado = "Finalizado";
            AdministrarInspeccion _ai = null;
            string sql = " SELECT Id, NumeroOP, Dni, Estado, Hora, Fecha  FROM asignacioninspeccion WHERE Dni='" + dni + "' AND Estado != '" + estado + "' ";
            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    _ai = (AdministrarInspeccion)db.QuerySingle<AdministrarInspeccion>(sql, dni);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return _ai;
        }

        [HttpGet]
        [Route("api/OrdenProduccion_ConsultaLineasCreadas")]
        public List<LineaTrabajo> ConsultaLineasCreadas()
        {
            List<LineaTrabajo> listaLinea = new List<LineaTrabajo>();
            string sql = "SELECT Id, Numero FROM lineatrabajo  ORDER BY Numero DESC ";

            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    listaLinea = (List<LineaTrabajo>)db.Query<LineaTrabajo>(sql);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return listaLinea;
        }


        [HttpGet]
        [Route("api/OrdenProduccion_ConsultaOPActiva")]
        public List<OrdenProduccion> ConsultaOPActivas()
        {
            string estado = "Finalizado";
            List<OrdenProduccion> listaOPActiva = new List<OrdenProduccion>();
            string sql = "SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color, Objetivo, DNI, Linea, FechaInicio, FechaFin FROM ordenpoduccion WHERE EstadoOP != '" + estado + "' ORDER BY CodOP DESC ";
            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    listaOPActiva = (List<OrdenProduccion>)db.Query<OrdenProduccion>(sql);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return listaOPActiva;
        }


        [HttpGet]
        [Route("api/OrdenProduccion_ConsultaEmpleadoEnOP{estado, dni}")]
        public string ConsultaEmpleadoEnOP(string estado, int dni)
        {
            string respuesta = null;
            OrdenProduccion _op = null; ;
            string sql = "SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color, Objetivo, DNI, Linea, FechaInicio, FechaFin, HoraInicio,HoraFin FROM ordenpoduccion WHERE EstadoOP != '" + estado + "' AND DNI= '" + dni + "' ";
            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                   _op = (OrdenProduccion)db.QueryFirst<OrdenProduccion>(sql, estado);

                    if (_op !=null)
                    {
                        respuesta = "Ud. ya tiene una OP asignada NO FINALIZADA ";
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return respuesta;
        }


        [HttpPost]
        [Route("api/OrdenProduccion_InsertarOP")]
        public string InsertarOP(OrdenProduccion op)
        {
            string respuesta;
            int resul = 0;
            string sql = "INSERT INTO ordenpoduccion (CodOP, Detalle, EstadoOP, Modelo, Color, Objetivo, DNI, Linea, FechaInicio, FechaFin, HoraInicio, HoraFin ) VALUES ('"+op.CodOP+"', '"+op.Detalle+"', '"+op.EstadoOP+"', '"+op.Modelo+"', '"+op.Color+"', '"+op.Objetivo+"', '"+op.DNI+"', '"+op.Linea+"', '"+op.FechaInicio+"', '"+op.FechaFin+"', '"+op.HoraInicio+"', '"+op.HoraFin+"')";
            try
            { 
            using (var db = new MySqlConnection(_conexion))
            {

                resul = db.Execute(sql);
            }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            if (resul != 0)
            {
                respuesta = "Se Guardo la OP con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar Guardar OP";
            }
            
            return respuesta;
        }


        [HttpPut]
        [Route("api/OrdenProduccion_ActualizarEstadosInspeccion{numeroOP, estado}")]
        public string ActualizarEstadosInspeccion(int numeroOP, string estado)
        {
            string respuesta;
            int resul = 0;
            string sql = "UPDATE asignacioninspeccion SET  Estado ='"+estado+"'  WHERE NumeroOP = '"+numeroOP+"'";

            try
            {
                using (var db = new MySqlConnection(_conexion))
                {

                    resul = db.Execute(sql);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            if (resul != 0)
            {
                respuesta = "Se Actualizo el Estado";
            }
            else
            {
                respuesta = "ERROR al intentar Cambiar Estado OP";
            }

            return respuesta;
        }

        [HttpPut]
        [Route("api/OrdenProduccion_ActualizarEstadosOP{codOP, estado, fecha}")]
        public string ActualizarEstadosOP(int codOP, string estado, string fecha)
        {
            var hora = hoy.ToShortTimeString();
            string respuesta, sql;
            int resul = 0;
            if (estado == "Finalizado")
            {
                sql = "UPDATE ordenpoduccion SET  EstadoOP = '" + estado + "', FechaFin = '" + fecha + "', HoraFin = '" + hora + "'  WHERE CodOP = '" + codOP + "'";
            }
            else
            {
                sql = "UPDATE ordenpoduccion SET  EstadoOP = '" + estado + "'  WHERE CodOP = '" + codOP + "'";
            }
            try
            {
                using (var db = new MySqlConnection(_conexion))
                {

                    resul = db.Execute(sql);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            if (resul != 0)
            {
                respuesta = "Se Actualizo el Estado";
            }
            else
            {
                respuesta = "ERROR al intentar Cambiar Estado OP";
            }

            return respuesta;
        }



        [HttpDelete]
        [Route("api/OrdenProduccion_Eliminar{id}")]
        public string EliminarOP(int id)
         {
             string respuesta = "";
             int resul = 0;
             string sql = "DELETE FROM ordenpoduccion WHERE Id = '"+id+"'";
             using (var db = new MySqlConnection(_conexion))
             {

                 resul = db.Execute(sql, id);
             }

             if (resul != 0)
             {
                 respuesta = "Se Elimino la OP con Exito";
             }
             else
             {
                 respuesta = "ERROR al intentar Eliminar";
             }

             return respuesta;
         }


    }
}

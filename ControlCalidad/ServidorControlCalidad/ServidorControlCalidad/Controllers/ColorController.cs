using Dapper;
using MySql.Data.MySqlClient;
using ServidorControlCalidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServidorControlCalidad.Controllers
{
    public class ColorController : ApiController
    {
        string _conexion = @"Data Source=localhost; Database = calidadis; User Id=root; Password= karimed3344";
        public readonly DateTime hoy = DateTime.Now;

        [HttpGet]
        [Route("api/Color_ConsultaColor{dato}")]
        public List<Colores> ConsultaColor(string dato)
        {
            List<Colores> lista = new List<Colores>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT Id, CodigoColor, Descripcion FROM colores"; 
            }
            else
            {
                sql = "SELECT Id, CodigoColor, Descripcion FROM colores WHERE CodigoColor LIKE '%" + dato + "%' OR Descripcion LIKE '%" + dato +"%'";
            }

            try
            {
                using (var db = new MySqlConnection(_conexion))
                {

                    lista = (List<Colores>)db.Query<Colores>(sql);
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
        }


        [HttpPost]
        [Route("api/Color_InsertarColor{color}")]
     
        public string InsertarColor(Colores color)
        {
            int resul = 0;
            string respuesta;
            string sql = "INSERT INTO colores (CodigoColor, Descripcion) VALUES ('" + color.CodigoColor + "',  '" + color.Descripcion + "')";
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
                respuesta = "Se el Color con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar Guardar";
            }
            return respuesta;
        }


        [HttpPut]
        [Route("api/Color_Actualizar{datos}")]
        public string Actualizar(Colores datos)
        {
            string respuesta;
            int resul = 0;
            string sql = "UPDATE colores SET  CodigoColor = '" + datos.CodigoColor + "', Descripcion = '" + datos.Descripcion + "'  WHERE Id = '" + datos.Id + "'";
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
                respuesta = "Se Actualizo el Color";
            }
            else
            {
                respuesta = "ERROR al intentar Actualizar";
            }
            return respuesta;
        }


        [HttpDelete]
        [Route("api/Color_EliminarColor{id}")]
        public string EliminarColor(int id)
        {
            string respuesta = "";
            int resul = 0;
            string sql = "DELETE FROM colores WHERE Id = '" + id + "'";
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
                respuesta = "Se Eliminó el Color";
            }
            else
            {
                respuesta = "ERROR al intentar Eliminar";
            }

            return respuesta;
        }
    }
}

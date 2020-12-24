using Dapper;
using MySql.Data.MySqlClient;
using ServicioControlCalidad.Datos.Models;
using ServidorControlCalidad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServidorControlCalidad.Controllers
{
    public class ModeloController : ApiController
    {
        string _conexion = @"Data Source=localhost; Database = calidadis; User Id=root; Password= karimed3344";
        public readonly DateTime hoy = DateTime.Now;

        [HttpGet]
        [Route("api/Modelo_ConsultaModelo{dato}")]
        public List<Modelos> ConsultaModelos(string dato)
        {  
            List<Modelos> lista = new List<Modelos>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT Id, CodigoModelo, Denominacion, Objetivo FROM modelos ORDER BY Denominacion ASC ";
            }
            else
            {
                sql = "SELECT Id, CodigoModelo, Denominacion, Objetivo FROM modelos WHERE CodigoModelo LIKE '%" + dato + "%' OR Denominacion LIKE '%" + dato + "%' ORDER BY Denominacion ASC ";
            }
            try
            {
                using (var db = new MySqlConnection(_conexion))
                {

                    lista = (List<Modelos>)db.Query<Modelos>(sql);
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
            }


        /*public string Validar(Modelos modelo)
        {
            string repuesta;
            if (string.IsNullOrEmpty(modelo.CodigoModelo) || string.IsNullOrEmpty(modelo.Denominacion))
            {
                repuesta = "Debe llenar todos los campos";
            }
            else
            {
                if (ExisteCodigo(modelo.CodigoModelo))
                {
                    repuesta = "El Codigo ingresado ya Existe";
                }
                else
                {
                    Insertar(modelo);
                    repuesta = "Usuario Registrado con Exito";
                }
            }

            return repuesta;
        }*/


        [HttpPost]
        [Route("api/Modelo_InsertarModelo{modelo}")]
        public string InsertarModelo(Modelos modelo)
        {
            int resul = 0;
            string respuesta;
            string sql = "INSERT INTO modelos (CodigoModelo, Denominacion, Objetivo) VALUES ('" + modelo.CodigoModelo + "',  '" + modelo.Denominacion + "', '" + modelo.Objetivo + "')";
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
                respuesta = "Se Registro el Modelo con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar Guardar";
            }
            return respuesta;
        }


        /*public bool ExisteCodigo(string modelo)
        {
            ConectaBD conexion = new ConectaBD();
            MySqlDataReader reader;
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "SELECT Id FROM modelos WHERE  CodigoModelo = @CodigoModelo ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            comando.Parameters.AddWithValue("@CodigoModelo", modelo);

            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

        [HttpPut]
        [Route("api/Modelo_ActualizarModelo{datos}")]
        public string ActualizarModelo(Modelos datos)
        {
            int resul = 0;
            string respuesta;
            string sql = "UPDATE modelos SET  CodigoModelo = '" + datos.CodigoModelo + "', Denominacion = '" + datos.Denominacion + "', Objetivo = '" + datos.Objetivo + "'  WHERE Id = '" + datos.Id + "'";
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
                respuesta = "Se Actualizo el Modelo";
            }
            else
            {
                respuesta = "ERROR al intentar Actualizar";
            }
            return respuesta;
        }


        [HttpDelete]
        [Route("api/Modelo_EliminarModelo{id}")]
        public string EliminarModelo(int id)
        {
            string respuesta = "";
            int resul = 0;
            string sql = "DELETE FROM modelos WHERE Id = '" + id + "'";
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
                respuesta = "Se Eliminó el Modelo";
            }
            else
            {
                respuesta = "ERROR al intentar Eliminar";
            }

            return respuesta;
        }


        [HttpGet]
        [Route("api/Modelo_CodigoModelo{dato}")]
        public string CodigoModelo(string dato)
        {
            string codigo = "";
            Modelos _op = new Modelos();
            string sql = "SELECT Id, CodigoModelo, Denominacion, Objetivo FROM modelos WHERE Denominacion = '" + dato + "' ORDER BY CodigoModelo ASC ";

            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    _op = (Modelos)db.QueryFirst<Modelos>(sql, dato);

                    if (_op != null)
                    {
                        codigo = _op.CodigoModelo ;
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return codigo;
        }

        [HttpGet]
        [Route("api/Modelo_CargarObjetico{modelo}")]
        public int CargarObjetivo(string modelo)
        {
            int objetivo = 0;
            Modelos _op = new Modelos();
            string sql = "SELECT Id, CodigoModelo, Denominacion, Objetivo FROM modelos WHERE CodigoModelo = '" + modelo + "' ORDER BY CodigoModelo ASC ";
            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    _op = (Modelos)db.QueryFirst<Modelos>(sql, modelo);

                    if (_op != null)
                    {
                        objetivo = _op.Objetivo;
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return objetivo;

        }

    }
}

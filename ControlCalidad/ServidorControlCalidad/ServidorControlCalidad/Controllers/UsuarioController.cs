using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;
using MySql.Data.MySqlClient;
using ServicioControlCalidad.Datos.Models;

namespace ServidorControlCalidad.Controllers
{
    public class UsuarioController : ApiController
    {
        string _conexion = @"Data Source=localhost; Database = calidadis; User Id=root; Password= karimed3344";
        public readonly DateTime hoy = DateTime.Now;


        [HttpGet]
        [Route("api/Usuario_Loguin{usuario}")]
        public Usuarios Login(string usuario)
        {
            Usuarios datoUsurio = new Usuarios();
            string sql = "SELECT Id, Usuario, Contrase, Dni, IdCargo FROM usuarios WHERE  Usuario = '"+usuario+"' ";
           try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    datoUsurio = (Usuarios)db.QuerySingle<Usuarios>(sql);
                    

                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return datoUsurio;

           
        }



        [HttpPost]
        [Route("api/Usuario_RegistrarUsuario{usuario}")]
        public string RegistrarUsuario(Usuarios usuario)
        {
            string respuesta;
            int resul = 0;
            string sql = "INSERT INTO usuarios (Usuario, Contrase, Dni, IdCargo) VALUE (@Usuario, @Contraseña, @Dni, @IdCargo)";

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
                respuesta = "Se Creo el Usuario con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar Crear Usuario";
            }

            return respuesta;
        }

        [HttpGet]
        [Route("api/Usuario_ExisteUsuario{usuario}")]
        public string ExisteUsuario(string usuario)
        {
            string respuesta = null;
            string sql = "SELECT Id FROM usuarios WHERE  Usuario = @Usuario ";

            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    var datoUsurio = (Usuarios)db.QuerySingle<Usuarios>(sql, usuario);
                    if(datoUsurio != null)
                    {
                        respuesta = "El usuario ya existe";
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return respuesta;
        }


        [HttpGet]
        [Route("api/Usuario_TraerCargos{usuario}")]
        public  CargosUsuarios TraerCargos(string usuario)
        {
            CargosUsuarios datoUsurio = new CargosUsuarios();
            string sql = "SELECT IdCargos, Cargos FROM cargosusuarios WHERE  Cargos = '" + usuario + "' ";
            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    datoUsurio = (CargosUsuarios)db.QuerySingle<CargosUsuarios>(sql);


                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return datoUsurio;
        }
    }
}

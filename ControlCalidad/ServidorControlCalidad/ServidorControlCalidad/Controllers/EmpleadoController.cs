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
using ServicioControlCalidad.Datos;


namespace ServidorControlCalidad.Controllers
{
    public class EmpleadoController : ApiController
    {
        string _conexion = @"Data Source=localhost; Database = calidadis; User Id=root; Password= karimed3344";
        public readonly DateTime hoy = DateTime.Now;

        [HttpGet]
        [Route("api/Empleados_Consulta{dato}")]
        public List<Empleados> Consulta(string dato)
        {
            List<Empleados> lista = new List<Empleados>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT Id, Apellido, Nombres, DNI, Mail, IdCargo FROM empleados ";
            }
            else
            {
                sql = "SELECT Id, Apellido, Nombres, DNI, Mail, IdCargo FROM empleados WHERE Apellido LIKE '%" + dato + "%' OR DNI LIKE '%" + dato + "%' OR Nombres LIKE '%" + dato + "%'";
            }

            try
            {
                using (var db = new MySqlConnection(_conexion))
                {

                    lista = (List<Empleados>)db.Query<Empleados>(sql);
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
        }

        [HttpDelete]
        [Route("api/Empleado_Eliminar{id}")]
        public string Eliminar(int id)
        {
            string respuesta = "";
            int resul = 0;
            string sql = "DELETE FROM empleados WHERE Id = '" + id + "'";
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
                respuesta = "Se Eliminó con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar Eliminar";
            }

            return respuesta;
        }


        [HttpPut]
        [Route("api/Empleados_Actualizar{datos}")]
        public string Actualizar(Empleados datos)
        {
            string respuesta;
            int resul = 0;
            string sql = "UPDATE empleados SET  Apellido = '" + datos.Apellido + "', Nombres = '" + datos.Nombres + "', DNI = '" + datos.DNI + "', Mail = '" + datos.Mail + "' ,IdCargo = '" + datos.IdCargo + "'  WHERE Id = '" + datos.Id + "'";
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
                respuesta = "Se Actualizo los datos del Empleado";
            }
            else
            {
                respuesta = "ERROR al intentar Actualizar";
            }
            return respuesta;
        }

    [HttpPost]
    [Route("api/Empleados_Insertar{datos}")]
    public string Insertar(Empleados datos)
    {
         string respuesta;
        int resul = 0;
        string sql = "INSERT INTO empleados (Apellido, Nombres, DNI, Mail, IdCargo ) VALUES ('" + datos.Apellido + "',  '" + datos.Nombres + "', '" + datos.DNI + "', '" + datos.Mail + "', '" + datos.IdCargo + "')";
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
            respuesta = "Se Registro el Empleado con Exito";
        }
        else
        {
            respuesta = "ERROR al intentar Guardar";
        }
        return respuesta;
    }

        [HttpGet]
        [Route("api/Empleado_MostrarCargos")]
        public List<CargosUsuarios> MostrarCargos()
        {
            List<CargosUsuarios> lista = new List<CargosUsuarios>();
            string sql = "SELECT IdCargos, Cargos FROM cargosusuarios ORDER BY Cargos ASC";
            try
            {
                using (var db = new MySqlConnection(_conexion))
                {
                    lista = (List<CargosUsuarios>)db.Query<CargosUsuarios>(sql);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return lista;
        }
    }
}

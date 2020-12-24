
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebCalidad.Conexion;
using WebCalidad.Modelo;

namespace WebCalidad.Controllers
{
    public class EmpleadosController : ApiController
    {
        ConectaBD conexion;
        [HttpPost]
        public List<object> Consulta(string dato)
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT Id, Apellido, Nombres, DNI, Mail, Estado, Cargo FROM empleados ORDER BY Apellido ASC ";
            }
            else
            {
                sql = "SELECT Id, Apellido, Nombres, DNI, Mail, Estado, Cargo FROM empleados WHERE Apellido LIKE '%" + dato + "%' OR DNI LIKE '%" + dato + "%' OR Nombres LIKE '%" + dato + "%' OR Cargo LIKE '%" + dato + "%' OR Estado LIKE '%" + dato + "%' ORDER BY Apellido ASC ";
            }

            try
            {
                conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Empleados _empleados = new Empleados();

                    _empleados.Id = int.Parse(reader.GetString(0));
                    _empleados.Apellido = reader.GetString("Apellido");
                    _empleados.Nombres = reader[2].ToString();
                    _empleados.Dni = int.Parse(reader.GetString(3));
                    _empleados.Mail = reader[4].ToString();
                    _empleados.Estado = reader[5].ToString();
                    _empleados.Cargo = reader[6].ToString();

                    lista.Add(_empleados);

                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
        }


        public string Eliminar(int id, bool respEliminar)
        {
            string respuesta = "";
            bool bandera = false;
            conexion = new ConectaBD();
            int iduser = Sesion.IdTipoUsuario2;
            if (iduser == 1 || iduser == 2)
            {
               
                if (respEliminar)
                {
                    string sql = "DELETE FROM empleados WHERE Id = '" + id + "'";
                    bandera = conexion.Conecta(sql);
                }
                if (bandera)
                {
                    respuesta = "Empleado Eliminado con Exito";
                }
            }
            else
            {
                respuesta = "Solicite ELIMINAR a su Superior Directo";
            }

            return respuesta;
        }

        public string Actualizar(Empleados datos)
        {
            bool bandera = false;
            string respuesta;
            conexion = new ConectaBD();
            string sql = "UPDATE empleados SET  Apellido = '" + datos.Apellido + "', Nombres = '" + datos.Nombres + "', Dni = '" + datos.Dni + "', Mail = '" + datos.Mail + "', Estado = '" + datos.Estado + "' ,Cargo = '" + datos.Cargo + "'  WHERE Id = '" + datos.Id + "'";
            bandera = conexion.Conecta(sql);
            if (bandera)
            {
                respuesta = "Se Actualizó con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar actualizar";
            }
            return respuesta;
        }

        public string Insertar(Empleados datos)
        {
            string respuesta;
            conexion = new ConectaBD();
            bool bandera = false;
            string sql = "INSERT INTO empleados (Apellido, Nombres, DNI, Mail, Estado, Cargo ) VALUES ('" + datos.Apellido + "',  '" + datos.Nombres + "', '" + datos.Dni + "', '" + datos.Mail + "', '" + datos.Estado + "', '" + datos.Cargo + "')";
            bandera = conexion.Conecta(sql);
            if (bandera)
            {
                respuesta = "Se Guardo el Empleado con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar Guardar el Registro";
            }
            return respuesta;
        }

        public DataTable MostrarCargos()
        {
            ConectaBD conexion = new ConectaBD();
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();
            DataTable dt = new DataTable();
            try
            {

                string sql = "SELECT IdCargos, Cargos FROM cargosusuarios ORDER BY Cargos ASC";
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataReader reader;
                reader = comando.ExecuteReader();

                dt.Columns.Add("IdCargos", typeof(int));
                dt.Columns.Add("Cargos", typeof(string));
                dt.Load(reader);

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());

            }
            conexionBD.Close();
            return dt;
        }




        public List<object> Disponibilidad(string cargo, string estado)
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;
            sql = "SELECT Id, Apellido, Nombres, Dni, Mail, Estado, Cargo FROM empleados WHERE Cargo LIKE '%" + cargo + "%' AND Estado = '" + estado + "' ORDER BY Apellido ASC ";


            try
            {
                conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Empleados _empleados = new Empleados();

                    _empleados.Id = int.Parse(reader.GetString(0));
                    _empleados.Apellido = reader.GetString("Apellido");
                    _empleados.Nombres = reader[2].ToString();
                    _empleados.Dni = int.Parse(reader.GetString(3));
                    _empleados.Mail = reader[4].ToString();
                    _empleados.Estado = reader[5].ToString();
                    _empleados.Cargo = reader[6].ToString();

                    lista.Add(_empleados);

                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
        }

        public int AsignarSupervisor(string cargo, string estado)
        {

            List<Empleados> listaorde = new List<Empleados>();
            Empleados _empleados = new Empleados();
            int DniSupervisor = 0;

            MySqlDataReader reader;

            string sql;
            sql = "SELECT Id, Apellido, Nombres, Dni, Mail, Estado, Cargo FROM empleados WHERE Cargo = '" + cargo + "' AND Estado = '" + estado + "' ORDER BY CodOP ASC ";

            try
            {
                ConectaBD conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    _empleados.Id = int.Parse(reader.GetString(0));
                    _empleados.Apellido = reader.GetString("Apellido");
                    _empleados.Nombres = reader[2].ToString();
                    _empleados.Dni = int.Parse(reader.GetString(3));
                    _empleados.Mail = reader[4].ToString();
                    _empleados.Estado = reader[5].ToString();
                    _empleados.Cargo = reader[6].ToString();

                }
                DniSupervisor = _empleados.Dni;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            return DniSupervisor;
        }
    }
}

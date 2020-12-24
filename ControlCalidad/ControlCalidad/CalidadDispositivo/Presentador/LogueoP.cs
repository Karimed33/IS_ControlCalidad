using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlCalidad.Modelo;
using ControlCalidad.Conexion;
using MySql.Data.MySqlClient;

namespace ControlCalidad.Presentador
{
    class LogueoP
    {
        public string Login(string usuario, string password)
        {
            string repuesta = "";
            Usuarios datoUsurio;

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                repuesta = "Debe llenar todo los campos";
            }
            else
            {
                datoUsurio = VerUsuario(usuario);
                if (datoUsurio == null)
                {
                    repuesta = "El Usuario no Existe";
                }
                else
                {
                    UsuarioP user = new UsuarioP();
                    if (datoUsurio.Password != user.GenerarSHA1(password))
                    {
                        repuesta = "El Usuario y/o Contraseña no Coinciden";

                    }
                    else
                    {
                        Sesion.Id2 = datoUsurio.Id;
                        Sesion.Usuario2 = datoUsurio.Usuario1;
                        Sesion.Dni = datoUsurio.Dni;
                        Sesion.IdTipoUsuario2 = datoUsurio.IdCargo;
                        Sesion.TipoUsuario = datoUsurio.TipoUsuario;
                    }
                }
            }
            return repuesta;
        }


        public Usuarios VerUsuario(string usuario)
        {
            ConectaBD conexion = new ConectaBD();
            MySqlDataReader reader;
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "SELECT Id, Usuario, Contraseña, Dni, TipUsuario, IdCargo FROM usuarios WHERE  Usuario = @Usuario ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            comando.Parameters.AddWithValue("@Usuario", usuario);

            reader = comando.ExecuteReader();

            Usuarios usr = null;
            while (reader.Read())
            {
                usr = new Usuarios
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Usuario1 = reader["Usuario"].ToString(),
                    Password = reader["Contraseña"].ToString(),
                    Dni = int.Parse(reader["Dni"].ToString()),
                    TipoUsuario = reader["TipUsuario"].ToString(),
                    IdCargo = int.Parse(reader["IdCargo"].ToString())
                };

            }
            return usr;
        }
    }
}

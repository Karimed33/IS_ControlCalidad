using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ControlCalidad.Modelo;
using MySql.Data.MySqlClient;
using ControlCalidad.Conexion;

namespace ControlCalidad.Presentador
{
    class UsuarioP
    {
        public string Registro(Usuarios usuarios)
        {
            string repuesta;
            if (string.IsNullOrEmpty(usuarios.Usuario1) || string.IsNullOrEmpty(usuarios.Password) || string.IsNullOrEmpty(usuarios.TipoUsuario) || string.IsNullOrEmpty(usuarios.ConPassword) || string.IsNullOrEmpty(usuarios.Dni.ToString()))
            {
                repuesta = "Debe llenar todos los campos";
            }
            else
            {
                if (usuarios.Password == usuarios.ConPassword)
                {
                    if (ExisteUsuario(usuarios.Usuario1))
                    {
                        repuesta = "El Usuario ya Existe";
                    }
                    else
                    {
                        usuarios.Password = GenerarSHA1(usuarios.Password);
                        Registrar(usuarios);
                        repuesta = "Usuario Registrado con Exito";
                    }
                }
                else
                {
                    repuesta = "Las contraseñas no Coinciden";
                }
            }

            return repuesta;
        }


        public string GenerarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString();
        }

       


        public void CrearUsuario(Usuarios usuario)
        {
            if (usuario.TipoUsuario == "Administrador")
            {
                usuario.IdCargo = 1;
            }
            else
            {
                if (usuario.TipoUsuario == "Supervisor Calidad")
                {
                    usuario.IdCargo = 2;
                }
                else
                {
                    if (usuario.TipoUsuario == "Supervisor Linea")
                    {
                        usuario.IdCargo = 3;
                    }
                    else
                    {
                            usuario.IdCargo = 4;
                    }
                }
            }

        }

        public int Registrar(Usuarios usuario)
        {
            ConectaBD conexion = new ConectaBD();
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "INSERT INTO usuarios (Usuario, Contraseña, Dni, TipUsuario, IdCargo) VALUE (@Usuario, @Contraseña, @Dni, @TipUsuario, @IdCargo)";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            comando.Parameters.AddWithValue("@Usuario", usuario.Usuario1);
            comando.Parameters.AddWithValue("@Contraseña", usuario.Password);
            comando.Parameters.AddWithValue("@Dni", usuario.Dni);
            comando.Parameters.AddWithValue("@TipUsuario", usuario.TipoUsuario);
            comando.Parameters.AddWithValue("@IdCargo", usuario.IdCargo);

            int resultado = comando.ExecuteNonQuery();

            return resultado;


        }

        public bool ExisteUsuario(string usuario)
        {
            ConectaBD conexion = new ConectaBD();
            MySqlDataReader reader;
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "SELECT Id FROM usuarios WHERE  Usuario = @Usuario ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            comando.Parameters.AddWithValue("@Usuario", usuario);

            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

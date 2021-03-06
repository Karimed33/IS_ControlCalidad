﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCalidad.Conexion
{
    class ConectaBD
    {
        public MySqlConnection Conectar()
        {
            string servidor = "localhost";
            string bd = "calidadis";
            string usuario = "root";
            string password = "karimed3344";

            string cadenaConexion = "DataBase=" + bd + "; Data Source=" + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            try
            {
                MySqlConnection ConexionBD = new MySqlConnection(cadenaConexion);

                return ConexionBD;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error:" + e.Message);
                return null;
            }
        }


        public bool Conecta(string sql)
        {
            bool bandera = false;
            try
            {
                MySqlConnection conexionBD = Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                conexionBD.Close();
                bandera = true;
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
                bandera = false;
            }
            return bandera;
        }
    }
}

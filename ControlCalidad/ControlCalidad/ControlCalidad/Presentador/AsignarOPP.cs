using ControlCalidad.Conexion;
using ControlCalidadDominio.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Presentador
{
    class AsignarOPP
    {
        public AsignarOPCalidad VerOP(int DNI)
        {
            AsignarOPCalidad _op = null;
            MySqlDataReader reader;
            ConectaBD conexion = new ConectaBD();
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();
            string estado = "Finalizado";

            string sql = " SELECT Id, NumeroOP, Dni, Estado, Hora, Fecha  FROM Asigancioninspeccion WHERE Dni='" + DNI + "' AND Estado != '"+estado+"' ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            reader = comando.ExecuteReader();

            while (reader.Read())
            {
                _op = new AsignarOPCalidad
                {
                    Id = int.Parse(reader.GetString(0)),
                    numeroOP = int.Parse(reader.GetString(1)),
                    DNI = int.Parse(reader.GetString(2)),
                    Estado = reader[3].ToString(),
                    Hora = reader[4].ToString(),
                    Fecha = reader[5].ToString()
                };


            }
            return _op;
        }
    }
}

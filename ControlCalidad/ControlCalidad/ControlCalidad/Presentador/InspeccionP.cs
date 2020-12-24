using ControlCalidadDominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlCalidad.Conexion;
using MySql.Data.MySqlClient;

namespace ControlCalidad.Presentador
{
    public class InspeccionP
    {
        ConectaBD conexion;
        public bool Insertar(Inspecciones insp)
        {
            conexion = new ConectaBD();
            string sql = " INSERT INTO inspeccion (IdDefecto, Cantidad, Hora, Pie, CodOP, Fecha)  VALUES ('" + insp.IdDefecto + "', '" +insp.Cantidad+"', '" + insp.Hora + "', '" + insp.Pie + "', '" + insp.CodOP + "', '" + insp.Fecha + "') ";
            return conexion.Conecta(sql);
        }

        public bool InsertarPrimeraCalidad(PrimeraCalidad insp)
        {
            conexion = new ConectaBD();
            string sql = " INSERT INTO producciones (CodOP, Hora, Cantidad, Fecha)  VALUES ('" + insp.CodOP + "', '" + insp.Hora + "', '" + insp.Cantidad + "', '" + insp.Fecha + "') ";
            return conexion.Conecta(sql);
        }

        public int Acumular(int CodOP, int IdDefecto, string Pie, int Hora)
        {
            MySqlDataReader reader;
            int acumulador = 0;
            Inspecciones _op = new Inspecciones();
            string sql = "SELECT Id, IdDefecto, Cantidad, Hora, Pie, CodOP, Fecha FROM inspeccion WHERE CodOP ='" + CodOP + "' AND IdDefecto = '" + IdDefecto + "' AND pie = '" + Pie + "' AND Hora = '"+Hora+"' ORDER BY CodOP DESC ";
            //string _hora, _horaInsp;
            try
            {
                ConectaBD conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {

                    _op.Id = int.Parse(reader.GetString(0));
                    _op.IdDefecto = int.Parse(reader.GetString(1));
                    _op.Cantidad = int.Parse(reader.GetString(2));
                    _op.Hora = reader[3].ToString();
                    _op.Pie = reader[4].ToString();
                    _op.CodOP = int.Parse(reader.GetString(2));
                    _op.Fecha = reader[6].ToString();


                    //_horaInsp = insp.Hora.Substring(0, 2);
                    //_hora = _op.Hora.Substring(0, 2);
                   // if (_hora == _horaInsp)
                    {
                        acumulador += _op.Cantidad;
                    }
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return acumulador;
        }

        public int AcumularPrimeraCalidad(PrimeraCalidad insp)
        {
            MySqlDataReader reader;
            int acumulador = 0;
            string sql;
            sql = "SELECT Id, CodOP, Hora, Cantidad, Fecha FROM producciones ORDER BY CodOP DESC ";
            string _hora, _horaInsp;
            try
            {
                ConectaBD conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    PrimeraCalidad _op = new PrimeraCalidad
                    {
                        Id = int.Parse(reader.GetString(0)),
                        CodOP = int.Parse(reader.GetString(1)),
                        Hora = reader[2].ToString(),
                        Cantidad = int.Parse(reader.GetString(3)),
                        Fecha = reader[4].ToString()
                    };

                    _horaInsp = insp.Hora.Substring(0, 2);
                    _hora = _op.Hora.Substring(0, 2);
                    if (_hora == _horaInsp)
                    {
                        acumulador += _op.Cantidad;
                    }
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return acumulador;
        }


        public Turno ConsultaHoras(string denominacion)
        {
            Turno _turno = new Turno();
            MySqlDataReader reader;
            string sql;
            sql = "SELECT idTurnos, Denominacion, HoraInicio, HoraFin FROM turnos WHERE Denominacion = '"+denominacion+"' ORDER BY Denominacion DESC ";

            try
            {
                ConectaBD conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    _turno.Id = int.Parse(reader.GetString(0));
                    _turno.Denominacion = reader[1].ToString();
                    _turno.HoraInicio = reader[2].ToString();
                    _turno.HoraFin = reader[3].ToString();
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return _turno;
        }



        public List<Defectos> ConsultaDefectos(string dato)
        {
            MySqlDataReader reader;
            List<Defectos> lista = new List<Defectos>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT Id, Defecto, TipoDefecto FROM defectos ORDER BY Defecto DESC ";
            }
            else
            {
                sql = "SELECT Id, Defecto, TipoDefecto FROM defectos WHERE TipoDefecto = '" + dato + "' ORDER BY Defecto DESC ";
            }
            try
            {
                ConectaBD conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Defectos _op = new Defectos
                    {
                        Id = int.Parse(reader.GetString(0)),
                        Defecto = reader[1].ToString(),
                        TipoDefecto = reader[2].ToString()
                      
                    };
                    lista.Add(_op);

                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
        }

        

        public Turno DevolverTurno(string denominacion)
        {
            MySqlDataReader reader;
            string sql;
            sql = "SELECT idTurnos, Denominacion, HoraInicio, HoraFin FROM turnos  WHERE Denominacion = '"+denominacion+"' ORDER BY Denominacion DESC ";
            Turno _turno = new Turno();
            try
            {
                ConectaBD conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    _turno.Id = int.Parse(reader.GetString(0));
                    _turno.Denominacion = reader[1].ToString();
                    _turno.HoraInicio = reader[2].ToString();
                    _turno.HoraFin = reader[3].ToString();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return _turno;
        }


        public string BuscarTurno(string hora)
        {
            string denominacion ="";
            MySqlDataReader reader;
            string sql;
            sql = "SELECT idTurnos, Denominacion, HoraInicio, HoraFin FROM turnos  ORDER BY Denominacion DESC ";

            try
            {
                ConectaBD conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Turno _turno = new Turno
                    {
                        Id = int.Parse(reader.GetString(0)),
                        Denominacion = reader[1].ToString(),
                        HoraInicio = reader[2].ToString(),
                        HoraFin = reader[3].ToString()

                    };
                    int horaI = int.Parse(_turno.HoraInicio.Substring(0,2));
                    int horaF = int.Parse(_turno.HoraFin.Substring(0,2));
                    int _hora = int.Parse(hora.Substring(0, 2));
                    if (horaI > horaF)
                    {
                        for (var i = horaI; i <24; i++)
                        {
                            if (i == _hora)
                            {
                                denominacion = _turno.Denominacion;
                            }
                        }
                        for (var i = 0; i < horaF; i++)
                        {
                            if (i == _hora)
                            {
                                denominacion = _turno.Denominacion;
                            }
                        }

                    }
                    else
                    {
                        if (_hora >= horaI && _hora <= horaF)
                        {
                            for (var i = horaI; i < horaF; i++)
                            {
                                if (i == _hora)
                                {
                                    denominacion = _turno.Denominacion;
                                }
                            }
                        }
                    }

                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return denominacion;

        }

        public List<Defectos> ListarDefectos(int codOP)
        {
            MySqlDataReader reader;
            var listaDefecto = ConsultaDefectos(null);
            var sql = "INNER JOIN defectos ON defectos.Id = inspeccion.IdDefectos WHERE inspeccion.CodOP = '"+codOP+"'";
            try
            {
                ConectaBD conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Defectos _op = new Defectos
                    {
                        Id = int.Parse(reader.GetString(0)),
                        Defecto = reader[1].ToString(),
                        TipoDefecto = reader[2].ToString()

                    };
                    listaDefecto.Add(_op);

                }
            }

            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return listaDefecto;
        }


        public List<int> CargarHorasTurnos(string hora, string turno)
        {
            Turno turnos;
            InspeccionP pres = new InspeccionP();
            turnos = pres.DevolverTurno(turno);
            int inicio = int.Parse(turnos.HoraInicio.Substring(0, 2));
            int fin = int.Parse(turnos.HoraFin.Substring(0, 2));
            List<int> horas = new List<int>();
            int horaInicioOP = int.Parse(hora.Substring(0, 2));
     
            if (fin < inicio)
            {
                for (var i = horaInicioOP; i < 24; i++)
                {
                    horas.Add(i);
                }
                for (var i = -1; i <= fin; i++)
                {
                    horas.Add(i);
                }
            }
            else
            {
                for (var i = horaInicioOP; i <= fin; i++)
                {
                    horas.Add(i);
                }
            }
            return horas;
        }

    }
}

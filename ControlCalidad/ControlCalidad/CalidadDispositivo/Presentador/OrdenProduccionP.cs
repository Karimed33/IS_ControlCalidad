using ControlCalidad.Conexion;
using ControlCalidad.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ControlCalidad.Presentador
{
    class OrdenProduccionP
    {
        public List<object> Consulta(string dato)
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;
            if (dato == null)
            {
                sql = "SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color FROM ordenproduccion ORDER BY CodOP DES ";
            }
            else
            {
                sql = "SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color FROM ordenproduccion WHERE CodOP LIKE '%" + dato + "%' OR Detalle LIKE '%" + dato + "%' ORDER BY CodOP DES ";
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
                    OrdenProduccion _op = new OrdenProduccion();
                    _op.Id = int.Parse(reader.GetString(0));
                    _op.CodOP = int.Parse(reader.GetString(1));
                    _op.Detalle = reader[2].ToString();
                    _op.EstadoOP = reader[3].ToString();
                    _op.Modelo = reader[4].ToString();
                    _op.Color = reader[5].ToString();
                    lista.Add(_op);

                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
        }


        public string Validar(OrdenProduccion op)
        {
            string repuesta;
            if ( string.IsNullOrEmpty(op.Detalle))
            {
                repuesta = "Debe llenar todos los campos";
            }
            else
            {
                if (ExisteCodigo(op.CodOP))
                {
                    repuesta = "El Codigo ingresado ya Existe";
                }
                else
                {
                    Insertar(op);
                    repuesta = "Usuario Registrado con Exito";
                }
            }

            return repuesta;
        }

        public string Insertar(OrdenProduccion op)
        {
            string respuesta, resplinea = "";
            string estado = "Ocupado";
            ConectaBD conexion = new ConectaBD();
            bool bandera = false;
            string sql = "INSERT INTO ordenproduccion (CodOP, Detalle, EstadoOP, Color, Modelo, Objetivo, Linea) VALUES ('" + op.CodOP + "',  '" + op.Detalle + "', '"+op.EstadoOP+"', '"+op.Modelo+"', '"+op.Color+ "', '" + op.Objetivo + "', '" + op.Linea + "')";
            bandera = conexion.Conecta(sql);
            if (bandera)
            {
                respuesta = "Se Guardo la OP con Exito";
                resplinea=ActualizarEstadosLinea(op.CodOP, estado);
            }
            else
            {
                respuesta = "ERROR al intentar Guardar el Registro";
            }
            return respuesta + resplinea;
        }


        public bool ExisteCodigo(int op)
        {
            ConectaBD conexion = new ConectaBD();
            MySqlDataReader reader;
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = "SELECT Id FROM ordenproduccion WHERE  CodOP = @CodOP ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            comando.Parameters.AddWithValue("@CodOP", op);

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

        public string Actualizar(OrdenProduccion datos)
        {
            bool bandera = false;
            string respuesta;
            ConectaBD conexion = new ConectaBD();
            string sql = "UPDATE ordenproduccion SET  CodOP = '" + datos.CodOP + "', Detalle = '" + datos.Detalle + "', EstadoOP = '" + datos.EstadoOP+ "', Modelo = '" + datos.Modelo + "', Color = '" + datos.Color + "', Objetivo = '" + datos.Objetivo + "', DNI = '" + datos.DNI + "', Linea = '" + datos.Linea + "'  WHERE Id = '" + datos.Id + "'";
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

        public string Eliminar(int id)
        {
            string respuesta = "";
            bool bandera = false;
            ConectaBD conexion = new ConectaBD();
            int iduser = Sesion.IdTipoUsuario2;
            if (iduser == 1)
            {
                DialogResult resultado = MessageBox.Show("Seguro que desea Eliminar el Modelo?", "Salir", MessageBoxButtons.YesNoCancel);
                if (resultado == DialogResult.Yes)
                {
                    string sql = "DELETE FROM ordenproduccion WHERE Id = '" + id + "'";
                    bandera = conexion.Conecta(sql);
                }
                if (bandera)
                {
                    respuesta = "Orden de Producción Eliminada con Exito";
                }
            }
            else
            {
                respuesta = "Solicite ELIMINAR a su Superior Directo";
            }

            return respuesta;
        }


       

        public DataTable MostrarModelos()
        {
            ConectaBD conexion = new ConectaBD();
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();
            DataTable dt = new DataTable();
            try
            {

                string sql = "SELECT Id, CodModelo, Denominacion FROM modelos ORDER BY CodModelo ASC";
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataReader reader;
                reader = comando.ExecuteReader();

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("CodModelo", typeof(string));
                dt.Columns.Add("Denominacion", typeof(string));
                dt.Columns.Add("Objetivo", typeof(int));
                dt.Load(reader);

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());

            }
            conexionBD.Close();
            return dt;
        }

        public DataTable MostrarColores()
        {
            ConectaBD conexion = new ConectaBD();
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();
            DataTable dt = new DataTable();
            try
            {

                string sql = "SELECT Id, CodigoColor, Descripcion FROM colores ORDER BY CodigoColor ASC";
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                MySqlDataReader reader;
                reader = comando.ExecuteReader();

                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("CodigoColor", typeof(string));
                dt.Columns.Add("Descripcion", typeof(string));
                dt.Load(reader);

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());

            }
            conexionBD.Close();
            return dt;
        }

        public List<object> TablaOP(string estadoAsig )
        {
            MySqlDataReader reader;
            List<object> lista = new List<object>();
            string sql;
            sql = "SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color, Objetivo, DNI, Linea FROM ordenproduccion WHERE UPPER (Asignada) = '" + estadoAsig + "'  ORDER BY CodOP DES ";

            try
            {
                ConectaBD conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    OrdenProduccion _op = new OrdenProduccion();
                    _op.Id = int.Parse(reader.GetString(0));
                    _op.CodOP = int.Parse(reader.GetString(1));
                    _op.Detalle = reader[2].ToString();
                    _op.EstadoOP = reader[3].ToString();
                    _op.Modelo = reader[4].ToString();
                    _op.Color = reader[5].ToString();
                    _op.Objetivo = int.Parse(reader.GetString(6));
                    _op.DNI = int.Parse(reader.GetString(7));
                    _op.Linea = int.Parse(reader.GetString(8));
                    lista.Add(_op);

                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return lista;
        }


        public void ValidarDato(string dato)
        {
            if (string.IsNullOrEmpty(dato))
            {
                MessageBox.Show("Debe Ingresar un Código de Orden de Producción");
            }
        }

        public string ValidaOP(string dato)
        {

            string repuesta = "";
            OrdenProduccion datoOP = null;


            datoOP = VerOP(dato);

            if (datoOP == null)
            {
                repuesta = "El Número de Orden de Producción No Existe";
            }

            return repuesta;
        }

        public OrdenProduccion VerOP(string CodOp)
        {
            OrdenProduccion _op = null;
            MySqlDataReader reader;
            ConectaBD conexion = new ConectaBD();
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = " SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color, Objetivo, DNI, Linea  FROM ordenproduccion WHERE CodOP='" + CodOp + "' ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            reader = comando.ExecuteReader();

            while (reader.Read())
            {
                _op = new OrdenProduccion();
                _op.Id = int.Parse(reader.GetString(0));
                _op.CodOP = int.Parse(reader.GetString(1));
                _op.Detalle = reader[2].ToString();
                _op.EstadoOP = reader[3].ToString();
                _op.Modelo = reader[4].ToString();
                _op.Color = reader[5].ToString();
                _op.Objetivo = int.Parse(reader.GetString(6));
                _op.DNI = int.Parse(reader.GetString(7));
                _op.Linea = int.Parse(reader.GetString(8));


            }
            return _op;
        }

        public bool InsertarAsignacionIsnpeccion(AdministrarInspeccion op)
        {
            bool respuesta = false;
            ConectaBD conexion = new ConectaBD();
            bool bandera = false;
            string sql = "INSERT INTO asignacioninspeccion (CodOP, DniSupCalidad, EstadoInspeccion, Linea) VALUES ('" + op.NumOP + "', '" + op.DniSupCalidad + "', '" + op.EstadoInspeccion + "', '" + op.Linea + "')";
            bandera = conexion.Conecta(sql);
            if (bandera)
            {
                respuesta = true;
               
            }
            else
            {
                respuesta = false;
            }
            return respuesta;
        }

        public string ActualizarEstadosOP(int codOP, string estado)
        {
            bool bandera = false;
            string respuesta;
            ConectaBD conexion = new ConectaBD();
            string sql = "UPDATE ordenproduccion SET  EstadoOP = '" + estado + "'  WHERE CodOP = '" + codOP + "'";
            bandera = conexion.Conecta(sql);
            if (bandera)
            {
                respuesta = "Se Actualizó el Estado con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar actualizar";
            }
            return respuesta;
        }


        public string  ActualizarEstadosLinea(int linea, string estado)
        {
            bool bandera = false;
            string respuesta;
            ConectaBD conexion = new ConectaBD();
            string sql = "UPDATE lineatrabajo SET  Estado = '" + estado + "'  WHERE Numero = '" + linea + "'";
            bandera = conexion.Conecta(sql);
            if (bandera)
            {
                respuesta = "Se Actualizó el Estado de la Linea con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar actualizar";
            }
            return respuesta;
        }


        public string ActualizarEstadosInspeccion(int numeroOP, string estado)
        {
            bool bandera = false;
            string respuesta;
            ConectaBD conexion = new ConectaBD();
            string sql = "UPDATE asignacioninspeccion SET  EstadoInspeccion = '" + estado + "'  WHERE CodOP = '" + numeroOP + "'";
            bandera = conexion.Conecta(sql);
            if (bandera)
            {
                respuesta = "Se Actualizó el Estado de la Inspección con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar actualizar";
            }
            return respuesta;
        }


        public bool BuscarEstadoLinea(int linea)
        {
            LineaTrabajo _linea = new LineaTrabajo();
            MySqlDataReader reader;
            bool bandera = false;
            string sql;
            sql = "SELECT Id, Numero, Estado FROM lineatrabajo WHERE Numero= @Numero";

            try
            {
                ConectaBD conexion = new ConectaBD();
                MySqlConnection conexionBD = conexion.Conectar();
                conexionBD.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.Parameters.AddWithValue("@Numero", linea);

                reader = comando.ExecuteReader();
                while (reader.Read())
                {

                    _linea.Id = int.Parse(reader.GetString(0));
                    _linea.Numero = int.Parse(reader.GetString(1));
                    _linea.Estado = reader[2].ToString();

                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            if (_linea.Estado == "Disponible")
            { 
                bandera = true;
            }
            return bandera;

        }

        public OrdenProduccion TraerDatos(int dni)
        {
            string estado = "Finalizada";
            OrdenProduccion _op = null;
            MySqlDataReader reader;
            ConectaBD conexion = new ConectaBD();
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = " SELECT Id, CodOP, Detalle, EstadoOP, Modelo, Color, Objetivo, DNI, Linea  FROM ordenproduccion WHERE DNI='" + dni + "' AND UPPER (EstadoOP) <>'" + estado+"' ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            reader = comando.ExecuteReader();

            while (reader.Read())
            {
                _op = new OrdenProduccion();
                _op.Id = int.Parse(reader.GetString(0));
                _op.CodOP = int.Parse(reader.GetString(1));
                _op.Detalle = reader[2].ToString();
                _op.EstadoOP = reader[3].ToString();
                _op.Modelo = reader[4].ToString();
                _op.Color = reader[5].ToString();
                _op.Objetivo = int.Parse(reader.GetString(6));
                _op.DNI = int.Parse(reader.GetString(7));
                _op.Linea = int.Parse(reader.GetString(8));


            }
            return _op;
        }

        public AdministrarInspeccion TraerDatosInspeccion(int dni)
        {
            string estado = "Finalizada";
            AdministrarInspeccion _ai = null;
            MySqlDataReader reader;
            ConectaBD conexion = new ConectaBD();
            MySqlConnection conexionBD = conexion.Conectar();
            conexionBD.Open();

            string sql = " SELECT Id, CodOP, DniSupCalidad, EstadoInspeccion, Linea  FROM ordenproduccion WHERE DNI='" + dni + "' AND UPPER(EstadoInspeccion) <> '" + estado + "' ";

            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
            reader = comando.ExecuteReader();

            while (reader.Read())
            {
                _ai = new AdministrarInspeccion();
                _ai.Id = int.Parse(reader.GetString(0));
                _ai.NumOP = int.Parse(reader.GetString(1));
                _ai.DniSupCalidad = int.Parse(reader.GetString(2));
                _ai.EstadoInspeccion = reader[3].ToString();
                _ai.Linea= int.Parse(reader.GetString(4));

            }
            return _ai;
        }

        public string AdministrarEstadosUsuarios(int dni, string estado)
        {
            bool bandera = false;
            string respuesta;
            ConectaBD conexion = new ConectaBD();
            string sql = "UPDATE empleados SET  Estado = '" + estado + "'  WHERE Numero = '" + dni + "'";
            bandera = conexion.Conecta(sql);
            if (bandera)
            {
                respuesta = "Se Actualizó el Estado del Empleado con Exito";
            }
            else
            {
                respuesta = "ERROR al intentar actualizar";
            }
            return respuesta;
        }
    }
}


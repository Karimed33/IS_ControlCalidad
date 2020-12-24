using ControlCalidadDominio.Modelo;
using ControlCalidad.Presentador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlCalidad.Interfaz;
using ControlCalidadSistemaExterno;
using ControlCalidadSistemaExterno.Adaptador;

namespace ControlCalidad.Vistas
{
    public partial class AdministrarOP : Form
    {
        readonly DateTime hoy = DateTime.Now;
        public AdministrarOP()
        {
            InitializeComponent();
            Ocultar();
            txtUsuario.Text = Sesion.Dni.ToString();
            cbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbModelo.DropDownStyle = ComboBoxStyle.DropDownList;
            ValidarUsuario();
            dGVLineas.Visible = false;
           
        }

       
        public void CargarLineas()
        {
            AdapterOP presentador = new AdapterOP();

            List<LineaTrabajo> listaLinea;
            List<LineaTrabajo> listaLineaDisponible;
            listaLinea = presentador.ConsultarLineasCreadas();
            List<OrdenProduccion> listaOP;
            listaOP = presentador.ConsultaOPActivas();
            listaLineaDisponible = listaLinea.ToList();

            try
            {
                foreach (var a in listaLinea)
                {
                    foreach (var b in listaOP)
                    {

                        if (a.Numero == b.Linea)
                        {
                            listaLineaDisponible.Remove(a);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            
            dGVLineas.DataSource = listaLineaDisponible;
        }
        public void ValidarUsuario()
        {
            int dni = Sesion.Dni;
            string estado = "Finalizado";
            string respuesta;
            AdapterOP pres = new AdapterOP();
            respuesta = pres.ValidaEmpleado(estado, Sesion.Dni);
            if(respuesta!=null)
            {
                MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLineas.Enabled = false;
            }

        }
        private void Ocultar()
        {
            txtNumeroOP.Visible = false;
            pbCancelar.Visible = false;
            lbCancelar.Visible = false;
            txtObjetivo.Visible = false;
            lbOjetivo.Visible = false;
            txtLineaTrabajo.Visible = false;
            lbLineaTrabajo.Visible = false;
            txtDetalle.Visible = false;
            lbDetalle.Visible = false;
            cbColor.Visible = false;
            cbModelo.Visible = false;
            lbModelo.Visible = false;
            lbColor.Visible = false;
            pbAgregar.Visible = false;
            lbAgregar.Visible = false;
            lbEstado.Visible = false;
            lbNumeroOP.Visible = false;
            txtEstadoOP.Visible = false;
        }

   

        private void MostrarDown()
        {
            txtNumeroOP.Visible = true;
            lbNumeroOP.Visible = true;
            txtObjetivo.Visible = true;
            lbOjetivo.Visible = true;
            txtLineaTrabajo.Visible = true;
            lbLineaTrabajo.Visible = true;
            txtDetalle.Visible = true;
            lbDetalle.Visible = true;
            cbColor.Visible = true;
            cbModelo.Visible = true;
            lbModelo.Visible = true;
            lbColor.Visible = true;
            txtEstadoOP.Visible = true;
            lbEstado.Visible = true;
        }

        private void Limpiar()
        {
            txtNumeroOP.Text = "";
            txtObjetivo.Text = "";
            txtLineaTrabajo.Text = "";
            txtDetalle.Text = "";
            cbColor.Text = "";
            cbModelo.Text = "";
        }


        public void ComboModelos()
        {
            AdapterOP pres = new AdapterOP();
            cbModelo.DataSource = null;
            cbModelo.Items.Clear();
            List<Modelos> dt = new List<Modelos>();
            dt = pres.ComboModelo();
            cbModelo.ValueMember = "Id";
            cbModelo.DisplayMember = "Denominacion";
            cbModelo.DataSource = dt;
        }
        public  void ComboColores()
        {
            AdapterOP pres = new AdapterOP();
            cbColor.DataSource = null;
            cbColor.Items.Clear();
            List<Colores> dt = new List<Colores>();
            dt = pres.MostrarColores();
            cbColor.ValueMember = "Id";
            cbColor.DisplayMember = "Descripcion";
            cbColor.DataSource = dt;
        }

       
        /*private void AsignarOP_Load(object sender, EventArgs e)
        {

            Timer t1 = new Timer();
            t1.Interval = 5000;
            t1.Tick += Timer1_Tick;
            t1.Start();

        }*/

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        

        private void pbAsignar_Click(object sender, EventArgs e)
        {
            Ocultar();
            Limpiar();
        }


        
        private void cbModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string codMod, dato = cbModelo.Text;
            AdapterModels presentador = new AdapterModels();
            codMod = presentador.CodigoModelo(dato);
            txtObjetivo.Text = presentador.CargarObjetivo(codMod).ToString();
        }

       

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            Agregar(); 
            Ocultar();
            Limpiar();


        }

        public void Agregar()
        {
            string respuesta;
            OrdenProduccion _op = new OrdenProduccion();
            _op.CodOP = int.Parse(txtNumeroOP.Text);
            _op.Detalle = txtDetalle.Text;
            _op.EstadoOP = txtEstadoOP.Text;
            _op.Color = cbColor.Text;
            _op.Modelo = cbModelo.Text;
            _op.Objetivo = int.Parse(txtObjetivo.Text);
            _op.DNI = Sesion.Dni;
            _op.Linea = int.Parse(txtLineaTrabajo.Text);
            _op.FechaInicio = hoy.ToShortDateString();
            _op.HoraInicio= hoy.ToShortTimeString();
            AdapterOP presentador = new AdapterOP();
            respuesta = presentador.AgregarOP(_op);
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       

        private void pbModificar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            dGVLineas.Visible = true;
            CargarLineas();
        }

        private void dGVLineas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MostrarDown();
            txtLineaTrabajo.Text = this.dGVLineas.CurrentRow.Cells[1].Value.ToString();
            btnLineas.Enabled = true;
            dGVLineas.Visible = false;
            pbAgregar.Visible = true;
            lbAgregar.Visible = true;
            pbCancelar.Visible = true;
            lbCancelar.Visible = true;
            ComboModelos();
            ComboColores();
        }
    }
}

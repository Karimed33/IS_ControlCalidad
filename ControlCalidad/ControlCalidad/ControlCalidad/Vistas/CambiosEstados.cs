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
using ControlCalidadSistemaExterno.Adaptador;

namespace ControlCalidad.Vistas
{
    public partial class CambiosEstados : Form
    {
        readonly DateTime hoy = DateTime.Now;
        readonly string Usuario = Sesion.TipoUsuario;
        public CambiosEstados()
        {
            InitializeComponent();
            ValidarUsuario();
            txtUsuario.Text = Sesion.Usuario2;
        }

        public void ValidarUsuario()
        {
            AdapterOP pres = new AdapterOP();
            int DNI = Sesion.Dni;
            OrdenProduccion op;
            AdministrarInspeccion ai;
            if (Usuario == "Supervisor Linea" || Usuario == "Supervisor Linea")
            {
                if (Usuario == "Supervisor Linea")
                {
                    op = pres.TraerDatosSupLinea(DNI);
                    if (op == null)
                    {
                        MessageBox.Show("No tiene ninguna Orden de Producción Asignada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pbIniciar.Enabled = false;
                        pbPausar.Enabled = false;
                        pbFinalizar.Enabled = false;
                    }
                    else
                    {
                        txtOP.Text = op.CodOP.ToString();
                        txtEstado.Text = op.EstadoOP;
                    }
                }
                else
                {
                    if (Usuario == "Supervisor Calidad")
                    {
                        ai = pres.TraerSupCalidad(DNI);
                        if (ai == null)
                        {
                            MessageBox.Show("No tiene ninguna Orden de Producción Asignada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            pbIniciar.Enabled = false;
                            pbPausar.Enabled = false;
                            pbFinalizar.Enabled = false;
                        }
                        else
                        {
                            txtOP.Text = ai.NumeroOP.ToString();
                            txtEstado.Text = ai.Estado;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Usuario sin poder producir cambios", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pbIniciar.Enabled = false;
                pbPausar.Enabled = false;
                pbFinalizar.Enabled = false;
            }

        }

        private void pbIniciar_Click(object sender, EventArgs e)
        {
            string fecha = hoy.ToShortDateString();
            string estado = "En Proceso";
            int numeroOP = int.Parse(txtOP.Text);
            ActualizarEstados(estado, numeroOP, fecha);
        }

        public void ActualizarEstados(string estado, int numOP, string fecha)
        {

            string respuesta = "";
            AdapterOP pres = new AdapterOP();
            if (Usuario == "Supervisor Linea")
            {
                respuesta = pres.ActualizarEstadosOP(estado,numOP, fecha);

            }
            else
            {
                if (Usuario == "Supervisor Calidad")
                {
                    respuesta = pres.ActualizarEstadosInspeccion(numOP, estado);
                }
            }
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
       
        private void pbPausar_Click(object sender, EventArgs e)
        {
            string fecha = hoy.ToShortDateString();
            string estado = "Pausado";
            int numeroOP = int.Parse(txtOP.Text);
            ActualizarEstados(estado, numeroOP, fecha);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void pbFinalizar_Click(object sender, EventArgs e)
        {
            string fecha = hoy.ToShortDateString();
            string estado = "Finalizado";
            int numeroOP = int.Parse(txtOP.Text);
            ActualizarEstados(estado, numeroOP, fecha);


        }

    }
}

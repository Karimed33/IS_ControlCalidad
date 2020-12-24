using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlCalidad.Modelo;
using ControlCalidad.Presentador;

namespace ControlCalidad.Vistas
{
    public partial class CambioEstadosOP : Form
    {
        string Usuario = Sesion.TipoUsuario;
        public CambioEstadosOP()
        {
            InitializeComponent();
            ValidarUsuario();
        }

        public void ValidarUsuario()
        {
            OrdenProduccionP pres = new OrdenProduccionP();
            int DNI = Sesion.Dni;
            OrdenProduccion op = new OrdenProduccion();
            Modelo.AdministrarInspeccion ai = new Modelo.AdministrarInspeccion();
            if(Usuario=="Supervisor Linea")
            {
                op= pres.TraerDatos(DNI);
                txtOP.Text = op.CodOP.ToString();
                txtEstado.Text = op.EstadoOP;
            }
            else
            {
                if (Usuario == "Supervisor Calidad")
                {
                    ai = pres.TraerDatosInspeccion(DNI);
                    txtOP.Text = ai.NumOP.ToString();
                    txtEstado.Text = ai.EstadoInspeccion;
                }
            }

        }

        private void pbIniciar_Click(object sender, EventArgs e)
        {
           
            string estado = "Iniciado";
            int numeroOP = int.Parse(txtOP.Text);
            ActualizarEstados(estado, numeroOP);
        }

        public void ActualizarEstados(string estado, int numOP)
        {
            string respuesta = "";
            OrdenProduccionP pres = new OrdenProduccionP();
            if (Usuario == "Supervisor Linea")
            {
                respuesta = pres.ActualizarEstadosOP(numOP, estado);
            }
            else
            {
                if (Usuario == "Supervisor Calidad")
                {
                    respuesta = pres.ActualizarEstadosInspeccion(numOP, estado);
                }
            }
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbPausar_Click(object sender, EventArgs e)
        {
            string estado = "Pausada";
            int numeroOP = int.Parse(txtOP.Text);
            ActualizarEstados(estado, numeroOP);
        }

        private void pbFinalizar_Click(object sender, EventArgs e)
        {
            string estado = "Finalizada";
            int numeroOP = int.Parse(txtOP.Text);
            int dni = Sesion.Dni;
            ActualizarEstados(estado, numeroOP);
            ActualizarEstadosUsuarios(dni);
        }

        public string ActualizarEstadosUsuarios(int dni)
        {
            string respuesta = "";
            string estado = "Disponible";
            OrdenProduccionP pres = new OrdenProduccionP();     
            respuesta = pres.AdministrarEstadosUsuarios(dni, estado);       
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

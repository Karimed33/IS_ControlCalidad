using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlCalidadDominio.Modelo;
using ControlCalidad.Presentador;
using ControlCalidadSistemaExterno.Adaptador;

namespace ControlCalidad.Vistas
{
    public partial class Reportes : Form
    {
        readonly DateTime hoy = DateTime.Now;
        public Reportes()
        {
            InitializeComponent();
            CargarHoras();
            txtCodOP.Text = ObtenerOP(Sesion.Dni).ToString();
        }

        public int ObtenerOP(int dni)
        {
            OrdenProduccion op;
            int numero;
            AdapterOP pres = new AdapterOP();
            op = pres.TraerDatos(dni);
            numero = op.CodOP;
            return numero;
        }
        public void CargarHoras()
        {
            var presentador = new InspeccionP();
            int acumuladoIzq, acumuladoDer;
            List<Defectos> lista = ListaDefectos(int.Parse(txtCodOP.Text));
            int hora = int.Parse(hoy.ToShortTimeString().Substring(0, 2));
            for (var i = 1; i < 4; i++)
            {

                hora--;
                var control = new ReporteDefectosControl(hora);
                fLPHoras.Controls.Add(control);
                fLPPies.Controls.Add(control);
                foreach (var a in lista)
                {
                    acumuladoIzq = presentador.Acumular(int.Parse(txtCodOP.Text), a.Id, "Izquierdo", hora);
                    acumuladoDer = presentador.Acumular(hora, a.Id, "Derecho", hora);
                    var control2 = new ReporteDefectosControl(a.Id, a.Defecto, acumuladoDer, acumuladoIzq);
                    fLPDefectos.Controls.Add(control2);
                    flPAcumuladores.Controls.Add(control2);

                }
            }
            

        }


        public List<Defectos> ListaDefectos(int CodOP)
        {
            InspeccionP presentador = new InspeccionP();
            var listaDefectos = presentador.ListarDefectos(CodOP);
            return listaDefectos;
        }
       
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

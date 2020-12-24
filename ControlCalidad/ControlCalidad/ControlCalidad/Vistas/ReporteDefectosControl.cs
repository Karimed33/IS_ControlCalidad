using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlCalidad.EventsArgs;

namespace ControlCalidad.Vistas
{
    public partial class ReporteDefectosControl : UserControl
    {
        private int _acumuladorIzq;
        private string _nombreDefecto;
        private int _hora;
        private int _acumuladorDer;
        private int _id;

        public ReporteDefectosControl()
        {
            InitializeComponent();
        }

        public ReporteDefectosControl(int hora) : this()
        {
           
            _hora = hora;
            lbDerecho.Text = "D";
            lbIzquierdo.Text = "I";
            lbhora.Text = _hora.ToString();
        }

        public ReporteDefectosControl(int id, string defecto, int izquierdo, int derecho) : this()
        {
            _id = id;
            _nombreDefecto = defecto;
            _acumuladorDer = derecho;
            _acumuladorIzq = izquierdo;
            lbDefectos.Text = _nombreDefecto.ToString();
            txtAcumuladorDer.Text = _acumuladorDer.ToString();
            txtAcumuladorIzq.Text = _acumuladorIzq.ToString();
        }

    

        public void Acumular(string pie, int acumulado)
        {
            if (pie == "Izquierdo")
            {
                txtAcumuladorIzq.Text = acumulado.ToString();
            }
            else
            {
                txtAcumuladorDer.Text = acumulado.ToString();
            }
        }

        private void lbDefectos_Click(object sender, EventArgs e)
        {

        }
    }
}

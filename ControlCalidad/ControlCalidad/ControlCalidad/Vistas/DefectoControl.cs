using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlCalidad.Modelo;
using ControlCalidad.Presentador;
using ControlCalidad.EventsArgs;

namespace ControlCalidad.Vistas
{
  
    public partial class DefectoControl : UserControl
    {
        private int _id;
        private string _nombreDefecto;
        public event EventHandler<DefectoEventArgs> AgregarClicked;
        public event EventHandler<DefectoEventArgs> EliminarClicked;
 
        public DefectoControl()
        {
            InitializeComponent();
        }

        public DefectoControl(int numero, string nombre, int acumuladoDer, int acumuladoIzq) : this()
        {
            _id = numero;
            _nombreDefecto = nombre;
            lbDefectos.Text = _nombreDefecto.ToString();
            txtAcumuladorDer.Text = acumuladoDer.ToString();
            txtAcumuladorIzq.Text = acumuladoIzq.ToString();

        }

        private void OnAgregarClicked(string pie)
        {
            AgregarClicked?.Invoke(this, new DefectoEventArgs(pie, _id ) );
        }

        private void OnEliminarClicked(string pie)
        {
            EliminarClicked?.Invoke(this, new DefectoEventArgs(pie, _id));
        }

        private void btnAgregarIzq_Click(object sender, EventArgs e)
        {
            OnAgregarClicked("Izquierdo");
        }

        public void Acumular(string pie, int acumulado)
        {
            if(pie == "Izquierdo")
            {
                txtAcumuladorIzq.Text = acumulado.ToString();
            }
            else
            {
                txtAcumuladorDer.Text = acumulado.ToString();
            }
        }

        private void btnEliminarIzq_Click(object sender, EventArgs e)
        {
            OnEliminarClicked("Izquierdo");
        }

        private void btnEliminarDer_Click(object sender, EventArgs e)
        {
            OnEliminarClicked("Derecho");
        }

        private void btnAgregarDer_Click(object sender, EventArgs e)
        {
           
            OnAgregarClicked("Derecho");
        }
    }
}

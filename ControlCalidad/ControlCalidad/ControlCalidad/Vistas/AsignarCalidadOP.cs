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

namespace ControlCalidad.Vistas
{
    public partial class AsignarCalidadOP : UserControl
    {
        private int _numeroOP;
        public AsignarCalidadOP()
        {
            InitializeComponent();
        }


        public AsignarCalidadOP(int numero) : this()
        {
            _numeroOP = numero;
         

        }

        private void btnAsignarOP_Click(object sender, EventArgs e)
        {

        }


        /* public AsignarOPCalidad Agregar(string pie)
         {
             DateTime hoy = DateTime.Now;
             bool bandera = false;
             Inspecciones insp = new Inspecciones()
             {
                 Defecto = lbDefectos.Text,
                 Cantidad = 1,
                 //Hora = ObtenerHora(),
                 Pie = pie,
                 //CodOP = ObtenerOP(),
                 //TipoDefecto = ObtenerTipoDefecto(),
                 Fecha = hoy.ToShortDateString()
             };
             //InspeccionP presentdor = new InspeccionP();
             bandera = presentdor.Insertar(insp);
             return insp;
         }*/


        /*public AsignarOPCalidad Eliminar(string pie)
        {
            DateTime hoy = DateTime.Now;
            bool bandera = false;
            Inspecciones insp = new Inspecciones()
            {
                Defecto = lbDefectos.Text,
                Cantidad = -1,
                Hora = ObtenerHora(),
                Pie = pie,
                CodOP = ObtenerOP(),
                TipoDefecto = ObtenerTipoDefecto(),
                Fecha = hoy.ToShortDateString()
            };
            InspeccionP presentdor = new InspeccionP();
            bandera = presentdor.Insertar(insp);
            return insp;
        }*/







        /*private void btnAsignarOP_Click(object sender, EventArgs e)
        {
            AsignarOP insp = new AsignarOP();
            insp = Agregar("Derecho");
            txtAcumuladorDer.Text = Acumular(insp).ToString();
        }

        private void btnEliminarOP_Click(object sender, EventArgs e)
        {
            Inspecciones insp = new Inspecciones();
            insp = Eliminar("Derecho");
            txtAcumuladorDer.Text = Acumular(insp).ToString();
        }*/
    }
}

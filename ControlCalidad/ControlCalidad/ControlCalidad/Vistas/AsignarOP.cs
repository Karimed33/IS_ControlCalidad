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
    public partial class AsignarOP : Form
    {
        readonly DateTime hoy = DateTime.Now;
        public AsignarOP()
        {
            InitializeComponent();
            txtUsuario.Text = Sesion.Dni.ToString();
            fLPOP.Visible = false;
            CargarOP();
           
        
        }

        private void btnObservado_Click(object sender, EventArgs e)
        {
            fLPOP.Visible = true;
        }

      

        public void CargarOP()
        {
            List<OrdenProduccion> listaOP;
            AdapterOP presentador = new AdapterOP();
            listaOP = presentador.ConsultaOPActivas();
            var _opCalidad = new AsignarOPCalidad();
            AsignarOPP asignar = new AsignarOPP();
            _opCalidad = asignar.VerOP(Sesion.Dni);
            if (_opCalidad == null)
            {
                foreach (var a in listaOP)
                {

                    var control = new AsignarCalidadOP(a.CodOP);
                    fLPOP.Controls.Add(control);
                }
            }
            else
            {
                var Op = new OrdenProduccion();
                Op = presentador.VerOP(_opCalidad.numeroOP);
                var control = new AsignarCalidadOP(Op.CodOP);
                fLPOP.Controls.Add(control);
            }
        }





        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*public Eliminar()
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

    }
}

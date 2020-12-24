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
using ControlCalidadDominio.Modelo;
using ControlCalidadSistemaExterno.Adaptador;

namespace ControlCalidad.Vistas
{
    public partial class Inspeccion : Form
    {
        private int _horaSelecciona;
        readonly DateTime hoy = DateTime.Now;
        public Inspeccion()
        {
            InitializeComponent();
            txtNumeroOP.Text = ObtenerOP(Sesion.Dni).ToString();
            txtTurno.Text = ObtenerTurno();
            txtUsuario.Text = Sesion.Dni.ToString();
            fLPReproceso.Visible = false;
            fLPObservado.Visible = false;
            txthora.Visible = false;
            btnObservado.Visible = false;
            btnReproceso.Visible = false;
            ffLPPrimeraCalidad.Visible = false;
            CargarHoraTurnos();
            ValidarOP();

        }

        public void ValidarOP()
        {
            AdministrarInspeccion op;
            AdapterOP pres = new AdapterOP();
            op = pres.TraerSupCalidad(Sesion.Dni);
            var estado = op.Estado;
            if (estado == "En Proceso")
            {
                btnReproceso.Visible = true;
                btnObservado.Visible = true;
                ffLPPrimeraCalidad.Visible = true;
            }
            else
            {
                MessageBox.Show("No tiene una OP con estado En Proceso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public int ObtenerOP(int dni)
        {
            AdministrarInspeccion op;
            int numero;
            AdapterOP pres = new AdapterOP();
            op = pres.TraerSupCalidad(dni);
            numero = op.NumeroOP;
            return numero;
        }

        public string ObtenerTurno()
        {
            string fecha = hoy.ToShortDateString();
            string horaActual = hoy.ToShortTimeString();
            OrdenProduccion op;
            AdapterOP pres = new AdapterOP();
            op = pres.VerOP(int.Parse(txtNumeroOP.Text));
            string denominacion;
            string hora = op.HoraInicio;
            InspeccionP presentador = new InspeccionP();
            if (op.FechaInicio == fecha)
            {
                denominacion = presentador.BuscarTurno(hora);
            }
            else
            {
                denominacion = presentador.BuscarTurno(horaActual);
            }

            return denominacion;
        }

        private void btnLineas_Click(object sender, EventArgs e)
        {
            fLPReproceso.Visible = false;
            btnPrimeraCaliadad.BackColor = Color.FromArgb(26, 32, 40);
            btnObservado.BackColor = Color.FromArgb(12, 61, 92);
            btnReproceso.BackColor = Color.FromArgb(26, 32, 40);
            fLPObservado.Visible = true;
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            fLPObsevado.Visible = false;
            btnPrimeraCaliadad.BackColor = Color.FromArgb(26, 32, 40);
            btnReproceso.BackColor = Color.FromArgb(12, 61, 92);
            btnObservado.BackColor = Color.FromArgb(26, 32, 40);
            fLPReproceso.Visible = true;
        }

        public void CargarObservado()
        {
            List<Defectos> listaDefectos;
            InspeccionP presentador = new InspeccionP();
            int CodOP = int.Parse(txtNumeroOP.Text);
            int acumuladoIzq, acumuladoDer;
            listaDefectos = presentador.ConsultaDefectos("Observado");
            foreach (var a in listaDefectos)
            {
                acumuladoIzq = presentador.Acumular(CodOP, a.Id, "Izquierdo", _horaSelecciona);
                acumuladoDer = presentador.Acumular(CodOP, a.Id, "Derecho", _horaSelecciona);
                var control = new DefectoControl(a.Id, a.Defecto, acumuladoDer, acumuladoIzq);
                control.AgregarClicked += Control_AgregarClicked;
                control.EliminarClicked += Control_EliminarClicked;
                fLPObservado.Controls.Add(control);

            }
        }

        private void Control_EliminarClicked(object sender, EventsArgs.DefectoEventArgs e)
        {
            var inspecciones = EliminarDefectos(e.Pie, e.Id);
            InspeccionP pres = new InspeccionP();
            int acumulador = pres.Acumular(inspecciones.CodOP, inspecciones.IdDefecto, inspecciones.Pie, int.Parse(inspecciones.Hora));
            ((DefectoControl)sender).Acumular(e.Pie, acumulador);
        }

        public void CargarReproceso()
        {
            List<Defectos> listaDefectos = new List<Defectos>();
            InspeccionP presentador = new InspeccionP();
            int acumuladoIzq, acumuladoDer;
            int CodOP = int.Parse(txtNumeroOP.Text);
            listaDefectos = presentador.ConsultaDefectos("Reproceso");
            foreach (var a in listaDefectos)
            {
                acumuladoIzq = presentador.Acumular(CodOP, a.Id, "Izquierdo", _horaSelecciona);
                acumuladoDer = presentador.Acumular(CodOP, a.Id, "Derecho", _horaSelecciona);
                var control = new DefectoControl(a.Id, a.Defecto, acumuladoDer, acumuladoIzq);
                control.AgregarClicked += Control_AgregarClicked;
                control.EliminarClicked += Control_EliminarClicked;
                fLPReproceso.Controls.Add(control);
            }
        }


        private void Control_AgregarClicked(object sender, EventsArgs.DefectoEventArgs e)
        {
            var inspecciones = AgregaDefectos(e.Pie, e.Id);
            InspeccionP pres = new InspeccionP();
            int acumulador = pres.Acumular(inspecciones.CodOP, inspecciones.IdDefecto, inspecciones.Pie, int.Parse(inspecciones.Hora));
            ((DefectoControl)sender).Acumular(e.Pie, acumulador);

        }

        public void CargarHoraTurnos()
        {
            string fecha = hoy.ToShortDateString();
            OrdenProduccion op;
            AdapterOP pres = new AdapterOP();
            op = pres.TraerDatos(Sesion.Dni);
            string denominacion = txtTurno.Text;
            int inicioOp = int.Parse(op.HoraInicio.Substring(0, 2));
            Turno turnos;
            InspeccionP presentador = new InspeccionP();
            turnos = presentador.ConsultaHoras(denominacion);
            int inicio = int.Parse(turnos.HoraInicio.Substring(0, 2));
            int fin = int.Parse(turnos.HoraFin.Substring(0, 2));
            if (op.FechaInicio == fecha)
            {
                CargarHoras(inicioOp, fin);
            }
            else
            {
                CargarHoras(inicio, fin);
            }

        }

        public void CargarHoras(int inicio, int fin)
        {
            if (fin < inicio)
            {
                for (var i = inicio; i < 24; i++)
                {
                    var control = new HoraControl(i + 1);
                    control.HoraClicked += Control_HoraClicked;
                    fLPTurnos.Controls.Add(control);
                }
                for (var i = -1; i <= fin; i++)
                {
                    var control = new HoraControl(i + 1);
                    control.HoraClicked += Control_HoraClicked;
                    fLPTurnos.Controls.Add(control);
                }
            }
            else
            {
                for (var i = inicio; i <= fin; i++)
                {
                    var control = new HoraControl(i);
                    control.HoraClicked += Control_HoraClicked;
                    fLPTurnos.Controls.Add(control);
                }
            }
        }


        private void Control_HoraClicked(object sender, int e)
        {
            _horaSelecciona = e;
            fLPObservado.Controls.Clear();
            fLPReproceso.Controls.Clear();
            CargarObservado();
            CargarReproceso();
        }

        public string BuscarHora()
        {
            return _horaSelecciona.ToString();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            btnPrimeraCaliadad.BackColor = Color.FromArgb(12, 61, 92);
            btnReproceso.BackColor = Color.FromArgb(26, 32, 40);
            btnObservado.BackColor = Color.FromArgb(26, 32, 40);
            PrimeraCalidad insp;
            insp = AgregarProducciones();
            txtPrimeraCalidad.Text = AcumularProducciones(insp).ToString();

        }


        public PrimeraCalidad AgregarProducciones()
        {
            PrimeraCalidad insp = new PrimeraCalidad()
            {
                Cantidad = 1,
                Hora = BuscarHora(),
                CodOP = int.Parse(txtNumeroOP.Text),
                Fecha = hoy.ToShortDateString()
            };
            InspeccionP presentdor = new InspeccionP();
            _ = presentdor.InsertarPrimeraCalidad(insp);
            return insp;
        }

        public PrimeraCalidad EliminarProducciones()
        {
            PrimeraCalidad insp = new PrimeraCalidad()
            {
                Cantidad = -1,
                Hora = BuscarHora(),
                CodOP = int.Parse(txtNumeroOP.Text),
                Fecha = hoy.ToShortDateString()
            };
            InspeccionP presentdor = new InspeccionP();
            bool bandera = presentdor.InsertarPrimeraCalidad(insp);
            return insp;
        }


        public Inspecciones AgregaDefectos(string pie, int id)
        {
            DateTime hoy = DateTime.Now;
            Inspecciones insp = new Inspecciones()
            {
                IdDefecto= id,
                Cantidad = 1,
                Hora = _horaSelecciona.ToString(),
                Pie = pie,
                CodOP = int.Parse(txtNumeroOP.Text),  
                Fecha = hoy.ToShortDateString()
            };
            InspeccionP presentdor = new InspeccionP();
            bool bandera = presentdor.Insertar(insp);
            return insp;
        }

        public Inspecciones EliminarDefectos(string pie, int id)
        {
            DateTime hoy = DateTime.Now;
            Inspecciones insp = new Inspecciones()
            {
                IdDefecto = id,
                Cantidad = -1,
                Hora = _horaSelecciona.ToString(),
                Pie = pie,
                CodOP = int.Parse(txtNumeroOP.Text),
                Fecha = hoy.ToShortDateString()
            };
            InspeccionP presentdor = new InspeccionP();
            bool bandera = presentdor.Insertar(insp);
            return insp;
        }

        public int AcumularProducciones(PrimeraCalidad insp)
        {
            InspeccionP pres = new InspeccionP();
            int acumulador = pres.AcumularPrimeraCalidad(insp);
            return acumulador;

        }
        


        private void pbEliminar_Click(object sender, EventArgs e)
        {
            btnPrimeraCaliadad.BackColor = Color.FromArgb(12, 61, 92);
            btnReproceso.BackColor = Color.FromArgb(26, 32, 40);
            btnObservado.BackColor = Color.FromArgb(26, 32, 40);
            PrimeraCalidad insp;
            insp = EliminarProducciones();
            txtPrimeraCalidad.Text = AcumularProducciones(insp).ToString();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}

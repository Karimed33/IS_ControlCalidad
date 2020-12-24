using ControlCalidad.Modelo;
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

namespace ControlCalidad.Vistas
{
    public partial class AdministrarOP : Form
    {
        public AdministrarOP()
        {
            InitializeComponent();
            Ocultar();
            OcultarLinea();
            MostrarLineaDisponible();
            txtUsuario.Text = Sesion.Usuario2;
            cbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbModelo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Ocultar()
        {
            txtNumeroOP.Visible = false;
            pbAsignar.Visible = false;
            lbAsignar.Visible = false;
            pbNuevo.Visible = false;
            lbNuevo.Visible = false;
            pbModificar.Visible = false;
            lbModificar.Visible = false;
            txtObjetivo.Visible = false;
            lbOjetivo.Visible = false;
            txtBusqueda.Visible = false;
            lbNumOP.Visible = false;
            txtLineaTrabajo.Visible = false;
            lbLineaTrabajo.Visible = false;
            txtDetalle.Visible = false;
            lbDetalle.Visible = false;
            cbColor.Visible = false;
            cbModelo.Visible = false;
            lbModelo.Visible = false;
            lbColor.Visible = false;
        }

        private void OcultarLinea()
        {
            pbLinea1.Visible = false;
            pbLinea1.Visible = false;
            pbLinea2.Visible = false;
            pbLinea2.Visible = false;
            pbLinea3.Visible = false;
            pbLinea3.Visible = false;
            pbLinea4.Visible = false;
            pbLinea4.Visible = false;
        }

        private void mostrarUP()
        {
            
            txtBusqueda.Visible = true;
            lbNumOP.Visible = true;
            
        }

        private void MostrarDown()
        {
            txtNumeroOP.Visible = true;
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
        }

        private void Limpiar()
        {
            txtBusqueda.Text = "";
            txtNumeroOP.Text = "";
            txtObjetivo.Text = "";
            txtLineaTrabajo.Text = "";
            txtDetalle.Text = "";
            cbColor.Text = "";
            cbModelo.Text = "";
        }
        public void ComboModelos()
        {
            OrdenProduccionP pres = new OrdenProduccionP();
            cbModelo.DataSource = null;
            cbModelo.Items.Clear();
            DataTable dt = pres.MostrarModelos();
            cbModelo.ValueMember = "Id";
            cbModelo.DisplayMember = "CodModelo";
            cbModelo.DisplayMember = "Denominacion";
            cbModelo.DisplayMember = "Objetivo";
            cbModelo.DataSource = dt;
        }
        private void ComboColores()
        {
            OrdenProduccionP pres = new OrdenProduccionP();
            cbColor.DataSource = null;
            cbColor.Items.Clear();
            DataTable dt = pres.MostrarColores();
            cbColor.ValueMember = "Id";
            cbColor.DisplayMember = "CodModelo";
            cbColor.DisplayMember = "Denominacion";
            cbColor.DisplayMember = "Objetivo";
            cbColor.DataSource = dt;
        }
        public void MostrarLineaDisponible()
        {
            if (Sesion.TipoUsuario == "Supervisor Linea")
            {
                bool bandera = false;
                OrdenProduccionP presentador = new OrdenProduccionP();
                for (int i = 1; i <= 4; i++)
                {
                    bandera = presentador.BuscarEstadoLinea(i);
                    if (bandera && i == 1)
                    {
                        pbLinea1.Visible = true;
                        lbLinea1.Visible = true;
                    }
                    else
                    {
                        if (bandera && i == 2)
                        {
                            pbLinea2.Visible = true;
                            lbLinea2.Visible = true;
                        }
                        else
                        {
                            if (bandera && i == 3)
                            {
                                pbLinea3.Visible = true;
                                lbLinea3.Visible = true;
                            }
                            else
                            {
                                if (bandera && i == 4)
                                {
                                    pbLinea4.Visible = true;
                                    lbLinea4.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (Sesion.TipoUsuario == "Supervisor Calidad")
                {
                    mostrarUP();
                    pbBuscar.Visible = true;
                    lbBuscar.Visible = true;
                }
            }
        }
        private void AsignarOP_Load(object sender, EventArgs e)
        {

            Timer t1 = new Timer();
            t1.Interval = 5000;
            t1.Tick += Timer1_Tick;
            t1.Start();

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Timer1_Tick(object sender, EventArgs e)
        {

            CargarTablaOP();
           

        }

        public void CargarTablaOP()
        {
            string dato = "Disponible";
            OrdenProduccionP presentador = new OrdenProduccionP();
            dGVOP.DataSource = presentador.TablaOP(dato);

        }

        private void pbAsignar_Click(object sender, EventArgs e)
        {
            Asignar();
            Ocultar();
            Limpiar();
        }

        public void Asignar()
        {
            int dni = Sesion.Dni;
            bool bandera = false;
            string respuesta="";
            string estado = "Ocupado";
            AdministrarInspeccion _op = new AdministrarInspeccion();
            _op.NumOP = int.Parse(txtNumeroOP.Text);
            _op.DniSupCalidad = Sesion.Dni;
            _op.EstadoInspeccion = "Iniciada";
            _op.Linea = int.Parse(txtLineaTrabajo.Text);
            OrdenProduccionP presentador = new OrdenProduccionP();
            bandera = presentador.InsertarAsignacionIsnpeccion(_op);
            if(bandera)
            {
                respuesta = presentador.AdministrarEstadosUsuarios(dni, estado);
            }
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        


        private void pbBuscar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusqueda.ToString()))
            {

                Buscar();
            }
            else
            {
                MessageBox.Show("Debe ingrese el Numero de Orden de Produccion", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Buscar()
        {
            if (Sesion.TipoUsuario == "Supervisor Linea")
            {
                string dato = txtBusqueda.Text;
                OrdenProduccionP presentador = new OrdenProduccionP();
                presentador.ValidarDato(dato);
                try
                {
                    string respuesta = presentador.ValidaOP(dato);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtNumeroOP.Text = txtBusqueda.Text;
                        MostrarDown();
                        pbModificar.Visible = true;
                        lbModificar.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MostrarDown();
                pbAsignar.Visible = true;
                lbAsignar.Visible = true;
                txtNumeroOP.ReadOnly = true;
                cbColor.Enabled = false;
                cbModelo.Enabled = false;
            }
        }

        private void pbLinea1_Click(object sender, EventArgs e)
        {
            string cargo = Sesion.TipoUsuario;
            txtLineaTrabajo.Text = "1";
            if(cargo == "Supervisor Linea")
            {
                txtBusqueda.Visible = true;
                lbNumOP.Visible = true;
                pbNuevo.Visible = true;
                lbNuevo.Visible = true;
                pbBuscar.Visible = true;
                lbBuscar.Visible = true;
            }
        }

        private void pbLinea2_Click(object sender, EventArgs e)
        {
            txtLineaTrabajo.Text = "2";
            txtBusqueda.Visible = true;
            
        }

        private void pbLinea3_Click(object sender, EventArgs e)
        {
            txtLineaTrabajo.Text = "3";
        }

        private void pbLinea4_Click(object sender, EventArgs e)
        {
            txtLineaTrabajo.Text = "4";
        }

        public void CargarTabla(string dato)
        {
            OrdenProduccionP presentador = new OrdenProduccionP();
            dGVOP.DataSource = presentador.Consulta(dato);

        }
        private void cbModelo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string dato = cbModelo.Text;
            ModeloP presentador = new ModeloP();
            txtObjetivo.Text = presentador.CargarObjetivo(dato).ToString();
        }

        private void pbNuevo_Click(object sender, EventArgs e)
        {
            if (Sesion.TipoUsuario == "Supervisor Linea")
            {
                ComboModelos();
                ComboColores();
                MostrarDown();
                pbNuevo.Visible = true;
                lbNuevo.Visible = true;
            }
            else
            {
                MessageBox.Show("Permiso Denegado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pbAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
            CargarTabla(null);
            Ocultar();
            Limpiar();

        }

        public void Agregar()
        {
            string respuesta;
            OrdenProduccion _op = new OrdenProduccion();
            _op.CodOP = int.Parse(txtNumeroOP.Text);
            _op.Detalle = txtDetalle.Text;
            _op.EstadoOP = "Ocupado";
            _op.Color = cbColor.Text;
            _op.Modelo = cbModelo.Text;
            _op.Objetivo = int.Parse(txtObjetivo.Text);
            _op.DNI = Sesion.Dni;
            _op.Linea = int.Parse(txtLineaTrabajo.Text);
            OrdenProduccionP presentador = new OrdenProduccionP();
            respuesta = presentador.Insertar(_op);
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dGVOP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void pbModificar_Click(object sender, EventArgs e)
        {
            Modificar();
            CargarTabla(null);
            Ocultar();
            Limpiar();
        }

        public void Modificar()
        {
            string respuesta;
            OrdenProduccion _op = new OrdenProduccion()
            {
                CodOP = int.Parse(txtNumeroOP.Text),
                Detalle = txtDetalle.Text,
                EstadoOP = txtEstadoOP.Text,
                Color = cbColor.Text,
                Modelo = cbColor.Text,
                Linea = int.Parse(txtLineaTrabajo.Text),
                Objetivo = int.Parse(txtObjetivo.Text),
            };
            OrdenProduccionP presentador = new OrdenProduccionP();
            _op.Id = int.Parse(txtId.Text);
            respuesta = presentador.Actualizar(_op);
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

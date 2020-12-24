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
using ControlCalidad.Interfaz;
using ControlCalidadDominio.Modelo;
using ControlCalidadSistemaExterno.Adaptador;

namespace ControlCalidad.Vistas
{
    public partial class ModelosGestion : Form, IGestionar
    {
        public ModelosGestion()
        {
            InitializeComponent();
            CargarTabla(null);
            OcultarDown();
        }

        public void CargarTabla(string dato)
        {
            AdapterModels presentador = new AdapterModels();
            dGVModelos.DataSource = presentador.ConsultaModelo(dato);

        }
        

        /*private void dGVModelos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            if (n != -1)
            {
                txtId.Text = (string)dGVModelos.Rows[n].Cells[0].Value;
                txtCodigoModelo.Text = (string)dGVModelos.Rows[n].Cells[1].Value;
                txtDenominacion.Text = (string)dGVModelos.Rows[n].Cells[2].Value;
                txtObjetivo.Text = (string)dGVModelos.Rows[n].Cells[3].Value;

            }
        }*/


        private void Limpiar()
        {
            txtBusqueda.Text = "";
            txtCodigoModelo.Text = "";
            txtDenominacion.Text = "";
            txtObjetivo.Text = "";

        }
        private void OcultarDown()
        {
            pbConsultar.Visible = false;
            lbConsultar.Visible = false;
            pbAgregar.Visible = false;
            lbAgregar.Visible = false;
            pbModificar.Visible = false;
            lbModificar.Visible = false;
            pbEliminar.Visible = false;
            lbEliminar.Visible = false;
            txtCodigoModelo.Visible = false;
            lbCodModelo.Visible = false;
            txtDenominacion.Visible = false;
            lbDenominacion.Visible = false;
            txtObjetivo.Visible = false;
            lbOjetivo.Visible = false;
        }

        private void OcultarUp()
        {
            pbBuscar.Visible = false;
            lbBuscar.Visible = false;
            pbNuevo.Visible = false;
            lbNuevo.Visible = false;
            txtBusqueda.Visible = false;
            lbBusqueda.Visible = false;
            pbConsultar.Visible = false;
            lbConsultar.Visible = false;
        }

        private void MostrarUp()
        {
            pbBuscar.Visible = true;
            lbBuscar.Visible = true;
            pbNuevo.Visible = true;
            lbNuevo.Visible = true;
            txtBusqueda.Visible = true;
            lbBusqueda.Visible = true;
            pbConsultar.Visible = true;
            lbConsultar.Visible = true;
        }

        private void Mostrar()
        {
            txtCodigoModelo.Visible = true;
            lbCodModelo.Visible = true;
            txtDenominacion.Visible = true;
            lbDenominacion.Visible = true;
            txtObjetivo.Visible = true;
            lbOjetivo.Visible = true;
            pbModificar.Visible = true;
            lbModificar.Visible = true;
            pbEliminar.Visible = true;
            lbEliminar.Visible = true;
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBusqueda.ToString()))
            {
                MessageBox.Show("Debe ingresar algun dato de Busqueda", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CargarTabla(txtBusqueda.Text);
                pbConsultar.Visible = true;
                lbConsultar.Visible = true;
                pbNuevo.Visible = false;
                lbNuevo.Visible = false;
            }
        }

        private void pbConsultar_Click(object sender, EventArgs e)
        {
            Mostrar();
            txtId.Text = this.dGVModelos.CurrentRow.Cells[0].Value.ToString();
            txtCodigoModelo.Text = this.dGVModelos.CurrentRow.Cells[1].Value.ToString();
            txtDenominacion.Text = this.dGVModelos.CurrentRow.Cells[2].Value.ToString();
            txtObjetivo.Text = this.dGVModelos.CurrentRow.Cells[3].Value.ToString();
            OcultarUp();
        }


        private void pbNuevo_Click(object sender, EventArgs e)
        {
            
            Mostrar();
            lbAgregar.Visible = true;
            pbAgregar.Visible = true;
            OcultarUp();
            lbModificar.Visible = false;
            pbModificar.Visible = false;
            pbEliminar.Visible = false;
            lbEliminar.Visible = false;
            

        }


        private void pbAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
            CargarTabla(null);
            OcultarDown();
            Limpiar();
            MostrarUp();
        }

        public void Agregar()
        {
            string respuesta;
            Modelos _modelo = new Modelos();
            _modelo.CodigoModelo = txtCodigoModelo.Text;
            _modelo.Denominacion = txtDenominacion.Text;
            _modelo.Objetivo = int.Parse(txtObjetivo.Text);


            AdapterModels presentador = new AdapterModels();
            respuesta = presentador.Insertar(_modelo);
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbModificar_Click(object sender, EventArgs e)
        {
            Modificar();
            CargarTabla(null);
            OcultarDown();
            MostrarUp();
        }

        public void Modificar()
        {
            string respuesta;
            Modelos _modelos = new Modelos()
            {
                CodigoModelo = txtCodigoModelo.Text,
                Denominacion = txtDenominacion.Text,
                Objetivo = int.Parse(txtObjetivo.Text),
            };
            AdapterModels presentador = new AdapterModels();
            _modelos.Id = int.Parse(txtId.Text);
            respuesta = presentador.Actualizar(_modelos);
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            CargarTabla(null);
            Limpiar();
            OcultarDown();
            MostrarUp();
        }

        public void Eliminar()
        {
            DialogResult resultado = MessageBox.Show("Seguro que desea Eliminar el Modelo?", "Salir", MessageBoxButtons.YesNoCancel);
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dGVModelos.CurrentRow.Cells[0].Value.ToString());
                string respuesta = "";
                AdapterModels presentador = new AdapterModels();
                respuesta = presentador.Eliminar(id);
                MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarUp();
            }
            else
            {
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

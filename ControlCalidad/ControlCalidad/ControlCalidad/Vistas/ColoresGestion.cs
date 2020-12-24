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
using ControlCalidad.Modelo;
using ControlCalidadDominio.Modelo;
using ControlCalidadSistemaExterno.Adaptador;

namespace ControlCalidad.Vistas
{
    public partial class ColoresGestion : Form, IGestionar
    {
        public ColoresGestion()
        {
            InitializeComponent();
            CargarTabla(null);
            OcultarDown();
        }

        public void CargarTabla(string dato)
        {
            AdapterColor presentador = new AdapterColor();
            dGVColores.DataSource = presentador.Consulta(dato);

        }


        private void Limpiar()
        {
            txtBusqueda.Text = "";
            txtCodigoColor.Text = "";
            txtDescripcion.Text = "";
           

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
            txtCodigoColor.Visible = false;
            lbCodColor.Visible = false;
            txtDescripcion.Visible = false;
            lbDescripcion.Visible = false;
        }

        private void OcultarUp()
        {
            pbBuscar.Visible = false;
            lbBuscar.Visible = false;
            pbNuevo.Visible = false;
            lbNuevo.Visible = false;
            pbConsultar.Visible = false;
            lbConsultar.Visible = false;
            txtBusqueda.Visible = false;
            lbBusqueda.Visible = false;
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
            txtCodigoColor.Visible = true;
            lbCodColor.Visible = true;
            txtDescripcion.Visible = true;
            lbDescripcion.Visible = true;
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
            txtId.Text = this.dGVColores.CurrentRow.Cells[0].Value.ToString();
            txtCodigoColor.Text = this.dGVColores.CurrentRow.Cells[1].Value.ToString();
            txtDescripcion.Text = this.dGVColores.CurrentRow.Cells[2].Value.ToString();
            OcultarUp();
        }

        private void pbNuevo_Click(object sender, EventArgs e)
        {
            
            txtCodigoColor.Visible = true;
            lbCodColor.Visible = true;
            txtDescripcion.Visible = true;
            lbDescripcion.Visible = true;
            OcultarUp();
            pbAgregar.Visible = true;
            lbAgregar.Visible = true;
            
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
            Colores _color = new Colores();
            _color.CodigoColor = txtCodigoColor.Text;
            _color.Descripcion = txtDescripcion.Text;


            AdapterColor presentador = new AdapterColor();
            respuesta = presentador.Insertar(_color);
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
            Colores _color = new Colores()
            {
                CodigoColor = txtCodigoColor.Text,
                Descripcion = txtDescripcion.Text,
            };
            AdapterColor presentador = new AdapterColor();
            _color.Id = int.Parse(txtId.Text);
            respuesta = presentador.Actualizar(_color);
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MostrarUp();
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
            DialogResult resultado = MessageBox.Show("Seguro que desea Eliminar el Color?", "Salir", MessageBoxButtons.YesNoCancel);
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dGVColores.CurrentRow.Cells[0].Value.ToString());
                string respuesta = "";
                AdapterColor presentador = new AdapterColor();
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

        private void dGVColores_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}

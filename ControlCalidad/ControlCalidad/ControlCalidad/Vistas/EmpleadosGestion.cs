using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlCalidad.Interfaz;
using ControlCalidad.Modelo;
using ControlCalidad.Presentador;
using ControlCalidadDominio.Modelo;
using ControlCalidadSistemaExterno.Adaptador;

namespace ControlCalidad.Vistas
{
    public partial class EmpleadosGestion : Form, IGestionar
    {
        public EmpleadosGestion()
        {
            InitializeComponent();

            CargarTabla(null);
            //txtLegajoUsuario.Text = Sesion.Dni.ToString();
            OcultarDown();
            ComboCargo();
            cbCargo.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void ComboCargo()
        {
            AdapterrEmpleado pres = new AdapterrEmpleado();
            cbCargo.DataSource = null;
            cbCargo.Items.Clear();
            List<CargosUsuarios> dt = new List<CargosUsuarios>();
            dt = pres.ComboCargos();
            cbCargo.ValueMember = "IdCargos";
            cbCargo.DisplayMember = "Cargos";
            cbCargo.DataSource = dt;
        }
        

        

        public void CargarTabla(string dato)
        {
            AdapterrEmpleado presentador = new AdapterrEmpleado();
            dGVEmpleados.DataSource = presentador.Consulta(dato);

        }
       
        

        private void dGVEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*int n = e.RowIndex;
            if (n != -1)
            {
                txtId.Text = (string)dGVEmpleados.Rows[n].Cells[0].Value;
                txtApellido.Text = (string)dGVEmpleados.Rows[n].Cells[1].Value;
                txtNombres.Text = (string)dGVEmpleados.Rows[n].Cells[2].Value;
                txtDNI.Text = (string)dGVEmpleados.Rows[n].Cells[3].Value;
                txtMail.Text = (string)dGVEmpleados.Rows[n].Cells[4].Value;
                txtEstado.Text= (string)dGVEmpleados.Rows[n].Cells[5].Value;
                cbCargo.Text = (string)dGVEmpleados.Rows[n].Cells[6].Value;
            }*/
            txtId.Text = this.dGVEmpleados.CurrentRow.Cells[0].Value.ToString();
            txtApellido.Text = this.dGVEmpleados.CurrentRow.Cells[1].Value.ToString();
            txtNombres.Text = this.dGVEmpleados.CurrentRow.Cells[2].Value.ToString();
            txtDNI.Text = this.dGVEmpleados.CurrentRow.Cells[3].Value.ToString();
            txtMail.Text = this.dGVEmpleados.CurrentRow.Cells[4].Value.ToString();
            cbCargo.Text = this.dGVEmpleados.CurrentRow.Cells[5].Value.ToString();
        }

        private void Limpiar()
        {
            txtApellido.Text = " ";
            txtNombres.Text = " ";
            txtDNI.Text = " ";
            txtMail.Text = " ";
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
            txtApellido.Visible = false;
            lbApellido.Visible = false;
            txtNombres.Visible = false;
            lbNombres.Visible = false;
            txtMail.Visible = false;
            lbMail.Visible = false;
            txtDNI.Visible = false;
            lbDNI.Visible = false;
            cbCargo.Visible = false;
            lbCargo.Visible = false;
        }

        private void OcultarUp()
        {
            pbBuscar.Visible = false;
            lbBuscar.Visible = false;
            pbNuevo.Visible = false;
            lbNuevo.Visible = false;
            txtBusqueda.Visible = false;
            lbBuscar.Visible = false;
            lbBusqueda.Visible = false;
        }

        private void MostrarUp()
        {
            pbBuscar.Visible = true;
            lbBuscar.Visible = true;
            pbNuevo.Visible = true;
            lbNuevo.Visible = true;
            txtBusqueda.Visible = true;
            lbBuscar.Visible = true;
        }

        private void Mostrar()
        {
            pbConsultar.Visible = true;
            lbConsultar.Visible = true;
            pbAgregar.Visible = true;
            lbAgregar.Visible = true;
            pbModificar.Visible = true;
            lbModificar.Visible = true;
            pbEliminar.Visible = true;
            lbEliminar.Visible = true;
            txtApellido.Visible = true;
            lbApellido.Visible = true;
            txtNombres.Visible = true;
            lbNombres.Visible = true;
            txtMail.Visible = true;
            lbMail.Visible = true;
            txtDNI.Visible = true;
            lbDNI.Visible = true;
            cbCargo.Visible = true;
            lbCargo.Visible = true;
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
            txtId.Text = this.dGVEmpleados.CurrentRow.Cells[0].Value.ToString();
            txtApellido.Text = this.dGVEmpleados.CurrentRow.Cells[1].Value.ToString();
            txtNombres.Text = this.dGVEmpleados.CurrentRow.Cells[2].Value.ToString();
            txtDNI.Text = this.dGVEmpleados.CurrentRow.Cells[3].Value.ToString();
            txtMail.Text = this.dGVEmpleados.CurrentRow.Cells[4].Value.ToString();
            cbCargo.Text = this.dGVEmpleados.CurrentRow.Cells[5].Value.ToString();
            OcultarUp();
            pbAgregar.Visible = false;
            lbAgregar.Visible = false;
            
        }

        private void pbNuevo_Click(object sender, EventArgs e)
        {
            Mostrar();
            OcultarUp();
            lbModificar.Visible = false;
            pbModificar.Visible = false;
            pbEliminar.Visible = false;
            lbEliminar.Visible = false;
            pbConsultar.Visible = false;
            lbConsultar.Visible = false;
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
            AdapterUser user = new AdapterUser();
            CargosUsuarios cargos = user.TraerCargos(cbCargo.Text);
            Empleados _empleados = new Empleados()
            {
                Apellido = txtApellido.Text,
                Nombres = txtNombres.Text,
                DNI = int.Parse(txtDNI.Text),
                Mail = txtMail.Text,
                IdCargo= cargos.IdCargos,
            };
            AdapterrEmpleado presentdor = new AdapterrEmpleado();
            respuesta = presentdor.Insertar(_empleados);
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pbModificar_Click(object sender, EventArgs e)
        {
            Modificar();
            CargarTabla(null);
            OcultarDown();
        }

        public void Modificar()
        {
            string respuesta;
            AdapterUser user = new AdapterUser();
            CargosUsuarios cargos = user.TraerCargos(cbCargo.Text);
            Empleados _empleados = new Empleados()
            {
                Apellido = txtApellido.Text,
                Nombres = txtNombres.Text,
                DNI = int.Parse(txtDNI.Text),
                Mail = txtMail.Text,
                IdCargo = cargos.IdCargos,
            };
            AdapterrEmpleado presentador = new AdapterrEmpleado();
            _empleados.Id = int.Parse(txtId.Text);
            respuesta = presentador.Actualizar(_empleados);
            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
            CargarTabla(null);
            Limpiar();
            OcultarDown();
        }

        public void Eliminar()
        {
            DialogResult resultado = MessageBox.Show("Seguro que desea Eliminar el Modelo?", "Salir", MessageBoxButtons.YesNoCancel);
            if (resultado == DialogResult.Yes)
            {
                int id = int.Parse(dGVEmpleados.CurrentRow.Cells[0].Value.ToString());
                string respuesta = "";
                AdapterrEmpleado presentador = new AdapterrEmpleado();
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

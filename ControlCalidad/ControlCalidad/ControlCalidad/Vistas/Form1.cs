using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlCalidad.Vistas;
using ControlCalidad.Modelo;
using ControlCalidadDominio.Modelo;

namespace ControlCalidad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panelMenu.Width = 1;
            Ocultar();
            Permisos();
        }

        public void Permisos()
        {
            string cargo = Sesion.TipoUsuario;
            if(cargo=="Supervisor Linea")
            {
                btnEmpleados.Enabled = false;
                btnUsuarios.Enabled = false;
                btnCalidad.Enabled = false;
                btnModelos.Enabled = false;
                btnColores.Enabled = false;
            }
            else
            {
                if (cargo == "Supervisor Calidad")
                {
                    btnEmpleados.Enabled = false;
                    btnUsuarios.Enabled = false;
                    btnModelos.Enabled = false;
                    btnColores.Enabled = false;
                }
                else
                {
                    if (cargo == "Administrativo")
                    {
                        btnCalidad.Enabled = false;
                        btnAdmOP.Enabled = false;
                        btnAdmin.Enabled = false;
                    }
                }

            }
        }
        private void Ocultar()
        {
            btnModelos.Visible = false;
            btnColores.Visible = false;
            panel4.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel2.Visible = false;
            btnAdmin.Visible = false;
            btnAdmOP.Visible = false;
        }

        private void Mostrar()
        {
            btnModelos.Visible = true;
            btnColores.Visible = true;
            panel4.Visible = true;
            panel6.Visible = true;
            panel7.Visible = true;
            panel2.Visible = true;
            btnAdmin.Visible = true;
            btnAdmOP.Visible = true;
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
       

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulario<EmpleadosGestion>();
            btnEmpleados.BackColor = Color.FromArgb(12, 61, 92);
            Ocultar();
        }

        private void pbMenu_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 1)
            {
                panelMenu.Width = 220;
            }
            else
                panelMenu.Width = 1;
        }
        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbInicio_Click(null, e);
        }

        private void pbInicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<InicioContendor>();
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelContenedor.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                panelContenedor.Controls.Add(formulario);
                panelContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }



        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["EmpleadosGestion"] == null)
            {
                btnEmpleados.BackColor = Color.FromArgb(26, 32, 40);
            }
            else
            {
                if (Application.OpenForms["User"] == null)
                {
                    btnUsuarios.BackColor = Color.FromArgb(26, 32, 40);

                }
                else
                {
                    if (Application.OpenForms["ModelosGestion"] == null)
                    {
                        btnModelos.BackColor = Color.FromArgb(26, 32, 40);
                    }
                    else
                    {
                        if(Application.OpenForms["ColoresGestion"] == null)
                        {
                            btnColores.BackColor = Color.FromArgb(26, 32, 40);
                        }
                        else
                        {
                            if (Application.OpenForms["AsignarOP"] == null)
                            {
                                btnAdmOP.BackColor = Color.FromArgb(26, 32, 40);
                            }
                            else
                            {
                                if (Application.OpenForms["CambioEstadosOP"] == null)
                                {
                                    btnAdmin.BackColor = Color.FromArgb(26, 32, 40);
                                }
                                else
                                {
                                    if (Application.OpenForms["Inspeccion"] == null)
                                    {
                                        btnCalidad.BackColor = Color.FromArgb(26, 32, 40);
                                    }
                                    else
                                    {
                                        if (Application.OpenForms["Reportes"] == null)
                                        {
                                            btnReportes.BackColor = Color.FromArgb(26, 32, 40);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnModelos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ModelosGestion>();
            btnModelos.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario<User>();
            btnUsuarios.BackColor = Color.FromArgb(12, 61, 92);
            Ocultar();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Reportes>();
            btnReportes.BackColor = Color.FromArgb(12, 61, 92);
            Ocultar();
        }

        /*private void btnCalidad_Click(object sender, EventArgs e)
        {
            AbrirFormulario<InspeccionDefectos>();
            btnCalidad.BackColor = Color.FromArgb(12, 61, 92);
            Ocultar();
        }*/

        private void btnProduccion_Click(object sender, EventArgs e)
        {
            if (btnColores.Visible)
            {
                Ocultar();
                btnProduccion.BackColor = Color.FromArgb(26, 32, 40);

            }
            else
            {
                Mostrar();
                btnProduccion.BackColor = Color.FromArgb(12, 61, 92);
            }
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            AbrirFormulario<InicioContendor>();
        }

        private void btnColores_Click(object sender, EventArgs e)
        {
            AbrirFormulario<ColoresGestion>();
            btnColores.BackColor = Color.FromArgb(12, 61, 92);
           
        }

       

        private void btnAdmOP_Click(object sender, EventArgs e)
        {
            AbrirFormulario<AdministrarOP>();
            btnAdmOP.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AbrirFormulario<CambiosEstados>();
            btnAdmin.BackColor = Color.FromArgb(12, 61, 92);
        }

        private void btnCalidad_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inspeccion>();
            btnCalidad.BackColor = Color.FromArgb(12, 61, 92);
        }
    }
}

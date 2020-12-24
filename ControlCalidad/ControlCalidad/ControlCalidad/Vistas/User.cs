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
using ControlCalidad.Modelo;
using ControlCalidadSistemaExterno.Adaptador;
using ControlCalidadDominio.Modelo;
using System.Security.Cryptography;

namespace ControlCalidad.Vistas
{
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            cbTipoUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboCargo();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ComboCargo()
        {
            AdapterrEmpleado pres = new AdapterrEmpleado();
            cbTipoUsuario.DataSource = null;
            cbTipoUsuario.Items.Clear();
            List<CargosUsuarios> dt = pres.ComboCargos();
            cbTipoUsuario.ValueMember = "IdCargos";
            cbTipoUsuario.DisplayMember = "Cargos";
            cbTipoUsuario.DataSource = dt;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            AdapterUser user = new AdapterUser();
            string respuesta = null;
            CargosUsuarios cargos = user.TraerCargos(cbTipoUsuario.Text);
            Usuarios usuario = new Usuarios
            {
                Usuario = txtUsuario.Text,
                Contrase = txtPassword.Text,
                Dni = int.Parse(txtDni.Text),
                IdCargo = cargos.IdCargos
            };

            if (string.IsNullOrEmpty(usuario.Usuario) || string.IsNullOrEmpty(usuario.Contrase.ToString()) || string.IsNullOrEmpty(txtConPassword.Text) || string.IsNullOrEmpty(usuario.Dni.ToString()))
            {
                respuesta = "Debe llenar todos los campos";
            }
            else
            {
                if (usuario.Contrase.ToString() == txtConPassword.Text)
                {
                    respuesta = user.ExisteUsuario(usuario.Usuario);
                    if (respuesta ==null)
                    {
                        AdapterUser pres = new AdapterUser();
                        respuesta = pres.RegistrarUsuario(usuario);
                    }
                }
                else
                {
                    respuesta = "Las contraseñas no Coinciden";
                }
                MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Text = "";
                txtPassword.Text = "";
                txtConPassword.Text = "";
                txtDni.Text = "";
            }
        }



        public string GenerarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString();
        }
    }
}

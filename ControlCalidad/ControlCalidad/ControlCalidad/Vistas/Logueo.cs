using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlCalidad.Presentador;
using ControlCalidad.Interfaz;
using ControlCalidadSistemaExterno;
using ControlCalidadDominio.Modelo;
using System.Security.Cryptography;
using ControlCalidadSistemaExterno.Adaptador;

namespace ControlCalidad.Vistas
{
    public partial class Logueo : Form, ILogueo
    {
        public Logueo()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
           Ingresar();       
        }

        public void Ingresar()
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;
            string respuesta=null;
            Usuarios user = new Usuarios();
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todo los campos";
            }
            try
            {
               AdapterUser conecta = new AdapterUser();
                user = conecta.GetLogueo(usuario);
                if (user == null)
                {
                    respuesta = "El Usuario no Existe";
                }
                if (user.Contrase != txtPassword.Text)//GenerarSHA1(password))
                {
                    respuesta = "El Usuario y/o Contraseña no Coinciden";
                }
                if (respuesta!= null)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Sesion.Id2 = user.Id;
                    Sesion.Usuario2 = user.Usuario;
                    Sesion.Dni = user.Dni;
                    Sesion.IdTipoUsuario2 = user.IdCargo;
                    Sesion.TipoUsuario = VerUsuario(user.IdCargo);
                    Form1 inicio = new Form1();
                    inicio.Visible = true;
                    this.Visible = false;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public string VerUsuario(int idUsuario)
        {
            string resul;
            if (idUsuario == 1)
            {
                resul= "Administrador";
            }
            else
            {
                if (idUsuario == 2)
                {
                    resul = "Supervisor Calidad";
                }
                else
                {
                    if (idUsuario == 3)
                    {
                        resul= "Supervisor Linea";
                    }
                    else
                    {
                        resul = "Administrativo";
                    }
                }
            }
            return resul;
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

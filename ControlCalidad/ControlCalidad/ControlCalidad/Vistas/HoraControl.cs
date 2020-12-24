using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlCalidad.EventsArgs;

namespace ControlCalidad.Vistas
{
    public partial class HoraControl : UserControl
    {
        private int _hora;

        public event EventHandler<int> HoraClicked;
        public HoraControl()
        {
            InitializeComponent();
        }

        public HoraControl(int hora) : this()
        {
            _hora = hora;
            btnHora.Text = hora.ToString();

        }

        private void OnHoraClicked()
        {
            HoraClicked?.Invoke(this, _hora);
        }

     

        private void btnHora_Click(object sender, EventArgs e)
        {
            //btnHora.BackColor = Color.FromArgb(12, 61, 92);
            OnHoraClicked();
        }
    }
}

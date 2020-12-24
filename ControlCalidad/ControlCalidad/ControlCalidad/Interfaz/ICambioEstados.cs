using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Interfaz
{
    interface ICambioEstados
    {
        void ValidarUsuario();
        void ActualizarEstados(string estado, int numOP);
        void ActualizarEstadosUsuarios(int dni);
    }
}

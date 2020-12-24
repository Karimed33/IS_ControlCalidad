using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Interfaz
{
    interface IAdministrarOP
    {
        void ValidarUsuario();
        void ComboModelos();
        void ComboColores();
        void Asignar();
        void Buscar();
        void Agregar();

    }
}

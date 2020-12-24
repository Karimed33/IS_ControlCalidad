using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.Interfaz
{
    interface IGestionar
    {
        void CargarTabla(string dato);
        void Agregar();
        void Modificar();
        void Eliminar();
    }
}

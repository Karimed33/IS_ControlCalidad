using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlCalidad.EventsArgs
{
    public class DefectoEventArgs : EventArgs
    {
        public string Pie { set; get; }
        public int Id { set; get; }

        public DefectoEventArgs(string pie, int id)
        {
            Pie = pie;
            Id = id;
        }
    }

    
}

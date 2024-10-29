using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class CalibracionEquipo
    {
        public int Id { get; set; }

        public Calibracion Calibracion { get; set; }
        public Equipo Equipo { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class MantenimientoEquipo
    {
        public int Id { get; set; }

        public Equipo Equipo { get; set; }
        public Mantenimiento Mantenimiento { get; set; }

    }
}

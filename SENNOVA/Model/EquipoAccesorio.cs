using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class EquipoAccesorio
    {
        public int Id { get; set; }

        public Equipo Equipo { get; set; }
        public Accesorios Accesorios { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class IngresosAreasTecnicas
    {
        public int Id { get; set; }

        public AreaTecnica AreaTecnica { get; set; }
        public Ingreso Ingreso { get; set; }
    }
}

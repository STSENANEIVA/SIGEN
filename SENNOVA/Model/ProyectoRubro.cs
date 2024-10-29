using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class ProyectoRubro
    {
        public int Id { get; set; }
        public string Objeto { get; set; }
        public Nullable<decimal> Valor { get; set; }

        public Rubro Rubro { get; set; }
        public Proyecto Proyecto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Servicio
    {
        
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Requisitos { get; set; }
        public string Alcance { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public bool Activo { get; set; }

        public AreaTecnica AreaTecnica { get; set; }
        public Familia Familia { get; set; }
    }
}

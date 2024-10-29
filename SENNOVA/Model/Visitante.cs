using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Visitante
    {
        public int Id { get; set; }

        public TipoVisitante TipoVisitante { get; set; }
        public Persona Persona { get; set; }
        public List<Ingreso> lstIngresos { get; set; }
    }
}

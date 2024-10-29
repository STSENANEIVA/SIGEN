using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
   public  class AreaTecnica
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string NombreSin { get; set; }
        public bool Activo { get; set; }

        public Empleado Empleado { get; set; }
        public TipoAreaTecnica TipoAreaTecnica { get; set; }

        public  List<Servicio> lstServicios { get; set; }

    }
}

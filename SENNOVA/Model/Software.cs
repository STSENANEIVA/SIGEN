using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class Software
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Version { get; set; }
        public bool Activo { get; set; }

        public TipoLicencia TipoLicencia { get; set; }
        public List<EquipoSoftware> lstEquipoSoftware { get; set; }

    }
}

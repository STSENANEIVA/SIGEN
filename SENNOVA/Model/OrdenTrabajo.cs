using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class OrdenTrabajo
    {
        public int Id { get; set; }
        public bool AutorizaIngreso { get; set; }
        public string NumeroOT { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaLimite { get; set; }
        public DateTime FechaIngresoItem { get; set; }
        public string Observaciones { get; set; }

        public AreaTecnica AreaTecnica { get; set; }
        public Cotizacion Cotizacion { get; set; }
        public Empleado Responzable { get; set; }

        public List<OrdenTrabajoDetalle> lstOrdenTrabajoDetalles { get; set; }
    }
}

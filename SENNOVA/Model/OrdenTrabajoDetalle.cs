using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrdenTrabajoDetalle
    {
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public string CodigoItem { get; set; }
        public string Servicio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Observaciones { get; set; }
        public OrdenTrabajo OrdenTrabajo { get; set; }
    }
}

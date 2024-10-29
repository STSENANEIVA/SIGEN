using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class CotizacionDetalle
    {
        public int Id { get; set; }
        public decimal PrecioServicio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public string Observaciones { get; set; }

        public Cotizacion Cotizacion { get; set; }
        public Servicio Servicio { get; set; }
    }
}

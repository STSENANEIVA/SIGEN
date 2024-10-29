using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Cotizacion
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ValorTotal { get; set; }
        public string ValidezOferta { get; set; }
        public string NumeroFicha { get; set; }
        public string TipoCotizacion { get; set; }
        public string Observaciones { get; set; }

        public ProgramaFormacion ProgramaFormacion { get; set; }
        public Empleado Elaborador { get; set; }
        public Empleado Autorizador { get; set; }
        public Empleado Revisador { get; set; }
        public Cliente Cliente { get; set; }
        public List<TerminoCotizacion> lstTerminoCotizaciones { get; set; }
        public List<CotizacionDetalle> lstCotizacionDetalles { get; set; }
    }
}

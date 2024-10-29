using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class TerminoCotizacion
    {
        public int Id { get; set; }

        public TerminoCondicion TerminoCondicion { get; set; }
        public Cotizacion Cotizacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class Calibracion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoCalibracion { get; set; }
        public string TipoServicio { get; set; }
        public string NumeroCertificado { get; set; }
        public string Resultados { get; set; }
        public string Conforme { get; set; }
        public DateTime FechaProxima { get; set; }
        public string Observaciones { get; set; }

        public List<CalibracionEquipo> lstCalibracionEquipos { get; set; }

    }
}

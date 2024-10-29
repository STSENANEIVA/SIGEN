using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Proyecto
    {
        public int Id { get; set; }
        public string TituloProyecto { get; set; }
        public string CodigoSGPS { get; set; }
        public short AnoEjecucion { get; set; }
        public DateTime FechaDiligenciamiento { get; set; }
        public string ObjetivoGeneral { get; set; }
        public decimal AsignacionInicial { get; set; }
        public Nullable<decimal> TotalAdiciones { get; set; }
        public Nullable<decimal> TotalDisminucionesCentralizaciones { get; set; }
        public Nullable<decimal> TotalEjecutado { get; set; }
        public Nullable<decimal> PresupuestoFinal { get; set; }

        public CentroFormacion CentroFormacion { get; set; }
        public LineaProgramatica LineaProgramatica { get; set; }
        public RedConocimientoSectorial RedConocimientoSectorial { get; set; }
        public AreaConocimiento AreaConocimiento { get; set; }
        public Empleado Empleado { get; set; }
        public List<ObjetivoEspecifico> lstObjetivoEspecificos { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class Mantenimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMantenimiento { get; set; }
        public string Actividad { get; set; }
        public string NumeroReporte { get; set; }
        public string ClaseMantenimiento { get; set; }
        public string AceptacionOferta { get; set; }
        public string Observaciones { get; set; }

        public virtual Empleado Ejecutor { get; set; }
        public virtual Empleado Revisor { get; set; }
        public List<MantenimientoEquipo> lstMantenimientoEuipos { get; set; }

    }
}

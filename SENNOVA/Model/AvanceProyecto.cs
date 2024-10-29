using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class AvanceProyecto
    {
        public int Id { get; set; }
        public string Mes { get; set; }
        public decimal Proyectado { get; set; }
        public decimal Ejecutado { get; set; }
        public string Observaciones { get; set; }
        public decimal EjecutadoPresupuesto { get; set; }
        public decimal Adicion { get; set; }
        public decimal Disminucion { get; set; }
        public decimal Saldo { get; set; }
        public string ObservacionesPresupuestales { get; set; }

        public Actividad Actividad { get; set; }
    }
}

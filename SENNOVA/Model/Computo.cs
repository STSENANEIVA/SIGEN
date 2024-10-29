using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Computo
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public bool CuentaAdmin { get; set; }
        public bool Backup { get; set; }
        public string Procesador { get; set; }
        public string Ram { get; set; }
        public string Disco { get; set; }
        public string Observaciones { get; set; }

        public Equipo Equipo { get; set; }
        public Impresora Impresora { get; set; }
        public List<EquipoSoftware> lstEquipoSoftware { get; set; }
        public List<Computo> lstComputos { get; set; }
    }
}

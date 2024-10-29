using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class Equipo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Placa { get; set; }
        public string Serial { get; set; }
        public string Marca { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Valor { get; set; }
        public string NumeroContrato { get; set; }
        public DateTime FechaFuncionamiento { get; set; }

        public virtual Empleado Responsable { get; set; }
        public virtual AreaTecnica AreaTecnica { get; set; }
        public virtual TipoEquipo TipoEquipo { get; set; }
        public List<MantenimientoEquipo> lstMantenimientoEquipos { get; set; }
        public List<CalibracionEquipo> lstCalibracionEquipos { get; set; }
        public List<Computo> lstComputos { get; set; }
        public List<EquipoTecnico> lstEquipoTecnicos { get; set; }
        public List<EquipoAccesorio> lstEquipoAccesorios { get; set; }
        public List<EquipoSoftware> lstEquipoSoftware { get; set; }

    }
}

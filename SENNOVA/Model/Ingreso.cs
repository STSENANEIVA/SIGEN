using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Ingreso
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public bool PoliticaDatos { get; set; }
        public string Ficha { get; set; }

        public Visitante Visitante { get; set; }
        public Empresa Empresa { get; set; }
        public ProgramaFormacion ProgramaFormacion { get; set; }
        public Empleado Empleado { get; set; }
        public List<IngresosAreasTecnicas> lstIngresosAreasTecnicas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Empresa
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public SectorEconomico SectorEconomico { get; set; }

        public List<Ingreso> lstIngresos { get; set; }
    }
}

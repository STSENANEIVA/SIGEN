using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Actividad
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public ObjetivoEspecifico ObjetivoEspecifico { get; set; }

        public List<Producto> lstProductos { get; set; }
        public List<AvanceProyecto> lstAvanceProyectos { get; set; }
        
        
    }
}

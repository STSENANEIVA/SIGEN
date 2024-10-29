using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Empleado
    {
        public int Id { get; set; }
        public string EmailLaboral { get; set; }
        public string Telefono { get; set; }
        public string Ip { get; set; }
        public string NombreCompleto { get; set; }
        

        public virtual RolSennova RolSennova { get; set; }
        public Persona Persona { get; set; }
        public Cargo Cargo{ get; set; }
        public List<AreaTecnica> lstAreaTecnicas { get; set; }
        public List<Proyecto> Proyectos { get; set; }

    }
}

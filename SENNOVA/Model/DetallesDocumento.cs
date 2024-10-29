using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class DetallesDocumento
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string RutaDoc { get; set; }
        public bool Descargable { get; set; }
        public bool Fisico { get; set; }
        public bool Digital { get; set; }
        public string TipoSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaRevision { get; set; }
        public DateTime FechaAprovacion { get; set; }
        public string CopiaControlada { get; set; }
        public DateTime FechaCopiaControlada { get; set; }
        public bool Activo { get; set; }

        public Documento Documento { get; set; }
        public Empleado Solicitante { get; set; }
        public Empleado Revisor { get; set; }
        public Empleado Aprovador { get; set; }

    }
}

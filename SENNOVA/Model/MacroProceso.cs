using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model
{ 
    [Serializable]
    public class MacroProceso
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [AllowHtml]
        public string Icono { get; set; }
        public string Color { get; set; }
        public bool Activo { get; set; }

        public List<Proceso> lstProcesos { get; set; }

    }
}

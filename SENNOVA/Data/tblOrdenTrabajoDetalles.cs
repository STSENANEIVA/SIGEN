//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrdenTrabajoDetalles
    {
        public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public string CodigoItem { get; set; }
        public string Servicio { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFinal { get; set; }
        public string Observaciones { get; set; }
    
        public virtual tblOrdenTrabajo tblOrdenTrabajo { get; set; }
    }
}

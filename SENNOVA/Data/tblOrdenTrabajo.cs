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
    
    public partial class tblOrdenTrabajo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOrdenTrabajo()
        {
            this.lstOrdenTrabajoDetalles = new HashSet<tblOrdenTrabajoDetalles>();
        }
    
        public int Id { get; set; }
        public bool AutorizaIngreso { get; set; }
        public string NumeroOT { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public System.DateTime FechaLimite { get; set; }
        public System.DateTime FechaIngresoItem { get; set; }
        public string Observaciones { get; set; }
    
        public virtual tblAreaTecnica tblAreaTecnica { get; set; }
        public virtual tblCotizacion tblCotizacion { get; set; }
        public virtual tblEmpleado tblResponsable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrdenTrabajoDetalles> lstOrdenTrabajoDetalles { get; set; }
    }
}

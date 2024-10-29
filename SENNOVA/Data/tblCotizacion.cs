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
    
    public partial class tblCotizacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCotizacion()
        {
            this.lstTerminoCotizaciones = new HashSet<tblTerminoCotizacion>();
            this.lstCotizacionDetalles = new HashSet<tblCotizacionDetalle>();
            this.lstOrdenesTrabajos = new HashSet<tblOrdenTrabajo>();
        }
    
        public int Id { get; set; }
        public string Codigo { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<decimal> ValorTotal { get; set; }
        public string ValidezOferta { get; set; }
        public string NumeroFicha { get; set; }
        public string TipoCotizacion { get; set; }
        public string Observaciones { get; set; }
    
        public virtual tblProgramaFormacion tblProgramaFormacion { get; set; }
        public virtual tblEmpleado tblElaborador { get; set; }
        public virtual tblEmpleado tblAutorizador { get; set; }
        public virtual tblEmpleado tblRevisador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTerminoCotizacion> lstTerminoCotizaciones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCotizacionDetalle> lstCotizacionDetalles { get; set; }
        public virtual tblCliente tblCliente { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblOrdenTrabajo> lstOrdenesTrabajos { get; set; }
    }
}

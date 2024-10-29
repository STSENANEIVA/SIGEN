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
    
    public partial class tblMantenimiento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMantenimiento()
        {
            this.TipoMantenimiento = "(\'PREDICTIVO\',\'PREVENTIVO\',\'CORRECTIVO\')";
            this.lstMantenimientoEuipos = new HashSet<tblMantenimientoEquipo>();
        }
    
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public string TipoMantenimiento { get; set; }
        public string Actividad { get; set; }
        public string NumeroReporte { get; set; }
        public string ClaseMantenimiento { get; set; }
        public string AceptacionOferta { get; set; }
        public string Observaciones { get; set; }
    
        public virtual tblEmpleado Ejecutor { get; set; }
        public virtual tblEmpleado Revisor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMantenimientoEquipo> lstMantenimientoEuipos { get; set; }
    }
}

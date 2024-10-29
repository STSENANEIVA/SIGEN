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
    
    public partial class tblCalibracion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCalibracion()
        {
            this.TipoCalibracion = "(\'PREDICTIVO\',\'PREVENTIVO\',\'CORRECTIVO\')";
            this.TipoServicio = "(\'PREDICTIVO\',\'PREVENTIVO\',\'CORRECTIVO\')";
            this.lstCalibracionEquipos = new HashSet<tblCalibracionEquipo>();
        }
    
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public string TipoCalibracion { get; set; }
        public string TipoServicio { get; set; }
        public string NumeroCertificado { get; set; }
        public string Resultados { get; set; }
        public string Conforme { get; set; }
        public System.DateTime FechaProxima { get; set; }
        public string Observaciones { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCalibracionEquipo> lstCalibracionEquipos { get; set; }
    }
}

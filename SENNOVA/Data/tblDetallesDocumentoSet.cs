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
    
    public partial class tblDetallesDocumentoSet
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public string RutaDoc { get; set; }
        public bool Descargable { get; set; }
        public bool Fisico { get; set; }
        public bool Digital { get; set; }
        public string TipoSolicitud { get; set; }
        public System.DateTime FechaSolicitud { get; set; }
        public Nullable<System.DateTime> FechaRevision { get; set; }
        public Nullable<System.DateTime> FechaAprovacion { get; set; }
        public string CopiaControlada { get; set; }
        public Nullable<System.DateTime> FechaCopiaControlada { get; set; }
        public bool Activo { get; set; }
        public int tblDocumento_Id { get; set; }
        public Nullable<int> tblSolicitante_Id { get; set; }
        public Nullable<int> tblRevisor_Id { get; set; }
        public Nullable<int> tblAprovador_Id { get; set; }
    
        public virtual tblDocumento tblDocumento { get; set; }
        public virtual tblEmpleado tblEmpleado { get; set; }
        public virtual tblEmpleado tblEmpleado1 { get; set; }
        public virtual tblEmpleado tblEmpleado2 { get; set; }
    }
}
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
    
    public partial class tblProyectoRubro
    {
        public int Id { get; set; }
        public string Objeto { get; set; }
        public Nullable<decimal> Valor { get; set; }
    
        public virtual tblProyecto tblProyecto { get; set; }
        public virtual tblRubro tblRubro { get; set; }
    }
}

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
    
    public partial class tblEquipoTecnico
    {
        public int Id { get; set; }
        public string ClaseEquipo { get; set; }
        public string Caracteristicas { get; set; }
        public bool Aire { get; set; }
        public bool Electricidad { get; set; }
        public bool Gas { get; set; }
        public bool Aceite { get; set; }
        public bool Otros { get; set; }
        public string PresionAire { get; set; }
        public string Caudal { get; set; }
        public string Voltaje { get; set; }
        public string Amperaje { get; set; }
        public string Potencia { get; set; }
        public string TipoGas { get; set; }
        public string PresionGas { get; set; }
        public string TipoAceite { get; set; }
        public string Especifique { get; set; }
        public string Observaciones { get; set; }
    
        public virtual tblEquipo tblEquipo { get; set; }
        public virtual tblTipoPatron tblTipoPatron { get; set; }
    }
}

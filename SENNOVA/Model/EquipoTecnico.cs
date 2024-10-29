using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class EquipoTecnico
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

        public Equipo Equipo { get; set; }
        public TipoPatron TipoPatron { get; set; }

    }
}

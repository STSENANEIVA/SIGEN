using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Persona
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string NombreCompleto { get; set; }

        public TipoDocumento TipoDocumento { get; set; }
    }
}

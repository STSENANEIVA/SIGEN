using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Adjunto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoArchivo { get; set; }
        public decimal Tamaño { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class EquipoSoftware
    {
        public int Id { get; set; }

        public Software Software { get; set; }
        public Computo Computo { get; set; }

    }
}

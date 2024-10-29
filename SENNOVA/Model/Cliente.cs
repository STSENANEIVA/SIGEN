using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Cliente
    {
        public int Id { get; set; }
        public Persona Persona { get; set; }
    }
}

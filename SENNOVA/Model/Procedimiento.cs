﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class Procedimiento
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public Proceso Proceso { get; set; }
        public List<Documento> lstDocumentos { get; set; }

    }
}
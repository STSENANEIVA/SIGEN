﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{ 
    [Serializable]
    public class Documento
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }
        public DetallesDocumento DetallesDocumento { get; set; }

        public TiposDocumentos TiposDocumentos { get; set; }
        public Procedimiento Procedimiento { get; set; }
        public List<DetallesDocumento> lstDetallesDocumentos { get; set; }

    }
}

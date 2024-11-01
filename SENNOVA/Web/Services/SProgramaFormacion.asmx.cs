﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Logic;
using Model;

namespace Web.Services
{
    /// <summary>
    /// Descripción breve de SProgramaFormacion1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class SProgramaFormacion : System.Web.Services.WebService
    {

        public SProgramaFormacion()
        {
            //Uncomment the following line if using designed components
            //InitializeComponent();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetProgramasFormacion(string prefix)
        {
            List<string> ProgramasFormacion = new List<string>();
            LProgramaFormacion objLProgramaFormacion = new LProgramaFormacion();
            List<ProgramaFormacion> lstProgramasFormacion = objLProgramaFormacion.Consultar();

            var listaFiltrada = lstProgramasFormacion.Where(o => o.Nombre.ToUpper().Contains(prefix.ToUpper()));

            foreach (var item in listaFiltrada)
            {
                string nombreCompuesto = item.Codigo + " - " + item.Nombre.Replace(',', '.');
                ProgramasFormacion.Add(string.Format("{0},{1}", nombreCompuesto.ToUpper(), item.Id));
            }

            return ProgramasFormacion.ToArray();

        }
    }
}

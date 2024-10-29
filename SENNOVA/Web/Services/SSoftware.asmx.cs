using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using Model;
using Logic;

namespace Web.Services
{
    /// <summary>
    /// Descripción breve de SSoftware
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class SSoftware : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetSoftware(string prefix)
        {
            List<string> Software = new List<string>();
            LSoftware objLSoftware = new LSoftware();
            List<Software> lstSoftware = objLSoftware.Consultar();

            var listaFiltrada = lstSoftware.Where(o => o.Nombre.ToUpper().Contains(prefix.ToUpper()));

            foreach (var item in listaFiltrada)
            {
                string nombreCompuesto = item.Codigo + " - " + item.Nombre.Replace(',', '.');
                Software.Add(string.Format("{0},{1}", nombreCompuesto.ToUpper(), item.Id));
            }

            return Software.ToArray();

        }
    }
}

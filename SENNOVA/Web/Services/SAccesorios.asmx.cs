using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using Logic;
using System.Web.Script.Services;

namespace Web.Services
{
    /// <summary>
    /// Descripción breve de SAccesorios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class SAccesorios : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetAccesorios(string prefix)
        {
            List<string> Accesorios = new List<string>();
            LAccesorios objLAccesorios = new LAccesorios();
            List<Accesorios> lstAccesorios = objLAccesorios.Consultar();

            var listaFiltrada = lstAccesorios.Where(o => o.Nombre.ToUpper().Contains(prefix.ToUpper()));

            foreach (var item in listaFiltrada)
            {
                string nombreCompuesto = item.Codigo + " - " + item.Nombre.Replace(',', '.');
                Accesorios.Add(string.Format("{0},{1}", nombreCompuesto.ToUpper(), item.Id));
            }

            return Accesorios.ToArray();

        }
    }
}

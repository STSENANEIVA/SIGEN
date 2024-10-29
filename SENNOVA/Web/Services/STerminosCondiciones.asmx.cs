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
    /// Descripción breve de STerminosCondiciones
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class STerminosCondiciones : System.Web.Services.WebService
    {
        public STerminosCondiciones()
        {
            //Uncomment the following line if using designed components
            //InitializeComponent();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetTerminosCondiciones(string prefix)
        {
            List<string> TerminosCondiciones = new List<string>();
            LTerminoCondicion objLTerminoCondicion = new LTerminoCondicion();
            List<TerminoCondicion> lstTerminosCondiciones = objLTerminoCondicion.Consultar();

            var listaFiltrada = lstTerminosCondiciones.Where(o => o.Nombre.ToUpper().Contains(prefix.ToUpper()));

            foreach (var item in listaFiltrada)
            {
                string nombreCompuesto = item.Codigo + " - " + item.Nombre.Replace(',', '.');
                TerminosCondiciones.Add(string.Format("{0},{1}", nombreCompuesto.ToUpper(), item.Id));
            }

            return TerminosCondiciones.ToArray();

        }
    }
}

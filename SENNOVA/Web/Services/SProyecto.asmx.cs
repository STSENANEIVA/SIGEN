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
    /// Descripción breve de SProyecto
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class SProyecto : System.Web.Services.WebService
    {
        public SProyecto()
        {
            //Uncomment the following line if using designed components
            //InitializeComponent();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetProyectos(string prefix)
        {
            List<string> Proyectos = new List<string>();
            LProyecto objLProyecto = new LProyecto();
            List<Proyecto> lstProyectos = objLProyecto.Consultar();

            var listaFiltrada = lstProyectos.Where(o => o.TituloProyecto.ToUpper().Contains(prefix.ToUpper()));

            foreach (var item in listaFiltrada)
            {
                string nombreCompuesto = item.CodigoSGPS + " - " + item.TituloProyecto.Replace(',', '.');
                Proyectos.Add(string.Format("{0},{1}", item.TituloProyecto, item.Id));
            }

            return Proyectos.ToArray();

        }

    }
}

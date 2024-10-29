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
    /// Descripción breve de SLineaProgramatica
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    
    public class SLineaProgramatica : System.Web.Services.WebService
    {

        public SLineaProgramatica()
        {
            //Uncomment the following line if using designed components
            //InitializeComponent();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetLineasProgramaticas(string prefix)
        {
            List<string> LineasProgramaticas = new List<string>();
            LLineaProgramatica objLLineaProgramatica = new LLineaProgramatica();
            List<LineaProgramatica> lstLineasProgramaticas = objLLineaProgramatica.Consultar();

            var listaFiltrada = lstLineasProgramaticas.Where(o => o.Nombre.ToUpper().Contains(prefix.ToUpper()));

            foreach (var item in listaFiltrada)
            {
                string nombreCompuesto = item.Codigo + " - " + item.Nombre.Replace(',', '.');
                LineasProgramaticas.Add(string.Format("{0},{1}", nombreCompuesto.ToUpper(), item.Id));
            }

            return LineasProgramaticas.ToArray();

        }
    }
}

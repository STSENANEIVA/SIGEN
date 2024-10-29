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
    /// Descripción breve de SServicios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
     [System.Web.Script.Services.ScriptService]

    public class SServicios : System.Web.Services.WebService
    {

        public SServicios()
        {
            //Uncomment the following line if using designed components
            //InitializeComponent();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

        public string[] GetServicios(string prefix)
       {
            List<string> Servicios = new List<string>();
            LServicio objLServicio = new LServicio();
            List<Servicio> lstServicios = objLServicio.Consultar();

            var listaFiltrada = lstServicios.Where(o => o.Nombre.ToUpper().Contains(prefix.ToUpper()));

            foreach (var item in listaFiltrada)
            {
                string nombreCompuesto = item.Codigo + " - " + item.Nombre.Replace(',', '.');
                Servicios.Add(string.Format("{0},{1}", nombreCompuesto.ToUpper(), item.Id));
            }

            return Servicios.ToArray();

        }
        public string[] GetServiciosAreaTecnica(string prefix, string idAreaTecnica)
        {
            List<string> Servicios = new List<string>();
            LServicio objLServicio = new LServicio();
            List<Servicio> lstServicios = objLServicio.ConsultarAreaTecnicaId(int.Parse(idAreaTecnica));

            var listaFiltrada = lstServicios.Where(o => o.Nombre.ToUpper().Contains(prefix.ToUpper()));

            foreach (var item in listaFiltrada)
            {
                string nombreCompuesto = item.Codigo + " - " + item.Nombre.Replace(',', '.');
                Servicios.Add(string.Format("{0},{1}", nombreCompuesto.ToUpper(), item.Id));
            }

            return Servicios.ToArray();

        }
    }
}

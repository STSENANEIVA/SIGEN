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
    /// Descripción breve de SPersona
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    
    public class SPersona : System.Web.Services.WebService
    {

        public SPersona()
        {
            //Uncomment the following line if using designed components
            //InitializeComponent();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] GetPersonas(string prefix)
        {
            List<string> Personas = new List<string>();
            LPersona objLPersona = new LPersona();
            List<Persona> lstPersonas = objLPersona.Consultar();

            var listaFiltrada = lstPersonas.Where(o => o.Nombres.ToUpper().Contains(prefix.ToUpper()) || o.Apellidos.ToUpper().Contains(prefix.ToUpper()));

            foreach (var item in listaFiltrada)
            {
                string nombreCompuesto = item.NumeroIdentificacion + " - " + item.Nombres + " " + item.Apellidos;
                Personas.Add(string.Format("{0},{1}", nombreCompuesto.ToUpper(), item.Id));
            }

            return Personas.ToArray();

        }
    }
}

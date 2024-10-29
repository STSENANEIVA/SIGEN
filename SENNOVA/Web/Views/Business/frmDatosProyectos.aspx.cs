using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Logic;
using Microsoft.Ajax.Utilities;

namespace Web.Views.Business
{
    public partial class frmDatosProyectos : System.Web.UI.Page
    {

        LEmpleado objLEmpleado = new LEmpleado();
        LProyecto objLProyecto = new LProyecto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string email = HttpContext.Current.User.Identity.Name;
                Empleado objEmpleado = objLEmpleado.ConsultarEmail(email);
                List<Proyecto> lstProyectos = new List<Proyecto>();
                lstProyectos = objLProyecto.ConsultarEmpleado(objEmpleado.Id);
                if (lstProyectos.Count != 0)
                {
                    CargarGrillaProyecto(lstProyectos);
                }
            }
        }

        private void CargarGrillaProyecto(List<Proyecto> lstProyectos)
        {
            Session["ProyectosCompletos"] = lstProyectos;
            Session["ProyectosFiltrados"] = lstProyectos;
            grdProyecto.DataSource = lstProyectos;
            grdProyecto.DataBind();
            if (grdProyecto.HeaderRow != null)
            {
                grdProyecto.UseAccessibleHeader = true;
                grdProyecto.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string tituloProyecto = txtProyecto.Text;
                if (!tituloProyecto.IsNullOrWhiteSpace())
                {
                    List<Proyecto> lstProyectos = new List<Proyecto>();
                    lstProyectos = objLProyecto.Consultar(tituloProyecto);
                    if (lstProyectos.Count != 0)
                    {
                        CargarGrillaProyecto(lstProyectos);
                        ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    }
                    else
                    {
                        grdProyecto.DataBind();
                    }
                }
                else
                {
                    string message = "Escriba el titulo de proyecto para buscar";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                }
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkDetalles_Click(object sender, EventArgs e)
        {
            string idProyecto = (sender as LinkButton).CommandArgument;
            Response.Redirect("frmProyecto.aspx?idProyecto=" + idProyecto);
        }
    }
}
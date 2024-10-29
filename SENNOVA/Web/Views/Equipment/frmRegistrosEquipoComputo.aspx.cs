using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Model;
using Utilities;


namespace Web.Views.Equipment
{
    public partial class frmRegistrosEquipoComputo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarControles();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Equipment/frmEquipoComputo.aspx");
        }

        private void CargarControles()
        {
            CargarGrillaEquipoComputo();
        }

        private void CargarGrillaEquipoComputo()
        {
            try
            {
                LEquipo objLEquipo = new LEquipo();
                List<Equipo> lstEquipo = objLEquipo.Consultar();
                Session["EquipoCompletos"] = lstEquipo;
                Session["EquipoFiltrados"] = lstEquipo;

                grdEquiposComputo.DataSource = lstEquipo;
                grdEquiposComputo.DataBind();

                if (grdEquiposComputo.HeaderRow != null)
                {
                    grdEquiposComputo.UseAccessibleHeader = true;
                    grdEquiposComputo.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void lnkEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string idEquipoTecnico = (sender as LinkButton).CommandArgument;
                Response.Redirect("frmEquipoComputo.aspx?idEquipoTecnico=" + idEquipoTecnico);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
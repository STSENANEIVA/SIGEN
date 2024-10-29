using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Model;
using Utilities;

namespace Web.Views.Configurations
{
    public partial class frmRegistrosOrdenTrabajo : System.Web.UI.Page
    {
        List<OrdenTrabajo> lstOrdenTrabajo;
        List<OrdenTrabajoDetalle> lstOrdenTrabajoDetalle = new List<OrdenTrabajoDetalle>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarControles();
                grdDetalleOrdenTrabajo.DataBind();
            }
        }

        private void CargarControles()
        {
            CargarGrillaOrdenesTrabajo();
        }

        private void CargarGrillaOrdenesTrabajo()
        {
            try
            {
                LOrdenTrabajo objLOrdenTrabajo = new LOrdenTrabajo();
                List<OrdenTrabajo> lstOrdenTrabajo = objLOrdenTrabajo.Consultar();
                Session["OrdenesTrabajoCompletos"] = lstOrdenTrabajo;
                Session["OrdenesTrabajoFiltrados"] = lstOrdenTrabajo;
                grdOrdenesTrabajo.DataSource = lstOrdenTrabajo;
                grdOrdenesTrabajo.DataBind();

                if (grdOrdenesTrabajo.HeaderRow != null)
                {
                    grdOrdenesTrabajo.UseAccessibleHeader = true;
                    grdOrdenesTrabajo.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        }


        protected void btnBuscarFiltroSuperior_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFechaFinal.Text) && !String.IsNullOrEmpty(txtFechaInicial.Text))
            {
                try
                {
                    DateTime fechaIncialFormat = Convert.ToDateTime(txtFechaInicial.Text);
                    DateTime fechaFinalFormat = Convert.ToDateTime(txtFechaFinal.Text);
                    bool camposValidados = ValidarCampos(fechaIncialFormat, fechaFinalFormat);
                    CargarOrdenesTrabajoCompletas();
                    if (camposValidados)
                    {
                        List<OrdenTrabajo> lstOrdenTrabajo = Session["OrdenesTrabajoCompletos"] as List<OrdenTrabajo>;

                        lstOrdenTrabajo = (from s in lstOrdenTrabajo
                                           where s.FechaEmision >= fechaIncialFormat && s.FechaLimite <= fechaFinalFormat
                                           select s).ToList();


                        Session["OrdenesTrabajoFiltrados"] = lstOrdenTrabajo;

                        grdOrdenesTrabajo.DataSource = lstOrdenTrabajo;
                        grdOrdenesTrabajo.DataBind();
                        if (grdOrdenesTrabajo.HeaderRow != null)
                        {
                            grdOrdenesTrabajo.UseAccessibleHeader = true;
                            grdOrdenesTrabajo.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    }
                    else
                    {
                        throw new ApplicationException(Message.CamposObligatorios);
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
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "warningalert();", true);
                CargarGrillaOrdenesTrabajo();
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            }
        }

        private bool ValidarCampos(DateTime fechaIncial, DateTime fechaFinal)
        {
            bool validado = true;
            if (string.IsNullOrEmpty(fechaIncial.ToString()))
            {
                validado = false;
            }
            if (string.IsNullOrEmpty(fechaFinal.ToString()))
            {
                validado = false;
            }
            return validado;
        }

        private void CargarOrdenesTrabajoCompletas()
        {
            try
            {
                LOrdenTrabajo objLOrdenTrabajo = new LOrdenTrabajo();
                lstOrdenTrabajo = objLOrdenTrabajo.Consultar();
                Session["OrdenesTrabajoCompletos"] = lstOrdenTrabajo;
                Session["OrdenesTrabajoFiltrados"] = lstOrdenTrabajo;
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
        }

        protected void lnkCerrarModal(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Operational/frmRegistrosOrdenTrabajo.aspx");
        }

        protected void lnkDetalles(object sender, EventArgs e)
        {
            try
            {

                string idOrdenTrabajo = (sender as LinkButton).CommandArgument;
                CargarGrillaOrdenTrabajoDetale(idOrdenTrabajo);
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaOrdenesTrabajo();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void CargarGrillaOrdenTrabajoDetale(string idOrdenTrabajo)
        {
            LOrdenTrabajo objLOrdenTrabajo = new LOrdenTrabajo();
            OrdenTrabajo OrdenTrabajo = objLOrdenTrabajo.Consultar(int.Parse(idOrdenTrabajo));

            LOrdenTrabajoDetalle objLOrdenTrabajoDetalle = new LOrdenTrabajoDetalle();
            lstOrdenTrabajoDetalle = objLOrdenTrabajoDetalle.ConsultarPorOrdenTrabajo(OrdenTrabajo.Id);

            grdDetalleOrdenTrabajo.DataSource = lstOrdenTrabajoDetalle;
            grdDetalleOrdenTrabajo.DataBind();

            if (grdDetalleOrdenTrabajo.HeaderRow != null)
            {
                grdDetalleOrdenTrabajo.UseAccessibleHeader = true;
                grdDetalleOrdenTrabajo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            CargarGrillaOrdenesTrabajo();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTableDetalles();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalDetalleOrdenTrabajo", "$('#modalDetalleOrdenTrabajo').modal('show');", true);
        }
    }

}
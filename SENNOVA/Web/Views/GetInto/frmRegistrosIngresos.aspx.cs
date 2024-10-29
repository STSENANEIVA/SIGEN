using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Model;
using Utilities;

namespace Web.Views.GetInto
{
    public partial class frmRegistrosIngresos : System.Web.UI.Page
    {

        List<Ingreso> lstIngresos;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarControles();
            }
        }

        private void CargarControles()
        {
            CargarGrillaIngresos();
        }

        private void CargarGrillaIngresos()
        {
            try
            {
                LIngreso objLIngresos = new LIngreso();
                List<Ingreso> lstIngresos = objLIngresos.Consultar();
                Session["IngresosCompletos"] = lstIngresos;
                Session["IngresosFiltrados"] = lstIngresos;
                grdIngresos.DataSource = lstIngresos;
                grdIngresos.DataBind();

                if (grdIngresos.HeaderRow != null)
                {
                    grdIngresos.UseAccessibleHeader = true;
                    grdIngresos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grdIngresos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow row in grdIngresos.Rows)
                {
                    CheckBoxList chklAreasTecnicas = ((CheckBoxList)row.FindControl("chklAreasTecnicas"));
                    List<Ingreso> lstIngresos = Session["IngresosFiltrados"] as List<Ingreso>;
                    string idIngreso = row.Cells[0].Text.Trim();
                    Ingreso ingreso = lstIngresos.Find(i => i.Id == int.Parse(idIngreso));
                    List<AreaTecnica> lstAreaTecnicas = new List<AreaTecnica>();
                    foreach (var item in ingreso.lstIngresosAreasTecnicas)
                    {
                        lstAreaTecnicas.Add(item.AreaTecnica);
                    }
                    chklAreasTecnicas.DataSource = lstAreaTecnicas;
                    chklAreasTecnicas.DataTextField = "Nombre";
                    chklAreasTecnicas.DataValueField = "Id";
                    chklAreasTecnicas.Enabled = false;
                    chklAreasTecnicas.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }   

        private void CargarGrillaIngresos(List<Ingreso> lstIngresos)
        {
            try
            {
                Session["IngresosCompletos"] = lstIngresos;
                Session["IngresosFiltrados"] = lstIngresos;
                grdIngresos.DataSource = lstIngresos;
                grdIngresos.DataBind();
                if (grdIngresos.HeaderRow != null)
                {
                    grdIngresos.UseAccessibleHeader = true;
                    grdIngresos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the pager row.
            GridViewRow pagerRow = grdIngresos.BottomPagerRow;

            // Retrieve the PageDropDownList DropDownList from the bottom pager row.
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            // Set the PageIndex property to display that page selected by the user.
            grdIngresos.PageIndex = pageList.SelectedIndex;
            grdIngresos.DataSource = Session["IngresosFiltrados"];
            grdIngresos.DataBind();
        }


        protected void btnBuscarFiltroSuperior_Click(object sender, EventArgs e)
        {
            try
            {

                string fechaIncialFormat = txtFechaInicial.Text;
                string fechaFinalFormat = txtFechaFinal.Text;
                bool camposValidados = ValidarCampos(fechaIncialFormat, fechaFinalFormat);
                CargarIngresosCompletas();
                if (camposValidados == true)
                {
                    List<Ingreso> lstIngresos = Session["IngresosCompletos"] as List<Ingreso>;

                    lstIngresos = (from s in lstIngresos
                                   where s.Fecha >= Convert.ToDateTime(fechaIncialFormat) && s.Fecha <= Convert.ToDateTime(fechaFinalFormat)
                                   select s).ToList();


                    Session["IngresosFiltrados"] = lstIngresos;
                    grdIngresos.DataSource = lstIngresos;
                    grdIngresos.DataBind();
                    if (grdIngresos.HeaderRow != null)
                    {
                        grdIngresos.UseAccessibleHeader = true;
                        grdIngresos.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.FechaDiligenciamiento}');", true);
                }
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }

        }

        private bool ValidarCampos(string fechaIncial, string fechaFinal)
        {
            bool validado = true;
            if (string.IsNullOrEmpty(fechaIncial))
            {
                validado = false;
            }
            if (string.IsNullOrEmpty(fechaFinal))
            {
                validado = false;
            }
            return validado;
        }

        private void CargarIngresosCompletas()
        {
            try
            {
                LIngreso objLIngreso = new LIngreso();
                lstIngresos = objLIngreso.Consultar();
                Session["IngresosCompletos"] = lstIngresos;
                Session["IngresosFiltrados"] = lstIngresos;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
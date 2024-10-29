using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Logic;
using Utilities;

namespace Web.Views.Configurations
{
    public partial class frmProceso : System.Web.UI.Page
    {
        LProceso objLProceso = new LProceso();
        LMacroProceso objLMacroProceso = new LMacroProceso();
        List<Proceso> lstProcesos;
        string camposFaltantes = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarControles();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Configurations/frmProceso.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Proceso
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;
                int idMacroProceso = int.Parse(ddlMacroProceso.SelectedValue);


                //validar el Proceso
                bool Procesovalidado = ValidarCamposProceso(codigo, nombre, idMacroProceso);

                if (!Procesovalidado)
                {
                    CargarGrillaProceso();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Proceso y retorno el numero
                int idProceso = GuardarProceso(codigo, nombre, activo, idMacroProceso);
                txtIdProceso.Text = idProceso.ToString();
                PantallaGuardado();
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaProceso();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarProceso(string codigo, string nombre, bool activo, int idMacroProceso)
        {
            LProceso objLProceso = new LProceso();
            Proceso objProceso = new Proceso();
            string id = txtIdProceso.Text.Trim();
            int idProceso;
            if (string.IsNullOrEmpty(id))
            {
                objProceso = objLProceso.Guardar(codigo, nombre, idMacroProceso);
            }
            else
            {
                idProceso = Int32.Parse(id);
                objProceso = objLProceso.Actualizar(idProceso, codigo, nombre, activo, idMacroProceso);
            }
            return objProceso.Id;
        }

        private bool ValidarCamposProceso(string codigo, string nombre, int idMacroProceso)
        {
            bool resultado = true;

            if (String.IsNullOrEmpty(codigo))
            {
                camposFaltantes = camposFaltantes + ", " + "codigo";
                resultado = false;
            }
            if (String.IsNullOrEmpty(nombre))
            {
                camposFaltantes = camposFaltantes + ", " + "nombre";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idMacroProceso.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "MacroProceso";
                resultado = false;
            }
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdProceso.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaProceso();
            CargarMacroProcesoes();
        }

        private void CargarMacroProcesoes()
        {

            objLMacroProceso = new LMacroProceso();
            ddlMacroProceso.DataSource = objLMacroProceso.Consultar();
            ddlMacroProceso.DataTextField = "Nombre";
            ddlMacroProceso.DataValueField = "id";
            ddlMacroProceso.DataBind();
            ddlMacroProceso.Items.Add(new ListItem("Seleccione", "0"));
            ddlMacroProceso.SelectedValue = "0";
        }

        private void CargarGrillaProceso()
        {
            objLProceso = new LProceso();
            lstProcesos = objLProceso.Consultar();
            Session["ProcesosCompletos"] = lstProcesos;
            Session["ProcesosFiltrados"] = lstProcesos;
            grdProceso.DataSource = lstProcesos;
            grdProceso.DataBind();
            if (grdProceso.HeaderRow != null)
            {
                grdProceso.UseAccessibleHeader = true;
                grdProceso.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaProceso();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaProceso();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdProceso.Text = grdProceso.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdProceso.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdProceso.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdProceso.SelectedRow.Cells[4].Controls[0] as CheckBox;
                if (chk.Checked)
                {
                    chkActivo.Checked = true;
                }
                else
                {
                    chkActivo.Checked = false;
                }
                string region = HttpUtility.HtmlDecode(grdProceso.SelectedRow.Cells[3].Text.Trim());
                ddlMacroProceso.ClearSelection();
                ddlMacroProceso.SelectedValue = ddlMacroProceso.Items.FindByText(region).Value;

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaProceso();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idProceso = (sender as LinkButton).CommandArgument;
            CargarGrillaProceso();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idProceso}');", true);
        }
    }
}
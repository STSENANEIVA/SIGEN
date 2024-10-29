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
    public partial class frmProcedimiento : System.Web.UI.Page
    {
        LProcedimiento objLProcedimiento = new LProcedimiento();
        LProceso objLProceso = new LProceso();
        List<Procedimiento> lstProcedimientos;
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
            Response.Redirect("~/Views/Configurations/frmProcedimiento.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Procedimiento
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;
                int idProceso = int.Parse(ddlProceso.SelectedValue);


                //validar el Procedimiento
                bool Procedimientovalidado = ValidarCamposProcedimiento(codigo, nombre, idProceso);

                if (!Procedimientovalidado)
                {
                    CargarGrillaProcedimiento();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Procedimiento y retorno el numero
                int idProcedimiento = GuardarProcedimiento(codigo, nombre, activo, idProceso);
                txtIdProcedimiento.Text = idProcedimiento.ToString();
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
            CargarGrillaProcedimiento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarProcedimiento(string codigo, string nombre, bool activo, int idProceso)
        {
            LProcedimiento objLProcedimiento = new LProcedimiento();
            Procedimiento objProcedimiento = new Procedimiento();
            string id = txtIdProcedimiento.Text.Trim();
            int idProcedimiento;
            if (string.IsNullOrEmpty(id))
            {
                objProcedimiento = objLProcedimiento.Guardar(codigo, nombre, idProceso);
            }
            else
            {
                idProcedimiento = Int32.Parse(id);
                objProcedimiento = objLProcedimiento.Actualizar(idProcedimiento, codigo, nombre, activo, idProceso);
            }
            return objProcedimiento.Id;
        }

        private bool ValidarCamposProcedimiento(string codigo, string nombre, int idProceso)
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
            if (String.IsNullOrEmpty(idProceso.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Proceso";
                resultado = false;
            }
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdProcedimiento.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaProcedimiento();
            CargarProcesoes();
        }

        private void CargarProcesoes()
        {

            objLProceso = new LProceso();
            ddlProceso.DataSource = objLProceso.Consultar();
            ddlProceso.DataTextField = "Nombre";
            ddlProceso.DataValueField = "id";
            ddlProceso.DataBind();
            ddlProceso.Items.Add(new ListItem("Seleccione", "0"));
            ddlProceso.SelectedValue = "0";
        }

        private void CargarGrillaProcedimiento()
        {
            objLProcedimiento = new LProcedimiento();
            lstProcedimientos = objLProcedimiento.Consultar();
            Session["ProcedimientosCompletos"] = lstProcedimientos;
            Session["ProcedimientosFiltrados"] = lstProcedimientos;
            grdProcedimiento.DataSource = lstProcedimientos;
            grdProcedimiento.DataBind();
            if (grdProcedimiento.HeaderRow != null)
            {
                grdProcedimiento.UseAccessibleHeader = true;
                grdProcedimiento.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaProcedimiento();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaProcedimiento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdProcedimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdProcedimiento.Text = grdProcedimiento.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdProcedimiento.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdProcedimiento.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdProcedimiento.SelectedRow.Cells[4].Controls[0] as CheckBox;
                if (chk.Checked)
                {
                    chkActivo.Checked = true;
                }
                else
                {
                    chkActivo.Checked = false;
                }
                string region = HttpUtility.HtmlDecode(grdProcedimiento.SelectedRow.Cells[3].Text.Trim());
                ddlProceso.ClearSelection();
                ddlProceso.SelectedValue = ddlProceso.Items.FindByText(region).Value;

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaProcedimiento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idProcedimiento = (sender as LinkButton).CommandArgument;
            CargarGrillaProcedimiento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idProcedimiento}');", true);
        }
    }
}
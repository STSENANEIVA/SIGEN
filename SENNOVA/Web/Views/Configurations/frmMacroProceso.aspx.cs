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
    public partial class frmMacroProceso : System.Web.UI.Page
    {
        LMacroProceso objLMacroProceso = new LMacroProceso();
        LProceso objLProceso = new LProceso();
        List<MacroProceso> lstMacroProcesos;
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
            Response.Redirect("~/Views/Configurations/frmMacroProceso.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del MacroProceso
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;
                string color = txtColor.Text;
                string icono = txtIcono.Text.Trim();

                //validar el MacroProceso
                bool MacroProcesovalidado = ValidarCamposMacroProceso(codigo, nombre);

                if (!MacroProcesovalidado)
                {
                    CargarGrillaMacroProceso();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el MacroProceso y retorno el numero
                int idMacroProceso = GuardarMacroProceso(codigo, nombre, activo, color, icono);
                txtIdMacroProceso.Text = idMacroProceso.ToString();
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
            CargarGrillaMacroProceso();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarMacroProceso(string codigo, string nombre, bool activo, string color, string icono)
        {
            LMacroProceso objLMacroProceso = new LMacroProceso();
            MacroProceso objMacroProceso = new MacroProceso();
            string id = txtIdMacroProceso.Text.Trim();
            int idMacroProceso;
            if (string.IsNullOrEmpty(id))
            {
                objMacroProceso = objLMacroProceso.Guardar(codigo, nombre, color, icono);
            }
            else
            {
                idMacroProceso = Int32.Parse(id);
                objMacroProceso = objLMacroProceso.Actualizar(idMacroProceso, codigo, nombre, activo, color, icono);
            }
            return objMacroProceso.Id;
        }

        private bool ValidarCamposMacroProceso(string codigo, string nombre)
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
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdMacroProceso.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaMacroProceso();
        }

        private void CargarGrillaMacroProceso()
        {
            objLMacroProceso = new LMacroProceso();
            lstMacroProcesos = objLMacroProceso.Consultar();
            Session["MacroProcesosCompletos"] = lstMacroProcesos;
            Session["MacroProcesosFiltrados"] = lstMacroProcesos;
            grdMacroProceso.DataSource = lstMacroProcesos;
            grdMacroProceso.DataBind();
            if (grdMacroProceso.HeaderRow != null)
            {
                grdMacroProceso.UseAccessibleHeader = true;
                grdMacroProceso.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaMacroProceso();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaMacroProceso();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdMacroProceso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdMacroProceso.Text = grdMacroProceso.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdMacroProceso.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdMacroProceso.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdMacroProceso.SelectedRow.Cells[3].Controls[0] as CheckBox;
                if (chk.Checked)
                {
                    chkActivo.Checked = true;
                }
                else
                {
                    chkActivo.Checked = false;
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
            CargarGrillaMacroProceso();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idMacroProceso = (sender as LinkButton).CommandArgument;
            CargarGrillaMacroProceso();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idMacroProceso}');", true);
        }
    }
}
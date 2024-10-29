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
    public partial class frmSoftware : System.Web.UI.Page
    {
        LSoftware objLSoftware = new LSoftware();
        LTipoLicencia objLTipoLicencia = new LTipoLicencia();
        List<Software> lstSoftwares;
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
            Response.Redirect("~/Views/Configurations/frmSoftware.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Software
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string version = txtVersion.Text.Trim();
                bool activo = chkActivo.Checked;
                int idTipoLicencia = int.Parse(ddlTipoLicencia.SelectedValue);


                //validar el Software
                bool Softwarevalidado = ValidarCamposSoftware(codigo, nombre, version, idTipoLicencia);

                if (!Softwarevalidado)
                {
                    CargarGrillaSoftware();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Software y retorno el numero
                int idSoftware = GuardarSoftware(codigo, nombre, version, activo, idTipoLicencia);
                txtIdSoftware.Text = idSoftware.ToString();
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
            CargarGrillaSoftware();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarSoftware(string codigo, string nombre, string version, bool activo, int idTipoLicencia)
        {
            LSoftware objLSoftware = new LSoftware();
            Software objSoftware = new Software();
            string id = txtIdSoftware.Text.Trim();
            int idSoftware;
            if (string.IsNullOrEmpty(id))
            {
                objSoftware = objLSoftware.Guardar(codigo, nombre, version, idTipoLicencia);
            }
            else
            {
                idSoftware = Int32.Parse(id);
                objSoftware = objLSoftware.Actualizar(idSoftware, codigo, nombre, version, activo, idTipoLicencia);
            }
            return objSoftware.Id;
        }

        private bool ValidarCamposSoftware(string codigo, string nombre, string version, int idTipoLicencia)
        {
            bool resultado = true;

            if (String.IsNullOrEmpty(codigo))
            {
                camposFaltantes = camposFaltantes + ", " + "codigo";
                resultado = false;
            }
            if (String.IsNullOrEmpty(version))
            {
                camposFaltantes = camposFaltantes + ", " + "version";
                resultado = false;
            }
            if (String.IsNullOrEmpty(nombre))
            {
                camposFaltantes = camposFaltantes + ", " + "nombre";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idTipoLicencia.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "TipoLicencia";
                resultado = false;
            }
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdSoftware.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaSoftware();
            CargarTipoLicenciaes();
        }

        private void CargarTipoLicenciaes()
        {

            objLTipoLicencia = new LTipoLicencia();
            ddlTipoLicencia.DataSource = objLTipoLicencia.Consultar();
            ddlTipoLicencia.DataTextField = "Nombre";
            ddlTipoLicencia.DataValueField = "id";
            ddlTipoLicencia.DataBind();
            ddlTipoLicencia.Items.Add(new ListItem("Seleccione", "0"));
            ddlTipoLicencia.SelectedValue = "0";
        }

        private void CargarGrillaSoftware()
        {
            objLSoftware = new LSoftware();
            lstSoftwares = objLSoftware.Consultar();
            Session["SoftwaresCompletos"] = lstSoftwares;
            Session["SoftwaresFiltrados"] = lstSoftwares;
            grdSoftware.DataSource = lstSoftwares;
            grdSoftware.DataBind();

            if (grdSoftware.HeaderRow != null)
            {
                grdSoftware.UseAccessibleHeader = true;
                grdSoftware.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaSoftware();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaSoftware();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdSoftware.Text = grdSoftware.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdSoftware.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdSoftware.SelectedRow.Cells[2].Text).Trim();
                txtVersion.Text = HttpUtility.HtmlDecode(grdSoftware.SelectedRow.Cells[3].Text).Trim();
                string tipoLicencia = HttpUtility.HtmlDecode(grdSoftware.SelectedRow.Cells[4].Text).Trim();
                ddlTipoLicencia.ClearSelection();
                ddlTipoLicencia.SelectedValue = ddlTipoLicencia.Items.FindByText(tipoLicencia).Value;
                CheckBox chk = grdSoftware.SelectedRow.Cells[5].Controls[0] as CheckBox;
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
            CargarGrillaSoftware();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idSoftware = (sender as LinkButton).CommandArgument;
            CargarGrillaSoftware();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idSoftware}');", true);
            
        }
    }
}
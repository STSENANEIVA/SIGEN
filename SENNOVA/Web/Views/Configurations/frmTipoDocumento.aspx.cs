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
    public partial class frmTipoDocumento : System.Web.UI.Page
    {
        LTipoDocumento objLTipoDocumento = new LTipoDocumento();
        List<TipoDocumento> lstTipoDocumentos;
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
            Response.Redirect("~/Views/Configurations/frmTipoDocumento.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del TipoDocumento
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el TipoDocumento
                bool TipoDocumentovalidado = ValidarCamposTipoDocumento(codigo, nombre);

                if (!TipoDocumentovalidado)
                {
                    CargarGrillaTipoDocumento();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el TipoDocumento y retorno el numero
                int idTipoDocumento = GuardarTipoDocumento(codigo, nombre, activo);
                txtIdTipoDocumento.Text = idTipoDocumento.ToString();
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
            CargarGrillaTipoDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarTipoDocumento(string codigo, string nombre, bool activo)
        {
            LTipoDocumento objLTipoDocumento = new LTipoDocumento();
            TipoDocumento objTipoDocumento = new TipoDocumento();
            string id = txtIdTipoDocumento.Text.Trim();
            int idTipoDocumento;
            if (string.IsNullOrEmpty(id))
            {
                objTipoDocumento = objLTipoDocumento.Guardar(codigo, nombre);
            }
            else
            {
                idTipoDocumento = Int32.Parse(id);
                objTipoDocumento = objLTipoDocumento.Actualizar(idTipoDocumento, codigo, nombre, activo);
            }
            return objTipoDocumento.Id;
        }

        private bool ValidarCamposTipoDocumento(string codigo, string nombre)
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
            txtIdTipoDocumento.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaTipoDocumento();
        }

        private void CargarGrillaTipoDocumento()
        {
            objLTipoDocumento = new LTipoDocumento();
            lstTipoDocumentos = objLTipoDocumento.Consultar();
            Session["TipoDocumentosCompletos"] = lstTipoDocumentos;
            Session["TipoDocumentosFiltrados"] = lstTipoDocumentos;
            grdTipoDocumento.DataSource = lstTipoDocumentos;
            grdTipoDocumento.DataBind();
            if (grdTipoDocumento.HeaderRow != null)
            {
                grdTipoDocumento.UseAccessibleHeader = true;
                grdTipoDocumento.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaTipoDocumento();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaTipoDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdTipoDocumento.Text = grdTipoDocumento.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdTipoDocumento.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdTipoDocumento.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdTipoDocumento.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaTipoDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idTipoDocumento = (sender as LinkButton).CommandArgument;
            CargarGrillaTipoDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idTipoDocumento}');", true);
        }
    }
}
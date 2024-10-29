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
    public partial class frmTiposDocumentos : System.Web.UI.Page
    {
        LTiposDocumentos objLTiposDocumentos = new LTiposDocumentos();
        List<TiposDocumentos> lstTiposDocumentos;
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
            Response.Redirect("~/Views/Configurations/frmTiposDocumentos.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del TiposDocumentos
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el TiposDocumentos
                bool TiposDocumentosvalidado = ValidarCamposTiposDocumentos(codigo, nombre);

                if (!TiposDocumentosvalidado)
                {
                    CargarGrillaTiposDocumentos();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el TiposDocumentos y retorno el numero
                int idTiposDocumentos = GuardarTiposDocumentos(codigo, nombre, activo);
                txtIdTiposDocumentos.Text = idTiposDocumentos.ToString();
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
            CargarGrillaTiposDocumentos();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarTiposDocumentos(string codigo, string nombre, bool activo)
        {
            LTiposDocumentos objLTiposDocumentos = new LTiposDocumentos();
            TiposDocumentos objTiposDocumentos = new TiposDocumentos();
            string id = txtIdTiposDocumentos.Text.Trim();
            int idTiposDocumentos;
            if (string.IsNullOrEmpty(id))
            {
                objTiposDocumentos = objLTiposDocumentos.Guardar(codigo, nombre);
            }
            else
            {
                idTiposDocumentos = Int32.Parse(id);
                objTiposDocumentos = objLTiposDocumentos.Actualizar(idTiposDocumentos, codigo, nombre, activo);
            }
            return objTiposDocumentos.Id;
        }

        private bool ValidarCamposTiposDocumentos(string codigo, string nombre)
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
            txtIdTiposDocumentos.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaTiposDocumentos();
        }

        private void CargarGrillaTiposDocumentos()
        {
            objLTiposDocumentos = new LTiposDocumentos();
            lstTiposDocumentos = objLTiposDocumentos.Consultar();
            Session["TiposDocumentosCompletos"] = lstTiposDocumentos;
            Session["TiposDocumentosFiltrados"] = lstTiposDocumentos;
            grdTiposDocumentos.DataSource = lstTiposDocumentos;
            grdTiposDocumentos.DataBind();
            if (grdTiposDocumentos.HeaderRow != null)
            {
                grdTiposDocumentos.UseAccessibleHeader = true;
                grdTiposDocumentos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaTiposDocumentos();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaTiposDocumentos();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdTiposDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdTiposDocumentos.Text = grdTiposDocumentos.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdTiposDocumentos.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdTiposDocumentos.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdTiposDocumentos.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaTiposDocumentos();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idTiposDocumentos = (sender as LinkButton).CommandArgument;
            CargarGrillaTiposDocumentos();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idTiposDocumentos}');", true);
        }
    }
}
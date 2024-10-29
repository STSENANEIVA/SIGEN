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
    public partial class frmTipoLicencia : System.Web.UI.Page
    {
        LTipoLicencia objLTipoLicencia = new LTipoLicencia();
        List<TipoLicencia> lstTipoLicencias;
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
            Response.Redirect("~/Views/Configurations/frmTipoLicencia.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del TipoLicencia
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el TipoLicencia
                bool TipoLicenciavalidado = ValidarCamposTipoLicencia(codigo, nombre);

                if (!TipoLicenciavalidado)
                {
                    CargarGrillaTipoLicencia();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el TipoLicencia y retorno el numero
                int idTipoLicencia = GuardarTipoLicencia(codigo, nombre, activo);
                txtIdTipoLicencia.Text = idTipoLicencia.ToString();
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
            CargarGrillaTipoLicencia();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarTipoLicencia(string codigo, string nombre, bool activo)
        {
            LTipoLicencia objLTipoLicencia = new LTipoLicencia();
            TipoLicencia objTipoLicencia = new TipoLicencia();
            string id = txtIdTipoLicencia.Text.Trim();
            int idTipoLicencia;
            if (string.IsNullOrEmpty(id))
            {
                objTipoLicencia = objLTipoLicencia.Guardar(codigo, nombre);
            }
            else
            {
                idTipoLicencia = Int32.Parse(id);
                objTipoLicencia = objLTipoLicencia.Actualizar(idTipoLicencia, codigo, nombre, activo);
            }
            return objTipoLicencia.Id;
        }

        private bool ValidarCamposTipoLicencia(string codigo, string nombre)
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
            txtIdTipoLicencia.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaTipoLicencia();
        }

        private void CargarGrillaTipoLicencia()
        {
            objLTipoLicencia = new LTipoLicencia();
            lstTipoLicencias = objLTipoLicencia.Consultar();
            Session["TipoLicenciasCompletos"] = lstTipoLicencias;
            Session["TipoLicenciasFiltrados"] = lstTipoLicencias;
            grdTipoLicencia.DataSource = lstTipoLicencias;
            grdTipoLicencia.DataBind();
            if (grdTipoLicencia.HeaderRow != null)
            {
                grdTipoLicencia.UseAccessibleHeader = true;
                grdTipoLicencia.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaTipoLicencia();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaTipoLicencia();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdTipoLicencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdTipoLicencia.Text = grdTipoLicencia.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdTipoLicencia.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdTipoLicencia.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdTipoLicencia.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaTipoLicencia();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }


        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idTipoLicencia = (sender as LinkButton).CommandArgument;
            CargarGrillaTipoLicencia();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idTipoLicencia}');", true);
        }
    }
}
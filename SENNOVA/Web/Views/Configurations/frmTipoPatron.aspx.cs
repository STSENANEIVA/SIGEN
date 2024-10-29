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
    public partial class frmTipoPatron : System.Web.UI.Page
    {
        LTipoPatron objLTipoPatron = new LTipoPatron();
        List<TipoPatron> lstTipoPatrones;
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
            Response.Redirect("~/Views/Configurations/frmTipoPatron.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del TipoPatron
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el TipoPatron
                bool TipoPatronvalidado = ValidarCamposTipoPatron(codigo, nombre);

                if (!TipoPatronvalidado)
                {
                    CargarGrillaTipoPatron();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el TipoPatron y retorno el numero
                int idTipoPatron = GuardarTipoPatron(codigo, nombre, activo);
                txtIdTipoPatron.Text = idTipoPatron.ToString();
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
            CargarGrillaTipoPatron();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarTipoPatron(string codigo, string nombre, bool activo)
        {
            LTipoPatron objLTipoPatron = new LTipoPatron();
            TipoPatron objTipoPatron = new TipoPatron();
            string id = txtIdTipoPatron.Text.Trim();
            int idTipoPatron;
            if (string.IsNullOrEmpty(id))
            {
                objTipoPatron = objLTipoPatron.Guardar(codigo, nombre);
            }
            else
            {
                idTipoPatron = Int32.Parse(id);
                objTipoPatron = objLTipoPatron.Actualizar(idTipoPatron, codigo, nombre, activo);
            }
            return objTipoPatron.Id;
        }

        private bool ValidarCamposTipoPatron(string codigo, string nombre)
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
            txtIdTipoPatron.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaTipoPatron();
        }

        private void CargarGrillaTipoPatron()
        {
            objLTipoPatron = new LTipoPatron();
            lstTipoPatrones = objLTipoPatron.Consultar();
            Session["TipoPatronesCompletos"] = lstTipoPatrones;
            Session["TipoPatronesFiltrados"] = lstTipoPatrones;
            grdTipoPatron.DataSource = lstTipoPatrones;
            grdTipoPatron.DataBind();
            if (grdTipoPatron.HeaderRow != null)
            {
                grdTipoPatron.UseAccessibleHeader = true;
                grdTipoPatron.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaTipoPatron();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaTipoPatron();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdTipoPatron_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdTipoPatron.Text = grdTipoPatron.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdTipoPatron.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdTipoPatron.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdTipoPatron.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaTipoPatron();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idTipoPatron = (sender as LinkButton).CommandArgument;
            CargarGrillaTipoPatron();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idTipoPatron}');", true);
            
        }
    }
}
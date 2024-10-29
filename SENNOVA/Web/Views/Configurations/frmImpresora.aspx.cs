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
    public partial class frmImpresora : System.Web.UI.Page
    {
        LImpresora objLImpresora = new LImpresora();
        LSoftware objLSoftware = new LSoftware();
        List<Impresora> lstImpresoras;
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
            Response.Redirect("~/Views/Configurations/frmImpresora.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Impresora
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el Impresora
                bool Impresoravalidado = ValidarCamposImpresora(codigo, nombre);

                if (!Impresoravalidado)
                {
                    CargarGrillaImpresora();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Impresora y retorno el numero
                int idImpresora = GuardarImpresora(codigo, nombre, activo);
                txtIdImpresora.Text = idImpresora.ToString();
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
            CargarGrillaImpresora();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarImpresora(string codigo, string nombre, bool activo)
        {
            LImpresora objLImpresora = new LImpresora();
            Impresora objImpresora = new Impresora();
            string id = txtIdImpresora.Text.Trim();
            int idImpresora;
            if (string.IsNullOrEmpty(id))
            {
                objImpresora = objLImpresora.Guardar(codigo, nombre);
            }
            else
            {
                idImpresora = Int32.Parse(id);
                objImpresora = objLImpresora.Actualizar(idImpresora, codigo, nombre, activo);
            }
            return objImpresora.Id;
        }

        private bool ValidarCamposImpresora(string codigo, string nombre)
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
            txtIdImpresora.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaImpresora();
        }

        private void CargarGrillaImpresora()
        {
            objLImpresora = new LImpresora();
            lstImpresoras = objLImpresora.Consultar();
            Session["ImpresorasCompletos"] = lstImpresoras;
            Session["ImpresorasFiltrados"] = lstImpresoras;
            grdImpresora.DataSource = lstImpresoras;
            grdImpresora.DataBind();
            if (grdImpresora.HeaderRow != null)
            {
                grdImpresora.UseAccessibleHeader = true;
                grdImpresora.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaImpresora();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaImpresora();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdImpresora_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdImpresora.Text = grdImpresora.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdImpresora.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdImpresora.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdImpresora.SelectedRow.Cells[3].Controls[0] as CheckBox;
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

            CargarGrillaImpresora();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idImpresora = (sender as LinkButton).CommandArgument;
            CargarGrillaImpresora();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idImpresora}');", true);
        }
    }
}
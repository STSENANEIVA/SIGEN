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
    public partial class frmTipoAreaTecnica : System.Web.UI.Page
    {
        LTipoAreaTecnica objLTipoAreaTecnica = new LTipoAreaTecnica();
        List<TipoAreaTecnica> lstTipoAreaTecnicas;
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
            Response.Redirect("~/Views/Configurations/frmTipoAreaTecnica.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del TipoAreaTecnica
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el TipoAreaTecnica
                bool TipoAreaTecnicavalidado = ValidarCamposTipoAreaTecnica(codigo, nombre);

                if (!TipoAreaTecnicavalidado)
                {
                    CargarGrillaTipoAreaTecnica();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el TipoAreaTecnica y retorno el numero
                int idTipoAreaTecnica = GuardarTipoAreaTecnica(codigo, nombre, activo);
                txtIdTipoAreaTecnica.Text = idTipoAreaTecnica.ToString();
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
            CargarGrillaTipoAreaTecnica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarTipoAreaTecnica(string codigo, string nombre, bool activo)
        {
            LTipoAreaTecnica objLTipoAreaTecnica = new LTipoAreaTecnica();
            TipoAreaTecnica objTipoAreaTecnica = new TipoAreaTecnica();
            string id = txtIdTipoAreaTecnica.Text.Trim();
            int idTipoAreaTecnica;
            if (string.IsNullOrEmpty(id))
            {
                objTipoAreaTecnica = objLTipoAreaTecnica.Guardar(codigo, nombre);
            }
            else
            {
                idTipoAreaTecnica = Int32.Parse(id);
                objTipoAreaTecnica = objLTipoAreaTecnica.Actualizar(idTipoAreaTecnica, codigo, nombre, activo);
            }
            return objTipoAreaTecnica.Id;
        }

        private bool ValidarCamposTipoAreaTecnica(string codigo, string nombre)
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
            txtIdTipoAreaTecnica.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaTipoAreaTecnica();
        }

        private void CargarGrillaTipoAreaTecnica()
        {
            objLTipoAreaTecnica = new LTipoAreaTecnica();
            lstTipoAreaTecnicas = objLTipoAreaTecnica.Consultar();
            Session["TipoAreaTecnicasCompletos"] = lstTipoAreaTecnicas;
            Session["TipoAreaTecnicasFiltrados"] = lstTipoAreaTecnicas;
            grdTipoAreaTecnica.DataSource = lstTipoAreaTecnicas;
            grdTipoAreaTecnica.DataBind();

            if (grdTipoAreaTecnica.HeaderRow != null)
            {
                grdTipoAreaTecnica.UseAccessibleHeader = true;
                grdTipoAreaTecnica.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaTipoAreaTecnica();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaTipoAreaTecnica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdTipoAreaTecnica_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdTipoAreaTecnica.Text = grdTipoAreaTecnica.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdTipoAreaTecnica.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdTipoAreaTecnica.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdTipoAreaTecnica.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaTipoAreaTecnica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idTipoAreaTecnica = (sender as LinkButton).CommandArgument;
            CargarGrillaTipoAreaTecnica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idTipoAreaTecnica}');", true);
        }
    }
}
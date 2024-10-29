using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Utilities;

namespace Web.Views.Configurations
{
    public partial class frmFamilia : System.Web.UI.Page
    {
        List<Familia> lstFamilia;
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
            Response.Redirect("~/Views/Configurations/frmFamilia.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;

                bool Familiavalidado = ValidarCamposFamilia(codigo, nombre);
                
                if (!Familiavalidado)
                {
                    CargarGrillaFamilia();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                int idFamilia = GuardarFamilia(codigo, nombre, activo);
                txtIdFamilia.Text = idFamilia.ToString();
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
            CargarGrillaFamilia();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private void CargarControles()
        {
            CargarGrillaFamilia();
        }

        private void CargarGrillaFamilia()
        {

            LFamilia objLFamilia = new LFamilia();
            lstFamilia = objLFamilia.Consultar();
            Session["FamiliaCompletos"] = lstFamilia;
            Session["FamiliaFiltrados"] = lstFamilia;
            grdFamilia.DataSource = lstFamilia;
            grdFamilia.DataBind();

            if(grdFamilia.HeaderRow != null)
            {
                grdFamilia.UseAccessibleHeader = true;
                grdFamilia.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        private bool ValidarCamposFamilia(string codigo, string nombre) 
        {
            bool resultado = true;
            if (String.IsNullOrEmpty(codigo))
            {
                camposFaltantes = camposFaltantes + ", " + "codigo";
                resultado = false;
            }
            if (String.IsNullOrEmpty(nombre))
            {
                camposFaltantes = camposFaltantes + ", " + "codigo";
                resultado = false;
            }
            return resultado;
        }
        
        private int GuardarFamilia(string codigo, string nombre, bool activo)
        {
            LFamilia objLFamilia = new LFamilia();
            Familia objFamilia = new Familia();
            string id = txtIdFamilia.Text.Trim();
            int idFamilia;
            if (string.IsNullOrEmpty(id))
            {
                objFamilia = objLFamilia.Guardar(codigo, nombre, activo);
            }
            else
            {
                idFamilia = Int32.Parse(id);
                objFamilia = objLFamilia.Actualizar(idFamilia, codigo, nombre, activo);
            }
            return objFamilia.Id;
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaFamilia();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaFamilia();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdFamilia.Text = "";
        }

        protected void grdFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdFamilia.Text = grdFamilia.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdFamilia.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdFamilia.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdFamilia.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaFamilia();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idFamilia = (sender as LinkButton).CommandArgument;
            CargarGrillaFamilia();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idFamilia}');", true);
        }
    }
}
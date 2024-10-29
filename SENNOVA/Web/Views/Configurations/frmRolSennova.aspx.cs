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
    public partial class frmRolSennova : System.Web.UI.Page
    {
        LRolSennova objLRolSennova = new LRolSennova();
        List<RolSennova> lstRolSennovas;
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
            Response.Redirect("~/Views/Configurations/frmRolSennova.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del RolSennova
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el RolSennova
                bool RolSennovavalidado = ValidarCamposRolSennova(codigo, nombre);

                if (!RolSennovavalidado)
                {
                    CargarGrillaRolSennova();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el RolSennova y retorno el numero
                int idRolSennova = GuardarRolSennova(codigo, nombre, activo);
                txtIdRolSennova.Text = idRolSennova.ToString();
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
            CargarGrillaRolSennova();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarRolSennova(string codigo, string nombre, bool activo)
        {
            LRolSennova objLRolSennova = new LRolSennova();
            RolSennova objRolSennova = new RolSennova();
            string id = txtIdRolSennova.Text.Trim();
            int idRolSennova;
            if (string.IsNullOrEmpty(id))
            {
                objRolSennova = objLRolSennova.Guardar(codigo, nombre);
            }
            else
            {
                idRolSennova = Int32.Parse(id);
                objRolSennova = objLRolSennova.Actualizar(idRolSennova, codigo, nombre, activo);
            }
            return objRolSennova.Id;
        }

        private bool ValidarCamposRolSennova(string codigo, string nombre)
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
            txtIdRolSennova.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaRolSennova();
        }

        private void CargarGrillaRolSennova()
        {
            objLRolSennova = new LRolSennova();
            lstRolSennovas = objLRolSennova.Consultar();
            Session["RolSennovasCompletos"] = lstRolSennovas;
            Session["RolSennovasFiltrados"] = lstRolSennovas;
            grdRolSennova.DataSource = lstRolSennovas;
            grdRolSennova.DataBind();
            if (grdRolSennova.HeaderRow != null)
            {
                grdRolSennova.UseAccessibleHeader = true;
                grdRolSennova.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaRolSennova();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaRolSennova();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdRolSennova_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdRolSennova.Text = grdRolSennova.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdRolSennova.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdRolSennova.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdRolSennova.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaRolSennova();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idRolSennova = (sender as LinkButton).CommandArgument;
            CargarGrillaRolSennova();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idRolSennova}');", true);
        }
    }
}
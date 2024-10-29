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
    public partial class frmTerminoCondicion : System.Web.UI.Page
    {
        LTerminoCondicion objLTerminoCondicion = new LTerminoCondicion();
        List<TerminoCondicion> lstTerminoCondicions;
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
            Response.Redirect("~/Views/Configurations/frmTerminoCondicion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del TerminoCondicion
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el TerminoCondicion
                bool TerminoCondicionvalidado = ValidarCamposTerminoCondicion(codigo, nombre);

                if (!TerminoCondicionvalidado)
                {
                    CargarGrillaTerminoCondicion();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el TerminoCondicion y retorno el numero
                int idTerminoCondicion = GuardarTerminoCondicion(codigo, nombre, activo);
                txtIdTerminoCondicion.Text = idTerminoCondicion.ToString();
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
            CargarGrillaTerminoCondicion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarTerminoCondicion(string codigo, string nombre, bool activo)
        {
            LTerminoCondicion objLTerminoCondicion = new LTerminoCondicion();
            TerminoCondicion objTerminoCondicion = new TerminoCondicion();
            string id = txtIdTerminoCondicion.Text.Trim();
            int idTerminoCondicion;
            if (string.IsNullOrEmpty(id))
            {
                objTerminoCondicion = objLTerminoCondicion.Guardar(codigo, nombre);
            }
            else
            {
                idTerminoCondicion = Int32.Parse(id);
                objTerminoCondicion = objLTerminoCondicion.Actualizar(idTerminoCondicion, codigo, nombre, activo);
            }
            return objTerminoCondicion.Id;
        }

        private bool ValidarCamposTerminoCondicion(string codigo, string nombre)
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
            txtIdTerminoCondicion.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaTerminoCondicion();
        }

        private void CargarGrillaTerminoCondicion()
        {
            objLTerminoCondicion = new LTerminoCondicion();
            lstTerminoCondicions = objLTerminoCondicion.Consultar();
            Session["TerminoCondicionsCompletos"] = lstTerminoCondicions;
            Session["TerminoCondicionsFiltrados"] = lstTerminoCondicions;
            grdTerminoCondicion.DataSource = lstTerminoCondicions;
            grdTerminoCondicion.DataBind();
            if (grdTerminoCondicion.HeaderRow != null)
            {
                grdTerminoCondicion.UseAccessibleHeader = true;
                grdTerminoCondicion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaTerminoCondicion();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaTerminoCondicion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdTerminoCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdTerminoCondicion.Text = grdTerminoCondicion.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdTerminoCondicion.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdTerminoCondicion.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdTerminoCondicion.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaTerminoCondicion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idTerminoCondicion = (sender as LinkButton).CommandArgument;
            CargarGrillaTerminoCondicion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idTerminoCondicion}');", true);
        }
    }
}
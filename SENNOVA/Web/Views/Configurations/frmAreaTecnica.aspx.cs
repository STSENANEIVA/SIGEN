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
    public partial class frmAreaTecnica : System.Web.UI.Page
    {
        LAreaTecnica objLAreaTecnica = new LAreaTecnica();
        List<AreaTecnica> lstAreaTecnicas;
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
            Response.Redirect("~/Views/Configurations/frmAreaTecnica.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del AreaTecnica
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string idTipoAreaTecnica = ddlTipoAreaTecnica.SelectedValue;
                string idResponsable = hidResponsableId.Value;
                LEmpleado objLEmpleado = new LEmpleado();
                Empleado objEmpleado = objLEmpleado.ConsultarPorPersona(int.Parse(idResponsable));
                bool activo = chkActivo.Checked;


                //validar el AreaTecnica
                bool AreaTecnicavalidado = ValidarCamposAreaTecnica(codigo, nombre, idTipoAreaTecnica, objEmpleado.Id);

                if (!AreaTecnicavalidado)
                {
                    CargarGrillaAreaTecnica();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el AreaTecnica y retorno el numero
                int idAreaTecnica = GuardarAreaTecnica(codigo, nombre, activo, idTipoAreaTecnica, objEmpleado.Id);
                txtIdAreaTecnica.Text = idAreaTecnica.ToString();
                PantallaGuardado();
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaAreaTecnica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarAreaTecnica(string codigo, string nombre, bool activo, string idTipoAreaTecnica, int idResponsable)
        {
            LAreaTecnica objLAreaTecnica = new LAreaTecnica();
            AreaTecnica objAreaTecnica = new AreaTecnica();
            string id = txtIdAreaTecnica.Text.Trim();
            int idAreaTecnica;
            if (string.IsNullOrEmpty(id))
            {
                objAreaTecnica = objLAreaTecnica.Guardar(codigo, nombre, int.Parse(idTipoAreaTecnica), idResponsable);
            }
            else
            {
                idAreaTecnica = Int32.Parse(id);
                objAreaTecnica = objLAreaTecnica.Actualizar(idAreaTecnica, codigo, nombre, activo, int.Parse(idTipoAreaTecnica), idResponsable);
            }
            return objAreaTecnica.Id;
        }

        private bool ValidarCamposAreaTecnica(string codigo, string nombre, string idTipoAreaTecnica, int idResponsable)
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
            if (String.IsNullOrEmpty(nombre))
            {
                camposFaltantes = camposFaltantes + ", " + "nombre";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idTipoAreaTecnica.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "TipoAreaTecnica";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idResponsable.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Responsable";
                resultado = false;
            }
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdAreaTecnica.Text = "";
            txtResponsable.Text = "";
            hidResponsableId.Value = "";
            chkActivo.Checked = false;
        }

        private void CargarControles()
        {
            CargarGrillaAreaTecnica();           
            CargarTipoAreaTecnicas();
        }
        private void CargarTipoAreaTecnicas()
        {

            LTipoAreaTecnica objLTipoAreaTecnica = new LTipoAreaTecnica();
            ddlTipoAreaTecnica.DataSource = objLTipoAreaTecnica.Consultar();
            ddlTipoAreaTecnica.DataTextField = "Nombre";
            ddlTipoAreaTecnica.DataValueField = "id";
            ddlTipoAreaTecnica.DataBind();
            //ddlTipoAreaTecnica.Items.Add(new ListItem("Seleccione", "0"));
            //ddlTipoAreaTecnica.SelectedValue = "0";
        }

        private void CargarGrillaAreaTecnica()
        {
            objLAreaTecnica = new LAreaTecnica();
            lstAreaTecnicas = objLAreaTecnica.Consultar();
            Session["AreaTecnicasCompletos"] = lstAreaTecnicas;
            Session["AreaTecnicasFiltrados"] = lstAreaTecnicas;
            grdAreaTecnica.DataSource = lstAreaTecnicas;
            grdAreaTecnica.DataBind();

            if (grdAreaTecnica.HeaderRow != null)
            {
                grdAreaTecnica.UseAccessibleHeader = true;
                grdAreaTecnica.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaAreaTecnica();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaAreaTecnica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdAreaTecnica_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdAreaTecnica.Text = grdAreaTecnica.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdAreaTecnica.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdAreaTecnica.SelectedRow.Cells[2].Text).Trim();
                string tipoArea = HttpUtility.HtmlDecode(grdAreaTecnica.SelectedRow.Cells[3].Text).Trim();
                ddlTipoAreaTecnica.ClearSelection();
                ddlTipoAreaTecnica.SelectedValue = ddlTipoAreaTecnica.Items.FindByText(tipoArea).Value;
                txtResponsable.Text = HttpUtility.HtmlDecode(grdAreaTecnica.SelectedRow.Cells[4].Text).Trim();
                CheckBox chk = grdAreaTecnica.SelectedRow.Cells[5].Controls[0] as CheckBox;
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
            CargarGrillaAreaTecnica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idAreaTecnica = (sender as LinkButton).CommandArgument;
            CargarGrillaAreaTecnica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idAreaTecnica}');", true);
        }
    }
}
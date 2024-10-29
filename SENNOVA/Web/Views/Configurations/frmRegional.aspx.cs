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
    public partial class frmRegional : System.Web.UI.Page
    {
        LRegional objLRegional = new LRegional();
        LRegion objLRegion = new LRegion();
        List<Regional> lstRegionals;
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
            Response.Redirect("~/Views/Configurations/frmRegional.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Regional
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;
                int idRegion = int.Parse(ddlRegion.SelectedValue);


                //validar el Regional
                bool Regionalvalidado = ValidarCamposRegional(codigo, nombre, idRegion);

                if (!Regionalvalidado)
                {
                    CargarGrillaRegional();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Regional y retorno el numero
                int idRegional = GuardarRegional(codigo, nombre, activo, idRegion);
                txtIdRegional.Text = idRegional.ToString();
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
            CargarGrillaRegional();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarRegional(string codigo, string nombre, bool activo, int idRegion)
        {
            LRegional objLRegional = new LRegional();
            Regional objRegional = new Regional();
            string id = txtIdRegional.Text.Trim();
            int idRegional;
            if (string.IsNullOrEmpty(id))
            {
                objRegional = objLRegional.Guardar(codigo, nombre, idRegion);
            }
            else
            {
                idRegional = Int32.Parse(id);
                objRegional = objLRegional.Actualizar(idRegional, codigo, nombre, activo, idRegion);
            }
            return objRegional.Id;
        }

        private bool ValidarCamposRegional(string codigo, string nombre, int idRegion)
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
            if (String.IsNullOrEmpty(idRegion.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Region";
                resultado = false;
            }
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdRegional.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaRegional();
            CargarRegiones();
        }

        private void CargarRegiones()
        {

            objLRegion = new LRegion();
            ddlRegion.DataSource = objLRegion.Consultar();
            ddlRegion.DataTextField = "Nombre";
            ddlRegion.DataValueField = "id";
            ddlRegion.DataBind();
            ddlRegion.Items.Add(new ListItem("Seleccione", "0"));
            ddlRegion.SelectedValue = "0";
        }

        private void CargarGrillaRegional()
        {
            objLRegional = new LRegional();
            lstRegionals = objLRegional.Consultar();
            Session["RegionalsCompletos"] = lstRegionals;
            Session["RegionalsFiltrados"] = lstRegionals;
            grdRegional.DataSource = lstRegionals;
            grdRegional.DataBind();
            if (grdRegional.HeaderRow != null)
            {
                grdRegional.UseAccessibleHeader = true;
                grdRegional.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaRegional();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaRegional();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdRegional.Text = grdRegional.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdRegional.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdRegional.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdRegional.SelectedRow.Cells[4].Controls[0] as CheckBox;
                if (chk.Checked)
                {
                    chkActivo.Checked = true;
                }
                else
                {
                    chkActivo.Checked = false;
                }
                string region = HttpUtility.HtmlDecode(grdRegional.SelectedRow.Cells[3].Text.Trim());
                ddlRegion.ClearSelection();
                ddlRegion.SelectedValue = ddlRegion.Items.FindByText(region).Value;

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaRegional();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idRegional = (sender as LinkButton).CommandArgument;
                LRegional objLRegional = new LRegional();
                Regional Regional = objLRegional.Consultar(int.Parse(idRegional));
                LCentroFormacion objLCentroFormacion = new LCentroFormacion();
                CentroFormacion objCentroFormacion = objLCentroFormacion.ConsultarPorRegional(Regional.Id);

                if (objCentroFormacion.Id == 0)
                {
                    objLRegional.Eliminar(int.Parse(idRegional));
                    CargarGrillaRegional();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaRegional();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    string message = $"El Regional {Regional.Nombre} no se puede Eliminar, ya que se encuentra asociado.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
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
            CargarGrillaRegional();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }
    }
}
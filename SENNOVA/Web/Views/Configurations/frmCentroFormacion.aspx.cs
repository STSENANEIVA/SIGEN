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
    public partial class frmCentroFormacion : System.Web.UI.Page
    {
        LCentroFormacion objLCentroFormacion = new LCentroFormacion();
        LRegional objLRegional = new LRegional();
        List<CentroFormacion> lstCentroFormacions;
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
            Response.Redirect("~/Views/Configurations/frmCentroFormacion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del CentroFormacion
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;
                int idRegional = int.Parse(ddlRegional.SelectedValue);


                //validar el CentroFormacion
                bool CentroFormacionvalidado = ValidarCamposCentroFormacion(codigo, nombre, idRegional);

                if (!CentroFormacionvalidado)
                {
                    CargarGrillaCentroFormacion();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el CentroFormacion y retorno el numero
                int idCentroFormacion = GuardarCentroFormacion(codigo, nombre, activo, idRegional);
                txtIdCentroFormacion.Text = idCentroFormacion.ToString();
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
            CargarGrillaCentroFormacion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarCentroFormacion(string codigo, string nombre, bool activo, int idRegional)
        {
            LCentroFormacion objLCentroFormacion = new LCentroFormacion();
            CentroFormacion objCentroFormacion = new CentroFormacion();
            string id = txtIdCentroFormacion.Text.Trim();
            int idCentroFormacion;
            if (string.IsNullOrEmpty(id))
            {
                objCentroFormacion = objLCentroFormacion.Guardar(codigo, nombre, idRegional);
            }
            else
            {
                idCentroFormacion = Int32.Parse(id);
                objCentroFormacion = objLCentroFormacion.Actualizar(idCentroFormacion, codigo, nombre, activo, idRegional);
            }
            return objCentroFormacion.Id;
        }

        private bool ValidarCamposCentroFormacion(string codigo, string nombre, int idRegional)
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
            if (String.IsNullOrEmpty(idRegional.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Regional";
                resultado = false;
            }
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdCentroFormacion.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaCentroFormacion();
            CargarRegionales();
        }

        private void CargarRegionales()
        {

            objLRegional = new LRegional();
            ddlRegional.DataSource = objLRegional.Consultar();
            ddlRegional.DataTextField = "Nombre";
            ddlRegional.DataValueField = "id";
            ddlRegional.DataBind();
            ddlRegional.Items.Add(new ListItem("Seleccione", "0"));
            ddlRegional.SelectedValue = "0";
        }

        private void CargarGrillaCentroFormacion()
        {
            objLCentroFormacion = new LCentroFormacion();
            lstCentroFormacions = objLCentroFormacion.Consultar();
            Session["CentroFormacionsCompletos"] = lstCentroFormacions;
            Session["CentroFormacionsFiltrados"] = lstCentroFormacions;
            grdCentroFormacion.DataSource = lstCentroFormacions;
            grdCentroFormacion.DataBind();
            if (grdCentroFormacion.HeaderRow != null)
            {
                grdCentroFormacion.UseAccessibleHeader = true;
                grdCentroFormacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaCentroFormacion();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaCentroFormacion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdCentroFormacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdCentroFormacion.Text = grdCentroFormacion.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdCentroFormacion.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdCentroFormacion.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdCentroFormacion.SelectedRow.Cells[4].Controls[0] as CheckBox;
                if (chk.Checked)
                {
                    chkActivo.Checked = true;
                }
                else
                {
                    chkActivo.Checked = false;
                }
                string region = HttpUtility.HtmlDecode(grdCentroFormacion.SelectedRow.Cells[3].Text.Trim());
                ddlRegional.ClearSelection();
                ddlRegional.SelectedValue = ddlRegional.Items.FindByText(region).Value;

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaCentroFormacion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);

        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idCentroFormacion = (sender as LinkButton).CommandArgument;
                LCentroFormacion objLCentroFormacion = new LCentroFormacion();
                CentroFormacion CentroFormacion = objLCentroFormacion.Consultar(int.Parse(idCentroFormacion));
                CentroFormacion objCentroFormacion = objLCentroFormacion.ConsultarPorRegional(CentroFormacion.Id);

                if (objCentroFormacion.Id == 0)
                {
                    objLCentroFormacion.Eliminar(int.Parse(idCentroFormacion));
                    CargarGrillaCentroFormacion();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaCentroFormacion();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    string message = $"El CentroFormacion {CentroFormacion.Nombre} no se puede Eliminar, ya que se encuentra asociado.";
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
            CargarGrillaCentroFormacion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }
    }
}
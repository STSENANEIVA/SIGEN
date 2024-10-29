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
    public partial class frmCargo : System.Web.UI.Page
    {
        LCargo objLCargo = new LCargo();
        List<Cargo> lstCargos;
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
            Response.Redirect("~/Views/Configurations/frmCargo.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Cargo
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el Cargo
                bool Cargovalidado = ValidarCamposCargo(codigo, nombre);

                if (!Cargovalidado)
                {
                    CargarGrillaCargo();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Cargo y retorno el numero
                int idCargo = GuardarCargo(codigo, nombre, activo);
                txtIdCargo.Text = idCargo.ToString();
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
        }

        private int GuardarCargo(string codigo, string nombre, bool activo)
        {
            LCargo objLCargo = new LCargo();
            Cargo objCargo = new Cargo();
            string id = txtIdCargo.Text.Trim();
            int idCargo;
            if (string.IsNullOrEmpty(id))
            {
                objCargo = objLCargo.Guardar(codigo, nombre);
            }
            else
            {
                idCargo = Int32.Parse(id);
                objCargo = objLCargo.Actualizar(idCargo, codigo, nombre, activo);
            }
            return objCargo.Id;
        }

        private bool ValidarCamposCargo(string codigo, string nombre)
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
            txtIdCargo.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaCargo();
        }

        private void CargarGrillaCargo()
        {
            objLCargo = new LCargo();
            lstCargos = objLCargo.Consultar();
            Session["CargosCompletos"] = lstCargos;
            Session["CargosFiltrados"] = lstCargos;
            grdCargo.DataSource = lstCargos;
            grdCargo.DataBind();
            if (grdCargo.HeaderRow != null)
            {
                grdCargo.UseAccessibleHeader = true;
                grdCargo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaCargo();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaCargo();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdCargo.Text = grdCargo.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdCargo.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdCargo.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdCargo.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaCargo();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idCargo = (sender as LinkButton).CommandArgument;
            CargarGrillaCargo();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idCargo}');", true);
        }
    }
}
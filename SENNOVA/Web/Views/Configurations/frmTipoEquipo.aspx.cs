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
    public partial class frmTipoEquipo : System.Web.UI.Page
    {
        LTipoEquipo objLTipoEquipo = new LTipoEquipo();
        List<TipoEquipo> lstTipoEquipos;
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
            Response.Redirect("~/Views/Configurations/frmTipoEquipo.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del TipoEquipo
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el TipoEquipo
                bool TipoEquipovalidado = ValidarCamposTipoEquipo(codigo, nombre);

                if (!TipoEquipovalidado)
                {
                    CargarGrillaTipoEquipo();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el TipoEquipo y retorno el numero
                int idTipoEquipo = GuardarTipoEquipo(codigo, nombre, activo);
                txtIdTipoEquipo.Text = idTipoEquipo.ToString();
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
            CargarGrillaTipoEquipo();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarTipoEquipo(string codigo, string nombre, bool activo)
        {
            LTipoEquipo objLTipoEquipo = new LTipoEquipo();
            TipoEquipo objTipoEquipo = new TipoEquipo();
            string id = txtIdTipoEquipo.Text.Trim();
            int idTipoEquipo;
            if (string.IsNullOrEmpty(id))
            {
                objTipoEquipo = objLTipoEquipo.Guardar(codigo, nombre);
            }
            else
            {
                idTipoEquipo = Int32.Parse(id);
                objTipoEquipo = objLTipoEquipo.Actualizar(idTipoEquipo, codigo, nombre, activo);
            }
            return objTipoEquipo.Id;
        }

        private bool ValidarCamposTipoEquipo(string codigo, string nombre)
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
            txtIdTipoEquipo.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaTipoEquipo();
        }

        private void CargarGrillaTipoEquipo()
        {
            objLTipoEquipo = new LTipoEquipo();
            lstTipoEquipos = objLTipoEquipo.Consultar();
            Session["TipoEquiposCompletos"] = lstTipoEquipos;
            Session["TipoEquiposFiltrados"] = lstTipoEquipos;
            grdTipoEquipo.DataSource = lstTipoEquipos;
            grdTipoEquipo.DataBind();

            if (grdTipoEquipo.HeaderRow != null)
            {
                grdTipoEquipo.UseAccessibleHeader = true;
                grdTipoEquipo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaTipoEquipo();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaTipoEquipo();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdTipoEquipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdTipoEquipo.Text = grdTipoEquipo.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdTipoEquipo.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdTipoEquipo.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdTipoEquipo.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaTipoEquipo();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idTipoEquipo = (sender as LinkButton).CommandArgument;
            CargarGrillaTipoEquipo();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idTipoEquipo}');", true);
        }
    }
}
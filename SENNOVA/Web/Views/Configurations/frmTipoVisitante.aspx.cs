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
    public partial class frmTipoVisitante : System.Web.UI.Page
    {
        LTipoVisitante objLTipoVisitante = new LTipoVisitante();
        List<TipoVisitante> lstTipoVisitantes;
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
            Response.Redirect("~/Views/Configurations/frmTipoVisitante.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del TipoVisitante
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el TipoVisitante
                bool TipoVisitantevalidado = ValidarCamposTipoVisitante(codigo, nombre);

                if (!TipoVisitantevalidado)
                {
                    CargarGrillaTipoVisitante();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el TipoVisitante y retorno el numero
                int idTipoVisitante = GuardarTipoVisitante(codigo, nombre, activo);
                txtIdTipoVisitante.Text = idTipoVisitante.ToString();
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
            CargarGrillaTipoVisitante();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarTipoVisitante(string codigo, string nombre, bool activo)
        {
            LTipoVisitante objLTipoVisitante = new LTipoVisitante();
            TipoVisitante objTipoVisitante = new TipoVisitante();
            string id = txtIdTipoVisitante.Text.Trim();
            int idTipoVisitante;
            if (string.IsNullOrEmpty(id))
            {
                objTipoVisitante = objLTipoVisitante.Guardar(codigo, nombre);
            }
            else
            {
                idTipoVisitante = Int32.Parse(id);
                objTipoVisitante = objLTipoVisitante.Actualizar(idTipoVisitante, codigo, nombre, activo);
            }
            return objTipoVisitante.Id;
        }

        private bool ValidarCamposTipoVisitante(string codigo, string nombre)
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
            txtIdTipoVisitante.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaTipoVisitante();
        }

        private void CargarGrillaTipoVisitante()
        {
            objLTipoVisitante = new LTipoVisitante();
            lstTipoVisitantes = objLTipoVisitante.Consultar();
            Session["TipoVisitantesCompletos"] = lstTipoVisitantes;
            Session["TipoVisitantesFiltrados"] = lstTipoVisitantes;
            grdTipoVisitante.DataSource = lstTipoVisitantes;
            grdTipoVisitante.DataBind();

            if (grdTipoVisitante.HeaderRow != null)
            {
                grdTipoVisitante.UseAccessibleHeader = true;
                grdTipoVisitante.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaTipoVisitante();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaTipoVisitante();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdTipoVisitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdTipoVisitante.Text = grdTipoVisitante.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdTipoVisitante.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdTipoVisitante.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdTipoVisitante.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaTipoVisitante();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idTipoVisitante = (sender as LinkButton).CommandArgument;
            CargarGrillaTipoVisitante();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idTipoVisitante}');", true);
            
        }
    }
}
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
    public partial class frmAreaConocimiento : System.Web.UI.Page
    {
        LAreaConocimiento objLAreaConocimiento = new LAreaConocimiento();
        List<AreaConocimiento> lstAreaConocimientos;
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
            Response.Redirect("~/Views/Configurations/frmAreaConocimiento.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del AreaConocimiento
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el AreaConocimiento
                bool AreaConocimientovalidado = ValidarCamposAreaConocimiento(codigo, nombre);

                if (!AreaConocimientovalidado)
                {
                    CargarGrillaAreaConocimiento();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el AreaConocimiento y retorno el numero
                int idAreaConocimiento = GuardarAreaConocimiento(codigo, nombre, activo);
                txtIdAreaConocimiento.Text = idAreaConocimiento.ToString();
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
            CargarGrillaAreaConocimiento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarAreaConocimiento(string codigo, string nombre, bool activo)
        {
            LAreaConocimiento objLAreaConocimiento = new LAreaConocimiento();
            AreaConocimiento objAreaConocimiento = new AreaConocimiento();
            string id = txtIdAreaConocimiento.Text.Trim();
            int idAreaConocimiento;
            if (string.IsNullOrEmpty(id))
            {
                objAreaConocimiento = objLAreaConocimiento.Guardar(codigo, nombre);
            }
            else
            {
                idAreaConocimiento = Int32.Parse(id);
                objAreaConocimiento = objLAreaConocimiento.Actualizar(idAreaConocimiento, codigo, nombre, activo);
            }
            return objAreaConocimiento.Id;
        }

        private bool ValidarCamposAreaConocimiento(string codigo, string nombre)
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
            txtIdAreaConocimiento.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaAreaConocimiento();
        }

        private void CargarGrillaAreaConocimiento()
        {
            objLAreaConocimiento = new LAreaConocimiento();
            lstAreaConocimientos = objLAreaConocimiento.Consultar();
            Session["AreaConocimientosCompletos"] = lstAreaConocimientos;
            Session["AreaConocimientosFiltrados"] = lstAreaConocimientos;
            grdAreaConocimiento.DataSource = lstAreaConocimientos;
            grdAreaConocimiento.DataBind();
            if (grdAreaConocimiento.HeaderRow != null)
            {
                grdAreaConocimiento.UseAccessibleHeader = true;
                grdAreaConocimiento.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaAreaConocimiento();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaAreaConocimiento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdAreaConocimiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdAreaConocimiento.Text = grdAreaConocimiento.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdAreaConocimiento.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdAreaConocimiento.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdAreaConocimiento.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaAreaConocimiento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idAreaConocimiento = (sender as LinkButton).CommandArgument;
                LAreaConocimiento objLAreaConocimiento = new LAreaConocimiento();
                AreaConocimiento AreaConocimiento = objLAreaConocimiento.Consultar(int.Parse(idAreaConocimiento));
                LProyecto objLProyecto = new LProyecto();
                Proyecto objProyecto = objLProyecto.ConsultarPorAreaConocimiento(AreaConocimiento.Id);

                if (objProyecto.Id == 0)
                {
                    objLAreaConocimiento.Eliminar(int.Parse(idAreaConocimiento));
                    CargarGrillaAreaConocimiento();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaAreaConocimiento();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    string message = $"El AreaConocimiento {AreaConocimiento.Nombre} no se puede Eliminar, ya que se encuentra asociado a un Producto";
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
            CargarGrillaAreaConocimiento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }
    }
}
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
    public partial class frmLineaProgramatica : System.Web.UI.Page
    {
        LLineaProgramatica objLLineaProgramatica = new LLineaProgramatica();
        List<LineaProgramatica> lstLineaProgramaticas;
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
            Response.Redirect("~/Views/Configurations/frmLineaProgramatica.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del LineaProgramatica
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el LineaProgramatica
                bool LineaProgramaticavalidado = ValidarCamposLineaProgramatica(codigo, nombre);

                if (!LineaProgramaticavalidado)
                {
                    CargarGrillaLineaProgramatica();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el LineaProgramatica y retorno el numero
                int idLineaProgramatica = GuardarLineaProgramatica(codigo, nombre, activo);
                txtIdLineaProgramatica.Text = idLineaProgramatica.ToString();
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
            CargarGrillaLineaProgramatica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarLineaProgramatica(string codigo, string nombre, bool activo)
        {
            LLineaProgramatica objLLineaProgramatica = new LLineaProgramatica();
            LineaProgramatica objLineaProgramatica = new LineaProgramatica();
            string id = txtIdLineaProgramatica.Text.Trim();
            int idLineaProgramatica;
            if (string.IsNullOrEmpty(id))
            {
                objLineaProgramatica = objLLineaProgramatica.Guardar(codigo, nombre);
            }
            else
            {
                idLineaProgramatica = Int32.Parse(id);
                objLineaProgramatica = objLLineaProgramatica.Actualizar(idLineaProgramatica, codigo, nombre, activo);
            }
            return objLineaProgramatica.Id;
        }

        private bool ValidarCamposLineaProgramatica(string codigo, string nombre)
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
            txtIdLineaProgramatica.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaLineaProgramatica();
        }

        private void CargarGrillaLineaProgramatica()
        {
            objLLineaProgramatica = new LLineaProgramatica();
            lstLineaProgramaticas = objLLineaProgramatica.Consultar();
            Session["LineaProgramaticasCompletos"] = lstLineaProgramaticas;
            Session["LineaProgramaticasFiltrados"] = lstLineaProgramaticas;
            grdLineaProgramatica.DataSource = lstLineaProgramaticas;
            grdLineaProgramatica.DataBind();
            if (grdLineaProgramatica.HeaderRow != null)
            {
                grdLineaProgramatica.UseAccessibleHeader = true;
                grdLineaProgramatica.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaLineaProgramatica();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaLineaProgramatica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdLineaProgramatica_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdLineaProgramatica.Text = grdLineaProgramatica.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdLineaProgramatica.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdLineaProgramatica.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdLineaProgramatica.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaLineaProgramatica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idLineaProgramatica = (sender as LinkButton).CommandArgument;
                LLineaProgramatica objLLineaProgramatica = new LLineaProgramatica();
                LineaProgramatica LineaProgramatica = objLLineaProgramatica.Consultar(int.Parse(idLineaProgramatica));
                LProyecto objLProyecto = new LProyecto();
                Proyecto objProyecto = objLProyecto.ConsultarPorLineaProgramatica(LineaProgramatica.Id);

                if (objProyecto.Id == 0)
                {
                    objLLineaProgramatica.Eliminar(int.Parse(idLineaProgramatica));
                    CargarGrillaLineaProgramatica();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaLineaProgramatica();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    string message = $"El LineaProgramatica {LineaProgramatica.Nombre} no se puede Eliminar, ya que se encuentra asociado a un Producto";
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
            CargarGrillaLineaProgramatica();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }
    }
}
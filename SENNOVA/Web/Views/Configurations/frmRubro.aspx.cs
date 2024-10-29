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
    public partial class frmRubro : System.Web.UI.Page
    {
        LRubro objLRubro = new LRubro();
        LProyectoRubro objLProyectoRubros = new LProyectoRubro();
        List<Rubro> lstRubros;
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
            Response.Redirect("~/Views/Configurations/frmRubro.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Rubro
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el Rubro
                bool Rubrovalidado = ValidarCamposRubro(codigo, nombre);

                if (!Rubrovalidado)
                {
                    CargarGrillaRubro();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Rubro y retorno el numero
                int idRubro = GuardarRubro(codigo, nombre, activo);
                txtIdRubro.Text = idRubro.ToString();
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
            CargarGrillaRubro();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarRubro(string codigo, string nombre, bool activo)
        {
            LRubro objLRubro = new LRubro();
            Rubro objRubro = new Rubro();
            string id = txtIdRubro.Text.Trim();
            int idRubro;
            if (string.IsNullOrEmpty(id))
            {
                objRubro = objLRubro.Guardar(codigo, nombre);
            }
            else
            {
                idRubro = Int32.Parse(id);
                objRubro = objLRubro.Actualizar(idRubro, codigo, nombre, activo);
            }
            return objRubro.Id;
        }

        private bool ValidarCamposRubro(string codigo, string nombre)
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
            txtIdRubro.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaRubro();
        }

        private void CargarGrillaRubro()
        {
            objLRubro = new LRubro();
            lstRubros = objLRubro.Consultar();
            Session["RubrosCompletos"] = lstRubros;
            Session["RubrosFiltrados"] = lstRubros;
            grdRubro.DataSource = lstRubros;
            grdRubro.DataBind();

            if (grdRubro.HeaderRow != null)
            {
                grdRubro.UseAccessibleHeader = true;
                grdRubro.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaRubro();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaRubro();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdRubro.Text = grdRubro.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdRubro.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdRubro.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdRubro.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaRubro();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idRubro = (sender as LinkButton).CommandArgument;
            CargarGrillaRubro();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idRubro}');", true);
        }
    }
}
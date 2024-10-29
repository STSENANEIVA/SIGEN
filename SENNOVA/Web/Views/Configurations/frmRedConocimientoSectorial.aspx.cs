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
    public partial class frmRedConocimientoSectorial : System.Web.UI.Page
    {
        LRedConocimientoSectorial objLRedConocimientoSectorial = new LRedConocimientoSectorial();
        List<RedConocimientoSectorial> lstRedConocimientoSectorials;
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
            Response.Redirect("~/Views/Configurations/frmRedConocimientoSectorial.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del RedConocimientoSectorial
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el RedConocimientoSectorial
                bool RedConocimientoSectorialvalidado = ValidarCamposRedConocimientoSectorial(codigo, nombre);

                if (!RedConocimientoSectorialvalidado)
                {
                    CargarGrillaRedConocimientoSectorial();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el RedConocimientoSectorial y retorno el numero
                int idRedConocimientoSectorial = GuardarRedConocimientoSectorial(codigo, nombre, activo);
                txtIdRedConocimientoSectorial.Text = idRedConocimientoSectorial.ToString();
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
            CargarGrillaRedConocimientoSectorial();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarRedConocimientoSectorial(string codigo, string nombre, bool activo)
        {
            LRedConocimientoSectorial objLRedConocimientoSectorial = new LRedConocimientoSectorial();
            RedConocimientoSectorial objRedConocimientoSectorial = new RedConocimientoSectorial();
            string id = txtIdRedConocimientoSectorial.Text.Trim();
            int idRedConocimientoSectorial;
            if (string.IsNullOrEmpty(id))
            {
                objRedConocimientoSectorial = objLRedConocimientoSectorial.Guardar(codigo, nombre);
            }
            else
            {
                idRedConocimientoSectorial = Int32.Parse(id);
                objRedConocimientoSectorial = objLRedConocimientoSectorial.Actualizar(idRedConocimientoSectorial, codigo, nombre, activo);
            }
            return objRedConocimientoSectorial.Id;
        }

        private bool ValidarCamposRedConocimientoSectorial(string codigo, string nombre)
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
            txtIdRedConocimientoSectorial.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaRedConocimientoSectorial();
        }

        private void CargarGrillaRedConocimientoSectorial()
        {
            objLRedConocimientoSectorial = new LRedConocimientoSectorial();
            lstRedConocimientoSectorials = objLRedConocimientoSectorial.Consultar();
            Session["RedConocimientoSectorialsCompletos"] = lstRedConocimientoSectorials;
            Session["RedConocimientoSectorialsFiltrados"] = lstRedConocimientoSectorials;
            grdRedConocimientoSectorial.DataSource = lstRedConocimientoSectorials;
            grdRedConocimientoSectorial.DataBind();
            if (grdRedConocimientoSectorial.HeaderRow != null)
            {
                grdRedConocimientoSectorial.UseAccessibleHeader = true;
                grdRedConocimientoSectorial.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaRedConocimientoSectorial();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaRedConocimientoSectorial();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdRedConocimientoSectorial_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdRedConocimientoSectorial.Text = grdRedConocimientoSectorial.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdRedConocimientoSectorial.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdRedConocimientoSectorial.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdRedConocimientoSectorial.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaRedConocimientoSectorial();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idRedConocimientoSectorial = (sender as LinkButton).CommandArgument;
                LRedConocimientoSectorial objLRedConocimientoSectorial = new LRedConocimientoSectorial();
                RedConocimientoSectorial RedConocimientoSectorial = objLRedConocimientoSectorial.Consultar(int.Parse(idRedConocimientoSectorial));
                LProyecto objLProyecto = new LProyecto();
                Proyecto objProyecto = objLProyecto.ConsultarPorRedConocimientoSectorial(RedConocimientoSectorial.Id);

                if (objProyecto.Id == 0)
                {
                    objLRedConocimientoSectorial.Eliminar(int.Parse(idRedConocimientoSectorial));
                    CargarGrillaRedConocimientoSectorial();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaRedConocimientoSectorial();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    string message = $"El RedConocimientoSectorial {RedConocimientoSectorial.Nombre} no se puede Eliminar, ya que se encuentra asociado a un Producto";
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
            CargarGrillaRedConocimientoSectorial();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }
    }
}
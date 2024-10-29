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
    public partial class frmAccesorios : System.Web.UI.Page
    {
        LAccesorios objLAccesorios = new LAccesorios();
        List<Accesorios> lstAccesorioss;
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
            Response.Redirect("~/Views/Configurations/frmAccesorios.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Accesorios
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el Accesorios
                bool Accesoriosvalidado = ValidarCamposAccesorios(codigo, nombre, descripcion);

                if (!Accesoriosvalidado)
                {
                    CargarGrillaAccesorios();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Accesorios y retorno el numero
                int idAccesorios = GuardarAccesorios(codigo, nombre, descripcion, activo);
                txtIdAccesorios.Text = idAccesorios.ToString();
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
            CargarGrillaAccesorios();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarAccesorios(string codigo, string nombre, string descripcion, bool activo)
        {
            LAccesorios objLAccesorios = new LAccesorios();
            Accesorios objAccesorios = new Accesorios();
            string id = txtIdAccesorios.Text.Trim();
            int idAccesorios;
            if (string.IsNullOrEmpty(id))
            {
                objAccesorios = objLAccesorios.Guardar(codigo, nombre, descripcion);
            }
            else
            {
                idAccesorios = Int32.Parse(id);
                objAccesorios = objLAccesorios.Actualizar(idAccesorios, codigo, nombre, descripcion, activo);
            }
            return objAccesorios.Id;
        }

        private bool ValidarCamposAccesorios(string codigo, string nombre, string descripcion)
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
            if (String.IsNullOrEmpty(descripcion))
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
            txtIdAccesorios.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaAccesorios();
        }

        private void CargarGrillaAccesorios()
        {
            objLAccesorios = new LAccesorios();
            lstAccesorioss = objLAccesorios.Consultar();
            Session["AccesoriossCompletos"] = lstAccesorioss;
            Session["AccesoriossFiltrados"] = lstAccesorioss;
            grdAccesorios.DataSource = lstAccesorioss;
            grdAccesorios.DataBind();

            if (grdAccesorios.HeaderRow != null)
            {
                grdAccesorios.UseAccessibleHeader = true;
                grdAccesorios.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaAccesorios();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaAccesorios();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdAccesorios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdAccesorios.Text = grdAccesorios.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdAccesorios.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdAccesorios.SelectedRow.Cells[2].Text).Trim();
                txtDescripcion.Text = HttpUtility.HtmlDecode(grdAccesorios.SelectedRow.Cells[3].Text).Trim();
                CheckBox chk = grdAccesorios.SelectedRow.Cells[4].Controls[0] as CheckBox;
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
            CargarGrillaAccesorios();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idAccesorios = (sender as LinkButton).CommandArgument;
            CargarGrillaAccesorios();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idAccesorios}');", true);
            
        }
    }
}
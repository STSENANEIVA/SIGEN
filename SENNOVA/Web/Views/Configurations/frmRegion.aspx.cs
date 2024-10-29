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
    public partial class frmRegion : System.Web.UI.Page
    {
        LRegion objLRegion = new LRegion();
        LRegional objLRegional = new LRegional();
        List<Region> lstRegions;
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
            Response.Redirect("~/Views/Configurations/frmRegion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Region
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el Region
                bool Regionvalidado = ValidarCamposRegion(codigo, nombre);

                if (!Regionvalidado)
                {
                    CargarGrillaRegion();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Region y retorno el numero
                int idRegion = GuardarRegion(codigo, nombre, activo);
                txtIdRegion.Text = idRegion.ToString();
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
            CargarGrillaRegion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarRegion(string codigo, string nombre, bool activo)
        {
            LRegion objLRegion = new LRegion();
            Region objRegion = new Region();
            string id = txtIdRegion.Text.Trim();
            int idRegion;
            if (string.IsNullOrEmpty(id))
            {
                objRegion = objLRegion.Guardar(codigo, nombre);
            }
            else
            {
                idRegion = Int32.Parse(id);
                objRegion = objLRegion.Actualizar(idRegion, codigo, nombre, activo);
            }
            return objRegion.Id;
        }

        private bool ValidarCamposRegion(string codigo, string nombre)
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
            txtIdRegion.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaRegion();
        }

        private void CargarGrillaRegion()
        {
            objLRegion = new LRegion();
            lstRegions = objLRegion.Consultar();
            Session["RegionsCompletos"] = lstRegions;
            Session["RegionsFiltrados"] = lstRegions;
            grdRegion.DataSource = lstRegions;
            grdRegion.DataBind();
            if (grdRegion.HeaderRow != null)
            {
                grdRegion.UseAccessibleHeader = true;
                grdRegion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaRegion();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaRegion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdRegion.Text = grdRegion.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdRegion.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdRegion.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdRegion.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaRegion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idRegion = (sender as LinkButton).CommandArgument;
                LRegion objLRegion = new LRegion();
                Region Region = objLRegion.Consultar(int.Parse(idRegion));
                Regional objRegional = objLRegional.ConsultarPorRegion(Region.Id);

                if (objRegional.Id == 0)
                {
                    objLRegion.Eliminar(int.Parse(idRegion));
                    CargarGrillaRegion();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaRegion();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    string message = $"El Region {Region.Nombre} no se puede Eliminar, ya que se encuentra asociado a un Producto";
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
            CargarGrillaRegion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }
    }
}
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
    public partial class frmServicio : System.Web.UI.Page
    {
        LServicio objLServicio = new LServicio();
        List<Servicio> lstServicios;
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
            Response.Redirect("~/Views/Configurations/frmServicio.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Servicio
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string idAreaTecnica = ddlAreaTecnica.SelectedValue;
                string precio = txtPrecio.Text;
                string requisitos = txtRequisitos.Text.Trim();
                string alcance = txtAlcance.Text.Trim();
                bool activo = chkActivo.Checked;
                string idFamilia = ddlFamilia.SelectedValue;

                //validar el Servicio
                bool Serviciovalidado = ValidarCamposServicio(codigo, nombre, idAreaTecnica, idFamilia);

                if (!Serviciovalidado)
                {
                    CargarGrillaServicio();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Servicio y retorno el numero
                int idServicio = GuardarServicio(codigo, nombre, requisitos, alcance, precio, activo, idAreaTecnica, idFamilia);
                txtIdServicio.Text = idServicio.ToString();
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
            CargarGrillaServicio();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarServicio(string codigo, string nombre, string requisitos, string alcance, string precio, bool activo, string idAreaTecnica, string idFamilia)
        {
            LServicio objLServicio = new LServicio();
            Servicio objServicio = new Servicio();
            string id = txtIdServicio.Text.Trim();
            int idServicio;
            if (string.IsNullOrEmpty(id))
            {
                objServicio = objLServicio.Guardar(codigo, nombre, requisitos, alcance, decimal.Parse(precio), int.Parse(idAreaTecnica), int.Parse(idFamilia));
            }
            else
            {
                idServicio = Int32.Parse(id);
                objServicio = objLServicio.Actualizar(idServicio, codigo, nombre, activo, requisitos, alcance, decimal.Parse(precio), int.Parse(idAreaTecnica), int.Parse(idFamilia));
            }
            return objServicio.Id;
        }

        private bool ValidarCamposServicio(string codigo, string nombre, string idAreaTecnica, string idFamilia)
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
            if (String.IsNullOrEmpty(nombre))
            {
                camposFaltantes = camposFaltantes + ", " + "nombre";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idAreaTecnica.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "AreaTecnica";
                resultado = false;
            }

            if (String.IsNullOrEmpty(idFamilia.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Familia";
                resultado = false;
            }

            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdServicio.Text = "";
            txtRequisitos.Text = "";
            txtAlcance.Text = "";
            chkActivo.Checked = false;
        }

        private void CargarControles()
        {
            CargarGrillaServicio();           
            CargarAreaTecnicas();
            CargarFamilia();
        }
        private void CargarAreaTecnicas()
        {

            LAreaTecnica objLAreaTecnica = new LAreaTecnica();
            ddlAreaTecnica.DataSource = objLAreaTecnica.Consultar();
            ddlAreaTecnica.DataTextField = "NombreSin";
            ddlAreaTecnica.DataValueField = "id";
            ddlAreaTecnica.DataBind();
            //ddlAreaTecnica.Items.Add(new ListItem("Seleccione", "0"));
            //ddlAreaTecnica.SelectedValue = "0";
        }

        private void CargarFamilia()
        {

            LFamilia objLFamilia = new LFamilia();
            ddlFamilia.DataSource = objLFamilia.Consultar();
            ddlFamilia.DataTextField = "Nombre";
            ddlFamilia.DataValueField = "id";
            ddlFamilia.DataBind();

            //ddlFamilia.Items.Add(new ListItem("Seleccione", "0"));
            //ddlFamilia.SelectedValue = "0";
        }

        private void CargarGrillaServicio()
        {
            objLServicio = new LServicio();
            lstServicios = objLServicio.Consultar();
            Session["ServiciosCompletos"] = lstServicios;
            Session["ServiciosFiltrados"] = lstServicios;
            grdServicio.DataSource = lstServicios;
            grdServicio.DataBind();
            if (grdServicio.HeaderRow != null)
            {
                grdServicio.UseAccessibleHeader = true;
                grdServicio.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaServicio();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaServicio();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdServicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdServicio.Text = grdServicio.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdServicio.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdServicio.SelectedRow.Cells[2].Text).Trim();
                string tipoArea = HttpUtility.HtmlDecode(grdServicio.SelectedRow.Cells[3].Text).Trim();
                ddlAreaTecnica.ClearSelection();
                ddlAreaTecnica.SelectedValue = ddlAreaTecnica.Items.FindByText(tipoArea).Value;
                txtAlcance.Text = HttpUtility.HtmlDecode(grdServicio.SelectedRow.Cells[4].Text).Trim();
                txtRequisitos.Text = HttpUtility.HtmlDecode(grdServicio.SelectedRow.Cells[5].Text).Trim();
                //string tipoFamilia = HttpUtility.HtmlDecode(grdServicio.SelectedRow.Cells[6].Text);
                //ddlFamilia.ClearSelection();
                //ddlFamilia.SelectedValue = ddlFamilia.Items.FindByText(tipoFamilia).Value;
                txtPrecio.Text = grdServicio.SelectedRow.Cells[7].Text;
                CheckBox chk = grdServicio.SelectedRow.Cells[8].Controls[0] as CheckBox;
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
            CargarGrillaServicio();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idServicio = (sender as LinkButton).CommandArgument;
            CargarGrillaServicio();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idServicio}');", true);
        }
    }
}
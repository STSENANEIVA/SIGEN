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
    public partial class frmEmpresa : System.Web.UI.Page
    {
        LEmpresa objLEmpresa = new LEmpresa();
        LTipoDocumento objLTipoDocumento = new LTipoDocumento();
        List<Empresa> lstEmpresas;
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
            Response.Redirect("~/Views/Configurations/frmEmpresa.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Empresa
                string razonSocial = txtRazonSocial.Text.Trim();
                string nit = txtNit.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();

                int idSectorEconomico = int.Parse(ddlSectorEconomico.SelectedValue);


                //validar el Empresa
                bool Empresavalidado = ValidarCamposEmpresa(razonSocial, nit, telefono, email, idSectorEconomico);
                if (!Empresavalidado)
                {
                    CargarGrillaEmpresa();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }
                if (email.Contains("@") && email.Contains(".com") || email.Contains("@") && email.Contains(".com.co") || email.Contains("@") && email.Contains(".edu.co"))
                {
                    //guardo el Empresa y retorno el numero
                    int idEmpresa = GuardarEmpresa(razonSocial, nit, telefono, email, idSectorEconomico);

                    txtIdEmpresa.Text = idEmpresa.ToString();
                    PantallaGuardado();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaEmpresa();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    string message = "Dirección de correo electrónico no válida";
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
            CargarGrillaEmpresa();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarEmpresa(string razonSocial, string nit, string telefono, string email, int idSectorEconomico)
        {
            LEmpresa objLEmpresa = new LEmpresa();
            Empresa objEmpresa = new Empresa();
            string id = txtIdEmpresa.Text.Trim();
            int idEmpresa;
            if (string.IsNullOrEmpty(id))
            {
                objEmpresa = objLEmpresa.Guardar(razonSocial, nit, telefono, email, idSectorEconomico);
            }
            else
            {
                idEmpresa = Int32.Parse(id);
                objEmpresa = objLEmpresa.Actualizar(idEmpresa, razonSocial, nit, telefono, email, idSectorEconomico);
            }
            return objEmpresa.Id;
        }

        private bool ValidarCamposEmpresa(string razonSocial, string nit, string telefono, string email, int idSectorEconomico)
        {
            bool resultado = true;

            if (String.IsNullOrEmpty(razonSocial))
            {
                camposFaltantes = camposFaltantes + ", " + "Nombres";
                resultado = false;
            }
            if (String.IsNullOrEmpty(nit))
            {
                camposFaltantes = camposFaltantes + ", " + "RazonSocial";
                resultado = false;
            }
            if (String.IsNullOrEmpty(telefono))
            {
                camposFaltantes = camposFaltantes + ", " + "Telefono";
                resultado = false;
            }
            if (String.IsNullOrEmpty(email))
            {
                camposFaltantes = camposFaltantes + ", " + "Email";
                resultado = false;
            }
          
            
            if (String.IsNullOrEmpty(idSectorEconomico.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "TipoDocumento";
                resultado = false;
            }
        
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtRazonSocial.Text = "";
            txtNit.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            ddlSectorEconomico.SelectedValue = "0";
            txtIdEmpresa.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaEmpresa();
            CargarSectorEconomico();
        }

        private void CargarSectorEconomico()
        {

            LSectorEconomico objLSectorEconomico = new LSectorEconomico();
            ddlSectorEconomico.DataSource = objLSectorEconomico.Consultar();
            ddlSectorEconomico.DataTextField = "Nombre";
            ddlSectorEconomico.DataValueField = "id";
            ddlSectorEconomico.DataBind();
            ddlSectorEconomico.Items.Add(new ListItem("Seleccione", "0"));
            ddlSectorEconomico.SelectedValue = "0";
        }


        private void CargarGrillaEmpresa()
        {
            LEmpresa objLEmpresa = new LEmpresa();
            lstEmpresas = objLEmpresa.Consultar();
            Session["EmpresasCompletos"] = lstEmpresas;
            Session["EmpresasFiltrados"] = lstEmpresas;
            grdEmpresa.DataSource = lstEmpresas;
            grdEmpresa.DataBind();

            if (grdEmpresa.HeaderRow != null)
            {
                grdEmpresa.UseAccessibleHeader = true;
                grdEmpresa.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaEmpresa();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaEmpresa();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }


        protected void grdEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdEmpresa.Text = grdEmpresa.SelectedRow.Cells[0].Text;
                txtNit.Text = HttpUtility.HtmlDecode(grdEmpresa.SelectedRow.Cells[1].Text).Trim();
                txtRazonSocial.Text = HttpUtility.HtmlDecode(grdEmpresa.SelectedRow.Cells[2].Text).Trim();
                txtTelefono.Text = HttpUtility.HtmlDecode(grdEmpresa.SelectedRow.Cells[3].Text).Trim();
                txtEmail.Text = HttpUtility.HtmlDecode(grdEmpresa.SelectedRow.Cells[4].Text).Trim();
                string sectorEconomico = HttpUtility.HtmlDecode(grdEmpresa.SelectedRow.Cells[5].Text);
                ddlSectorEconomico.ClearSelection();
                ddlSectorEconomico.SelectedValue = ddlSectorEconomico.Items.FindByText(sectorEconomico).Value;

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaEmpresa();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idEmpresa = (sender as LinkButton).CommandArgument;
            CargarGrillaEmpresa();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idEmpresa}');", true);
        }

        protected void txtNit_TextChanged(object sender, EventArgs e)
        {
            try
            {
              
                string nit = txtNit.Text.Trim();

                LEmpresa objLEmpresa = new LEmpresa();
                Empresa empresa = objLEmpresa.Consultar(nit);
                if (empresa.Id != 0)
                {
                    txtNit.Text = empresa.Nit;
                    txtRazonSocial.Text = empresa.RazonSocial;
                    txtTelefono.Text = empresa.Telefono;
                    txtEmail.Text = empresa.Email;
                    txtIdEmpresa.Text = empresa.Id.ToString();
                    ddlSectorEconomico.SelectedValue = ddlSectorEconomico.Items.FindByText(empresa.SectorEconomico.Nombre).Value;
                }
                txtRazonSocial.Focus();
            }
            catch (Exception)
            {

                throw;
            }
            CargarGrillaEmpresa();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }
    }
}
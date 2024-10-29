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
    public partial class frmPersonal : System.Web.UI.Page
    {
        LPersona objLPersona = new LPersona();
        LTipoDocumento objLTipoDocumento = new LTipoDocumento();
        List<Empleado> lstEmpleados;
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
            Response.Redirect("~/Views/Configurations/frmPersonal.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Persona
                string nombres = txtNombres.Text.Trim();
                string apellidos = txtApellidos.Text.Trim();
                string numeroIdentificacion = txtNumeroIdentificacion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();
                string emailLaboral = txtEmailLaboral.Text.Trim();
                string telefonoLaboral = txtTelefonoLaboral.Text.Trim();
                string ip = txtIp.Text.Trim();

                int idTipoDocumento = int.Parse(ddlTipoDocumento.SelectedValue);
                int idRolSennova = int.Parse(ddlRolSennova.SelectedValue);
                int idCargo = int.Parse(ddlCargo.SelectedValue);


                //validar el Persona
                bool Personavalidado = ValidarCamposPersona(nombres, apellidos, numeroIdentificacion, telefono, email, idTipoDocumento);

                if (!Personavalidado)
                {
                    CargarGrillaEmpleados();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                if (email.Contains("@") && email.Contains(".com") || email.Contains("@") && email.Contains(".com.co") || email.Contains("@") && email.Contains(".edu.co") && emailLaboral.Contains("@") && emailLaboral.Contains(".com") || emailLaboral.Contains("@") && emailLaboral.Contains(".com.co") || emailLaboral.Contains("@") && emailLaboral.Contains(".edu.co"))
                {
                    //guardo el Persona y retorno el numero
                    int idPersona = GuardarPersona(nombres, apellidos, numeroIdentificacion, telefono, email, idTipoDocumento);
                    //guada el empleado 
                    LEmpleado objLEmpleado = new LEmpleado();
                    Empleado empleado = GuardarEmpleado(emailLaboral, telefonoLaboral, ip, idRolSennova, idPersona, idCargo);
                    txtIdPersona.Text = idPersona.ToString();
                    PantallaGuardado();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaEmpleados();
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
            CargarGrillaEmpleados();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarPersona(string nombres, string apellidos, string numeroIdentificacion, string telefono, string email, int idTipoDocumento)
        {
            LPersona objLPersona = new LPersona();
            Persona objPersona = new Persona();
            string id = txtIdPersona.Text.Trim();
            int idPersona;
            if (string.IsNullOrEmpty(id))
            {
                objPersona = objLPersona.Guardar(nombres, apellidos, numeroIdentificacion, telefono, email, idTipoDocumento);
            }
            else
            {
                idPersona = Int32.Parse(id);
                objPersona = objLPersona.Actualizar(idPersona, nombres, apellidos, numeroIdentificacion, telefono, email, idTipoDocumento);
            }
            return objPersona.Id;
        }

        private Empleado GuardarEmpleado(string emailLaboral, string telefonoLaboral, string ip, int idRolSennova, int idPersona, int idCargo)
        {
            LEmpleado objLEmpleado = new LEmpleado();
            Empleado objEmpleado = new Empleado();
            string id = txtIdEmpleado.Text.Trim();
            int idEmpleado;
            if (string.IsNullOrEmpty(id))
            {
                objEmpleado = objLEmpleado.Guardar(emailLaboral, telefonoLaboral, ip, idRolSennova, idPersona, idCargo);
            }
            else
            {
                idEmpleado = Int32.Parse(id);
                objEmpleado = objLEmpleado.Actualizar(idEmpleado, emailLaboral, telefonoLaboral, ip, idRolSennova, idPersona, idCargo);
            }
            return objEmpleado;
        }

        private bool ValidarCamposPersona(string nombres, string apellidos, string numeroIdentificacion, string telefono, string email, int idTipoDocumento)
        {
            bool resultado = true;

            if (String.IsNullOrEmpty(nombres))
            {
                camposFaltantes = camposFaltantes + ", " + "Nombres";
                resultado = false;
            }
            if (String.IsNullOrEmpty(apellidos))
            {
                camposFaltantes = camposFaltantes + ", " + "Apellidos";
                resultado = false;
            }
            if (String.IsNullOrEmpty(numeroIdentificacion))
            {
                camposFaltantes = camposFaltantes + ", " + "Numero de Identificacion";
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


            if (String.IsNullOrEmpty(idTipoDocumento.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "TipoDocumento";
                resultado = false;
            }

            return resultado;
        }

        private void LimpiarCampos()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtNumeroIdentificacion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtEmailLaboral.Text = "";
            txtIp.Text = "";
            ddlRolSennova.SelectedValue = "0";
            txtIdPersona.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaEmpleados();
            CargarTipoDocumentos();
            CargarRolesSennova();
            CargarCargos();
        }

        private void CargarCargos()
        {

            LCargo objLCargo = new LCargo();
            ddlCargo.DataSource = objLCargo.Consultar();
            ddlCargo.DataTextField = "Nombre";
            ddlCargo.DataValueField = "id";
            ddlCargo.DataBind();
            ddlCargo.Items.Add(new ListItem("Seleccione", "0"));
            ddlCargo.SelectedValue = "0";
        }

        private void CargarTipoDocumentos()
        {

            objLTipoDocumento = new LTipoDocumento();
            ddlTipoDocumento.DataSource = objLTipoDocumento.Consultar();
            ddlTipoDocumento.DataTextField = "Nombre";
            ddlTipoDocumento.DataValueField = "id";
            ddlTipoDocumento.DataBind();
            //ddlTipoDocumento.Items.Add(new ListItem("Seleccione", "0"));
            //ddlTipoDocumento.SelectedValue = "0";
        }

        private void CargarRolesSennova()
        {

            LRolSennova objLRolSennova = new LRolSennova();
            ddlRolSennova.DataSource = objLRolSennova.Consultar();
            ddlRolSennova.DataTextField = "Nombre";
            ddlRolSennova.DataValueField = "id";
            ddlRolSennova.DataBind();
            ddlRolSennova.Items.Add(new ListItem("Seleccione", "0"));
            ddlRolSennova.SelectedValue = "0";
        }

        private void CargarGrillaEmpleados()
        {
            LEmpleado objLEmpleado = new LEmpleado();
            lstEmpleados = objLEmpleado.Consultar();
            Session["PersonasCompletos"] = lstEmpleados;
            Session["PersonasFiltrados"] = lstEmpleados;
            grdPersona.DataSource = lstEmpleados;
            grdPersona.DataBind();
            if (grdPersona.HeaderRow != null)
            {
                grdPersona.UseAccessibleHeader = true;
                grdPersona.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaEmpleados();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaEmpleados();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdEmpleado.Text = grdPersona.SelectedRow.Cells[0].Text;
                txtIdPersona.Text = grdPersona.SelectedRow.Cells[12].Text;
                string tipoDocumento = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[2].Text.Trim());
                ddlTipoDocumento.ClearSelection();
                ddlTipoDocumento.SelectedValue = ddlTipoDocumento.Items.FindByText(tipoDocumento).Value;
                txtNumeroIdentificacion.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[3].Text).Trim();
                txtNombres.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[4].Text).Trim();
                txtApellidos.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[5].Text).Trim();
                txtTelefono.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[6].Text).Trim();
                txtEmail.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[7].Text).Trim();
                txtEmailLaboral.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[8].Text).Trim();
                txtIp.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[9].Text).Trim();
                string rolSennova = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[10].Text.Trim());
                if (!string.IsNullOrEmpty(rolSennova.Trim()))
                {
                    ddlRolSennova.ClearSelection();
                    ddlRolSennova.SelectedValue = ddlRolSennova.Items.FindByText(rolSennova).Value; 
                }
                string cargo = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[11].Text.Trim());
                if (!string.IsNullOrEmpty(cargo.Trim()))
                {
                    ddlCargo.ClearSelection();
                    ddlCargo.SelectedValue = ddlCargo.Items.FindByText(cargo).Value;
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
            CargarGrillaEmpleados();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idEmpleado = (sender as LinkButton).CommandArgument;
            CargarGrillaEmpleados();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idEmpleado}');", true);
        }

        protected void txtNumeroIdentificacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoIdentificacion = Int32.Parse(ddlTipoDocumento.SelectedValue);
                string numeroIdentificacion = txtNumeroIdentificacion.Text.Trim();

                LPersona objLPersona = new LPersona();
                Persona cliente = objLPersona.Consultar(idTipoIdentificacion, numeroIdentificacion);
                if (cliente.Id != 0)
                {
                    txtNombres.Text = cliente.Nombres;
                    txtApellidos.Text = cliente.Apellidos;
                    txtTelefono.Text = cliente.Telefono;
                    txtEmail.Text = cliente.Email;
                    txtIdPersona.Text = cliente.Id.ToString();
                }
                txtNombres.Focus();
            }
            catch (Exception)
            {

                throw;
            }
            CargarGrillaEmpleados();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }
    }
}
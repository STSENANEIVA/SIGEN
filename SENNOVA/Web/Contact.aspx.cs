using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Logic;
using Utilities;
using System.IO;
using Sendinblue;

namespace Web
{
    public partial class Contact : Page
    {
        LPersona objLPersona = new LPersona();
        LTipoDocumento objLTipoDocumento = new LTipoDocumento();
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
            Response.Redirect("~/Contact.aspx");
        }

      
        private void CargarControles()
        {
            CargarTipoDocumentos();
        }

        private void CargarTipoDocumentos()
        {

            LTipoDocumento objLTipoDocumento = new LTipoDocumento();
            ddlTipoDocumento.DataSource = objLTipoDocumento.Consultar();
            ddlTipoDocumento.DataTextField = "Nombre";
            ddlTipoDocumento.DataValueField = "id";
            ddlTipoDocumento.DataBind();
            //ddlTipoDocumento.Items.Add(new ListItem("Seleccione", "0"));
            //ddlTipoDocumento.SelectedValue = "0";
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
                string mensaje = txtMensaje.Text.Trim();

                int idTipoDocumento = int.Parse(ddlTipoDocumento.SelectedValue);

                //validar el Persona
                bool Personavalidado = ValidarCamposPersona(nombres, apellidos, numeroIdentificacion, telefono, email, idTipoDocumento, mensaje);

                if (!Personavalidado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "warningalert();", true);
                }
                else
                {

                    string[] datos = new string[6]{ nombres , apellidos, numeroIdentificacion, telefono, email, mensaje };
                    _ = Sendinblue.Program.Main(datos);
                    PantallaGuardado();
                }

            }
            catch (ApplicationException exe)
            {
                advertencia.Visible = true;
                txtMensajeAdvertencia.Text = exe.Message;
            }
            catch (Exception exe)
            {
                error.Visible = true;
                txtMensajeError.Text = exe.Message;
            }
        }

        private bool ValidarCamposPersona(string nombres, string apellidos, string numeroIdentificacion, string telefono, string email, int idTipoDocumento, string mensaje)
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

            if (String.IsNullOrEmpty(mensaje))
            {
                camposFaltantes = camposFaltantes + ", " + "Mensaje";
                resultado = false;
            }

            return resultado;
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                OcultarMessage();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert();", true);
                //correcto.Visible = true;
                //txtMensajeCorrecto.Text = Message.CorreoEnviado;
            }
            catch (ApplicationException exe)
            {
                advertencia.Visible = true;
                txtMensajeAdvertencia.Text = exe.Message;
            }
            catch (Exception exe)
            {
                error.Visible = true;
                txtMensajeError.Text = exe.Message;
            }
        }

        private void OcultarMessage()
        {
            correcto.Visible = false;
            advertencia.Visible = false;
            error.Visible = false;
        }

        private void LimpiarCampos()
        {
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtNumeroIdentificacion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtMensaje.Text = "";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Logic;
using Utilities;
using System.Text.RegularExpressions;

namespace Web.Views.Configurations
{
    public partial class frmIngresos : System.Web.UI.Page
    {
        LPersona objLPersona = new LPersona();
        LTipoDocumento objLTipoDocumento = new LTipoDocumento();
        LEmpleado objLEmpleado = new LEmpleado();
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
            Response.Redirect("~/Views/GetInto/frmIngresos.aspx");
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

                int idTipoDocumento = int.Parse(ddlTipoDocumento.SelectedValue);

                //validar el Persona
                bool Personavalidado = ValidarCamposPersona(nombres, apellidos, numeroIdentificacion, telefono, email,  idTipoDocumento);

                if (!Personavalidado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                if (email.Contains("@") && email.Contains(".com") || email.Contains("@") && email.Contains(".com.co") || email.Contains("@") && email.Contains(".edu.co") || email.Contains("@") && email.Contains(".es"))
                {
                    //guardo el Persona y retorno el numero
                    int idPersona = GuardarPersona(nombres, apellidos, numeroIdentificacion, telefono, email, idTipoDocumento);
                    //consultamos si ya existe registrado el visitante con esta persona
                    LVisitante objLVisitante = new LVisitante();
                    Visitante visitante = objLVisitante.ConsultarPorPersona(idPersona);
                    int idTipoVisitante = int.Parse(ddlTipoVisitante.SelectedValue);
                    if (visitante.Id == 0)
                    {
                        visitante = objLVisitante.Guardar(idPersona, idTipoVisitante);
                    }

                    bool aceptaPolitica = chkPolitica.Checked;
                    string ficha = txtFicha.Text.Trim();
                    int idEmpresa = int.Parse(ddlEmpresa.SelectedValue);
                    int idProgramaFormacion = int.Parse(ddlProgramaFormacion.SelectedValue);
                    Empleado empleado = objLEmpleado.ConsultarPorEmailLaboral(HttpContext.Current.User.Identity.Name);
                    LIngreso objLIngreso = new LIngreso();
                    Ingreso ingreso = objLIngreso.Guardar(DateTime.Now, aceptaPolitica, ficha, visitante.Id, idEmpresa, idProgramaFormacion, empleado.Id);


                    //obtenemos las areas tecnicas visitadas
                    List<AreaTecnica> lstAreaTecnicas = new List<AreaTecnica>();
                    lstAreaTecnicas = ObtenerAreasTecnicasSeleccionadas();
                    GuardarIngresosAreasTecnicas(lstAreaTecnicas, ingreso.Id);

                    txtIdPersona.Text = idPersona.ToString();
                    PantallaGuardado();
                }
                else
                {
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
        }

        private void GuardarIngresosAreasTecnicas(List<AreaTecnica> lstAreaTecnicas, int idIngreso)
        {
            try
            {
                LIngresosAreasTecnicas objLIngresosAreasTecnicas = new LIngresosAreasTecnicas();
                foreach (var item in lstAreaTecnicas)
                {
                    objLIngresosAreasTecnicas.Guardar(item.Id, idIngreso);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private List<AreaTecnica> ObtenerAreasTecnicasSeleccionadas()
        {
            try
            {
                LAreaTecnica objLAreaTecnica = new LAreaTecnica();
                List<AreaTecnica> lstAreaTecnicas = new List<AreaTecnica>();
                foreach (ListItem item in chklAreasTecnicas.Items)
                {
                    if (item.Selected)
                    {
                        string acomodado = item.Value.Replace(" &nbsp;", "");
                        AreaTecnica areaTecnica = objLAreaTecnica.ConsultarNombre(HttpUtility.HtmlDecode(acomodado));
                        lstAreaTecnicas.Add(areaTecnica);
                    }
                }
                return lstAreaTecnicas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private int GuardarPersona(string nombres, string apellidos, string numeroIdentificacion, string telefono, string email,  int idTipoDocumento)
        {
            LPersona objLPersona = new LPersona();
            Persona objPersona = new Persona();
            string id = txtIdPersona.Text.Trim();
            int idPersona;
            if (string.IsNullOrEmpty(id) || id == "0")
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
            txtIdPersona.Text = "";
            txtFicha.Text = "";
            ddlTipoVisitante.SelectedValue = "0";
            ddlProgramaFormacion.SelectedValue = "0";
            chklAreasTecnicas.ClearSelection();
            chkPolitica.Checked = false;
        }

        private void CargarControles()
        {
            CargarTipoDocumentos();
            CargarTipoVisitantes();
            CargarEmpresa();
            CargarProgramaFormacion();
            CargarAreasTecnicas();
            Aprendiz1.Visible = false;
            Aprendiz2.Visible = false;
        }

        private void CargarAreasTecnicas()
        {
            LAreaTecnica objLAreaTecnica = new LAreaTecnica();
            chklAreasTecnicas.DataSource = objLAreaTecnica.Consultar();
            chklAreasTecnicas.DataTextField = "Nombre";
            chklAreasTecnicas.DataBind();
        }

        private void CargarEmpresa()
        {
            LEmpresa objLEmpresa = new LEmpresa();
            ddlEmpresa.DataSource = objLEmpresa.Consultar();
            ddlEmpresa.DataTextField = "RazonSocial";
            ddlEmpresa.DataValueField = "id";
            ddlEmpresa.DataBind();
        }
        private void CargarProgramaFormacion()
        {
            LProgramaFormacion objLProgramaFormacion = new LProgramaFormacion();
            ddlProgramaFormacion.DataSource = objLProgramaFormacion.Consultar();
            ddlProgramaFormacion.DataTextField = "Nombre";
            ddlProgramaFormacion.DataValueField = "id";
            ddlProgramaFormacion.DataBind();
            ddlProgramaFormacion.Items.Add(new ListItem("Seleccione", "0"));
            ddlProgramaFormacion.SelectedValue = "0";
        }

        private void CargarTipoVisitantes()
        {

            LTipoVisitante objLTipoVisitante = new LTipoVisitante();
            ddlTipoVisitante.DataSource = objLTipoVisitante.Consultar();
            ddlTipoVisitante.DataTextField = "Nombre";
            ddlTipoVisitante.DataValueField = "id";
            ddlTipoVisitante.DataBind();
            ddlTipoVisitante.Items.Add(new ListItem("Seleccione", "0"));
            ddlTipoVisitante.SelectedValue = "0";
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

      
        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
        }


        protected void txtNumeroIdentificacion_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoIdentificacion = Int32.Parse(ddlTipoDocumento.SelectedValue);
                string numeroIdentificacion = txtNumeroIdentificacion.Text.Trim();

                LPersona objLPersona = new LPersona();
                Persona visitante = objLPersona.Consultar(idTipoIdentificacion, numeroIdentificacion);
                if (visitante.Id != 0)
                {
                    txtNombres.Text = visitante.Nombres;
                    txtApellidos.Text = visitante.Apellidos;
                    txtTelefono.Text = visitante.Telefono;
                    txtEmail.Text = visitante.Email;
                    txtIdPersona.Text = visitante.Id.ToString();
                }
                txtNombres.Focus();
                txtIdPersona.Text = visitante.Id.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlTipoVisitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipoVisitante = Int32.Parse(ddlTipoVisitante.SelectedValue);
                string codigoVisitanteAprendiz = ConfigGeneric.CodigoVisitanteAprendiz;
                if (idTipoVisitante == int.Parse(codigoVisitanteAprendiz)) {
                    Aprendiz1.Visible = true;
                    Aprendiz2.Visible = true;
                }
                else
                {
                    Aprendiz1.Visible = false;
                    Aprendiz2.Visible = false;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Logic;
using Utilities;
using SpreadsheetLight;
using System.IO;
using Web.Services;


namespace Web.Views.Configurations
{
    public partial class frmPersona : System.Web.UI.Page
    {
        LPersona objLPersona = new LPersona();
        LTipoDocumento objLTipoDocumento = new LTipoDocumento();
        List<Persona> lstPersonas;
        string camposFaltantes = "";
        List<Persona> lstPersona = new List<Persona>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarControles();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Configurations/frmPersona.aspx");
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
                bool Personavalidado = ValidarCamposPersona(nombres, apellidos, numeroIdentificacion, telefono, email, idTipoDocumento);

                if (!Personavalidado)
                {
                    CargarGrillaPersonas();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }
                if (email.Contains("@") && email.Contains(".com") || email.Contains("@") && email.Contains(".com.co") || email.Contains("@") && email.Contains(".edu.co"))
                {
                    //guardo el Persona y retorno el numero
                    int idPersona = GuardarPersona(nombres, apellidos, numeroIdentificacion, telefono, email, idTipoDocumento);
                    txtIdPersona.Text = idPersona.ToString();
                    PantallaGuardado();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaPersonas();
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
            CargarGrillaPersonas();
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
        }

        private void CargarControles()
        {
            CargarGrillaPersonas();
            CargarTipoDocumentos();
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

        private void CargarGrillaPersonas()
        {
            LPersona objLPersona = new LPersona();
            lstPersonas = objLPersona.Consultar();
            Session["PersonasCompletos"] = lstPersonas;
            Session["PersonasFiltrados"] = lstPersonas;
            grdPersona.DataSource = lstPersonas;
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
                CargarGrillaPersonas();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaPersonas();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);

        }

        protected void grdPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdPersona.Text = grdPersona.SelectedRow.Cells[0].Text;
                string tipoDocumento = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[2].Text.Trim());
                ddlTipoDocumento.ClearSelection();
                ddlTipoDocumento.SelectedValue = ddlTipoDocumento.Items.FindByText(tipoDocumento).Value;
                txtNumeroIdentificacion.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[3].Text).Trim();
                txtNombres.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[4].Text).Trim();
                txtApellidos.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[5].Text).Trim();
                txtTelefono.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[6].Text).Trim();
                txtEmail.Text = HttpUtility.HtmlDecode(grdPersona.SelectedRow.Cells[7].Text).Trim();
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaPersonas();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);

        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idPersona = (sender as LinkButton).CommandArgument;
            CargarGrillaPersonas();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idPersona}');", true);
        }

        protected void lnkCargarExcel_Click(object sender, EventArgs e)
        {
            cargarDataTables();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalCargarExcel", "$('#modalCargarExcel').modal('show');", true);
        }

        protected void lnkCerrarModal(object sender, EventArgs e)
        {
            cargarDataTables();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalCargarExcel", "$('#modalCargarExcel').modal('hide');", true);
            grdCargarExcel.DataBind();

            if (grdCargarExcel.HeaderRow != null)
            {
                grdCargarExcel.UseAccessibleHeader = true;
                grdCargarExcel.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTableExcel();", true);
        }

        protected void btnLeer_Click(object sender, EventArgs e)
        {
            if (upFile.HasFile)
            {
                string filename = Path.GetFileName(upFile.PostedFile.FileName);
                string filepath = Server.MapPath("~/Files/" + filename);
                upFile.SaveAs(filepath);

                SLDocument sl = new SLDocument(filepath);

                LTipoDocumento objLTipoDocumento = new LTipoDocumento();
                TipoDocumento objTipoDocumento = new TipoDocumento();
                LPersona objLPersona = new LPersona();
                Persona objPersona = new Persona();
                objPersona = objLPersona.ConsultarUltimoRegistro();

                int iRow = 2; int id = objPersona.Id + 1;

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    string tipoDocumento = sl.GetCellValueAsString(iRow, 1);
                    objTipoDocumento = objLTipoDocumento.ConsultarNombre(tipoDocumento);
                    string codigo = objLPersona.GenerarCodigo();
                    string numeroDocumento = sl.GetCellValueAsString(iRow, 2);
                    string nombres = sl.GetCellValueAsString(iRow, 3);
                    string apellidos = sl.GetCellValueAsString(iRow, 4);
                    string telefono = sl.GetCellValueAsString(iRow, 5);
                    string email = sl.GetCellValueAsString(iRow, 6);
                    
                    Persona persona = new Persona()
                    {
                        Id = id,
                        Codigo = codigo,
                        TipoDocumento = objTipoDocumento,
                        NumeroIdentificacion = numeroDocumento,
                        Nombres = nombres,
                        Apellidos = apellidos,
                        Telefono = telefono,
                        Email = email,
                    };

                    lstPersona.Add(persona);
                    iRow++; id++;
                }


                grdCargarExcel.DataSource = lstPersona;
                grdCargarExcel.DataBind();

                if (grdCargarExcel.HeaderRow != null)
                {
                    grdCargarExcel.UseAccessibleHeader = true;
                    grdCargarExcel.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                cargarDataTables();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalCargarExcel", "$('#modalCargarExcel').modal('show');", true);
            }
            else
            {
                string messaje = "Seleccione un archivo primero";
                cargarDataTables();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalCargarExcel", "$('#modalCargarExcel').modal('show');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{messaje}');", true);
            }

        }

        protected void btnGuardarExcel_Click(object sender, EventArgs e)
        {
            if (grdCargarExcel.HeaderRow != null)
            {

                for (int i = 0; i < grdCargarExcel.Rows.Count; i++)
                {
                    string codigo = grdCargarExcel.Rows[i].Cells[1].Text;
                    string tipoDocumento = grdCargarExcel.Rows[i].Cells[2].Text;
                    string numeroDocumento = HttpUtility.HtmlDecode(grdCargarExcel.Rows[i].Cells[3].Text).Trim();
                    string nombres = HttpUtility.HtmlDecode(grdCargarExcel.Rows[i].Cells[4].Text).Trim();
                    string apellidos = HttpUtility.HtmlDecode(grdCargarExcel.Rows[i].Cells[5].Text).Trim();
                    string telefono = HttpUtility.HtmlDecode(grdCargarExcel.Rows[i].Cells[6].Text).Trim();
                    string email = HttpUtility.HtmlDecode(grdCargarExcel.Rows[i].Cells[7].Text).Trim();

                    LPersona objLPersona = new LPersona();
                    Persona objPersona = new Persona();
                    objPersona = objLPersona.Consultar(codigo);
                    int idPersona = objPersona.Id;
                    LTipoDocumento objLTipoDocumento = new LTipoDocumento();
                    TipoDocumento objTipoDocumento = new TipoDocumento();
                    objTipoDocumento = objLTipoDocumento.ConsultarNombre(tipoDocumento);

                    if (objPersona.Codigo == null)
                    {
                        objPersona = objLPersona.Guardar(nombres, apellidos, numeroDocumento, telefono, email, objTipoDocumento.Id);
                    }
                    else
                    {
                        objPersona = objLPersona.Actualizar(idPersona, nombres, apellidos, numeroDocumento, telefono, email, objTipoDocumento.Id);
                    }

                }
            }
            else
            {
                string message = "Cargue los datos a la tabla para poder guardarlos";
                cargarDataTables();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalCargarExcel", "$('#modalCargarExcel').modal('show');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
            }
            cargarDataTables();
        }

        private void cargarDataTables()
        {
            CargarGrillaPersonas();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTableExcel();", true);
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
            CargarGrillaPersonas();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);

        }
    }
}
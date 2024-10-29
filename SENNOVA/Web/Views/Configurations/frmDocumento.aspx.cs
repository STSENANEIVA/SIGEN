using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Model;
using Utilities;

namespace Web.Views.Configurations
{
    public partial class frmDocumento : System.Web.UI.Page
    {
        LDocumento objLDocumento = new LDocumento();
        LProcedimiento objLProcedimiento = new LProcedimiento();
        List<Documento> lstDocumentos;
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
            Response.Redirect("~/Views/Configurations/frmDocumento.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Documento
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;
                int idProcedimiento = int.Parse(ddlProcedimiento.SelectedValue);
                int idTiposDocumentos = int.Parse(ddlTipoDocumento.SelectedValue);

                //validar el Documento
                bool Documentovalidado = ValidarCamposDocumento(codigo, nombre, idProcedimiento, idTiposDocumentos);

                if (!Documentovalidado)
                {
                    CargarGrillaDocumento();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Documento y retorno el numero
                int idDocumento = GuardarDocumento(codigo, nombre, activo, idProcedimiento, idTiposDocumentos);
                txtIdDocumento.Text = idDocumento.ToString();
                SubirArchivo();
                PantallaGuardado();
                
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarDocumento(string codigo, string nombre, bool activo, int idProcedimiento, int idTiposDocumentos)
        {
            LDocumento objLDocumento = new LDocumento();
            Documento objDocumento = new Documento();
            string id = txtIdDocumento.Text.Trim();
            int idDocumento;
            if (string.IsNullOrEmpty(id))
            {
                objDocumento = objLDocumento.Guardar(codigo, nombre, idProcedimiento, idTiposDocumentos);
            }
            else
            {
                idDocumento = Int32.Parse(id);
                objDocumento = objLDocumento.Actualizar(idDocumento, codigo, nombre, activo, idProcedimiento, idTiposDocumentos);
            }
            return objDocumento.Id;
        }

        private bool ValidarCamposDocumento(string codigo, string nombre, int idProcedimiento, int idTiposDocumentos)
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
            if (String.IsNullOrEmpty(idProcedimiento.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Procedimiento";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idTiposDocumentos.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Tipos de Documentos";
                resultado = false;
            }
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdDocumento.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaDocumento();
            CargarTiposDocumentos();
            CargarProcedimientos();
        }

        private void CargarProcedimientos()
        {

            objLProcedimiento = new LProcedimiento();
            ddlProcedimiento.DataSource = objLProcedimiento.Consultar();
            ddlProcedimiento.DataTextField = "Nombre";
            ddlProcedimiento.DataValueField = "id";
            ddlProcedimiento.DataBind();
            ddlProcedimiento.Items.Add(new ListItem("Seleccione", "0"));
            ddlProcedimiento.SelectedValue = "0";
        }

        private void CargarTiposDocumentos()
        {

            LTiposDocumentos objLTiposDocumentos = new LTiposDocumentos();
            ddlTipoDocumento.DataSource = objLTiposDocumentos.Consultar();
            ddlTipoDocumento.DataTextField = "Nombre";
            ddlTipoDocumento.DataValueField = "id";
            ddlTipoDocumento.DataBind();
            ddlTipoDocumento.Items.Add(new ListItem("Seleccione", "0"));
            ddlTipoDocumento.SelectedValue = "0";
        }

        private void CargarGrillaDocumento()
        {
            objLDocumento = new LDocumento();
            lstDocumentos = objLDocumento.Consultar();
            Session["DocumentosCompletos"] = lstDocumentos;
            Session["DocumentosFiltrados"] = lstDocumentos;
            grdDocumento.DataSource = lstDocumentos;
            grdDocumento.DataBind();
            if(grdDocumento.HeaderRow != null)
            {
                grdDocumento.UseAccessibleHeader = true;
                grdDocumento.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaDocumento();
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdDocumento.Text = grdDocumento.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdDocumento.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdDocumento.SelectedRow.Cells[2].Text).Trim();
                string procedimiento = HttpUtility.HtmlDecode(grdDocumento.SelectedRow.Cells[3].Text);
                ddlProcedimiento.ClearSelection();
                ddlProcedimiento.SelectedValue = ddlProcedimiento.Items.FindByText(procedimiento).Value;

                string tipoDocumento = HttpUtility.HtmlDecode(grdDocumento.SelectedRow.Cells[4].Text);
                ddlTipoDocumento.ClearSelection();
                ddlTipoDocumento.SelectedValue = ddlTipoDocumento.Items.FindByText(tipoDocumento).Value;

                CheckBox chk = grdDocumento.SelectedRow.Cells[5].Controls[0] as CheckBox;
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
            CargarGrillaDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idDocumento = (sender as LinkButton).CommandArgument;
            CargarGrillaDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idDocumento}');", true);
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            try
            {
                string filePath = (sender as LinkButton).CommandArgument;
                var fileInfo = new FileInfo(filePath);
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString(CultureInfo.InvariantCulture));
                Response.ContentType = "application/octet-stream";
                Response.BinaryWrite(File.ReadAllBytes(fileInfo.FullName));
                Response.Flush();
                Response.End();

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

        private void CargarArchivos()
        {
            string rutaSoportesDetallesDocumentos = ConfigGeneric.DetallesDocumentos;


            string rutaDocumento = txtIdDocumento.Text;
            bool existeRuta = Directory.Exists(Server.MapPath(rutaSoportesDetallesDocumentos + rutaDocumento + "/"));
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaSoportesDetallesDocumentos + rutaDocumento + "/"));


                foreach (string filePath in filePaths)
                {
                    Adjunto adjunto = new Adjunto();
                    adjunto.Nombre = Path.GetFileName(filePath);
                    adjunto.Url = filePath;
                    lstAdjunto.Add(adjunto);
                }
            }
            grdDocumentos.DataSource = lstAdjunto;
            grdDocumentos.DataBind();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalDocumentos", "$('#myModalDocumentos').modal('show');", true);

        }

        protected void lnkCerrarModal_Click(object sender, EventArgs e)
        {
            try
            {
                CerrarModal();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CerrarModal()
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalDocumentos", "$('#myModalDocumentos').modal('hide');", true);
            CargarGrillaDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkSoportes_Click(object sender, EventArgs e)
        {
            try
            {
                string idDocumento = (sender as LinkButton).CommandArgument;
                txtIdDocumento.Text = idDocumento;
                List<Adjunto> lstAdjunto = ConsultarArchivosPorDocumento(idDocumento);
                if (lstAdjunto.Count != 0)
                {
                    CargarGrillaSoportes(lstAdjunto);
                }
                else
                {
                    grdDocumentos.DataBind();
                }
                CargarGrillaDocumento();
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSubirSoporte", "$('#modalSubirSoporte').modal('show');", true);

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

        private List<Adjunto> ConsultarArchivosPorDocumento(string idDocumento)
        {
            string idSoportes = idDocumento;
            string rutaArchivosDocumentos = ConfigGeneric.DetallesDocumentos;
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            LDocumento objLDocumento = new LDocumento();

            bool existeRuta = Directory.Exists(Server.MapPath(rutaArchivosDocumentos + idSoportes + "/"));
            
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaArchivosDocumentos + idSoportes + "/"));

                foreach (string filePath in filePaths)
                {
                    Adjunto adjunto = new Adjunto();
                    adjunto.Nombre = Path.GetFileName(filePath);
                    adjunto.Url = filePath;
                    lstAdjunto.Add(adjunto);
                }
            }

            return lstAdjunto;
        }

        private void CargarGrillaSoportes(List<Adjunto> lstAdjunto)
        {
            try
            {
                grdDocumentos.DataSource = lstAdjunto;
                grdDocumentos.DataBind();
                if (grdDocumentos.HeaderRow != null)
                {
                    grdDocumentos.UseAccessibleHeader = true;
                    grdDocumentos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTableSoportes();", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void lnkCerrarModal(object sender, EventArgs e)
        {
            CargarGrillaDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSubirSoporte", "$('#modalSubirSoporte').modal('hide');", true);
            grdDocumentos.DataBind();

            if (grdDocumentos.HeaderRow != null)
            {
                grdDocumentos.UseAccessibleHeader = true;
                grdDocumentos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTableSoportes();", true);
        }

        private void SubirArchivo()
        {
            try
            {
                Boolean fileOK = false;
                string rutaSoportesDocumentos = ConfigGeneric.DetallesDocumentos;

                String path = Server.MapPath(rutaSoportesDocumentos);

                //validamos que se seleccione un archivo
                if (upFile.HasFile)
                {
                    //validamos que las extensiones sean validas
                    String fileExtension = System.IO.Path.GetExtension(upFile.FileName).ToLower();
                    String[] allowedExtensions = { ".png", ".jpeg", ".jpg", ".pdf", ".xls", ".xlsx", ".docx", ".doc" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            double filesize = upFile.FileContent.Length;

                            if (filesize < 2048000)
                            {
                                fileOK = true;
                                break;
                            }
                        }
                    }
                }

                if (fileOK)
                {
                    //creamos el directorio
                    string rutaSoporte = txtIdDocumento.Text;
                    Directory.CreateDirectory(Server.MapPath(rutaSoportesDocumentos + rutaSoporte));

                    string filePath = Server.MapPath(rutaSoportesDocumentos + rutaSoporte + "/");
                    upFile.PostedFile.SaveAs(filePath + upFile.FileName);
                    CargarArchivos();
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
            CargarGrillaDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                string filePath = (sender as LinkButton).CommandArgument;
                File.Delete(filePath);
                string message = "Archivo Eliminado!";
                string idDocumento = txtIdDocumento.Text;
                List<Adjunto> lstAdjunto = ConsultarArchivosPorDocumento(idDocumento);
                CargarGrillaSoportes(lstAdjunto);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{message}');", true);
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaDocumento();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSubirSoporte", "$('#modalSubirSoporte').modal('show');", true);
        }
    }
}
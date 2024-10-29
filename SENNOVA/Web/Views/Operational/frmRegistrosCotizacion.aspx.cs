using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Model;
using Utilities;

namespace Web.Views.Configurations
{
    public partial class frmRegistrosCotizacion : System.Web.UI.Page
    {
        List<Cotizacion> lstCotizacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarControles();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Operational/frmCotizacion.aspx");
        }

        private void CargarControles()
        {
            CargarGrillaCotizacion();
        }

        private void CargarGrillaCotizacion()
        {
            try
            {
                LCotizacion objLCotizacion = new LCotizacion();
                List<Cotizacion> lstCotizacion = objLCotizacion.Consultar();
                Session["CotizacionCompletos"] = lstCotizacion;
                Session["CotizacionFiltrados"] = lstCotizacion;
                grdCotizaciones.DataSource = lstCotizacion;
                grdCotizaciones.DataBind();

                if (grdCotizaciones.HeaderRow != null)
                {
                    grdCotizaciones.UseAccessibleHeader = true;
                    grdCotizaciones.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnBuscarFiltroSuperior_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFechaFinal.Text) && !String.IsNullOrEmpty(txtFechaInicial.Text))
            {
                try
                {
                    DateTime fechaIncialFormat = Convert.ToDateTime(txtFechaInicial.Text);
                    DateTime fechaFinalFormat = Convert.ToDateTime(txtFechaFinal.Text);
                    bool camposValidados = ValidarCampos(fechaIncialFormat, fechaFinalFormat);
                    CargarCotizacionCompleta();
                    if (camposValidados)
                    {
                        List<Cotizacion> lstCotizacion = Session["CotizacionCompletos"] as List<Cotizacion>;

                        lstCotizacion = (from s in lstCotizacion
                                           where s.Fecha >= fechaIncialFormat && s.Fecha <= fechaFinalFormat
                                           select s).ToList();


                        Session["CotizacionFiltrados"] = lstCotizacion;

                        grdCotizaciones.DataSource = lstCotizacion;
                        grdCotizaciones.DataBind();
                        if (grdCotizaciones.HeaderRow != null)
                        {
                            grdCotizaciones.UseAccessibleHeader = true;
                            grdCotizaciones.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    }
                    else
                    {
                        throw new ApplicationException(Message.CamposObligatorios);
                    }
                }
                catch (ApplicationException exe)
                {
                    throw exe;
                }
                catch (Exception exe)
                {
                    throw exe;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "warningalert();", true);
                CargarGrillaCotizacion();
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            }
        }

        private bool ValidarCampos(DateTime fechaIncial, DateTime fechaFinal)
        {
            bool validado = true;
            if (string.IsNullOrEmpty(fechaIncial.ToString()))
            {
                validado = false;
            }
            if (string.IsNullOrEmpty(fechaFinal.ToString()))
            {
                validado = false;
            }
            return validado;
        }

        private void CargarCotizacionCompleta()
        {
            try
            {
                LCotizacion objLCotizacion = new LCotizacion();
                lstCotizacion = objLCotizacion.Consultar();
                Session["CotizacionCompletos"] = lstCotizacion;
                Session["CotizacionFiltrados"] = lstCotizacion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void lnkOrdenTrabjo_Click(object sender, EventArgs e)
        {
            try
            {
                string idCotizacion = (sender as LinkButton).CommandArgument;
                Response.Redirect("frmOrdenTrabajo.aspx?idCotizacion=" + idCotizacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void lnkSoportes_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSubirSoporte", "$('#modalSubirSoporte').modal('show');", true);
            string idCotizacion = (sender as LinkButton).CommandArgument;
            txtIdCotizacion.Text = idCotizacion;

            List<Adjunto> lstAdjunto = ConsultarArchivosPorCotizacion(idCotizacion);
            CargarGrillaSoportes(lstAdjunto);
            CargarGrillaCotizacion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);

        }

        protected void lnkCerrarModal(object sender, EventArgs e)
        {
            CargarGrillaCotizacion();
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

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean fileOK = false;
                string rutaSoportesCotizaciones = ConfigGeneric.SoportesCotizacion;

                String path = Server.MapPath(rutaSoportesCotizaciones);

                //validamos que se seleccione un archivo
                if (upFile.HasFile)
                {
                    //validamos que las extensiones sean validas
                    String fileExtension = System.IO.Path.GetExtension(upFile.FileName).ToLower();
                    String[] allowedExtensions = { ".png", ".jpeg", ".jpg", ".pdf" };
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
                else
                {
                    string message = "Verifique la extension o el tamaño permitido.";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                }

                if (fileOK)
                {

                    //creamos el directorio
                    string rutaCotizacion = txtIdCotizacion.Text;
                    Directory.CreateDirectory(Server.MapPath(rutaSoportesCotizaciones + rutaCotizacion));

                    string filePath = Server.MapPath(rutaSoportesCotizaciones + rutaCotizacion + "/");
                    upFile.PostedFile.SaveAs(filePath + upFile.FileName);
                    string message = "Archivo Subido!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{message}');", true);
                    CargarDocumentos();
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
            CargarGrillaCotizacion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSubirSoporte", "$('#modalSubirSoporte').modal('show');", true);
        }

        private void CargarDocumentos()
        {
            string rutaSoportesCotizaciones = ConfigGeneric.SoportesCotizacion;

            string rutaCotizacion = txtIdCotizacion.Text;
            bool existeRuta = Directory.Exists(Server.MapPath(rutaSoportesCotizaciones + rutaCotizacion + "/"));
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaSoportesCotizaciones + rutaCotizacion + "/"));


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
            if (grdDocumentos.HeaderRow != null)
            {
                grdDocumentos.UseAccessibleHeader = true;
                grdDocumentos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        private List<Adjunto> ConsultarArchivosPorCotizacion(string idCotizacion)
        {
            string idSoportes = idCotizacion;
            string rutaSoportesCotizaciones = ConfigGeneric.SoportesCotizacion;

            LCotizacion objLCotizacion = new LCotizacion();
            bool existeRuta = Directory.Exists(Server.MapPath(rutaSoportesCotizaciones + idSoportes + "/"));
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaSoportesCotizaciones + idSoportes + "/"));

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

        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                string filePath = (sender as LinkButton).CommandArgument;
                File.Delete(filePath);
                string message = "Archivo Eliminado!";
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{message}');", true);
                CargarDocumentos();
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaCotizacion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalSubirSoporte", "$('#modalSubirSoporte').modal('show');", true);

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
    }
}
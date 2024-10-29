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
    public partial class frmOrdenTrabjo : System.Web.UI.Page
    {
        List<OrdenTrabajo> lstOrdenTrabajo = new List<OrdenTrabajo>();
        List<AreaTecnica> lstAreaTecnica = new List<AreaTecnica>();
        List<OrdenTrabajoDetalle> lstOrdenTrabajoDetalle = new List<OrdenTrabajoDetalle>();
        List<CotizacionDetalle> lstCotizacionDetalle = new List<CotizacionDetalle>();
        string camposFaltantes = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["idCotizacion"];
                if (id != null)
                {
                    CargarGrillaDetallesCotizacion(id);
                    List<Adjunto> lstAdjunto = ConsultarArchivosPorCotizacion(id);
                    CargarGrillaSoportes(lstAdjunto);
                }
                CargarControles();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Operational/frmRegistrosCotizacion.aspx");
        }

        protected void lnkCotizacion_Click(object sender, EventArgs e)
        {
            try
            {
                string idCotizacion = txtIdCotizacion.Text;
                Response.Redirect("frmCotizacion.aspx?idCotizacion=" + idCotizacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CargarControles()
        {
            CargarAreaTecnica();
            CargarResponsables();
        }

        private void CargarAreaTecnica()
        {

            LAreaTecnica objLAreaTecnica = new LAreaTecnica();
            lstAreaTecnica = objLAreaTecnica.Consultar();
            AreaTecnica otro = new AreaTecnica() { Id = 0, Codigo = "0", Nombre = "Otro", NombreSin = "Otro", Activo = true };
            lstAreaTecnica.Add(otro);
            ddlAreaTecnica.DataSource = lstAreaTecnica;
            ddlAreaTecnica.DataTextField = "NombreSin";
            ddlAreaTecnica.DataValueField = "id";
            ddlAreaTecnica.DataBind();
        }


        private void CargarResponsables()
        {

            LEmpleado objLEmpleado = new LEmpleado();
            ddlResponsable.DataSource = objLEmpleado.Consultar();
            ddlResponsable.DataTextField = "NombreCompleto";
            ddlResponsable.DataValueField = "id";
            ddlResponsable.DataBind();
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos generales orden de trabajo
                bool autorizacion = chkAutoriza.Checked;
                string numeroOT = txtNumeroOT.Text.Trim();
                DateTime fechaEmision = Convert.ToDateTime(txtFechaEmision.Text);
                DateTime fechaLimite = Convert.ToDateTime(txtFechaEjecucion.Text);
                DateTime fechaIngresoItem = Convert.ToDateTime(txtFechaIngresoItem.Text);
                string observacionesOT = txtObservacionOT.Text.Trim();

                //Obtener id de la Area Tecnica
                int idAreaTecnica = int.Parse(ddlAreaTecnica.SelectedValue);

                //Obtener id de la cotizacion
                int idCotizacion = int.Parse(txtIdCotizacion.Text.Trim());

                //Obtener id del Responzable
                int idResponsable = int.Parse(ddlResponsable.SelectedValue);

                

                bool camposValidados = validarCampos(numeroOT, fechaEmision, fechaLimite, fechaIngresoItem, idResponsable);

                if (!camposValidados)
                {
                    string messaje = Message.CamposObligatorios;
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{messaje}');", true);
                }

                //Guardo la orden de trabajo y retorno el número
                int idOrdenTrabajo = GuardarOrdenTrabjo(autorizacion, numeroOT, fechaEmision, fechaLimite, fechaIngresoItem, observacionesOT, idAreaTecnica, idCotizacion, idResponsable);

                txtIdOrdenTrabajo.Text = idOrdenTrabajo.ToString();

                //Guardo detalle orden de trabajo y retorno el número
                GuardarOrdenTrabjoDetalle(idOrdenTrabajo);
                PantallaGuardado();
                Response.Redirect("~/Views/Operational/frmRegistrosOrdenTrabajo.aspx");
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
                CargarGrillaDetallesCotizacion(txtIdCotizacion.Text);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
                CargarGrillaDetallesCotizacion(txtIdCotizacion.Text);
            }
            
        }

        private int GuardarOrdenTrabjo(bool autorizacion, string numeroOT, DateTime fechaEmision, DateTime fechaLimite, DateTime fechaIngresoItem, string observacionesOT, int idAreaTecnica, int idCotizacion, int idResponsable)
        {
            LOrdenTrabajo objLOrdenTrabajo = new LOrdenTrabajo();
            OrdenTrabajo objOrdenTrabajo = new OrdenTrabajo();
            string id = txtIdOrdenTrabajo.Text.Trim();
            int idOrdenTrabajo;
            if (string.IsNullOrEmpty(id))
            {
                objOrdenTrabajo = objLOrdenTrabajo.Guardar(autorizacion, numeroOT, fechaEmision, fechaLimite, fechaIngresoItem, observacionesOT, idAreaTecnica, idCotizacion, idResponsable);
            }
            else
            {
                idOrdenTrabajo = Int32.Parse(id);
                objOrdenTrabajo = objLOrdenTrabajo.Actualizar(idOrdenTrabajo, autorizacion, numeroOT, fechaEmision, fechaLimite, fechaIngresoItem, observacionesOT, idAreaTecnica, idCotizacion, idResponsable);
            }
            return objOrdenTrabajo.Id;
        }

        protected void GuardarOrdenTrabjoDetalle(int idOrdenTrabajo)
        {
            try
            {
                foreach (GridViewRow row in grdDetalleOrdenTrabajo.Rows)
                {
                    decimal cantidadTbl = Convert.ToDecimal(row.Cells[0].Text);
                    TextBox codigoItemTexbox = ((TextBox)row.FindControl("txtCodigoItem"));
                    string codigoTbl = codigoItemTexbox.Text;
                    string servicioTbl = HttpUtility.HtmlDecode(row.Cells[2].Text);
                    TextBox fechaInicioTexbox = ((TextBox)row.FindControl("txtFechaInicio"));
                    string fechaInicioTbl = fechaInicioTexbox.Text;
                    TextBox fechaFinalTexbox = ((TextBox)row.FindControl("txtFechaFinal"));
                    string fechaFinalTbl = fechaFinalTexbox.Text;
                    TextBox observacionTexbox = ((TextBox)row.FindControl("txtObservacion"));
                    string observacionTbl = HttpUtility.HtmlDecode(observacionTexbox.Text);


                    LOrdenTrabajoDetalle objLOrdenTrabajoDetalle = new LOrdenTrabajoDetalle();
                    OrdenTrabajoDetalle objOrdenTrabajoDetalle = new OrdenTrabajoDetalle();
                    objOrdenTrabajoDetalle = objLOrdenTrabajoDetalle.Guardar(cantidadTbl, codigoTbl, servicioTbl, Convert.ToDateTime(fechaInicioTbl), Convert.ToDateTime(fechaFinalTbl), observacionTbl, idOrdenTrabajo);
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

        private void OcultarMessage()
        {
            correcto.Visible = false;
            advertencia.Visible = false;
            error.Visible = false;
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                OcultarMessage();
                string message = Message.GuardoCorrecto;
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{message}');", true);
                grdDetalleOrdenTrabajo.DataSource = null;
                grdDetalleOrdenTrabajo.DataBind();
                txtCodigoCotizacion.Text = "";

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{exe.Message}');", true);
            }
        }

        private void LimpiarCampos()
        {
            txtIdOrdenTrabajo.Text = "";
            txtIdCotizacion.Text = "";
            ddlAreaTecnica.SelectedValue = "1";
            txtNumeroOT.Text = "";
            txtFechaEmision.Text = "";
            txtFechaEjecucion.Text = "";
            txtFechaIngresoItem.Text = "";
            ddlResponsable.SelectedValue = "1";
            txtObservacionOT.Text = "";
            chkAutoriza.Checked = false;
        }

        private bool validarCampos(string numeroOT, DateTime fechaEmision, DateTime fechaLimite, DateTime fechaIngresoItem,  int idResponsable)
        {
            bool resultado = true;

            if (String.IsNullOrEmpty(numeroOT))
            {
                camposFaltantes = camposFaltantes + ", " + "Número de orden";
                resultado = false;
            }

            if (String.IsNullOrEmpty(fechaEmision.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Fecha Emisión";
                resultado = false;
            }

            if (String.IsNullOrEmpty(fechaLimite.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Fecha Límite ejecución";
                resultado = false;
            }

            if (String.IsNullOrEmpty(fechaIngresoItem.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Fecha de ingreso de OT";
                resultado = false;
            }

            if (String.IsNullOrEmpty(idResponsable.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Responzable";
                resultado = false;
            }

            return resultado;
        }

        protected void ObtenerDatosTabla()
        {
            for (int i = 0; i < grdDetalleOrdenTrabajo.Rows.Count; i++)
            {
                decimal cantidadTbl = Convert.ToDecimal(grdDetalleOrdenTrabajo.Rows[i].Cells[0].Text);
                string codigoTbl = grdDetalleOrdenTrabajo.Rows[i].Cells[1].Text;
                string servicioTbl = HttpUtility.HtmlDecode(grdDetalleOrdenTrabajo.Rows[i].Cells[2].Text);
                string fechaInicioTbl = HttpUtility.HtmlDecode(grdDetalleOrdenTrabajo.Rows[i].Cells[3].Text.Trim());
                string fechaFinalTbl = HttpUtility.HtmlDecode(grdDetalleOrdenTrabajo.Rows[i].Cells[4].Text.Trim());
                string observacionTbl = grdDetalleOrdenTrabajo.Rows[i].Cells[5].Text;

                txtNumeroOT.Text = fechaInicioTbl;
                txtObservacionOT.Text = fechaFinalTbl;
                OrdenTrabajoDetalle detalleTbl = new OrdenTrabajoDetalle() { Cantidad = cantidadTbl, CodigoItem = codigoTbl, Servicio = servicioTbl, FechaInicio = Convert.ToDateTime(fechaInicioTbl), FechaFinal = Convert.ToDateTime(fechaFinalTbl), Observaciones = observacionTbl };
                lstOrdenTrabajoDetalle.Add(detalleTbl);
            }
        }

        protected void CargarGrillaDetallesCotizacion(string idCotizacion)
        {
            LCotizacion objLCotizacion = new LCotizacion();
            Cotizacion Cotizacion = objLCotizacion.Consultar(int.Parse(idCotizacion));

            txtIdCotizacion.Text = Cotizacion.Id.ToString();
            txtCodigoCotizacion.Text = Cotizacion.Codigo;

            LCotizacionDetalle objLCotizacionDetalle = new LCotizacionDetalle();
            lstCotizacionDetalle = objLCotizacionDetalle.ConsultarPorCotizacion(Cotizacion.Id);

            grdDetalleOrdenTrabajo.DataSource = lstCotizacionDetalle;
            grdDetalleOrdenTrabajo.DataBind();

            if (grdDetalleOrdenTrabajo.HeaderRow != null)
            {
                grdDetalleOrdenTrabajo.UseAccessibleHeader = true;
                grdDetalleOrdenTrabajo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

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
            CargarGrillaDetallesCotizacion(txtIdCotizacion.Text);
            
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean fileOK = false;
                string rutaSoportesOT = ConfigGeneric.SoportesOT;

                String path = Server.MapPath(rutaSoportesOT);

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
                    Directory.CreateDirectory(Server.MapPath(rutaSoportesOT + rutaCotizacion));

                    string filePath = Server.MapPath(rutaSoportesOT + rutaCotizacion + "/");
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
            CargarGrillaDetallesCotizacion(txtIdCotizacion.Text);
        }

        private void CargarDocumentos()
        {
            string rutaSoportesOT = ConfigGeneric.SoportesOT;

            string rutaCotizacion = txtIdCotizacion.Text;
            bool existeRuta = Directory.Exists(Server.MapPath(rutaSoportesOT + rutaCotizacion + "/"));
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaSoportesOT + rutaCotizacion + "/"));


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
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);

        }

        private List<Adjunto> ConsultarArchivosPorCotizacion(string idCotizacion)
        {
            string idSoportes = idCotizacion;
            string rutaSoportesOT = ConfigGeneric.SoportesOT;

            LCotizacion objLCotizacion = new LCotizacion();
            bool existeRuta = Directory.Exists(Server.MapPath(rutaSoportesOT + idSoportes + "/"));
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaSoportesOT + idSoportes + "/"));

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
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
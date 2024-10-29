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
using System.Globalization;

namespace Web.Views.Business
{
    public partial class frmActividades : System.Web.UI.Page
    {
        LActividad objLActividad = new LActividad();
        LObjetivoEspecifico objLObjetivoEspecifico = new LObjetivoEspecifico();
        List<Actividad> lstActividades = new List<Actividad>();
        string camposFaltantes = "";
        int idObjetivoEpecifico = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string idObjetivo = Request.QueryString["idObjetivo"];
            if (idObjetivo != null)
            {
                idObjetivoEpecifico = Int32.Parse(idObjetivo);
                txtIdObjetivo.Text = idObjetivoEpecifico.ToString();
            }
            CargarControles(idObjetivoEpecifico);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Configurations/frmActividad.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Actividad
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;
                int idObjetivoEspecifico = int.Parse(txtIdObjetivo.Text);


                //validar el Actividad
                bool Actividadvalidado = ValidarCamposActividad(codigo, nombre, idObjetivoEspecifico);

                if (!Actividadvalidado)
                {
                    throw new ApplicationException(Message.CamposObligatorios);
                }

                //guardo el Actividad y retorno el numero
                int idActividad = GuardarActividad(codigo, nombre, activo, idObjetivoEspecifico);
                txtIdActividad.Text = idActividad.ToString();
                PantallaGuardado();
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
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

        private int GuardarActividad(string codigo, string nombre, bool activo, int idObjetivoEspecifico)
        {
            LActividad objLActividad = new LActividad();
            Actividad objActividad = new Actividad();
            string id = txtIdActividad.Text.Trim();
            int idActividad;
            if (string.IsNullOrEmpty(id))
            {
                objActividad = objLActividad.Guardar(codigo, nombre, idObjetivoEspecifico);
            }
            else
            {
                idActividad = Int32.Parse(id);
                objActividad = objLActividad.Actualizar(idActividad, codigo, nombre, activo, idObjetivoEspecifico);
            }
            return objActividad.Id;
        }

        private bool ValidarCamposActividad(string codigo, string nombre, int idObjetivoEspecifico)
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
            if (String.IsNullOrEmpty(idObjetivoEspecifico.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "ObjetivoEspecifico";
                resultado = false;
            }
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdActividad.Text = "";
            txtCodigoProducto.Text = "";
            txtNombreProducto.Text = "";
            txtIdActividadProducto.Text = "";

        }

        private void CargarControles(int idObjetivoEpecifico)
        {
            CargarGrillaActividad();
            CargarObjetivoEspecificos();
        }

        private void CargarObjetivoEspecificos()
        {

            objLObjetivoEspecifico = new LObjetivoEspecifico();
            int idObjetivoEpecifico = int.Parse(txtIdObjetivo.Text);

            ObjetivoEspecifico objetivoEspecifico = objLObjetivoEspecifico.Consultar(idObjetivoEpecifico);
            txtObjetivo.Text = objetivoEspecifico.Nombre;

        }

        private void CargarGrillaActividad()
        {
            objLActividad = new LActividad();
            int idObjetivoEpecifico = int.Parse(txtIdObjetivo.Text);
            lstActividades = objLActividad.ConsultarPorObjetivo(idObjetivoEpecifico);
            Session["ActividadesCompletos"] = lstActividades;
            Session["ActividadesFiltrados"] = lstActividades;
            grdActividad.DataSource = lstActividades;
            grdActividad.DataBind();
            if (grdActividad.HeaderRow != null)
            {
                grdActividad.UseAccessibleHeader = true;
                grdActividad.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                correcto.Visible = true;
                txtMensajeCorrecto.Text = Message.GuardoCorrecto;
                CargarGrillaActividad();

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
            CargarGrillaActividad();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }


        protected void grdActividad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idObjetivoEpecifico = int.Parse(txtIdObjetivo.Text);
                CargarControles(idObjetivoEpecifico);
                txtIdActividad.Text = grdActividad.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdActividad.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdActividad.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdActividad.SelectedRow.Cells[3].Controls[0] as CheckBox;
                if (chk.Checked)
                {
                    chkActivo.Checked = true;
                }
                else
                {
                    chkActivo.Checked = false;
                }
                //string region = HttpUtility.HtmlDecode(grdActividad.SelectedRow.Cells[3].Text.Trim());
                //ddlObjetivoEspecifico.ClearSelection();
                //ddlObjetivoEspecifico.SelectedValue = ddlObjetivoEspecifico.Items.FindByText(region).Value;

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
            CargarGrillaActividad();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idActividad = (sender as LinkButton).CommandArgument;
                LActividad objLActividad = new LActividad();
                Actividad Actividad = objLActividad.Consultar(int.Parse(idActividad));
                Actividad objActividad = objLActividad.ConsultarPorObjetivoEspecifico(Actividad.Id);

                if (objActividad.Id == 0)
                {
                    objLActividad.Eliminar(int.Parse(idActividad));
                    CargarGrillaActividad();
                }
                else
                {
                    throw new ApplicationException("El Actividad " + Actividad.Nombre + " no se puede Eliminar, ya que se encuentra asociado.");
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
            CargarGrillaActividad();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkProductos_Click(object sender, EventArgs e)
        {
            try
            {
                CargarTipoProducto();
                string idActividad = (sender as LinkButton).CommandArgument;
                CargarProductosPorActividad(idActividad);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalProductos", "$('#ModalProductos').modal('show');", true);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalSoportes", "$('#myModalSoportes').modal('hide');", true);

            }
            catch (ApplicationException exe)
            {
                error.Visible = true;
                txtMensajeError.Text = exe.Message;
            }
            catch (Exception exe)
            {
                error.Visible = true;
                txtMensajeError.Text = exe.Message;
            }
            CargarGrillaActividad();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private void CargarTipoProducto()
        {
            try
            {
                LTipoProducto objLTipoProducto = new LTipoProducto();
                ddlTipoProducto.DataSource = objLTipoProducto.Consultar();
                ddlTipoProducto.DataTextField = "Nombre";
                ddlTipoProducto.DataValueField = "id";
                ddlTipoProducto.DataBind();
                ddlTipoProducto.Items.Add(new ListItem("Seleccione", "0"));
                ddlTipoProducto.SelectedValue = "0";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CargarProductosPorActividad(string idActividad)
        {
            try
            {
                txtIdActividadProducto.Text = idActividad;
                LProducto objLProducto = new LProducto();
                List<Producto> lstProductos = objLProducto.ConsultarPorActividad(int.Parse(idActividad));
                CargarGrillaProductos(lstProductos);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CargarGrillaProductos(List<Producto> lstProductos)
        {
            try
            {
                Session["ProductosCompletos"] = lstProductos;
                Session["ProductosFiltrados"] = lstProductos;
                grdProducto.DataSource = lstProductos;
                grdProducto.DataBind();
                if (grdProducto.HeaderRow != null)
                {
                    grdProducto.UseAccessibleHeader = true;
                    grdProducto.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idObjetivoEpecifico = int.Parse(txtIdObjetivo.Text);
                CargarControles(idObjetivoEpecifico);
                txtIdProducto.Text = grdProducto.SelectedRow.Cells[0].Text;
                txtCodigoProducto.Text = HttpUtility.HtmlDecode(grdProducto.SelectedRow.Cells[1].Text).Trim();
                txtNombreProducto.Text = HttpUtility.HtmlDecode(grdProducto.SelectedRow.Cells[2].Text).Trim();
                string tipoProducto = HttpUtility.HtmlDecode(grdProducto.SelectedRow.Cells[3].Text.Trim());
                ddlTipoProducto.ClearSelection();
                ddlTipoProducto.SelectedValue = ddlTipoProducto.Items.FindByText(tipoProducto).Value;
                CheckBox chk = grdProducto.SelectedRow.Cells[4].Controls[0] as CheckBox;
                if (chk.Checked)
                {
                    chkActivoProducto.Checked = true;
                }
                else
                {
                    chkActivoProducto.Checked = false;
                }
                //string region = HttpUtility.HtmlDecode(grdProducto.SelectedRow.Cells[3].Text.Trim());
                //ddlObjetivoEspecifico.ClearSelection();
                //ddlObjetivoEspecifico.SelectedValue = ddlObjetivoEspecifico.Items.FindByText(region).Value;

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
            CargarGrillaActividad();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            CargarProductosPorActividad(txtIdActividadProducto.Text);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalProductos", "$('#ModalProductos').modal('show');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalSoportes", "$('#myModalSoportes').modal('hide');", true);
        }

        protected void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Actividad
                string codigo = txtCodigoProducto.Text.Trim();
                string nombre = txtNombreProducto.Text.Trim();
                bool activo = chkActivoProducto.Checked;
                int idTipoProducto = int.Parse(ddlTipoProducto.SelectedValue);
                int idActividad = int.Parse(txtIdActividadProducto.Text);


                //validar el Actividad
                bool Actividadvalidado = ValidarCamposProducto(codigo, nombre, idTipoProducto, idActividad);

                if (!Actividadvalidado)
                {
                    throw new ApplicationException(Message.CamposObligatorios);
                }

                //guardo el Actividad y retorno el numero
                int idProducto = GuardarProducto(codigo, nombre, activo, idTipoProducto, idActividad);
                txtIdActividad.Text = idActividad.ToString();
                PantallaGuardado();
                CargarProductosPorActividad(idActividad.ToString());
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

        private int GuardarProducto(string codigo, string nombre, bool activo, int idTipoProducto, int idActividad)
        {
            try
            {
                LProducto objLProducto = new LProducto();
                Producto objProducto = new Producto();
                string id = txtIdActividad.Text.Trim();
                int idProducto;
                if (string.IsNullOrEmpty(id))
                {
                    objProducto = objLProducto.Guardar(codigo, nombre, idTipoProducto, idActividad);
                }
                else
                {
                    idProducto = Int32.Parse(id);
                    objProducto = objLProducto.Actualizar(idProducto, codigo, nombre, activo, idTipoProducto, idActividad);
                }
                return objProducto.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool ValidarCamposProducto(string codigo, string nombre, int idTipoProducto, int idActividad)
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
            if (String.IsNullOrEmpty(idActividad.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Actividad";
                resultado = false;
            }
            return resultado;
        }


        protected void lnkSoprtes_Click(object sender, EventArgs e)
        {
            try
            {
                string idProducto = (sender as LinkButton).CommandArgument;
                txtIdProducto.Text = idProducto;


                List<Adjunto> lstAdjunto = ConsultarArchivosPorProducto(idProducto);
                CargarGrillaSoportes(lstAdjunto);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalProductos", "$('#ModalProductos').modal('hide');", true);

                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalSoportes", "$('#myModalSoportes').modal('show');", true);
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
            CargarGrillaActividad();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private void CargarGrillaSoportes(List<Adjunto> lstAdjunto)
        {
            try
            {
                grdSoportes.DataSource = lstAdjunto;
                lblTotalSoportesProductos.Text = lstAdjunto.Count.ToString();
                grdSoportes.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<Adjunto> ConsultarArchivosPorProducto(string idProducto)
        {
            string idSoportes = idProducto;
            string rutaSoportesProductos = Message.SoportesProductos;

            LProducto objLProducto = new LProducto();
            bool existeRuta = Directory.Exists(Server.MapPath(rutaSoportesProductos + idSoportes + "/"));
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaSoportesProductos + idSoportes + "/"));

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
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalSoportes", "$('#myModalSoportes').modal();", true);
                Response.End();

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

        protected void Delete(object sender, EventArgs e)
        {
            try
            {
                string filePath = (sender as LinkButton).CommandArgument;
                File.Delete(filePath);
                //Response.Redirect(Request.Url.AbsoluteUri);
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

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean fileOK = false;
                string rutaSoportesProductos = Message.SoportesProductos;

                String path = Server.MapPath(rutaSoportesProductos);

                //validamos que se seleccione un archivo
                if (fuAdjunto.HasFile)
                {
                    //validamos que las extensiones sean validas
                    String fileExtension = System.IO.Path.GetExtension(fuAdjunto.FileName).ToLower();
                    String[] allowedExtensions = { ".png", ".jpeg", ".jpg", ".pdf" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension == allowedExtensions[i])
                        {
                            double filesize = fuAdjunto.FileContent.Length;

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
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalSoportes", "$('#myModalSoportes').modal('hide');", true);
                    CargarArchivos();
                    throw new ApplicationException("Verifique la extension o el tamaño permitido.");
                }

                if (fileOK)
                {

                    //creamos el directorio
                    string rutaProducto = txtIdProducto.Text;
                    Directory.CreateDirectory(Server.MapPath(rutaSoportesProductos + rutaProducto));

                    string filePath = Server.MapPath(rutaSoportesProductos + rutaProducto + "/");
                    fuAdjunto.PostedFile.SaveAs(filePath + fuAdjunto.FileName);
                    txtMensaje.Text = "Archivo Subido!";
                    CargarArchivos();
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalSoportes", "$('#myModalSoportes').modal('show');", true);
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

        private void CargarArchivos()
        {
            string rutaSoportesProductos = Message.SoportesProductos;

            string rutaProducto = txtIdProducto.Text;
            bool existeRuta = Directory.Exists(Server.MapPath(rutaSoportesProductos + rutaProducto + "/"));
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaSoportesProductos + rutaProducto + "/"));


                foreach (string filePath in filePaths)
                {
                    Adjunto adjunto = new Adjunto();
                    adjunto.Nombre = Path.GetFileName(filePath);
                    adjunto.Url = filePath;
                    lstAdjunto.Add(adjunto);
                }
            }
            grdSoportes.DataSource = lstAdjunto;
            lblTotalSoportesProductos.Text = lstAdjunto.Count.ToString();
            grdSoportes.DataBind();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalSoportes", "$('#myModalSoportes').modal('show');", true);

        }

        protected void lnkCerrarModal_Click(object sender, EventArgs e)
        {
            try
            {
                CerrarModal();
                CargarGrillaActividad();
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CerrarModal()
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalProductos", "$('#ModalProductos').modal('hide');", true);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalSoportes", "$('#myModalSoportes').modal('hide');", true);
        }

        protected void lnkAvances_Click(object sender, EventArgs e)
        {
            try
            {
                divPresupuestal.Visible = false;
                txtEjecutado.ReadOnly = true;
                string idActividad = (sender as LinkButton).CommandArgument;
                CargarAvancesPorActividad(idActividad);
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalAvances", "$('#ModalAvances').modal('show');", true);
            }
            catch (Exception)
            {
                throw;
            }
            CargarGrillaActividad();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private void CargarAvancesPorActividad(string idActividad)
        {
            try
            {
                txtIdAtividadAvance.Text = idActividad;
                LAvanceProyecto objLAvance = new LAvanceProyecto();
                List<AvanceProyecto> lstAvances = objLAvance.ConsultarPorActividad(int.Parse(idActividad));
                CargarGrillaAvances(lstAvances);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CargarGrillaAvances(List<AvanceProyecto> lstAvances)
        {
            try
            {
                Session["AvancesCompletos"] = lstAvances;
                Session["AvancesFiltrados"] = lstAvances;
                grdAvance.DataSource = lstAvances;
                grdAvance.DataBind();
                if (grdAvance.HeaderRow != null)
                {
                    grdAvance.UseAccessibleHeader = true;
                    grdAvance.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void lnkGuardarAvance_Click(object sender, EventArgs e)
        {
            try
            {
                int idActividad = int.Parse(txtIdAtividadAvance.Text);


                string mes = ddlMes.SelectedValue;
                string proyectado = txtProyectado.Text.Trim();
                string ejecutado = txtEjecutadoPresupuestal.Text.Trim();
                string observacionTecnica = txtObservacionTecnica.Text.Trim();
                string adicion = txtAdicion.Text.Trim();
                string disminucion = txtDisminucion.Text.Trim();
                string ejecutadoPresupuestal = txtEjecutadoPresupuestal.Text.Trim();
                decimal saldo = decimal.Parse(txtSaldo.Text.Replace("$",""));
                string observacionPresupuestal = txtObservacionPresupuestal.Text.Trim();



                LAvanceProyecto objLAvanceProyecto = new LAvanceProyecto();

                //guardo el Actividad y retorno el numero
                int idAvance = GuardarAvance(mes, proyectado, ejecutado, observacionTecnica, idActividad, ejecutadoPresupuestal, adicion, disminucion, saldo);
                txtIdActividad.Text = idActividad.ToString();
                PantallaGuardado();
                CargarAvancesPorActividad(idActividad.ToString());
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalAvances", "$('#ModalAvances').modal('show');", true);
                
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

        private int GuardarAvance(string mes, string proyectado, string ejecutado, string observacionTecnica, int idActividad, string ejecutadoPresupuestal, string adicion, string disminucion, decimal saldo)
        {
            try
            {
                LAvanceProyecto objLAvance = new LAvanceProyecto();
                AvanceProyecto objAvance = new AvanceProyecto();
                string id = txtIdAvance.Text.Trim();
                int idAvance;
                if (string.IsNullOrEmpty(id))
                {
                    objAvance = objLAvance.Guardar(mes, decimal.Parse(proyectado), observacionTecnica, idActividad);
                    divPresupuestal.Visible = false;
                    txtProyectado.ReadOnly = false;
                    txtEjecutado.ReadOnly = true;
                }
                else
                {
                    idAvance = Int32.Parse(id);
                    ejecutadoPresupuestal = ejecutadoPresupuestal.Replace("$", "").Trim();
                    adicion = adicion.Replace("$", "").Trim();
                    disminucion = disminucion.Replace("$", "").Trim();
                    objAvance = objLAvance.Actualizar(idAvance, mes, decimal.Parse(proyectado), observacionTecnica, idActividad, decimal.Parse(ejecutadoPresupuestal), 
                        decimal.Parse(adicion), decimal.Parse(disminucion),  saldo);
                    divPresupuestal.Visible = true;
                    txtProyectado.ReadOnly = true;
                    txtEjecutado.ReadOnly = false;
                }
                return objAvance.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grdAvance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                divPresupuestal.Visible = true;
                txtEjecutado.ReadOnly = false;
                txtProyectado.ReadOnly = true;

                int idActividadAvance = int.Parse(txtIdAtividadAvance.Text);

                txtIdAvance.Text = grdAvance.SelectedRow.Cells[0].Text;
                string mes = HttpUtility.HtmlDecode(grdAvance.SelectedRow.Cells[1].Text.Trim());
                ddlMes.ClearSelection();
                ddlMes.SelectedValue = ddlMes.Items.FindByValue(mes).Value;
                txtProyectado.Text = grdAvance.SelectedRow.Cells[2].Text;
                txtEjecutado.Text = grdAvance.SelectedRow.Cells[3].Text;
                txtObservacionTecnica.Text = HttpUtility.HtmlDecode(grdAvance.SelectedRow.Cells[4].Text);
                txtEjecutadoPresupuestal.Text = grdAvance.SelectedRow.Cells[5].Text;
                txtAdicion.Text = grdAvance.SelectedRow.Cells[6].Text;
                txtDisminucion.Text = grdAvance.SelectedRow.Cells[7].Text;
                txtObservacionPresupuestal.Text = HttpUtility.HtmlDecode(grdAvance.SelectedRow.Cells[8].Text);
                txtSaldo.Text = grdAvance.SelectedRow.Cells[9].Text;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ModalAvances", "$('#ModalAvances').modal('show');", true);

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
            CargarGrillaActividad();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            CargarAvancesPorActividad(txtIdAtividadAvance.Text);
        }

    }
}
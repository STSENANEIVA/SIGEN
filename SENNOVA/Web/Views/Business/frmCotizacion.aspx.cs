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
    public partial class frmCotizacion : System.Web.UI.Page
    {
        LCotizacion objLCotizacion = new LCotizacion();
        List<Cotizacion> lstCotizaciones;
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
            Response.Redirect("~/Views/Configurations/frmCotizacion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Cotizacion
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string idAreaTecnica = ddlAreaTecnica.SelectedValue;
                string precio = txtPrecio.Text;
                string requisitos = txtRequisitos.Text.Trim();
                string alcance = txtAlcance.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el Cotizacion
                bool Cotizacionvalidado = ValidarCamposCotizacion(codigo, nombre, idAreaTecnica);

                if (!Cotizacionvalidado)
                {
                    OcultarMessage();
                    throw new ApplicationException(Message.CamposObligatorios);
                }

                //guardo el Cotizacion y retorno el numero
                int idCotizacion = GuardarCotizacion(codigo, nombre, requisitos, alcance, precio, activo, idAreaTecnica);
                txtIdCotizacion.Text = idCotizacion.ToString();
                PantallaGuardado();
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

        private int GuardarCotizacion(string codigo, string nombre, string requisitos, string alcance, string precio, bool activo, string idAreaTecnica)
        {
            LCotizacion objLCotizacion = new LCotizacion();
            Cotizacion objCotizacion = new Cotizacion();
            string id = txtIdCotizacion.Text.Trim();
            int idCotizacion;
            if (string.IsNullOrEmpty(id))
            {
                //objCotizacion = objLCotizacion.Guardar(codigo, nombre, requisitos, alcance, decimal.Parse(precio), int.Parse(idAreaTecnica));
            }
            else
            {
                idCotizacion = Int32.Parse(id);
                //objCotizacion = objLCotizacion.Actualizar(idCotizacion, codigo, nombre, activo, requisitos, alcance, decimal.Parse(precio), int.Parse(idAreaTecnica));
            }
            return objCotizacion.Id;
        }

        private bool ValidarCamposCotizacion(string codigo, string nombre, string idAreaTecnica)
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
            
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdCotizacion.Text = "";
            chkActivo.Checked = false;
        }

        private void CargarControles()
        {
            CargarGrillaCotizacion();           
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

        private void CargarGrillaCotizacion()
        {
            objLCotizacion = new LCotizacion();
            lstCotizaciones = objLCotizacion.Consultar();
            Session["CotizacionesCompletos"] = lstCotizaciones;
            Session["CotizacionesFiltrados"] = lstCotizaciones;
            grdCotizacion.DataSource = lstCotizaciones;
            grdCotizacion.DataBind();
            lblTotalRegistros.Text = lstCotizaciones.Count.ToString();
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                OcultarMessage();
                correcto.Visible = true;
                txtMensajeCorrecto.Text = Message.GuardoCorrecto;
                CargarGrillaCotizacion();

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

        protected void grdCotizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OcultarMessage();
                CargarControles();
                txtIdCotizacion.Text = grdCotizacion.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdCotizacion.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdCotizacion.SelectedRow.Cells[2].Text).Trim();
                string tipoArea = HttpUtility.HtmlDecode(grdCotizacion.SelectedRow.Cells[3].Text).Trim();
                ddlAreaTecnica.ClearSelection();
                ddlAreaTecnica.SelectedValue = ddlAreaTecnica.Items.FindByText(tipoArea).Value;
                txtAlcance.Text = HttpUtility.HtmlDecode(grdCotizacion.SelectedRow.Cells[4].Text).Trim();
                txtRequisitos.Text = HttpUtility.HtmlDecode(grdCotizacion.SelectedRow.Cells[5].Text).Trim();
                txtPrecio.Text = HttpUtility.HtmlDecode(grdCotizacion.SelectedRow.Cells[6].Text).Trim();

                CheckBox chk = grdCotizacion.SelectedRow.Cells[7].Controls[0] as CheckBox;
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
                advertencia.Visible = true;
                txtMensajeAdvertencia.Text = exe.Message;
            }
            catch (Exception exe)
            {
                error.Visible = true;
                txtMensajeError.Text = exe.Message;
            }
        }

        protected void grdCotizacion_DataBound(object sender, EventArgs e)
        {
            GridViewRow pagerRow = grdCotizacion.BottomPagerRow;

            if (pagerRow != null)
            {
                // Retrieve the DropDownList and Label controls from the row.
                DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");
                Label pageLabel = (Label)pagerRow.Cells[0].FindControl("CurrentPageLabel");

                if (pageList != null)
                {

                    // Create the values for the DropDownList control based on 
                    // the  total number of pages required to display the data
                    // source.
                    for (int i = 0; i < grdCotizacion.PageCount; i++)
                    {

                        // Create a ListItem object to represent a page.
                        int pageNumber = i + 1;
                        ListItem item = new ListItem(pageNumber.ToString());

                        // If the ListItem object matches the currently selected
                        // page, flag the ListItem object as being selected. Because
                        // the DropDownList control is recreated each time the pager
                        // row gets created, this will persist the selected item in
                        // the DropDownList control.   
                        if (i == grdCotizacion.PageIndex)
                        {
                            item.Selected = true;
                        }

                        // Add the ListItem object to the Items collection of the 
                        // DropDownList.
                        pageList.Items.Add(item);
                    }
                    if (pageLabel != null)
                    {

                        // Calculate the current page number.
                        int currentPage = grdCotizacion.PageIndex + 1;

                        // Update the Label control with the current page information.
                        pageLabel.Text = "Page " + currentPage.ToString() +
                          " of " + grdCotizacion.PageCount.ToString();

                    }
                }
            }
        }

        protected void PageDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the pager row.
            GridViewRow pagerRow = grdCotizacion.BottomPagerRow;

            // Retrieve the PageDropDownList DropDownList from the bottom pager row.
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            // Set the PageIndex property to display that page selected by the user.
            grdCotizacion.PageIndex = pageList.SelectedIndex;
            grdCotizacion.DataSource = Session["CotizacionesFiltrados"];
            grdCotizacion.DataBind();
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idCotizacion = (sender as LinkButton).CommandArgument;
                LCotizacion objLCotizacion = new LCotizacion();
                Cotizacion Cotizacion = objLCotizacion.Consultar(int.Parse(idCotizacion));
                LEquipo objLEquipo = new LEquipo();
                //Equipo Equipo = objLEquipo.ConsultarPorCotizacion(Cotizacion.Id);

                //if (Equipo.Id == 0)
                //{
                //    objLCotizacion.Eliminar(int.Parse(idCotizacion));
                //    CargarGrillaCotizacion();
                //}
                //else
                //{
                //    throw new ApplicationException("El Cotizacion " + Cotizacion.Nombre + " no se puede Eliminar, ya que se encuentra asociado a un Producto");
                //}
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
    }
}
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

namespace Web.Views.Configurations
{
    public partial class frmCotizacion : System.Web.UI.Page
    {
        LCotizacion objLCotizacion = new LCotizacion();
        List<Cotizacion> lstCotizaciones;
        List<CotizacionDetalle> lstCotizacionDetalle;
        string camposFaltantes = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["idCotizacion"];
                if (id != null)
                {
                    CargarCotizacion(id);
                }
                CargarControles();
                
            }
            
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Operational/frmCotizacion.aspx");
        }

        protected void btnRegistros_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Operational/frmRegistrosCotizacion.aspx");
        }

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //Obtener datos del Cotizacion
        //        string codigo = txtCodigo.Text.Trim();
        //        string nombre = txtNombre.Text.Trim();
        //        string idAreaTecnica = ddlAreaTecnica.SelectedValue;
        //        string precio = txtPrecio.Text;
        //        string requisitos = txtRequisitos.Text.Trim();
        //        string alcance = txtAlcance.Text.Trim();
        //        bool activo = chkActivo.Checked;


        //        //validar el Cotizacion
        //        bool Cotizacionvalidado = ValidarCamposCotizacion(codigo, nombre, idAreaTecnica);

        //        if (!Cotizacionvalidado)
        //        {
        //            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
        //        }

        //        //guardo el Cotizacion y retorno el numero
        //        int idCotizacion = GuardarCotizacion(codigo, nombre, requisitos, alcance, precio, activo, idAreaTecnica);
        //        txtIdCotizacion.Text = idCotizacion.ToString();
        //        PantallaGuardado();
        //    }
        //    catch (ApplicationException exe)
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
        //    }
        //    catch (Exception exe)
        //    {
        //        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
        //    }
        //}

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
            txtIdCotizacion.Text = "";
        }

        private void CargarControles()
        {
            CargarTipoCotizacion();
            CargarAreaTecnica();
        }

        private void CargarAreaTecnica()
        {

            LAreaTecnica objLAreaTecnica = new LAreaTecnica();
            ddlAreaTecnica.DataSource = objLAreaTecnica.Consultar();
            ddlAreaTecnica.DataTextField = "NombreSin";
            ddlAreaTecnica.DataValueField = "id";
            ddlAreaTecnica.DataBind();
        }
        private void CargarTipoCotizacion()
        {
            ddlTipoCotizacion.Items.Add(new ListItem("Interna", "Interna"));
            ddlTipoCotizacion.Items.Add(new ListItem("Externa", "Externa"));
            ddlTipoCotizacion.DataBind();
            idProgramaFormacion.Visible = true;
            idFicha.Visible = true;
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                //CargarGrillaCotizacion();

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


        protected void ddlTipoCotizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string tipoCotizacion = ddlTipoCotizacion.SelectedValue;
                if (tipoCotizacion == "Interna")
                {
                    idCargo.Visible = true;
                    idTelefonoLaboral.Visible = true;
                    idEmailLaboral.Visible = true;
                    idProgramaFormacion.Visible = true;
                    idFicha.Visible = true;
                }
                else
                {
                    idCargo.Visible = false;
                    idTelefonoLaboral.Visible = false;
                    idEmailLaboral.Visible = false;
                    idProgramaFormacion.Visible = false;
                    idFicha.Visible = false;
                }
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
        }

        protected void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                string idServicio = hidServicioId.Value;
                if (!string.IsNullOrEmpty(idServicio))
                {
                    LServicio objLServicio = new LServicio();
                    Servicio servicio = new Servicio();
                    servicio = objLServicio.Consultar(int.Parse(idServicio));

                    ObtenerSesionCotizacionDetalle();

                    List<CotizacionDetalle> lstCotizacionDetallesTemporal = new List<CotizacionDetalle>();
                    lstCotizacionDetallesTemporal = Session["lstCotizacionDetallesTemporal"] as List<CotizacionDetalle>;

                    if (lstCotizacionDetallesTemporal == null)
                    {
                        List<CotizacionDetalle> lstCotizacionDetalles = new List<CotizacionDetalle>();
                        CotizacionDetalle objCotizacionDetalle = new CotizacionDetalle();
                        objCotizacionDetalle.Servicio = servicio;
                        objCotizacionDetalle.PrecioServicio = (decimal)servicio.Valor;
                        objCotizacionDetalle.Cantidad = 0;
                        objCotizacionDetalle.Observaciones = "";

                        lstCotizacionDetalles.Add(objCotizacionDetalle);
                        Session["lstCotizacionDetallesTemporal"] = lstCotizacionDetalles;
                        CagarGrillaDetalles(lstCotizacionDetalles);
                    }
                    else
                    {
                        CotizacionDetalle objCotizacionDetalle = new CotizacionDetalle();
                        objCotizacionDetalle.Servicio = servicio;
                        bool existeServicio = lstCotizacionDetallesTemporal.Exists(i => i.Servicio.Id == servicio.Id);
                        if (!existeServicio)
                        {
                            objCotizacionDetalle.PrecioServicio = (decimal)servicio.Valor;
                            objCotizacionDetalle.Cantidad = 0;
                            objCotizacionDetalle.Observaciones = "";
                            lstCotizacionDetallesTemporal.Add(objCotizacionDetalle);
                        }
                        else
                        {

                        }
                        Session["lstCotizacionDetallesTemporal"] = lstCotizacionDetallesTemporal;
                        CagarGrillaDetalles(lstCotizacionDetallesTemporal);
                    }
                }
                else
                {
                    string message = "Por favor valide la creación del producto y la asociación del mismo para poder continuar!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                }
                hidServicioId.Value = "";
                txtServicio.Text = "";

                ObtenerSesionTerminos();

                List<TerminoCondicion> lstTerminoCondicionsTemporal = new List<TerminoCondicion>();
                lstTerminoCondicionsTemporal = Session["lstTerminoCondicionesTemporal"] as List<TerminoCondicion>;
                CagarGrillaTerminos(lstTerminoCondicionsTemporal);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
        }

        private void ObtenerSesionCotizacionDetalle()
        {
            try
            {
                if (grdCotizacionDetalles.Rows.Count != 0)
                {
                    List<CotizacionDetalle> lstCotizacionDetalles = new List<CotizacionDetalle>();

                    foreach (GridViewRow row in grdCotizacionDetalles.Rows)
                    {
                        string idServicio = row.Cells[0].Text.Trim();
                        string codigo = row.Cells[1].Text.Trim();
                        string nombre = HttpUtility.HtmlDecode(row.Cells[2].Text.Trim());

                        TextBox cantidad = ((TextBox)row.FindControl("txtCantidad"));
                        string cant = cantidad.Text;
                        decimal cantidadProducto = decimal.Parse(cant);

                        TextBox valorUni = ((TextBox)row.FindControl("txtValorUnitario"));
                        string valUnitario = valorUni.Text;
                        if (string.IsNullOrEmpty(valUnitario))
                        {
                            valUnitario = "0";
                        }
                        else
                        {
                            decimal precioCompra = decimal.Parse(valUnitario);
                        }

                        TextBox valorTot = ((TextBox)row.FindControl("txtValorTotal"));
                        string valTotal = valorTot.Text;
                        decimal valorTotal = decimal.Parse(valTotal);

                        LServicio objLServicio = new LServicio();
                        Servicio Servicio = objLServicio.Consultar(int.Parse(idServicio));

                        CotizacionDetalle cotizacionCompraDetalle = new CotizacionDetalle();
                        cotizacionCompraDetalle.Servicio = Servicio;
                        cotizacionCompraDetalle.PrecioServicio = (decimal)Servicio.Valor;
                        cotizacionCompraDetalle.Cantidad = cantidadProducto;
                        cotizacionCompraDetalle.ValorUnitario = cantidadProducto * (decimal)Servicio.Valor;
                        lstCotizacionDetalles.Add(cotizacionCompraDetalle);
                    }

                    Session["lstCotizacionDetallesTemporal"] = lstCotizacionDetalles;

                }
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
        }

        private void CagarGrillaDetalles(List<CotizacionDetalle> lstCotizacionDetalle)
        {
            try
            {
                grdCotizacionDetalles.DataSource = lstCotizacionDetalle;
                grdCotizacionDetalles.DataBind();

                if (grdCotizacionDetalles.HeaderRow != null)
                {
                    grdCotizacionDetalles.UseAccessibleHeader = true;
                    grdCotizacionDetalles.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnEliminarDetalle_Click(object sender, EventArgs e)
        {

        }

        protected void CargarCotizacion(string idCotizacion)
        {
            LCotizacion objLCotizacion = new LCotizacion();
            Cotizacion Cotizacion = objLCotizacion.Consultar(int.Parse(idCotizacion));

            LPersona objLPersona = new LPersona();
            Persona Persona = objLPersona.Consultar(Cotizacion.Cliente.Persona.Id);

            LEmpleado objLEmpleado = new LEmpleado();
            Empleado Empleado = objLEmpleado.ConsultarPorIdPersona(Persona.Id);

            LProgramaFormacion objLProgramaFormacion = new LProgramaFormacion();
            ProgramaFormacion ProgramaFormacion = objLProgramaFormacion.Consultar(Cotizacion.ProgramaFormacion.Id);

            txtIdCotizacion.Text = Cotizacion.Id.ToString();
            txtCodigo.Text = Cotizacion.Codigo;
            ddlTipoCotizacion.SelectedValue = Cotizacion.TipoCotizacion;
            txtSolicitante.Text = $"{Persona.NumeroIdentificacion} - {Persona.NombreCompleto}";
            txtTelefono.Text = Persona.Telefono;
            txtEmail.Text = Persona.Email;
            txtCargo.Text = Empleado.Cargo.Nombre;
            txtTelefonoLaboral.Text = Persona.Telefono;
            txtEmailLaboral.Text = Empleado.EmailLaboral;
            txtProgramaFormacion.Text = $"{ProgramaFormacion.Codigo} - {ProgramaFormacion.Nombre}";
            txtFicha.Text = ProgramaFormacion.Codigo;
            txtObservaciones.Text = Cotizacion.Observaciones;

            LCotizacionDetalle objLCotizacionDetalle = new LCotizacionDetalle();
            lstCotizacionDetalle = objLCotizacionDetalle.ConsultarPorCotizacion(int.Parse(idCotizacion));
            CagarGrillaDetalles(lstCotizacionDetalle);
        }

        protected void txtSolicitante_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string idSolicitante = hidSolicitanteId.Value;
                if (!string.IsNullOrEmpty(idSolicitante))
                {
                    LEmpleado objLEmpleado = new LEmpleado();
                    Empleado empleado = objLEmpleado.ConsultarPorPersona(int.Parse(idSolicitante));
                    if (empleado != null)
                    {
                        txtTelefono.Text = empleado.Persona.Telefono;
                        txtEmail.Text = empleado.Persona.Email;
                        txtCargo.Text = empleado.Cargo.Nombre;
                        txtTelefonoLaboral.Text = empleado.Telefono;
                        txtEmailLaboral.Text = empleado.EmailLaboral;
                    }
                    else
                    {
                        LPersona objLPersona = new LPersona();
                        Persona persona = objLPersona.Consultar(int.Parse(idSolicitante));
                        txtTelefono.Text = persona.Telefono;
                        txtEmail.Text = persona.Email;
                    }
                }
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
        }
        
        protected void grdCotizacionDetalles_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                foreach (GridViewRow row in grdCotizacionDetalles.Rows)
                {
                    TextBox txtValorUnitario = ((TextBox)row.FindControl("txtValorUnitario"));


                    string precio = txtValorUnitario.Text;
                    if (!string.IsNullOrEmpty(precio))
                    {
                        string forma = precio.Replace(",00", "");
                        txtValorUnitario.Text = forma;
                    }

                    List<CotizacionDetalle>  lstCotizacionDetalles = Session["lstCotizacionDetallesTemporal"] as List<CotizacionDetalle>;

                    //ActualizarTotal(lstDetallesOrden);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

   
        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {
                List<CotizacionDetalle> lstCotizacionDetallesTemporal = new List<CotizacionDetalle>();
                Session["lstCotizacionDetallesTemporal"] = lstCotizacionDetallesTemporal;
                CagarGrillaDetalles(lstCotizacionDetallesTemporal);
            }
            catch (Exception)
            {

                throw;
            }
            ObtenerSesionTerminos();
            List<TerminoCondicion> lstTerminoCondicionsTemporal = new List<TerminoCondicion>();
            lstTerminoCondicionsTemporal = Session["lstTerminoCondicionesTemporal"] as List<TerminoCondicion>;
            CagarGrillaTerminos(lstTerminoCondicionsTemporal);
        }

        protected void btnAgregarTerminosCondiciones_Click(object sender, EventArgs e)
        {
            try
            {
                string idTerminoCondicion = hidTerminoCondicionId.Value;
                if (!string.IsNullOrEmpty(idTerminoCondicion))
                {
                    LTerminoCondicion objLTerminoCondicion = new LTerminoCondicion();
                    TerminoCondicion terminoCondicion = new TerminoCondicion();
                    terminoCondicion = objLTerminoCondicion.Consultar(int.Parse(idTerminoCondicion));

                    ObtenerSesionTerminos();

                    List<TerminoCondicion> lstTerminoCondicionsTemporal = new List<TerminoCondicion>();
                    lstTerminoCondicionsTemporal = Session["lstTerminoCondicionesTemporal"] as List<TerminoCondicion>;

                    if (lstTerminoCondicionsTemporal == null)
                    {
                        List<TerminoCondicion> lstTerminoCondicions = new List<TerminoCondicion>();
                        lstTerminoCondicions.Add(terminoCondicion);
                        Session["lstTerminoCondicionesTemporal"] = lstTerminoCondicions;
                        CagarGrillaTerminos(lstTerminoCondicions);
                    }
                    else
                    {
                        TerminoCondicion objTerminoCondicion = new TerminoCondicion();
                        
                        bool existeTerminoCondicion = lstTerminoCondicionsTemporal.Exists(i => i.Id == terminoCondicion.Id);
                        if (!existeTerminoCondicion)
                        {
                            lstTerminoCondicionsTemporal.Add(terminoCondicion);
                        }
                      
                        Session["lstTerminoCondicionsTemporal"] = lstTerminoCondicionsTemporal;
                        CagarGrillaTerminos(lstTerminoCondicionsTemporal);
                    }
                }
                else
                {
                    string message = "Por favor valide la creación del termino y la asociación del mismo para poder continuar!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                }
                hidTerminoCondicionId.Value = "";
                txtTerminoCondicion.Text = "";
                ObtenerSesionCotizacionDetalle();
                List<CotizacionDetalle> lstCotizacionDetallesTemporal = new List<CotizacionDetalle>();
                lstCotizacionDetallesTemporal = Session["lstCotizacionDetallesTemporal"] as List<CotizacionDetalle>;
                CagarGrillaDetalles(lstCotizacionDetallesTemporal);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
        }

        private void ObtenerSesionTerminos()
        {
            try
            {
                if (grdTerminos.Rows.Count != 0)
                {
                    List<TerminoCondicion> lstTerminoCondicions = new List<TerminoCondicion>();

                    foreach (GridViewRow row in grdTerminos.Rows)
                    {
                        string idTerminoCondicion = row.Cells[0].Text.Trim();
                        string codigo = row.Cells[1].Text.Trim();
                        string nombre = HttpUtility.HtmlDecode(row.Cells[2].Text.Trim());

                        LTerminoCondicion objLTerminoCondicion = new LTerminoCondicion();
                        TerminoCondicion terminoCondicion = objLTerminoCondicion.Consultar(int.Parse(idTerminoCondicion));
                        
                        lstTerminoCondicions.Add(terminoCondicion);
                    }

                    Session["lstTerminoCondicionesTemporal"] = lstTerminoCondicions;

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnLimpiarTerminos_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    List<TerminoCondicion> lstTerminoCondicionesTemporal = new List<TerminoCondicion>();
                    Session["lstTerminoCondicionesTemporal"] = lstTerminoCondicionesTemporal;
                    CagarGrillaTerminos(lstTerminoCondicionesTemporal);
                }
                catch (Exception)
                {

                    throw;
                }
            }
            catch (Exception)
            {

                throw;
            }
            ObtenerSesionCotizacionDetalle();
            List<CotizacionDetalle> lstCotizacionDetallesTemporal = new List<CotizacionDetalle>();
            lstCotizacionDetallesTemporal = Session["lstCotizacionDetallesTemporal"] as List<CotizacionDetalle>;
            CagarGrillaDetalles(lstCotizacionDetallesTemporal);
        }

        private void CagarGrillaTerminos(List<TerminoCondicion> lstTerminoCondicionesTemporal)
        {
            try
            {
                grdTerminos.DataSource = lstTerminoCondicionesTemporal;
                grdTerminos.DataBind();

                if (grdTerminos.HeaderRow != null)
                {
                    grdTerminos.UseAccessibleHeader = true;
                    grdTerminos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnEliminarTermino_Click(object sender, EventArgs e)
        {

        }
    }
}
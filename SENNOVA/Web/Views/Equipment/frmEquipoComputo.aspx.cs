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

namespace Web.Views.Equipment
{
    public partial class frmEquipoComputo : System.Web.UI.Page
    {
        LComputo objLComputo = new LComputo();
        LEquipo objLEquipo = new LEquipo();
        LTipoEquipo objLTipoEquipo = new LTipoEquipo();
        List<Software> lstSoftware = new List<Software>();
        List<Accesorios> lstAccesorios = new List<Accesorios>();
        string camposFaltantes = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["idEquipoTecnico"];
                if (id != null)
                {
                    txtIdEquipoTecnico.Text = id;
                    LlenarDatos(id);
                }
                CargarControles();
            }
        }

        private void LlenarDatos(string id)
        {
            Equipo equipo = objLEquipo.Consultar(int.Parse(id));
            //campos de equipo
            txtPlaca.Text = equipo.Placa;
            txtIdEquipo.Text = equipo.Id.ToString();
            txtNombre.Text = equipo.Nombre;
            txtSerial.Text = equipo.Serial;
            txtMarca.Text = equipo.Marca;
            txtFechaCompra.Text = equipo.FechaCompra.ToShortDateString();
            txtFechaCompra.TextMode = TextBoxMode.DateTime;
            txtValor.Text = equipo.Valor.ToString();
            txtNumeroContrato.Text = equipo.NumeroContrato;
            txtFechaFuncionamiento.Text = equipo.FechaFuncionamiento.ToShortDateString();
            txtFechaFuncionamiento.TextMode = TextBoxMode.DateTime;

            ddlEstado.SelectedValue = equipo.Estado;
            ddlResponsable.SelectedValue = equipo.Responsable.Id.ToString();
            ddlTipoEquipo.SelectedValue = equipo.TipoEquipo.Id.ToString();
            ddlAreaTecnica.SelectedValue = equipo.AreaTecnica.Id.ToString();

            //campos de computo
            Computo computo = equipo.lstComputos.FirstOrDefault();
            if (computo != null)
            {
                txtIdComputo.Text = computo.Id.ToString();
                chkCuentaAdmin.Checked = computo.CuentaAdmin;
                chkBackup.Checked = computo.Backup;
                txtIp.Text = computo.Ip;
                txtProcesador.Text = computo.Procesador;
                txtRam.Text = computo.Ram;
                txtDisco.Text = computo.Disco;
                txtObservaciones.Text = computo.Observaciones;
            }

            //Cargar Accesorios
            LEquipoAccesorio objLEquipoAccesorio = new LEquipoAccesorio();
            List<EquipoAccesorio> lstEquipoAccesorio = objLEquipoAccesorio.ConsultarEquipo(equipo.Id);
            List<Accesorios> lstAccesorios = new List<Accesorios>();
            foreach (var item in lstEquipoAccesorio)
            {
                lstAccesorios.Add(item.Accesorios);
            }
            CargarGrillaAccesorios(lstAccesorios);

            //Cargar Software
            LEquipoSoftware objLEquipoSoftware = new LEquipoSoftware();
            List<EquipoSoftware> lstEquipoSoftware = objLEquipoSoftware.ConsultarEquipo(computo.Id);
            List<Software> lstSoftware = new List<Software>();
            foreach (var item in lstEquipoSoftware)
            {
                lstSoftware.Add(item.Software);
            }
            CargarGrillaSoftware(lstSoftware);
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTableSoftware();", true);

            txtNombre.Focus();

            //Cargar Documentos
            List<Adjunto> lstAdjunto = ConsultarArchivosPorEquipoTecnico(id);
            CargarGrillaDocumentos(lstAdjunto);

            //Cargar Imagenes
            List<Adjunto> lstImagenes = ConsultarImagenesPorEquipoTecnico(id);
            CargarGrillaImagenes(lstImagenes);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Equipment/frmEquipoComputo.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Equipo
                string nombre = txtNombre.Text.Trim();
                string serial = txtSerial.Text.Trim();
                string placa = txtPlaca.Text.Trim();
                string marca = txtMarca.Text.Trim();
                string fechaCompra = txtFechaCompra.Text;
                string valor = txtValor.Text;
                string numeroContrato = txtNumeroContrato.Text.Trim();
                string fechaFuncionamiento = txtFechaFuncionamiento.Text;
                string estado = ddlEstado.SelectedValue;
                string idTipoEquipo = ddlTipoEquipo.SelectedValue;
                string idAreaTecnica = ddlAreaTecnica.SelectedValue;
                string idResponsable = ddlResponsable.SelectedValue;

                //Obtener datos del Computo
                bool cuentaAdmin = chkCuentaAdmin.Checked;
                bool backup = chkBackup.Checked;
                string ip = txtIp.Text.Trim();
                string procesador = txtProcesador.Text.Trim();
                string ram = txtRam.Text.Trim();
                string disco = txtDisco.Text.Trim();
                string observaciones = txtObservaciones.Text.Trim();

                ///falta la validacion
                //validar el EquipoComputo
                //bool EquipoComputovalidado = ValidarCamposEquipoComputo(nombres, apellidos, numeroIdentificacion, telefono, email, idTipoEquipo);
                //if (!EquipoComputovalidado)
                //{
                      //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                //    throw new ApplicationException(Message.CamposObligatorios);
                //}

                //guardo el Equipo y retorno el id
                int idEquipo = GuardarEquipo(placa, nombre, serial, marca, estado, fechaCompra, decimal.Parse(valor), numeroContrato, fechaFuncionamiento, int.Parse(idTipoEquipo), int.Parse(idResponsable), int.Parse(idAreaTecnica));
                //guada el Computo y retorno el id 
                LComputo objLComputo = new LComputo();
                int idImpresora = 0;
                int idComputo = GuardarComputo(ip, cuentaAdmin, backup, procesador, ram, disco, observaciones, idEquipo, idImpresora);

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
        }

        private int GuardarEquipo(string placa, string nombre, string serial, string marca, string estado, string fechaCompra, decimal valor, string numeroContrato, string fechaFuncionamiento, int idTipoEquipo, int idResponsable, int idAreaTecnica)
        {
            LEquipo objLEquipo = new LEquipo();
            Equipo objEquipo = new Equipo();
            string id = txtIdEquipo.Text.Trim();
            int idEquipo;
            if (string.IsNullOrEmpty(id))
            {
                objEquipo = objLEquipo.Guardar(placa, nombre, serial, marca, estado, DateTime.Parse(fechaCompra), valor, numeroContrato, DateTime.Parse(fechaFuncionamiento), idTipoEquipo, idResponsable, idAreaTecnica);
            }
            else
            {
                idEquipo = Int32.Parse(id);
                objEquipo = objLEquipo.Actualizar(idEquipo, placa, nombre, serial, marca, estado, DateTime.Parse(fechaCompra), valor, numeroContrato, DateTime.Parse(fechaFuncionamiento), idTipoEquipo, idResponsable, idAreaTecnica);
            }
            return objEquipo.Id;
        }

        private int GuardarComputo(string ip, bool cuentaAdmin, bool backup, string procesador, string ram, string disco, string observaciones, int idEquipo, int idImpresora)
        {
            LComputo objLComputo = new LComputo();
            Computo objComputo = new Computo();
            string id = txtIdComputo.Text.Trim();
            int idComputo;
            if (string.IsNullOrEmpty(id))
            {
                objComputo = objLComputo.Guardar(ip, cuentaAdmin, backup, procesador, ram, disco, observaciones, idEquipo, idImpresora);
            }
            else
            {
                idComputo = Int32.Parse(id);
                objComputo = objLComputo.Actualizar(idComputo, ip, cuentaAdmin, backup, procesador, ram, disco, observaciones, idEquipo, idImpresora);
            }
            return objComputo.Id;
        }

        private bool ValidarCamposEquipoComputo(string nombres, string apellidos, string numeroIdentificacion, string telefono, string email, int idTipoEquipo)
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


            if (String.IsNullOrEmpty(idTipoEquipo.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "TipoEquipo";
                resultado = false;
            }

            return resultado;
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtPlaca.Text = "";
            txtSerial.Text = "";
            txtMarca.Text = "";
            txtFechaCompra.Text = "";
            txtFechaFuncionamiento.Text = "";
            txtValor.Text = "";
            txtNumeroContrato.Text = "";
            txtIdEquipo.Text = "";
            txtIdComputo.Text = "";

            chkBackup.Checked = false;
            chkCuentaAdmin.Checked = false;
            txtIp.Text = "";
            txtProcesador.Text = "";
            txtRam.Text = "";
            txtDisco.Text = "";
            txtObservaciones.Text = "";
        }

        private void CargarControles()
        {
            CargarTipoEquipos();
            CargarAreaTecnica();
            CargarResponsables();
            CargarEstados();
        }

        private void CargarEstados()
        {
            ddlEstado.Items.Add(new ListItem("Bueno", "BUENO"));
            ddlEstado.Items.Add(new ListItem("Regular", "REGULAR"));
            ddlEstado.Items.Add(new ListItem("Malo", "MALO"));
        }

        private void CargarTipoEquipos()
        {

            objLTipoEquipo = new LTipoEquipo();
            ddlTipoEquipo.DataSource = objLTipoEquipo.Consultar();
            ddlTipoEquipo.DataTextField = "Nombre";
            ddlTipoEquipo.DataValueField = "id";
            ddlTipoEquipo.DataBind();
        }

        private void CargarResponsables()
        {

            LEmpleado objLEmpleado = new LEmpleado();
            ddlResponsable.DataSource = objLEmpleado.Consultar();
            ddlResponsable.DataTextField = "NombreCompleto";
            ddlResponsable.DataValueField = "id";
            ddlResponsable.DataBind();
        }

        private void CargarAreaTecnica()
        {

            LAreaTecnica objLAreaTecnica = new LAreaTecnica();
            ddlAreaTecnica.DataSource = objLAreaTecnica.Consultar();
            ddlAreaTecnica.DataTextField = "NombreSin";
            ddlAreaTecnica.DataValueField = "id";
            ddlAreaTecnica.DataBind();
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

        protected void txtPlaca_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string placa = txtPlaca.Text.Trim();

                LEquipo objLEquipo = new LEquipo();
                Equipo equipo = objLEquipo.Consultar(placa);
                if (equipo.Id != 0)
                {
                    //campos de equipo
                    txtIdEquipoTecnico.Text = equipo.Id.ToString();
                    txtNombre.Text = equipo.Nombre;
                    txtSerial.Text = equipo.Serial;
                    txtMarca.Text = equipo.Marca;
                    txtFechaCompra.Text = equipo.FechaCompra.ToShortDateString();
                    txtFechaCompra.TextMode = TextBoxMode.DateTime;
                    txtValor.Text = equipo.Valor.ToString();
                    txtNumeroContrato.Text = equipo.NumeroContrato;
                    txtFechaFuncionamiento.Text = equipo.FechaFuncionamiento.ToShortDateString();
                    txtFechaFuncionamiento.TextMode = TextBoxMode.DateTime;

                    ddlEstado.SelectedValue = equipo.Estado;
                    ddlResponsable.SelectedValue = equipo.Responsable.Id.ToString();
                    ddlTipoEquipo.SelectedValue = equipo.TipoEquipo.Id.ToString();
                    ddlAreaTecnica.SelectedValue = equipo.AreaTecnica.Id.ToString();

                    //campos de computo
                    Computo computo = equipo.lstComputos.FirstOrDefault();
                    if (computo != null)
                    {
                        txtIdComputo.Text = computo.Id.ToString();
                        chkCuentaAdmin.Checked = computo.CuentaAdmin;
                        chkBackup.Checked = computo.Backup;
                        txtIp.Text = computo.Ip;
                        txtProcesador.Text = computo.Procesador;
                        txtRam.Text = computo.Ram;
                        txtDisco.Text = computo.Disco;
                        txtObservaciones.Text = computo.Observaciones;
                    }

                    //Cargar Accesorios
                    LEquipoAccesorio objLEquipoAccesorio = new LEquipoAccesorio();
                    List<EquipoAccesorio> lstEquipoAccesorio = objLEquipoAccesorio.ConsultarEquipo(equipo.Id);
                    List<Accesorios> lstAccesorios = new List<Accesorios>();
                    foreach (var item in lstEquipoAccesorio)
                    {
                        lstAccesorios.Add(item.Accesorios);
                    }
                    CargarGrillaAccesorios(lstAccesorios);

                    //Cargar Software
                    LEquipoSoftware objLEquipoSoftware = new LEquipoSoftware();
                    List<EquipoSoftware> lstEquipoSoftware = objLEquipoSoftware.ConsultarEquipo(computo.Id);
                    List<Software> lstSoftware = new List<Software>();
                    foreach (var item in lstEquipoSoftware)
                    {
                        lstSoftware.Add(item.Software);
                    }
                    CargarGrillaSoftware(lstSoftware);

                    //Cargar Documentos
                    List<Adjunto> lstAdjunto = ConsultarArchivosPorEquipoTecnico(equipo.Id.ToString());
                    CargarGrillaDocumentos(lstAdjunto);

                    //Cargar Imagenes
                    List<Adjunto> lstImagenes = ConsultarImagenesPorEquipoTecnico(equipo.Id.ToString());
                    CargarGrillaImagenes(lstImagenes);

                }
                txtNombre.Focus();
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
        }

        //Software
        protected void btnAgregarSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                string idSoftware = hidSoftwareId.Value;

                if (!string.IsNullOrEmpty(idSoftware))
                {
                    LSoftware objLSoftware = new LSoftware();
                    Software software = objLSoftware.Consultar(int.Parse(idSoftware));
                    List<Software> lstSoftwareActual = ObtenerListadoGrdSoftware();
                    bool existeSoftware = lstSoftwareActual.Exists(i => i.Id == software.Id);
                    if (!existeSoftware)
                    {
                        lstSoftwareActual.Add(software);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('Aplicaión agregada');", true);
                    }
                    else
                    {
                        string message = "El Aplicativo ya esta asociado!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                    }
                    CargarGrillaSoftware(lstSoftwareActual);
                }
                else
                {
                    string message = "Antes de agregar debe seleccionar un Software !!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                }
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            List<Adjunto> lstAdjunto = ConsultarArchivosPorEquipoTecnico(txtIdEquipoTecnico.Text);
            CargarGrillaDocumentos(lstAdjunto);
            List<Adjunto> lstImagenes = ConsultarImagenesPorEquipoTecnico(txtIdEquipoTecnico.Text);
            CargarGrillaImagenes(lstImagenes);
            List<Accesorios> lstAccesoriosActual = ObtenerListadoGrdAccesorios();
            CargarGrillaAccesorios(lstAccesoriosActual);
        }

        private void CargarGrillaSoftware(List<Software> lstSoftware)
        {

            Session["SoftwareCompletos"] = lstSoftware;
            Session["SoftwareFiltrados"] = lstSoftware;
            grdSoftware.DataSource = lstSoftware;
            grdSoftware.DataBind();
            if (grdSoftware.HeaderRow != null)
            {
                grdSoftware.UseAccessibleHeader = true;
                grdSoftware.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTableSoftware();", true);
        }

        protected void btnGuardarSoftware_Click(object sender, EventArgs e)
        {
            try
            {
                string idEquipo = txtIdEquipo.Text;
                if (!string.IsNullOrEmpty(idEquipo))
                {
                    List<Software> lstSoftware = ObtenerListadoGrdSoftware();

                    foreach (var item in lstSoftware)
                    {
                        LEquipoSoftware objLEquipoSoftware = new LEquipoSoftware();
                        EquipoSoftware objEquipoSoftware = objLEquipoSoftware.ConsultarPorSoftware(item.Id);
                        if (objEquipoSoftware.Id == 0)
                        {
                            objLEquipoSoftware.Guardar(item.Id, int.Parse(idEquipo));
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                }
                else
                {
                    string message = "Antes de guardar Software debe haber creado el Equipo!!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                }
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            List<Software> lstSoftwareActual = ObtenerListadoGrdSoftware();
            CargarGrillaSoftware(lstSoftwareActual);
            List<Accesorios> lstAccesoriosActual = ObtenerListadoGrdAccesorios();
            CargarGrillaAccesorios(lstAccesoriosActual);
            CargarImagenes();
            CargarDocumentos();
        }

        private List<Software> ObtenerListadoGrdSoftware()
        {
            try
            {
                List<Software> lstSoftwareTemporal = new List<Software>();

                foreach (GridViewRow rows in grdSoftware.Rows)
                {
                    //obtenemos el id del accesorio
                    string idSoftware = rows.Cells[0].Text.Trim();
                    string codigo = rows.Cells[1].Text.Trim();
                    string nombre = rows.Cells[2].Text.Trim();
                    string version  = rows.Cells[3].Text.Trim();
                    string tipoLicencia  = HttpUtility.HtmlDecode(rows.Cells[4].Text.Trim());
                    Software software = new Software();
                    software.Id = int.Parse(idSoftware);
                    software.Codigo = codigo;
                    software.Nombre = nombre;
                    software.Version = version;
                    software.TipoLicencia = new TipoLicencia() {
                        Nombre = tipoLicencia,
                    };
                    lstSoftwareTemporal.Add(software);
                }
                return lstSoftwareTemporal;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Accesorios

        protected void btnAgregarAccesorios_Click(object sender, EventArgs e)
        {
            try
            {
                string idAccesorios = hidAccesorioId.Value;
                if (!string.IsNullOrEmpty(idAccesorios))
                {
                    LAccesorios objLAccesorios = new LAccesorios();
                    List<Accesorios> lstAccesoriosActual = ObtenerListadoGrdAccesorios();

                    bool existeAccesorios = lstAccesoriosActual.Exists(i => i.Id == int.Parse(idAccesorios));
                    if (!existeAccesorios)
                    {
                        Accesorios accesorios = objLAccesorios.Consultar(int.Parse(idAccesorios));
                        lstAccesoriosActual.Add(accesorios);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('Accesorio agregado');", true);
                    }
                    else
                    {
                        string message = "El Accesorio ya esta asociado!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                    }
                    CargarGrillaAccesorios(lstAccesoriosActual);
                }
                else
                {
                    string message = "Antes de agregar debe seleccionar un Accesorio!!";
                    txtAccesorio.Focus();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                }
                List<Adjunto> lstAdjunto = ConsultarArchivosPorEquipoTecnico(txtIdEquipoTecnico.Text);
                CargarGrillaDocumentos(lstAdjunto);
                List<Adjunto> lstImagenes = ConsultarImagenesPorEquipoTecnico(txtIdEquipoTecnico.Text);
                CargarGrillaImagenes(lstImagenes);
                List<Software> lstSoftwareActual = ObtenerListadoGrdSoftware();
                CargarGrillaSoftware(lstSoftwareActual);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }

        }

        private void CargarGrillaAccesorios(List<Accesorios> lstAccesorios)
        {

            Session["AccesoriosCompletos"] = lstAccesorios;
            Session["AccesoriosFiltrados"] = lstAccesorios;
            grdAccesorios.DataSource = lstAccesorios;
            grdAccesorios.DataBind();
            if (grdAccesorios.HeaderRow != null)
            {
                grdAccesorios.UseAccessibleHeader = true;
                grdAccesorios.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (lstAccesorios.Count != 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTableAccesorios();", true);
            }
        }

        protected void PageSoftwareDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the pager row.
            GridViewRow pagerRow = grdAccesorios.BottomPagerRow;

            // Retrieve the PageDropDownList DropDownList from the bottom pager row.
            DropDownList pageList = (DropDownList)pagerRow.Cells[0].FindControl("PageDropDownList");

            // Set the PageIndex property to display that page selected by the user.
            grdAccesorios.PageIndex = pageList.SelectedIndex;
            grdAccesorios.DataSource = Session["AccesoriossFiltrados"];
            grdAccesorios.DataBind();
        }

        protected void btnGuardarAccesorios_Click(object sender, EventArgs e)
        {
            try
            {
                string idEquipo = txtIdEquipo.Text;
                if (!string.IsNullOrEmpty(idEquipo))
                {
                    List<Accesorios> lstAccesorios  = ObtenerListadoGrdAccesorios();
                  
                    foreach (var item in lstAccesorios)
                    {
                        LEquipoAccesorio objLEquipoAccesorio = new LEquipoAccesorio();
                        EquipoAccesorio objEquipoAccesorio = objLEquipoAccesorio.ConsultarPorAccesorio(item.Id);
                        if (objEquipoAccesorio.Id == 0)
                        {
                            objLEquipoAccesorio.Guardar(item.Id, int.Parse(idEquipo));
                        }
                    }
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                }
                else
                {
                    string message = "Antes de guardar Accesorios debe haber creado el Equipo!!";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                }
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            List<Software> lstSoftwareActual = ObtenerListadoGrdSoftware();
            CargarGrillaSoftware(lstSoftwareActual);
            List<Accesorios> lstAccesoriosActual = ObtenerListadoGrdAccesorios();
            CargarGrillaAccesorios(lstAccesoriosActual);
            CargarImagenes();
            CargarDocumentos();
        }

        private List<Accesorios> ObtenerListadoGrdAccesorios()
        {
            try
            {
                List<Accesorios> lstAccesoriosTemporal = new List<Accesorios>();

                foreach (GridViewRow rows in grdAccesorios.Rows)
                {
                    //obtenemos el id del accesorio
                    string idAccesorio = rows.Cells[0].Text.Trim();
                    string codigo = rows.Cells[1].Text.Trim();
                    string nombre = rows.Cells[2].Text.Trim();
                    string descripcion = HttpUtility.HtmlDecode(rows.Cells[3].Text).Trim();
                    Accesorios accesorios = new Accesorios();
                    accesorios.Id = int.Parse(idAccesorio);
                    accesorios.Codigo =codigo;
                    accesorios.Nombre = nombre;
                    accesorios.Descripcion = descripcion;
                    lstAccesoriosTemporal.Add(accesorios);
                }
                return lstAccesoriosTemporal;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void lnkSubirDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean fileOK = false;
                string rutaSoportesEquipoComputo = ConfigGeneric.SoportesEquipoTecnico;

                String path = Server.MapPath(rutaSoportesEquipoComputo);

                //validamos que se seleccione un archivo
                if (txtIdEquipoTecnico.Text != "")
                {
                    if (upDocument.HasFile)
                    {
                        //validamos que las extensiones sean validas
                        String fileExtension = System.IO.Path.GetExtension(upDocument.FileName).ToLower();
                        String[] allowedExtensions = { ".xlsx", ".pdf", ".docx" };
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (fileExtension == allowedExtensions[i])
                            {
                                double filesize = upDocument.FileContent.Length;

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
                        string rutaEquipoTecnico = txtIdEquipoTecnico.Text;
                        Directory.CreateDirectory(Server.MapPath(rutaSoportesEquipoComputo + rutaEquipoTecnico));

                        string filePath = Server.MapPath(rutaSoportesEquipoComputo + rutaEquipoTecnico + "/");
                        upDocument.PostedFile.SaveAs(filePath + upDocument.FileName);
                        string message = "Archivo Subido!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{message}');", true);
                        CargarDocumentos();
                    }
                }
                else
                {
                    string message = "Para adjuntar un documento primero necesita un Equipo Técnico";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                }
                List<Software> lstSoftwareActual = ObtenerListadoGrdSoftware();
                CargarGrillaSoftware(lstSoftwareActual);
                List<Accesorios> lstAccesoriosActual = ObtenerListadoGrdAccesorios();
                CargarGrillaAccesorios(lstAccesoriosActual);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarImagenes();
        }

        private void CargarDocumentos()
        {
            string rutaSoportesEquipoComputo = ConfigGeneric.SoportesEquipoTecnico;

            string rutaEquipoTecnico = txtIdEquipoTecnico.Text;
            bool existeRuta = Directory.Exists(Server.MapPath(rutaSoportesEquipoComputo + rutaEquipoTecnico + "/"));
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaSoportesEquipoComputo + rutaEquipoTecnico + "/"));


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

        protected void lnkSubirImagen_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean fileOK = false;
                string rutaImagenesEquipoTecnico = ConfigGeneric.ImagenesEquipoTecnico;

                String path = Server.MapPath(rutaImagenesEquipoTecnico);

                //validamos que se seleccione un archivo
                if (txtIdEquipoTecnico.Text != "")
                {
                    if (upImage.HasFile)
                    {
                        //validamos que las extensiones sean validas
                        String fileExtension = System.IO.Path.GetExtension(upImage.FileName).ToLower();
                        String[] allowedExtensions = { ".png", ".jpeg", ".jpg", };
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (fileExtension == allowedExtensions[i])
                            {
                                double filesize = upImage.FileContent.Length;

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
                        string rutaEquipoTecnico = txtIdEquipoTecnico.Text;
                        Directory.CreateDirectory(Server.MapPath(rutaImagenesEquipoTecnico + rutaEquipoTecnico));

                        string filePath = Server.MapPath(rutaImagenesEquipoTecnico + rutaEquipoTecnico + "/");
                        upImage.PostedFile.SaveAs(filePath + upImage.FileName);
                        string message = "Archivo Subido!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{message}');", true);
                        CargarImagenes();
                    }
                }
                else
                {
                    string message = "Para adjuntar una imagen primero necesita un Equipo Técnico";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
                }
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarDocumentos();
            List<Software> lstSoftwareActual = ObtenerListadoGrdSoftware();
            CargarGrillaSoftware(lstSoftwareActual);
            List<Accesorios> lstAccesoriosActual = ObtenerListadoGrdAccesorios();
            CargarGrillaAccesorios(lstAccesoriosActual);
        }

        private void CargarImagenes()
        {
            string rutaImagenesEquipoTecnico = ConfigGeneric.ImagenesEquipoTecnico;

            string rutaEquipoTecnico = txtIdEquipoTecnico.Text;
            bool existeRuta = Directory.Exists(Server.MapPath(rutaImagenesEquipoTecnico + rutaEquipoTecnico + "/"));
            List<Adjunto> lstImagenes = new List<Adjunto>();

            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaImagenesEquipoTecnico + rutaEquipoTecnico + "/"));


                foreach (string filePath in filePaths)
                {
                    string filename = Path.GetFileName(filePath);
                    Adjunto adjunto = new Adjunto();
                    adjunto.Nombre = filename;
                    adjunto.Descripcion = $"{rutaImagenesEquipoTecnico}{rutaEquipoTecnico}/{filename}";
                    adjunto.Url = filePath;
                    lstImagenes.Add(adjunto);
                }
            }
            grdImagenes.DataSource = lstImagenes;
            grdImagenes.DataBind();
            if (grdImagenes.HeaderRow != null)
            {
                grdImagenes.UseAccessibleHeader = true;
                grdImagenes.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);

        }

        private List<Adjunto> ConsultarArchivosPorEquipoTecnico(string idEquipoTecnico)
        {
            string idSoportes = idEquipoTecnico;
            string rutaSoportesEquipoComputo = ConfigGeneric.SoportesEquipoTecnico;

            LEquipo objLEquipo = new LEquipo();
            bool existeRuta = Directory.Exists(Server.MapPath(rutaSoportesEquipoComputo + idSoportes + "/"));
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaSoportesEquipoComputo + idSoportes + "/"));

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

        private void CargarGrillaDocumentos(List<Adjunto> lstAdjunto)
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

        private List<Adjunto> ConsultarImagenesPorEquipoTecnico(string idEquipoTecnico)
        {
            string idSoportes = idEquipoTecnico;
            string rutaSoportesEquipoComputo = ConfigGeneric.ImagenesEquipoTecnico;

            LEquipo objLEquipo = new LEquipo();
            bool existeRuta = Directory.Exists(Server.MapPath(rutaSoportesEquipoComputo + idSoportes + "/"));
            List<Adjunto> lstAdjunto = new List<Adjunto>();
            if (existeRuta)
            {
                string[] filePaths = Directory.GetFiles(Server.MapPath(rutaSoportesEquipoComputo + idSoportes + "/"));

                foreach (string filePath in filePaths)
                {
                    string filename = Path.GetFileName(filePath);
                    Adjunto adjunto = new Adjunto();
                    adjunto.Nombre = filename;
                    adjunto.Descripcion = $"{rutaSoportesEquipoComputo}{idSoportes}/{filename}";
                    adjunto.Url = filePath;
                    lstAdjunto.Add(adjunto);
                }
            }
            return lstAdjunto;
        }

        private void CargarGrillaImagenes(List<Adjunto> lstImagenes)
        {
            try
            {
                grdImagenes.DataSource = lstImagenes;
                grdImagenes.DataBind();
                if (grdImagenes.HeaderRow != null)
                {
                    grdImagenes.UseAccessibleHeader = true;
                    grdImagenes.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
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
            List<Adjunto> lstAdjunto = ConsultarArchivosPorEquipoTecnico(txtIdEquipoTecnico.Text);
            CargarGrillaDocumentos(lstAdjunto);
            List<Adjunto> lstImagenes = ConsultarImagenesPorEquipoTecnico(txtIdEquipoTecnico.Text);
            CargarGrillaImagenes(lstImagenes);
            List<Software> lstSoftwareActual = ObtenerListadoGrdSoftware();
            CargarGrillaSoftware(lstSoftwareActual);
            List<Accesorios> lstAccesoriosActual = ObtenerListadoGrdAccesorios();
            CargarGrillaAccesorios(lstAccesoriosActual);
        }

        protected void Download(object sender, EventArgs e)
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


        //protected void lnkEliminar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string idAccesorios = (sender as LinkButton).CommandArgument;
        //        LEquipoAccesorio objLEquipoAccesorio = new LEquipoAccesorio();
        //        Accesorios Accesorios = objLAccesorios.Consultar(int.Parse(idAccesorios));
        //        EquipoAccesorio objEquipoAccesorio = objLEquipoAccesorio.ConsultarPorAccesorio(Accesorios.Id);

        //        if (objEquipoAccesorio.Id == 0)
        //        {
        //            objLAccesorios.Eliminar(int.Parse(idAccesorios));
        //            CargarGrillaAccesorios();
        //        }
        //        else
        //        {
        //            throw new ApplicationException("El Accesorios " + Accesorios.Nombre + " no se puede Eliminar, ya que se encuentra asociado!");
        //        }
        //    }
        //    catch (ApplicationException exe)
        //    {
        //        advertencia.Visible = true;
        //        txtMensajeAdvertencia.Text = exe.Message;
        //    }
        //    catch (Exception exe)
        //    {
        //        error.Visible = true;
        //        txtMensajeError.Text = exe.Message;
        //    }
        //}
    }
}
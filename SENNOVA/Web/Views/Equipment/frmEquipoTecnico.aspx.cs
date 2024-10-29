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
using DocumentFormat.OpenXml.Wordprocessing;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace Web.Views.Equipment
{
    public partial class frmEquipoTecnico : System.Web.UI.Page
    {
        LEquipoTecnico objLEquipoTecnico = new LEquipoTecnico();
        LEquipo objLEquipo = new LEquipo();
        LTipoEquipo objLTipoEquipo = new LTipoEquipo();
        string camposFaltantes = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["idEquipoTecnico"];
                if (id != null)
                {
                    txtIdEquipo.Text = id;
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
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Equipment/frmEquipoTecnico.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Equipo
                string placa = txtPlaca.Text.Trim();
                string idTipoEquipo = ddlTipoEquipo.SelectedValue;
                string nombre = txtNombre.Text.Trim();
                string idResponsable = ddlResponsable.SelectedValue;
                string serial = txtSerial.Text.Trim();
                string marca = txtMarca.Text.Trim();
                string fechaCompra = txtFechaCompra.Text;
                string valor = txtValor.Text;
                string numeroContrato = txtNumeroContrato.Text.Trim();
                string fechaFuncionamiento = txtFechaFuncionamiento.Text;
                string idAreaTecnica = ddlAreaTecnica.SelectedValue;
                string estado = ddlEstado.SelectedValue;

                //Obtener datos del EquipoTecnico
                string claseEquipo = txtClaseEquipo.Text.Trim();
                string idTipoPatron = ddlTipoPatron.SelectedValue;
                string caracteristicas = txtCaracteristicas.Text.Trim();
                string presionAire = txtPresionAire.Text.Trim();
                string caudal = txtCaudal.Text.Trim();
                string voltaje = txtVoltaje.Text.Trim();
                string amperaje = txtAmperaje.Text.Trim();
                string potencia = txtPotencia.Text.Trim();
                string tipoGas = txtTipoGas.Text.Trim();
                string presionGas = txtPresionGas.Text.Trim();
                string tipoAceite = txtTipoAceite.Text.Trim();
                string especifique = txtEspecifique.Text.Trim();
                string observaciones = txtObservaciones.Text.Trim();
                bool aire = false;
                bool electricidad = false;
                bool gas = false;
                bool aceite = false;
                bool otros = false;

                if (chkAire.Checked) {aire = true;}

                if (chkElectricidad.Checked){electricidad = true;}

                if (chkGas.Checked){gas = true;}

                if (chkAceite.Checked){aceite = true;}

                if (chkOtros.Checked){otros = true;}

                ///falta la validacion
                //validar el EquipoTecnico
                //bool EquipoTecnicovalidado = ValidarCamposEquipoTecnico();
                //if (!EquipoTecnicovalidado)
                //{
                //  ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                //}

                //guardo el Equipo y retorno el id
                int idEquipo = GuardarEquipo(placa, nombre, serial, marca, estado, fechaCompra, decimal.Parse(valor), numeroContrato, fechaFuncionamiento, int.Parse(idTipoEquipo), int.Parse(idResponsable), int.Parse(idAreaTecnica));
                //guada el equipo tecnico
                LEquipoTecnico objLEquipoTecnico = new LEquipoTecnico();
                int idEquipoTecnico = GuardarEquipoTecnico(claseEquipo, caracteristicas, aire, electricidad, gas, aceite, otros, presionAire, caudal,voltaje,amperaje,potencia,tipoGas,presionGas,tipoAceite, especifique,observaciones,idEquipo,idTipoPatron);
                PantallaGuardado();
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true); ;
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

        private int GuardarEquipoTecnico(string claseEquipo, string caracteristicas, bool aire, bool electricidad, bool gas, bool aceite, bool otros, string presionAire, string caudal, string voltaje, string amperaje, string potencia, string tipoGas, string presionGas, string tipoAceite, string especifique, string observaciones,int  idEquipo, string idTipoPatron)
        {
            LEquipoTecnico objLEquipoTecnico = new LEquipoTecnico();
            EquipoTecnico objEquipoTecnico = new EquipoTecnico();
            string id = txtIdEquipo.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                objEquipoTecnico = objLEquipoTecnico.Guardar(claseEquipo, caracteristicas, aire, electricidad, gas, aceite, otros, presionAire, caudal, voltaje, amperaje, potencia, tipoGas, presionGas, tipoAceite, especifique, observaciones, idEquipo, int.Parse(idTipoPatron));
            }
            else
            {
                int idEquipoTecnico = Int32.Parse(id);
                objEquipoTecnico = objLEquipoTecnico.Actualizar(idEquipoTecnico,claseEquipo,caracteristicas,aire,electricidad,gas,aceite,otros,presionAire,caudal,voltaje,amperaje,potencia,tipoGas,presionGas,tipoAceite,especifique,observaciones,idEquipo, int.Parse(idTipoPatron));
            }
            return objEquipoTecnico.Id;
        }

        private bool ValidarCamposEquipoTecnico(string nombres, string apellidos, string numeroIdentificacion, string telefono, string email, int idTipoEquipo)
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
            txtIdEquipo.Text = "";
            //txtIdEquipoTecnico.Text = "";
        }

        private void CargarControles()
        {
            CargarTipoEquipos();
            CargarAreaTecnica();
            CargarResponsables();
            CargarEstados();
            CargarTipoPatron();
        }

        private void CargarTipoPatron()
        {
            LTipoPatron objLTipoPatron = new LTipoPatron();
            ddlTipoPatron.DataSource = objLTipoPatron.Consultar();
            ddlTipoPatron.DataTextField = "Nombre";
            ddlTipoPatron.DataValueField = "id";
            ddlTipoPatron.DataBind();
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
                    EquipoTecnico computo = equipo.lstEquipoTecnicos.FirstOrDefault();
                    if (computo != null)
                    {
                        //txtIdEquipoTecnico.Text = computo.Id.ToString();
                        //chkCuentaAdmin.Checked = computo.CuentaAdmin;
                        //chkBackup.Checked = computo.Backup;
                        //txtIp.Text = computo.Ip;
                        //txtProcesador.Text = computo.Procesador;
                        //txtRam.Text = computo.Ram;
                        //txtDisco.Text = computo.Disco;
                        txtObservaciones.Text = computo.Observaciones; 
                    }


                }
                txtNombre.Focus();
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
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
                if (txtIdEquipo.Text != "")
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
                        string rutaEquipoTecnico = txtIdEquipo.Text;
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

            string rutaEquipoTecnico = txtIdEquipo.Text;
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

        private void CargarImagenes()
        {
            string rutaImagenesEquipoTecnico = ConfigGeneric.ImagenesEquipoTecnico;

            string rutaEquipoTecnico = txtIdEquipo.Text;
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
                    string descripcion = rows.Cells[3].Text.Trim();
                    Accesorios accesorios = new Accesorios();
                    accesorios.Id = int.Parse(idAccesorio);
                    accesorios.Codigo = codigo;
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

        protected void lnkSubirImagen_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean fileOK = false;
                string rutaImagenesEquipoTecnico = ConfigGeneric.ImagenesEquipoTecnico;

                String path = Server.MapPath(rutaImagenesEquipoTecnico);

                //validamos que se seleccione un archivo
                if (txtIdEquipo.Text != "")
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
                        string rutaEquipoTecnico = txtIdEquipo.Text;
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
            List<Accesorios> lstAccesoriosActual = ObtenerListadoGrdAccesorios();
            CargarGrillaAccesorios(lstAccesoriosActual);
        }

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
                List<Adjunto> lstAdjunto = ConsultarArchivosPorEquipoTecnico(txtIdEquipo.Text);
                CargarGrillaDocumentos(lstAdjunto);
                List<Adjunto> lstImagenes = ConsultarImagenesPorEquipoTecnico(txtIdEquipo.Text);
                CargarGrillaImagenes(lstImagenes);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }

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

        protected void btnGuardarAccesorios_Click(object sender, EventArgs e)
        {
            try
            {
                string idEquipo = txtIdEquipo.Text;
                if (!string.IsNullOrEmpty(idEquipo))
                {
                    List<Accesorios> lstAccesorios = ObtenerListadoGrdAccesorios();

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
            List<Accesorios> lstAccesoriosActual = ObtenerListadoGrdAccesorios();
            CargarGrillaAccesorios(lstAccesoriosActual);
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
            List<Adjunto> lstAdjunto = ConsultarArchivosPorEquipoTecnico(txtIdEquipo.Text);
            CargarGrillaDocumentos(lstAdjunto);
            List<Adjunto> lstImagenes = ConsultarImagenesPorEquipoTecnico(txtIdEquipo.Text);
            CargarGrillaImagenes(lstImagenes);
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
    }
}
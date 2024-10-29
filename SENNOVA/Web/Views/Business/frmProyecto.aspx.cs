using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Logic;
using Utilities;

namespace Web.Views.Business
{
    public partial class frmProyecto : System.Web.UI.Page
    {
        LProyecto objLProyecto = new LProyecto();
        LEmpleado objLEmpleado = new LEmpleado();
        LCentroFormacion objLCentroFormacion = new LCentroFormacion();
        string camposFaltantes = "";
        string idProyecto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //verificamos si viene por edicion o si es nuevo
                idProyecto = Request.QueryString["idProyecto"];


                if (string.IsNullOrEmpty(idProyecto))
                {
                    //seleccionamos el estado 1 que es de edicion
                    EstadosPantalla(1);
                }
                else
                {
                    //si viene por la opcion de nevo , se envio cero 0
                    EstadosPantalla(2);
                }
            }
        }

        public void EstadosPantalla(int estado)
        {
            switch (estado)
            {
                case 1:
                    PantallaNuevo();
                    break;
                case 2:
                    PantallaEdicion();
                    break;
                default:
                    PantallaNuevo();
                    break;
            }
        }

        private void PantallaNuevo()
        {
            CargarControles();
            List<Proyecto> lstProyectos = new List<Proyecto>();
            CargarGrillaProyecto(lstProyectos);
            Empleado empleado = objLEmpleado.ConsultarPorEmailLaboral(HttpContext.Current.User.Identity.Name);
            txtPersona.Text = empleado.NombreCompleto;
            hidPersonaId.Value = empleado.Id.ToString();
        }

        private void PantallaEdicion()
        {

            int idProyecto = Int32.Parse(Request.QueryString["idProyecto"]);
            txtIdProyecto.Text = idProyecto.ToString();
            CargarGrillaIdProyecto(idProyecto);
        }

        private void CargarGrillaIdProyecto(int idProyecto)
        {
            try
            {
                List<Proyecto> lstProyectos = new List<Proyecto>();
                objLProyecto = new LProyecto();
                Proyecto objProyecto = objLProyecto.Consultar(idProyecto);
                hidPersonaId.Value = objProyecto.Empleado.Id.ToString();
                txtPersona.Text = objProyecto.Empleado.NombreCompleto;
                lstProyectos.Add(objProyecto);
                CargarGrillaProyecto(lstProyectos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Business/frmProyecto.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del Proyecto
                string tituloProyecto = txtTituloProyecto.Text.Trim();
                string codigoSGPS = txtCodigoSGPS.Text.Trim();
                string anoEjecucion = txtAnoEjecucion.Text.Trim();
                DateTime fecha = Convert.ToDateTime(txtFecha.Text.Trim());
                string objetivoGeneral = txtObjetivoGeneral.Text.Trim();
                string asigancionInicial = txtAsigancionInicial.Text.Replace(".", "").Trim();
                int idCentroFormacion = int.Parse(hidCentroFormacionId.Value);
                int idLineaProgramatica = int.Parse(ddlLineaProgramatica.SelectedValue);
                int idRedConocimientoSectorial = int.Parse(ddlRedConocimientoSectorial.SelectedValue);
                int idAreaConocimiento = int.Parse(ddlAreaConocimiento.SelectedValue);
                int idPersona = int.Parse(hidPersonaId.Value);


                //validar el Proyecto
                bool Proyectovalidado = ValidarCamposProyecto(tituloProyecto, codigoSGPS, anoEjecucion, fecha, objetivoGeneral, asigancionInicial, idCentroFormacion,
                    idLineaProgramatica, idRedConocimientoSectorial, idAreaConocimiento, idPersona);

                if (!Proyectovalidado)
                {
                    CargarGrillaIdProyecto(int.Parse(txtIdProyecto.Text));
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el Proyecto y retorno el numero
                int idProyecto = GuardarProyecto(tituloProyecto, codigoSGPS, anoEjecucion, fecha, objetivoGeneral, asigancionInicial, idCentroFormacion, idLineaProgramatica, idRedConocimientoSectorial, idAreaConocimiento, idPersona);
                txtIdProyecto.Text = idProyecto.ToString();
                PantallaGuardado();
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            string id = txtIdProyecto.Text;
            if (!String.IsNullOrEmpty(id))
            {
                CargarGrillaIdProyecto(int.Parse(id));
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            }
        }

        private int GuardarProyecto(string tituloProyecto, string codigoSGPS, string anoEjecucion, DateTime fecha, string objetivoGeneral, string asigancionInicial, int idCentroFormacion, int idLineaProgramatica, int idRedConocimientoSectorial, int idAreaConocimiento, int idPersona)
        {
            LProyecto objLProyecto = new LProyecto();
            Proyecto objProyecto = new Proyecto();
            string id = txtIdProyecto.Text.Trim();
            int idProyecto;
            if (string.IsNullOrEmpty(id))
            {
                objProyecto = objLProyecto.Guardar(tituloProyecto, codigoSGPS, short.Parse(anoEjecucion), fecha, objetivoGeneral, Convert.ToDecimal(asigancionInicial), idCentroFormacion, idLineaProgramatica, idRedConocimientoSectorial, idAreaConocimiento, idPersona);
            }
            else
            {
                idProyecto = Int32.Parse(id);
                objProyecto = objLProyecto.Actualizar(idProyecto, tituloProyecto, codigoSGPS, short.Parse(anoEjecucion), fecha, objetivoGeneral, Convert.ToDecimal(asigancionInicial), idCentroFormacion, idLineaProgramatica, idRedConocimientoSectorial, idAreaConocimiento, idPersona);
            }
            return objProyecto.Id;
        }

        private bool ValidarCamposProyecto(string tituloProyecto, string codigoSGPS, string anoEjecucion, DateTime fecha, string objetivoGeneral, string asigancionInicial, int idCentroFormacion, int idLineaProgramatica, int idRedConocimientoSectorial, int idAreaConocimiento, int idPersona)
        {
            bool resultado = true;

            if (String.IsNullOrEmpty(tituloProyecto))
            {
                camposFaltantes = camposFaltantes + ", " + "TituloProyecto";
                resultado = false;
            }
            if (String.IsNullOrEmpty(codigoSGPS))
            {
                camposFaltantes = camposFaltantes + ", " + "CodigoSGPS";
                resultado = false;
            }
            if (String.IsNullOrEmpty(anoEjecucion))
            {
                camposFaltantes = camposFaltantes + ", " + "Numero de Identificacion";
                resultado = false;
            }
            if (String.IsNullOrEmpty(fecha.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Fecha";
                resultado = false;
            }
            if (String.IsNullOrEmpty(objetivoGeneral))
            {
                camposFaltantes = camposFaltantes + ", " + "ObjetivoGeneral";
                resultado = false;
            }
            if (String.IsNullOrEmpty(asigancionInicial))
            {
                camposFaltantes = camposFaltantes + ", " + "ObjetivoGeneral Laboral";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idCentroFormacion.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "CentroFormacion";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idLineaProgramatica.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Linea Programatica";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idRedConocimientoSectorial.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Red de Conocimiento Sectorial";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idAreaConocimiento.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Area de Conocimiento";
                resultado = false;
            }
            if (String.IsNullOrEmpty(idPersona.ToString()))
            {
                camposFaltantes = camposFaltantes + ", " + "Persona";
                resultado = false;
            }
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtTituloProyecto.Text = "";
            txtCodigoSGPS.Text = "";
            txtAnoEjecucion.Text = "";
            txtFecha.Text = "";
            txtObjetivoGeneral.Text = "";
            txtAsigancionInicial.Text = "";
            ddlLineaProgramatica.SelectedValue = "0";
            ddlRedConocimientoSectorial.SelectedValue = "0";
            ddlAreaConocimiento.SelectedValue = "0";
            txtCentroFormacion.Text = "";
            hidCentroFormacionId.Value = "0";
        }

        private void CargarControles()
        {
            CargarLineaProgramatica();
            CargarAreaConocimiento();
            CargarRedConocimientoSectorial();
        }

        private void CargarLineaProgramatica()
        {

            LLineaProgramatica objLLineaProgramatica = new LLineaProgramatica();
            ddlLineaProgramatica.DataSource = objLLineaProgramatica.Consultar();
            ddlLineaProgramatica.DataTextField = "Nombre";
            ddlLineaProgramatica.DataValueField = "id";
            ddlLineaProgramatica.DataBind();
            ddlLineaProgramatica.Items.Add(new ListItem("Seleccione", "0"));
            ddlLineaProgramatica.SelectedValue = "0";
        }

        private void CargarAreaConocimiento()
        {

            LAreaConocimiento objLAreaConocimiento = new LAreaConocimiento();
            ddlAreaConocimiento.DataSource = objLAreaConocimiento.Consultar();
            ddlAreaConocimiento.DataTextField = "Nombre";
            ddlAreaConocimiento.DataValueField = "id";
            ddlAreaConocimiento.DataBind();
            ddlAreaConocimiento.Items.Add(new ListItem("Seleccione", "0"));
            ddlAreaConocimiento.SelectedValue = "0";
        }

        private void CargarRedConocimientoSectorial()
        {

            LRedConocimientoSectorial objLRedConocimientoSectorial = new LRedConocimientoSectorial();
            ddlRedConocimientoSectorial.DataSource = objLRedConocimientoSectorial.Consultar();
            ddlRedConocimientoSectorial.DataTextField = "Nombre";
            ddlRedConocimientoSectorial.DataValueField = "id";
            ddlRedConocimientoSectorial.DataBind();
            ddlRedConocimientoSectorial.Items.Add(new ListItem("Seleccione", "0"));
            ddlRedConocimientoSectorial.SelectedValue = "0";
        }

        private void CargarGrillaProyecto(List<Proyecto> lstProyectos)
        {
            Session["ProyectosCompletos"] = lstProyectos;
            Session["ProyectosFiltrados"] = lstProyectos;
            grdProyecto.DataSource = lstProyectos;
            grdProyecto.DataBind();
            if (grdProyecto.HeaderRow != null)
            {
                grdProyecto.UseAccessibleHeader = true;
                grdProyecto.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                int idProyecto = Int32.Parse(txtIdProyecto.Text);
                CargarGrillaIdProyecto(idProyecto);

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            string id = txtIdProyecto.Text;
            if (!String.IsNullOrEmpty(id))
            {
                CargarGrillaIdProyecto(int.Parse(id));
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            }
        }

        protected void grdProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdProyecto.Text = grdProyecto.SelectedRow.Cells[0].Text;
                txtAnoEjecucion.Text = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[3].Text).Trim();
                txtTituloProyecto.Text = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[1].Text).Trim();
                txtCodigoSGPS.Text = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[2].Text).Trim();
                txtFecha.Text = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[4].Text).Trim();
                txtObjetivoGeneral.Text = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[5].Text).Trim();
                txtCentroFormacion.Text = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[6].Text).Trim();
                txtPersona.Text = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[10].Text).Trim();
                string idCentroFormacion = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[12].Text).Trim();
                hidCentroFormacionId.Value = idCentroFormacion;
                string asigancionInicial = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[11].Text).Trim();
                txtAsigancionInicial.Text = asigancionInicial.Replace("$", "").Trim();
                string lineaProgramatica = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[7].Text.Trim());
                ddlLineaProgramatica.ClearSelection();
                ddlLineaProgramatica.SelectedValue = ddlLineaProgramatica.Items.FindByText(lineaProgramatica).Value;
                string redConocimientoSectorial = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[8].Text.Trim());
                ddlRedConocimientoSectorial.ClearSelection();
                ddlRedConocimientoSectorial.SelectedValue = ddlRedConocimientoSectorial.Items.FindByText(redConocimientoSectorial).Value;
                string areaConocimiento = HttpUtility.HtmlDecode(grdProyecto.SelectedRow.Cells[9].Text.Trim());
                ddlAreaConocimiento.ClearSelection();
                ddlAreaConocimiento.SelectedValue = ddlAreaConocimiento.Items.FindByText(areaConocimiento).Value;

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            string id = txtIdProyecto.Text;
            if (!String.IsNullOrEmpty(id))
            {
                CargarGrillaIdProyecto(int.Parse(id));
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            }
        }


        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idProyecto = (sender as LinkButton).CommandArgument;
                LProyecto objLProyecto = new LProyecto();
                Proyecto Proyecto = objLProyecto.Consultar(int.Parse(idProyecto));
                LObjetivoEspecifico objLObjetivoEspecifico = new LObjetivoEspecifico();
                ObjetivoEspecifico objObjetivoEspecifico = objLObjetivoEspecifico.ConsultarPorProyecto(Proyecto.Id);

                if (objObjetivoEspecifico.Id == 0)
                {
                    objLProyecto.Eliminar(int.Parse(idProyecto));
                    //CargarGrillaProyecto();
                    //ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    string message = $"El Proyecto {Proyecto.TituloProyecto} {Proyecto.CodigoSGPS} no se puede Eliminar, ya que se encuentra asociado.";
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
            string id = txtIdProyecto.Text;
            if (!String.IsNullOrEmpty(id))
            {
                CargarGrillaIdProyecto(int.Parse(id));
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            }
        }

        protected void lnkObjetivos_Click(object sender, EventArgs e)
        {
            try
            {
                string idProyecto = (sender as LinkButton).CommandArgument;
                Response.Redirect("frmObjetivosEspecificos.aspx?idProyecto=" + idProyecto);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
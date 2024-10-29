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
    public partial class frmObjetivosEspecificos : System.Web.UI.Page
    {
 

        LObjetivoEspecifico objLObjetivoEspecifico = new LObjetivoEspecifico();
        LProyecto objLProyecto = new LProyecto();
        List<ObjetivoEspecifico> lstObjetivosEspecificos;
        string camposFaltantes = "";
        int idProyecto = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string proyecto = Request.QueryString["idProyecto"];
                if (proyecto != null)
                {
                    idProyecto = Int32.Parse(proyecto); 
                }
                CargarControles(idProyecto);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Configurations/frmObjetivoEspecifico.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del ObjetivoEspecifico
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;
                int idProyecto = int.Parse(txtIdProyecto.Text);

                //validar el ObjetivoEspecifico
                bool ObjetivoEspecificovalidado = ValidarCamposObjetivoEspecifico(codigo, nombre, idProyecto);

                if (!ObjetivoEspecificovalidado)
                {
                    CargarGrillaObjetivoEspecifico(idProyecto);
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el ObjetivoEspecifico y retorno el numero
                int idObjetivoEspecifico = GuardarObjetivoEspecifico(codigo, nombre, activo, idProyecto);
                txtIdObjetivoEspecifico.Text = idObjetivoEspecifico.ToString();
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
            CargarGrillaObjetivoEspecifico(idProyecto);
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarObjetivoEspecifico(string codigo, string nombre, bool activo, int idProyecto)
        {
            LObjetivoEspecifico objLObjetivoEspecifico = new LObjetivoEspecifico();
            ObjetivoEspecifico objObjetivoEspecifico = new ObjetivoEspecifico();
            string id = txtIdObjetivoEspecifico.Text.Trim();
            int idObjetivoEspecifico;
            if (string.IsNullOrEmpty(id))
            {
                objObjetivoEspecifico = objLObjetivoEspecifico.Guardar(codigo, nombre, idProyecto);
            }
            else
            {
                idObjetivoEspecifico = Int32.Parse(id);
                objObjetivoEspecifico = objLObjetivoEspecifico.Actualizar(idObjetivoEspecifico, codigo, nombre, activo, idProyecto);
            }
            return objObjetivoEspecifico.Id;
        }

        private bool ValidarCamposObjetivoEspecifico(string codigo, string nombre, int idProyecto)
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
            return resultado;
        }

        private void LimpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdObjetivoEspecifico.Text = "";
        }

        private void CargarControles(int idProyecto)
        {
            CargarGrillaObjetivoEspecifico(idProyecto);
        }

        private void CargarGrillaObjetivoEspecifico(int idProyecto)
        {
            objLObjetivoEspecifico = new LObjetivoEspecifico();
            if (idProyecto == 0)
            {
                lstObjetivosEspecificos = objLObjetivoEspecifico.Consultar();
            }
            else
            {
                Proyecto objProyecto = objLProyecto.Consultar(idProyecto);
                txtIdProyecto.Text = objProyecto.Id.ToString();
                txtCodigoSGPS.Text = objProyecto.CodigoSGPS;
                lstObjetivosEspecificos = objLObjetivoEspecifico.ConsultarPorProyectos(idProyecto);
            }
            Session["ObjetivosEspecificosCompletos"] = lstObjetivosEspecificos;
            Session["ObjetivosEspecificosFiltrados"] = lstObjetivosEspecificos;
            grdObjetivoEspecifico.DataSource = lstObjetivosEspecificos;
            grdObjetivoEspecifico.DataBind();
            if (grdObjetivoEspecifico.HeaderRow != null)
            {
                grdObjetivoEspecifico.UseAccessibleHeader = true;
                grdObjetivoEspecifico.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                int idProyecto = int.Parse(txtIdProyecto.Text);

                CargarGrillaObjetivoEspecifico(idProyecto);

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaObjetivoEspecifico(idProyecto);
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdObjetivoEspecifico_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtIdObjetivoEspecifico.Text = grdObjetivoEspecifico.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdObjetivoEspecifico.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdObjetivoEspecifico.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdObjetivoEspecifico.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaObjetivoEspecifico(idProyecto);
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idObjetivoEspecifico = (sender as LinkButton).CommandArgument;
                LActividad objLActividad = new LActividad();
                ObjetivoEspecifico ObjetivoEspecifico = objLObjetivoEspecifico.Consultar(int.Parse(idObjetivoEspecifico));
                Actividad objActividad = objLActividad.ConsultarPorObjetivoEspecifico(ObjetivoEspecifico.Id);

                if (objActividad.Id == 0)
                {
                    objLObjetivoEspecifico.Eliminar(int.Parse(idObjetivoEspecifico));
                    CargarGrillaObjetivoEspecifico(idProyecto);
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaObjetivoEspecifico(idProyecto);
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    string message = $"El ObjetivoEspecifico {ObjetivoEspecifico.Nombre} no se puede Eliminar, ya que se encuentra asociado a un Producto";
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
            CargarGrillaObjetivoEspecifico(idProyecto);
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkActividades_Click(object sender, EventArgs e)
        {
            try
            {
                string idObjetivo = (sender as LinkButton).CommandArgument;
                Response.Redirect("frmActividades.aspx?idObjetivo=" + idObjetivo);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
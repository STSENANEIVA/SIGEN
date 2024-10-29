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
    public partial class frmSectorEconomico : System.Web.UI.Page
    {
        LSectorEconomico objLSectorEconomico = new LSectorEconomico();
        List<SectorEconomico> lstSectorEconomicos;
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
            Response.Redirect("~/Views/Configurations/frmSectorEconomico.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del SectorEconomico
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el SectorEconomico
                bool SectorEconomicovalidado = ValidarCamposSectorEconomico(codigo, nombre);

                if (!SectorEconomicovalidado)
                {
                    CargarGrillaSectorEconomico();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el SectorEconomico y retorno el numero
                int idSectorEconomico = GuardarSectorEconomico(codigo, nombre, activo);
                txtIdSectorEconomico.Text = idSectorEconomico.ToString();
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
            CargarGrillaSectorEconomico();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarSectorEconomico(string codigo, string nombre, bool activo)
        {
            LSectorEconomico objLSectorEconomico = new LSectorEconomico();
            SectorEconomico objSectorEconomico = new SectorEconomico();
            SectorEconomico CodigoValidate = objLSectorEconomico.Consultar(codigo);
            SectorEconomico NombreValidate = objLSectorEconomico.ConsultarNombre(nombre);
            string id = txtIdSectorEconomico.Text.Trim();
            int idSectorEconomico;
            if (string.IsNullOrEmpty(id))
            {
                if (CodigoValidate.Id == 0 && NombreValidate.Id == 0)
                {
                    objSectorEconomico = objLSectorEconomico.Guardar(codigo, nombre);
                }
                else if (CodigoValidate.Id != 0)
                {
                    objSectorEconomico = objLSectorEconomico.Actualizar(CodigoValidate.Id, codigo, nombre, activo);

                }else if (NombreValidate.Id != 0)
                {
                    objSectorEconomico = objLSectorEconomico.Actualizar(NombreValidate.Id, codigo, nombre, activo);
                }

                
            }
            else
            {
                idSectorEconomico = Int32.Parse(id);
                objSectorEconomico = objLSectorEconomico.Actualizar(idSectorEconomico, codigo, nombre, activo);
            }
            return objSectorEconomico.Id;
        }

        private bool ValidarCamposSectorEconomico(string codigo, string nombre)
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
            txtIdSectorEconomico.Text = "";
            chkActivo.Checked = false;
        }

        private void CargarControles()
        {
            CargarGrillaSectorEconomico();
        }

        private void CargarGrillaSectorEconomico()
        {
            objLSectorEconomico = new LSectorEconomico();
            lstSectorEconomicos = objLSectorEconomico.Consultar();
            Session["SectorEconomicosCompletos"] = lstSectorEconomicos;
            Session["SectorEconomicosFiltrados"] = lstSectorEconomicos;
            grdSectorEconomico.DataSource = lstSectorEconomicos;
            grdSectorEconomico.DataBind();

            if (grdSectorEconomico.HeaderRow != null)
            {
                grdSectorEconomico.UseAccessibleHeader = true;
                grdSectorEconomico.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaSectorEconomico();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaSectorEconomico();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdSectorEconomico_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdSectorEconomico.Text = grdSectorEconomico.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdSectorEconomico.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdSectorEconomico.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdSectorEconomico.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaSectorEconomico();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }


        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idSectorEconomico = (sender as LinkButton).CommandArgument;
            CargarGrillaSectorEconomico();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idSectorEconomico}');", true);
        }
    }
}
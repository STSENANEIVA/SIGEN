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
    public partial class frmTipoProducto : System.Web.UI.Page
    {
        LTipoProducto objLTipoProducto = new LTipoProducto();
        List<TipoProducto> lstTipoProductos;
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
            Response.Redirect("~/Views/Configurations/frmTipoProducto.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del TipoProducto
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el TipoProducto
                bool TipoProductovalidado = ValidarCamposTipoProducto(codigo, nombre);

                if (!TipoProductovalidado)
                {
                    CargarGrillaTipoProducto();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el TipoProducto y retorno el numero
                int idTipoProducto = GuardarTipoProducto(codigo, nombre, activo);
                txtIdTipoProducto.Text = idTipoProducto.ToString();
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
            CargarGrillaTipoProducto();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        private int GuardarTipoProducto(string codigo, string nombre, bool activo)
        {
            LTipoProducto objLTipoProducto = new LTipoProducto();
            TipoProducto objTipoProducto = new TipoProducto();
            string id = txtIdTipoProducto.Text.Trim();
            int idTipoProducto;
            if (string.IsNullOrEmpty(id))
            {
                objTipoProducto = objLTipoProducto.Guardar(codigo, nombre);
            }
            else
            {
                idTipoProducto = Int32.Parse(id);
                objTipoProducto = objLTipoProducto.Actualizar(idTipoProducto, codigo, nombre, activo);
            }
            return objTipoProducto.Id;
        }

        private bool ValidarCamposTipoProducto(string codigo, string nombre)
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
            txtIdTipoProducto.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaTipoProducto();
        }

        private void CargarGrillaTipoProducto()
        {
            objLTipoProducto = new LTipoProducto();
            lstTipoProductos = objLTipoProducto.Consultar();
            Session["TipoProductosCompletos"] = lstTipoProductos;
            Session["TipoProductosFiltrados"] = lstTipoProductos;
            grdTipoProducto.DataSource = lstTipoProductos;
            grdTipoProducto.DataBind();
            if (grdTipoProducto.HeaderRow != null)
            {
                grdTipoProducto.UseAccessibleHeader = true;
                grdTipoProducto.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                LimpiarCampos();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"successalert('{Message.GuardoCorrecto}');", true);
                CargarGrillaTipoProducto();

            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            CargarGrillaTipoProducto();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void grdTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdTipoProducto.Text = grdTipoProducto.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdTipoProducto.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdTipoProducto.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdTipoProducto.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            CargarGrillaTipoProducto();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string idTipoProducto = (sender as LinkButton).CommandArgument;
                LTipoProducto objLTipoProducto = new LTipoProducto();
                TipoProducto TipoProducto = objLTipoProducto.Consultar(int.Parse(idTipoProducto));
                LProducto objLProducto = new LProducto();
                Producto Producto = objLProducto.ConsultarPorTipoProducto(TipoProducto.Id);

                if (Producto.Id == 0)
                {
                    objLTipoProducto.Eliminar(int.Parse(idTipoProducto));
                    CargarGrillaTipoProducto();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                }
                else
                {
                    CargarGrillaTipoProducto();
                    ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
                    string message = $"El TipoProducto {TipoProducto.Nombre} no se puede Eliminar, ya que se encuentra asociado a un Producto";
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
            CargarGrillaTipoProducto();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
        }
    }
}
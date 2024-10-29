using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Logic;
using Utilities;
using SpreadsheetLight;
using System.IO;
using System.Linq;
using System.Globalization;

namespace Web.Views.Configurations
{
    public partial class frmProgramaFormacion : System.Web.UI.Page
    {
        LProgramaFormacion objLProgramaFormacion = new LProgramaFormacion();
        List<ProgramaFormacion> lstProgramaFormacions;
        List<ProgramaFormacion> lstProgramaFormacion = new List<ProgramaFormacion>();
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
            Response.Redirect("~/Views/Configurations/frmProgramaFormacion.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtener datos del ProgramaFormacion
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                bool activo = chkActivo.Checked;


                //validar el ProgramaFormacion
                bool ProgramaFormacionvalidado = ValidarCamposProgramaFormacion(codigo, nombre);

                if (!ProgramaFormacionvalidado)
                {
                    cargarDataTables();
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{Message.CamposObligatorios}');", true);
                }

                //guardo el ProgramaFormacion y retorno el numero
                int idProgramaFormacion = GuardarProgramaFormacion(codigo, nombre, activo);
                txtIdProgramaFormacion.Text = idProgramaFormacion.ToString();
                PantallaGuardado();
                cargarDataTables();
            }
            catch (ApplicationException exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            catch (Exception exe)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"erroralert('{exe.Message}');", true);
            }
            cargarDataTables();
        }

        private int GuardarProgramaFormacion(string codigo, string nombre, bool activo)
        {
            LProgramaFormacion objLProgramaFormacion = new LProgramaFormacion();
            ProgramaFormacion objProgramaFormacion = new ProgramaFormacion();
            string id = txtIdProgramaFormacion.Text.Trim();
            int idProgramaFormacion;
            if (string.IsNullOrEmpty(id))
            {
                objProgramaFormacion = objLProgramaFormacion.Guardar(codigo, nombre);
            }
            else
            {
                idProgramaFormacion = Int32.Parse(id);
                objProgramaFormacion = objLProgramaFormacion.Actualizar(idProgramaFormacion, codigo, nombre, activo);
            }
            return objProgramaFormacion.Id;
        }

        private bool ValidarCamposProgramaFormacion(string codigo, string nombre)
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
            txtIdProgramaFormacion.Text = "";
        }

        private void CargarControles()
        {
            CargarGrillaProgramaFormacion();
            grdCargarExcel.DataBind();
        }

        private void CargarGrillaProgramaFormacion()
        {
            objLProgramaFormacion = new LProgramaFormacion();
            lstProgramaFormacions = objLProgramaFormacion.Consultar();
            Session["ProgramaFormacionsCompletos"] = lstProgramaFormacions;
            Session["ProgramaFormacionsFiltrados"] = lstProgramaFormacions;
            grdProgramaFormacion.DataSource = lstProgramaFormacions;
            grdProgramaFormacion.DataBind();

            if (grdProgramaFormacion.HeaderRow != null)
            {
                grdProgramaFormacion.UseAccessibleHeader = true;
                grdProgramaFormacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
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
            cargarDataTables();
        }

        protected void grdProgramaFormacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarControles();
                txtIdProgramaFormacion.Text = grdProgramaFormacion.SelectedRow.Cells[0].Text;
                txtCodigo.Text = HttpUtility.HtmlDecode(grdProgramaFormacion.SelectedRow.Cells[1].Text).Trim();
                txtNombre.Text = HttpUtility.HtmlDecode(grdProgramaFormacion.SelectedRow.Cells[2].Text).Trim();
                CheckBox chk = grdProgramaFormacion.SelectedRow.Cells[3].Controls[0] as CheckBox;
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
            cargarDataTables();
        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            string idProgramaFormacion = (sender as LinkButton).CommandArgument;
            cargarDataTables();
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"confirmAlert('{idProgramaFormacion}');", true);
        }

        protected void btnLeer_Click(object sender, EventArgs e)
        {
            if (upFile.HasFile)
            {
                string filename = Path.GetFileName(upFile.PostedFile.FileName);
                string filepath = Server.MapPath("~/Files/" + filename);
                upFile.SaveAs(filepath);

                SLDocument sl = new SLDocument(filepath);

                int iRow = 2; int id = 0; bool activo = false;

                while (!string.IsNullOrEmpty(sl.GetCellValueAsString(iRow, 1)))
                {
                    string codigo = sl.GetCellValueAsString(iRow, 1);
                    string nombre = sl.GetCellValueAsString(iRow, 2);
                    if (sl.GetCellValueAsString(iRow, 3) == "SI")
                    {
                        activo = true;
                    }
                    ProgramaFormacion programa = new ProgramaFormacion() { Id = id, Codigo = codigo, Nombre = nombre, Activo = activo };
                    lstProgramaFormacion.Add(programa);
                    iRow++; id++;
                }


                grdCargarExcel.DataSource = lstProgramaFormacion;
                grdCargarExcel.DataBind();

                if (grdCargarExcel.HeaderRow != null)
                {
                    grdCargarExcel.UseAccessibleHeader = true;
                    grdCargarExcel.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                cargarDataTables();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalCargarExcel", "$('#modalCargarExcel').modal('show');", true);
            }
            else
            {
                string messaje = "Seleccione un archivo primero";
                cargarDataTables();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalCargarExcel", "$('#modalCargarExcel').modal('show');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{messaje}');", true);
            }

        }

        protected void lnkCargarExcel_Click(object sender, EventArgs e)
        {
            cargarDataTables();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalCargarExcel", "$('#modalCargarExcel').modal('show');", true);
        }

        protected void lnkCerrarModal(object sender, EventArgs e)
        {
            cargarDataTables();
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalCargarExcel", "$('#modalCargarExcel').modal('hide');", true);
            grdCargarExcel.DataBind();

            if (grdCargarExcel.HeaderRow != null)
            {
                grdCargarExcel.UseAccessibleHeader = true;
                grdCargarExcel.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTableExcel();", true);
        }

        protected void btnGuardarExcel_Click(object sender, EventArgs e)
        {
            if (grdCargarExcel.HeaderRow != null)
            {

                for (int i = 0; i < grdCargarExcel.Rows.Count; i++)
                {
                    string codigo = grdCargarExcel.Rows[i].Cells[1].Text;
                    string nombre = HttpUtility.HtmlDecode(grdCargarExcel.Rows[i].Cells[2].Text).Trim();

                    LProgramaFormacion objLProgramaFormacion = new LProgramaFormacion();
                    ProgramaFormacion objProgramaFormacion = new ProgramaFormacion();
                    objProgramaFormacion = objLProgramaFormacion.Consultar(codigo);
                    if (objProgramaFormacion.Codigo == null)
                    {
                        objProgramaFormacion = objLProgramaFormacion.Guardar(codigo, nombre);
                    }
                    else
                    {
                        objProgramaFormacion = objLProgramaFormacion.Actualizar(objProgramaFormacion.Id, codigo, nombre, true);
                    }
                    
                }
            }
            else
            {
                string message = "Cargue los datos a la tabla para poder guardarlos";
                cargarDataTables();
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "modalCargarExcel", "$('#modalCargarExcel').modal('show');", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", $"warningalert('{message}');", true);
            }
            cargarDataTables();
        }

        private void cargarDataTables()
        {
            CargarGrillaProgramaFormacion();
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTable();", true);
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "dataTableExcel();", true);
        }

        protected void lnkDescargarFormato(object sender, EventArgs e)
        {
            try
            {
                string filePath = "C:\\Users\\SENA\\Documents\\Visual Studio 2022\\Projects\\SENNOVA\\SENNOVA\\Web\\Files\\Formato_Programa_Formacion.xlsx";
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
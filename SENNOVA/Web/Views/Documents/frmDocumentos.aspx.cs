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
    public partial class frmDocumentos : System.Web.UI.Page
    {
        LDocumento objLDocumento = new LDocumento();
        LProcedimiento objLProcedimiento = new LProcedimiento();
        List<Documento> lstDocumentos;
        string camposFaltantes = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarControles();
            }
        }

        private void CargarControles()
        {
            CargarGrillaDocumento();
        }

        private void CargarGrillaDocumento()
        {
            objLDocumento = new LDocumento();
            lstDocumentos = objLDocumento.Consultar();
            Session["DocumentosCompletos"] = lstDocumentos;
            Session["DocumentosFiltrados"] = lstDocumentos;
            grdDocumento.DataSource = lstDocumentos;
            grdDocumento.DataBind();
            if (grdDocumento.HeaderRow != null)
            {
                grdDocumento.UseAccessibleHeader = true;
                grdDocumento.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void PantallaGuardado()
        {
            try
            {
                OcultarMessage();
                correcto.Visible = true;
                txtMensajeCorrecto.Text = Message.GuardoCorrecto;
                CargarGrillaDocumento();

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


        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                OcultarMessage();
                string campo = cboFiltros.SelectedItem.Value;
                string criterio = txtValorBusqueda.Text;
                CargarGrillaDocumento();
                List<Documento> lstDocumento = new List<Documento>();
                lstDocumento = BuscarPorFiltros(campo, criterio);
                grdDocumento.DataSource = lstDocumento;
                grdDocumento.DataBind();
                if (grdDocumento.HeaderRow != null)
                {
                    grdDocumento.UseAccessibleHeader = true;
                    grdDocumento.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
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

        public List<Documento> BuscarPorFiltros(string campo, string filtro)
        {
            List<Documento> lstDocumentos = Session["DocumentosCompletos"] as List<Documento>;

            if (lstDocumentos.Count <= 0)
            {
                Session["DocumentosFiltrados"] = lstDocumentos;
                return lstDocumentos;
            }

            if (campo == "Todos")
            {
                Session["DocumentosFiltrados"] = lstDocumentos;
                return lstDocumentos;
            }
            if (campo == "Codigo")
            {
                if (String.IsNullOrEmpty(filtro))
                {
                    filtro = "0";
                }

                lstDocumentos = (from s in lstDocumentos
                               where s.Codigo.ToUpper().Contains(filtro.ToUpper())
                               select s).ToList();
                Session["DocumentosFiltrados"] = lstDocumentos;
                return lstDocumentos;
            }
            if (campo == "Nombre")
            {
                if (String.IsNullOrEmpty(filtro))
                {
                    filtro = "0";
                }

                lstDocumentos = (from s in lstDocumentos
                               where s.Nombre.ToUpper().Contains(filtro.ToUpper())
                               select s).ToList();
                Session["DocumentosFiltrados"] = lstDocumentos;
                return lstDocumentos;
            }
            if (campo == "Procedimiento")
            {
                if (String.IsNullOrEmpty(filtro))
                {
                    filtro = "0";
                }

                lstDocumentos = (from s in lstDocumentos
                               where s.Procedimiento.Nombre.ToUpper().Contains(filtro.ToUpper())
                               select s).ToList();
                Session["DocumentosFiltrados"] = lstDocumentos;
                return lstDocumentos;
            }
            if (campo == "TipoDocumento")
            {
                if (String.IsNullOrEmpty(filtro))
                {
                    filtro = "0";
                }

                lstDocumentos = (from s in lstDocumentos
                               where s.TiposDocumentos.Nombre.ToUpper().Contains(filtro.ToUpper())
                               select s).ToList();
                Session["DocumentosFiltrados"] = lstDocumentos;
                return lstDocumentos;
            }
            Session["DocumentosFiltrados"] = lstDocumentos;
            return lstDocumentos;
        }
    }
}
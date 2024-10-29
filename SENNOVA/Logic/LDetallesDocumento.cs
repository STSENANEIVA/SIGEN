using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Data;
using Utilities;

namespace Logic
{
    public class LDetallesDocumento
    {
        DDetallesDocumento objDDetallesDocumento;

        public LDetallesDocumento()
        {
            objDDetallesDocumento = new DDetallesDocumento();
        }

        public DetallesDocumento Guardar(string version, string rutaDoc, bool descargable, bool fisico, bool digital, string tipoSolicitud, DateTime fechaSolicitud,
            DateTime fechaRevision, DateTime fechaAprovacion, string copiaControlada, DateTime fechaCopiaControlada, bool activo, int idDocumento, int idSolicitante,
            int idRevisor, int idAprovador)
        {
            try
            {
                ValidarCampos(version, rutaDoc, fechaSolicitud, idDocumento, idSolicitante, idRevisor, idAprovador);

                objDDetallesDocumento = new DDetallesDocumento();
                DetallesDocumento objDetallesDocumento = new DetallesDocumento();
                objDetallesDocumento.Version = version;
                objDetallesDocumento.RutaDoc = rutaDoc;
                objDetallesDocumento.Descargable = descargable;
                objDetallesDocumento.Fisico = fisico;
                objDetallesDocumento.Digital = digital;
                objDetallesDocumento.TipoSolicitud = tipoSolicitud;
                objDetallesDocumento.FechaSolicitud = fechaSolicitud;
                objDetallesDocumento.CopiaControlada = copiaControlada;
                objDetallesDocumento.FechaCopiaControlada = fechaCopiaControlada;
                objDetallesDocumento.Activo = activo;
                objDetallesDocumento.Documento = new Documento() { Id = idDocumento };
                objDetallesDocumento.Solicitante = new Empleado() { Id = idSolicitante };
                objDetallesDocumento.Revisor = new Empleado() { Id = idRevisor };
                objDetallesDocumento.Aprovador = new Empleado() { Id = idAprovador };
                objDetallesDocumento.Id = objDDetallesDocumento.Guardar(objDetallesDocumento);
                return objDetallesDocumento;
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DetallesDocumento Actualizar(int id, string version, string rutaDoc, bool descargable, bool fisico, bool digital, string tipoSolicitud, DateTime fechaSolicitud, 
            DateTime fechaRevision, DateTime fechaAprovacion, string copiaControlada, DateTime fechaCopiaControlada, bool activo, int idDocumento, int idSolicitante,
            int idRevisor, int idAprovador)
        {
            try
            {
                ValidarCampos(version, rutaDoc, fechaSolicitud, idDocumento, idSolicitante, idRevisor, idAprovador);

                DetallesDocumento objDetallesDocumento = objDDetallesDocumento.Consultar(id);
                if (objDetallesDocumento.Equals(null))
                {
                    throw new ApplicationException(Message.DetallesDocumentoNull);
                }

                objDDetallesDocumento = new DDetallesDocumento();
                objDetallesDocumento.Version = version;
                objDetallesDocumento.RutaDoc = rutaDoc;
                objDetallesDocumento.Descargable = descargable;
                objDetallesDocumento.Fisico = fisico;
                objDetallesDocumento.Digital = digital;
                objDetallesDocumento.TipoSolicitud = tipoSolicitud;
                objDetallesDocumento.FechaSolicitud = fechaSolicitud;
                objDetallesDocumento.CopiaControlada = copiaControlada;
                objDetallesDocumento.FechaCopiaControlada = fechaCopiaControlada;
                objDetallesDocumento.Activo = activo;
                objDetallesDocumento.Documento = new Documento() { Id = idDocumento };
                objDetallesDocumento.Solicitante = new Empleado() { Id = idSolicitante };
                objDetallesDocumento.Revisor = new Empleado() { Id = idRevisor };
                objDetallesDocumento.Aprovador = new Empleado() { Id = idAprovador };
                objDDetallesDocumento.Actualizar(objDetallesDocumento);
                return objDetallesDocumento;
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<DetallesDocumento> Consultar()
        {
            try
            {
                return objDDetallesDocumento.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<DetallesDocumento>> Consultar(int top, int posicion)
        {
            try
            {
                return objDDetallesDocumento.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DetallesDocumento Consultar(string version, int idDocumento)
        {
            try
            {
                return objDDetallesDocumento.Consultar(version, idDocumento);
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DetallesDocumento Consultar(int id)
        {
            try
            {
                return objDDetallesDocumento.Consultar(id);
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                DetallesDocumento DetallesDocumento = objDDetallesDocumento.Consultar(id);
                if (DetallesDocumento != null)
                {
                    objDDetallesDocumento.Eliminar(DetallesDocumento);
                }
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarCampos(string version, string rutaDoc,  DateTime fechaSolicitud, int idDocumento, int idSolicitante, int idRevisor,  int idAprovador)
        {
            if (String.IsNullOrEmpty(version))
            {
                throw new ApplicationException(Message.VersionVacio);
            }
            if (String.IsNullOrEmpty(rutaDoc))
            {
                throw new ApplicationException(Message.RutaDocVacio);
            }
            if (String.IsNullOrEmpty(fechaSolicitud.ToString()))
            {
                throw new ApplicationException(Message.FechaVacio);
            }
            if (String.IsNullOrEmpty(idDocumento.ToString()))
            {
                throw new ApplicationException(Message.DocumentoVacio);
            }
            if (String.IsNullOrEmpty(idSolicitante.ToString()))
            {
                throw new ApplicationException(Message.SolicitanteVacio);
            }
            if (String.IsNullOrEmpty(idRevisor.ToString()))
            {
                throw new ApplicationException(Message.RevisorVacio);
            }
            if (String.IsNullOrEmpty(idAprovador.ToString()))
            {
                throw new ApplicationException(Message.AprovadorVacio);
            }

        }

        public DetallesDocumento ConsultarPorDocumento(int idDocumento)
        {
            try
            {
                return objDDetallesDocumento.ConsultarPorDocumento(idDocumento);
            }
            catch (ApplicationException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

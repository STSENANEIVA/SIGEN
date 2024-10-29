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
    public class LDocumento
    {
        DDocumento objDDocumento;

        public LDocumento()
        {
            objDDocumento = new DDocumento();
        }

        public Documento Guardar(string codigo, string nombre, int idProcedimiento, int idTiposDocumentos)
        {
            try
            {
                ValidarCampos(codigo, nombre, idProcedimiento, idTiposDocumentos);

                objDDocumento = new DDocumento();
                Documento objDocumento = new Documento();
                objDocumento.Codigo = codigo;
                objDocumento.Nombre = nombre;
                objDocumento.Activo = true;
                objDocumento.Procedimiento = new Procedimiento() { Id = idProcedimiento };
                objDocumento.TiposDocumentos = new TiposDocumentos() { Id = idTiposDocumentos };
                objDocumento.Id = objDDocumento.Guardar(objDocumento);
                return objDocumento;
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

        public Documento Actualizar(int id, string codigo, string nombre, bool activo, int idProcedimiento, int idTiposDocumentos)
        {
            try
            {
                ValidarCampos(codigo, nombre, idProcedimiento, idTiposDocumentos);

                Documento objDocumento = objDDocumento.Consultar(id);
                if (objDocumento.Equals(null))
                {
                    throw new ApplicationException(Message.DocumentoNull);
                }

                objDDocumento = new DDocumento();
                objDocumento.Codigo = codigo;
                objDocumento.Nombre = nombre;
                objDocumento.Activo = true;
                objDocumento.Procedimiento = new Procedimiento() { Id = idProcedimiento };
                objDocumento.TiposDocumentos = new TiposDocumentos() { Id = idTiposDocumentos };
                objDDocumento.Actualizar(objDocumento);
                return objDocumento;
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

        public List<Documento> Consultar()
        {
            try
            {
                return objDDocumento.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Documento>> Consultar(int top, int posicion)
        {
            try
            {
                return objDDocumento.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Documento Consultar(int id)
        {
            try
            {
                return objDDocumento.Consultar(id);
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

        public Documento Consultar(string codigo)
        {
            try
            {
                return objDDocumento.Consultar(codigo);
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
                Documento Documento = objDDocumento.Consultar(id);
                if (Documento != null)
                {
                    objDDocumento.Eliminar(Documento);
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

        private void ValidarCampos(string codigo, string nombre, int idProcedimiento, int idTiposDocumentos)
        {
            if (String.IsNullOrEmpty(codigo))
            {
                throw new ApplicationException(Message.CodigoVacio);
            }
            if (String.IsNullOrEmpty(nombre))
            {
                throw new ApplicationException(Message.NombreVacio);
            }
            if (String.IsNullOrEmpty(idProcedimiento.ToString()))
            {
                throw new ApplicationException(Message.ProcedimientoVacio);
            }
            if (String.IsNullOrEmpty(idTiposDocumentos.ToString()))
            {
                throw new ApplicationException(Message.TipoDocumentoVacio);
            }
        }

        public Documento ConsultarPorProcedimiento(int id)
        {
            try
            {
                return objDDocumento.ConsultarPorProcedimiento(id);
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

        public Documento ConsultarPorTiposDocumentos(int idTiposDocumentos)
        {
            try
            {
                return objDDocumento.ConsultarPorTiposDocumentos(idTiposDocumentos);
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

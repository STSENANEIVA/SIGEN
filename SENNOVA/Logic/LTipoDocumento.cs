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
    public class LTipoDocumento
    {
        DTipoDocumento objDTipoDocumento;

        public LTipoDocumento()
        {
            objDTipoDocumento = new DTipoDocumento();
        }

        public TipoDocumento Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDTipoDocumento = new DTipoDocumento();
                TipoDocumento objTipoDocumento = new TipoDocumento();
                objTipoDocumento.Codigo = codigo;
                objTipoDocumento.Nombre = nombre;
                objTipoDocumento.Activo = true;
                objTipoDocumento.Id = objDTipoDocumento.Guardar(objTipoDocumento);
                return objTipoDocumento;
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

        public TipoDocumento Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                TipoDocumento objTipoDocumento = objDTipoDocumento.Consultar(id);
                if (objTipoDocumento.Equals(null))
                {
                    throw new ApplicationException(Message.TipoDocumentoNull);
                }

                objDTipoDocumento = new DTipoDocumento();
                objTipoDocumento.Codigo = codigo;
                objTipoDocumento.Nombre = nombre;
                objTipoDocumento.Activo = activo;
                objDTipoDocumento.Actualizar(objTipoDocumento);
                return objTipoDocumento;
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

        public List<TipoDocumento> Consultar()
        {
            try
            {
                return objDTipoDocumento.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<TipoDocumento>> Consultar(int top, int posicion)
        {
            try
            {
                return objDTipoDocumento.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoDocumento Consultar(int id)
        {
            try
            {
                return objDTipoDocumento.Consultar(id);
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

        public TipoDocumento Consultar(string codigo)
        {
            try
            {
                return objDTipoDocumento.Consultar(codigo);
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

        public TipoDocumento ConsultarNombre(string nombre)
        {
            try
            {
                return objDTipoDocumento.ConsultarNombre(nombre);
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
                TipoDocumento TipoDocumento = objDTipoDocumento.Consultar(id);
                if (TipoDocumento != null)
                {
                    objDTipoDocumento.Eliminar(TipoDocumento);
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

        private void ValidarCampos(string codigo, string nombre)
        {
            if (String.IsNullOrEmpty(codigo))
            {
                throw new ApplicationException(Message.CodigoVacio);
            }
            if (String.IsNullOrEmpty(nombre))
            {
                throw new ApplicationException(Message.NombreVacio);
            }
        }
    }
}

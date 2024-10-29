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
    public class LTiposDocumentos
    {
        DTiposDocumentos objDTiposDocumentos;

        public LTiposDocumentos()
        {
            objDTiposDocumentos = new DTiposDocumentos();
        }

        public TiposDocumentos Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDTiposDocumentos = new DTiposDocumentos();
                TiposDocumentos objTiposDocumentos = new TiposDocumentos();
                objTiposDocumentos.Codigo = codigo;
                objTiposDocumentos.Nombre = nombre;
                objTiposDocumentos.Activo = true;
                objTiposDocumentos.Id = objDTiposDocumentos.Guardar(objTiposDocumentos);
                return objTiposDocumentos;
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

        public TiposDocumentos Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                TiposDocumentos objTiposDocumentos = objDTiposDocumentos.Consultar(id);
                if (objTiposDocumentos.Equals(null))
                {
                    throw new ApplicationException(Message.TipoDocumentoNull);
                }

                objDTiposDocumentos = new DTiposDocumentos();
                objTiposDocumentos.Codigo = codigo;
                objTiposDocumentos.Nombre = nombre;
                objTiposDocumentos.Activo = activo;
                objDTiposDocumentos.Actualizar(objTiposDocumentos);
                return objTiposDocumentos;
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

        public List<TiposDocumentos> Consultar()
        {
            try
            {
                return objDTiposDocumentos.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<TiposDocumentos>> Consultar(int top, int posicion)
        {
            try
            {
                return objDTiposDocumentos.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TiposDocumentos Consultar(int id)
        {
            try
            {
                return objDTiposDocumentos.Consultar(id);
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

        public TiposDocumentos Consultar(string codigo)
        {
            try
            {
                return objDTiposDocumentos.Consultar(codigo);
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
                TiposDocumentos TiposDocumentos = objDTiposDocumentos.Consultar(id);
                if (TiposDocumentos != null)
                {
                    objDTiposDocumentos.Eliminar(TiposDocumentos);
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

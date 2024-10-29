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
    public class LTipoPatron
    {
        DTipoPatron objDTipoPatron;

        public LTipoPatron()
        {
            objDTipoPatron = new DTipoPatron();
        }

        public TipoPatron Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDTipoPatron = new DTipoPatron();
                TipoPatron objTipoPatron = new TipoPatron();
                objTipoPatron.Codigo = codigo;
                objTipoPatron.Nombre = nombre;
                objTipoPatron.Activo = true;
                objTipoPatron.Id = objDTipoPatron.Guardar(objTipoPatron);
                return objTipoPatron;
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

        public TipoPatron Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                TipoPatron objTipoPatron = objDTipoPatron.Consultar(id);
                if (objTipoPatron.Equals(null))
                {
                    throw new ApplicationException(Message.TipoPatronNull);
                }

                objDTipoPatron = new DTipoPatron();
                objTipoPatron.Codigo = codigo;
                objTipoPatron.Nombre = nombre;
                objTipoPatron.Activo = activo;
                objDTipoPatron.Actualizar(objTipoPatron);
                return objTipoPatron;
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

        public List<TipoPatron> Consultar()
        {
            try
            {
                return objDTipoPatron.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<TipoPatron>> Consultar(int top, int posicion)
        {
            try
            {
                return objDTipoPatron.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoPatron Consultar(int id)
        {
            try
            {
                return objDTipoPatron.Consultar(id);
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

        public TipoPatron Consultar(string codigo)
        {
            try
            {
                return objDTipoPatron.Consultar(codigo);
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
                TipoPatron TipoPatron = objDTipoPatron.Consultar(id);
                if (TipoPatron != null)
                {
                    objDTipoPatron.Eliminar(TipoPatron);
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

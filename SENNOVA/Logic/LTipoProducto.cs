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
    public class LTipoProducto
    {
        DTipoProducto objDTipoProducto;

        public LTipoProducto()
        {
            objDTipoProducto = new DTipoProducto();
        }

        public TipoProducto Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDTipoProducto = new DTipoProducto();
                TipoProducto objTipoProducto = new TipoProducto();
                objTipoProducto.Codigo = codigo;
                objTipoProducto.Nombre = nombre;
                objTipoProducto.Activo = true;
                objTipoProducto.Id = objDTipoProducto.Guardar(objTipoProducto);
                return objTipoProducto;
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

        public TipoProducto Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                TipoProducto objTipoProducto = objDTipoProducto.Consultar(id);
                if (objTipoProducto.Equals(null))
                {
                    throw new ApplicationException(Message.TipoProductoNull);
                }

                objDTipoProducto = new DTipoProducto();
                objTipoProducto.Codigo = codigo;
                objTipoProducto.Nombre = nombre;
                objTipoProducto.Activo = activo;
                objDTipoProducto.Actualizar(objTipoProducto);
                return objTipoProducto;
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

        public List<TipoProducto> Consultar()
        {
            try
            {
                return objDTipoProducto.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<TipoProducto>> Consultar(int top, int posicion)
        {
            try
            {
                return objDTipoProducto.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoProducto Consultar(int id)
        {
            try
            {
                return objDTipoProducto.Consultar(id);
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

        public TipoProducto Consultar(string codigo)
        {
            try
            {
                return objDTipoProducto.Consultar(codigo);
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
                TipoProducto TipoProducto = objDTipoProducto.Consultar(id);
                if (TipoProducto != null)
                {
                    objDTipoProducto.Eliminar(TipoProducto);
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

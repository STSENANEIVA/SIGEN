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
    public class LProducto
    {
        DProducto objDProducto;

        public LProducto()
        {
            objDProducto = new DProducto();
        }

        public Producto Guardar(string codigo, string nombre, int idTipoProducto, int IdActividad)
        {
            try
            {
                ValidarCampos(codigo, nombre, idTipoProducto, IdActividad);

                objDProducto = new DProducto();
                Producto objProducto = new Producto();
                objProducto.Codigo = codigo;
                objProducto.Nombre = nombre;
                objProducto.Activo = true;
                objProducto.TipoProducto = new TipoProducto() { Id = idTipoProducto};
                objProducto.Actividad = new Actividad() { Id = IdActividad };
                objProducto.Id = objDProducto.Guardar(objProducto);
                return objProducto;
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

        public Producto Actualizar(int id, string codigo, string nombre, bool activo, int idTipoProducto, int IdActividad)
        {
            try
            {
                ValidarCampos(codigo, nombre, idTipoProducto, IdActividad);

                Producto objProducto = objDProducto.Consultar(id);
                if (objProducto.Equals(null))
                {
                    throw new ApplicationException(Message.ProductoNull);
                }

                objDProducto = new DProducto();
                objProducto.Codigo = codigo;
                objProducto.Nombre = nombre;
                objProducto.Activo = activo;
                objProducto.TipoProducto = new TipoProducto() { Id = idTipoProducto };
                objProducto.Actividad = new Actividad() { Id = IdActividad };
                objDProducto.Actualizar(objProducto);
                return objProducto;
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

        public List<Producto> Consultar()
        {
            try
            {
                return objDProducto.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Producto>> Consultar(int top, int posicion)
        {
            try
            {
                return objDProducto.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Producto Consultar(int id)
        {
            try
            {
                return objDProducto.Consultar(id);
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

        public Producto Consultar(string codigo)
        {
            try
            {
                return objDProducto.Consultar(codigo);
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
                Producto Producto = objDProducto.Consultar(id);
                if (Producto != null)
                {
                    objDProducto.Eliminar(Producto);
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

        private void ValidarCampos(string codigo, string nombre, int idTipoProducto, int IdActividad)
        {
            if (String.IsNullOrEmpty(codigo))
            {
                throw new ApplicationException(Message.CodigoVacio);
            }
            if (String.IsNullOrEmpty(nombre))
            {
                throw new ApplicationException(Message.NombreVacio);
            }
            if (String.IsNullOrEmpty(idTipoProducto.ToString()))
            {
                throw new ApplicationException(Message.TipoProductoVacio);
            }
            if (String.IsNullOrEmpty(IdActividad.ToString()))
            {
                throw new ApplicationException(Message.ActividadVacio);
            }
        }

        public Producto ConsultarPorTipoProducto(int id)
        {
            try
            {
                return objDProducto.ConsultarPorTipoProducto(id);
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

        public List<Producto> ConsultarPorActividad(int idActividad)
        {
            try
            {
                return objDProducto.ConsultarPorActividad(idActividad);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

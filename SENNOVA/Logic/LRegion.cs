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
    public class LRegion
    {
        DRegion objDRegion;

        public LRegion()
        {
            objDRegion = new DRegion();
        }

        public Region Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDRegion = new DRegion();
                Region objRegion = new Region();
                objRegion.Codigo = codigo;
                objRegion.Nombre = nombre;
                objRegion.Activo = true;
                objRegion.Id = objDRegion.Guardar(objRegion);
                return objRegion;
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

        public Region Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Region objRegion = objDRegion.Consultar(id);
                if (objRegion.Equals(null))
                {
                    throw new ApplicationException(Message.RegionNull);
                }

                objDRegion = new DRegion();
                objRegion.Codigo = codigo;
                objRegion.Nombre = nombre;
                objRegion.Activo = activo;
                objDRegion.Actualizar(objRegion);
                return objRegion;
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

        public List<Region> Consultar()
        {
            try
            {
                return objDRegion.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Region>> Consultar(int top, int posicion)
        {
            try
            {
                return objDRegion.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Region Consultar(int id)
        {
            try
            {
                return objDRegion.Consultar(id);
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

        public Region Consultar(string codigo)
        {
            try
            {
                return objDRegion.Consultar(codigo);
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
                Region Region = objDRegion.Consultar(id);
                if (Region != null)
                {
                    objDRegion.Eliminar(Region);
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

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
    public class LRegional
    {
        DRegional objDRegional;

        public LRegional()
        {
            objDRegional = new DRegional();
        }

        public Regional Guardar(string codigo, string nombre, int idRegion)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDRegional = new DRegional();
                Regional objRegional = new Regional();
                objRegional.Codigo = codigo;
                objRegional.Nombre = nombre;
                objRegional.Activo = true;
                objRegional.Region = new Region() { Id = idRegion };
                objRegional.Id = objDRegional.Guardar(objRegional);
                return objRegional;
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

        public Regional Actualizar(int id, string codigo, string nombre, bool activo, int idRegion)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Regional objRegional = objDRegional.Consultar(id);
                if (objRegional.Equals(null))
                {
                    throw new ApplicationException(Message.RegionalNull);
                }

                objDRegional = new DRegional();
                objRegional.Codigo = codigo;
                objRegional.Nombre = nombre;
                objRegional.Activo = activo;
                objRegional.Region = new Region() { Id = idRegion };
                objDRegional.Actualizar(objRegional);
                return objRegional;
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

        public List<Regional> Consultar()
        {
            try
            {
                return objDRegional.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Regional>> Consultar(int top, int posicion)
        {
            try
            {
                return objDRegional.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Regional Consultar(int id)
        {
            try
            {
                return objDRegional.Consultar(id);
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

        public Regional Consultar(string codigo)
        {
            try
            {
                return objDRegional.Consultar(codigo);
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
                Regional Regional = objDRegional.Consultar(id);
                if (Regional != null)
                {
                    objDRegional.Eliminar(Regional);
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

        public Regional ConsultarPorRegion(int id)
        {
            try
            {
                return objDRegional.ConsultarPorRegion(id);
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

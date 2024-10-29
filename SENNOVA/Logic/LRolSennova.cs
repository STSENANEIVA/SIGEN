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
    public class LRolSennova
    {
        DRolSennova objDRolSennova;

        public LRolSennova()
        {
            objDRolSennova = new DRolSennova();
        }

        public RolSennova Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDRolSennova = new DRolSennova();
                RolSennova objRolSennova = new RolSennova();
                objRolSennova.Codigo = codigo;
                objRolSennova.Nombre = nombre;
                objRolSennova.Activo = true;
                objRolSennova.Id = objDRolSennova.Guardar(objRolSennova);
                return objRolSennova;
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

        public RolSennova Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                RolSennova objRolSennova = objDRolSennova.Consultar(id);
                if (objRolSennova.Equals(null))
                {
                    throw new ApplicationException(Message.RolSennovaNull);
                }

                objDRolSennova = new DRolSennova();
                objRolSennova.Codigo = codigo;
                objRolSennova.Nombre = nombre;
                objRolSennova.Activo = activo;
                objDRolSennova.Actualizar(objRolSennova);
                return objRolSennova;
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

        public List<RolSennova> Consultar()
        {
            try
            {
                return objDRolSennova.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<RolSennova>> Consultar(int top, int posicion)
        {
            try
            {
                return objDRolSennova.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RolSennova Consultar(int id)
        {
            try
            {
                return objDRolSennova.Consultar(id);
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

        public RolSennova Consultar(string codigo)
        {
            try
            {
                return objDRolSennova.Consultar(codigo);
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
                RolSennova RolSennova = objDRolSennova.Consultar(id);
                if (RolSennova != null)
                {
                    objDRolSennova.Eliminar(RolSennova);
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

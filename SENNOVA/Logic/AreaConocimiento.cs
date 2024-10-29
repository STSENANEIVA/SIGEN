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
    public class LAreaConocimiento
    {
        DAreaConocimiento objDAreaConocimiento;

        public LAreaConocimiento()
        {
            objDAreaConocimiento = new DAreaConocimiento();
        }

        public AreaConocimiento Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDAreaConocimiento = new DAreaConocimiento();
                AreaConocimiento objAreaConocimiento = new AreaConocimiento();
                objAreaConocimiento.Codigo = codigo;
                objAreaConocimiento.Nombre = nombre;
                objAreaConocimiento.Activo = true;
                objAreaConocimiento.Id = objDAreaConocimiento.Guardar(objAreaConocimiento);
                return objAreaConocimiento;
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

        public AreaConocimiento Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                AreaConocimiento objAreaConocimiento = objDAreaConocimiento.Consultar(id);
                if (objAreaConocimiento.Equals(null))
                {
                    throw new ApplicationException(Message.AreaConocimientoNull);
                }

                objDAreaConocimiento = new DAreaConocimiento();
                objAreaConocimiento.Codigo = codigo;
                objAreaConocimiento.Nombre = nombre;
                objAreaConocimiento.Activo = activo;
                objDAreaConocimiento.Actualizar(objAreaConocimiento);
                return objAreaConocimiento;
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

        public List<AreaConocimiento> Consultar()
        {
            try
            {
                return objDAreaConocimiento.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<AreaConocimiento>> Consultar(int top, int posicion)
        {
            try
            {
                return objDAreaConocimiento.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AreaConocimiento Consultar(int id)
        {
            try
            {
                return objDAreaConocimiento.Consultar(id);
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

        public AreaConocimiento Consultar(string codigo)
        {
            try
            {
                return objDAreaConocimiento.Consultar(codigo);
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
                AreaConocimiento AreaConocimiento = objDAreaConocimiento.Consultar(id);
                if (AreaConocimiento != null)
                {
                    objDAreaConocimiento.Eliminar(AreaConocimiento);
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

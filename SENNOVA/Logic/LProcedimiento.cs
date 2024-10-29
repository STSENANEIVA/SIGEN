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
    public class LProcedimiento
    {
        DProcedimiento objDProcedimiento;

        public LProcedimiento()
        {
            objDProcedimiento = new DProcedimiento();
        }

        public Procedimiento Guardar(string codigo, string nombre, int idProceso)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDProcedimiento = new DProcedimiento();
                Procedimiento objProcedimiento = new Procedimiento();
                objProcedimiento.Codigo = codigo;
                objProcedimiento.Nombre = nombre;
                objProcedimiento.Activo = true;
                objProcedimiento.Proceso = new Proceso() { Id = idProceso };
                objProcedimiento.Id = objDProcedimiento.Guardar(objProcedimiento);
                return objProcedimiento;
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

        public Procedimiento Actualizar(int id, string codigo, string nombre, bool activo, int idProceso)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Procedimiento objProcedimiento = objDProcedimiento.Consultar(id);
                if (objProcedimiento.Equals(null))
                {
                    throw new ApplicationException(Message.ProcedimientoNull);
                }

                objDProcedimiento = new DProcedimiento();
                objProcedimiento.Codigo = codigo;
                objProcedimiento.Nombre = nombre;
                objProcedimiento.Activo = activo;
                objProcedimiento.Proceso = new Proceso() { Id = idProceso };
                objDProcedimiento.Actualizar(objProcedimiento);
                return objProcedimiento;
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

        public List<Procedimiento> Consultar()
        {
            try
            {
                return objDProcedimiento.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Procedimiento>> Consultar(int top, int posicion)
        {
            try
            {
                return objDProcedimiento.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Procedimiento Consultar(int id)
        {
            try
            {
                return objDProcedimiento.Consultar(id);
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

        public Procedimiento Consultar(string codigo)
        {
            try
            {
                return objDProcedimiento.Consultar(codigo);
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
                Procedimiento Procedimiento = objDProcedimiento.Consultar(id);
                if (Procedimiento != null)
                {
                    objDProcedimiento.Eliminar(Procedimiento);
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

        public Procedimiento ConsultarPorProceso(int id)
        {
            try
            {
                return objDProcedimiento.ConsultarPorProceso(id);
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

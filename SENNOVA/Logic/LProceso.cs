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
    public class LProceso
    {
        DProceso objDProceso;

        public LProceso()
        {
            objDProceso = new DProceso();
        }

        public Proceso Guardar(string codigo, string nombre, int idMacroProceso)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDProceso = new DProceso();
                Proceso objProceso = new Proceso();
                objProceso.Codigo = codigo;
                objProceso.Nombre = nombre;
                objProceso.Activo = true;
                objProceso.MacroProceso = new MacroProceso() { Id = idMacroProceso };
                objProceso.Id = objDProceso.Guardar(objProceso);
                return objProceso;
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

        public Proceso Actualizar(int id, string codigo, string nombre, bool activo, int idMacroProceso)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Proceso objProceso = objDProceso.Consultar(id);
                if (objProceso.Equals(null))
                {
                    throw new ApplicationException(Message.ProcesoNull);
                }

                objDProceso = new DProceso();
                objProceso.Codigo = codigo;
                objProceso.Nombre = nombre;
                objProceso.Activo = activo;
                objProceso.MacroProceso = new MacroProceso() { Id = idMacroProceso };
                objDProceso.Actualizar(objProceso);
                return objProceso;
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

        public List<Proceso> Consultar()
        {
            try
            {
                return objDProceso.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Proceso>> Consultar(int top, int posicion)
        {
            try
            {
                return objDProceso.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Proceso Consultar(int id)
        {
            try
            {
                return objDProceso.Consultar(id);
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

        public Proceso Consultar(string codigo)
        {
            try
            {
                return objDProceso.Consultar(codigo);
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
                Proceso Proceso = objDProceso.Consultar(id);
                if (Proceso != null)
                {
                    objDProceso.Eliminar(Proceso);
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

        public Proceso ConsultarPorMacroProceso(int id)
        {
            try
            {
                return objDProceso.ConsultarPorMacroProceso(id);
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

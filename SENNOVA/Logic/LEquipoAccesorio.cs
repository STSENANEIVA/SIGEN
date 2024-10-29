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
    public class LEquipoAccesorio
    {
        DEquipoAccesorio objDEquipoAccesorio;

        public LEquipoAccesorio()
        {
            objDEquipoAccesorio = new DEquipoAccesorio();
        }

        public EquipoAccesorio Guardar(int idAccesorio, int idEquipo)
        {
            try
            {
                ValidarCampos(idAccesorio, idEquipo);

                objDEquipoAccesorio = new DEquipoAccesorio();
                EquipoAccesorio objEquipoAccesorio = new EquipoAccesorio();
                objEquipoAccesorio.Accesorios = new Accesorios { Id = idAccesorio };
                objEquipoAccesorio.Equipo = new Equipo { Id = idEquipo };
                objEquipoAccesorio.Id = objDEquipoAccesorio.Guardar(objEquipoAccesorio);
                return objEquipoAccesorio;
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

        public EquipoAccesorio Actualizar(int id, int idAccesorio, int idEquipo)
        {
            try
            {
                ValidarCampos(idAccesorio, idEquipo);

                EquipoAccesorio objEquipoAccesorio = objDEquipoAccesorio.Consultar(id);
                if (objEquipoAccesorio.Equals(null))
                {
                    throw new ApplicationException(Message.EquipoAccesorioNull);
                }

                objDEquipoAccesorio = new DEquipoAccesorio();
                objEquipoAccesorio.Accesorios = new Accesorios { Id = idAccesorio};
                objEquipoAccesorio.Equipo = new Equipo { Id = idEquipo };
                objDEquipoAccesorio.Actualizar(objEquipoAccesorio);
                return objEquipoAccesorio;
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

        public List<EquipoAccesorio> Consultar()
        {
            try
            {
                return objDEquipoAccesorio.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<EquipoAccesorio> ConsultarEquipo(int idEquipo)
        {
            try
            {
                return objDEquipoAccesorio.ConsultarEquipo(idEquipo);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<EquipoAccesorio>> Consultar(int top, int posicion)
        {
            try
            {
                return objDEquipoAccesorio.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EquipoAccesorio Consultar(int id)
        {
            try
            {
                return objDEquipoAccesorio.Consultar(id);
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
                EquipoAccesorio EquipoAccesorio = objDEquipoAccesorio.Consultar(id);
                if (EquipoAccesorio != null)
                {
                    objDEquipoAccesorio.Eliminar(EquipoAccesorio);
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

        private void ValidarCampos(int idAccesorio, int idEquipo)
        {
           
          
            if (String.IsNullOrEmpty(idAccesorio.ToString()))
            {
                throw new ApplicationException(Message.AccesoriosVacio);
            }
            if (String.IsNullOrEmpty(idEquipo.ToString()))
            {
                throw new ApplicationException(Message.EquipoVacio);
            }
        }

        public EquipoAccesorio ConsultarPorAccesorio(int id)
        {
            try
            {
                return objDEquipoAccesorio.ConsultarPorAccesorio(id);
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

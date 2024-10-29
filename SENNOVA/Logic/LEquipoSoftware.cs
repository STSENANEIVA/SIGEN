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
    public class LEquipoSoftware
    {
        DEquipoSoftware objDEquipoSoftware;

        public LEquipoSoftware()
        {
            objDEquipoSoftware = new DEquipoSoftware();
        }

        public EquipoSoftware Guardar(int idSoftware, int idComputo)
        {
            try
            {
                ValidarCampos(idSoftware, idComputo);

                objDEquipoSoftware = new DEquipoSoftware();
                EquipoSoftware objEquipoSoftware = new EquipoSoftware();
                objEquipoSoftware.Software = new Software { Id = idSoftware };
                objEquipoSoftware.Computo = new Computo { Id = idComputo };
                objEquipoSoftware.Id = objDEquipoSoftware.Guardar(objEquipoSoftware);
                return objEquipoSoftware;
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

        public EquipoSoftware Actualizar(int id, int idSoftware, int idComputo)
        {
            try
            {
                ValidarCampos(idSoftware, idComputo);

                EquipoSoftware objEquipoSoftware = objDEquipoSoftware.Consultar(id);
                if (objEquipoSoftware.Equals(null))
                {
                    throw new ApplicationException(Message.EquipoSoftwareNull);
                }

                objDEquipoSoftware = new DEquipoSoftware();
                objEquipoSoftware.Software = new Software { Id = idSoftware};
                objEquipoSoftware.Computo = new Computo { Id = idComputo };
                objDEquipoSoftware.Actualizar(objEquipoSoftware);
                return objEquipoSoftware;
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

        public List<EquipoSoftware> Consultar()
        {
            try
            {
                return objDEquipoSoftware.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<EquipoSoftware>> Consultar(int top, int posicion)
        {
            try
            {
                return objDEquipoSoftware.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EquipoSoftware Consultar(int id)
        {
            try
            {
                return objDEquipoSoftware.Consultar(id);
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
                EquipoSoftware EquipoSoftware = objDEquipoSoftware.Consultar(id);
                if (EquipoSoftware != null)
                {
                    objDEquipoSoftware.Eliminar(EquipoSoftware);
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

        private void ValidarCampos(int idSoftware, int idComputo)
        {
           
          
            if (String.IsNullOrEmpty(idSoftware.ToString()))
            {
                throw new ApplicationException(Message.SoftwareVacio);
            }
            if (String.IsNullOrEmpty(idComputo.ToString()))
            {
                throw new ApplicationException(Message.ComputoVacio);
            }
        }

        public EquipoSoftware ConsultarPorSoftware(int id)
        {
            try
            {
                return objDEquipoSoftware.ConsultarPorSoftware(id);
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

        public List<EquipoSoftware> ConsultarEquipo(int idcomputo)
        {
            try
            {
                return objDEquipoSoftware.ConsultarEquipo(idcomputo);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

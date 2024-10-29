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
    public class LVisitante
    {
        DVisitante objDVisitante;

        public LVisitante()
        {
            objDVisitante = new DVisitante();
        }

        public Visitante Guardar(int idPersona, int idTipoVisitante)
        {
            try
            {
                ValidarCampos(idPersona, idTipoVisitante);

                objDVisitante = new DVisitante();
                Visitante objVisitante = new Visitante();
                objVisitante.Persona = new Persona { Id = idPersona };
                objVisitante.TipoVisitante = new TipoVisitante { Id = idTipoVisitante };
                objVisitante.Id = objDVisitante.Guardar(objVisitante);
                return objVisitante;
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

        public Visitante Actualizar(int id, int idPersona, int idTipoVisitante)
        {
            try
            {
                ValidarCampos(idPersona, idTipoVisitante);

                Visitante objVisitante = objDVisitante.Consultar(id);
                if (objVisitante.Equals(null))
                {
                    throw new ApplicationException(Message.VisitanteNull);
                }

                objDVisitante = new DVisitante();
                objVisitante.Persona = new Persona { Id = idPersona};
                objVisitante.TipoVisitante = new TipoVisitante { Id = idTipoVisitante };
                objDVisitante.Actualizar(objVisitante);
                return objVisitante;
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

        public List<Visitante> Consultar()
        {
            try
            {
                return objDVisitante.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Visitante>> Consultar(int top, int posicion)
        {
            try
            {
                return objDVisitante.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Visitante Consultar(int id)
        {
            try
            {
                return objDVisitante.Consultar(id);
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
                Visitante Visitante = objDVisitante.Consultar(id);
                if (Visitante != null)
                {
                    objDVisitante.Eliminar(Visitante);
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

        private void ValidarCampos(int idPersona, int idTipoVisitante)
        {
           
          
            if (String.IsNullOrEmpty(idPersona.ToString()))
            {
                throw new ApplicationException(Message.PersonaVacio);
            }
            if (String.IsNullOrEmpty(idTipoVisitante.ToString()))
            {
                throw new ApplicationException(Message.TipoVisitanteVacio);
            }
        }

        public Visitante ConsultarPorPersona(int id)
        {
            try
            {
                return objDVisitante.ConsultarPorPersona(id);
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

        public Visitante ConsultarPorTipoVisitante(int idTipoVisitante)
        {
            try
            {
                return objDVisitante.ConsultarPorTipoVisitante(idTipoVisitante);
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

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
    public class LSectorEconomico
    {
        DSectorEconomico objDSectorEconomico;

        public LSectorEconomico()
        {
            objDSectorEconomico = new DSectorEconomico();
        }

        public SectorEconomico Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDSectorEconomico = new DSectorEconomico();
                SectorEconomico objSectorEconomico = new SectorEconomico();
                objSectorEconomico.Codigo = codigo;
                objSectorEconomico.Nombre = nombre;
                objSectorEconomico.Activo = true;
                objSectorEconomico.Id = objDSectorEconomico.Guardar(objSectorEconomico);
                return objSectorEconomico;
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

        public SectorEconomico Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                SectorEconomico objSectorEconomico = objDSectorEconomico.Consultar(id);
                if (objSectorEconomico.Equals(null))
                {
                    throw new ApplicationException(Message.SectorEconomicoNull);
                }

                objDSectorEconomico = new DSectorEconomico();
                objSectorEconomico.Codigo = codigo;
                objSectorEconomico.Nombre = nombre;
                objSectorEconomico.Activo = activo;
                objDSectorEconomico.Actualizar(objSectorEconomico);
                return objSectorEconomico;
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

        public List<SectorEconomico> Consultar()
        {
            try
            {
                return objDSectorEconomico.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<SectorEconomico>> Consultar(int top, int posicion)
        {
            try
            {
                return objDSectorEconomico.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SectorEconomico Consultar(int id)
        {
            try
            {
                return objDSectorEconomico.Consultar(id);
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

        public SectorEconomico Consultar(string codigo)
        {
            try
            {
                return objDSectorEconomico.Consultar(codigo);
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

        public SectorEconomico ConsultarNombre(string nombre)
        {
            try
            {
                return objDSectorEconomico.ConsultarNombre(nombre);
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
                SectorEconomico SectorEconomico = objDSectorEconomico.Consultar(id);
                if (SectorEconomico != null)
                {
                    objDSectorEconomico.Eliminar(SectorEconomico);
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

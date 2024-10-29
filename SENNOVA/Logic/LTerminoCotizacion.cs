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
    public class LTerminoCotizacion
    {
        DTerminoCotizacion objDTerminoCotizacion;

        public LTerminoCotizacion()
        {
            objDTerminoCotizacion = new DTerminoCotizacion();
        }

        public TerminoCotizacion Guardar(int idTerminoCondicion, int idCotizacion)
        {
            try
            {
                objDTerminoCotizacion = new DTerminoCotizacion();
                TerminoCotizacion objTerminoCotizacion = new TerminoCotizacion();
                objTerminoCotizacion.TerminoCondicion = new TerminoCondicion() { Id = idTerminoCondicion };
                objTerminoCotizacion.Cotizacion = new Cotizacion() { Id = idCotizacion };
                objTerminoCotizacion.Id = objDTerminoCotizacion.Guardar(objTerminoCotizacion);
                return objTerminoCotizacion;
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

        public TerminoCotizacion Actualizar(int id, int idTerminoCondicion, int idCotizacion)
        {
            try
            {

                TerminoCotizacion objTerminoCotizacion = objDTerminoCotizacion.Consultar(id);
                if (objTerminoCotizacion.Equals(null))
                {
                    throw new ApplicationException(Message.TerminoCondicionNull);
                }

                objDTerminoCotizacion = new DTerminoCotizacion();
                objTerminoCotizacion.TerminoCondicion = new TerminoCondicion() { Id = idTerminoCondicion };
                objTerminoCotizacion.Cotizacion = new Cotizacion() { Id = idCotizacion };
                objDTerminoCotizacion.Actualizar(objTerminoCotizacion);
                return objTerminoCotizacion;
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

        public List<TerminoCotizacion> Consultar()
        {
            try
            {
                return objDTerminoCotizacion.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public TerminoCotizacion Consultar(int id)
        {
            try
            {
                return objDTerminoCotizacion.Consultar(id);
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

        public TerminoCotizacion ConsultarPorTerminoCondicion(int id)
        {
            try
            {
                return objDTerminoCotizacion.ConsultarPorTerminoCondicion(id);
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
                TerminoCotizacion TerminoCotizacion = objDTerminoCotizacion.Consultar(id);
                if (TerminoCotizacion != null)
                {
                    objDTerminoCotizacion.Eliminar(TerminoCotizacion);
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
    }
}

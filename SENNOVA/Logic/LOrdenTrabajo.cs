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
    public class LOrdenTrabajo
    {
        DOrdenTrabajo objDOrdenTrabajo;

        public LOrdenTrabajo()
        {
            objDOrdenTrabajo = new DOrdenTrabajo();
        }

        public OrdenTrabajo Guardar(bool AutorizaIngreso, string NumeroOT, DateTime FechaEmision, DateTime FechaLimite, DateTime FechaIngresoItem, string Observaciones, int idAreaTecnica, int idCotizacion, int idResponzable)
        {
            try
            {
                ValidarCampos(AutorizaIngreso, NumeroOT, FechaEmision, FechaLimite, FechaIngresoItem, Observaciones, idAreaTecnica, idCotizacion, idResponzable);
                
                objDOrdenTrabajo = new DOrdenTrabajo();
                OrdenTrabajo objOrdenTrabajo = new OrdenTrabajo();

                objOrdenTrabajo.AutorizaIngreso = AutorizaIngreso;
                objOrdenTrabajo.NumeroOT = NumeroOT;
                objOrdenTrabajo.FechaEmision = FechaEmision;
                objOrdenTrabajo.FechaLimite = FechaLimite;
                objOrdenTrabajo.FechaIngresoItem = FechaIngresoItem;
                objOrdenTrabajo.Observaciones = Observaciones;
                objOrdenTrabajo.AreaTecnica = new AreaTecnica() { Id = idAreaTecnica };
                objOrdenTrabajo.Cotizacion = new Cotizacion() { Id = idCotizacion };
                objOrdenTrabajo.Responzable = new Empleado() { Id = idResponzable };

                objOrdenTrabajo.Id = objDOrdenTrabajo.Guardar(objOrdenTrabajo);
                return objOrdenTrabajo;
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

        public OrdenTrabajo Actualizar(int id, bool AutorizaIngreso, string NumeroOT, DateTime FechaEmision, DateTime FechaLimite, DateTime FechaIngresoItem, string Observaciones, int idAreaTecnica, int idCotizacion, int idResponzable)
        {
            try
            {
                ValidarCampos(AutorizaIngreso, NumeroOT, FechaEmision, FechaLimite, FechaIngresoItem, Observaciones, idAreaTecnica, idCotizacion, idResponzable);

                OrdenTrabajo objOrdenTrabajo = objDOrdenTrabajo.Consultar(id);
                if (objOrdenTrabajo.Equals(null))
                {
                    throw new ApplicationException(Message.OrdenTrabajoNull);
                }

                objDOrdenTrabajo = new DOrdenTrabajo();

                objOrdenTrabajo.AutorizaIngreso = AutorizaIngreso;
                objOrdenTrabajo.NumeroOT = NumeroOT;
                objOrdenTrabajo.FechaEmision = FechaEmision;
                objOrdenTrabajo.FechaLimite = FechaLimite;
                objOrdenTrabajo.FechaIngresoItem = FechaIngresoItem;
                objOrdenTrabajo.Observaciones = Observaciones;
                objOrdenTrabajo.AreaTecnica = new AreaTecnica() { Id = idAreaTecnica };
                objOrdenTrabajo.Cotizacion = new Cotizacion() { Id = idCotizacion };
                objOrdenTrabajo.Responzable = new Empleado() { Id = idResponzable };
                objDOrdenTrabajo.Actualizar(objOrdenTrabajo);
                return objOrdenTrabajo;
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

        public List<OrdenTrabajo> Consultar()
        {
            try
            {
                return objDOrdenTrabajo.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<OrdenTrabajo>> Consultar(int top, int posicion)
        {
            try
            {
                return objDOrdenTrabajo.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public OrdenTrabajo Consultar(int id)
        {
            try
            {
                return objDOrdenTrabajo.Consultar(id);
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

        public OrdenTrabajo ConsultarPorAreaTecnica(int idAreaTecnica)
        {
            try
            {
                return objDOrdenTrabajo.ConsultarPorAreaTecnica(idAreaTecnica);
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
                OrdenTrabajo OrdenTrabajo = objDOrdenTrabajo.Consultar(id);
                if (OrdenTrabajo != null)
                {
                    objDOrdenTrabajo.Eliminar(OrdenTrabajo);
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

        private void ValidarCampos(bool AutorizaIngreso, string NumeroOT, DateTime FechaEmision, DateTime FechaLimite, DateTime FechaIngresoItem, string Observaciones, int idAreaTecnica, int idCotizacion, int idResponzable)
        {

            if ( String.IsNullOrEmpty(NumeroOT) )
            {
                throw new ApplicationException(Message.NumeroOTVacio);
            }

            if (String.IsNullOrEmpty(FechaEmision.ToString()))
            {
                throw new ApplicationException(Message.FechaEmisionVacio);
            }

            if (String.IsNullOrEmpty(FechaLimite.ToString()))
            {
                throw new ApplicationException(Message.FechaLimiteVacio);
            }

            if (String.IsNullOrEmpty(FechaIngresoItem.ToString()))
            {
                throw new ApplicationException(Message.FechaIngresoItemVacio);
            }
        }
    }
}

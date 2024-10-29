using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Logic
{
    public class LOrdenTrabajoDetalle
    {
        DOrdenTrabajoDetalle objDOrdenTrabajoDetalle;

        public LOrdenTrabajoDetalle()
        {
            objDOrdenTrabajoDetalle = new DOrdenTrabajoDetalle();
        }

        public OrdenTrabajoDetalle Guardar(decimal Cantidad, string CodigoItem, string Servicio, DateTime FechaInicio, DateTime FechaFinal, string Observaciones, int idOrdenTrabajo)
        {
            try
            {
                ValidarCampos(Cantidad, CodigoItem, Servicio, FechaInicio, FechaFinal, Observaciones, idOrdenTrabajo);

                objDOrdenTrabajoDetalle = new DOrdenTrabajoDetalle();
                OrdenTrabajoDetalle objOrdenTrabajoDetalle = new OrdenTrabajoDetalle();

                objOrdenTrabajoDetalle.Cantidad = Cantidad;
                objOrdenTrabajoDetalle.CodigoItem = CodigoItem;
                objOrdenTrabajoDetalle.Servicio = Servicio;
                objOrdenTrabajoDetalle.FechaInicio = FechaInicio;
                objOrdenTrabajoDetalle.FechaFinal = FechaFinal;
                objOrdenTrabajoDetalle.Observaciones = Observaciones;

                objOrdenTrabajoDetalle.OrdenTrabajo = new OrdenTrabajo() { Id = idOrdenTrabajo };


                objOrdenTrabajoDetalle.Id = objDOrdenTrabajoDetalle.Guardar(objOrdenTrabajoDetalle);

                return objOrdenTrabajoDetalle;
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

        public OrdenTrabajoDetalle Actualizar(int id, decimal Cantidad, string CodigoItem, string Servicio, DateTime FechaInicio, DateTime FechaFinal, string Observaciones, int idOrdenTrabajo)
        {
            try
            {
                ValidarCampos(Cantidad, CodigoItem, Servicio, FechaInicio, FechaFinal, Observaciones, idOrdenTrabajo);

                OrdenTrabajoDetalle objOrdenTrabajoDetalle = objDOrdenTrabajoDetalle.Consultar(id);

                if (objOrdenTrabajoDetalle.Equals(null))
                {
                    throw new ApplicationException(Message.OrdenTrabajoNull);
                }

                objDOrdenTrabajoDetalle = new DOrdenTrabajoDetalle();

                objOrdenTrabajoDetalle.Cantidad = Cantidad;
                objOrdenTrabajoDetalle.CodigoItem = CodigoItem;
                objOrdenTrabajoDetalle.Servicio = Servicio;
                objOrdenTrabajoDetalle.FechaInicio = FechaInicio;
                objOrdenTrabajoDetalle.FechaFinal = FechaFinal;
                objOrdenTrabajoDetalle.Observaciones = Observaciones;

                objOrdenTrabajoDetalle.OrdenTrabajo = new OrdenTrabajo() { Id = idOrdenTrabajo };

                objDOrdenTrabajoDetalle.Actualizar(objOrdenTrabajoDetalle);
                return objOrdenTrabajoDetalle;
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

        public List<OrdenTrabajoDetalle> Consultar()
        {
            try
            {
                return objDOrdenTrabajoDetalle.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<OrdenTrabajoDetalle>> Consultar(int top, int posicion)
        {
            try
            {
                return objDOrdenTrabajoDetalle.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public OrdenTrabajoDetalle Consultar(int id)
        {
            try
            {
                return objDOrdenTrabajoDetalle.Consultar(id);
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

        public List<OrdenTrabajoDetalle> ConsultarPorOrdenTrabajo(int idOrdenTrabajo)
        {
            try
            {
                return objDOrdenTrabajoDetalle.ConsultarPorOrdenTrabajo(idOrdenTrabajo);
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
                OrdenTrabajoDetalle OrdenTrabajoDetalle = objDOrdenTrabajoDetalle.Consultar(id);
                if (OrdenTrabajoDetalle != null)
                {
                    objDOrdenTrabajoDetalle.Eliminar(OrdenTrabajoDetalle);
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

        private void ValidarCampos(decimal Cantidad, string CodigoItem, string Servicio, DateTime FechaInicio, DateTime FechaFinal, string Observaciones, int idOrdenTrabajo)
        {

            if (String.IsNullOrEmpty(Cantidad.ToString()))
            {
                throw new ApplicationException(Message.CantidadVacio);
            }

            if (String.IsNullOrEmpty(Servicio))
            {
                throw new ApplicationException(Message.ServicioVacio);
            }
        }
    }
}

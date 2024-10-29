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
    public class LCotizacionDetalle
    {
        DCotizacionDetalle objDCotizacionDetalle;

        public LCotizacionDetalle()
        {
            objDCotizacionDetalle = new DCotizacionDetalle();
        }

        public CotizacionDetalle Guardar(decimal PrecioServicio, decimal Cantidad, decimal ValorUnitario, string Observaciones, int idCotizacion, int idServicio)
        {
            try
            {
                ValidarCampos( PrecioServicio,  Cantidad,  ValorUnitario,  Observaciones,  idCotizacion,  idServicio);

                objDCotizacionDetalle = new DCotizacionDetalle();
                CotizacionDetalle objCotizacionDetalle = new CotizacionDetalle();
                objCotizacionDetalle.PrecioServicio = PrecioServicio;
                objCotizacionDetalle.Cantidad = Cantidad;
                objCotizacionDetalle.ValorUnitario = ValorUnitario;
                objCotizacionDetalle.Observaciones = Observaciones;
                objCotizacionDetalle.Cotizacion = new Cotizacion() { Id = idCotizacion };
                objCotizacionDetalle.Servicio = new Servicio() { Id = idServicio };

                objCotizacionDetalle.Id = objDCotizacionDetalle.Guardar(objCotizacionDetalle);
                return objCotizacionDetalle;
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

        public CotizacionDetalle Actualizar(int id, decimal PrecioServicio, decimal Cantidad, decimal ValorUnitario, string Observaciones, int idCotizacion, int idServicio)
        {
            try
            {
                ValidarCampos( PrecioServicio,  Cantidad,  ValorUnitario,  Observaciones,  idCotizacion,  idServicio);

                CotizacionDetalle objCotizacionDetalle = objDCotizacionDetalle.Consultar(id);
                if (objDCotizacionDetalle.Equals(null))
                {
                    throw new ApplicationException(Message.CotizacionNull);
                }
                objDCotizacionDetalle = new DCotizacionDetalle();
                objCotizacionDetalle.PrecioServicio = PrecioServicio;
                objCotizacionDetalle.Cantidad = Cantidad;
                objCotizacionDetalle.ValorUnitario = ValorUnitario;
                objCotizacionDetalle.Observaciones = Observaciones;
                objCotizacionDetalle.Cotizacion = new Cotizacion() { Id = idCotizacion };
                objCotizacionDetalle.Servicio = new Servicio() { Id = idServicio };
                objDCotizacionDetalle.Actualizar(objCotizacionDetalle);
                return objCotizacionDetalle;
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

        public List<CotizacionDetalle> Consultar()
        {
            try
            {
                return objDCotizacionDetalle.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public CotizacionDetalle Consultar(int id)
        {
            try
            {
                return objDCotizacionDetalle.Consultar(id);
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
                CotizacionDetalle CotizacionDetalle = objDCotizacionDetalle.Consultar(id);
                if (CotizacionDetalle != null)
                {
                    objDCotizacionDetalle.Eliminar(CotizacionDetalle);
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

        public List<CotizacionDetalle> ConsultarPorCotizacion(int id)
        {
            try
            {
                return objDCotizacionDetalle.ConsultarPorCotizacion(id);
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

        public CotizacionDetalle ConsultarPorServicio(int id)
        {
            try
            {
                return objDCotizacionDetalle.ConsultarPorServicio(id);
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

        private void ValidarCampos(decimal PrecioServicio, decimal Cantidad, decimal ValorUnitario, string Observaciones, int idCotizacion, int idServicio)
        {
            if (String.IsNullOrEmpty(PrecioServicio.ToString()))
            {
                throw new ApplicationException(Message.PrecioVacio);
            }
            if (String.IsNullOrEmpty(Cantidad.ToString()))
            {
                throw new ApplicationException(Message.CantidadVacio);
            }

            if (String.IsNullOrEmpty(ValorUnitario.ToString()))
            {
                throw new ApplicationException(Message.ValorUnitarioVacio);
            }

            if (String.IsNullOrEmpty(idServicio.ToString()))
            {
                throw new ApplicationException(Message.ServicioVacio);
            }
        }
    }
}

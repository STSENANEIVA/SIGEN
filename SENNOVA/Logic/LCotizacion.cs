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
    public class LCotizacion
    {
        DCotizacion objDCotizacion;

        public LCotizacion()
        {
            objDCotizacion = new DCotizacion();
        }

        public Cotizacion Guardar(string codigo, DateTime fecha, decimal valorTotal, string validezOferta, string numeroFicha, string tipoCotizacion, string observaciones, int idProgramaFormacion, int idElaborador, int idRevisador, int idAutorizador )
        {
            try
            {
                ValidarCampos(codigo, fecha, valorTotal, validezOferta, numeroFicha, tipoCotizacion, observaciones, idProgramaFormacion, idElaborador, idRevisador, idAutorizador);

                objDCotizacion = new DCotizacion();
                Cotizacion objCotizacion = new Cotizacion();
                objCotizacion.Codigo = codigo;
                objCotizacion.Fecha = fecha;
                objCotizacion.ValorTotal = valorTotal;
                objCotizacion.ValidezOferta = validezOferta;
                objCotizacion.NumeroFicha = numeroFicha;
                objCotizacion.TipoCotizacion = tipoCotizacion;
                objCotizacion.Observaciones = observaciones;
                objCotizacion.ProgramaFormacion = new ProgramaFormacion() { Id = idProgramaFormacion };
                objCotizacion.Elaborador = new Empleado() { Id = idElaborador };
                objCotizacion.Revisador = new Empleado() { Id = idRevisador };
                objCotizacion.Autorizador = new Empleado() { Id = idAutorizador };
                objCotizacion.Id = objDCotizacion.Guardar(objCotizacion);
                return objCotizacion;
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

        public Cotizacion Actualizar(int id, string codigo, DateTime fecha, decimal valorTotal, string validezOferta, string numeroFicha, string tipoCotizacion, string observaciones, int idProgramaFormacion, int idElaborador, int idRevisador, int idAutorizador)
        {
            try
            {
                ValidarCampos(codigo, fecha, valorTotal, validezOferta, numeroFicha, tipoCotizacion, observaciones, idProgramaFormacion, idElaborador, idRevisador, idAutorizador);

                Cotizacion objCotizacion = objDCotizacion.Consultar(id);
                if (objCotizacion.Equals(null))
                {
                    throw new ApplicationException(Message.CotizacionNull);
                }

                objDCotizacion = new DCotizacion();
                objCotizacion.Codigo = codigo;
                objCotizacion.Fecha = fecha;
                objCotizacion.ValorTotal = valorTotal;
                objCotizacion.ValidezOferta = validezOferta;
                objCotizacion.NumeroFicha = numeroFicha;
                objCotizacion.TipoCotizacion = tipoCotizacion;
                objCotizacion.Observaciones = observaciones;
                objCotizacion.ProgramaFormacion = new ProgramaFormacion() { Id = idProgramaFormacion };
                objCotizacion.Elaborador = new Empleado() { Id = idElaborador };
                objCotizacion.Revisador = new Empleado() { Id = idRevisador };
                objCotizacion.Autorizador = new Empleado() { Id = idAutorizador };
                objDCotizacion.Actualizar(objCotizacion);
                return objCotizacion;
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

        public List<Cotizacion> Consultar()
        {
            try
            {
                return objDCotizacion.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Cotizacion>> Consultar(int top, int posicion)
        {
            try
            {
                return objDCotizacion.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cotizacion Consultar(int id)
        {
            try
            {
                return objDCotizacion.Consultar(id);
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

        public Cotizacion Consultar(string codigo)
        {
            try
            {
                return objDCotizacion.Consultar(codigo);
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
                Cotizacion Cotizacion = objDCotizacion.Consultar(id);
                if (Cotizacion != null)
                {
                    objDCotizacion.Eliminar(Cotizacion);
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

        private void ValidarCampos(string codigo, DateTime fecha, decimal valorTotal, string validezOferta, string numeroFicha, string tipoCotizacion, string observaciones, int idProgramaFormacion, int idElaborador, int idRevisador, int idAutorizador)
        {
            if (String.IsNullOrEmpty(codigo))
            {
                throw new ApplicationException(Message.CodigoVacio);
            }
            if (String.IsNullOrEmpty(fecha.ToString()))
            {
                throw new ApplicationException(Message.FechaVacio);
            }
        }

        public Cotizacion ConsultarPorProgramaFormacion(int id)
        {
            try
            {
                return objDCotizacion.ConsultarPorProgramaFormacion(id);
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

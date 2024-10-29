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
    public class LAvanceProyecto
    {
        DAvanceProyecto objDAvanceProyecto;
        LActividad objLActividad = new LActividad();

        public LAvanceProyecto()
        {
            objDAvanceProyecto = new DAvanceProyecto();
        }

        public AvanceProyecto Guardar(string mes, decimal proyectado, string observaciones, int idActividad)
        {
            try
            {
                ValidarCampos(mes, idActividad);

                objDAvanceProyecto = new DAvanceProyecto();
                AvanceProyecto objAvanceProyecto = new AvanceProyecto();
                objAvanceProyecto.Mes = mes;
                objAvanceProyecto.Proyectado = proyectado;
                objAvanceProyecto.Ejecutado = 0;
                objAvanceProyecto.Observaciones = observaciones;
                objAvanceProyecto.EjecutadoPresupuesto = 0;
                objAvanceProyecto.Adicion = 0;
                objAvanceProyecto.Disminucion = 0;
                Actividad objActividad = objLActividad.Consultar(idActividad);
                objAvanceProyecto.Saldo = objActividad.ObjetivoEspecifico.Proyecto.AsignacionInicial;
                objAvanceProyecto.Actividad = new Actividad() { Id = idActividad };
                objAvanceProyecto.Id = objDAvanceProyecto.Guardar(objAvanceProyecto);
                return objAvanceProyecto;
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

        public AvanceProyecto Actualizar(int id, string mes, decimal ejecutado, string observaciones, int idActividad, decimal ejecutadoPresupuesto,
            decimal adicion, decimal disminucion, decimal saldo)
        {
            try
            {
                ValidarCampos(mes, idActividad);

                AvanceProyecto objAvanceProyecto = objDAvanceProyecto.Consultar(id);
                if (objAvanceProyecto.Equals(null))
                {
                    throw new ApplicationException(Message.AvanceProyectoNull);
                }

                objDAvanceProyecto = new DAvanceProyecto();
                objAvanceProyecto.Mes = mes;
                objAvanceProyecto.Ejecutado = ejecutado;
                objAvanceProyecto.Observaciones = observaciones;
                objAvanceProyecto.EjecutadoPresupuesto = ejecutadoPresupuesto;
                objAvanceProyecto.Adicion = adicion;
                objAvanceProyecto.Disminucion = disminucion;
                if (saldo == 0)
                {
                    Actividad objActividad = objLActividad.Consultar(idActividad);
                    objAvanceProyecto.Saldo = objActividad.ObjetivoEspecifico.Proyecto.AsignacionInicial;
                }
                else
                {
                    objAvanceProyecto.Saldo = saldo;
                }
                objAvanceProyecto.Actividad = new Actividad() { Id = idActividad };
                objDAvanceProyecto.Actualizar(objAvanceProyecto);
                return objAvanceProyecto;
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

        public List<AvanceProyecto> Consultar()
        {
            try
            {
                return objDAvanceProyecto.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<AvanceProyecto>> Consultar(int top, int posicion)
        {
            try
            {
                return objDAvanceProyecto.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AvanceProyecto Consultar(int id)
        {
            try
            {
                return objDAvanceProyecto.Consultar(id);
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

        public AvanceProyecto ConsultarMes(string mes)
        {
            try
            {
                return objDAvanceProyecto.ConsultarMes(mes);
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
                AvanceProyecto AvanceProyecto = objDAvanceProyecto.Consultar(id);
                if (AvanceProyecto != null)
                {
                    objDAvanceProyecto.Eliminar(AvanceProyecto);
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

        private void ValidarCampos(string mes, int IdActividad)
        {
            if (String.IsNullOrEmpty(mes))
            {
                throw new ApplicationException(Message.MesVacio);
            }

            if (String.IsNullOrEmpty(IdActividad.ToString()))
            {
                throw new ApplicationException(Message.ActividadVacio);
            }
        }

        public List<AvanceProyecto> ConsultarPorActividad(int idActividad)
        {
            try
            {
                return objDAvanceProyecto.ConsultarPorActividad(idActividad);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

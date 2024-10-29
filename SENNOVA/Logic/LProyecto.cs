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
    public class LProyecto
    {
        DProyecto objDProyecto;

        public LProyecto()
        {
            objDProyecto = new DProyecto();
        }

        public Proyecto Guardar(string tituloProyecto, string codigoSGPS, int anoEjecucion, DateTime fechaDiligenciamiento, string objetivoGeneral, decimal asignacionInicial, int idCentroFormacion, int idLineaProgramatica, int idRedConocimientoSectorial, int idAreaConocimiento, int idEmpleado)
        {
            try
            {
                ValidarCampos(tituloProyecto, codigoSGPS, anoEjecucion, fechaDiligenciamiento, objetivoGeneral, asignacionInicial, idCentroFormacion, idLineaProgramatica, idRedConocimientoSectorial, idAreaConocimiento, idEmpleado);

                objDProyecto = new DProyecto();
                Proyecto objProyecto = new Proyecto();
                objProyecto.TituloProyecto = tituloProyecto;
                objProyecto.CodigoSGPS = codigoSGPS;
                objProyecto.AnoEjecucion = short.Parse(anoEjecucion.ToString());
                objProyecto.FechaDiligenciamiento = fechaDiligenciamiento;
                objProyecto.ObjetivoGeneral = objetivoGeneral;
                objProyecto.AsignacionInicial = asignacionInicial;
                objProyecto.CentroFormacion = new CentroFormacion() { Id = idCentroFormacion };
                objProyecto.LineaProgramatica = new LineaProgramatica() { Id = idLineaProgramatica };
                objProyecto.RedConocimientoSectorial = new RedConocimientoSectorial() { Id = idRedConocimientoSectorial };
                objProyecto.AreaConocimiento = new AreaConocimiento() { Id = idAreaConocimiento };
                objProyecto.Empleado = new Empleado() { Id = idEmpleado };
                objProyecto.Id = objDProyecto.Guardar(objProyecto);
                return objProyecto;
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

        public Proyecto Actualizar(int id, string tituloProyecto, string codigoSGPS, int anoEjecucion, DateTime fechaDiligenciamiento, string objetivoGeneral, decimal asignacionInicial, int idCentroFormacion, int idLineaProgramatica, int idRedConocimientoSectorial, int idAreaConocimiento, int idEmpleado)
        {
            try
            {
                ValidarCampos(tituloProyecto, codigoSGPS, anoEjecucion, fechaDiligenciamiento, objetivoGeneral, asignacionInicial, idCentroFormacion, idLineaProgramatica, idRedConocimientoSectorial, idAreaConocimiento, idEmpleado);

                Proyecto objProyecto = objDProyecto.Consultar(id);
                if (objProyecto.Equals(null))
                {
                    throw new ApplicationException(Message.ProyectoNull);
                }

                objDProyecto = new DProyecto();
                objProyecto.TituloProyecto = tituloProyecto;
                objProyecto.CodigoSGPS = codigoSGPS;
                objProyecto.AnoEjecucion = short.Parse(anoEjecucion.ToString());
                objProyecto.FechaDiligenciamiento = fechaDiligenciamiento;
                objProyecto.ObjetivoGeneral = objetivoGeneral;
                objProyecto.AsignacionInicial = asignacionInicial;
                objProyecto.CentroFormacion = new CentroFormacion() { Id = idCentroFormacion };
                objProyecto.LineaProgramatica = new LineaProgramatica() { Id = idLineaProgramatica };
                objProyecto.RedConocimientoSectorial = new RedConocimientoSectorial() { Id = idRedConocimientoSectorial };
                objProyecto.AreaConocimiento = new AreaConocimiento() { Id = idAreaConocimiento };
                objProyecto.Empleado = new Empleado() { Id = idEmpleado };
                objDProyecto.Actualizar(objProyecto);
                return objProyecto;
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

        public List<Proyecto> Consultar()
        {
            try
            {
                return objDProyecto.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Proyecto> ConsultarEmpleado(int idEmpleado)
        {
            try
            {
                return objDProyecto.ConsultarEmpleado(idEmpleado);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Proyecto>> Consultar(int top, int posicion)
        {
            try
            {
                return objDProyecto.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Proyecto Consultar(int id)
        {
            try
            {
                return objDProyecto.Consultar(id);
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

        public List<Proyecto> Consultar(string tituloProyecto)
        {
            try
            {
                return objDProyecto.Consultar(tituloProyecto);
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
                Proyecto Proyecto = objDProyecto.Consultar(id);
                if (Proyecto != null)
                {
                    objDProyecto.Eliminar(Proyecto);
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

        private void ValidarCampos(string tituloProyecto, string codigoSGPS, int anoEjecucion, DateTime fechaDiligenciamiento, string objetivoGeneral, decimal asignacionInicial,
            int idCentroFormacion, int idLineaProgramatica, int idRedConocimientoSectorial, int idAreaConocimiento, int idPersona)
        {
            if (String.IsNullOrEmpty(tituloProyecto))
            {
                throw new ApplicationException(Message.TituloProyecto);
            }
            if (String.IsNullOrEmpty(codigoSGPS))
            {
                throw new ApplicationException(Message.CodigoVacio);
            }
            if (String.IsNullOrEmpty(anoEjecucion.ToString()))
            {
                throw new ApplicationException(Message.AnoEjecucion);
            }
            if (String.IsNullOrEmpty(fechaDiligenciamiento.ToString()))
            {
                throw new ApplicationException(Message.FechaDiligenciamiento);
            }
            if (String.IsNullOrEmpty(objetivoGeneral))
            {
                throw new ApplicationException(Message.ObjetivoGeneralVacio);
            }
            if (String.IsNullOrEmpty(asignacionInicial.ToString()))
            {
                throw new ApplicationException(Message.AsignacionInicialVacio);
            }
            if (String.IsNullOrEmpty(idCentroFormacion.ToString()))
            {
                throw new ApplicationException(Message.CentroFormacionVacio);
            }
            if (String.IsNullOrEmpty(idLineaProgramatica.ToString()))
            {
                throw new ApplicationException(Message.LineaProgramaticaVacio);
            }
            if (String.IsNullOrEmpty(idRedConocimientoSectorial.ToString()))
            {
                throw new ApplicationException(Message.RedConocimientoSectorialVacio);
            }
            if (String.IsNullOrEmpty(idAreaConocimiento.ToString()))
            {
                throw new ApplicationException(Message.AreaConocimientoVacio);
            }
            if (String.IsNullOrEmpty(idPersona.ToString()))
            {
                throw new ApplicationException(Message.PersonaVacio);
            }
        }

        public Proyecto ConsultarPorRedConocimientoSectorial(int id)
        {
            try
            {
                return objDProyecto.ConsultarPorRedConocimientoSectorial(id);
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

        public Proyecto ConsultarPorLineaProgramatica(int id)
        {
            try
            {
                return objDProyecto.ConsultarPorLineaProgramatica(id);
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

        public Proyecto ConsultarPorAreaConocimiento(int id)
        {
            try
            {
                return objDProyecto.ConsultarPorAreaConocimiento(id);
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

        public Proyecto ConsultarPorPersona(int id)
        {
            try
            {
                return objDProyecto.ConsultarPorEmpleado(id);
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

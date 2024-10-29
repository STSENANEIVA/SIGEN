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
    public class LIngreso
    {
        DIngreso objDIngreso;

        public LIngreso()
        {
            objDIngreso = new DIngreso();
        }

        public Ingreso Guardar(DateTime fecha, bool politicaDatos, string ficha, int idVisitante, int idEmpresa, int idProgramaFormacion, int idEmpleado)
        {
            try
            {
                ValidarCampos(fecha, idVisitante, idEmpresa, idProgramaFormacion, idEmpleado);

                objDIngreso = new DIngreso();
                Ingreso objIngreso = new Ingreso();
                objIngreso.Fecha = fecha;
                objIngreso.PoliticaDatos = politicaDatos;
                objIngreso.Ficha = ficha;
                objIngreso.Visitante = new Visitante() { Id = idVisitante };
                objIngreso.Empresa = new Empresa() { Id = idEmpresa };
                objIngreso.Empleado = new Empleado() { Id = idEmpleado };
                if (idProgramaFormacion != 0)
                {
                    objIngreso.ProgramaFormacion = new ProgramaFormacion() { Id = idProgramaFormacion }; 
                }
                objIngreso.Id = objDIngreso.Guardar(objIngreso);
                return objIngreso;
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

        public Ingreso Actualizar(int id, DateTime fecha, bool politicaDatos, string ficha, int idVisitante, int idEmpresa, int idProgramaFormacion, int idEmpleado)
        {
            try
            {
                ValidarCampos(fecha, idVisitante, idEmpresa, idProgramaFormacion, idEmpleado);

                Ingreso objIngreso = objDIngreso.Consultar(id);
                if (objIngreso.Equals(null))
                {
                    throw new ApplicationException(Message.IngresoNull);
                }

                objDIngreso = new DIngreso();
                objIngreso.Fecha = fecha;
                objIngreso.PoliticaDatos = politicaDatos;
                objIngreso.Ficha = ficha;
                objIngreso.Visitante = new Visitante() { Id = idVisitante };
                objIngreso.Empresa = new Empresa() { Id = idEmpresa };
                objIngreso.Empleado = new Empleado() { Id = idEmpleado };
                objIngreso.ProgramaFormacion = new ProgramaFormacion() { Id = idProgramaFormacion };
                objDIngreso.Actualizar(objIngreso);
                return objIngreso;
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

        public List<Ingreso> Consultar()
        {
            try
            {
                return objDIngreso.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Ingreso>> Consultar(int top, int posicion)
        {
            try
            {
                return objDIngreso.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Ingreso Consultar(int id)
        {
            try
            {
                return objDIngreso.Consultar(id);
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
                Ingreso Ingreso = objDIngreso.Consultar(id);
                if (Ingreso != null)
                {
                    objDIngreso.Eliminar(Ingreso);
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

        private void ValidarCampos(DateTime fecha, int idVisitante, int idEmpresa, int idProgramaFormacion, int idEmpleado)
        {
            if (String.IsNullOrEmpty(fecha.ToString()))
            {
                throw new ApplicationException(Message.FechaVacio);
            }
            if (String.IsNullOrEmpty(idVisitante.ToString()))
            {
                throw new ApplicationException(Message.VisitanteVacio);
            }
            if (String.IsNullOrEmpty(idEmpresa.ToString()))
            {
                throw new ApplicationException(Message.EmpleadoVacio);
            }
            if (String.IsNullOrEmpty(idProgramaFormacion.ToString()))
            {
                throw new ApplicationException(Message.ProgramaFormacionVacio);
            }
            if (String.IsNullOrEmpty(idEmpleado.ToString()))
            {
                throw new ApplicationException(Message.EmpleadoVacio);
            }
        }

        public Ingreso ConsultarPorVisitante(int id)
        {
            try
            {
                return objDIngreso.ConsultarPorVisitante(id);
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

        public Ingreso ConsultarPorProgramaFormacion(int idProgramaFormacion)
        {
            try
            {
                return objDIngreso.ConsultarPorProgramaFormacion(idProgramaFormacion);
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

        public Ingreso ConsultarPorEmpresa(int idEmpresa)
        {
            try
            {
                return objDIngreso.ConsultarPorEmpresa(idEmpresa);
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

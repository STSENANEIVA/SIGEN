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
    public class LEmpleado
    {
        DEmpleado objDEmpleado;

        public LEmpleado()
        {
            objDEmpleado = new DEmpleado();
        }

        public Empleado Guardar(string emailLaboral, string telefono, string ip, int idRolSennova, int idPersona, int idCargo)
        {
            try
            {
                ValidarCampos(emailLaboral, idRolSennova, idPersona);

                objDEmpleado = new DEmpleado();
                Empleado objEmpleado = new Empleado();
                objEmpleado.EmailLaboral = emailLaboral;
                objEmpleado.Telefono = telefono;
                objEmpleado.Ip = ip;
                objEmpleado.RolSennova = new RolSennova() { Id = idRolSennova };
                objEmpleado.Cargo = new Cargo() { Id = idCargo };
                objEmpleado.Persona = new Persona() { Id = idPersona };
                objEmpleado.Id = objDEmpleado.Guardar(objEmpleado);
                return objEmpleado;
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

        public Empleado Actualizar(int id, string emailLaboral, string telefono, string ip, int idRolSennova, int idPersona, int idCargo)
        {
            try
            {
                ValidarCampos(emailLaboral, idRolSennova, idPersona);

                Empleado objEmpleado = objDEmpleado.Consultar(id);
                if (objEmpleado.Equals(null))
                {
                    throw new ApplicationException(Message.EmpleadoNull);
                }

                objDEmpleado = new DEmpleado();
                objEmpleado.EmailLaboral = emailLaboral;
                objEmpleado.Telefono = telefono;
                objEmpleado.Ip = ip;
                objEmpleado.RolSennova = new RolSennova() { Id = idRolSennova };
                objEmpleado.Persona = new Persona() { Id = idPersona };
                objEmpleado.Cargo = new Cargo() { Id = idCargo };

                objDEmpleado.Actualizar(objEmpleado);
                return objEmpleado;
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

        public List<Empleado> Consultar()
        {
            try
            {
                return objDEmpleado.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Empleado>> Consultar(int top, int posicion)
        {
            try
            {
                return objDEmpleado.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Empleado ConsultarPorEmailLaboral(string emailLaboral)
        {
            return objDEmpleado.ConsultarPorEmailLaboral(emailLaboral);
        }

        public Empleado Consultar(int id)
        {
            try
            {
                return objDEmpleado.Consultar(id);
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

        public Empleado ConsultarEmail(string emailLaboral)
        {
            try
            {
                return objDEmpleado.Consultar(emailLaboral);
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
                Empleado Empleado = objDEmpleado.Consultar(id);
                if (Empleado != null)
                {
                    objDEmpleado.Eliminar(Empleado);
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

        private void ValidarCampos(string emailLaboral, int idRolSennova, int idPersona)
        {
          
            if (String.IsNullOrEmpty(emailLaboral))
            {
                throw new ApplicationException(Message.EmailVacio);
            }

            if (String.IsNullOrEmpty(idRolSennova.ToString()))
            {
                throw new ApplicationException(Message.RolSennovaVacio);
            }
            if (String.IsNullOrEmpty(idPersona.ToString()))
            {
                throw new ApplicationException(Message.PersonaVacio);
            }

        }

        public Empleado ConsultarPorRolSennova(int id)
        {
            try
            {
                return objDEmpleado.ConsultarPorRolSennova(id);
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

        public Empleado ConsultarPorIdPersona(int idPersona)
        {
            try
            {
                return objDEmpleado.ConsultarPorIdPersona(idPersona);
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

        public Empleado ConsultarPorCargo(int idCargo)
        {
            try
            {
                return objDEmpleado.ConsultarPorCargo(idCargo);
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

        public Empleado ConsultarPorPersona(int idPersona)
        {
            try
            {
                return objDEmpleado.ConsultarPorPersona(idPersona);
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

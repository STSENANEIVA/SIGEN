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
    public class LCliente
    {
        DCliente objDCliente;

        public LCliente()
        {
            objDCliente = new DCliente();
        }

        public Cliente Guardar(int idPersona)
        {
            try
            {

                objDCliente = new DCliente();

                Cliente objCliente = new Cliente();
                objCliente.Persona = new Persona() { Id = idPersona };
                objCliente.Id = objDCliente.Guardar(objCliente);
                return objCliente;
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

        public Cliente Actualizar(int id, int idPersona)
        {
            try
            {
                Cliente objCliente = objDCliente.Consultar(id);
                if (objDCliente.Equals(null))
                {
                    throw new ApplicationException(Message.ClienteNull);
                }

                objDCliente = new DCliente();
                objCliente.Persona = new Persona() { Id = idPersona };
                objDCliente.Actualizar(objCliente);
                return objCliente;
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

        public List<Cliente> Consultar()
        {
            try
            {
                return objDCliente.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Cliente Consultar(int id)
        {
            try
            {
                return objDCliente.Consultar(id);
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
                Cliente Cliente = objDCliente.Consultar(id);
                if (Cliente != null)
                {
                    objDCliente.Eliminar(Cliente);
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

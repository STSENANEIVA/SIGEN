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
    public class LSoftware
    {
        DSoftware objDSoftware;

        public LSoftware()
        {
            objDSoftware = new DSoftware();
        }

        public Software Guardar(string codigo, string nombre, string version, int idTipoLicencia)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDSoftware = new DSoftware();
                Software objSoftware = new Software();
                objSoftware.Codigo = codigo;
                objSoftware.Nombre = nombre;
                objSoftware.Version = version;
                objSoftware.Activo = true;
                objSoftware.TipoLicencia = new TipoLicencia() { Id = idTipoLicencia };
                objSoftware.Id = objDSoftware.Guardar(objSoftware);
                return objSoftware;
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

        public Software Actualizar(int id, string codigo, string nombre, string version, bool activo, int idTipoLicencia)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Software objSoftware = objDSoftware.Consultar(id);
                if (objSoftware.Equals(null))
                {
                    throw new ApplicationException(Message.SoftwareNull);
                }

                objDSoftware = new DSoftware();
                objSoftware.Codigo = codigo;
                objSoftware.Nombre = nombre;
                objSoftware.Version = version;
                objSoftware.Activo = activo;
                objSoftware.TipoLicencia = new TipoLicencia() { Id = idTipoLicencia };
                objDSoftware.Actualizar(objSoftware);
                return objSoftware;
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

        public List<Software> Consultar()
        {
            try
            {
                return objDSoftware.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Software>> Consultar(int top, int posicion)
        {
            try
            {
                return objDSoftware.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Software Consultar(int id)
        {
            try
            {
                return objDSoftware.Consultar(id);
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

        public Software ConsultarPorTipoLicencia(int idTipoLicencia)
        {
            try
            {
                return objDSoftware.ConsultarPorTipoLicencia(idTipoLicencia);
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

        public Software Consultar(string codigo)
        {
            try
            {
                return objDSoftware.Consultar(codigo);
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
                Software Software = objDSoftware.Consultar(id);
                if (Software != null)
                {
                    objDSoftware.Eliminar(Software);
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

        private void ValidarCampos(string codigo, string nombre)
        {
            if (String.IsNullOrEmpty(codigo))
            {
                throw new ApplicationException(Message.CodigoVacio);
            }
            if (String.IsNullOrEmpty(nombre))
            {
                throw new ApplicationException(Message.NombreVacio);
            }
        }

    
    }
}

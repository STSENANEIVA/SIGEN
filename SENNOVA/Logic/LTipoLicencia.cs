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
    public class LTipoLicencia
    {
        DTipoLicencia objDTipoLicencia;

        public LTipoLicencia()
        {
            objDTipoLicencia = new DTipoLicencia();
        }

        public TipoLicencia Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDTipoLicencia = new DTipoLicencia();
                TipoLicencia objTipoLicencia = new TipoLicencia();
                objTipoLicencia.Codigo = codigo;
                objTipoLicencia.Nombre = nombre;
                objTipoLicencia.Activo = true;
                objTipoLicencia.Id = objDTipoLicencia.Guardar(objTipoLicencia);
                return objTipoLicencia;
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

        public TipoLicencia Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                TipoLicencia objTipoLicencia = objDTipoLicencia.Consultar(id);
                if (objTipoLicencia.Equals(null))
                {
                    throw new ApplicationException(Message.TipoLicenciaNull);
                }

                objDTipoLicencia = new DTipoLicencia();
                objTipoLicencia.Codigo = codigo;
                objTipoLicencia.Nombre = nombre;
                objTipoLicencia.Activo = activo;
                objDTipoLicencia.Actualizar(objTipoLicencia);
                return objTipoLicencia;
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

        public List<TipoLicencia> Consultar()
        {
            try
            {
                return objDTipoLicencia.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<TipoLicencia>> Consultar(int top, int posicion)
        {
            try
            {
                return objDTipoLicencia.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoLicencia Consultar(int id)
        {
            try
            {
                return objDTipoLicencia.Consultar(id);
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

        public TipoLicencia Consultar(string codigo)
        {
            try
            {
                return objDTipoLicencia.Consultar(codigo);
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
                TipoLicencia TipoLicencia = objDTipoLicencia.Consultar(id);
                if (TipoLicencia != null)
                {
                    objDTipoLicencia.Eliminar(TipoLicencia);
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

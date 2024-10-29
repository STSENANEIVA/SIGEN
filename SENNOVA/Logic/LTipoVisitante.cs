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
    public class LTipoVisitante
    {
        DTipoVisitante objDTipoVisitante;

        public LTipoVisitante()
        {
            objDTipoVisitante = new DTipoVisitante();
        }

        public TipoVisitante Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDTipoVisitante = new DTipoVisitante();
                TipoVisitante objTipoVisitante = new TipoVisitante();
                objTipoVisitante.Codigo = codigo;
                objTipoVisitante.Nombre = nombre;
                objTipoVisitante.Activo = true;
                objTipoVisitante.Id = objDTipoVisitante.Guardar(objTipoVisitante);
                return objTipoVisitante;
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

        public TipoVisitante Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                TipoVisitante objTipoVisitante = objDTipoVisitante.Consultar(id);
                if (objTipoVisitante.Equals(null))
                {
                    throw new ApplicationException(Message.TipoVisitanteNull);
                }

                objDTipoVisitante = new DTipoVisitante();
                objTipoVisitante.Codigo = codigo;
                objTipoVisitante.Nombre = nombre;
                objTipoVisitante.Activo = activo;
                objDTipoVisitante.Actualizar(objTipoVisitante);
                return objTipoVisitante;
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

        public List<TipoVisitante> Consultar()
        {
            try
            {
                return objDTipoVisitante.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<TipoVisitante>> Consultar(int top, int posicion)
        {
            try
            {
                return objDTipoVisitante.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoVisitante Consultar(int id)
        {
            try
            {
                return objDTipoVisitante.Consultar(id);
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

        public TipoVisitante Consultar(string codigo)
        {
            try
            {
                return objDTipoVisitante.Consultar(codigo);
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
                TipoVisitante TipoVisitante = objDTipoVisitante.Consultar(id);
                if (TipoVisitante != null)
                {
                    objDTipoVisitante.Eliminar(TipoVisitante);
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

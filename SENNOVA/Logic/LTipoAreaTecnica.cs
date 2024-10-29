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
    public class LTipoAreaTecnica
    {
        DTipoAreaTecnica objDTipoAreaTecnica;

        public LTipoAreaTecnica()
        {
            objDTipoAreaTecnica = new DTipoAreaTecnica();
        }

        public TipoAreaTecnica Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDTipoAreaTecnica = new DTipoAreaTecnica();
                TipoAreaTecnica objTipoAreaTecnica = new TipoAreaTecnica();
                objTipoAreaTecnica.Codigo = codigo;
                objTipoAreaTecnica.Nombre = nombre;
                objTipoAreaTecnica.Activo = true;
                objTipoAreaTecnica.Id = objDTipoAreaTecnica.Guardar(objTipoAreaTecnica);
                return objTipoAreaTecnica;
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

        public TipoAreaTecnica Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                TipoAreaTecnica objTipoAreaTecnica = objDTipoAreaTecnica.Consultar(id);
                if (objTipoAreaTecnica.Equals(null))
                {
                    throw new ApplicationException(Message.TipoAreaTecnicaNull);
                }

                objDTipoAreaTecnica = new DTipoAreaTecnica();
                objTipoAreaTecnica.Codigo = codigo;
                objTipoAreaTecnica.Nombre = nombre;
                objTipoAreaTecnica.Activo = activo;
                objDTipoAreaTecnica.Actualizar(objTipoAreaTecnica);
                return objTipoAreaTecnica;
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

        public List<TipoAreaTecnica> Consultar()
        {
            try
            {
                return objDTipoAreaTecnica.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<TipoAreaTecnica>> Consultar(int top, int posicion)
        {
            try
            {
                return objDTipoAreaTecnica.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoAreaTecnica Consultar(int id)
        {
            try
            {
                return objDTipoAreaTecnica.Consultar(id);
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

        public TipoAreaTecnica Consultar(string codigo)
        {
            try
            {
                return objDTipoAreaTecnica.Consultar(codigo);
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
                TipoAreaTecnica TipoAreaTecnica = objDTipoAreaTecnica.Consultar(id);
                if (TipoAreaTecnica != null)
                {
                    objDTipoAreaTecnica.Eliminar(TipoAreaTecnica);
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

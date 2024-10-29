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
    public class LTipoEquipo
    {
        DTipoEquipo objDTipoEquipo;

        public LTipoEquipo()
        {
            objDTipoEquipo = new DTipoEquipo();
        }

        public TipoEquipo Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDTipoEquipo = new DTipoEquipo();
                TipoEquipo objTipoEquipo = new TipoEquipo();
                objTipoEquipo.Codigo = codigo;
                objTipoEquipo.Nombre = nombre;
                objTipoEquipo.Activo = true;
                objTipoEquipo.Id = objDTipoEquipo.Guardar(objTipoEquipo);
                return objTipoEquipo;
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

        public TipoEquipo Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                TipoEquipo objTipoEquipo = objDTipoEquipo.Consultar(id);
                if (objTipoEquipo.Equals(null))
                {
                    throw new ApplicationException(Message.TipoEquipoNull);
                }

                objDTipoEquipo = new DTipoEquipo();
                objTipoEquipo.Codigo = codigo;
                objTipoEquipo.Nombre = nombre;
                objTipoEquipo.Activo = activo;
                objDTipoEquipo.Actualizar(objTipoEquipo);
                return objTipoEquipo;
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

        public List<TipoEquipo> Consultar()
        {
            try
            {
                return objDTipoEquipo.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<TipoEquipo>> Consultar(int top, int posicion)
        {
            try
            {
                return objDTipoEquipo.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoEquipo Consultar(int id)
        {
            try
            {
                return objDTipoEquipo.Consultar(id);
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

        public TipoEquipo Consultar(string codigo)
        {
            try
            {
                return objDTipoEquipo.Consultar(codigo);
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
                TipoEquipo TipoEquipo = objDTipoEquipo.Consultar(id);
                if (TipoEquipo != null)
                {
                    objDTipoEquipo.Eliminar(TipoEquipo);
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

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
    public class LTerminoCondicion
    {
        DTerminoCondicion objDTerminoCondicion;

        public LTerminoCondicion()
        {
            objDTerminoCondicion = new DTerminoCondicion();
        }

        public TerminoCondicion Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDTerminoCondicion = new DTerminoCondicion();
                TerminoCondicion objTerminoCondicion = new TerminoCondicion();
                objTerminoCondicion.Codigo = codigo;
                objTerminoCondicion.Nombre = nombre;
                objTerminoCondicion.Activo = true;
                objTerminoCondicion.Id = objDTerminoCondicion.Guardar(objTerminoCondicion);
                return objTerminoCondicion;
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

        public TerminoCondicion Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                TerminoCondicion objTerminoCondicion = objDTerminoCondicion.Consultar(id);
                if (objTerminoCondicion.Equals(null))
                {
                    throw new ApplicationException(Message.TerminoCondicionNull);
                }

                objDTerminoCondicion = new DTerminoCondicion();
                objTerminoCondicion.Codigo = codigo;
                objTerminoCondicion.Nombre = nombre;
                objTerminoCondicion.Activo = activo;
                objDTerminoCondicion.Actualizar(objTerminoCondicion);
                return objTerminoCondicion;
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

        public List<TerminoCondicion> Consultar()
        {
            try
            {
                return objDTerminoCondicion.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<TerminoCondicion>> Consultar(int top, int posicion)
        {
            try
            {
                return objDTerminoCondicion.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TerminoCondicion Consultar(int id)
        {
            try
            {
                return objDTerminoCondicion.Consultar(id);
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

        public TerminoCondicion Consultar(string codigo)
        {
            try
            {
                return objDTerminoCondicion.Consultar(codigo);
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
                TerminoCondicion TerminoCondicion = objDTerminoCondicion.Consultar(id);
                if (TerminoCondicion != null)
                {
                    objDTerminoCondicion.Eliminar(TerminoCondicion);
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

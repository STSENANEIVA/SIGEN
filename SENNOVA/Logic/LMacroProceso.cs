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
    public class LMacroProceso
    {
        DMacroProceso objDMacroProceso;

        public LMacroProceso()
        {
            objDMacroProceso = new DMacroProceso();
        }

        public MacroProceso Guardar(string codigo, string nombre, string color, string icono)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDMacroProceso = new DMacroProceso();
                MacroProceso objMacroProceso = new MacroProceso();
                objMacroProceso.Codigo = codigo;
                objMacroProceso.Nombre = nombre;
                objMacroProceso.Color = color;
                objMacroProceso.Icono = icono;
                objMacroProceso.Activo = true;
                objMacroProceso.Id = objDMacroProceso.Guardar(objMacroProceso);
                return objMacroProceso;
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

        public MacroProceso Actualizar(int id, string codigo, string nombre, bool activo, string color, string icono)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                MacroProceso objMacroProceso = objDMacroProceso.Consultar(id);
                if (objMacroProceso.Equals(null))
                {
                    throw new ApplicationException(Message.MacroProcesoNull);
                }

                objDMacroProceso = new DMacroProceso();
                objMacroProceso.Codigo = codigo;
                objMacroProceso.Nombre = nombre;
                objMacroProceso.Color = color;
                objMacroProceso.Icono = icono;
                objMacroProceso.Activo = activo;
                objDMacroProceso.Actualizar(objMacroProceso);
                return objMacroProceso;
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

        public List<MacroProceso> Consultar()
        {
            try
            {
                return objDMacroProceso.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<MacroProceso>> Consultar(int top, int posicion)
        {
            try
            {
                return objDMacroProceso.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MacroProceso Consultar(int id)
        {
            try
            {
                return objDMacroProceso.Consultar(id);
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

        public MacroProceso Consultar(string codigo)
        {
            try
            {
                return objDMacroProceso.Consultar(codigo);
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
                MacroProceso MacroProceso = objDMacroProceso.Consultar(id);
                if (MacroProceso != null)
                {
                    objDMacroProceso.Eliminar(MacroProceso);
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

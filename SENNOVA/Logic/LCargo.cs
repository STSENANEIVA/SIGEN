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
    public class LCargo
    {
        DCargo objDCargo;

        public LCargo()
        {
            objDCargo = new DCargo();
        }

        public Cargo Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDCargo = new DCargo();
                Cargo objCargo = new Cargo();
                objCargo.Codigo = codigo;
                objCargo.Nombre = nombre;
                objCargo.Activo = true;
                objCargo.Id = objDCargo.Guardar(objCargo);
                return objCargo;
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

        public Cargo Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Cargo objCargo = objDCargo.Consultar(id);
                if (objCargo.Equals(null))
                {
                    throw new ApplicationException(Message.CargoNull);
                }

                objDCargo = new DCargo();
                objCargo.Codigo = codigo;
                objCargo.Nombre = nombre;
                objCargo.Activo = activo;
                objDCargo.Actualizar(objCargo);
                return objCargo;
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

        public List<Cargo> Consultar()
        {
            try
            {
                return objDCargo.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Cargo>> Consultar(int top, int posicion)
        {
            try
            {
                return objDCargo.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cargo Consultar(int id)
        {
            try
            {
                return objDCargo.Consultar(id);
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

        public Cargo Consultar(string codigo)
        {
            try
            {
                return objDCargo.Consultar(codigo);
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
                Cargo Cargo = objDCargo.Consultar(id);
                if (Cargo != null)
                {
                    objDCargo.Eliminar(Cargo);
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

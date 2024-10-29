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
    public class LAccesorios
    {
        DAccesorios objDAccesorios;

        public LAccesorios()
        {
            objDAccesorios = new DAccesorios();
        }

        public Accesorios Guardar(string codigo, string nombre, string descripcion)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDAccesorios = new DAccesorios();
                Accesorios objAccesorios = new Accesorios();
                objAccesorios.Codigo = codigo;
                objAccesorios.Nombre = nombre;
                objAccesorios.Descripcion = descripcion;

                objAccesorios.Activo = true;
                objAccesorios.Id = objDAccesorios.Guardar(objAccesorios);
                return objAccesorios;
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

        public Accesorios Actualizar(int id, string codigo, string nombre, string descripcion, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Accesorios objAccesorios = objDAccesorios.Consultar(id);
                if (objAccesorios.Equals(null))
                {
                    throw new ApplicationException(Message.AccesoriosNull);
                }

                objDAccesorios = new DAccesorios();
                objAccesorios.Codigo = codigo;
                objAccesorios.Nombre = nombre;
                objAccesorios.Descripcion = descripcion;
                objAccesorios.Activo = activo;
                objDAccesorios.Actualizar(objAccesorios);
                return objAccesorios;
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

        public List<Accesorios> Consultar()
        {
            try
            {
                return objDAccesorios.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Accesorios>> Consultar(int top, int posicion)
        {
            try
            {
                return objDAccesorios.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Accesorios Consultar(int id)
        {
            try
            {
                return objDAccesorios.Consultar(id);
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

        public Accesorios Consultar(string codigo)
        {
            try
            {
                return objDAccesorios.Consultar(codigo);
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
                Accesorios Accesorios = objDAccesorios.Consultar(id);
                if (Accesorios != null)
                {
                    objDAccesorios.Eliminar(Accesorios);
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

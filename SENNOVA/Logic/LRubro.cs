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
    public class LRubro
    {
        DRubro objDRubro;

        public LRubro()
        {
            objDRubro = new DRubro();
        }

        public Rubro Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDRubro = new DRubro();
                Rubro objRubro = new Rubro();
                objRubro.Codigo = codigo;
                objRubro.Nombre = nombre;
                objRubro.Activo = true;
                objRubro.Id = objDRubro.Guardar(objRubro);
                return objRubro;
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

        public Rubro Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Rubro objRubro = objDRubro.Consultar(id);
                if (objRubro.Equals(null))
                {
                    throw new ApplicationException(Message.RubroNull);
                }

                objDRubro = new DRubro();
                objRubro.Codigo = codigo;
                objRubro.Nombre = nombre;
                objRubro.Activo = activo;
                objDRubro.Actualizar(objRubro);
                return objRubro;
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

        public List<Rubro> Consultar()
        {
            try
            {
                return objDRubro.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Rubro>> Consultar(int top, int posicion)
        {
            try
            {
                return objDRubro.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Rubro Consultar(int id)
        {
            try
            {
                return objDRubro.Consultar(id);
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

        public Rubro Consultar(string codigo)
        {
            try
            {
                return objDRubro.Consultar(codigo);
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
                Rubro Rubro = objDRubro.Consultar(id);
                if (Rubro != null)
                {
                    objDRubro.Eliminar(Rubro);
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

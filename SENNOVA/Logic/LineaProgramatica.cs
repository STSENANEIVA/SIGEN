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
    public class LLineaProgramatica
    {
        DLineaProgramatica objDLineaProgramatica;

        public LLineaProgramatica()
        {
            objDLineaProgramatica = new DLineaProgramatica();
        }

        public LineaProgramatica Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDLineaProgramatica = new DLineaProgramatica();
                LineaProgramatica objLineaProgramatica = new LineaProgramatica();
                objLineaProgramatica.Codigo = codigo;
                objLineaProgramatica.Nombre = nombre;
                objLineaProgramatica.Activo = true;
                objLineaProgramatica.Id = objDLineaProgramatica.Guardar(objLineaProgramatica);
                return objLineaProgramatica;
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

        public LineaProgramatica Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                LineaProgramatica objLineaProgramatica = objDLineaProgramatica.Consultar(id);
                if (objLineaProgramatica.Equals(null))
                {
                    throw new ApplicationException(Message.LineaProgramaticaNull);
                }

                objDLineaProgramatica = new DLineaProgramatica();
                objLineaProgramatica.Codigo = codigo;
                objLineaProgramatica.Nombre = nombre;
                objLineaProgramatica.Activo = activo;
                objDLineaProgramatica.Actualizar(objLineaProgramatica);
                return objLineaProgramatica;
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

        public List<LineaProgramatica> Consultar()
        {
            try
            {
                return objDLineaProgramatica.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<LineaProgramatica>> Consultar(int top, int posicion)
        {
            try
            {
                return objDLineaProgramatica.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public LineaProgramatica Consultar(int id)
        {
            try
            {
                return objDLineaProgramatica.Consultar(id);
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

        public LineaProgramatica Consultar(string codigo)
        {
            try
            {
                return objDLineaProgramatica.Consultar(codigo);
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
                LineaProgramatica LineaProgramatica = objDLineaProgramatica.Consultar(id);
                if (LineaProgramatica != null)
                {
                    objDLineaProgramatica.Eliminar(LineaProgramatica);
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

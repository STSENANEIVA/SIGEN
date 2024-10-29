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
    public class LImpresora
    {
        DImpresora objDImpresora;

        public LImpresora()
        {
            objDImpresora = new DImpresora();
        }

        public Impresora Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDImpresora = new DImpresora();
                Impresora objImpresora = new Impresora();
                objImpresora.Codigo = codigo;
                objImpresora.Nombre = nombre;
                objImpresora.Activo = true;
                objImpresora.Id = objDImpresora.Guardar(objImpresora);
                return objImpresora;
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

        public Impresora Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Impresora objImpresora = objDImpresora.Consultar(id);
                if (objImpresora.Equals(null))
                {
                    throw new ApplicationException(Message.ImpresoraNull);
                }

                objDImpresora = new DImpresora();
                objImpresora.Codigo = codigo;
                objImpresora.Nombre = nombre;
                objImpresora.Activo = activo;
                objDImpresora.Actualizar(objImpresora);
                return objImpresora;
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

        public List<Impresora> Consultar()
        {
            try
            {
                return objDImpresora.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Impresora>> Consultar(int top, int posicion)
        {
            try
            {
                return objDImpresora.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Impresora Consultar(int id)
        {
            try
            {
                return objDImpresora.Consultar(id);
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

        public Impresora Consultar(string codigo)
        {
            try
            {
                return objDImpresora.Consultar(codigo);
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
                Impresora Impresora = objDImpresora.Consultar(id);
                if (Impresora != null)
                {
                    objDImpresora.Eliminar(Impresora);
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

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
    public class LFamilia
    {
        DFamilia objDFamilia;
        public LFamilia()
        {
            objDFamilia = new DFamilia();
        }
        public Familia Guardar( string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDFamilia = new DFamilia();
                Familia objFamilia = new Familia();
                objFamilia.Codigo = codigo;
                objFamilia.Nombre = nombre;
                objFamilia.Activo = activo;
                objFamilia.Id = objDFamilia.Guardar(objFamilia);
                return objFamilia;
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
        public Familia Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Familia objFamilia = objDFamilia.Consultar(id);
                if (objFamilia.Equals(null))
                {
                    throw new ApplicationException(Message.FamiliaNull);
                }
                objDFamilia = new DFamilia();
                objFamilia.Codigo = codigo;
                objFamilia.Nombre = nombre;
                objFamilia.Activo = activo;
                objDFamilia.Actualizar(objFamilia);
                return objFamilia;
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
        public List<Familia> Consultar()
        {
            try
            {
                return objDFamilia.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public Familia Consultar(int id)
        {
            try
            {
                return objDFamilia.Consultar(id);
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
        public Familia Consultar(string codigo)
        {
            try
            {
                return objDFamilia.Consultar(codigo);
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
                Familia Familia = objDFamilia.Consultar(id);
                if (Familia != null)
                {
                    objDFamilia.Eliminar(Familia);
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
        private void ValidarCampos(string codigo, string nomnbre)
        {
            if (String.IsNullOrEmpty(codigo))
            {
                throw new ApplicationException(Message.CodigoVacio);
            }
            if (String.IsNullOrEmpty(nomnbre))
            {
                throw new ApplicationException(Message.NombreVacio);
            }
        }

    }
}

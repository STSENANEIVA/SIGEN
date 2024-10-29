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
    public class LCentroFormacion
    {
        DCentroFormacion objDCentroFormacion;

        public LCentroFormacion()
        {
            objDCentroFormacion = new DCentroFormacion();
        }

        public CentroFormacion Guardar(string codigo, string nombre, int idRegional)
        {
            try
            {
                ValidarCampos(codigo, nombre, idRegional);

                objDCentroFormacion = new DCentroFormacion();
                CentroFormacion objCentroFormacion = new CentroFormacion();
                objCentroFormacion.Codigo = codigo;
                objCentroFormacion.Nombre = nombre;
                objCentroFormacion.Activo = true;
                objCentroFormacion.Regional = new Regional { Id = idRegional };
                objCentroFormacion.Id = objDCentroFormacion.Guardar(objCentroFormacion);
                return objCentroFormacion;
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

        public CentroFormacion Actualizar(int id, string codigo, string nombre, bool activo, int idRegional)
        {
            try
            {
                ValidarCampos(codigo, nombre, idRegional);

                CentroFormacion objCentroFormacion = objDCentroFormacion.Consultar(id);
                if (objCentroFormacion.Equals(null))
                {
                    throw new ApplicationException(Message.CentroFormacionNull);
                }

                objDCentroFormacion = new DCentroFormacion();
                objCentroFormacion.Codigo = codigo;
                objCentroFormacion.Nombre = nombre;
                objCentroFormacion.Activo = activo;
                objCentroFormacion.Regional = new Regional { Id = idRegional};
                objDCentroFormacion.Actualizar(objCentroFormacion);
                return objCentroFormacion;
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

        public List<CentroFormacion> Consultar()
        {
            try
            {
                return objDCentroFormacion.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<CentroFormacion>> Consultar(int top, int posicion)
        {
            try
            {
                return objDCentroFormacion.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CentroFormacion Consultar(int id)
        {
            try
            {
                return objDCentroFormacion.Consultar(id);
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

        public CentroFormacion Consultar(string codigo)
        {
            try
            {
                return objDCentroFormacion.Consultar(codigo);
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
                CentroFormacion CentroFormacion = objDCentroFormacion.Consultar(id);
                if (CentroFormacion != null)
                {
                    objDCentroFormacion.Eliminar(CentroFormacion);
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

        private void ValidarCampos(string codigo, string nombre, int idRegional)
        {
            if (String.IsNullOrEmpty(codigo))
            {
                throw new ApplicationException(Message.CodigoVacio);
            }
            if (String.IsNullOrEmpty(nombre))
            {
                throw new ApplicationException(Message.NombreVacio);
            }
            if (String.IsNullOrEmpty(idRegional.ToString()))
            {
                throw new ApplicationException(Message.RegionalVacio);
            }
        }

        public CentroFormacion ConsultarPorRegional(int id)
        {
            try
            {
                return objDCentroFormacion.ConsultarPorRegional(id);
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
        
    }
}

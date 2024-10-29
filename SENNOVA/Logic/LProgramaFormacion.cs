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
    public class LProgramaFormacion
    {
        DProgramaFormacion objDProgramaFormacion;

        public LProgramaFormacion()
        {
            objDProgramaFormacion = new DProgramaFormacion();
        }

        public ProgramaFormacion Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDProgramaFormacion = new DProgramaFormacion();
                ProgramaFormacion objProgramaFormacion = new ProgramaFormacion();
                objProgramaFormacion.Codigo = codigo;
                objProgramaFormacion.Nombre = nombre;
                objProgramaFormacion.Activo = true;
                objProgramaFormacion.Id = objDProgramaFormacion.Guardar(objProgramaFormacion);
                return objProgramaFormacion;
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

        public ProgramaFormacion Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                ProgramaFormacion objProgramaFormacion = objDProgramaFormacion.Consultar(id);
                if (objProgramaFormacion.Equals(null))
                {
                    throw new ApplicationException(Message.ProgramaFormacionNull);
                }

                objDProgramaFormacion = new DProgramaFormacion();
                objProgramaFormacion.Codigo = codigo;
                objProgramaFormacion.Nombre = nombre;
                objProgramaFormacion.Activo = activo;
                objDProgramaFormacion.Actualizar(objProgramaFormacion);
                return objProgramaFormacion;
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

        public List<ProgramaFormacion> Consultar()
        {
            try
            {
                return objDProgramaFormacion.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<ProgramaFormacion>> Consultar(int top, int posicion)
        {
            try
            {
                return objDProgramaFormacion.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProgramaFormacion Consultar(int id)
        {
            try
            {
                return objDProgramaFormacion.Consultar(id);
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

        public ProgramaFormacion Consultar(string codigo)
        {
            try
            {
                return objDProgramaFormacion.Consultar(codigo);
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
                ProgramaFormacion ProgramaFormacion = objDProgramaFormacion.Consultar(id);
                if (ProgramaFormacion != null)
                {
                    objDProgramaFormacion.Eliminar(ProgramaFormacion);
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

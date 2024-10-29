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
    public class LActividad
    {
        DActividad objDActividad;

        public LActividad()
        {
            objDActividad = new DActividad();
        }

        public Actividad Guardar(string codigo, string nombre, int idObjetivoEspecifico)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDActividad = new DActividad();
                Actividad objActividad = new Actividad();
                objActividad.Codigo = codigo;
                objActividad.Nombre = nombre;
                objActividad.Activo = true;
                objActividad.ObjetivoEspecifico = new ObjetivoEspecifico() { Id = idObjetivoEspecifico };
                objActividad.Id = objDActividad.Guardar(objActividad);
                return objActividad;
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

        public Actividad Actualizar(int id, string codigo, string nombre, bool activo, int idObjetivoEspecifico)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Actividad objActividad = objDActividad.Consultar(id);
                if (objActividad.Equals(null))
                {
                    throw new ApplicationException(Message.ActividadNull);
                }

                objDActividad = new DActividad();
                objActividad.Codigo = codigo;
                objActividad.Nombre = nombre;
                objActividad.Activo = activo;
                objActividad.ObjetivoEspecifico = new ObjetivoEspecifico() { Id = idObjetivoEspecifico };
                objDActividad.Actualizar(objActividad);
                return objActividad;
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

        public List<Actividad> Consultar()
        {
            try
            {
                return objDActividad.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Actividad> ConsultarPorObjetivo(int idObjetivo)
        {
            try
            {
                return objDActividad.ConsultarPorObjetivo(idObjetivo);
            }
            catch (Exception)
            {
                throw;
            }

        }


        public Resultado<List<Actividad>> Consultar(int top, int posicion)
        {
            try
            {
                return objDActividad.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Actividad Consultar(int id)
        {
            try
            {
                return objDActividad.Consultar(id);
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

        public Actividad Consultar(string codigo)
        {
            try
            {
                return objDActividad.Consultar(codigo);
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
                Actividad Actividad = objDActividad.Consultar(id);
                if (Actividad != null)
                {
                    objDActividad.Eliminar(Actividad);
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

        public Actividad ConsultarPorObjetivoEspecifico(int id)
        {
            try
            {
                return objDActividad.ConsultarPorObjetivoEspecifico(id);
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

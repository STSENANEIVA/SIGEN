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
    public class LObjetivoEspecifico
    {
        DObjetivoEspecifico objDObjetivoEspecifico;

        public LObjetivoEspecifico()
        {
            objDObjetivoEspecifico = new DObjetivoEspecifico();
        }

        public ObjetivoEspecifico Guardar(string codigo, string nombre, int idProyecto)
        {
            try
            {
                ValidarCampos(codigo, nombre, idProyecto);

                objDObjetivoEspecifico = new DObjetivoEspecifico();
                ObjetivoEspecifico objObjetivoEspecifico = new ObjetivoEspecifico();
                objObjetivoEspecifico.Codigo = codigo;
                objObjetivoEspecifico.Nombre = nombre;
                objObjetivoEspecifico.Activo = true;
                objObjetivoEspecifico.Proyecto = new Proyecto() { Id = idProyecto};
                objObjetivoEspecifico.Id = objDObjetivoEspecifico.Guardar(objObjetivoEspecifico);
                return objObjetivoEspecifico;
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

        public ObjetivoEspecifico Actualizar(int id, string codigo, string nombre, bool activo, int idProyecto)
        {
            try
            {
                ValidarCampos(codigo, nombre, idProyecto);

                ObjetivoEspecifico objObjetivoEspecifico = objDObjetivoEspecifico.Consultar(id);
                if (objObjetivoEspecifico.Equals(null))
                {
                    throw new ApplicationException(Message.ObjetivoEspecificoNull);
                }

                objDObjetivoEspecifico = new DObjetivoEspecifico();
                objObjetivoEspecifico.Codigo = codigo;
                objObjetivoEspecifico.Nombre = nombre;
                objObjetivoEspecifico.Activo = activo;
                objObjetivoEspecifico.Proyecto = new Proyecto() { Id = idProyecto };
                objDObjetivoEspecifico.Actualizar(objObjetivoEspecifico);
                return objObjetivoEspecifico;
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

        public List<ObjetivoEspecifico> Consultar()
        {
            try
            {
                return objDObjetivoEspecifico.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<ObjetivoEspecifico> ConsultarPorProyectos(int idProyecto)
        {
            try
            {
                return objDObjetivoEspecifico.ConsultarPorProyectos(idProyecto);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<ObjetivoEspecifico>> Consultar(int top, int posicion)
        {
            try
            {
                return objDObjetivoEspecifico.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ObjetivoEspecifico Consultar(int id)
        {
            try
            {
                return objDObjetivoEspecifico.Consultar(id);
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

        public ObjetivoEspecifico Consultar(string codigo)
        {
            try
            {
                return objDObjetivoEspecifico.Consultar(codigo);
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
                ObjetivoEspecifico ObjetivoEspecifico = objDObjetivoEspecifico.Consultar(id);
                if (ObjetivoEspecifico != null)
                {
                    objDObjetivoEspecifico.Eliminar(ObjetivoEspecifico);
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

        private void ValidarCampos(string codigo, string nombre, int idProyecto)
        {
            if (String.IsNullOrEmpty(codigo))
            {
                throw new ApplicationException(Message.CodigoVacio);
            }
            if (String.IsNullOrEmpty(nombre))
            {
                throw new ApplicationException(Message.NombreVacio);
            }
            if (String.IsNullOrEmpty(idProyecto.ToString()))
            {
                throw new ApplicationException(Message.ProyectoVacio);
            }
            
        }

        public ObjetivoEspecifico ConsultarPorProyecto(int id)
        {
            try
            {
                return objDObjetivoEspecifico.ConsultarPorProyecto(id);
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

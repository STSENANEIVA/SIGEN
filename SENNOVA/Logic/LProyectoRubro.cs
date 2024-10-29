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
    public class LProyectoRubro
    {
        DProyectoRubro objDProyectoRubro;

        public LProyectoRubro()
        {
            objDProyectoRubro = new DProyectoRubro();
        }

        public ProyectoRubro Guardar(string objeto, decimal valor, int idRubro, int idProyecto)
        {
            try
            {
                ValidarCampos(objeto, valor);

                objDProyectoRubro = new DProyectoRubro();
                ProyectoRubro objProyectoRubro = new ProyectoRubro();
                objProyectoRubro.Objeto = objeto;
                objProyectoRubro.Valor = valor;
                objProyectoRubro.Rubro = new Rubro() { Id = idRubro };
                objProyectoRubro.Proyecto = new Proyecto() { Id = idProyecto };
                objProyectoRubro.Id = objDProyectoRubro.Guardar(objProyectoRubro);
                return objProyectoRubro;
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

        public ProyectoRubro Actualizar(int id, string objeto, decimal valor, int idRubro, int idProyecto)
        {
            try
            {
                ValidarCampos(objeto, valor);

                ProyectoRubro objProyectoRubro = objDProyectoRubro.Consultar(id);
                if (objProyectoRubro.Equals(null))
                {
                    throw new ApplicationException(Message.ProyectoRubroNull);
                }

                objDProyectoRubro = new DProyectoRubro();
                objProyectoRubro.Objeto = objeto;
                objProyectoRubro.Valor = valor;
                objProyectoRubro.Rubro = new Rubro() { Id = idRubro };
                objProyectoRubro.Proyecto = new Proyecto() { Id = idProyecto };
                objDProyectoRubro.Actualizar(objProyectoRubro);
                return objProyectoRubro;
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

        public List<ProyectoRubro> Consultar()
        {
            try
            {
                return objDProyectoRubro.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<ProyectoRubro>> Consultar(int top, int posicion)
        {
            try
            {
                return objDProyectoRubro.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProyectoRubro Consultar(int id)
        {
            try
            {
                return objDProyectoRubro.Consultar(id);
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

        public ProyectoRubro Consultar(string codigo)
        {
            try
            {
                return objDProyectoRubro.Consultar(codigo);
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
                ProyectoRubro ProyectoRubro = objDProyectoRubro.Consultar(id);
                if (ProyectoRubro != null)
                {
                    objDProyectoRubro.Eliminar(ProyectoRubro);
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

        private void ValidarCampos(string objeto, decimal valor)
        {
            if (String.IsNullOrEmpty(objeto))
            {
                throw new ApplicationException(Message.ObjetoVacio);
            }
            if (String.IsNullOrEmpty(valor.ToString()))
            {
                throw new ApplicationException(Message.ValorVacio);
            }
        }

        public ProyectoRubro ConsultarPorRubro(int id)
        {
            try
            {
                return objDProyectoRubro.ConsultarPorRubro(id);
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

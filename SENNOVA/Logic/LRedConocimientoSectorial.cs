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
    public class LRedConocimientoSectorial
    {
        DRedConocimientoSectorial objDRedConocimientoSectorial;

        public LRedConocimientoSectorial()
        {
            objDRedConocimientoSectorial = new DRedConocimientoSectorial();
        }

        public RedConocimientoSectorial Guardar(string codigo, string nombre)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDRedConocimientoSectorial = new DRedConocimientoSectorial();
                RedConocimientoSectorial objRedConocimientoSectorial = new RedConocimientoSectorial();
                objRedConocimientoSectorial.Codigo = codigo;
                objRedConocimientoSectorial.Nombre = nombre;
                objRedConocimientoSectorial.Activo = true;
                objRedConocimientoSectorial.Id = objDRedConocimientoSectorial.Guardar(objRedConocimientoSectorial);
                return objRedConocimientoSectorial;
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

        public RedConocimientoSectorial Actualizar(int id, string codigo, string nombre, bool activo)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                RedConocimientoSectorial objRedConocimientoSectorial = objDRedConocimientoSectorial.Consultar(id);
                if (objRedConocimientoSectorial.Equals(null))
                {
                    throw new ApplicationException(Message.RedConocimientoSectorialNull);
                }

                objDRedConocimientoSectorial = new DRedConocimientoSectorial();
                objRedConocimientoSectorial.Codigo = codigo;
                objRedConocimientoSectorial.Nombre = nombre;
                objRedConocimientoSectorial.Activo = activo;
                objDRedConocimientoSectorial.Actualizar(objRedConocimientoSectorial);
                return objRedConocimientoSectorial;
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

        public List<RedConocimientoSectorial> Consultar()
        {
            try
            {
                return objDRedConocimientoSectorial.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<RedConocimientoSectorial>> Consultar(int top, int posicion)
        {
            try
            {
                return objDRedConocimientoSectorial.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RedConocimientoSectorial Consultar(int id)
        {
            try
            {
                return objDRedConocimientoSectorial.Consultar(id);
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

        public RedConocimientoSectorial Consultar(string codigo)
        {
            try
            {
                return objDRedConocimientoSectorial.Consultar(codigo);
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
                RedConocimientoSectorial RedConocimientoSectorial = objDRedConocimientoSectorial.Consultar(id);
                if (RedConocimientoSectorial != null)
                {
                    objDRedConocimientoSectorial.Eliminar(RedConocimientoSectorial);
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

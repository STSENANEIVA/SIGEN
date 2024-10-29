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
    public class LAreaTecnica
    {
        DAreaTecnica objDAreaTecnica;

        public LAreaTecnica()
        {
            objDAreaTecnica = new DAreaTecnica();
        }

        public AreaTecnica Guardar(string codigo, string nombre, int idTipoAreaTecnica, int idEmpleado)
        {
            try
            {
                ValidarCampos(codigo, nombre, idTipoAreaTecnica, idEmpleado);

                objDAreaTecnica = new DAreaTecnica();
                AreaTecnica objAreaTecnica = new AreaTecnica();
                objAreaTecnica.Codigo = codigo;
                objAreaTecnica.Nombre = nombre;
                objAreaTecnica.Activo = true;
                objAreaTecnica.TipoAreaTecnica = new TipoAreaTecnica() { Id = idTipoAreaTecnica };
                objAreaTecnica.Empleado = new Empleado() { Id = idEmpleado };
                objAreaTecnica.Id = objDAreaTecnica.Guardar(objAreaTecnica);
                return objAreaTecnica;
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

        public AreaTecnica Actualizar(int id, string codigo, string nombre, bool activo, int idTipoAreaTecnica, int idEmpleado)
        {
            try
            {
                ValidarCampos(codigo, nombre, idTipoAreaTecnica, idEmpleado);

                AreaTecnica objAreaTecnica = objDAreaTecnica.Consultar(id);
                if (objAreaTecnica.Equals(null))
                {
                    throw new ApplicationException(Message.AreaTecnicaNull);
                }

                objDAreaTecnica = new DAreaTecnica();
                objAreaTecnica.Codigo = codigo;
                objAreaTecnica.Nombre = nombre;
                objAreaTecnica.Activo = activo;
                objAreaTecnica.TipoAreaTecnica = new TipoAreaTecnica() { Id = idTipoAreaTecnica };
                objAreaTecnica.Empleado = new Empleado() { Id = idEmpleado };

                objDAreaTecnica.Actualizar(objAreaTecnica);
                return objAreaTecnica;
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

        public List<AreaTecnica> Consultar()
        {
            try
            {
                return objDAreaTecnica.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<AreaTecnica> ConsultarTipoAreaTecnica(int idTipoAreaTecnica)
        {
            try
            {
                return objDAreaTecnica.ConsultarTipoAreaTecnica(idTipoAreaTecnica);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<AreaTecnica>> Consultar(int top, int posicion)
        {
            try
            {
                return objDAreaTecnica.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AreaTecnica Consultar(int id)
        {
            try
            {
                return objDAreaTecnica.Consultar(id);
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

        public AreaTecnica Consultar(string codigo)
        {
            try
            {
                return objDAreaTecnica.Consultar(codigo);
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

        public AreaTecnica ConsultarNombre(string nombre)
        {
            try
            {
                return objDAreaTecnica.ConsultarNombre(nombre);
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
                AreaTecnica AreaTecnica = objDAreaTecnica.Consultar(id);
                if (AreaTecnica != null)
                {
                    objDAreaTecnica.Eliminar(AreaTecnica);
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

        private void ValidarCampos(string codigo, string nombre, int idTipoAreaTecnica, int idEmpleado)
        {
            if (String.IsNullOrEmpty(codigo))
            {
                throw new ApplicationException(Message.CodigoVacio);
            }
            if (String.IsNullOrEmpty(nombre))
            {
                throw new ApplicationException(Message.NombreVacio);
            }
            if (String.IsNullOrEmpty(idTipoAreaTecnica.ToString()))
            {
                throw new ApplicationException(Message.TipoAreaTecnicaVacio);
            }
            if(String.IsNullOrEmpty(idEmpleado.ToString()))
            {
                throw new ApplicationException(Message.EmpleadoVacio);
            }
        }

        
    }
}

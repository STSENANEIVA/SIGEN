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
    public class LServicio
    {
        DServicio objDServicio;

        public LServicio()
        {
            objDServicio = new DServicio();
        }

        public Servicio Guardar(string codigo, string nombre, string requisitos, string alcance, decimal valor, int idAreaTecnica, int idFamilia)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                objDServicio = new DServicio();
                Servicio objServicio = new Servicio();
                objServicio.Codigo = codigo;
                objServicio.Nombre = nombre;
                objServicio.Requisitos = requisitos;
                objServicio.Alcance = alcance;
                objServicio.Valor = valor;
                objServicio.Activo = true;
                objServicio.AreaTecnica = new AreaTecnica() { Id = idAreaTecnica };
                objServicio.Familia = new Familia() { Id = idFamilia };
                objServicio.Id = objDServicio.Guardar(objServicio);
                return objServicio;
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

        public Servicio Actualizar(int id, string codigo, string nombre, bool activo, string requisitos, string alcance, decimal valor, int idAreaTecnica, int idFamilia)
        {
            try
            {
                ValidarCampos(codigo, nombre);

                Servicio objServicio = objDServicio.Consultar(id);
                if (objServicio.Equals(null))
                {
                    throw new ApplicationException(Message.ServicioNull);
                }

                objDServicio = new DServicio();
                objServicio.Codigo = codigo;
                objServicio.Nombre = nombre;
                objServicio.Requisitos = requisitos;
                objServicio.Alcance = alcance;
                objServicio.Valor = valor;
                objServicio.Activo = true;
                objServicio.AreaTecnica = new AreaTecnica() { Id = idAreaTecnica };
                objServicio.Familia = new Familia() { Id = idFamilia };
                objDServicio.Actualizar(objServicio);
                return objServicio;
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

        public List<Servicio> Consultar()
        {
            try
            {
                return objDServicio.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Servicio ConsultarAreaTecnica(int idAreaTecnica)
        {
            try
            {
                return objDServicio.ConsultarAreaTecnica(idAreaTecnica);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Servicio> ConsultarAreaTecnicaId(int idAreaTecnica)
        {
            try
            {
                return objDServicio.ConsultarAreaTecnicaId(idAreaTecnica);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Servicio ConsultarFamilia(int idFamilia)
        {
            try
            {
                return objDServicio.ConsultarFamilia(idFamilia);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Servicio>> Consultar(int top, int posicion)
        {
            try
            {
                return objDServicio.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Servicio Consultar(int id)
        {
            try
            {
                return objDServicio.Consultar(id);
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

        public Servicio Consultar(string codigo)
        {
            try
            {
                return objDServicio.Consultar(codigo);
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
                Servicio Servicio = objDServicio.Consultar(id);
                if (Servicio != null)
                {
                    objDServicio.Eliminar(Servicio);
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

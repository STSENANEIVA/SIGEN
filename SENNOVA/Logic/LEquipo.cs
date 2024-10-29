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
    public class LEquipo
    {
        DEquipo objDEquipo;

        public LEquipo()
        {
            objDEquipo = new DEquipo();
        }

        public Equipo Guardar(string placa, string nombre, string serial, string marca, string estado, DateTime fechaCompra, decimal valor, string numeroContrato, DateTime fechaFuncionamiento, int idTipoEquipo, int idResponsable, int idAreaTecnica)
        {
            try
            {
                ValidarCampos(placa, nombre, idTipoEquipo, idResponsable);

                objDEquipo = new DEquipo();
                Equipo objEquipo = new Equipo();
                objEquipo.Placa = placa;
                objEquipo.Nombre = nombre;
                objEquipo.Serial = serial;
                objEquipo.Marca = marca;
                objEquipo.Estado = estado;
                objEquipo.FechaCompra = fechaCompra;
                objEquipo.Valor = valor;
                objEquipo.NumeroContrato = numeroContrato;
                objEquipo.FechaFuncionamiento = fechaFuncionamiento;
                objEquipo.TipoEquipo = new TipoEquipo() { Id = idTipoEquipo };
                objEquipo.AreaTecnica = new AreaTecnica() { Id = idAreaTecnica };
                objEquipo.Responsable = new Empleado() { Id = idResponsable };
                objEquipo.Id = objDEquipo.Guardar(objEquipo);
                return objEquipo;
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

        public Equipo Actualizar(int id, string placa, string nombre, string serial, string marca, string estado, DateTime fechaCompra, decimal valor, string numeroContrato, DateTime fechaFuncionamiento, int idTipoEquipo, int idResponsable, int idAreaTecnica)
        {
            try
            {
                ValidarCampos(placa, nombre, idTipoEquipo, idResponsable);

                Equipo objEquipo = objDEquipo.Consultar(id);
                if (objEquipo.Equals(null))
                {
                    throw new ApplicationException(Message.EquipoNull);
                }

                objDEquipo = new DEquipo();
                objEquipo.Placa = placa;
                objEquipo.Nombre = nombre;
                objEquipo.Serial = serial;
                objEquipo.Marca = marca;
                objEquipo.Estado = estado;
                objEquipo.FechaCompra = fechaCompra;
                objEquipo.Valor = valor;
                objEquipo.NumeroContrato = numeroContrato;
                objEquipo.FechaFuncionamiento = fechaFuncionamiento;
                objEquipo.TipoEquipo = new TipoEquipo() { Id = idTipoEquipo };
                objEquipo.AreaTecnica = new AreaTecnica() { Id = idAreaTecnica };
                objEquipo.Responsable = new Empleado() { Id = idResponsable };

                objDEquipo.Actualizar(objEquipo);
                return objEquipo;
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

        public List<Equipo> Consultar()
        {
            try
            {
                return objDEquipo.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Equipo> ConsultarTipoEquipo(int idTipoEquipo)
        {
            try
            {
                return objDEquipo.ConsultarTipoEquipo(idTipoEquipo);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Equipo>> Consultar(int top, int posicion)
        {
            try
            {
                return objDEquipo.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Equipo Consultar(int id)
        {
            try
            {
                return objDEquipo.Consultar(id);
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

        public Equipo Consultar(string placa)
        {
            try
            {
                return objDEquipo.Consultar(placa);
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

        public Equipo ConsultarNombre(string nombre)
        {
            try
            {
                return objDEquipo.ConsultarNombre(nombre);
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

        public Equipo ConsultarPorTipoEquipo(int idTipoEquipo)
        {
            try
            {
                return objDEquipo.ConsultarPorTipoEquipo(idTipoEquipo);
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
                Equipo Equipo = objDEquipo.Consultar(id);
                if (Equipo != null)
                {
                    objDEquipo.Eliminar(Equipo);
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

        private void ValidarCampos(string placa, string nombre, int idTipoEquipo, int idEmpleado)
        {
           //pendiente
            if (String.IsNullOrEmpty(nombre))
            {
                throw new ApplicationException(Message.NombreVacio);
            }
            if(String.IsNullOrEmpty(idEmpleado.ToString()))
            {
                throw new ApplicationException(Message.EmpleadoVacio);
            }
        }

        public Equipo ConsultarPorAreaTecnica(int idAreaTecnica)
        {
            return objDEquipo.ConsultarPorAreaTecnica(idAreaTecnica);
        }
    }
}

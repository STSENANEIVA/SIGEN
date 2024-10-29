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
    public class LEquipoTecnico
    {
        DEquipoTecnico objDEquipoTecnico;

        public LEquipoTecnico()
        {
            objDEquipoTecnico = new DEquipoTecnico();
        }

        public EquipoTecnico Guardar(string claseEquipo, string caracteristicas, bool aire, bool electricidad, bool gas, bool aceite, bool otros, string presionAire, string caudal, string voltaje, string amperaje, 
            string potencia, string tipoGas, string presionGas, string tipoAceite, string especifique, string observaciones, int idEquipo, int idTipoPatron)
        {
            try
            {
                ValidarCampos(idEquipo, idTipoPatron);

                objDEquipoTecnico = new DEquipoTecnico();
                EquipoTecnico objEquipoTecnico = new EquipoTecnico();
                objEquipoTecnico.ClaseEquipo = claseEquipo;
                objEquipoTecnico.Caracteristicas = caracteristicas;
                objEquipoTecnico.Aire = aire;
                objEquipoTecnico.Electricidad = electricidad;
                objEquipoTecnico.Gas = gas;
                objEquipoTecnico.Aceite = aceite;
                objEquipoTecnico.Otros = otros;
                objEquipoTecnico.PresionAire = presionAire;
                objEquipoTecnico.Caudal = caudal;
                objEquipoTecnico.Voltaje = voltaje;
                objEquipoTecnico.Amperaje = amperaje;
                objEquipoTecnico.Potencia = potencia;
                objEquipoTecnico.TipoGas = tipoGas;
                objEquipoTecnico.PresionGas = presionGas;
                objEquipoTecnico.TipoAceite = tipoAceite;
                objEquipoTecnico.Especifique = especifique;
                objEquipoTecnico.Observaciones = observaciones;
                objEquipoTecnico.Equipo = new Equipo() { Id = idEquipo };
                objEquipoTecnico.TipoPatron = new TipoPatron() { Id = idTipoPatron };
                objEquipoTecnico.Id = objDEquipoTecnico.Guardar(objEquipoTecnico);
                return objEquipoTecnico;
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

        public EquipoTecnico Actualizar(int id, string claseEquipo, string caracteristicas, bool aire, bool electricidad, bool gas, bool aceite, bool otros, string presionAire, string caudal, string voltaje, string amperaje,
            string potencia, string tipoGas, string presionGas, string tipoAceite, string especifique, string observaciones, int idEquipo, int idTipoPatron)
        {
            try
            {
                ValidarCampos(idEquipo, idTipoPatron);

                EquipoTecnico objEquipoTecnico = objDEquipoTecnico.Consultar(id);
                if (Equals(null))
                {
                    throw new ApplicationException(Message.EquipoTecnicoNull);
                }

                objDEquipoTecnico = new DEquipoTecnico();
                objEquipoTecnico.ClaseEquipo = claseEquipo;
                objEquipoTecnico.Caracteristicas = caracteristicas;
                objEquipoTecnico.Aire = aire;
                objEquipoTecnico.Electricidad = electricidad;
                objEquipoTecnico.Gas = gas;
                objEquipoTecnico.Aceite = aceite;
                objEquipoTecnico.Otros = otros;
                objEquipoTecnico.PresionAire = presionAire;
                objEquipoTecnico.Caudal = caudal;
                objEquipoTecnico.Voltaje = voltaje;
                objEquipoTecnico.Amperaje = amperaje;
                objEquipoTecnico.Potencia = potencia;
                objEquipoTecnico.TipoGas = tipoGas;
                objEquipoTecnico.PresionGas = presionGas;
                objEquipoTecnico.TipoAceite = tipoAceite;
                objEquipoTecnico.Especifique = especifique;
                objEquipoTecnico.Observaciones = observaciones;
                objEquipoTecnico.Equipo = new Equipo() { Id = idEquipo };
                objEquipoTecnico.TipoPatron = new TipoPatron() { Id = idTipoPatron };
                objEquipoTecnico.Id = objDEquipoTecnico.Guardar(objEquipoTecnico);

                objDEquipoTecnico.Actualizar(objEquipoTecnico);
                return objEquipoTecnico;
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

        public List<EquipoTecnico> Consultar()
        {
            try
            {
                return objDEquipoTecnico.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<EquipoTecnico> ConsultarEquipo(int idEquipo)
        {
            try
            {
                return objDEquipoTecnico.ConsultarEquipo(idEquipo);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<EquipoTecnico>> Consultar(int top, int posicion)
        {
            try
            {
                return objDEquipoTecnico.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public EquipoTecnico Consultar(int id)
        {
            try
            {
                return objDEquipoTecnico.Consultar(id);
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

        public EquipoTecnico Consultar(string codigo)
        {
            try
            {
                return objDEquipoTecnico.Consultar(codigo);
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

        public EquipoTecnico ConsultarNombre(string nombre)
        {
            try
            {
                return objDEquipoTecnico.ConsultarNombre(nombre);
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

        public EquipoTecnico ConsultarPorTipoPatron(int idTipoPatron)
        {
            try
            {
                return objDEquipoTecnico.ConsultarPorTipoPatron(idTipoPatron);
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
                EquipoTecnico EquipoTecnico = objDEquipoTecnico.Consultar(id);
                if (EquipoTecnico != null)
                {
                    objDEquipoTecnico.Eliminar(EquipoTecnico);
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

        private void ValidarCampos(int idEquipo, int idTipoPatron)
        {
            //pendiente
            if (String.IsNullOrEmpty(idEquipo.ToString()))
            {
                throw new ApplicationException(Message.EquipoVacio);
            }
            if (String.IsNullOrEmpty(idTipoPatron.ToString()))
            {
                throw new ApplicationException(Message.TipoPatronVacio);
            }
        }


    }
}

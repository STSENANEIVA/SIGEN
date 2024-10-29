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
    public class LComputo
    {
        DComputo objDComputo;

        public LComputo()
        {
            objDComputo = new DComputo();
        }

        public Computo Guardar(string ip, bool cuentaAdmin, bool backup, string procesador, string ram, string disco, string observaciones, int idEquipo, int idImpresora)
        {
            try
            {
                ValidarCampos(ip, procesador, idEquipo, idImpresora);

                objDComputo = new DComputo();
                Computo objComputo = new Computo();
                objComputo.Ip = ip;
                objComputo.CuentaAdmin = cuentaAdmin;
                objComputo.Backup = backup;
                objComputo.Procesador = procesador;
                objComputo.Ram = ram;
                objComputo.Disco = disco;
                objComputo.Observaciones = observaciones;
                objComputo.Equipo = new Equipo() { Id = idEquipo };
                
                if (idImpresora != 0)
                {
                    objComputo.Impresora = new Impresora() { Id = idImpresora };

                }
                objComputo.Id = objDComputo.Guardar(objComputo);
                return objComputo;
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

        public Computo Actualizar(int id, string ip, bool cuentaAdmin, bool backup, string procesador, string ram, string disco, string observaciones, int idEquipo, int idImpresora)
        {
            try
            {
                ValidarCampos(ip, procesador, idEquipo, idImpresora);

                Computo objComputo = objDComputo.Consultar(id);
                if (objComputo.Equals(null))
                {
                    throw new ApplicationException(Message.ComputoNull);
                }

                objDComputo = new DComputo();
                objComputo.CuentaAdmin = cuentaAdmin;
                objComputo.Backup = backup;
                objComputo.Procesador = procesador;
                objComputo.Ram = ram;
                objComputo.Disco = disco;
                objComputo.Observaciones = observaciones;
                objComputo.Equipo = new Equipo() { Id = idEquipo };
                objComputo.Impresora = new Impresora() { Id = idImpresora };

                objDComputo.Actualizar(objComputo);
                return objComputo;
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

        public List<Computo> Consultar()
        {
            try
            {
                return objDComputo.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Computo> ConsultarEquipo(int idEquipo)
        {
            try
            {
                return objDComputo.ConsultarEquipo(idEquipo);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Computo>> Consultar(int top, int posicion)
        {
            try
            {
                return objDComputo.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Computo Consultar(int id)
        {
            try
            {
                return objDComputo.Consultar(id);
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

        public Computo ConsultarPorImpresora(int idImpresora)
        {
            try
            {
                return objDComputo.ConsultarPorImpresora(idImpresora);
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

        public Computo Consultar(string codigo)
        {
            try
            {
                return objDComputo.Consultar(codigo);
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

        public Computo ConsultarNombre(string nombre)
        {
            try
            {
                return objDComputo.ConsultarNombre(nombre);
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
                Computo Computo = objDComputo.Consultar(id);
                if (Computo != null)
                {
                    objDComputo.Eliminar(Computo);
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

        private void ValidarCampos(string placa, string nombre, int idEquipo, int idEmpleado)
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

        
    }
}

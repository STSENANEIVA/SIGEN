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
    public class LEmpresa
    {
        DEmpresa objDEmpresa;

        public LEmpresa()
        {
            objDEmpresa = new DEmpresa();
        }

        public Empresa Guardar(string razonSocial, string nit, string telefono, string email, int idSectorEconomico)
        {
            try
            {
                ValidarCampos(razonSocial, nit, idSectorEconomico);

                objDEmpresa = new DEmpresa();
                Empresa objEmpresa = new Empresa();
                objEmpresa.RazonSocial = razonSocial;
                objEmpresa.Nit = nit;
                objEmpresa.Telefono = telefono;
                objEmpresa.Email = email;
                objEmpresa.SectorEconomico = new SectorEconomico() { Id = idSectorEconomico };
                objEmpresa.Id = objDEmpresa.Guardar(objEmpresa);
                return objEmpresa;
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

        public Empresa Actualizar(int id, string razonSocial, string nit, string telefono, string email, int idSectorEconomico)
        {
            try
            {
                ValidarCampos(razonSocial, nit, idSectorEconomico);

                Empresa objEmpresa = objDEmpresa.Consultar(id);
                if (objEmpresa.Equals(null))
                {
                    throw new ApplicationException(Message.EmpresaNull);
                }

                objDEmpresa = new DEmpresa();
                objEmpresa.RazonSocial = razonSocial;
                objEmpresa.Nit = nit;
                objEmpresa.Telefono = telefono;
                objEmpresa.Email = email;
                objEmpresa.SectorEconomico = new SectorEconomico() { Id = idSectorEconomico };
                objDEmpresa.Actualizar(objEmpresa);
                return objEmpresa;
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

        public List<Empresa> Consultar()
        {
            try
            {
                return objDEmpresa.Consultar();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Resultado<List<Empresa>> Consultar(int top, int posicion)
        {
            try
            {
                return objDEmpresa.Consultar(top, posicion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Empresa Consultar(int id)
        {
            try
            {
                return objDEmpresa.Consultar(id);
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

        public Empresa Consultar(string codigo)
        {
            try
            {
                return objDEmpresa.Consultar(codigo);
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
                Empresa Empresa = objDEmpresa.Consultar(id);
                if (Empresa != null)
                {
                    objDEmpresa.Eliminar(Empresa);
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

        private void ValidarCampos(string razonSocial, string nit, int idSectorEconomico)
        {
            if (String.IsNullOrEmpty(razonSocial))
            {
                throw new ApplicationException(Message.RazonSocialVacio);
            }
            if (String.IsNullOrEmpty(nit))
            {
                throw new ApplicationException(Message.NitVacio);
            }
            if (String.IsNullOrEmpty(idSectorEconomico.ToString()))
            {
                throw new ApplicationException(Message.SectorEconomicoVacio);
            }
        }

        public Empresa ConsultarPorSectorEconomico(int idSectorEconomico)
        {
            try
            {
                return objDEmpresa.ConsultarPorSectorEconomico(idSectorEconomico);
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

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DCliente
    {
        private DB_SENNOVAContainer DbContext;

        public DCliente()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Cliente objCliente)
        {
            try
            {
                tblCliente ClienteContext = new tblCliente();
                ClienteContext.Id = objCliente.Id;
                ClienteContext.tblPersona = DbContext.tblPersona.Single(i => i.Id == objCliente.Persona.Id);
                DbContext.tblCliente.Add(ClienteContext);
                DbContext.SaveChanges();
                return ClienteContext.Id;

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Actualizar(Cliente objCliente)
        {
            try
            {
                tblCliente objClienteContext = DbContext.tblCliente.First(v => v.Id == objCliente.Id);
                objClienteContext.Id = objCliente.Id;
                objClienteContext.tblPersona = DbContext.tblPersona.Single(i => i.Id == objCliente.Persona.Id);;
                DbContext.SaveChanges();
                return objClienteContext.Id;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Eliminar(Cliente objCliente)
        {
            try
            {
                var Accion = (from p in DbContext.tblCliente
                              where p.Id == objCliente.Id
                              select p).First();

                DbContext.tblCliente.Remove(Accion);
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cliente> Consultar()
        {
            try
            {
                List<Cliente> lstCliente = new List<Cliente>();

                var query = from i in DbContext.tblCliente
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstCliente.Add(Convertir(item));
                    }
                }

                return lstCliente;

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente Consultar(int id)
        {
            try
            {
                Cliente objCliente = new Cliente();

                var query = (from i in DbContext.tblCliente
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCliente = Convertir(query);
                }
                return objCliente;

            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente Convertir(tblCliente ClienteContext)
        {
            try
            {
                Cliente objCliente = new Cliente();

                objCliente.Id = ClienteContext.Id;

                if (ClienteContext.tblPersona != null)
                {
                    objCliente.Persona = new Persona()
                    {
                        Id = ClienteContext.tblPersona.Id,
                        Codigo = ClienteContext.tblPersona.Codigo,
                        NumeroIdentificacion = ClienteContext.tblPersona.NumeroIdentificacion,
                        NombreCompleto = ClienteContext.tblPersona.Nombres + " " + ClienteContext.tblPersona.Apellidos,
                        Telefono = ClienteContext.tblPersona.Telefono,
                        Email = ClienteContext.tblPersona.Email,
                    };
                }

                return objCliente;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DEmpresa
    {
        private DB_SENNOVAContainer DbContext;

        public DEmpresa()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Empresa objEmpresa)
        {
            try
            {
                tblEmpresa EmpresaContext = new tblEmpresa();
                EmpresaContext.Id = objEmpresa.Id;
                EmpresaContext.RazonSocial = objEmpresa.RazonSocial.ToUpper();
                EmpresaContext.Nit = objEmpresa.Nit;
                EmpresaContext.Telefono = objEmpresa.Telefono;
                EmpresaContext.Email = objEmpresa.Email;
                EmpresaContext.tblSectorEconomico = DbContext.tblSectorEconomico.Single(i => i.Id == objEmpresa.SectorEconomico.Id);
                DbContext.tblEmpresa.Add(EmpresaContext);
                DbContext.SaveChanges();
                return EmpresaContext.Id;

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

        public int Actualizar(Empresa objEmpresa)
        {
            try
            {
                tblEmpresa objEmpresaContext = DbContext.tblEmpresa.First(v => v.Id == objEmpresa.Id);
                objEmpresaContext.Id = objEmpresa.Id;
                objEmpresaContext.RazonSocial = objEmpresa.RazonSocial;
                objEmpresaContext.Nit = objEmpresa.Nit.ToUpper();
                objEmpresaContext.Telefono = objEmpresa.Telefono;
                objEmpresaContext.Email = objEmpresa.Email;
                objEmpresaContext.tblSectorEconomico = DbContext.tblSectorEconomico.Single(i => i.Id == objEmpresa.SectorEconomico.Id);

                DbContext.SaveChanges();
                return objEmpresaContext.Id;
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

        public void Eliminar(Empresa objEmpresa)
        {
            try
            {
                var Accion = (from p in DbContext.tblEmpresa
                              where p.Id == objEmpresa.Id
                              select p).First();

                DbContext.tblEmpresa.Remove(Accion);
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

        public Empresa ConsultarPorSectorEconomico(int idSectorEconomico)
        {
            try
            {
                Empresa objEmpresa = new Empresa();

                var query = (from i in DbContext.tblEmpresa
                             where i.tblSectorEconomico.Id == idSectorEconomico
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEmpresa = Convertir(query);
                }
                return objEmpresa;

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

        public List<Empresa> Consultar()
        {
            try
            {
                List<Empresa> lstEmpresa = new List<Empresa>();

                var query = from i in DbContext.tblEmpresa
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstEmpresa.Add(Convertir(item));
                    }
                }

                return lstEmpresa;

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

        public Resultado<List<Empresa>> Consultar(int top, int posicion)
        {
            try
            {

                List<Empresa> lstEmpresa = new List<Empresa>();
                Resultado<List<Empresa>> resultado = new Resultado<List<Empresa>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblEmpresa
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstEmpresa.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstEmpresa;
                return resultado;

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

        public Empresa Consultar(int id)
        {
            try
            {
                Empresa objEmpresa = new Empresa();

                var query = (from i in DbContext.tblEmpresa
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEmpresa = Convertir(query);
                }
                return objEmpresa;

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

        public Empresa Consultar(string codigo)
        {
            try
            {
                Empresa objEmpresa = new Empresa();

                var query = (from i in DbContext.tblEmpresa
                             where i.RazonSocial == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEmpresa = Convertir(query);
                }
                return objEmpresa;

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


        public Empresa Convertir(tblEmpresa EmpresaContext)
        {
            try
            {
                Empresa objEmpresa = new Empresa();
                objEmpresa.Id = EmpresaContext.Id;
                objEmpresa.RazonSocial = EmpresaContext.RazonSocial;
                objEmpresa.Nit = EmpresaContext.Nit.ToUpper();
                objEmpresa.Telefono = EmpresaContext.Telefono;
                objEmpresa.Email = EmpresaContext.Email;
                objEmpresa.SectorEconomico = new SectorEconomico()
                {
                    Id = EmpresaContext.tblSectorEconomico.Id,
                    Codigo = EmpresaContext.tblSectorEconomico.Codigo,
                    Nombre = EmpresaContext.tblSectorEconomico.Nombre,
                    Activo = EmpresaContext.tblSectorEconomico.Activo,
                };
                return objEmpresa;
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

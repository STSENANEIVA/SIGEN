using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DSoftware
    {
        private DB_SENNOVAContainer DbContext;

        public DSoftware()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Software objSoftware)
        {
            try
            {
                tblSoftware SoftwareContext = new tblSoftware();
                SoftwareContext.Id = objSoftware.Id;
                SoftwareContext.Codigo = objSoftware.Codigo.ToUpper();
                SoftwareContext.Nombre = objSoftware.Nombre.ToUpper();
                SoftwareContext.Version = objSoftware.Version.ToUpper();
                SoftwareContext.Activo = objSoftware.Activo;
                SoftwareContext.tblTipoLicencia = DbContext.tblTipoLicencia.Single(i => i.Id == objSoftware.TipoLicencia.Id);
                DbContext.tblSoftware.Add(SoftwareContext);
                DbContext.SaveChanges();
                return SoftwareContext.Id;

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

        public int Actualizar(Software objSoftware)
        {
            try
            {
                tblSoftware objSoftwareContext = DbContext.tblSoftware.First(v => v.Id == objSoftware.Id);
                objSoftwareContext.Id = objSoftware.Id;
                objSoftwareContext.Codigo = objSoftware.Codigo.ToUpper();
                objSoftwareContext.Nombre = objSoftware.Nombre.ToUpper();
                objSoftwareContext.Version = objSoftware.Version.ToUpper();
                objSoftwareContext.Activo = objSoftware.Activo;
                objSoftwareContext.tblTipoLicencia = DbContext.tblTipoLicencia.Single(i => i.Id == objSoftware.TipoLicencia.Id);

                DbContext.SaveChanges();
                return objSoftwareContext.Id;
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

        public void Eliminar(Software objSoftware)
        {
            try
            {
                var Accion = (from p in DbContext.tblSoftware
                              where p.Id == objSoftware.Id
                              select p).First();

                DbContext.tblSoftware.Remove(Accion);
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

        public Software ConsultarPorTipoLicencia(int id)
        {
            try
            {
                Software objSoftware = new Software();

                var query = (from i in DbContext.tblSoftware
                             where i.tblTipoLicencia.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objSoftware = Convertir(query);
                }
                return objSoftware;

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

        public List<Software> Consultar()
        {
            try
            {
                List<Software> lstSoftware = new List<Software>();

                var query = from i in DbContext.tblSoftware
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstSoftware.Add(Convertir(item));
                    }
                }

                return lstSoftware;

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

        public Resultado<List<Software>> Consultar(int top, int posicion)
        {
            try
            {

                List<Software> lstSoftware = new List<Software>();
                Resultado<List<Software>> resultado = new Resultado<List<Software>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblSoftware
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstSoftware.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstSoftware;
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

        public Software Consultar(int id)
        {
            try
            {
                Software objSoftware = new Software();

                var query = (from i in DbContext.tblSoftware
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objSoftware = Convertir(query);
                }
                return objSoftware;

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

        public Software Consultar(string codigo)
        {
            try
            {
                Software objSoftware = new Software();

                var query = (from i in DbContext.tblSoftware
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objSoftware = Convertir(query);
                }
                return objSoftware;

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


        public Software Convertir(tblSoftware SoftwareContext)
        {
            try
            {
                Software objSoftware = new Software();
                objSoftware.Id = SoftwareContext.Id;
                objSoftware.Codigo = SoftwareContext.Codigo;
                objSoftware.Nombre = SoftwareContext.Nombre;
                objSoftware.Version = SoftwareContext.Version;
                objSoftware.Activo = SoftwareContext.Activo;
                objSoftware.TipoLicencia = new TipoLicencia()
                {
                    Id = SoftwareContext.tblTipoLicencia.Id,
                    Codigo = SoftwareContext.tblTipoLicencia.Codigo,
                    Nombre = SoftwareContext.tblTipoLicencia.Nombre,
                    Activo = SoftwareContext.tblTipoLicencia.Activo,
                };
                return objSoftware;
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

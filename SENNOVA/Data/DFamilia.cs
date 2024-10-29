using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

using Model;
using System.Data.Entity;

namespace Data
{
    public class DFamilia
    {
        private DB_SENNOVAContainer Dbcontext;

        public DFamilia()
        {
            Dbcontext = new DB_SENNOVAContainer();
        }

        public int Guardar(Familia objFamilia)
        {
            try
            {
                tblFamilia FamiliaContext = new tblFamilia();

                FamiliaContext.Id = objFamilia.Id;
                FamiliaContext.Codigo = objFamilia.Codigo;
                FamiliaContext.Nombre = objFamilia.Nombre;
                FamiliaContext.Activo = objFamilia.Activo;

                Dbcontext.tblFamilia.Add(FamiliaContext);
                Dbcontext.SaveChanges();
                return FamiliaContext.Id;
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
        public int Actualizar(Familia objFamilia)
        {
            try
            {
                tblFamilia FamiliaContext = Dbcontext.tblFamilia.First(v => v.Id == objFamilia.Id);
                FamiliaContext.Id = objFamilia.Id;
                FamiliaContext.Codigo = objFamilia.Codigo;
                FamiliaContext.Nombre = objFamilia.Nombre;
                FamiliaContext.Activo = objFamilia.Activo;

                Dbcontext.SaveChanges();
                return FamiliaContext.Id;
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
        public void Eliminar(Familia objFamilia)
        {
            try
            {
                var Accion = (from p in Dbcontext.tblFamilia where p.Id == objFamilia.Id select p).First();
                Dbcontext.tblFamilia.Remove(Accion);
                Dbcontext.SaveChanges();
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
        public List<Familia> Consultar()
        {
            try
            {
                List<Familia> lstFamilia = new List<Familia>();
                var query = from p in Dbcontext.tblFamilia select p;
                if (query != null)
                {
                    foreach(var item in query)
                    {
                        lstFamilia.Add(Convertir(item));
                    }
                }
                return lstFamilia;
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

        public Familia Consultar(int id)
        {
            try
            {
                Familia objFamilia = new Familia();

                var query = (from i in Dbcontext.tblFamilia
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objFamilia = Convertir(query);
                }
                return objFamilia;

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
        public Familia Consultar(string codigo)
        {
            try
            {
                Familia objFamilia = new Familia();
                var query = (from p in Dbcontext.tblFamilia where p.Codigo == codigo select p).FirstOrDefault();
                if (query != null)
                {
                    objFamilia = Convertir(query);
                }
                return objFamilia;
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

        public Familia Convertir(tblFamilia FamiliaContext)
        {
            try
            {
                Familia objFamilia = new Familia();
                objFamilia.Id = FamiliaContext.Id;
                objFamilia.Codigo = FamiliaContext.Codigo;
                objFamilia.Nombre = FamiliaContext.Nombre;
                objFamilia.Activo = FamiliaContext.Activo;

                return objFamilia;
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

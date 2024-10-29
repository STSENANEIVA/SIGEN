using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DTipoPatron
    {
        private DB_SENNOVAContainer DbContext;

        public DTipoPatron()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(TipoPatron objTipoPatron)
        {
            try
            {
                tblTipoPatron TipoPatronContext = new tblTipoPatron();
                TipoPatronContext.Id = objTipoPatron.Id;
                TipoPatronContext.Codigo = objTipoPatron.Codigo;
                TipoPatronContext.Nombre = objTipoPatron.Nombre.ToUpper();
                TipoPatronContext.Activo = objTipoPatron.Activo;
                DbContext.tblTipoPatron.Add(TipoPatronContext);
                DbContext.SaveChanges();
                return TipoPatronContext.Id;

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

        public int Actualizar(TipoPatron objTipoPatron)
        {
            try
            {
                tblTipoPatron objTipoPatronContext = DbContext.tblTipoPatron.First(v => v.Id == objTipoPatron.Id);
                objTipoPatronContext.Id = objTipoPatron.Id;
                objTipoPatronContext.Codigo = objTipoPatron.Codigo;
                objTipoPatronContext.Nombre = objTipoPatron.Nombre.ToUpper();
                objTipoPatronContext.Activo = objTipoPatron.Activo;
                DbContext.SaveChanges();
                return objTipoPatronContext.Id;
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

        public void Eliminar(TipoPatron objTipoPatron)
        {
            try
            {
                var Accion = (from p in DbContext.tblTipoPatron
                              where p.Id == objTipoPatron.Id
                              select p).First();

                DbContext.tblTipoPatron.Remove(Accion);
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

        public List<TipoPatron> Consultar()
        {
            try
            {
                List<TipoPatron> lstTipoPatron = new List<TipoPatron>();

                var query = from i in DbContext.tblTipoPatron
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstTipoPatron.Add(Convertir(item));
                    }
                }

                return lstTipoPatron;

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

        public Resultado<List<TipoPatron>> Consultar(int top, int posicion)
        {
            try
            {

                List<TipoPatron> lstTipoPatron = new List<TipoPatron>();
                Resultado<List<TipoPatron>> resultado = new Resultado<List<TipoPatron>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblTipoPatron
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstTipoPatron.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstTipoPatron;
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

        public TipoPatron Consultar(int id)
        {
            try
            {
                TipoPatron objTipoPatron = new TipoPatron();

                var query = (from i in DbContext.tblTipoPatron
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoPatron = Convertir(query);
                }
                return objTipoPatron;

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

        public TipoPatron Consultar(string codigo)
        {
            try
            {
                TipoPatron objTipoPatron = new TipoPatron();

                var query = (from i in DbContext.tblTipoPatron
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoPatron = Convertir(query);
                }
                return objTipoPatron;

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


        public TipoPatron Convertir(tblTipoPatron TipoPatronContext)
        {
            try
            {
                TipoPatron objTipoPatron = new TipoPatron();
                objTipoPatron.Id = TipoPatronContext.Id;
                objTipoPatron.Codigo = TipoPatronContext.Codigo;
                objTipoPatron.Nombre = TipoPatronContext.Nombre.ToUpper();
                objTipoPatron.Activo = TipoPatronContext.Activo;

                return objTipoPatron;
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

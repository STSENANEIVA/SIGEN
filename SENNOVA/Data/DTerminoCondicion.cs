using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DTerminoCondicion
    {
        private DB_SENNOVAContainer DbContext;

        public DTerminoCondicion()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(TerminoCondicion objTerminoCondicion)
        {
            try
            {
                tblTerminoCondicion TerminoCondicionContext = new tblTerminoCondicion();
                TerminoCondicionContext.Id = objTerminoCondicion.Id;
                TerminoCondicionContext.Codigo = objTerminoCondicion.Codigo;
                TerminoCondicionContext.Nombre = objTerminoCondicion.Nombre.ToUpper();
                TerminoCondicionContext.Activo = objTerminoCondicion.Activo;
                DbContext.tblTerminoCondicion.Add(TerminoCondicionContext);
                DbContext.SaveChanges();
                return TerminoCondicionContext.Id;

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

        public int Actualizar(TerminoCondicion objTerminoCondicion)
        {
            try
            {
                tblTerminoCondicion objTerminoCondicionContext = DbContext.tblTerminoCondicion.First(v => v.Id == objTerminoCondicion.Id);
                objTerminoCondicionContext.Id = objTerminoCondicion.Id;
                objTerminoCondicionContext.Codigo = objTerminoCondicion.Codigo;
                objTerminoCondicionContext.Nombre = objTerminoCondicion.Nombre.ToUpper();
                objTerminoCondicionContext.Activo = objTerminoCondicion.Activo;
                DbContext.SaveChanges();
                return objTerminoCondicionContext.Id;
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

        public void Eliminar(TerminoCondicion objTerminoCondicion)
        {
            try
            {
                var Accion = (from p in DbContext.tblTerminoCondicion
                              where p.Id == objTerminoCondicion.Id
                              select p).First();

                DbContext.tblTerminoCondicion.Remove(Accion);
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

        public List<TerminoCondicion> Consultar()
        {
            try
            {
                List<TerminoCondicion> lstTerminoCondicion = new List<TerminoCondicion>();

                var query = from i in DbContext.tblTerminoCondicion
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstTerminoCondicion.Add(Convertir(item));
                    }
                }

                return lstTerminoCondicion;

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

        public Resultado<List<TerminoCondicion>> Consultar(int top, int posicion)
        {
            try
            {

                List<TerminoCondicion> lstTerminoCondicion = new List<TerminoCondicion>();
                Resultado<List<TerminoCondicion>> resultado = new Resultado<List<TerminoCondicion>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblTerminoCondicion
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstTerminoCondicion.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstTerminoCondicion;
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

        public TerminoCondicion Consultar(int id)
        {
            try
            {
                TerminoCondicion objTerminoCondicion = new TerminoCondicion();

                var query = (from i in DbContext.tblTerminoCondicion
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTerminoCondicion = Convertir(query);
                }
                return objTerminoCondicion;

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

        public TerminoCondicion Consultar(string codigo)
        {
            try
            {
                TerminoCondicion objTerminoCondicion = new TerminoCondicion();

                var query = (from i in DbContext.tblTerminoCondicion
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTerminoCondicion = Convertir(query);
                }
                return objTerminoCondicion;

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


        public TerminoCondicion Convertir(tblTerminoCondicion TerminoCondicionContext)
        {
            try
            {
                TerminoCondicion objTerminoCondicion = new TerminoCondicion();
                objTerminoCondicion.Id = TerminoCondicionContext.Id;
                objTerminoCondicion.Codigo = TerminoCondicionContext.Codigo;
                objTerminoCondicion.Nombre = TerminoCondicionContext.Nombre.ToUpper();
                objTerminoCondicion.Activo = TerminoCondicionContext.Activo;

                return objTerminoCondicion;
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

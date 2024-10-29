using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DRedConocimientoSectorial
    {
        private DB_SENNOVAContainer DbContext;

        public DRedConocimientoSectorial()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(RedConocimientoSectorial objRedConocimientoSectorial)
        {
            try
            {
                tblRedConocimientoSectorial RedConocimientoSectorialContext = new tblRedConocimientoSectorial();
                RedConocimientoSectorialContext.Id = objRedConocimientoSectorial.Id;
                RedConocimientoSectorialContext.Codigo = objRedConocimientoSectorial.Codigo;
                RedConocimientoSectorialContext.Nombre = objRedConocimientoSectorial.Nombre.ToUpper();
                RedConocimientoSectorialContext.Activo = objRedConocimientoSectorial.Activo;
                DbContext.tblRedConocimientoSectorial.Add(RedConocimientoSectorialContext);
                DbContext.SaveChanges();
                return RedConocimientoSectorialContext.Id;

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

        public int Actualizar(RedConocimientoSectorial objRedConocimientoSectorial)
        {
            try
            {
                tblRedConocimientoSectorial objRedConocimientoSectorialContext = DbContext.tblRedConocimientoSectorial.First(v => v.Id == objRedConocimientoSectorial.Id);
                objRedConocimientoSectorialContext.Id = objRedConocimientoSectorial.Id;
                objRedConocimientoSectorialContext.Codigo = objRedConocimientoSectorial.Codigo;
                objRedConocimientoSectorialContext.Nombre = objRedConocimientoSectorial.Nombre.ToUpper();
                objRedConocimientoSectorialContext.Activo = objRedConocimientoSectorial.Activo;
                DbContext.SaveChanges();
                return objRedConocimientoSectorialContext.Id;
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

        public void Eliminar(RedConocimientoSectorial objRedConocimientoSectorial)
        {
            try
            {
                var Accion = (from p in DbContext.tblRedConocimientoSectorial
                              where p.Id == objRedConocimientoSectorial.Id
                              select p).First();

                DbContext.tblRedConocimientoSectorial.Remove(Accion);
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

        public List<RedConocimientoSectorial> Consultar()
        {
            try
            {
                List<RedConocimientoSectorial> lstRedConocimientoSectorial = new List<RedConocimientoSectorial>();

                var query = from i in DbContext.tblRedConocimientoSectorial
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstRedConocimientoSectorial.Add(Convertir(item));
                    }
                }

                return lstRedConocimientoSectorial;

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

        public Resultado<List<RedConocimientoSectorial>> Consultar(int top, int posicion)
        {
            try
            {

                List<RedConocimientoSectorial> lstRedConocimientoSectorial = new List<RedConocimientoSectorial>();
                Resultado<List<RedConocimientoSectorial>> resultado = new Resultado<List<RedConocimientoSectorial>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblRedConocimientoSectorial
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstRedConocimientoSectorial.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstRedConocimientoSectorial;
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

        public RedConocimientoSectorial Consultar(int id)
        {
            try
            {
                RedConocimientoSectorial objRedConocimientoSectorial = new RedConocimientoSectorial();

                var query = (from i in DbContext.tblRedConocimientoSectorial
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRedConocimientoSectorial = Convertir(query);
                }
                return objRedConocimientoSectorial;

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

        public RedConocimientoSectorial Consultar(string codigo)
        {
            try
            {
                RedConocimientoSectorial objRedConocimientoSectorial = new RedConocimientoSectorial();

                var query = (from i in DbContext.tblRedConocimientoSectorial
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRedConocimientoSectorial = Convertir(query);
                }
                return objRedConocimientoSectorial;

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


        public RedConocimientoSectorial Convertir(tblRedConocimientoSectorial RedConocimientoSectorialContext)
        {
            try
            {
                RedConocimientoSectorial objRedConocimientoSectorial = new RedConocimientoSectorial();
                objRedConocimientoSectorial.Id = RedConocimientoSectorialContext.Id;
                objRedConocimientoSectorial.Codigo = RedConocimientoSectorialContext.Codigo;
                objRedConocimientoSectorial.Nombre = RedConocimientoSectorialContext.Nombre.ToUpper();
                objRedConocimientoSectorial.Activo = RedConocimientoSectorialContext.Activo;

                return objRedConocimientoSectorial;
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

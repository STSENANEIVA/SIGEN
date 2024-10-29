using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
   public  class DImpresora
    {
        private DB_SENNOVAContainer DbContext;

        public DImpresora()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Impresora objImpresora)
        {
            try
            {
                tblImpresora ImpresoraContext = new tblImpresora();
                ImpresoraContext.Id = objImpresora.Id;
                ImpresoraContext.Codigo = objImpresora.Codigo;
                ImpresoraContext.Nombre = objImpresora.Nombre.ToUpper();
                ImpresoraContext.Activo = objImpresora.Activo;
                DbContext.tblImpresora.Add(ImpresoraContext);
                DbContext.SaveChanges();
                return ImpresoraContext.Id;

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

        public int Actualizar(Impresora objImpresora)
        {
            try
            {
                tblImpresora objImpresoraContext = DbContext.tblImpresora.First(v => v.Id == objImpresora.Id);
                objImpresoraContext.Id = objImpresora.Id;
                objImpresoraContext.Codigo = objImpresora.Codigo;
                objImpresoraContext.Nombre = objImpresora.Nombre.ToUpper();
                objImpresoraContext.Activo = objImpresora.Activo;
                DbContext.SaveChanges();
                return objImpresoraContext.Id;
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

        public void Eliminar(Impresora objImpresora)
        {
            try
            {
                var Accion = (from p in DbContext.tblImpresora
                              where p.Id == objImpresora.Id
                              select p).First();

                DbContext.tblImpresora.Remove(Accion);
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

        public List<Impresora> Consultar()
        {
            try
            {
                List<Impresora> lstImpresora = new List<Impresora>();

                var query = from i in DbContext.tblImpresora
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstImpresora.Add(Convertir(item));
                    }
                }

                return lstImpresora;

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

        public Resultado<List<Impresora>> Consultar(int top, int posicion)
        {
            try
            {

                List<Impresora> lstImpresora = new List<Impresora>();
                Resultado<List<Impresora>> resultado = new Resultado<List<Impresora>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblImpresora
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstImpresora.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstImpresora;
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

        public Impresora Consultar(int id)
        {
            try
            {
                Impresora objImpresora = new Impresora();

                var query = (from i in DbContext.tblImpresora
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objImpresora = Convertir(query);
                }
                return objImpresora;

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

        public Impresora Consultar(string codigo)
        {
            try
            {
                Impresora objImpresora = new Impresora();

                var query = (from i in DbContext.tblImpresora
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objImpresora = Convertir(query);
                }
                return objImpresora;

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


        public Impresora Convertir(tblImpresora ImpresoraContext)
        {
            try
            {
                Impresora objImpresora = new Impresora();
                objImpresora.Id = ImpresoraContext.Id;
                objImpresora.Codigo = ImpresoraContext.Codigo;
                objImpresora.Nombre = ImpresoraContext.Nombre.ToUpper();
                objImpresora.Activo = ImpresoraContext.Activo;

                return objImpresora;
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

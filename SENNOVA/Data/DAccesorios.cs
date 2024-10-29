using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
   public  class DAccesorios
    {
        private DB_SENNOVAContainer DbContext;

        public DAccesorios()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Accesorios objAccesorios)
        {
            try
            {
                tblAccesorios AccesoriosContext = new tblAccesorios();
                AccesoriosContext.Id = objAccesorios.Id;
                AccesoriosContext.Codigo = objAccesorios.Codigo;
                AccesoriosContext.Nombre = objAccesorios.Nombre.ToUpper();
                AccesoriosContext.Descripcion = objAccesorios.Descripcion.ToUpper();
                AccesoriosContext.Activo = objAccesorios.Activo;
                DbContext.tblAccesorios.Add(AccesoriosContext);
                DbContext.SaveChanges();
                return AccesoriosContext.Id;

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

        public int Actualizar(Accesorios objAccesorios)
        {
            try
            {
                tblAccesorios objAccesoriosContext = DbContext.tblAccesorios.First(v => v.Id == objAccesorios.Id);
                objAccesoriosContext.Id = objAccesorios.Id;
                objAccesoriosContext.Codigo = objAccesorios.Codigo;
                objAccesoriosContext.Nombre = objAccesorios.Nombre.ToUpper();
                objAccesoriosContext.Descripcion = objAccesorios.Descripcion.ToUpper();
                objAccesoriosContext.Activo = objAccesorios.Activo;
                DbContext.SaveChanges();
                return objAccesoriosContext.Id;
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

        public void Eliminar(Accesorios objAccesorios)
        {
            try
            {
                var Accion = (from p in DbContext.tblAccesorios
                              where p.Id == objAccesorios.Id
                              select p).First();

                DbContext.tblAccesorios.Remove(Accion);
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

        public List<Accesorios> Consultar()
        {
            try
            {
                List<Accesorios> lstAccesorios = new List<Accesorios>();

                var query = from i in DbContext.tblAccesorios
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstAccesorios.Add(Convertir(item));
                    }
                }

                return lstAccesorios;

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

        public Resultado<List<Accesorios>> Consultar(int top, int posicion)
        {
            try
            {

                List<Accesorios> lstAccesorios = new List<Accesorios>();
                Resultado<List<Accesorios>> resultado = new Resultado<List<Accesorios>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblAccesorios
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstAccesorios.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstAccesorios;
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

        public Accesorios Consultar(int id)
        {
            try
            {
                Accesorios objAccesorios = new Accesorios();

                var query = (from i in DbContext.tblAccesorios
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objAccesorios = Convertir(query);
                }
                return objAccesorios;

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

        public Accesorios Consultar(string codigo)
        {
            try
            {
                Accesorios objAccesorios = new Accesorios();

                var query = (from i in DbContext.tblAccesorios
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objAccesorios = Convertir(query);
                }
                return objAccesorios;

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


        public Accesorios Convertir(tblAccesorios AccesoriosContext)
        {
            try
            {
                Accesorios objAccesorios = new Accesorios();
                objAccesorios.Id = AccesoriosContext.Id;
                objAccesorios.Codigo = AccesoriosContext.Codigo;
                objAccesorios.Nombre = AccesoriosContext.Nombre.ToUpper();
                objAccesorios.Descripcion = AccesoriosContext.Descripcion.ToUpper();
                objAccesorios.Activo = AccesoriosContext.Activo;

                return objAccesorios;
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

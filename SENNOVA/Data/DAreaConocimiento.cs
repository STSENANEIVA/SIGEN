using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DAreaConocimiento
    {
        private DB_SENNOVAContainer DbContext;

        public DAreaConocimiento()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(AreaConocimiento objAreaConocimiento)
        {
            try
            {
                tblAreaConocimiento AreaConocimientoContext = new tblAreaConocimiento();
                AreaConocimientoContext.Id = objAreaConocimiento.Id;
                AreaConocimientoContext.Codigo = objAreaConocimiento.Codigo;
                AreaConocimientoContext.Nombre = objAreaConocimiento.Nombre.ToUpper();
                AreaConocimientoContext.Activo = objAreaConocimiento.Activo;
                DbContext.tblAreaConocimiento.Add(AreaConocimientoContext);
                DbContext.SaveChanges();
                return AreaConocimientoContext.Id;

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

        public int Actualizar(AreaConocimiento objAreaConocimiento)
        {
            try
            {
                tblAreaConocimiento objAreaConocimientoContext = DbContext.tblAreaConocimiento.First(v => v.Id == objAreaConocimiento.Id);
                objAreaConocimientoContext.Id = objAreaConocimiento.Id;
                objAreaConocimientoContext.Codigo = objAreaConocimiento.Codigo;
                objAreaConocimientoContext.Nombre = objAreaConocimiento.Nombre.ToUpper();
                objAreaConocimientoContext.Activo = objAreaConocimiento.Activo;
                DbContext.SaveChanges();
                return objAreaConocimientoContext.Id;
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

        public void Eliminar(AreaConocimiento objAreaConocimiento)
        {
            try
            {
                var Accion = (from p in DbContext.tblAreaConocimiento
                              where p.Id == objAreaConocimiento.Id
                              select p).First();

                DbContext.tblAreaConocimiento.Remove(Accion);
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

        public List<AreaConocimiento> Consultar()
        {
            try
            {
                List<AreaConocimiento> lstAreaConocimiento = new List<AreaConocimiento>();

                var query = from i in DbContext.tblAreaConocimiento
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstAreaConocimiento.Add(Convertir(item));
                    }
                }

                return lstAreaConocimiento;

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

        public Resultado<List<AreaConocimiento>> Consultar(int top, int posicion)
        {
            try
            {

                List<AreaConocimiento> lstAreaConocimiento = new List<AreaConocimiento>();
                Resultado<List<AreaConocimiento>> resultado = new Resultado<List<AreaConocimiento>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblAreaConocimiento
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstAreaConocimiento.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstAreaConocimiento;
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

        public AreaConocimiento Consultar(int id)
        {
            try
            {
                AreaConocimiento objAreaConocimiento = new AreaConocimiento();

                var query = (from i in DbContext.tblAreaConocimiento
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objAreaConocimiento = Convertir(query);
                }
                return objAreaConocimiento;

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

        public AreaConocimiento Consultar(string codigo)
        {
            try
            {
                AreaConocimiento objAreaConocimiento = new AreaConocimiento();

                var query = (from i in DbContext.tblAreaConocimiento
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objAreaConocimiento = Convertir(query);
                }
                return objAreaConocimiento;

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


        public AreaConocimiento Convertir(tblAreaConocimiento AreaConocimientoContext)
        {
            try
            {
                AreaConocimiento objAreaConocimiento = new AreaConocimiento();
                objAreaConocimiento.Id = AreaConocimientoContext.Id;
                objAreaConocimiento.Codigo = AreaConocimientoContext.Codigo;
                objAreaConocimiento.Nombre = AreaConocimientoContext.Nombre.ToUpper();
                objAreaConocimiento.Activo = AreaConocimientoContext.Activo;

                return objAreaConocimiento;
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

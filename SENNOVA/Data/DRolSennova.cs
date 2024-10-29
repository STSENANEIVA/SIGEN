using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DRolSennova
    {
        private DB_SENNOVAContainer DbContext;

        public DRolSennova()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(RolSennova objRolSennova)
        {
            try
            {
                tblRolSennova RolSennovaContext = new tblRolSennova();
                RolSennovaContext.Id = objRolSennova.Id;
                RolSennovaContext.Codigo = objRolSennova.Codigo;
                RolSennovaContext.Nombre = objRolSennova.Nombre.ToUpper();
                RolSennovaContext.Activo = objRolSennova.Activo;
                DbContext.tblRolSennova.Add(RolSennovaContext);
                DbContext.SaveChanges();
                return RolSennovaContext.Id;

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

        public int Actualizar(RolSennova objRolSennova)
        {
            try
            {
                tblRolSennova objRolSennovaContext = DbContext.tblRolSennova.First(v => v.Id == objRolSennova.Id);
                objRolSennovaContext.Id = objRolSennova.Id;
                objRolSennovaContext.Codigo = objRolSennova.Codigo;
                objRolSennovaContext.Nombre = objRolSennova.Nombre.ToUpper();
                objRolSennovaContext.Activo = objRolSennova.Activo;
                DbContext.SaveChanges();
                return objRolSennovaContext.Id;
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

        public void Eliminar(RolSennova objRolSennova)
        {
            try
            {
                var Accion = (from p in DbContext.tblRolSennova
                              where p.Id == objRolSennova.Id
                              select p).First();

                DbContext.tblRolSennova.Remove(Accion);
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

        public List<RolSennova> Consultar()
        {
            try
            {
                List<RolSennova> lstRolSennova = new List<RolSennova>();

                var query = from i in DbContext.tblRolSennova
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstRolSennova.Add(Convertir(item));
                    }
                }

                return lstRolSennova;

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

        public Resultado<List<RolSennova>> Consultar(int top, int posicion)
        {
            try
            {

                List<RolSennova> lstRolSennova = new List<RolSennova>();
                Resultado<List<RolSennova>> resultado = new Resultado<List<RolSennova>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblRolSennova
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstRolSennova.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstRolSennova;
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

        public RolSennova Consultar(int id)
        {
            try
            {
                RolSennova objRolSennova = new RolSennova();

                var query = (from i in DbContext.tblRolSennova
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRolSennova = Convertir(query);
                }
                return objRolSennova;

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

        public RolSennova Consultar(string codigo)
        {
            try
            {
                RolSennova objRolSennova = new RolSennova();

                var query = (from i in DbContext.tblRolSennova
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRolSennova = Convertir(query);
                }
                return objRolSennova;

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

        public RolSennova Convertir(tblRolSennova RolSennovaContext)
        {
            try
            {
                RolSennova objRolSennova = new RolSennova();
                objRolSennova.Id = RolSennovaContext.Id;
                objRolSennova.Codigo = RolSennovaContext.Codigo;
                objRolSennova.Nombre = RolSennovaContext.Nombre.ToUpper();
                objRolSennova.Activo = RolSennovaContext.Activo;

                return objRolSennova;
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

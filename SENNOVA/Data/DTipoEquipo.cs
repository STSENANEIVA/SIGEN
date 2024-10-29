using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DTipoEquipo
    {
        private DB_SENNOVAContainer DbContext;

        public DTipoEquipo()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(TipoEquipo objTipoEquipo)
        {
            try
            {
                tblTipoEquipo TipoEquipoContext = new tblTipoEquipo();
                TipoEquipoContext.Id = objTipoEquipo.Id;
                TipoEquipoContext.Codigo = objTipoEquipo.Codigo;
                TipoEquipoContext.Nombre = objTipoEquipo.Nombre.ToUpper();
                TipoEquipoContext.Activo = objTipoEquipo.Activo;
                DbContext.tblTipoEquipo.Add(TipoEquipoContext);
                DbContext.SaveChanges();
                return TipoEquipoContext.Id;

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

        public int Actualizar(TipoEquipo objTipoEquipo)
        {
            try
            {
                tblTipoEquipo objTipoEquipoContext = DbContext.tblTipoEquipo.First(v => v.Id == objTipoEquipo.Id);
                objTipoEquipoContext.Id = objTipoEquipo.Id;
                objTipoEquipoContext.Codigo = objTipoEquipo.Codigo;
                objTipoEquipoContext.Nombre = objTipoEquipo.Nombre.ToUpper();
                objTipoEquipoContext.Activo = objTipoEquipo.Activo;
                DbContext.SaveChanges();
                return objTipoEquipoContext.Id;
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

        public void Eliminar(TipoEquipo objTipoEquipo)
        {
            try
            {
                var Accion = (from p in DbContext.tblTipoEquipo
                              where p.Id == objTipoEquipo.Id
                              select p).First();

                DbContext.tblTipoEquipo.Remove(Accion);
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

        public List<TipoEquipo> Consultar()
        {
            try
            {
                List<TipoEquipo> lstTipoEquipo = new List<TipoEquipo>();

                var query = from i in DbContext.tblTipoEquipo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstTipoEquipo.Add(Convertir(item));
                    }
                }

                return lstTipoEquipo;

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

        public Resultado<List<TipoEquipo>> Consultar(int top, int posicion)
        {
            try
            {

                List<TipoEquipo> lstTipoEquipo = new List<TipoEquipo>();
                Resultado<List<TipoEquipo>> resultado = new Resultado<List<TipoEquipo>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblTipoEquipo
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstTipoEquipo.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstTipoEquipo;
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

        public TipoEquipo Consultar(int id)
        {
            try
            {
                TipoEquipo objTipoEquipo = new TipoEquipo();

                var query = (from i in DbContext.tblTipoEquipo
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoEquipo = Convertir(query);
                }
                return objTipoEquipo;

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

        public TipoEquipo Consultar(string codigo)
        {
            try
            {
                TipoEquipo objTipoEquipo = new TipoEquipo();

                var query = (from i in DbContext.tblTipoEquipo
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoEquipo = Convertir(query);
                }
                return objTipoEquipo;

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


        public TipoEquipo Convertir(tblTipoEquipo TipoEquipoContext)
        {
            try
            {
                TipoEquipo objTipoEquipo = new TipoEquipo();
                objTipoEquipo.Id = TipoEquipoContext.Id;
                objTipoEquipo.Codigo = TipoEquipoContext.Codigo;
                objTipoEquipo.Nombre = TipoEquipoContext.Nombre.ToUpper();
                objTipoEquipo.Activo = TipoEquipoContext.Activo;

                return objTipoEquipo;
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

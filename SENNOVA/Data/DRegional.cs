using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DRegional
    {
        private DB_SENNOVAContainer DbContext;

        public DRegional()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Regional objRegional)
        {
            try
            {
                tblRegional RegionalContext = new tblRegional();
                RegionalContext.Id = objRegional.Id;
                RegionalContext.Codigo = objRegional.Codigo;
                RegionalContext.Nombre = objRegional.Nombre.ToUpper();
                RegionalContext.Activo = objRegional.Activo;
                RegionalContext.tblRegion = DbContext.tblRegion.Single(i => i.Id == objRegional.Region.Id);
                DbContext.tblRegional.Add(RegionalContext);
                DbContext.SaveChanges();
                return RegionalContext.Id;

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

        public int Actualizar(Regional objRegional)
        {
            try
            {
                tblRegional objRegionalContext = DbContext.tblRegional.First(v => v.Id == objRegional.Id);
                objRegionalContext.Id = objRegional.Id;
                objRegionalContext.Codigo = objRegional.Codigo;
                objRegionalContext.Nombre = objRegional.Nombre.ToUpper();
                objRegionalContext.Activo = objRegional.Activo;
                objRegionalContext.tblRegion = DbContext.tblRegion.Single(i => i.Id == objRegional.Region.Id);

                DbContext.SaveChanges();
                return objRegionalContext.Id;
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

        public void Eliminar(Regional objRegional)
        {
            try
            {
                var Accion = (from p in DbContext.tblRegional
                              where p.Id == objRegional.Id
                              select p).First();

                DbContext.tblRegional.Remove(Accion);
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

        public Regional ConsultarPorRegion(int id)
        {
            try
            {
                Regional objRegional = new Regional();

                var query = (from i in DbContext.tblRegional
                             where i.tblRegion.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRegional = Convertir(query);
                }
                return objRegional;

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

        public List<Regional> Consultar()
        {
            try
            {
                List<Regional> lstRegional = new List<Regional>();

                var query = from i in DbContext.tblRegional
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstRegional.Add(Convertir(item));
                    }
                }

                return lstRegional;

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

        public Resultado<List<Regional>> Consultar(int top, int posicion)
        {
            try
            {

                List<Regional> lstRegional = new List<Regional>();
                Resultado<List<Regional>> resultado = new Resultado<List<Regional>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblRegional
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstRegional.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstRegional;
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

        public Regional Consultar(int id)
        {
            try
            {
                Regional objRegional = new Regional();

                var query = (from i in DbContext.tblRegional
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRegional = Convertir(query);
                }
                return objRegional;

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

        public Regional Consultar(string codigo)
        {
            try
            {
                Regional objRegional = new Regional();

                var query = (from i in DbContext.tblRegional
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRegional = Convertir(query);
                }
                return objRegional;

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


        public Regional Convertir(tblRegional RegionalContext)
        {
            try
            {
                Regional objRegional = new Regional();
                objRegional.Id = RegionalContext.Id;
                objRegional.Codigo = RegionalContext.Codigo;
                objRegional.Nombre = RegionalContext.Nombre.ToUpper();
                objRegional.Activo = RegionalContext.Activo;
                objRegional.Region = new Region()
                {
                    Id = RegionalContext.tblRegion.Id,
                    Codigo = RegionalContext.tblRegion.Codigo,
                    Nombre = RegionalContext.tblRegion.Nombre,
                    Activo = RegionalContext.tblRegion.Activo,
                };
                return objRegional;
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

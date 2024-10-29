using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
   public  class DRegion
    {
        private DB_SENNOVAContainer DbContext;

        public DRegion()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Region objRegion)
        {
            try
            {
                tblRegion RegionContext = new tblRegion();
                RegionContext.Id = objRegion.Id;
                RegionContext.Codigo = objRegion.Codigo;
                RegionContext.Nombre = objRegion.Nombre.ToUpper();
                RegionContext.Activo = objRegion.Activo;
                DbContext.tblRegion.Add(RegionContext);
                DbContext.SaveChanges();
                return RegionContext.Id;

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

        public int Actualizar(Region objRegion)
        {
            try
            {
                tblRegion objRegionContext = DbContext.tblRegion.First(v => v.Id == objRegion.Id);
                objRegionContext.Id = objRegion.Id;
                objRegionContext.Codigo = objRegion.Codigo;
                objRegionContext.Nombre = objRegion.Nombre.ToUpper();
                objRegionContext.Activo = objRegion.Activo;
                DbContext.SaveChanges();
                return objRegionContext.Id;
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

        public void Eliminar(Region objRegion)
        {
            try
            {
                var Accion = (from p in DbContext.tblRegion
                              where p.Id == objRegion.Id
                              select p).First();

                DbContext.tblRegion.Remove(Accion);
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

        public List<Region> Consultar()
        {
            try
            {
                List<Region> lstRegion = new List<Region>();

                var query = from i in DbContext.tblRegion
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstRegion.Add(Convertir(item));
                    }
                }

                return lstRegion;

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

        public Resultado<List<Region>> Consultar(int top, int posicion)
        {
            try
            {

                List<Region> lstRegion = new List<Region>();
                Resultado<List<Region>> resultado = new Resultado<List<Region>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblRegion
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstRegion.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstRegion;
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

        public Region Consultar(int id)
        {
            try
            {
                Region objRegion = new Region();

                var query = (from i in DbContext.tblRegion
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRegion = Convertir(query);
                }
                return objRegion;

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

        public Region Consultar(string codigo)
        {
            try
            {
                Region objRegion = new Region();

                var query = (from i in DbContext.tblRegion
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRegion = Convertir(query);
                }
                return objRegion;

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


        public Region Convertir(tblRegion RegionContext)
        {
            try
            {
                Region objRegion = new Region();
                objRegion.Id = RegionContext.Id;
                objRegion.Codigo = RegionContext.Codigo;
                objRegion.Nombre = RegionContext.Nombre.ToUpper();
                objRegion.Activo = RegionContext.Activo;

                return objRegion;
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

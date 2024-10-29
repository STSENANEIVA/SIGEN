using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DSectorEconomico
    {
        private DB_SENNOVAContainer DbContext;

        public DSectorEconomico()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(SectorEconomico objSectorEconomico)
        {
            try
            {
                tblSectorEconomico SectorEconomicoContext = new tblSectorEconomico();
                SectorEconomicoContext.Id = objSectorEconomico.Id;
                SectorEconomicoContext.Codigo = objSectorEconomico.Codigo;
                SectorEconomicoContext.Nombre = objSectorEconomico.Nombre.ToUpper();
                SectorEconomicoContext.Activo = objSectorEconomico.Activo;
                DbContext.tblSectorEconomico.Add(SectorEconomicoContext);
                DbContext.SaveChanges();
                return SectorEconomicoContext.Id;

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

        public int Actualizar(SectorEconomico objSectorEconomico)
        {
            try
            {
                tblSectorEconomico objSectorEconomicoContext = DbContext.tblSectorEconomico.First(v => v.Id == objSectorEconomico.Id);
                objSectorEconomicoContext.Id = objSectorEconomico.Id;
                objSectorEconomicoContext.Codigo = objSectorEconomico.Codigo;
                objSectorEconomicoContext.Nombre = objSectorEconomico.Nombre.ToUpper();
                objSectorEconomicoContext.Activo = objSectorEconomico.Activo;
                DbContext.SaveChanges();
                return objSectorEconomicoContext.Id;
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

        public void Eliminar(SectorEconomico objSectorEconomico)
        {
            try
            {
                var Accion = (from p in DbContext.tblSectorEconomico
                              where p.Id == objSectorEconomico.Id
                              select p).First();

                DbContext.tblSectorEconomico.Remove(Accion);
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

        public List<SectorEconomico> Consultar()
        {
            try
            {
                List<SectorEconomico> lstSectorEconomico = new List<SectorEconomico>();

                var query = from i in DbContext.tblSectorEconomico
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstSectorEconomico.Add(Convertir(item));
                    }
                }

                return lstSectorEconomico;

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

        public Resultado<List<SectorEconomico>> Consultar(int top, int posicion)
        {
            try
            {

                List<SectorEconomico> lstSectorEconomico = new List<SectorEconomico>();
                Resultado<List<SectorEconomico>> resultado = new Resultado<List<SectorEconomico>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblSectorEconomico
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstSectorEconomico.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstSectorEconomico;
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

        public SectorEconomico Consultar(int id)
        {
            try
            {
                SectorEconomico objSectorEconomico = new SectorEconomico();

                var query = (from i in DbContext.tblSectorEconomico
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objSectorEconomico = Convertir(query);
                }
                return objSectorEconomico;

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

        public SectorEconomico Consultar(string codigo)
        {
            try
            {
                SectorEconomico objSectorEconomico = new SectorEconomico();

                var query = (from i in DbContext.tblSectorEconomico
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objSectorEconomico = Convertir(query);
                }
                return objSectorEconomico;

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

        public SectorEconomico ConsultarNombre(string nombre)
        {
            try
            {
                SectorEconomico objSectorEconomico = new SectorEconomico();

                var query = (from i in DbContext.tblSectorEconomico
                             where i.Nombre == nombre
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objSectorEconomico = Convertir(query);
                }
                return objSectorEconomico;

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

        public SectorEconomico Convertir(tblSectorEconomico SectorEconomicoContext)
        {
            try
            {
                SectorEconomico objSectorEconomico = new SectorEconomico();
                objSectorEconomico.Id = SectorEconomicoContext.Id;
                objSectorEconomico.Codigo = SectorEconomicoContext.Codigo;
                objSectorEconomico.Nombre = SectorEconomicoContext.Nombre.ToUpper();
                objSectorEconomico.Activo = SectorEconomicoContext.Activo;

                return objSectorEconomico;
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

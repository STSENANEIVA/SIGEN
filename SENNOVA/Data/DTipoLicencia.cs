using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DTipoLicencia
    {
        private DB_SENNOVAContainer DbContext;

        public DTipoLicencia()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(TipoLicencia objTipoLicencia)
        {
            try
            {
                tblTipoLicencia TipoLicenciaContext = new tblTipoLicencia();
                TipoLicenciaContext.Id = objTipoLicencia.Id;
                TipoLicenciaContext.Codigo = objTipoLicencia.Codigo;
                TipoLicenciaContext.Nombre = objTipoLicencia.Nombre.ToUpper();
                TipoLicenciaContext.Activo = objTipoLicencia.Activo;
                DbContext.tblTipoLicencia.Add(TipoLicenciaContext);
                DbContext.SaveChanges();
                return TipoLicenciaContext.Id;

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

        public int Actualizar(TipoLicencia objTipoLicencia)
        {
            try
            {
                tblTipoLicencia objTipoLicenciaContext = DbContext.tblTipoLicencia.First(v => v.Id == objTipoLicencia.Id);
                objTipoLicenciaContext.Id = objTipoLicencia.Id;
                objTipoLicenciaContext.Codigo = objTipoLicencia.Codigo;
                objTipoLicenciaContext.Nombre = objTipoLicencia.Nombre.ToUpper();
                objTipoLicenciaContext.Activo = objTipoLicencia.Activo;
                DbContext.SaveChanges();
                return objTipoLicenciaContext.Id;
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

        public void Eliminar(TipoLicencia objTipoLicencia)
        {
            try
            {
                var Accion = (from p in DbContext.tblTipoLicencia
                              where p.Id == objTipoLicencia.Id
                              select p).First();

                DbContext.tblTipoLicencia.Remove(Accion);
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

        public List<TipoLicencia> Consultar()
        {
            try
            {
                List<TipoLicencia> lstTipoLicencia = new List<TipoLicencia>();

                var query = from i in DbContext.tblTipoLicencia
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstTipoLicencia.Add(Convertir(item));
                    }
                }

                return lstTipoLicencia;

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

        

        public Resultado<List<TipoLicencia>> Consultar(int top, int posicion)
        {
            try
            {

                List<TipoLicencia> lstTipoLicencia = new List<TipoLicencia>();
                Resultado<List<TipoLicencia>> resultado = new Resultado<List<TipoLicencia>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblTipoLicencia
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstTipoLicencia.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstTipoLicencia;
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

        public TipoLicencia Consultar(int id)
        {
            try
            {
                TipoLicencia objTipoLicencia = new TipoLicencia();

                var query = (from i in DbContext.tblTipoLicencia
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoLicencia = Convertir(query);
                }
                return objTipoLicencia;

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

        public TipoLicencia Consultar(string codigo)
        {
            try
            {
                TipoLicencia objTipoLicencia = new TipoLicencia();

                var query = (from i in DbContext.tblTipoLicencia
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoLicencia = Convertir(query);
                }
                return objTipoLicencia;

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

        public TipoLicencia Convertir(tblTipoLicencia TipoLicenciaContext)
        {
            try
            {
                TipoLicencia objTipoLicencia = new TipoLicencia();
                objTipoLicencia.Id = TipoLicenciaContext.Id;
                objTipoLicencia.Codigo = TipoLicenciaContext.Codigo;
                objTipoLicencia.Nombre = TipoLicenciaContext.Nombre.ToUpper();
                objTipoLicencia.Activo = TipoLicenciaContext.Activo;

                return objTipoLicencia;
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

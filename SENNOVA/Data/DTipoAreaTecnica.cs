using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DTipoAreaTecnica
    {
        private DB_SENNOVAContainer DbContext;

        public DTipoAreaTecnica()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(TipoAreaTecnica objTipoAreaTecnica)
        {
            try
            {
                tblTipoAreaTecnica TipoAreaTecnicaContext = new tblTipoAreaTecnica();
                TipoAreaTecnicaContext.Id = objTipoAreaTecnica.Id;
                TipoAreaTecnicaContext.Codigo = objTipoAreaTecnica.Codigo;
                TipoAreaTecnicaContext.Nombre = objTipoAreaTecnica.Nombre.ToUpper();
                TipoAreaTecnicaContext.Activo = objTipoAreaTecnica.Activo;
                DbContext.tblTipoAreaTecnica.Add(TipoAreaTecnicaContext);
                DbContext.SaveChanges();
                return TipoAreaTecnicaContext.Id;

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

        public int Actualizar(TipoAreaTecnica objTipoAreaTecnica)
        {
            try
            {
                tblTipoAreaTecnica objTipoAreaTecnicaContext = DbContext.tblTipoAreaTecnica.First(v => v.Id == objTipoAreaTecnica.Id);
                objTipoAreaTecnicaContext.Id = objTipoAreaTecnica.Id;
                objTipoAreaTecnicaContext.Codigo = objTipoAreaTecnica.Codigo;
                objTipoAreaTecnicaContext.Nombre = objTipoAreaTecnica.Nombre.ToUpper();
                objTipoAreaTecnicaContext.Activo = objTipoAreaTecnica.Activo;
                DbContext.SaveChanges();
                return objTipoAreaTecnicaContext.Id;
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

        public void Eliminar(TipoAreaTecnica objTipoAreaTecnica)
        {
            try
            {
                var Accion = (from p in DbContext.tblTipoAreaTecnica
                              where p.Id == objTipoAreaTecnica.Id
                              select p).First();

                DbContext.tblTipoAreaTecnica.Remove(Accion);
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

        public List<TipoAreaTecnica> Consultar()
        {
            try
            {
                List<TipoAreaTecnica> lstTipoAreaTecnica = new List<TipoAreaTecnica>();

                var query = from i in DbContext.tblTipoAreaTecnica
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstTipoAreaTecnica.Add(Convertir(item));
                    }
                }

                return lstTipoAreaTecnica;

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

        public Resultado<List<TipoAreaTecnica>> Consultar(int top, int posicion)
        {
            try
            {

                List<TipoAreaTecnica> lstTipoAreaTecnica = new List<TipoAreaTecnica>();
                Resultado<List<TipoAreaTecnica>> resultado = new Resultado<List<TipoAreaTecnica>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblTipoAreaTecnica
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstTipoAreaTecnica.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstTipoAreaTecnica;
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

        public TipoAreaTecnica Consultar(int id)
        {
            try
            {
                TipoAreaTecnica objTipoAreaTecnica = new TipoAreaTecnica();

                var query = (from i in DbContext.tblTipoAreaTecnica
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoAreaTecnica = Convertir(query);
                }
                return objTipoAreaTecnica;

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

        public TipoAreaTecnica Consultar(string codigo)
        {
            try
            {
                TipoAreaTecnica objTipoAreaTecnica = new TipoAreaTecnica();

                var query = (from i in DbContext.tblTipoAreaTecnica
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoAreaTecnica = Convertir(query);
                }
                return objTipoAreaTecnica;

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


        public TipoAreaTecnica Convertir(tblTipoAreaTecnica TipoAreaTecnicaContext)
        {
            try
            {
                TipoAreaTecnica objTipoAreaTecnica = new TipoAreaTecnica();
                objTipoAreaTecnica.Id = TipoAreaTecnicaContext.Id;
                objTipoAreaTecnica.Codigo = TipoAreaTecnicaContext.Codigo;
                objTipoAreaTecnica.Nombre = TipoAreaTecnicaContext.Nombre.ToUpper();
                objTipoAreaTecnica.Activo = TipoAreaTecnicaContext.Activo;

                return objTipoAreaTecnica;
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

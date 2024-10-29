using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DTipoVisitante
    {
        private DB_SENNOVAContainer DbContext;

        public DTipoVisitante()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(TipoVisitante objTipoVisitante)
        {
            try
            {
                tblTipoVisitante TipoVisitanteContext = new tblTipoVisitante();
                TipoVisitanteContext.Id = objTipoVisitante.Id;
                TipoVisitanteContext.Codigo = objTipoVisitante.Codigo;
                TipoVisitanteContext.Nombre = objTipoVisitante.Nombre.ToUpper();
                TipoVisitanteContext.Activo = objTipoVisitante.Activo;
                DbContext.tblTipoVisitante.Add(TipoVisitanteContext);
                DbContext.SaveChanges();
                return TipoVisitanteContext.Id;

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

        public int Actualizar(TipoVisitante objTipoVisitante)
        {
            try
            {
                tblTipoVisitante objTipoVisitanteContext = DbContext.tblTipoVisitante.First(v => v.Id == objTipoVisitante.Id);
                objTipoVisitanteContext.Id = objTipoVisitante.Id;
                objTipoVisitanteContext.Codigo = objTipoVisitante.Codigo;
                objTipoVisitanteContext.Nombre = objTipoVisitante.Nombre.ToUpper();
                objTipoVisitanteContext.Activo = objTipoVisitante.Activo;
                DbContext.SaveChanges();
                return objTipoVisitanteContext.Id;
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

        public void Eliminar(TipoVisitante objTipoVisitante)
        {
            try
            {
                var Accion = (from p in DbContext.tblTipoVisitante
                              where p.Id == objTipoVisitante.Id
                              select p).First();

                DbContext.tblTipoVisitante.Remove(Accion);
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

        public List<TipoVisitante> Consultar()
        {
            try
            {
                List<TipoVisitante> lstTipoVisitante = new List<TipoVisitante>();

                var query = from i in DbContext.tblTipoVisitante
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstTipoVisitante.Add(Convertir(item));
                    }
                }

                return lstTipoVisitante;

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

        public Resultado<List<TipoVisitante>> Consultar(int top, int posicion)
        {
            try
            {

                List<TipoVisitante> lstTipoVisitante = new List<TipoVisitante>();
                Resultado<List<TipoVisitante>> resultado = new Resultado<List<TipoVisitante>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblTipoVisitante
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstTipoVisitante.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstTipoVisitante;
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

        public TipoVisitante Consultar(int id)
        {
            try
            {
                TipoVisitante objTipoVisitante = new TipoVisitante();

                var query = (from i in DbContext.tblTipoVisitante
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoVisitante = Convertir(query);
                }
                return objTipoVisitante;

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

        public TipoVisitante Consultar(string codigo)
        {
            try
            {
                TipoVisitante objTipoVisitante = new TipoVisitante();

                var query = (from i in DbContext.tblTipoVisitante
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoVisitante = Convertir(query);
                }
                return objTipoVisitante;

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


        public TipoVisitante Convertir(tblTipoVisitante TipoVisitanteContext)
        {
            try
            {
                TipoVisitante objTipoVisitante = new TipoVisitante();
                objTipoVisitante.Id = TipoVisitanteContext.Id;
                objTipoVisitante.Codigo = TipoVisitanteContext.Codigo;
                objTipoVisitante.Nombre = TipoVisitanteContext.Nombre.ToUpper();
                objTipoVisitante.Activo = TipoVisitanteContext.Activo;

                return objTipoVisitante;
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

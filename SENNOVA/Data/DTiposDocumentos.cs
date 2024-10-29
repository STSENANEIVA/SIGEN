using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DTiposDocumentos
    {
        private DB_SENNOVAContainer DbContext;

        public DTiposDocumentos()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(TiposDocumentos objTiposDocumentos)
        {
            try
            {
                tblTiposDocumentos TiposDocumentosContext = new tblTiposDocumentos();
                TiposDocumentosContext.Id = objTiposDocumentos.Id;
                TiposDocumentosContext.Codigo = objTiposDocumentos.Codigo;
                TiposDocumentosContext.Nombre = objTiposDocumentos.Nombre.ToUpper();
                TiposDocumentosContext.Activo = objTiposDocumentos.Activo;
                DbContext.tblTiposDocumentos.Add(TiposDocumentosContext);
                DbContext.SaveChanges();
                return TiposDocumentosContext.Id;

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

        public int Actualizar(TiposDocumentos objTiposDocumentos)
        {
            try
            {
                tblTiposDocumentos objTiposDocumentosContext = DbContext.tblTiposDocumentos.First(v => v.Id == objTiposDocumentos.Id);
                objTiposDocumentosContext.Id = objTiposDocumentos.Id;
                objTiposDocumentosContext.Codigo = objTiposDocumentos.Codigo;
                objTiposDocumentosContext.Nombre = objTiposDocumentos.Nombre.ToUpper();
                objTiposDocumentosContext.Activo = objTiposDocumentos.Activo;
                DbContext.SaveChanges();
                return objTiposDocumentosContext.Id;
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

        public void Eliminar(TiposDocumentos objTiposDocumentos)
        {
            try
            {
                var Accion = (from p in DbContext.tblTiposDocumentos
                              where p.Id == objTiposDocumentos.Id
                              select p).First();

                DbContext.tblTiposDocumentos.Remove(Accion);
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

        public List<TiposDocumentos> Consultar()
        {
            try
            {
                List<TiposDocumentos> lstTiposDocumentos = new List<TiposDocumentos>();

                var query = from i in DbContext.tblTiposDocumentos
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstTiposDocumentos.Add(Convertir(item));
                    }
                }

                return lstTiposDocumentos;

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

        public Resultado<List<TiposDocumentos>> Consultar(int top, int posicion)
        {
            try
            {

                List<TiposDocumentos> lstTiposDocumentos = new List<TiposDocumentos>();
                Resultado<List<TiposDocumentos>> resultado = new Resultado<List<TiposDocumentos>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblTiposDocumentos
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstTiposDocumentos.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstTiposDocumentos;
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

        public TiposDocumentos Consultar(int id)
        {
            try
            {
                TiposDocumentos objTiposDocumentos = new TiposDocumentos();

                var query = (from i in DbContext.tblTiposDocumentos
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTiposDocumentos = Convertir(query);
                }
                return objTiposDocumentos;

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

        public TiposDocumentos Consultar(string codigo)
        {
            try
            {
                TiposDocumentos objTiposDocumentos = new TiposDocumentos();

                var query = (from i in DbContext.tblTiposDocumentos
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTiposDocumentos = Convertir(query);
                }
                return objTiposDocumentos;

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


        public TiposDocumentos Convertir(tblTiposDocumentos TiposDocumentosContext)
        {
            try
            {
                TiposDocumentos objTiposDocumentos = new TiposDocumentos();
                objTiposDocumentos.Id = TiposDocumentosContext.Id;
                objTiposDocumentos.Codigo = TiposDocumentosContext.Codigo;
                objTiposDocumentos.Nombre = TiposDocumentosContext.Nombre.ToUpper();
                objTiposDocumentos.Activo = TiposDocumentosContext.Activo;

                return objTiposDocumentos;
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

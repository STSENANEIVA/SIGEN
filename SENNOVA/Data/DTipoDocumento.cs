using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DTipoDocumento
    {
        private DB_SENNOVAContainer DbContext;

        public DTipoDocumento()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(TipoDocumento objTipoDocumento)
        {
            try
            {
                tblTipoDocumento TipoDocumentoContext = new tblTipoDocumento();
                TipoDocumentoContext.Id = objTipoDocumento.Id;
                TipoDocumentoContext.Codigo = objTipoDocumento.Codigo;
                TipoDocumentoContext.Nombre = objTipoDocumento.Nombre.ToUpper();
                TipoDocumentoContext.Activo = objTipoDocumento.Activo;
                DbContext.tblTipoDocumento.Add(TipoDocumentoContext);
                DbContext.SaveChanges();
                return TipoDocumentoContext.Id;

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

        public int Actualizar(TipoDocumento objTipoDocumento)
        {
            try
            {
                tblTipoDocumento objTipoDocumentoContext = DbContext.tblTipoDocumento.First(v => v.Id == objTipoDocumento.Id);
                objTipoDocumentoContext.Id = objTipoDocumento.Id;
                objTipoDocumentoContext.Codigo = objTipoDocumento.Codigo;
                objTipoDocumentoContext.Nombre = objTipoDocumento.Nombre.ToUpper();
                objTipoDocumentoContext.Activo = objTipoDocumento.Activo;
                DbContext.SaveChanges();
                return objTipoDocumentoContext.Id;
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

        public void Eliminar(TipoDocumento objTipoDocumento)
        {
            try
            {
                var Accion = (from p in DbContext.tblTipoDocumento
                              where p.Id == objTipoDocumento.Id
                              select p).First();

                DbContext.tblTipoDocumento.Remove(Accion);
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

        public List<TipoDocumento> Consultar()
        {
            try
            {
                List<TipoDocumento> lstTipoDocumento = new List<TipoDocumento>();

                var query = from i in DbContext.tblTipoDocumento
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstTipoDocumento.Add(Convertir(item));
                    }
                }

                return lstTipoDocumento;

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

        public Resultado<List<TipoDocumento>> Consultar(int top, int posicion)
        {
            try
            {

                List<TipoDocumento> lstTipoDocumento = new List<TipoDocumento>();
                Resultado<List<TipoDocumento>> resultado = new Resultado<List<TipoDocumento>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblTipoDocumento
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstTipoDocumento.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstTipoDocumento;
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

        public TipoDocumento Consultar(int id)
        {
            try
            {
                TipoDocumento objTipoDocumento = new TipoDocumento();

                var query = (from i in DbContext.tblTipoDocumento
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoDocumento = Convertir(query);
                }
                return objTipoDocumento;

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

        public TipoDocumento Consultar(string codigo)
        {
            try
            {
                TipoDocumento objTipoDocumento = new TipoDocumento();

                var query = (from i in DbContext.tblTipoDocumento
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoDocumento = Convertir(query);
                }
                return objTipoDocumento;

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

        public TipoDocumento ConsultarNombre(string nombre)
        {
            try
            {
                TipoDocumento objTipoDocumento = new TipoDocumento();

                var query = (from i in DbContext.tblTipoDocumento
                             where i.Nombre == nombre
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoDocumento = Convertir(query);
                }
                return objTipoDocumento;

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


        public TipoDocumento Convertir(tblTipoDocumento TipoDocumentoContext)
        {
            try
            {
                TipoDocumento objTipoDocumento = new TipoDocumento();
                objTipoDocumento.Id = TipoDocumentoContext.Id;
                objTipoDocumento.Codigo = TipoDocumentoContext.Codigo;
                objTipoDocumento.Nombre = TipoDocumentoContext.Nombre.ToUpper();
                objTipoDocumento.Activo = TipoDocumentoContext.Activo;

                return objTipoDocumento;
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

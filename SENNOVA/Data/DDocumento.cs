using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DDocumento
    {
        private DB_SENNOVAContainer DbContext;

        public DDocumento()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Documento objDocumento)
        {
            try
            {
                tblDocumento DocumentoContext = new tblDocumento();
                DocumentoContext.Id = objDocumento.Id;
                DocumentoContext.Codigo = objDocumento.Codigo;
                DocumentoContext.Nombre = objDocumento.Nombre.ToUpper();
                DocumentoContext.Activo = objDocumento.Activo;
                DocumentoContext.tblProcedimiento = DbContext.tblProcedimiento.Single(i => i.Id == objDocumento.Procedimiento.Id);
                DocumentoContext.tblTiposDocumentos = DbContext.tblTiposDocumentos.Single(i => i.Id == objDocumento.TiposDocumentos.Id);
                DbContext.tblDocumento.Add(DocumentoContext);
                DbContext.SaveChanges();
                return DocumentoContext.Id;

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

        public int Actualizar(Documento objDocumento)
        {
            try
            {
                tblDocumento objDocumentoContext = DbContext.tblDocumento.First(v => v.Id == objDocumento.Id);
                objDocumentoContext.Id = objDocumento.Id;
                objDocumentoContext.Codigo = objDocumento.Codigo;
                objDocumentoContext.Nombre = objDocumento.Nombre.ToUpper();
                objDocumentoContext.Activo = objDocumento.Activo;
                objDocumentoContext.tblProcedimiento = DbContext.tblProcedimiento.Single(i => i.Id == objDocumento.Procedimiento.Id);
                objDocumentoContext.tblTiposDocumentos = DbContext.tblTiposDocumentos.Single(i => i.Id == objDocumento.TiposDocumentos.Id);

                DbContext.SaveChanges();
                return objDocumentoContext.Id;
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

        public void Eliminar(Documento objDocumento)
        {
            try
            {
                var Accion = (from p in DbContext.tblDocumento
                              where p.Id == objDocumento.Id
                              select p).First();

                DbContext.tblDocumento.Remove(Accion);
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

        public Documento ConsultarPorProcedimiento(int id)
        {
            try
            {
                Documento objDocumento = new Documento();

                var query = (from i in DbContext.tblDocumento
                             where i.tblProcedimiento.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objDocumento = Convertir(query);
                }
                return objDocumento;

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

        public Documento ConsultarPorTiposDocumentos(int idTiposDocumentos)
        {
            try
            {
                Documento objDocumento = new Documento();

                var query = (from i in DbContext.tblDocumento
                             where i.tblTiposDocumentos.Id == idTiposDocumentos
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objDocumento = Convertir(query);
                }
                return objDocumento;

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

        public List<Documento> Consultar()
        {
            try
            {
                List<Documento> lstDocumento = new List<Documento>();

                var query = from i in DbContext.tblDocumento
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstDocumento.Add(Convertir(item));
                    }
                }

                return lstDocumento;

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

        public Resultado<List<Documento>> Consultar(int top, int posicion)
        {
            try
            {

                List<Documento> lstDocumento = new List<Documento>();
                Resultado<List<Documento>> resultado = new Resultado<List<Documento>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblDocumento
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstDocumento.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstDocumento;
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

        public Documento Consultar(int id)
        {
            try
            {
                Documento objDocumento = new Documento();

                var query = (from i in DbContext.tblDocumento
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objDocumento = Convertir(query);
                }
                return objDocumento;

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

        public Documento Consultar(string codigo)
        {
            try
            {
                Documento objDocumento = new Documento();

                var query = (from i in DbContext.tblDocumento
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objDocumento = Convertir(query);
                }
                return objDocumento;

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


        public Documento Convertir(tblDocumento DocumentoContext)
        {
            try
            {
                Documento objDocumento = new Documento();
                objDocumento.Id = DocumentoContext.Id;
                objDocumento.Codigo = DocumentoContext.Codigo;
                objDocumento.Nombre = DocumentoContext.Nombre.ToUpper();
                objDocumento.Activo = DocumentoContext.Activo;
                objDocumento.Procedimiento = new Procedimiento()
                {
                    Id = DocumentoContext.tblProcedimiento.Id,
                    Codigo = DocumentoContext.tblProcedimiento.Codigo,
                    Nombre = DocumentoContext.tblProcedimiento.Nombre,
                    Activo = DocumentoContext.tblProcedimiento.Activo,
                };
                objDocumento.TiposDocumentos = new TiposDocumentos()
                {
                    Id = DocumentoContext.tblTiposDocumentos.Id,
                    Codigo = DocumentoContext.tblTiposDocumentos.Codigo,
                    Nombre = DocumentoContext.tblTiposDocumentos.Nombre,
                    Activo = DocumentoContext.tblTiposDocumentos.Activo,
                };
                return objDocumento;
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

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DDetallesDocumento
    {
        private DB_SENNOVAContainer DbContext;

        public DDetallesDocumento()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(DetallesDocumento objDetallesDocumento)
        {
            try
            {
                tblDetallesDocumento DetallesDocumentoContext = new tblDetallesDocumento();
                DetallesDocumentoContext.Id = objDetallesDocumento.Id;
                DetallesDocumentoContext.Version = objDetallesDocumento.Version.ToUpper();
                DetallesDocumentoContext.RutaDoc = objDetallesDocumento.RutaDoc;
                DetallesDocumentoContext.Descargable = objDetallesDocumento.Descargable;
                DetallesDocumentoContext.Fisico = objDetallesDocumento.Fisico;
                DetallesDocumentoContext.Digital = objDetallesDocumento.Digital;
                DetallesDocumentoContext.TipoSolicitud = objDetallesDocumento.TipoSolicitud.ToUpper();
                DetallesDocumentoContext.FechaSolicitud = objDetallesDocumento.FechaSolicitud;
                DetallesDocumentoContext.CopiaControlada = objDetallesDocumento.CopiaControlada;
                DetallesDocumentoContext.FechaCopiaControlada = objDetallesDocumento.FechaCopiaControlada;
                DetallesDocumentoContext.Activo = objDetallesDocumento.Activo;
                DetallesDocumentoContext.tblDocumento = DbContext.tblDocumento.Single(i => i.Id == objDetallesDocumento.Documento.Id);
                DetallesDocumentoContext.tblSolicitante = DbContext.tblEmpleado.Single(i => i.Id == objDetallesDocumento.Solicitante.Id);
                DbContext.tblDetallesDocumento.Add(DetallesDocumentoContext);
                DbContext.SaveChanges();
                return DetallesDocumentoContext.Id;

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

        public int Actualizar(DetallesDocumento objDetallesDocumento)
        {
            try
            {
                tblDetallesDocumento objDetallesDocumentoContext = DbContext.tblDetallesDocumento.First(v => v.Id == objDetallesDocumento.Id);
                objDetallesDocumentoContext.Id = objDetallesDocumento.Id;
                objDetallesDocumentoContext.Version = objDetallesDocumento.Version.ToUpper();
                objDetallesDocumentoContext.RutaDoc = objDetallesDocumento.RutaDoc;
                objDetallesDocumentoContext.Descargable = objDetallesDocumento.Descargable;
                objDetallesDocumentoContext.Fisico = objDetallesDocumento.Fisico;
                objDetallesDocumentoContext.Digital = objDetallesDocumento.Digital;
                objDetallesDocumentoContext.TipoSolicitud = objDetallesDocumento.TipoSolicitud.ToUpper();
                objDetallesDocumentoContext.FechaSolicitud = objDetallesDocumento.FechaSolicitud;
                objDetallesDocumentoContext.FechaRevision = objDetallesDocumento.FechaRevision;
                objDetallesDocumentoContext.FechaAprovacion = objDetallesDocumento.FechaAprovacion;
                objDetallesDocumentoContext.CopiaControlada = objDetallesDocumento.CopiaControlada;
                objDetallesDocumentoContext.FechaCopiaControlada = objDetallesDocumento.FechaCopiaControlada;
                objDetallesDocumentoContext.Activo = objDetallesDocumento.Activo;
                objDetallesDocumentoContext.tblDocumento = DbContext.tblDocumento.Single(i => i.Id == objDetallesDocumento.Documento.Id);
                objDetallesDocumentoContext.tblSolicitante = DbContext.tblEmpleado.Single(i => i.Id == objDetallesDocumento.Solicitante.Id);
                objDetallesDocumentoContext.tblRevisor = DbContext.tblEmpleado.Single(i => i.Id == objDetallesDocumento.Revisor.Id);
                objDetallesDocumentoContext.tblAprovador = DbContext.tblEmpleado.Single(i => i.Id == objDetallesDocumento.Aprovador.Id);
                DbContext.SaveChanges();
                return objDetallesDocumentoContext.Id;
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

        public void Eliminar(DetallesDocumento objDetallesDocumento)
        {
            try
            {
                var Accion = (from p in DbContext.tblDetallesDocumento
                              where p.Id == objDetallesDocumento.Id
                              select p).First();

                DbContext.tblDetallesDocumento.Remove(Accion);
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

        public List<DetallesDocumento> Consultar()
        {
            try
            {
                List<DetallesDocumento> lstDetallesDocumento = new List<DetallesDocumento>();

                var query = from i in DbContext.tblDetallesDocumento
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstDetallesDocumento.Add(Convertir(item));
                    }
                }

                return lstDetallesDocumento;

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

        public DetallesDocumento ConsultarPorDocumento(int idDocumento)
        {
            try
            {
                DetallesDocumento objDetallesDocumento = new DetallesDocumento();

                var query = (from i in DbContext.tblDetallesDocumento
                             where i.tblDocumento.Id == idDocumento
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objDetallesDocumento = Convertir(query);
                }
                return objDetallesDocumento;

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

        public Resultado<List<DetallesDocumento>> Consultar(int top, int posicion)
        {
            try
            {

                List<DetallesDocumento> lstDetallesDocumento = new List<DetallesDocumento>();
                Resultado<List<DetallesDocumento>> resultado = new Resultado<List<DetallesDocumento>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblDetallesDocumento
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstDetallesDocumento.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstDetallesDocumento;
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

        public DetallesDocumento Consultar(int id)
        {
            try
            {
                DetallesDocumento objDetallesDocumento = new DetallesDocumento();

                var query = (from i in DbContext.tblDetallesDocumento
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objDetallesDocumento = Convertir(query);
                }
                return objDetallesDocumento;

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

        public DetallesDocumento Consultar(string version, int idDocumento)
        {
            try
            {
                DetallesDocumento objDetallesDocumento = new DetallesDocumento();

                var query = (from i in DbContext.tblDetallesDocumento
                             where i.Version == version && i.tblDocumento.Id == idDocumento
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objDetallesDocumento = Convertir(query);
                }
                return objDetallesDocumento;

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


        public DetallesDocumento Convertir(tblDetallesDocumento DetallesDocumentoContext)
        {
            try
            {
                DetallesDocumento objDetallesDocumento = new DetallesDocumento();
                objDetallesDocumento.Id = DetallesDocumentoContext.Id;
                objDetallesDocumento.Version = DetallesDocumentoContext.Version;
                objDetallesDocumento.RutaDoc = DetallesDocumentoContext.RutaDoc;
                objDetallesDocumento.Descargable = DetallesDocumentoContext.Descargable;
                objDetallesDocumento.Fisico = DetallesDocumentoContext.Fisico;
                objDetallesDocumento.Digital = DetallesDocumentoContext.Digital;
                objDetallesDocumento.TipoSolicitud = DetallesDocumentoContext.TipoSolicitud;
                objDetallesDocumento.FechaSolicitud = DetallesDocumentoContext.FechaSolicitud;
                objDetallesDocumento.FechaRevision = (DateTime)DetallesDocumentoContext.FechaRevision;
                objDetallesDocumento.FechaAprovacion = (DateTime)DetallesDocumentoContext.FechaAprovacion;
                objDetallesDocumento.CopiaControlada = DetallesDocumentoContext.CopiaControlada;
                objDetallesDocumento.FechaCopiaControlada = (DateTime)DetallesDocumentoContext.FechaCopiaControlada;
                objDetallesDocumento.Activo = DetallesDocumentoContext.Activo;

                objDetallesDocumento.Documento = new Documento()
                {
                    Id = DetallesDocumentoContext.tblDocumento.Id,
                    Codigo = DetallesDocumentoContext.tblDocumento.Codigo,
                    Nombre = DetallesDocumentoContext.tblDocumento.Nombre,
                    Activo = DetallesDocumentoContext.tblDocumento.Activo,
                };
                objDetallesDocumento.Solicitante = new Empleado()
                {
                    Id = DetallesDocumentoContext.tblSolicitante.Id,
                    NombreCompleto = DetallesDocumentoContext.tblSolicitante.tblPersona.Nombres + " " + DetallesDocumentoContext.tblSolicitante.tblPersona.Apellidos,
                };
                if (objDetallesDocumento.Revisor != null)
                {
                    objDetallesDocumento.Revisor = new Empleado()
                    {
                        Id = DetallesDocumentoContext.tblRevisor.Id,
                        NombreCompleto = DetallesDocumentoContext.tblRevisor.tblPersona.Nombres + " " + DetallesDocumentoContext.tblRevisor.tblPersona.Apellidos,
                    };
                }
                if (objDetallesDocumento.Aprovador != null)
                {
                    objDetallesDocumento.Aprovador = new Empleado()
                    {
                        Id = DetallesDocumentoContext.tblAprovador.Id,
                        NombreCompleto = DetallesDocumentoContext.tblAprovador.tblPersona.Nombres + " " + DetallesDocumentoContext.tblAprovador.tblPersona.Apellidos,
                    };
                }

                return objDetallesDocumento;
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

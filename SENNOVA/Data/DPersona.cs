using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DPersona
    {
        private DB_SENNOVAContainer DbContext;

        public DPersona()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Persona objPersona)
        {
            try
            {
                tblPersona PersonaContext = new tblPersona();
                PersonaContext.Id = objPersona.Id;
                PersonaContext.Codigo = objPersona.Codigo;
                PersonaContext.Nombres = objPersona.Nombres.ToUpper();
                PersonaContext.Apellidos = objPersona.Apellidos.ToUpper();
                PersonaContext.NumeroIdentificacion = objPersona.NumeroIdentificacion;
                PersonaContext.Telefono = objPersona.Telefono;
                PersonaContext.Email = objPersona.Email;
                PersonaContext.tblTipoDocumento = DbContext.tblTipoDocumento.Single(i => i.Id == objPersona.TipoDocumento.Id);
                DbContext.tblPersona.Add(PersonaContext);
                DbContext.SaveChanges();
                return PersonaContext.Id;

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

        public int Actualizar(Persona objPersona)
        {
            try
            {
                tblPersona objPersonaContext = DbContext.tblPersona.First(v => v.Id == objPersona.Id);
                objPersonaContext.Id = objPersona.Id;
                objPersonaContext.Codigo = objPersona.Codigo;
                objPersonaContext.Nombres = objPersona.Nombres.ToUpper();
                objPersonaContext.Apellidos = objPersona.Apellidos.ToUpper();
                objPersonaContext.NumeroIdentificacion = objPersona.NumeroIdentificacion;
                objPersonaContext.Telefono = objPersona.Telefono;
                objPersonaContext.Email = objPersona.Email;
                objPersonaContext.tblTipoDocumento = DbContext.tblTipoDocumento.Single(i => i.Id == objPersona.TipoDocumento.Id);
                DbContext.SaveChanges();
                return objPersonaContext.Id;
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

        public Persona ConsultarPorTipoNumero(int idTipoDocumento, string numeroIdentificacion)
        {
            try
            {
                Persona objPersona = new Persona();

                var query = (from i in DbContext.tblPersona
                             where i.tblTipoDocumento.Id == idTipoDocumento && i.NumeroIdentificacion == numeroIdentificacion
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objPersona = Convertir(query);
                }
                return objPersona;

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

       public void Eliminar(Persona objPersona)
        {
            try
            {
                var Accion = (from p in DbContext.tblPersona
                              where p.Id == objPersona.Id
                              select p).First();

                DbContext.tblPersona.Remove(Accion);
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

        public List<Persona> Consultar()
        {
            try
            {
                List<Persona> lstPersona = new List<Persona>();

                var query = from i in DbContext.tblPersona
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstPersona.Add(Convertir(item));
                    }
                }

                return lstPersona;

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

        public Resultado<List<Persona>> Consultar(int top, int posicion)
        {
            try
            {

                List<Persona> lstPersona = new List<Persona>();
                Resultado<List<Persona>> resultado = new Resultado<List<Persona>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblPersona
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstPersona.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstPersona;
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

        public Persona ConsultarPorTipoDocumento(int id)
        {
            try
            {
                Persona objPersona = new Persona();

                var query = (from i in DbContext.tblPersona
                             where i.tblTipoDocumento.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objPersona = Convertir(query);
                }
                return objPersona;

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

        public Persona Consultar(int id)
        {
            try
            {
                Persona objPersona = new Persona();

                var query = (from i in DbContext.tblPersona
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objPersona = Convertir(query);
                }
                return objPersona;

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

        public Persona ConsultarUltimoRegistro()
        {
            try
            {
                Persona objPersona = new Persona();

                var query = (from i in DbContext.tblPersona
                             select i).OrderByDescending(x => x.Id).FirstOrDefault();

                if (query != null)
                {
                    objPersona = Convertir(query);
                }
                return objPersona;

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

        public Persona Consultar(string codigo)
        {
            try
            {
                Persona objPersona = new Persona();

                var query = (from i in DbContext.tblPersona
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objPersona = Convertir(query);
                }
                return objPersona;

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


        public Persona Convertir(tblPersona PersonaContext)
        {
            try
            {
                Persona objPersona = new Persona();
                objPersona.Id = PersonaContext.Id;
                objPersona.Codigo = PersonaContext.Codigo;
                objPersona.Nombres = PersonaContext.Nombres.ToUpper();
                objPersona.Apellidos = PersonaContext.Apellidos.ToUpper();
                objPersona.NumeroIdentificacion = PersonaContext.NumeroIdentificacion;
                objPersona.Telefono = PersonaContext.Telefono;
                objPersona.Email = PersonaContext.Email;
                objPersona.NombreCompleto = PersonaContext.Nombres + " " + PersonaContext.Apellidos;
                objPersona.TipoDocumento = new TipoDocumento()
                {
                    Id = PersonaContext.tblTipoDocumento.Id,
                    Codigo = PersonaContext.tblTipoDocumento.Codigo,
                    Nombre = PersonaContext.tblTipoDocumento.Nombre,
                    Activo = PersonaContext.tblTipoDocumento.Activo,
                };
               
                return objPersona;
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

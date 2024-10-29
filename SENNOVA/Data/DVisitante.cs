using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DVisitante
    {
        private DB_SENNOVAContainer DbContext;

        public DVisitante()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Visitante objVisitante)
        {
            try
            {
                tblVisitante VisitanteContext = new tblVisitante();
                VisitanteContext.Id = objVisitante.Id;
                VisitanteContext.tblPersona = DbContext.tblPersona.Single(i => i.Id == objVisitante.Persona.Id);
                VisitanteContext.tblTipoVisitante = DbContext.tblTipoVisitante.Single(i => i.Id == objVisitante.TipoVisitante.Id);
                DbContext.tblVisitante.Add(VisitanteContext);
                DbContext.SaveChanges();
                return VisitanteContext.Id;

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

        public int Actualizar(Visitante objVisitante)
        {
            try
            {
                tblVisitante objVisitanteContext = DbContext.tblVisitante.First(v => v.Id == objVisitante.Id);
                objVisitanteContext.Id = objVisitante.Id;
                objVisitanteContext.tblPersona = DbContext.tblPersona.Single(i => i.Id == objVisitante.Persona.Id);
                objVisitanteContext.tblTipoVisitante = DbContext.tblTipoVisitante.Single(i => i.Id == objVisitante.TipoVisitante.Id);

                DbContext.SaveChanges();
                return objVisitanteContext.Id;
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

        public void Eliminar(Visitante objVisitante)
        {
            try
            {
                var Accion = (from p in DbContext.tblVisitante
                              where p.Id == objVisitante.Id
                              select p).First();

                DbContext.tblVisitante.Remove(Accion);
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

        public Visitante ConsultarPorPersona(int id)
        {
            try
            {
                Visitante objVisitante = new Visitante();

                var query = (from i in DbContext.tblVisitante
                             where i.tblPersona.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objVisitante = Convertir(query);
                }
                return objVisitante;

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

        public Visitante ConsultarPorTipoVisitante(int idTipoVisitante)
        {
            try
            {
                Visitante objVisitante = new Visitante();

                var query = (from i in DbContext.tblVisitante
                             where i.tblTipoVisitante.Id == idTipoVisitante
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objVisitante = Convertir(query);
                }
                return objVisitante;

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

        public List<Visitante> Consultar()
        {
            try
            {
                List<Visitante> lstVisitante = new List<Visitante>();

                var query = from i in DbContext.tblVisitante
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstVisitante.Add(Convertir(item));
                    }
                }

                return lstVisitante;

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

        public Resultado<List<Visitante>> Consultar(int top, int posicion)
        {
            try
            {

                List<Visitante> lstVisitante = new List<Visitante>();
                Resultado<List<Visitante>> resultado = new Resultado<List<Visitante>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblVisitante
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstVisitante.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstVisitante;
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

        public Visitante Consultar(int id)
        {
            try
            {
                Visitante objVisitante = new Visitante();

                var query = (from i in DbContext.tblVisitante
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objVisitante = Convertir(query);
                }
                return objVisitante;

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


        public Visitante Convertir(tblVisitante VisitanteContext)
        {
            try
            {
                Visitante objVisitante = new Visitante();
                objVisitante.Id = VisitanteContext.Id;
                objVisitante.Persona = new Persona()
                {
                    Id = VisitanteContext.tblPersona.Id,
                    Codigo = VisitanteContext.tblPersona.Codigo,
                    NombreCompleto = VisitanteContext.tblPersona.Nombres + " " + VisitanteContext.tblPersona.Apellidos,
                    Email = VisitanteContext.tblPersona.Email,
                };
                return objVisitante;
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

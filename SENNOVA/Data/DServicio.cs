using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DServicio
    {
        private DB_SENNOVAContainer DbContext;

        public DServicio()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Servicio objServicio)
        {
            try
            {
                tblServicio ServicioContext = new tblServicio();
                ServicioContext.Id = objServicio.Id;
                ServicioContext.Codigo = objServicio.Codigo;
                ServicioContext.Nombre = objServicio.Nombre.ToUpper();
                ServicioContext.Requisitos = objServicio.Requisitos.ToUpper();
                ServicioContext.Alcance = objServicio.Alcance.ToUpper();
                ServicioContext.Valor = objServicio.Valor;
                ServicioContext.Activo = objServicio.Activo;
                ServicioContext.tblAreaTecnica = DbContext.tblAreaTecnica.Single(i => i.Id == objServicio.AreaTecnica.Id);
                ServicioContext.tblFamilia = DbContext.tblFamilia.Single(i => i.Id == objServicio.Familia.Id);
                DbContext.tblServicio.Add(ServicioContext);
                DbContext.SaveChanges();
                return ServicioContext.Id;

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

        public int Actualizar(Servicio objServicio)
        {
            try
            {
                tblServicio objServicioContext = DbContext.tblServicio.First(v => v.Id == objServicio.Id);
                objServicioContext.Id = objServicio.Id;
                objServicioContext.Codigo = objServicio.Codigo;
                objServicioContext.Nombre = objServicio.Nombre.ToUpper();
                objServicioContext.Requisitos = objServicio.Requisitos.ToUpper();
                objServicioContext.Alcance = objServicio.Alcance.ToUpper();
                objServicioContext.Valor = objServicio.Valor;
                objServicioContext.Activo = objServicio.Activo;
                objServicioContext.tblAreaTecnica = DbContext.tblAreaTecnica.Single(i => i.Id == objServicio.AreaTecnica.Id);
                objServicioContext.tblFamilia = DbContext.tblFamilia.Single(i => i.Id == objServicio.Familia.Id);
                DbContext.SaveChanges();
                return objServicioContext.Id;
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

        public void Eliminar(Servicio objServicio)
        {
            try
            {
                var Accion = (from p in DbContext.tblServicio
                              where p.Id == objServicio.Id
                              select p).First();

                DbContext.tblServicio.Remove(Accion);
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

        public List<Servicio> Consultar()
        {
            try
            {
                List<Servicio> lstServicio = new List<Servicio>();

                var query = from i in DbContext.tblServicio
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstServicio.Add(Convertir(item));
                    }
                }

                return lstServicio;

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

        public List<Servicio> ConsultarAreaTecnicaId(int idAreaTecnica)
        {
            try
            {
                List<Servicio> lstServicio = new List<Servicio>();

                var query = from i in DbContext.tblServicio
                            where i.tblAreaTecnica.Id == idAreaTecnica
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstServicio.Add(Convertir(item));
                    }
                }

                return lstServicio;

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
        public Servicio ConsultarAreaTecnica(int idAreaTecnica)
        {
            try
            {
                Servicio objServicio = new Servicio();

                var query = (from i in DbContext.tblServicio
                            where i.tblAreaTecnica.Id == idAreaTecnica
                            select i).FirstOrDefault(); ;

                if (query != null)
                {
                    objServicio = Convertir(query);
                }
                return objServicio;

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

        public Servicio ConsultarFamilia(int idFamilia)
        {
            try
            {
                Servicio objServicio = new Servicio();

                var query = (from i in DbContext.tblServicio
                             where i.tblFamilia.Id == idFamilia
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objServicio = Convertir(query);
                }
                return objServicio;

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


        public Resultado<List<Servicio>> Consultar(int top, int posicion)
        {
            try
            {

                List<Servicio> lstServicio = new List<Servicio>();
                Resultado<List<Servicio>> resultado = new Resultado<List<Servicio>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblServicio
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstServicio.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstServicio;
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

        public Servicio Consultar(int id)
        {
            try
            {
                Servicio objServicio = new Servicio();

                var query = (from i in DbContext.tblServicio
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objServicio = Convertir(query);
                }
                return objServicio;

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

        public Servicio Consultar(string codigo)
        {
            try
            {
                Servicio objServicio = new Servicio();

                var query = (from i in DbContext.tblServicio
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objServicio = Convertir(query);
                }
                return objServicio;

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

        public Servicio Convertir(tblServicio ServicioContext)
        {
            try
            {
                Servicio objServicio = new Servicio();
                objServicio.Id = ServicioContext.Id;
                objServicio.Codigo = ServicioContext.Codigo;
                objServicio.Nombre = ServicioContext.Nombre.ToUpper();
                objServicio.Requisitos = ServicioContext.Requisitos.ToUpper();
                objServicio.Alcance = ServicioContext.Alcance.ToUpper();
                objServicio.Valor = ServicioContext.Valor;
                objServicio.Activo = ServicioContext.Activo;

                objServicio.AreaTecnica = new AreaTecnica()
                {
                    Id = ServicioContext.tblAreaTecnica.Id,
                    Codigo = ServicioContext.tblAreaTecnica.Codigo,
                    NombreSin = ServicioContext.tblAreaTecnica.Nombre,
                    Activo = ServicioContext.tblAreaTecnica.Activo,
                };

                objServicio.Familia = new Familia()
                {
                    Id = ServicioContext.tblFamilia.Id,
                    Codigo = ServicioContext.tblFamilia.Codigo,
                    Nombre = ServicioContext.tblFamilia.Nombre,
                    Activo = ServicioContext.tblFamilia.Activo,
                };

                return objServicio;
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

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DAreaTecnica
    {
        private DB_SENNOVAContainer DbContext;

        public DAreaTecnica()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(AreaTecnica objAreaTecnica)
        {
            try
            {
                tblAreaTecnica AreaTecnicaContext = new tblAreaTecnica();
                AreaTecnicaContext.Id = objAreaTecnica.Id;
                AreaTecnicaContext.Codigo = objAreaTecnica.Codigo;
                AreaTecnicaContext.Nombre = objAreaTecnica.Nombre.ToUpper();
                AreaTecnicaContext.Activo = objAreaTecnica.Activo;
                AreaTecnicaContext.tblTipoAreaTecnica = DbContext.tblTipoAreaTecnica.Single(i => i.Id == objAreaTecnica.TipoAreaTecnica.Id);
                AreaTecnicaContext.tblEmpleado = DbContext.tblEmpleado.Single(i => i.Id == objAreaTecnica.Empleado.Id);
                DbContext.tblAreaTecnica.Add(AreaTecnicaContext);
                DbContext.SaveChanges();
                return AreaTecnicaContext.Id;

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

        public int Actualizar(AreaTecnica objAreaTecnica)
        {
            try
            {
                tblAreaTecnica objAreaTecnicaContext = DbContext.tblAreaTecnica.First(v => v.Id == objAreaTecnica.Id);
                objAreaTecnicaContext.Id = objAreaTecnica.Id;
                objAreaTecnicaContext.Codigo = objAreaTecnica.Codigo;
                objAreaTecnicaContext.Nombre = objAreaTecnica.Nombre.ToUpper();
                objAreaTecnicaContext.Activo = objAreaTecnica.Activo;
                objAreaTecnicaContext.tblTipoAreaTecnica = DbContext.tblTipoAreaTecnica.Single(i => i.Id == objAreaTecnica.TipoAreaTecnica.Id);
                objAreaTecnicaContext.tblEmpleado = DbContext.tblEmpleado.Single(i => i.Id == objAreaTecnica.Empleado.Id);
                DbContext.SaveChanges();
                return objAreaTecnicaContext.Id;
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

        public void Eliminar(AreaTecnica objAreaTecnica)
        {
            try
            {
                var Accion = (from p in DbContext.tblAreaTecnica
                              where p.Id == objAreaTecnica.Id
                              select p).First();

                DbContext.tblAreaTecnica.Remove(Accion);
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

        public List<AreaTecnica> Consultar()
        {
            try
            {
                List<AreaTecnica> lstAreaTecnica = new List<AreaTecnica>();

                var query = from i in DbContext.tblAreaTecnica
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstAreaTecnica.Add(Convertir(item));
                    }
                }

                return lstAreaTecnica;

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


        public List<AreaTecnica> ConsultarTipoAreaTecnica(int idTipoAreaTecnica)
        {
            try
            {
                List<AreaTecnica> lstAreaTecnica = new List<AreaTecnica>();

                var query = from i in DbContext.tblAreaTecnica
                            where i.tblTipoAreaTecnica.Id == idTipoAreaTecnica
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstAreaTecnica.Add(Convertir(item));
                    }
                }

                return lstAreaTecnica;

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


        public Resultado<List<AreaTecnica>> Consultar(int top, int posicion)
        {
            try
            {

                List<AreaTecnica> lstAreaTecnica = new List<AreaTecnica>();
                Resultado<List<AreaTecnica>> resultado = new Resultado<List<AreaTecnica>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblAreaTecnica
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstAreaTecnica.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstAreaTecnica;
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

        public AreaTecnica Consultar(int id)
        {
            try
            {
                AreaTecnica objAreaTecnica = new AreaTecnica();

                var query = (from i in DbContext.tblAreaTecnica
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objAreaTecnica = Convertir(query);
                }
                return objAreaTecnica;

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

        public AreaTecnica Consultar(string codigo)
        {
            try
            {
                AreaTecnica objAreaTecnica = new AreaTecnica();

                var query = (from i in DbContext.tblAreaTecnica
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objAreaTecnica = Convertir(query);
                }
                return objAreaTecnica;

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

        public AreaTecnica ConsultarNombre(string nombre)
        {
            try
            {
                AreaTecnica objAreaTecnica = new AreaTecnica();

                var query = (from i in DbContext.tblAreaTecnica
                             where i.Nombre == nombre.Trim()
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objAreaTecnica = Convertir(query);
                }
                return objAreaTecnica;

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


        public AreaTecnica Convertir(tblAreaTecnica AreaTecnicaContext)
        {
            try
            {
                AreaTecnica objAreaTecnica = new AreaTecnica();
                objAreaTecnica.Id = AreaTecnicaContext.Id;
                objAreaTecnica.Codigo = AreaTecnicaContext.Codigo;
                objAreaTecnica.Nombre = " &nbsp;" + AreaTecnicaContext.Nombre.ToUpper();
                objAreaTecnica.NombreSin = AreaTecnicaContext.Nombre.ToUpper();
                objAreaTecnica.Activo = AreaTecnicaContext.Activo;
                objAreaTecnica.TipoAreaTecnica = new TipoAreaTecnica()
                {
                    Id = AreaTecnicaContext.tblTipoAreaTecnica.Id,
                    Codigo = AreaTecnicaContext.tblTipoAreaTecnica.Codigo,
                    Nombre = AreaTecnicaContext.tblTipoAreaTecnica.Nombre,
                    Activo = AreaTecnicaContext.tblTipoAreaTecnica.Activo,
                };
                objAreaTecnica.Empleado = new Empleado()
                {
                    Id = AreaTecnicaContext.tblTipoAreaTecnica.Id,
                    NombreCompleto = AreaTecnicaContext.tblEmpleado.tblPersona.Nombres + " " + AreaTecnicaContext.tblEmpleado.tblPersona.Apellidos,
                };
                return objAreaTecnica;
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

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DEmpleado
    {
        private DB_SENNOVAContainer DbContext;

        public DEmpleado()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Empleado objEmpleado)
        {
            try
            {
                tblEmpleado EmpleadoContext = new tblEmpleado();
                EmpleadoContext.EmailLaboral = objEmpleado.EmailLaboral;
                EmpleadoContext.Telefono = objEmpleado.Telefono;
                EmpleadoContext.Ip = objEmpleado.Ip;

                if (objEmpleado.RolSennova.Id != 0)
                {
                    EmpleadoContext.tblRolSennova = DbContext.tblRolSennova.Single(i => i.Id == objEmpleado.RolSennova.Id); 
                }
                if (objEmpleado.Cargo.Id != 0)
                {
                    EmpleadoContext.tblCargo = DbContext.tblCargo.Single(i => i.Id == objEmpleado.Cargo.Id);
                }
                EmpleadoContext.tblPersona = DbContext.tblPersona.Single(i => i.Id == objEmpleado.Persona.Id);
                DbContext.tblEmpleado.Add(EmpleadoContext);
                DbContext.SaveChanges();
                return EmpleadoContext.Id;

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

        public int Actualizar(Empleado objEmpleado)
        {
            try
            {
                tblEmpleado objEmpleadoContext = DbContext.tblEmpleado.First(v => v.Id == objEmpleado.Id);
                objEmpleadoContext.Id = objEmpleado.Id;
                objEmpleadoContext.EmailLaboral = objEmpleado.EmailLaboral;
                objEmpleadoContext.Telefono = objEmpleado.Telefono;
                objEmpleadoContext.Ip = objEmpleado.Ip;

                if (objEmpleado.Cargo.Id != 0)
                {
                    objEmpleadoContext.tblCargo = DbContext.tblCargo.Single(i => i.Id == objEmpleado.Cargo.Id);
                }
                if (objEmpleado.RolSennova.Id != 0)
                {
                    objEmpleadoContext.tblRolSennova = DbContext.tblRolSennova.Single(i => i.Id == objEmpleado.RolSennova.Id); 
                }
                objEmpleadoContext.tblPersona = DbContext.tblPersona.Single(i => i.Id == objEmpleado.Persona.Id);
                DbContext.SaveChanges();
                return objEmpleadoContext.Id;
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

        public Empleado ConsultarPorEmailLaboral(string emailLaboral)
        {
            try
            {
                Empleado objEmpleado = new Empleado();

                var query = (from i in DbContext.tblEmpleado
                             where i.EmailLaboral.ToUpper().Trim() == emailLaboral.ToUpper().Trim()
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEmpleado = Convertir(query);
                }
                return objEmpleado;

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

        public void Eliminar(Empleado objEmpleado)
        {
            try
            {
                var Accion = (from p in DbContext.tblEmpleado
                              where p.Id == objEmpleado.Id
                              select p).First();

                DbContext.tblEmpleado.Remove(Accion);
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

        public Empleado ConsultarPorPersona(int idPersona)
        {
            try
            {
                Empleado objEmpleado = new Empleado();

                var query = (from i in DbContext.tblEmpleado
                             where i.tblPersona.Id == idPersona
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEmpleado = Convertir(query);
                }
                return objEmpleado;

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

        public Empleado ConsultarPorCargo(int idCargo)
        {
            try
            {
                Empleado objEmpleado = new Empleado();

                var query = (from i in DbContext.tblEmpleado
                             where i.tblCargo.Id == idCargo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEmpleado = Convertir(query);
                }
                return objEmpleado;

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

        public Empleado ConsultarPorIdPersona(int idPersona)
        {
            try
            {
                Empleado objEmpleado = new Empleado();

                var query = (from i in DbContext.tblEmpleado
                             where i.tblPersona.Id == idPersona
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEmpleado = Convertir(query);
                }
                return objEmpleado;

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

        public List<Empleado> Consultar()
        {
            try
            {
                List<Empleado> lstEmpleado = new List<Empleado>();

                var query = from i in DbContext.tblEmpleado
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstEmpleado.Add(Convertir(item));
                    }
                }

                return lstEmpleado;

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

        public Resultado<List<Empleado>> Consultar(int top, int posicion)
        {
            try
            {

                List<Empleado> lstEmpleado = new List<Empleado>();
                Resultado<List<Empleado>> resultado = new Resultado<List<Empleado>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblEmpleado
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstEmpleado.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstEmpleado;
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

        public Empleado ConsultarPorRolSennova(int id)
        {
            try
            {
                Empleado objEmpleado = new Empleado();

                var query = (from i in DbContext.tblEmpleado
                             where i.tblRolSennova.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEmpleado = Convertir(query);
                }
                return objEmpleado;

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

        public Empleado Consultar(int id)
        {
            try
            {
                Empleado objEmpleado = new Empleado();

                var query = (from i in DbContext.tblEmpleado
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEmpleado = Convertir(query);
                }
                return objEmpleado;

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

        public Empleado Consultar(string emailLaboral)
        {
            try
            {
                Empleado objEmpleado = new Empleado();

                var query = (from i in DbContext.tblEmpleado
                             where i.EmailLaboral == emailLaboral
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEmpleado = Convertir(query);
                }
                return objEmpleado;

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

        public Empleado Convertir(tblEmpleado EmpleadoContext)
        {
            try
            {
                Empleado objEmpleado = new Empleado();
                objEmpleado.Id = EmpleadoContext.Id;
                objEmpleado.EmailLaboral = EmpleadoContext.EmailLaboral;
                objEmpleado.Telefono = EmpleadoContext.Telefono;
                objEmpleado.Ip = EmpleadoContext.Ip;

                if (EmpleadoContext.tblRolSennova != null)
                {
                    objEmpleado.RolSennova = new RolSennova()
                    {
                        Id = EmpleadoContext.tblRolSennova.Id,
                        Codigo = EmpleadoContext.tblRolSennova.Codigo,
                        Nombre = EmpleadoContext.tblRolSennova.Nombre,
                        Activo = EmpleadoContext.tblRolSennova.Activo,
                    }; 
                }
                if (EmpleadoContext.tblCargo != null)
                {
                    objEmpleado.Cargo = new Cargo()
                    {
                        Id = EmpleadoContext.tblCargo.Id,
                        Codigo = EmpleadoContext.tblCargo.Codigo,
                        Nombre = EmpleadoContext.tblCargo.Nombre,
                        Activo = EmpleadoContext.tblCargo.Activo,
                    };
                }
                objEmpleado.Persona = new Persona()
                {
                    Id = EmpleadoContext.tblPersona.Id,
                    Nombres = EmpleadoContext.tblPersona.Nombres,
                    Apellidos = EmpleadoContext.tblPersona.Apellidos,
                    NumeroIdentificacion = EmpleadoContext.tblPersona.NumeroIdentificacion,
                    Telefono = EmpleadoContext.tblPersona.Telefono,
                    Email = EmpleadoContext.tblPersona.Email,
                    TipoDocumento = new TipoDocumento()
                    {
                        Id = EmpleadoContext.tblPersona.tblTipoDocumento.Id,
                        Codigo = EmpleadoContext.tblPersona.tblTipoDocumento.Codigo,
                        Nombre = EmpleadoContext.tblPersona.tblTipoDocumento.Nombre,
                        Activo = EmpleadoContext.tblPersona.tblTipoDocumento.Activo,
                    }
                };

                objEmpleado.NombreCompleto = EmpleadoContext.tblPersona.Nombres + " " + EmpleadoContext.tblPersona.Apellidos;

                return objEmpleado;
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

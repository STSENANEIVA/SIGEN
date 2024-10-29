using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DIngreso
    {
        private DB_SENNOVAContainer DbContext;

        public DIngreso()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Ingreso objIngreso)
        {
            try
            {
                tblIngreso IngresoContext = new tblIngreso();
                IngresoContext.Id = objIngreso.Id;
                IngresoContext.Fecha = objIngreso.Fecha;
                IngresoContext.PoliticaDatos = objIngreso.PoliticaDatos;
                IngresoContext.Ficha = objIngreso.Ficha;
                IngresoContext.tblVisitante = DbContext.tblVisitante.Single(i => i.Id == objIngreso.Visitante.Id);
                IngresoContext.tblEmpresa = DbContext.tblEmpresa.Single(i => i.Id == objIngreso.Empresa.Id);
                IngresoContext.tblEmpleado = DbContext.tblEmpleado.Single(i => i.Id == objIngreso.Empleado.Id);
                if (objIngreso.ProgramaFormacion != null)
                {
                    IngresoContext.tblProgramaFormacion = DbContext.tblProgramaFormacion.Single(i => i.Id == objIngreso.ProgramaFormacion.Id);
                }
                DbContext.tblIngreso.Add(IngresoContext);
                DbContext.SaveChanges();
                return IngresoContext.Id;

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

        public int Actualizar(Ingreso objIngreso)
        {
            try
            {
                tblIngreso objIngresoContext = DbContext.tblIngreso.First(v => v.Id == objIngreso.Id);
                objIngresoContext.Id = objIngreso.Id;
                objIngresoContext.Fecha = objIngreso.Fecha;
                objIngresoContext.PoliticaDatos = objIngreso.PoliticaDatos;
                objIngresoContext.Ficha = objIngreso.Ficha;
                objIngresoContext.tblVisitante = DbContext.tblVisitante.Single(i => i.Id == objIngreso.Visitante.Id);
                objIngresoContext.tblEmpresa = DbContext.tblEmpresa.Single(i => i.Id == objIngreso.Empresa.Id);
                objIngresoContext.tblEmpleado = DbContext.tblEmpleado.Single(i => i.Id == objIngreso.Empleado.Id);
                objIngresoContext.tblProgramaFormacion = DbContext.tblProgramaFormacion.Single(i => i.Id == objIngreso.ProgramaFormacion.Id);

                DbContext.SaveChanges();
                return objIngresoContext.Id;
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

        public void Eliminar(Ingreso objIngreso)
        {
            try
            {
                var Accion = (from p in DbContext.tblIngreso
                              where p.Id == objIngreso.Id
                              select p).First();

                DbContext.tblIngreso.Remove(Accion);
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

        public Ingreso ConsultarPorVisitante(int id)
        {
            try
            {
                Ingreso objIngreso = new Ingreso();

                var query = (from i in DbContext.tblIngreso
                             where i.tblVisitante.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objIngreso = Convertir(query);
                }
                return objIngreso;

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

        public Ingreso ConsultarPorEmpresa(int idEmpresa)
        {
            try
            {
                Ingreso objIngreso = new Ingreso();

                var query = (from i in DbContext.tblIngreso
                             where i.tblEmpresa.Id == idEmpresa
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objIngreso = Convertir(query);
                }
                return objIngreso;

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

        public Ingreso ConsultarPorProgramaFormacion(int idProgramaFormacion)
        {
            try
            {
                Ingreso objIngreso = new Ingreso();

                var query = (from i in DbContext.tblIngreso
                             where i.tblProgramaFormacion.Id == idProgramaFormacion
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objIngreso = Convertir(query);
                }
                return objIngreso;

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

        public List<Ingreso> Consultar()
        {
            try
            {
                List<Ingreso> lstIngreso = new List<Ingreso>();

                var query = from i in DbContext.tblIngreso
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstIngreso.Add(Convertir(item));
                    }
                }

                return lstIngreso;

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

        public Resultado<List<Ingreso>> Consultar(int top, int posicion)
        {
            try
            {

                List<Ingreso> lstIngreso = new List<Ingreso>();
                Resultado<List<Ingreso>> resultado = new Resultado<List<Ingreso>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblIngreso
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstIngreso.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstIngreso;
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

        public Ingreso Consultar(int id)
        {
            try
            {
                Ingreso objIngreso = new Ingreso();

                var query = (from i in DbContext.tblIngreso
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objIngreso = Convertir(query);
                }
                return objIngreso;

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

        public Ingreso Convertir(tblIngreso IngresoContext)
        {
            try
            {
                Ingreso objIngreso = new Ingreso();
                objIngreso.Id = IngresoContext.Id;
                objIngreso.Fecha = IngresoContext.Fecha;
                objIngreso.PoliticaDatos = (bool)IngresoContext.PoliticaDatos;
                objIngreso.Ficha = IngresoContext.Ficha;
                objIngreso.Visitante = new Visitante()
                {
                    Id = IngresoContext.tblVisitante.Id,
                    Persona = new Persona()
                    {
                        Id = IngresoContext.tblVisitante.tblPersona.Id,
                        NombreCompleto = IngresoContext.tblVisitante.tblPersona.Nombres + " " + IngresoContext.tblVisitante.tblPersona.Apellidos,
                        NumeroIdentificacion = IngresoContext.tblVisitante.tblPersona.NumeroIdentificacion,
                        Email = IngresoContext.tblVisitante.tblPersona.Email,
                        Telefono = IngresoContext.tblVisitante.tblPersona.Telefono,
                    },
                    TipoVisitante = new TipoVisitante()
                    {
                        Id = IngresoContext.tblVisitante.tblTipoVisitante.Id,
                        Nombre = IngresoContext.tblVisitante.tblTipoVisitante.Nombre,
                    }
                };
                objIngreso.Empleado = new Empleado()
                {
                    Id = IngresoContext.tblEmpleado.Id,
                    EmailLaboral = IngresoContext.tblEmpleado.EmailLaboral,
                    Persona = new Persona()
                    {
                        Id = IngresoContext.tblEmpleado.tblPersona.Id,
                        NombreCompleto = IngresoContext.tblEmpleado.tblPersona.Nombres + " " + IngresoContext.tblEmpleado.tblPersona.Apellidos,
                        NumeroIdentificacion = IngresoContext.tblEmpleado.tblPersona.NumeroIdentificacion,
                        
                    },
                    RolSennova = new RolSennova()
                    {
                        Id = IngresoContext.tblEmpleado.tblRolSennova.Id,
                        Nombre = IngresoContext.tblEmpleado.tblRolSennova.Nombre
                    }
                };
                objIngreso.Empresa = new Empresa()
                {
                    Id = IngresoContext.tblEmpresa.Id,
                    RazonSocial = IngresoContext.tblEmpresa.RazonSocial
                };
                if (IngresoContext.tblProgramaFormacion != null)
                {
                    objIngreso.ProgramaFormacion = new ProgramaFormacion()
                    {
                        Id = IngresoContext.tblProgramaFormacion.Id,
                        Nombre = IngresoContext.tblProgramaFormacion.Nombre
                    };

                };
                if (IngresoContext.lstIngresosAreasTecnicas != null)
                {
                    objIngreso.lstIngresosAreasTecnicas = new List<IngresosAreasTecnicas>();
                    foreach (var objIngresosAreasTecnicas in IngresoContext.lstIngresosAreasTecnicas)
                    {
                        objIngreso.lstIngresosAreasTecnicas.Add(new IngresosAreasTecnicas()
                        {
                            Id = objIngresosAreasTecnicas.Id,
                            AreaTecnica = new AreaTecnica()
                            {
                                Id = objIngresosAreasTecnicas.tblAreaTecnica.Id,
                                Nombre = objIngresosAreasTecnicas.tblAreaTecnica.Nombre,
                            },
                        });
                    };
                }
                return objIngreso;
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

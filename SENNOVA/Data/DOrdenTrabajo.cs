using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DOrdenTrabajo
    {
        private DB_SENNOVAContainer DbContext;

        public DOrdenTrabajo()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(OrdenTrabajo objOrdenTrabajo)
        {
            try
            {
                tblOrdenTrabajo OrdenTrabajoContext = new tblOrdenTrabajo();
                OrdenTrabajoContext.Id = objOrdenTrabajo.Id;
                OrdenTrabajoContext.AutorizaIngreso = objOrdenTrabajo.AutorizaIngreso;
                OrdenTrabajoContext.NumeroOT = objOrdenTrabajo.NumeroOT;
                OrdenTrabajoContext.FechaEmision = objOrdenTrabajo.FechaEmision;
                OrdenTrabajoContext.FechaLimite = objOrdenTrabajo.FechaLimite;
                OrdenTrabajoContext.FechaIngresoItem = objOrdenTrabajo.FechaIngresoItem;
                OrdenTrabajoContext.Observaciones = objOrdenTrabajo.Observaciones;

                OrdenTrabajoContext.tblAreaTecnica = DbContext.tblAreaTecnica.Single(i => i.Id == objOrdenTrabajo.AreaTecnica.Id);
                OrdenTrabajoContext.tblCotizacion = DbContext.tblCotizacion.Single(i => i.Id == objOrdenTrabajo.Cotizacion.Id);
                OrdenTrabajoContext.tblResponsable = DbContext.tblEmpleado.Single(i => i.Id == objOrdenTrabajo.Responzable.Id);

                DbContext.tblOrdenTrabajo.Add(OrdenTrabajoContext);
                DbContext.SaveChanges();
                return OrdenTrabajoContext.Id;
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

        public int Actualizar(OrdenTrabajo objOrdenTrabajo)
        {
            try
            {
                tblOrdenTrabajo OrdenTrabajoContext = DbContext.tblOrdenTrabajo.First(v => v.Id == objOrdenTrabajo.Id);
                OrdenTrabajoContext.Id = objOrdenTrabajo.Id;
                OrdenTrabajoContext.AutorizaIngreso = objOrdenTrabajo.AutorizaIngreso;
                OrdenTrabajoContext.NumeroOT = objOrdenTrabajo.NumeroOT;
                OrdenTrabajoContext.FechaEmision = objOrdenTrabajo.FechaEmision;
                OrdenTrabajoContext.FechaLimite = objOrdenTrabajo.FechaLimite;
                OrdenTrabajoContext.FechaIngresoItem = objOrdenTrabajo.FechaIngresoItem;
                OrdenTrabajoContext.Observaciones = objOrdenTrabajo.Observaciones;

                OrdenTrabajoContext.tblAreaTecnica = DbContext.tblAreaTecnica.Single(i => i.Id == objOrdenTrabajo.AreaTecnica.Id);
                OrdenTrabajoContext.tblCotizacion = DbContext.tblCotizacion.Single(i => i.Id == objOrdenTrabajo.Cotizacion.Id);
                OrdenTrabajoContext.tblResponsable = DbContext.tblEmpleado.Single(i => i.Id == objOrdenTrabajo.Responzable.Id);

                DbContext.SaveChanges();
                return OrdenTrabajoContext.Id;
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

        public void Eliminar(OrdenTrabajo objOrdenTrabajo)
        {
            try
            {
                var Accion = (from p in DbContext.tblOrdenTrabajo
                              where p.Id == objOrdenTrabajo.Id
                              select p).First();

                DbContext.tblOrdenTrabajo.Remove(Accion);
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

        public List<OrdenTrabajo> Consultar()
        {
            try
            {
                List<OrdenTrabajo> lstOrdenTrabajo = new List<OrdenTrabajo>();

                var query = from i in DbContext.tblOrdenTrabajo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstOrdenTrabajo.Add(Convertir(item));
                    }
                }

                return lstOrdenTrabajo;

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

        public Resultado<List<OrdenTrabajo>> Consultar(int top, int posicion)
        {
            try
            {

                List<OrdenTrabajo> lstOrdenTrabajo = new List<OrdenTrabajo>();
                Resultado<List<OrdenTrabajo>> resultado = new Resultado<List<OrdenTrabajo>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblOrdenTrabajo
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstOrdenTrabajo.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstOrdenTrabajo;
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

        public OrdenTrabajo Consultar(int id)
        {
            try
            {
                OrdenTrabajo objOrdenTrabajo = new OrdenTrabajo();

                var query = (from i in DbContext.tblOrdenTrabajo
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objOrdenTrabajo = Convertir(query);
                }
                return objOrdenTrabajo;

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

        public OrdenTrabajo ConsultarPorAreaTecnica(int idAreaTecnica)
        {
            try
            {
                OrdenTrabajo objOrdenTrabajo = new OrdenTrabajo();

                var query = (from i in DbContext.tblOrdenTrabajo
                             where i.tblAreaTecnica.Id == idAreaTecnica
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objOrdenTrabajo = Convertir(query);
                }
                return objOrdenTrabajo;

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


        public OrdenTrabajo Convertir(tblOrdenTrabajo OrdenTrabajoContext)
        {
            try
            {
                OrdenTrabajo objOrdenTrabajo = new OrdenTrabajo();
                objOrdenTrabajo.Id = OrdenTrabajoContext.Id;
                objOrdenTrabajo.AutorizaIngreso = OrdenTrabajoContext.AutorizaIngreso;
                objOrdenTrabajo.NumeroOT = OrdenTrabajoContext.NumeroOT;
                objOrdenTrabajo.FechaEmision = OrdenTrabajoContext.FechaEmision;
                objOrdenTrabajo.FechaLimite = OrdenTrabajoContext.FechaLimite;
                objOrdenTrabajo.FechaIngresoItem = OrdenTrabajoContext.FechaIngresoItem;
                objOrdenTrabajo.Observaciones = OrdenTrabajoContext.Observaciones;

                if (OrdenTrabajoContext.tblAreaTecnica != null)
                {
                    objOrdenTrabajo.AreaTecnica = new AreaTecnica()
                    {
                        Id = OrdenTrabajoContext.tblAreaTecnica.Id,
                        Codigo = OrdenTrabajoContext.tblAreaTecnica.Codigo,
                        Nombre = OrdenTrabajoContext.tblAreaTecnica.Nombre,
                        Activo = OrdenTrabajoContext.tblAreaTecnica.Activo,

                        TipoAreaTecnica = new TipoAreaTecnica()
                        {
                            Id = OrdenTrabajoContext.tblAreaTecnica.tblTipoAreaTecnica.Id,
                            Codigo = OrdenTrabajoContext.tblAreaTecnica.tblTipoAreaTecnica.Codigo,
                            Nombre = OrdenTrabajoContext.tblAreaTecnica.tblTipoAreaTecnica.Nombre,
                        }
                    };
                }

                if (OrdenTrabajoContext.tblCotizacion != null)
                {
                    objOrdenTrabajo.Cotizacion = new Cotizacion()
                    {
                        Id = OrdenTrabajoContext.tblCotizacion.Id,
                        Codigo = OrdenTrabajoContext.tblCotizacion.Codigo,
                        Fecha = OrdenTrabajoContext.tblCotizacion.Fecha,
                        ValorTotal = (decimal)OrdenTrabajoContext.tblCotizacion.ValorTotal,
                        ValidezOferta = OrdenTrabajoContext.tblCotizacion.ValidezOferta,
                        NumeroFicha = OrdenTrabajoContext.tblCotizacion.NumeroFicha,
                        TipoCotizacion = OrdenTrabajoContext.tblCotizacion.TipoCotizacion,
                        Observaciones = OrdenTrabajoContext.tblCotizacion.Observaciones,

                        ProgramaFormacion = new ProgramaFormacion()
                        {
                            Id = OrdenTrabajoContext.tblCotizacion.tblProgramaFormacion.Id,
                            Codigo = OrdenTrabajoContext.tblCotizacion.tblProgramaFormacion.Codigo,
                            Nombre = OrdenTrabajoContext.tblCotizacion.tblProgramaFormacion.Nombre,
                        },


                    };
                }
                if (OrdenTrabajoContext.tblResponsable != null)
                {
                    objOrdenTrabajo.Responzable = new Empleado()
                    {
                        Id = OrdenTrabajoContext.tblResponsable.Id,
                        EmailLaboral = OrdenTrabajoContext.tblResponsable.EmailLaboral,
                        Telefono = OrdenTrabajoContext.tblResponsable.Telefono,
                        Persona = new Persona()
                        {
                            Id = OrdenTrabajoContext.tblResponsable.tblPersona.Id,
                            NombreCompleto = OrdenTrabajoContext.tblResponsable.tblPersona.Nombres + " " + OrdenTrabajoContext.tblResponsable.tblPersona.Apellidos,
                        }
                    };
                }

                return objOrdenTrabajo;
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

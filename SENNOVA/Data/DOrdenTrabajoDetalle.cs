using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DOrdenTrabajoDetalle
    {
        private DB_SENNOVAContainer DbContext;

        public DOrdenTrabajoDetalle()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(OrdenTrabajoDetalle objOrdenTrabajoDetalle)
        {
            try
            {
                tblOrdenTrabajoDetalles OrdenTrabajoDetalleContext = new tblOrdenTrabajoDetalles();

                OrdenTrabajoDetalleContext.Id = objOrdenTrabajoDetalle.Id;
                OrdenTrabajoDetalleContext.Cantidad = objOrdenTrabajoDetalle.Cantidad;
                OrdenTrabajoDetalleContext.CodigoItem = objOrdenTrabajoDetalle.CodigoItem;
                OrdenTrabajoDetalleContext.Servicio = objOrdenTrabajoDetalle.Servicio;
                OrdenTrabajoDetalleContext.FechaInicio = objOrdenTrabajoDetalle.FechaInicio;
                OrdenTrabajoDetalleContext.FechaFinal = objOrdenTrabajoDetalle.FechaFinal;
                OrdenTrabajoDetalleContext.Observaciones = objOrdenTrabajoDetalle.Observaciones;

                OrdenTrabajoDetalleContext.tblOrdenTrabajo = DbContext.tblOrdenTrabajo.Single(i => i.Id == objOrdenTrabajoDetalle.OrdenTrabajo.Id);


                DbContext.tblOrdenTrabajoDetalles.Add(OrdenTrabajoDetalleContext);
                DbContext.SaveChanges();
                return OrdenTrabajoDetalleContext.Id;
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

        public int Actualizar(OrdenTrabajoDetalle objOrdenTrabajoDetalle)
        {
            try
            {
                tblOrdenTrabajoDetalles OrdenTrabajoDetalleContext = DbContext.tblOrdenTrabajoDetalles.First(v => v.Id == objOrdenTrabajoDetalle.Id);

                OrdenTrabajoDetalleContext.Id = objOrdenTrabajoDetalle.Id;
                OrdenTrabajoDetalleContext.Cantidad = objOrdenTrabajoDetalle.Cantidad;
                OrdenTrabajoDetalleContext.CodigoItem = objOrdenTrabajoDetalle.CodigoItem;
                OrdenTrabajoDetalleContext.Servicio = objOrdenTrabajoDetalle.Servicio;
                OrdenTrabajoDetalleContext.FechaInicio = objOrdenTrabajoDetalle.FechaInicio;
                OrdenTrabajoDetalleContext.FechaFinal = objOrdenTrabajoDetalle.FechaFinal;
                OrdenTrabajoDetalleContext.Observaciones = objOrdenTrabajoDetalle.Observaciones;

                OrdenTrabajoDetalleContext.tblOrdenTrabajo = DbContext.tblOrdenTrabajo.Single(i => i.Id == objOrdenTrabajoDetalle.OrdenTrabajo.Id);
                
                DbContext.SaveChanges();
                return OrdenTrabajoDetalleContext.Id;
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

        public void Eliminar(OrdenTrabajoDetalle objOrdenTrabajoDetalle)
        {
            try
            {
                var Accion = (from p in DbContext.tblOrdenTrabajoDetalles
                              where p.Id == objOrdenTrabajoDetalle.Id
                              select p).First();

                DbContext.tblOrdenTrabajoDetalles.Remove(Accion);
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
        public List<OrdenTrabajoDetalle> ConsultarPorOrdenTrabajo(int idOrdenTrabajo)
        {
            try
            {
                List<OrdenTrabajoDetalle> lstOrdenTrabajoDetalle = new List<OrdenTrabajoDetalle>();

                var query = from i in DbContext.tblOrdenTrabajoDetalles
                             where i.tblOrdenTrabajo.Id == idOrdenTrabajo
                             select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstOrdenTrabajoDetalle.Add(Convertir(item));
                    }
                }
                return lstOrdenTrabajoDetalle;

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
        public List<OrdenTrabajoDetalle> Consultar()
        {
            try
            {
                List<OrdenTrabajoDetalle> lstOrdenTrabajoDetalle = new List<OrdenTrabajoDetalle>();

                var query = from i in DbContext.tblOrdenTrabajoDetalles
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstOrdenTrabajoDetalle.Add(Convertir(item));
                    }
                }

                return lstOrdenTrabajoDetalle;

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

        public Resultado<List<OrdenTrabajoDetalle>> Consultar(int top, int posicion)
        {
            try
            {

                List<OrdenTrabajoDetalle> OrdenTrabajoDetalle = new List<OrdenTrabajoDetalle>();
                Resultado<List<OrdenTrabajoDetalle>> resultado = new Resultado<List<OrdenTrabajoDetalle>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblOrdenTrabajoDetalles
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        OrdenTrabajoDetalle.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = OrdenTrabajoDetalle;
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

        public OrdenTrabajoDetalle Consultar(int id)
        {
            try
            {
                OrdenTrabajoDetalle objOrdenTrabajoDetalle = new OrdenTrabajoDetalle();

                var query = (from i in DbContext.tblOrdenTrabajoDetalles
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objOrdenTrabajoDetalle = Convertir(query);
                }
                return objOrdenTrabajoDetalle;

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

        public OrdenTrabajoDetalle Convertir(tblOrdenTrabajoDetalles OrdenTrabajoDetalleContext)
        {
            try
            {
                OrdenTrabajoDetalle objOrdenTrabajoDetalle = new OrdenTrabajoDetalle();

                objOrdenTrabajoDetalle.Id = OrdenTrabajoDetalleContext.Id;
                objOrdenTrabajoDetalle.Cantidad = OrdenTrabajoDetalleContext.Cantidad;
                objOrdenTrabajoDetalle.CodigoItem = OrdenTrabajoDetalleContext.CodigoItem;
                objOrdenTrabajoDetalle.Servicio = OrdenTrabajoDetalleContext.Servicio;
                objOrdenTrabajoDetalle.FechaInicio = OrdenTrabajoDetalleContext.FechaInicio;
                objOrdenTrabajoDetalle.FechaFinal = OrdenTrabajoDetalleContext.FechaFinal;
                objOrdenTrabajoDetalle.Observaciones = OrdenTrabajoDetalleContext.Observaciones;

                if (OrdenTrabajoDetalleContext.tblOrdenTrabajo != null)
                {
                    objOrdenTrabajoDetalle.OrdenTrabajo = new OrdenTrabajo()
                    {
                        Id = OrdenTrabajoDetalleContext.tblOrdenTrabajo.Id,
                        AutorizaIngreso = OrdenTrabajoDetalleContext.tblOrdenTrabajo.AutorizaIngreso,
                        NumeroOT = OrdenTrabajoDetalleContext.tblOrdenTrabajo.NumeroOT,
                        FechaEmision = OrdenTrabajoDetalleContext.tblOrdenTrabajo.FechaEmision,
                        FechaLimite = OrdenTrabajoDetalleContext.tblOrdenTrabajo.FechaLimite,
                        FechaIngresoItem = OrdenTrabajoDetalleContext.tblOrdenTrabajo.FechaIngresoItem,
                        Observaciones = OrdenTrabajoDetalleContext.tblOrdenTrabajo.Observaciones,

                        AreaTecnica = new AreaTecnica()
                        {
                            Id = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblAreaTecnica.Id,
                            Codigo = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblAreaTecnica.Codigo,
                            Nombre = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblAreaTecnica.Nombre,

                        },

                        Cotizacion = new Cotizacion()
                        {
                            Id = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblCotizacion.Id,
                            Codigo = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblCotizacion.Codigo,
                            Fecha = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblCotizacion.Fecha,
                            ValorTotal = (decimal)OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblCotizacion.ValorTotal,
                            ValidezOferta = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblCotizacion.ValidezOferta,
                            NumeroFicha = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblCotizacion.NumeroFicha,
                            TipoCotizacion = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblCotizacion.TipoCotizacion,
                            Observaciones = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblCotizacion.Observaciones,

                        },

                        Responzable = new Empleado()
                        {
                            Id = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblResponsable.Id,
                            EmailLaboral = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblResponsable.EmailLaboral,
                            Telefono = OrdenTrabajoDetalleContext.tblOrdenTrabajo.tblResponsable.Telefono,
                        }
                    };
                }

                return objOrdenTrabajoDetalle;
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

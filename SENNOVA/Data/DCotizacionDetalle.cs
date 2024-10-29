using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DCotizacionDetalle
    {
        private DB_SENNOVAContainer DbContext;
        public DCotizacionDetalle()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(CotizacionDetalle objCotizacionDetalle)
        {
            try
            {
                tblCotizacionDetalle CotizacionDetalleContext = new tblCotizacionDetalle();
                CotizacionDetalleContext.Id = objCotizacionDetalle.Id;
                CotizacionDetalleContext.PrecioServicio = objCotizacionDetalle.PrecioServicio;
                CotizacionDetalleContext.Cantidad = objCotizacionDetalle.Cantidad;
                CotizacionDetalleContext.ValorUnitario = objCotizacionDetalle.ValorUnitario;
                CotizacionDetalleContext.Observaciones = objCotizacionDetalle.Observaciones;

                CotizacionDetalleContext.tblCotizacion = DbContext.tblCotizacion.Single(i => i.Id == objCotizacionDetalle.Cotizacion.Id);
                CotizacionDetalleContext.tblServicio = DbContext.tblServicio.Single(i => i.Id == objCotizacionDetalle.Servicio.Id);

                DbContext.tblCotizacionDetalle.Add(CotizacionDetalleContext);
                DbContext.SaveChanges();
                return CotizacionDetalleContext.Id;

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

        public int Actualizar(CotizacionDetalle objCotizacionDetalle)
        {
            try
            {
                tblCotizacionDetalle objCotizacionDetalleContext = DbContext.tblCotizacionDetalle.First(v => v.Id == objCotizacionDetalle.Id);


                objCotizacionDetalleContext.Id = objCotizacionDetalle.Id;
                objCotizacionDetalleContext.PrecioServicio = objCotizacionDetalle.PrecioServicio;
                objCotizacionDetalleContext.Cantidad = objCotizacionDetalle.Cantidad;
                objCotizacionDetalleContext.ValorUnitario = objCotizacionDetalle.ValorUnitario;
                objCotizacionDetalleContext.Observaciones = objCotizacionDetalle.Observaciones;

                objCotizacionDetalleContext.tblCotizacion = DbContext.tblCotizacion.Single(i => i.Id == objCotizacionDetalle.Cotizacion.Id);
                objCotizacionDetalleContext.tblServicio = DbContext.tblServicio.Single(i => i.Id == objCotizacionDetalle.Servicio.Id);

                DbContext.SaveChanges();
                return objCotizacionDetalleContext.Id;
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

        public void Eliminar(CotizacionDetalle objCotizacionDetalle)
        {
            try
            {
                var Accion = (from p in DbContext.tblCotizacionDetalle
                              where p.Id == objCotizacionDetalle.Id
                              select p).First();

                DbContext.tblCotizacionDetalle.Remove(Accion);
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

        public List<CotizacionDetalle> ConsultarPorCotizacion(int idCotizacion)
        {
            try
            {
                List<CotizacionDetalle> lstCotizacionDetalle = new List<CotizacionDetalle>();

                var query = from i in DbContext.tblCotizacionDetalle
                            where i.tblCotizacion.Id == idCotizacion
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstCotizacionDetalle.Add(Convertir(item));
                    }
                }
                return lstCotizacionDetalle;

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

        public List<CotizacionDetalle> Consultar()
        {
            try
            {
                List<CotizacionDetalle> lstCotizacionDetalle = new List<CotizacionDetalle>();

                var query = from i in DbContext.tblCotizacionDetalle
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstCotizacionDetalle.Add(Convertir(item));
                    }
                }

                return lstCotizacionDetalle;

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

        public CotizacionDetalle Consultar(int id)
        {
            try
            {
                CotizacionDetalle objCotizacionDetalle = new CotizacionDetalle();

                var query = (from i in DbContext.tblCotizacionDetalle
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCotizacionDetalle = Convertir(query);
                }
                return objCotizacionDetalle;

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

        public CotizacionDetalle ConsultarPorServicio(int id)
        {
            try
            {
                CotizacionDetalle objCotizacionDetalle = new CotizacionDetalle();

                var query = (from i in DbContext.tblCotizacionDetalle
                             where i.tblServicio.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCotizacionDetalle = Convertir(query);
                }
                return objCotizacionDetalle;

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

        public CotizacionDetalle Convertir(tblCotizacionDetalle CotizacionDetalleContext)
        {
            try
            {
                CotizacionDetalle objCotizacionDetalle = new CotizacionDetalle();

                objCotizacionDetalle.Id = CotizacionDetalleContext.Id;
                objCotizacionDetalle.PrecioServicio = (decimal)CotizacionDetalleContext.PrecioServicio;
                objCotizacionDetalle.Cantidad = CotizacionDetalleContext.Cantidad;
                objCotizacionDetalle.ValorUnitario = (decimal)CotizacionDetalleContext.ValorUnitario;
                objCotizacionDetalle.Observaciones = CotizacionDetalleContext.Observaciones;

                if (CotizacionDetalleContext.tblCotizacion != null)
                {
                    objCotizacionDetalle.Cotizacion = new Cotizacion()
                    {
                        Id = CotizacionDetalleContext.tblCotizacion.Id,
                        Codigo = CotizacionDetalleContext.tblCotizacion.Codigo,
                        Fecha = CotizacionDetalleContext.tblCotizacion.Fecha,
                        ValorTotal = (decimal)CotizacionDetalleContext.tblCotizacion.ValorTotal,
                        ValidezOferta = CotizacionDetalleContext.tblCotizacion.ValidezOferta,
                        NumeroFicha = CotizacionDetalleContext.tblCotizacion.NumeroFicha,
                        TipoCotizacion = CotizacionDetalleContext.tblCotizacion.TipoCotizacion,
                        Observaciones = CotizacionDetalleContext.tblCotizacion.Observaciones,


                        ProgramaFormacion = new ProgramaFormacion()
                        {
                            Id = CotizacionDetalleContext.tblCotizacion.tblProgramaFormacion.Id,
                            Codigo = CotizacionDetalleContext.tblCotizacion.tblProgramaFormacion.Codigo,
                            Nombre = CotizacionDetalleContext.tblCotizacion.tblProgramaFormacion.Nombre,
                            Activo = CotizacionDetalleContext.tblCotizacion.tblProgramaFormacion.Activo,
                        },

                        Elaborador = new Empleado()
                        {
                            Id = CotizacionDetalleContext.tblCotizacion.tblElaborador.tblPersona.Id,
                            NombreCompleto = CotizacionDetalleContext.tblCotizacion.tblElaborador.tblPersona.Nombres + " " + CotizacionDetalleContext.tblCotizacion.tblElaborador.tblPersona.Apellidos,
                        },

                        Autorizador = new Empleado()
                        {
                            Id = CotizacionDetalleContext.tblCotizacion.tblAutorizador.tblPersona.Id,
                            NombreCompleto = CotizacionDetalleContext.tblCotizacion.tblAutorizador.tblPersona.Nombres + " " + CotizacionDetalleContext.tblCotizacion.tblAutorizador.tblPersona.Apellidos,
                        },

                        Revisador = new Empleado()
                        {
                            Id = CotizacionDetalleContext.tblCotizacion.tblRevisador.tblPersona.Id,
                            NombreCompleto = CotizacionDetalleContext.tblCotizacion.tblRevisador.tblPersona.Nombres + " " + CotizacionDetalleContext.tblCotizacion.tblRevisador.tblPersona.Apellidos,
                        },
                    };
                }

                if (CotizacionDetalleContext.tblServicio != null)
                {
                    objCotizacionDetalle.Servicio = new Servicio()
                    {
                        Id = CotizacionDetalleContext.tblServicio.Id,
                        Codigo = CotizacionDetalleContext.tblServicio.Codigo,
                        Nombre = CotizacionDetalleContext.tblServicio.Nombre,
                        Requisitos = CotizacionDetalleContext.tblServicio.Requisitos,
                        Alcance = CotizacionDetalleContext.tblServicio.Alcance,
                        Valor = CotizacionDetalleContext.tblServicio.Valor,
                        Activo = CotizacionDetalleContext.tblServicio.Activo,

                        AreaTecnica = new AreaTecnica()
                        {
                            Id = CotizacionDetalleContext.tblServicio.tblAreaTecnica.Id,
                            Codigo = CotizacionDetalleContext.tblServicio.tblAreaTecnica.Codigo,
                            Nombre = CotizacionDetalleContext.tblServicio.tblAreaTecnica.Nombre,
                            Activo = CotizacionDetalleContext.tblServicio.tblAreaTecnica.Activo,
                        }
                    };
                }
                return objCotizacionDetalle;
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

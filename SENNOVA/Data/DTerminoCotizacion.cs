using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DTerminoCotizacion
    {
        private DB_SENNOVAContainer DbContext;

        public DTerminoCotizacion()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(TerminoCotizacion objTerminoCotizacion)
        {
            try
            {
                tblTerminoCotizacion TerminoCotizacionContext = new tblTerminoCotizacion();
                TerminoCotizacionContext.tblTerminoCondicion = DbContext.tblTerminoCondicion.Single(i => i.Id == objTerminoCotizacion.TerminoCondicion.Id);
                TerminoCotizacionContext.tblCotizacion = DbContext.tblCotizacion.Single(i => i.Id == objTerminoCotizacion.Cotizacion.Id);
                DbContext.tblTerminoCotizacion.Add(TerminoCotizacionContext);
                DbContext.SaveChanges();
                return TerminoCotizacionContext.Id;

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

        public int Actualizar(TerminoCotizacion objTerminoCotizacion)
        {
            try
            {
                tblTerminoCotizacion objTerminoCotizacionContext = DbContext.tblTerminoCotizacion.First(v => v.Id == objTerminoCotizacion.Id);
                objTerminoCotizacionContext.Id = objTerminoCotizacion.Id;
                objTerminoCotizacionContext.tblTerminoCondicion = DbContext.tblTerminoCondicion.Single(i => i.Id == objTerminoCotizacion.TerminoCondicion.Id);
                objTerminoCotizacionContext.tblCotizacion = DbContext.tblCotizacion.Single(i => i.Id == objTerminoCotizacion.Cotizacion.Id);

                DbContext.SaveChanges();
                return objTerminoCotizacionContext.Id;
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

        public void Eliminar(TerminoCotizacion objTerminoCotizacion)
        {
            try
            {
                var Accion = (from p in DbContext.tblTerminoCotizacion
                              where p.Id == objTerminoCotizacion.Id
                              select p).First();

                DbContext.tblTerminoCotizacion.Remove(Accion);
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

        public TerminoCotizacion ConsultarPorTerminoCondicion(int id)
        {
            try
            {
                TerminoCotizacion objTerminoCotizacion = new TerminoCotizacion();

                var query = (from i in DbContext.tblTerminoCotizacion
                             where i.tblTerminoCondicion.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTerminoCotizacion = Convertir(query);
                }
                return objTerminoCotizacion;

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

        public List<TerminoCotizacion> Consultar()
        {
            try
            {
                List<TerminoCotizacion> lstTerminoCotizacion = new List<TerminoCotizacion>();

                var query = from i in DbContext.tblTerminoCotizacion
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstTerminoCotizacion.Add(Convertir(item));
                    }
                }

                return lstTerminoCotizacion;

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

        public Resultado<List<TerminoCotizacion>> Consultar(int top, int posicion)
        {
            try
            {

                List<TerminoCotizacion> lstTerminoCotizacion = new List<TerminoCotizacion>();
                Resultado<List<TerminoCotizacion>> resultado = new Resultado<List<TerminoCotizacion>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblTerminoCotizacion
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstTerminoCotizacion.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstTerminoCotizacion;
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

        public TerminoCotizacion Consultar(int id)
        {
            try
            {
                TerminoCotizacion objTerminoCotizacion = new TerminoCotizacion();

                var query = (from i in DbContext.tblTerminoCotizacion
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTerminoCotizacion = Convertir(query);
                }
                return objTerminoCotizacion;

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

        public TerminoCotizacion Convertir(tblTerminoCotizacion TerminoCotizacionContext)
        {
            try
            {
                TerminoCotizacion objTerminoCotizacion = new TerminoCotizacion();
                objTerminoCotizacion.Id = TerminoCotizacionContext.Id;
                objTerminoCotizacion.TerminoCondicion = new TerminoCondicion()
                {
                    Id = TerminoCotizacionContext.tblTerminoCondicion.Id,
                    Codigo = TerminoCotizacionContext.tblTerminoCondicion.Codigo,
                    Nombre = TerminoCotizacionContext.tblTerminoCondicion.Nombre,
                    Activo = TerminoCotizacionContext.tblTerminoCondicion.Activo,
                };
                objTerminoCotizacion.Cotizacion = new Cotizacion()
                {
                    Id = TerminoCotizacionContext.tblCotizacion.Id,
                    Codigo = TerminoCotizacionContext.tblCotizacion.Codigo,
                    Fecha = TerminoCotizacionContext.tblCotizacion.Fecha,
                    ValorTotal = (decimal)TerminoCotizacionContext.tblCotizacion.ValorTotal,


                };
                if (TerminoCotizacionContext.tblCotizacion.tblProgramaFormacion != null)
                {
                    objTerminoCotizacion.Cotizacion.ProgramaFormacion = new ProgramaFormacion()
                    {
                        Id = TerminoCotizacionContext.tblCotizacion.tblProgramaFormacion.Id,
                        Nombre = TerminoCotizacionContext.tblCotizacion.tblProgramaFormacion.Nombre,
                    };
                }
                return objTerminoCotizacion;
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

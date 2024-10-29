using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DCotizacion
    {
        private DB_SENNOVAContainer DbContext;

        public DCotizacion()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Cotizacion objCotizacion)
        {
            try
            {
                tblCotizacion CotizacionContext = new tblCotizacion();
                CotizacionContext.Id = objCotizacion.Id;
                CotizacionContext.Codigo = objCotizacion.Codigo;
                CotizacionContext.Fecha = objCotizacion.Fecha;
                CotizacionContext.ValorTotal = objCotizacion.ValorTotal;
                CotizacionContext.ValidezOferta = objCotizacion.ValidezOferta;
                CotizacionContext.NumeroFicha = objCotizacion.NumeroFicha;
                CotizacionContext.TipoCotizacion = objCotizacion.TipoCotizacion;
                CotizacionContext.Observaciones = objCotizacion.Observaciones;
                CotizacionContext.tblProgramaFormacion = DbContext.tblProgramaFormacion.Single(i => i.Id == objCotizacion.ProgramaFormacion.Id);
                CotizacionContext.tblElaborador = DbContext.tblEmpleado.Single(i => i.Id == objCotizacion.Elaborador.Id);
                CotizacionContext.tblAutorizador = DbContext.tblEmpleado.Single(i => i.Id == objCotizacion.Autorizador.Id);
                CotizacionContext.tblRevisador = DbContext.tblEmpleado.Single(i => i.Id == objCotizacion.Revisador.Id);
                DbContext.tblCotizacion.Add(CotizacionContext);
                DbContext.SaveChanges();
                return CotizacionContext.Id;

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

        public int Actualizar(Cotizacion objCotizacion)
        {
            try
            {
                tblCotizacion objCotizacionContext = DbContext.tblCotizacion.First(v => v.Id == objCotizacion.Id);
                objCotizacionContext.Id = objCotizacion.Id;
                objCotizacionContext.Codigo = objCotizacion.Codigo;
                objCotizacionContext.Fecha = objCotizacion.Fecha;
                objCotizacionContext.ValorTotal = objCotizacion.ValorTotal;
                objCotizacionContext.ValidezOferta = objCotizacion.ValidezOferta;
                objCotizacionContext.NumeroFicha = objCotizacion.NumeroFicha;
                objCotizacionContext.TipoCotizacion = objCotizacion.TipoCotizacion;
                objCotizacionContext.Observaciones = objCotizacion.Observaciones;
                objCotizacionContext.tblProgramaFormacion = DbContext.tblProgramaFormacion.Single(i => i.Id == objCotizacion.ProgramaFormacion.Id);
                objCotizacionContext.tblElaborador = DbContext.tblEmpleado.Single(i => i.Id == objCotizacion.Elaborador.Id);
                objCotizacionContext.tblAutorizador = DbContext.tblEmpleado.Single(i => i.Id == objCotizacion.Autorizador.Id);
                objCotizacionContext.tblRevisador = DbContext.tblEmpleado.Single(i => i.Id == objCotizacion.Revisador.Id);

                DbContext.SaveChanges();
                return objCotizacionContext.Id;
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

        public void Eliminar(Cotizacion objCotizacion)
        {
            try
            {
                var Accion = (from p in DbContext.tblCotizacion
                              where p.Id == objCotizacion.Id
                              select p).First();

                DbContext.tblCotizacion.Remove(Accion);
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

        public Cotizacion ConsultarPorProgramaFormacion(int id)
        {
            try
            {
                Cotizacion objCotizacion = new Cotizacion();

                var query = (from i in DbContext.tblCotizacion
                             where i.tblProgramaFormacion.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCotizacion = Convertir(query);
                }
                return objCotizacion;

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

        public List<Cotizacion> Consultar()
        {
            try
            {
                List<Cotizacion> lstCotizacion = new List<Cotizacion>();

                var query = from i in DbContext.tblCotizacion
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstCotizacion.Add(Convertir(item));
                    }
                }

                return lstCotizacion;

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

        public Resultado<List<Cotizacion>> Consultar(int top, int posicion)
        {
            try
            {

                List<Cotizacion> lstCotizacion = new List<Cotizacion>();
                Resultado<List<Cotizacion>> resultado = new Resultado<List<Cotizacion>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblCotizacion
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstCotizacion.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstCotizacion;
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

        public Cotizacion Consultar(int id)
        {
            try
            {
                Cotizacion objCotizacion = new Cotizacion();

                var query = (from i in DbContext.tblCotizacion
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCotizacion = Convertir(query);
                }
                return objCotizacion;

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

        public Cotizacion Consultar(string codigo)
        {
            try
            {
                Cotizacion objCotizacion = new Cotizacion();

                var query = (from i in DbContext.tblCotizacion
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCotizacion = Convertir(query);
                }
                return objCotizacion;

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


        public Cotizacion Convertir(tblCotizacion CotizacionContext)
        {
            try
            {
                Cotizacion objCotizacion = new Cotizacion();
                objCotizacion.Id = CotizacionContext.Id;
                objCotizacion.Codigo = CotizacionContext.Codigo;
                objCotizacion.Fecha = CotizacionContext.Fecha;
                objCotizacion.ValorTotal = (decimal)CotizacionContext.ValorTotal;
                objCotizacion.ValidezOferta = CotizacionContext.ValidezOferta;
                objCotizacion.NumeroFicha = CotizacionContext.NumeroFicha;
                objCotizacion.TipoCotizacion = CotizacionContext.TipoCotizacion;
                objCotizacion.Observaciones = CotizacionContext.Observaciones;
                if (CotizacionContext.tblProgramaFormacion != null)
                {
                    objCotizacion.ProgramaFormacion = new ProgramaFormacion()
                    {
                        Id = CotizacionContext.tblProgramaFormacion.Id,
                        Codigo = CotizacionContext.tblProgramaFormacion.Codigo,
                        Nombre = CotizacionContext.tblProgramaFormacion.Nombre,
                        Activo = CotizacionContext.tblProgramaFormacion.Activo,
                    }; 
                }
                if (CotizacionContext.tblElaborador != null)
                {
                    objCotizacion.Elaborador = new Empleado()
                    {
                        Id = CotizacionContext.tblElaborador.Id,
                        EmailLaboral = CotizacionContext.tblElaborador.EmailLaboral,
                        Persona  =new Persona()
                        {
                            Id = CotizacionContext.tblElaborador.tblPersona.Id,
                            NombreCompleto = CotizacionContext.tblElaborador.tblPersona.Nombres + " " + CotizacionContext.tblElaborador.tblPersona.Apellidos,
                        }
                    };
                }
                if (CotizacionContext.tblAutorizador != null)
                {
                    objCotizacion.Autorizador = new Empleado()
                    {
                        Id = CotizacionContext.tblAutorizador.Id,
                        EmailLaboral = CotizacionContext.tblAutorizador.EmailLaboral,
                        Persona = new Persona()
                        {
                            Id = CotizacionContext.tblAutorizador.tblPersona.Id,
                            NombreCompleto = CotizacionContext.tblAutorizador.tblPersona.Nombres + " " + CotizacionContext.tblAutorizador.tblPersona.Apellidos,
                        }
                    };
                }
                if (CotizacionContext.tblRevisador != null)
                {
                    objCotizacion.Revisador = new Empleado()
                    {
                        Id = CotizacionContext.tblRevisador.Id,
                        EmailLaboral = CotizacionContext.tblRevisador.EmailLaboral,
                        Persona = new Persona()
                        {
                            Id = CotizacionContext.tblRevisador.tblPersona.Id,
                            NombreCompleto = CotizacionContext.tblRevisador.tblPersona.Nombres + " " + CotizacionContext.tblRevisador.tblPersona.Apellidos,
                        }
                    };
                }
                if (CotizacionContext.tblCliente !=null)
                {
                    objCotizacion.Cliente = new Cliente()
                    {
                        Id = CotizacionContext.tblCliente.Id,
                        Persona = new Persona()
                        {
                            Id = CotizacionContext.tblCliente.tblPersona.Id,
                            NombreCompleto = CotizacionContext.tblCliente.tblPersona.Nombres + " " + CotizacionContext.tblCliente.tblPersona.Apellidos,
                        }
                    };
                }
                return objCotizacion;
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

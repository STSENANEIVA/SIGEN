using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DProyecto
    {
        private DB_SENNOVAContainer DbContext;

        public DProyecto()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Proyecto objProyecto)
        {
            try
            {
                tblProyecto ProyectoContext = new tblProyecto();
                ProyectoContext.Id = objProyecto.Id;
                ProyectoContext.TituloProyecto = objProyecto.TituloProyecto;
                ProyectoContext.CodigoSGPS = objProyecto.CodigoSGPS.ToUpper();
                ProyectoContext.AnoEjecucion = objProyecto.AnoEjecucion;
                ProyectoContext.FechaDiligenciamiento = objProyecto.FechaDiligenciamiento;
                ProyectoContext.ObjetivoGeneral = objProyecto.ObjetivoGeneral;
                ProyectoContext.AsignacionInicial = objProyecto.AsignacionInicial;
                ProyectoContext.tblCentroFormacion = DbContext.tblCentroFormacion.Single(i => i.Id == objProyecto.CentroFormacion.Id);
                ProyectoContext.tblLineaProgramatica = DbContext.tblLineaProgramatica.Single(i => i.Id == objProyecto.LineaProgramatica.Id);
                ProyectoContext.tblRedConocimientoSectorial = DbContext.tblRedConocimientoSectorial.Single(i => i.Id == objProyecto.RedConocimientoSectorial.Id);
                ProyectoContext.tblAreaConocimiento = DbContext.tblAreaConocimiento.Single(i => i.Id == objProyecto.AreaConocimiento.Id);
                ProyectoContext.tblEmpleado = DbContext.tblEmpleado.Single(i => i.Id == objProyecto.Empleado.Id);
                DbContext.tblProyecto.Add(ProyectoContext);
                DbContext.SaveChanges();
                return ProyectoContext.Id;

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

        public int Actualizar(Proyecto objProyecto)
        {
            try
            {
                tblProyecto objProyectoContext = DbContext.tblProyecto.First(v => v.Id == objProyecto.Id);
                objProyectoContext.Id = objProyecto.Id;
                objProyectoContext.TituloProyecto = objProyecto.TituloProyecto;
                objProyectoContext.CodigoSGPS = objProyecto.CodigoSGPS.ToUpper();
                objProyectoContext.AnoEjecucion = objProyecto.AnoEjecucion;
                objProyectoContext.FechaDiligenciamiento = objProyecto.FechaDiligenciamiento;
                objProyectoContext.ObjetivoGeneral = objProyecto.ObjetivoGeneral;
                objProyectoContext.AsignacionInicial = objProyecto.AsignacionInicial;
                objProyectoContext.tblCentroFormacion = DbContext.tblCentroFormacion.Single(i => i.Id == objProyecto.CentroFormacion.Id);
                objProyectoContext.tblLineaProgramatica = DbContext.tblLineaProgramatica.Single(i => i.Id == objProyecto.LineaProgramatica.Id);
                objProyectoContext.tblRedConocimientoSectorial = DbContext.tblRedConocimientoSectorial.Single(i => i.Id == objProyecto.RedConocimientoSectorial.Id);
                objProyectoContext.tblAreaConocimiento = DbContext.tblAreaConocimiento.Single(i => i.Id == objProyecto.AreaConocimiento.Id);
                objProyectoContext.tblEmpleado = DbContext.tblEmpleado.Single(i => i.Id == objProyecto.Empleado.Id);
                DbContext.SaveChanges();
                return objProyectoContext.Id;
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

        public void Eliminar(Proyecto objProyecto)
        {
            try
            {
                var Accion = (from p in DbContext.tblProyecto
                              where p.Id == objProyecto.Id
                              select p).First();

                DbContext.tblProyecto.Remove(Accion);
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

        public List<Proyecto> Consultar()
        {
            try
            {
                List<Proyecto> lstProyecto = new List<Proyecto>();

                var query = from i in DbContext.tblProyecto
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstProyecto.Add(Convertir(item));
                    }
                }

                return lstProyecto;

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

        public List<Proyecto> ConsultarEmpleado(int idEmpleado)
        {
            try
            {
                List<Proyecto> lstProyecto = new List<Proyecto>();

                var query = from i in DbContext.tblProyecto
                            where i.tblEmpleado.Id == idEmpleado
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstProyecto.Add(Convertir(item));
                    }
                }

                return lstProyecto;

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

        public Resultado<List<Proyecto>> Consultar(int top, int posicion)
        {
            try
            {

                List<Proyecto> lstProyecto = new List<Proyecto>();
                Resultado<List<Proyecto>> resultado = new Resultado<List<Proyecto>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblProyecto
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstProyecto.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstProyecto;
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

        public Proyecto ConsultarPorLineaProgramatica(int id)
        {
            try
            {
                Proyecto objProyecto = new Proyecto();

                var query = (from i in DbContext.tblProyecto
                             where i.tblLineaProgramatica.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProyecto = Convertir(query);
                }
                return objProyecto;

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

        public Proyecto ConsultarPorEmpleado(int id)
        {
            try
            {
                Proyecto objProyecto = new Proyecto();

                var query = (from i in DbContext.tblProyecto
                             where i.tblEmpleado.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProyecto = Convertir(query);
                }
                return objProyecto;

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

        public Proyecto ConsultarPorAreaConocimiento(int id)
        {
            try
            {
                Proyecto objProyecto = new Proyecto();

                var query = (from i in DbContext.tblProyecto
                             where i.tblAreaConocimiento.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProyecto = Convertir(query);
                }
                return objProyecto;

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

        public Proyecto ConsultarPorRedConocimientoSectorial(int id)
        {
            try
            {
                Proyecto objProyecto = new Proyecto();

                var query = (from i in DbContext.tblProyecto
                             where i.tblRedConocimientoSectorial.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProyecto = Convertir(query);
                }
                return objProyecto;

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

        public Proyecto Consultar(int id)
        {
            try
            {
                Proyecto objProyecto = new Proyecto();

                var query = (from i in DbContext.tblProyecto
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProyecto = Convertir(query);
                }
                return objProyecto;

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

        public List<Proyecto> Consultar(string TituloProyecto)
        {
            try
            {
                List<Proyecto> lstProyecto = new List<Proyecto>();

                var query = from i in DbContext.tblProyecto
                             where i.TituloProyecto == TituloProyecto
                             select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstProyecto.Add(Convertir(item));
                    }
                }

                return lstProyecto;

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

        public Proyecto Convertir(tblProyecto ProyectoContext)
        {
            try
            {
                Proyecto objProyecto = new Proyecto();
                objProyecto.Id = ProyectoContext.Id;
                objProyecto.TituloProyecto = ProyectoContext.TituloProyecto;
                objProyecto.CodigoSGPS = ProyectoContext.CodigoSGPS.ToUpper();
                objProyecto.AnoEjecucion = ProyectoContext.AnoEjecucion;
                objProyecto.FechaDiligenciamiento = ProyectoContext.FechaDiligenciamiento;
                objProyecto.ObjetivoGeneral = ProyectoContext.ObjetivoGeneral;
                objProyecto.AsignacionInicial = ProyectoContext.AsignacionInicial;
                objProyecto.CentroFormacion = new CentroFormacion()
                {
                    Id = ProyectoContext.tblCentroFormacion.Id,
                    Codigo = ProyectoContext.tblCentroFormacion.Codigo,
                    Nombre = ProyectoContext.tblCentroFormacion.Nombre,
                    Activo = ProyectoContext.tblCentroFormacion.Activo,
                };
                objProyecto.LineaProgramatica = new LineaProgramatica()
                {
                    Id = ProyectoContext.tblLineaProgramatica.Id,
                    Codigo = ProyectoContext.tblLineaProgramatica.Codigo,
                    Nombre = ProyectoContext.tblLineaProgramatica.Nombre,
                    Activo = ProyectoContext.tblLineaProgramatica.Activo,
                };
                objProyecto.RedConocimientoSectorial = new RedConocimientoSectorial()
                {
                    Id = ProyectoContext.tblRedConocimientoSectorial.Id,
                    Codigo = ProyectoContext.tblRedConocimientoSectorial.Codigo,
                    Nombre = ProyectoContext.tblRedConocimientoSectorial.Nombre,
                    Activo = ProyectoContext.tblRedConocimientoSectorial.Activo,
                };
                objProyecto.AreaConocimiento = new AreaConocimiento()
                {
                    Id = ProyectoContext.tblAreaConocimiento.Id,
                    Codigo = ProyectoContext.tblAreaConocimiento.Codigo,
                    Nombre = ProyectoContext.tblAreaConocimiento.Nombre,
                    Activo = ProyectoContext.tblAreaConocimiento.Activo,
                };
                objProyecto.Empleado = new Empleado()
                {
                    Id = ProyectoContext.tblEmpleado.Id,
                    NombreCompleto = ProyectoContext.tblEmpleado.tblPersona.Nombres + " " + ProyectoContext.tblEmpleado.tblPersona.Apellidos
                };
                return objProyecto;
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

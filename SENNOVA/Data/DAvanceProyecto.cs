using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DAvanceProyecto
    {
        private DB_SENNOVAContainer DbContext;

        public DAvanceProyecto()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(AvanceProyecto objAvanceProyecto)
        {
            try
            {
                tblAvanceProyecto AvanceProyectoContext = new tblAvanceProyecto();
                AvanceProyectoContext.Id = objAvanceProyecto.Id;
                AvanceProyectoContext.Mes = objAvanceProyecto.Mes;
                AvanceProyectoContext.Proyectado = objAvanceProyecto.Proyectado;
                AvanceProyectoContext.Ejecutado = objAvanceProyecto.Ejecutado;
                AvanceProyectoContext.Observaciones = objAvanceProyecto.Observaciones;
                AvanceProyectoContext.EjecutadoPresupuesto = objAvanceProyecto.EjecutadoPresupuesto;
                AvanceProyectoContext.Adicion = objAvanceProyecto.Adicion;
                AvanceProyectoContext.Disminucion = objAvanceProyecto.Disminucion;
                AvanceProyectoContext.Saldo = objAvanceProyecto.Saldo;
                AvanceProyectoContext.tblActividad = DbContext.tblActividad.Single(i => i.Id == objAvanceProyecto.Actividad.Id);
                DbContext.tblAvanceProyecto.Add(AvanceProyectoContext);
                DbContext.SaveChanges();
                return AvanceProyectoContext.Id;

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

        public int Actualizar(AvanceProyecto objAvanceProyecto)
        {
            try
            {
                tblAvanceProyecto objAvanceProyectoContext = DbContext.tblAvanceProyecto.First(v => v.Id == objAvanceProyecto.Id);
                objAvanceProyectoContext.Id = objAvanceProyecto.Id;
                objAvanceProyectoContext.Mes = objAvanceProyecto.Mes;
                objAvanceProyectoContext.Proyectado = objAvanceProyecto.Proyectado;
                objAvanceProyectoContext.Ejecutado = objAvanceProyecto.Ejecutado;
                objAvanceProyectoContext.Observaciones = objAvanceProyecto.Observaciones;
                objAvanceProyectoContext.EjecutadoPresupuesto = objAvanceProyecto.EjecutadoPresupuesto;
                objAvanceProyectoContext.Adicion = objAvanceProyecto.Adicion;
                objAvanceProyectoContext.Disminucion = objAvanceProyecto.Disminucion;
                objAvanceProyectoContext.Saldo = objAvanceProyecto.Saldo;
                objAvanceProyectoContext.tblActividad = DbContext.tblActividad.Single(i => i.Id == objAvanceProyecto.Actividad.Id);
                DbContext.SaveChanges();
                return objAvanceProyectoContext.Id;
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

        public void Eliminar(AvanceProyecto objAvanceProyecto)
        {
            try
            {
                var Accion = (from p in DbContext.tblAvanceProyecto
                              where p.Id == objAvanceProyecto.Id
                              select p).First();

                DbContext.tblAvanceProyecto.Remove(Accion);
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

        public List<AvanceProyecto> ConsultarPorActividad(int idActividad)
        {
            try
            {
                List<AvanceProyecto> lstAvanceProyecto = new List<AvanceProyecto>();

                var query = from i in DbContext.tblAvanceProyecto
                            where i.tblActividad.Id == idActividad
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstAvanceProyecto.Add(Convertir(item));
                    }
                }

                return lstAvanceProyecto;

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

        public List<AvanceProyecto> Consultar()
        {
            try
            {
                List<AvanceProyecto> lstAvanceProyecto = new List<AvanceProyecto>();

                var query = from i in DbContext.tblAvanceProyecto
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstAvanceProyecto.Add(Convertir(item));
                    }
                }

                return lstAvanceProyecto;

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

        public Resultado<List<AvanceProyecto>> Consultar(int top, int posicion)
        {
            try
            {

                List<AvanceProyecto> lstAvanceProyecto = new List<AvanceProyecto>();
                Resultado<List<AvanceProyecto>> resultado = new Resultado<List<AvanceProyecto>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblAvanceProyecto
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstAvanceProyecto.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstAvanceProyecto;
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

        public AvanceProyecto Consultar(int id)
        {
            try
            {
                AvanceProyecto objAvanceProyecto = new AvanceProyecto();

                var query = (from i in DbContext.tblAvanceProyecto
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objAvanceProyecto = Convertir(query);
                }
                return objAvanceProyecto;

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

        public AvanceProyecto ConsultarMes(string Mes)
        {
            try
            {
                AvanceProyecto objAvanceProyecto = new AvanceProyecto();

                var query = (from i in DbContext.tblAvanceProyecto
                             where i.Mes == Mes
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objAvanceProyecto = Convertir(query);
                }
                return objAvanceProyecto;

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


        public AvanceProyecto Convertir(tblAvanceProyecto AvanceProyectoContext)
        {
            try
            {
                AvanceProyecto objAvanceProyecto = new AvanceProyecto();
                objAvanceProyecto.Id = AvanceProyectoContext.Id;
                objAvanceProyecto.Mes = AvanceProyectoContext.Mes;
                objAvanceProyecto.Proyectado = AvanceProyectoContext.Proyectado;
                objAvanceProyecto.Ejecutado = (decimal)AvanceProyectoContext.Ejecutado;
                objAvanceProyecto.Observaciones = AvanceProyectoContext.Observaciones;
                objAvanceProyecto.EjecutadoPresupuesto = (decimal)AvanceProyectoContext.EjecutadoPresupuesto;
                objAvanceProyecto.Adicion = (decimal)AvanceProyectoContext.Adicion;
                objAvanceProyecto.Disminucion = (decimal)AvanceProyectoContext.Disminucion;
                objAvanceProyecto.Saldo = (decimal)AvanceProyectoContext.Saldo;
                objAvanceProyecto.Actividad = new Actividad()
                {
                    Id = AvanceProyectoContext.tblActividad.Id,
                    Codigo = AvanceProyectoContext.tblActividad.Codigo,
                    Nombre = AvanceProyectoContext.tblActividad.Nombre,
                    Activo = AvanceProyectoContext.tblActividad.Activo,
                };
                return objAvanceProyecto;
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

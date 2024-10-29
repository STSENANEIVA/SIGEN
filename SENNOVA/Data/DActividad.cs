using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DActividad
    {
        private DB_SENNOVAContainer DbContext;

        public DActividad()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Actividad objActividad)
        {
            try
            {
                tblActividad ActividadContext = new tblActividad();
                ActividadContext.Id = objActividad.Id;
                ActividadContext.Codigo = objActividad.Codigo;
                ActividadContext.Nombre = objActividad.Nombre.ToUpper();
                ActividadContext.Activo = objActividad.Activo;
                ActividadContext.tblObjetivoEspecifico = DbContext.tblObjetivoEspecifico.Single(i => i.Id == objActividad.ObjetivoEspecifico.Id);

                DbContext.tblActividad.Add(ActividadContext);
                DbContext.SaveChanges();
                return ActividadContext.Id;

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

        public int Actualizar(Actividad objActividad)
        {
            try
            {
                tblActividad objActividadContext = DbContext.tblActividad.First(v => v.Id == objActividad.Id);
                objActividadContext.Id = objActividad.Id;
                objActividadContext.Codigo = objActividad.Codigo;
                objActividadContext.Nombre = objActividad.Nombre.ToUpper();
                objActividadContext.Activo = objActividad.Activo;
                objActividadContext.tblObjetivoEspecifico = DbContext.tblObjetivoEspecifico.Single(i => i.Id == objActividad.ObjetivoEspecifico.Id);
                DbContext.SaveChanges();
                return objActividadContext.Id;
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

        public void Eliminar(Actividad objActividad)
        {
            try
            {
                var Accion = (from p in DbContext.tblActividad
                              where p.Id == objActividad.Id
                              select p).First();

                DbContext.tblActividad.Remove(Accion);
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

        public List<Actividad> Consultar()
        {
            try
            {
                List<Actividad> lstActividad = new List<Actividad>();

                var query = from i in DbContext.tblActividad
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstActividad.Add(Convertir(item));
                    }
                }

                return lstActividad;

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

        public List<Actividad> ConsultarPorObjetivo(int idObjetivo)
        {
            try
            {
                List<Actividad> lstActividad = new List<Actividad>();

                var query = from i in DbContext.tblActividad
                            where i.tblObjetivoEspecifico.Id == idObjetivo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstActividad.Add(Convertir(item));
                    }
                }

                return lstActividad;

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

        public Actividad ConsultarPorObjetivoEspecifico(int id)
        {
            try
            {
                Actividad objActividad = new Actividad();

                var query = (from i in DbContext.tblActividad
                             where i.tblObjetivoEspecifico.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objActividad = Convertir(query);
                }
                return objActividad;

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

        public Resultado<List<Actividad>> Consultar(int top, int posicion)
        {
            try
            {

                List<Actividad> lstActividad = new List<Actividad>();
                Resultado<List<Actividad>> resultado = new Resultado<List<Actividad>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblActividad
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstActividad.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstActividad;
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

        public Actividad Consultar(int id)
        {
            try
            {
                Actividad objActividad = new Actividad();

                var query = (from i in DbContext.tblActividad
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objActividad = Convertir(query);
                }
                return objActividad;

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

        public Actividad Consultar(string codigo)
        {
            try
            {
                Actividad objActividad = new Actividad();

                var query = (from i in DbContext.tblActividad
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objActividad = Convertir(query);
                }
                return objActividad;

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


        public Actividad Convertir(tblActividad ActividadContext)
        {
            try
            {
                Actividad objActividad = new Actividad();
                objActividad.Id = ActividadContext.Id;
                objActividad.Codigo = ActividadContext.Codigo;
                objActividad.Nombre = ActividadContext.Nombre.ToUpper();
                objActividad.Activo = ActividadContext.Activo;
                objActividad.ObjetivoEspecifico = new ObjetivoEspecifico()
                {
                    Id = ActividadContext.tblObjetivoEspecifico.Id,
                    Codigo = ActividadContext.tblObjetivoEspecifico.Codigo,
                    Nombre = ActividadContext.tblObjetivoEspecifico.Nombre,
                    Activo = ActividadContext.tblObjetivoEspecifico.Activo,
                    Proyecto = new Proyecto()
                    {
                        Id = ActividadContext.tblObjetivoEspecifico.tblProyecto.Id,
                        AsignacionInicial = ActividadContext.tblObjetivoEspecifico.tblProyecto.AsignacionInicial,
                    }
                };
                return objActividad;
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

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DObjetivoEspecifico
    {
        private DB_SENNOVAContainer DbContext;

        public DObjetivoEspecifico()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(ObjetivoEspecifico objObjetivoEspecifico)
        {
            try
            {
                tblObjetivoEspecifico ObjetivoEspecificoContext = new tblObjetivoEspecifico();
                ObjetivoEspecificoContext.Id = objObjetivoEspecifico.Id;
                ObjetivoEspecificoContext.Codigo = objObjetivoEspecifico.Codigo;
                ObjetivoEspecificoContext.Nombre = objObjetivoEspecifico.Nombre.ToUpper();
                ObjetivoEspecificoContext.Activo = objObjetivoEspecifico.Activo;
                ObjetivoEspecificoContext.tblProyecto = DbContext.tblProyecto.Single(i => i.Id == objObjetivoEspecifico.Proyecto.Id);
                DbContext.tblObjetivoEspecifico.Add(ObjetivoEspecificoContext);
                DbContext.SaveChanges();
                return ObjetivoEspecificoContext.Id;

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

        public int Actualizar(ObjetivoEspecifico objObjetivoEspecifico)
        {
            try
            {
                tblObjetivoEspecifico objObjetivoEspecificoContext = DbContext.tblObjetivoEspecifico.First(v => v.Id == objObjetivoEspecifico.Id);
                objObjetivoEspecificoContext.Id = objObjetivoEspecifico.Id;
                objObjetivoEspecificoContext.Codigo = objObjetivoEspecifico.Codigo;
                objObjetivoEspecificoContext.Nombre = objObjetivoEspecifico.Nombre.ToUpper();
                objObjetivoEspecificoContext.Activo = objObjetivoEspecifico.Activo;
                objObjetivoEspecificoContext.tblProyecto = DbContext.tblProyecto.Single(i => i.Id == objObjetivoEspecifico.Proyecto.Id);
                DbContext.SaveChanges();
                return objObjetivoEspecificoContext.Id;
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

        public void Eliminar(ObjetivoEspecifico objObjetivoEspecifico)
        {
            try
            {
                var Accion = (from p in DbContext.tblObjetivoEspecifico
                              where p.Id == objObjetivoEspecifico.Id
                              select p).First();

                DbContext.tblObjetivoEspecifico.Remove(Accion);
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

        public List<ObjetivoEspecifico> Consultar()
        {
            try
            {
                List<ObjetivoEspecifico> lstObjetivoEspecifico = new List<ObjetivoEspecifico>();

                var query = from i in DbContext.tblObjetivoEspecifico
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstObjetivoEspecifico.Add(Convertir(item));
                    }
                }

                return lstObjetivoEspecifico;

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

        public List<ObjetivoEspecifico> ConsultarPorProyectos(int idProyecto)
        {
            try
            {
                List<ObjetivoEspecifico> lstObjetivoEspecifico = new List<ObjetivoEspecifico>();

                var query = from i in DbContext.tblObjetivoEspecifico
                            where i.tblProyecto.Id == idProyecto
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstObjetivoEspecifico.Add(Convertir(item));
                    }
                }

                return lstObjetivoEspecifico;

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

        public ObjetivoEspecifico ConsultarPorProyecto(int id)
        {
            try
            {
                ObjetivoEspecifico objObjetivoEspecifico = new ObjetivoEspecifico();

                var query = (from i in DbContext.tblObjetivoEspecifico
                             where i.tblProyecto.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objObjetivoEspecifico = Convertir(query);
                }
                return objObjetivoEspecifico;

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

        public Resultado<List<ObjetivoEspecifico>> Consultar(int top, int posicion)
        {
            try
            {

                List<ObjetivoEspecifico> lstObjetivoEspecifico = new List<ObjetivoEspecifico>();
                Resultado<List<ObjetivoEspecifico>> resultado = new Resultado<List<ObjetivoEspecifico>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblObjetivoEspecifico
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstObjetivoEspecifico.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstObjetivoEspecifico;
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

        public ObjetivoEspecifico Consultar(int id)
        {
            try
            {
                ObjetivoEspecifico objObjetivoEspecifico = new ObjetivoEspecifico();

                var query = (from i in DbContext.tblObjetivoEspecifico
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objObjetivoEspecifico = Convertir(query);
                }
                return objObjetivoEspecifico;

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

        public ObjetivoEspecifico Consultar(string codigo)
        {
            try
            {
                ObjetivoEspecifico objObjetivoEspecifico = new ObjetivoEspecifico();

                var query = (from i in DbContext.tblObjetivoEspecifico
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objObjetivoEspecifico = Convertir(query);
                }
                return objObjetivoEspecifico;

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


        public ObjetivoEspecifico Convertir(tblObjetivoEspecifico ObjetivoEspecificoContext)
        {
            try
            {
                ObjetivoEspecifico objObjetivoEspecifico = new ObjetivoEspecifico();
                objObjetivoEspecifico.Id = ObjetivoEspecificoContext.Id;
                objObjetivoEspecifico.Codigo = ObjetivoEspecificoContext.Codigo;
                objObjetivoEspecifico.Nombre = ObjetivoEspecificoContext.Nombre.ToUpper();
                objObjetivoEspecifico.Activo = ObjetivoEspecificoContext.Activo;
                objObjetivoEspecifico.Proyecto = new Proyecto()
                {
                    Id = ObjetivoEspecificoContext.tblProyecto.Id,
                    TituloProyecto = ObjetivoEspecificoContext.tblProyecto.TituloProyecto,
                    CodigoSGPS = ObjetivoEspecificoContext.tblProyecto.CodigoSGPS,
                    AnoEjecucion = ObjetivoEspecificoContext.tblProyecto.AnoEjecucion,
                    AsignacionInicial = ObjetivoEspecificoContext.tblProyecto.AsignacionInicial,
                    FechaDiligenciamiento = ObjetivoEspecificoContext.tblProyecto.FechaDiligenciamiento,
                    ObjetivoGeneral = ObjetivoEspecificoContext.tblProyecto.ObjetivoGeneral,
                };
                
                return objObjetivoEspecifico;
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

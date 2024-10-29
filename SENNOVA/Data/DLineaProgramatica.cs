using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DLineaProgramatica
    {
        private DB_SENNOVAContainer DbContext;

        public DLineaProgramatica()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(LineaProgramatica objLineaProgramatica)
        {
            try
            {
                tblLineaProgramatica LineaProgramaticaContext = new tblLineaProgramatica();
                LineaProgramaticaContext.Id = objLineaProgramatica.Id;
                LineaProgramaticaContext.Codigo = objLineaProgramatica.Codigo;
                LineaProgramaticaContext.Nombre = objLineaProgramatica.Nombre.ToUpper();
                LineaProgramaticaContext.Activo = objLineaProgramatica.Activo;
                DbContext.tblLineaProgramatica.Add(LineaProgramaticaContext);
                DbContext.SaveChanges();
                return LineaProgramaticaContext.Id;

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

        public int Actualizar(LineaProgramatica objLineaProgramatica)
        {
            try
            {
                tblLineaProgramatica objLineaProgramaticaContext = DbContext.tblLineaProgramatica.First(v => v.Id == objLineaProgramatica.Id);
                objLineaProgramaticaContext.Id = objLineaProgramatica.Id;
                objLineaProgramaticaContext.Codigo = objLineaProgramatica.Codigo;
                objLineaProgramaticaContext.Nombre = objLineaProgramatica.Nombre.ToUpper();
                objLineaProgramaticaContext.Activo = objLineaProgramatica.Activo;
                DbContext.SaveChanges();
                return objLineaProgramaticaContext.Id;
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

        public void Eliminar(LineaProgramatica objLineaProgramatica)
        {
            try
            {
                var Accion = (from p in DbContext.tblLineaProgramatica
                              where p.Id == objLineaProgramatica.Id
                              select p).First();

                DbContext.tblLineaProgramatica.Remove(Accion);
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

        public List<LineaProgramatica> Consultar()
        {
            try
            {
                List<LineaProgramatica> lstLineaProgramatica = new List<LineaProgramatica>();

                var query = from i in DbContext.tblLineaProgramatica
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstLineaProgramatica.Add(Convertir(item));
                    }
                }

                return lstLineaProgramatica;

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

        public Resultado<List<LineaProgramatica>> Consultar(int top, int posicion)
        {
            try
            {

                List<LineaProgramatica> lstLineaProgramatica = new List<LineaProgramatica>();
                Resultado<List<LineaProgramatica>> resultado = new Resultado<List<LineaProgramatica>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblLineaProgramatica
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstLineaProgramatica.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstLineaProgramatica;
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

        public LineaProgramatica Consultar(int id)
        {
            try
            {
                LineaProgramatica objLineaProgramatica = new LineaProgramatica();

                var query = (from i in DbContext.tblLineaProgramatica
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objLineaProgramatica = Convertir(query);
                }
                return objLineaProgramatica;

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

        public LineaProgramatica Consultar(string codigo)
        {
            try
            {
                LineaProgramatica objLineaProgramatica = new LineaProgramatica();

                var query = (from i in DbContext.tblLineaProgramatica
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objLineaProgramatica = Convertir(query);
                }
                return objLineaProgramatica;

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


        public LineaProgramatica Convertir(tblLineaProgramatica LineaProgramaticaContext)
        {
            try
            {
                LineaProgramatica objLineaProgramatica = new LineaProgramatica();
                objLineaProgramatica.Id = LineaProgramaticaContext.Id;
                objLineaProgramatica.Codigo = LineaProgramaticaContext.Codigo;
                objLineaProgramatica.Nombre = LineaProgramaticaContext.Nombre.ToUpper();
                objLineaProgramatica.Activo = LineaProgramaticaContext.Activo;

                return objLineaProgramatica;
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

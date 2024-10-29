using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DRubro
    {
        private DB_SENNOVAContainer DbContext;

        public DRubro()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Rubro objRubro)
        {
            try
            {
                tblRubro RubroContext = new tblRubro();
                RubroContext.Id = objRubro.Id;
                RubroContext.Codigo = objRubro.Codigo;
                RubroContext.Nombre = objRubro.Nombre.ToUpper();
                RubroContext.Activo = objRubro.Activo;
                DbContext.tblRubro.Add(RubroContext);
                DbContext.SaveChanges();
                return RubroContext.Id;

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

        public int Actualizar(Rubro objRubro)
        {
            try
            {
                tblRubro objRubroContext = DbContext.tblRubro.First(v => v.Id == objRubro.Id);
                objRubroContext.Id = objRubro.Id;
                objRubroContext.Codigo = objRubro.Codigo;
                objRubroContext.Nombre = objRubro.Nombre.ToUpper();
                objRubroContext.Activo = objRubro.Activo;
                DbContext.SaveChanges();
                return objRubroContext.Id;
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

        public void Eliminar(Rubro objRubro)
        {
            try
            {
                var Accion = (from p in DbContext.tblRubro
                              where p.Id == objRubro.Id
                              select p).First();

                DbContext.tblRubro.Remove(Accion);
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

        public List<Rubro> Consultar()
        {
            try
            {
                List<Rubro> lstRubro = new List<Rubro>();

                var query = from i in DbContext.tblRubro
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstRubro.Add(Convertir(item));
                    }
                }

                return lstRubro;

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

        public Resultado<List<Rubro>> Consultar(int top, int posicion)
        {
            try
            {

                List<Rubro> lstRubro = new List<Rubro>();
                Resultado<List<Rubro>> resultado = new Resultado<List<Rubro>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblRubro
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstRubro.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstRubro;
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

        public Rubro Consultar(int id)
        {
            try
            {
                Rubro objRubro = new Rubro();

                var query = (from i in DbContext.tblRubro
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRubro = Convertir(query);
                }
                return objRubro;

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

        public Rubro Consultar(string codigo)
        {
            try
            {
                Rubro objRubro = new Rubro();

                var query = (from i in DbContext.tblRubro
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objRubro = Convertir(query);
                }
                return objRubro;

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


        public Rubro Convertir(tblRubro RubroContext)
        {
            try
            {
                Rubro objRubro = new Rubro();
                objRubro.Id = RubroContext.Id;
                objRubro.Codigo = RubroContext.Codigo;
                objRubro.Nombre = RubroContext.Nombre.ToUpper();
                objRubro.Activo = RubroContext.Activo;

                return objRubro;
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

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DProyectoRubro
    {
        private DB_SENNOVAContainer DbContext;

        public DProyectoRubro()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(ProyectoRubro objProyectoRubro)
        {
            try
            {
                tblProyectoRubro ProyectoRubroContext = new tblProyectoRubro();
                ProyectoRubroContext.Id = objProyectoRubro.Id;
                ProyectoRubroContext.Objeto = objProyectoRubro.Objeto.ToUpper();
                ProyectoRubroContext.Valor = objProyectoRubro.Valor;
                ProyectoRubroContext.tblRubro = DbContext.tblRubro.Single(i => i.Id == objProyectoRubro.Rubro.Id);
                ProyectoRubroContext.tblProyecto = DbContext.tblProyecto.Single(i => i.Id == objProyectoRubro.Proyecto.Id);
                DbContext.tblProyectoRubro.Add(ProyectoRubroContext);
                DbContext.SaveChanges();
                return ProyectoRubroContext.Id;

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

        public int Actualizar(ProyectoRubro objProyectoRubro)
        {
            try
            {
                tblProyectoRubro objProyectoRubroContext = DbContext.tblProyectoRubro.First(v => v.Id == objProyectoRubro.Id);
                objProyectoRubroContext.Id = objProyectoRubro.Id;
                objProyectoRubroContext.Objeto = objProyectoRubro.Objeto.ToUpper();
                objProyectoRubroContext.Valor = objProyectoRubro.Valor;
                objProyectoRubroContext.tblRubro = DbContext.tblRubro.Single(i => i.Id == objProyectoRubro.Rubro.Id);
                objProyectoRubroContext.tblProyecto = DbContext.tblProyecto.Single(i => i.Id == objProyectoRubro.Proyecto.Id);

                DbContext.SaveChanges();
                return objProyectoRubroContext.Id;
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

        public void Eliminar(ProyectoRubro objProyectoRubro)
        {
            try
            {
                var Accion = (from p in DbContext.tblProyectoRubro
                              where p.Id == objProyectoRubro.Id
                              select p).First();

                DbContext.tblProyectoRubro.Remove(Accion);
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

        public ProyectoRubro ConsultarPorRubro(int id)
        {
            try
            {
                ProyectoRubro objProyectoRubro = new ProyectoRubro();

                var query = (from i in DbContext.tblProyectoRubro
                             where i.tblRubro.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProyectoRubro = Convertir(query);
                }
                return objProyectoRubro;

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

        public List<ProyectoRubro> Consultar()
        {
            try
            {
                List<ProyectoRubro> lstProyectoRubro = new List<ProyectoRubro>();

                var query = from i in DbContext.tblProyectoRubro
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstProyectoRubro.Add(Convertir(item));
                    }
                }

                return lstProyectoRubro;

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

        public Resultado<List<ProyectoRubro>> Consultar(int top, int posicion)
        {
            try
            {

                List<ProyectoRubro> lstProyectoRubro = new List<ProyectoRubro>();
                Resultado<List<ProyectoRubro>> resultado = new Resultado<List<ProyectoRubro>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblProyectoRubro
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstProyectoRubro.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstProyectoRubro;
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

        public ProyectoRubro Consultar(int id)
        {
            try
            {
                ProyectoRubro objProyectoRubro = new ProyectoRubro();

                var query = (from i in DbContext.tblProyectoRubro
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProyectoRubro = Convertir(query);
                }
                return objProyectoRubro;

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

        public ProyectoRubro Consultar(string codigo)
        {
            try
            {
                ProyectoRubro objProyectoRubro = new ProyectoRubro();

                var query = (from i in DbContext.tblProyectoRubro
                             where i.Objeto == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProyectoRubro = Convertir(query);
                }
                return objProyectoRubro;

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


        public ProyectoRubro Convertir(tblProyectoRubro ProyectoRubroContext)
        {
            try
            {
                ProyectoRubro objProyectoRubro = new ProyectoRubro();
                objProyectoRubro.Id = ProyectoRubroContext.Id;
                objProyectoRubro.Objeto = ProyectoRubroContext.Objeto.ToUpper();
                objProyectoRubro.Valor = ProyectoRubroContext.Valor;
                objProyectoRubro.Rubro = new Rubro()
                {
                    Id = ProyectoRubroContext.tblRubro.Id,
                    Codigo = ProyectoRubroContext.tblRubro.Codigo,
                    Nombre = ProyectoRubroContext.tblRubro.Nombre,
                    Activo = ProyectoRubroContext.tblRubro.Activo,
                };
                return objProyectoRubro;
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

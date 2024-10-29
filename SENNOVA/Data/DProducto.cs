using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DProducto
    {
        private DB_SENNOVAContainer DbContext;

        public DProducto()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Producto objProducto)
        {
            try
            {
                tblProducto ProductoContext = new tblProducto();
                ProductoContext.Id = objProducto.Id;
                ProductoContext.Codigo = objProducto.Codigo;
                ProductoContext.Nombre = objProducto.Nombre.ToUpper();
                ProductoContext.Activo = objProducto.Activo;
                ProductoContext.tblTipoProducto = DbContext.tblTipoProducto.Single(i => i.Id == objProducto.TipoProducto.Id);
                ProductoContext.tblActividad = DbContext.tblActividad.Single(i => i.Id == objProducto.Actividad.Id);
                DbContext.tblProducto.Add(ProductoContext);
                DbContext.SaveChanges();
                return ProductoContext.Id;

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

        public int Actualizar(Producto objProducto)
        {
            try
            {
                tblProducto objProductoContext = DbContext.tblProducto.First(v => v.Id == objProducto.Id);
                objProductoContext.Id = objProducto.Id;
                objProductoContext.Codigo = objProducto.Codigo;
                objProductoContext.Nombre = objProducto.Nombre.ToUpper();
                objProductoContext.Activo = objProducto.Activo;
                objProductoContext.tblTipoProducto = DbContext.tblTipoProducto.Single(i => i.Id == objProducto.TipoProducto.Id);
                objProductoContext.tblActividad = DbContext.tblActividad.Single(i => i.Id == objProducto.Actividad.Id);
                DbContext.SaveChanges();
                return objProductoContext.Id;
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

        public void Eliminar(Producto objProducto)
        {
            try
            {
                var Accion = (from p in DbContext.tblProducto
                              where p.Id == objProducto.Id
                              select p).First();

                DbContext.tblProducto.Remove(Accion);
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

        public List<Producto> Consultar()
        {
            try
            {
                List<Producto> lstProducto = new List<Producto>();

                var query = from i in DbContext.tblProducto
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstProducto.Add(Convertir(item));
                    }
                }

                return lstProducto;

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

        public List<Producto> ConsultarPorActividad(int idActividad)
        {
            try
            {
                List<Producto> lstProducto = new List<Producto>();

                var query = from i in DbContext.tblProducto
                            where i.tblActividad.Id == idActividad
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstProducto.Add(Convertir(item));
                    }
                }

                return lstProducto;

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

        public Producto ConsultarPorTipoProducto(int id)
        {
            try
            {
                Producto objProducto = new Producto();

                var query = (from i in DbContext.tblProducto
                             where i.tblTipoProducto.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProducto = Convertir(query);
                }
                return objProducto;

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

        public Resultado<List<Producto>> Consultar(int top, int posicion)
        {
            try
            {

                List<Producto> lstProducto = new List<Producto>();
                Resultado<List<Producto>> resultado = new Resultado<List<Producto>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblProducto
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstProducto.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstProducto;
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

        public Producto Consultar(int id)
        {
            try
            {
                Producto objProducto = new Producto();

                var query = (from i in DbContext.tblProducto
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProducto = Convertir(query);
                }
                return objProducto;

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

        public Producto Consultar(string codigo)
        {
            try
            {
                Producto objProducto = new Producto();

                var query = (from i in DbContext.tblProducto
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProducto = Convertir(query);
                }
                return objProducto;

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


        public Producto Convertir(tblProducto ProductoContext)
        {
            try
            {
                Producto objProducto = new Producto();
                objProducto.Id = ProductoContext.Id;
                objProducto.Codigo = ProductoContext.Codigo;
                objProducto.Nombre = ProductoContext.Nombre.ToUpper();
                objProducto.Activo = ProductoContext.Activo;
                objProducto.TipoProducto = new TipoProducto()
                {
                    Id = ProductoContext.tblTipoProducto.Id,
                    Codigo = ProductoContext.tblTipoProducto.Codigo,
                    Nombre = ProductoContext.tblTipoProducto.Nombre,
                    Activo = ProductoContext.tblTipoProducto.Activo,
                };
                objProducto.Actividad = new Actividad()
                {
                    Id = ProductoContext.tblActividad.Id,
                    Codigo = ProductoContext.tblActividad.Codigo,
                    Nombre = ProductoContext.tblActividad.Nombre,
                    Activo = ProductoContext.tblActividad.Activo,
                };
                return objProducto;
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

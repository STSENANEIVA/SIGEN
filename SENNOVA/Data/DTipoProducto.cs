using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DTipoProducto
    {
        private DB_SENNOVAContainer DbContext;

        public DTipoProducto()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(TipoProducto objTipoProducto)
        {
            try
            {
                tblTipoProducto TipoProductoContext = new tblTipoProducto();
                TipoProductoContext.Id = objTipoProducto.Id;
                TipoProductoContext.Codigo = objTipoProducto.Codigo;
                TipoProductoContext.Nombre = objTipoProducto.Nombre.ToUpper();
                TipoProductoContext.Activo = objTipoProducto.Activo;
                DbContext.tblTipoProducto.Add(TipoProductoContext);
                DbContext.SaveChanges();
                return TipoProductoContext.Id;

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

        public int Actualizar(TipoProducto objTipoProducto)
        {
            try
            {
                tblTipoProducto objTipoProductoContext = DbContext.tblTipoProducto.First(v => v.Id == objTipoProducto.Id);
                objTipoProductoContext.Id = objTipoProducto.Id;
                objTipoProductoContext.Codigo = objTipoProducto.Codigo;
                objTipoProductoContext.Nombre = objTipoProducto.Nombre.ToUpper();
                objTipoProductoContext.Activo = objTipoProducto.Activo;
                DbContext.SaveChanges();
                return objTipoProductoContext.Id;
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

        public void Eliminar(TipoProducto objTipoProducto)
        {
            try
            {
                var Accion = (from p in DbContext.tblTipoProducto
                              where p.Id == objTipoProducto.Id
                              select p).First();

                DbContext.tblTipoProducto.Remove(Accion);
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

        public List<TipoProducto> Consultar()
        {
            try
            {
                List<TipoProducto> lstTipoProducto = new List<TipoProducto>();

                var query = from i in DbContext.tblTipoProducto
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstTipoProducto.Add(Convertir(item));
                    }
                }

                return lstTipoProducto;

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

        public Resultado<List<TipoProducto>> Consultar(int top, int posicion)
        {
            try
            {

                List<TipoProducto> lstTipoProducto = new List<TipoProducto>();
                Resultado<List<TipoProducto>> resultado = new Resultado<List<TipoProducto>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblTipoProducto
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstTipoProducto.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstTipoProducto;
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

        public TipoProducto Consultar(int id)
        {
            try
            {
                TipoProducto objTipoProducto = new TipoProducto();

                var query = (from i in DbContext.tblTipoProducto
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoProducto = Convertir(query);
                }
                return objTipoProducto;

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

        public TipoProducto Consultar(string codigo)
        {
            try
            {
                TipoProducto objTipoProducto = new TipoProducto();

                var query = (from i in DbContext.tblTipoProducto
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objTipoProducto = Convertir(query);
                }
                return objTipoProducto;

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


        public TipoProducto Convertir(tblTipoProducto TipoProductoContext)
        {
            try
            {
                TipoProducto objTipoProducto = new TipoProducto();
                objTipoProducto.Id = TipoProductoContext.Id;
                objTipoProducto.Codigo = TipoProductoContext.Codigo;
                objTipoProducto.Nombre = TipoProductoContext.Nombre.ToUpper();
                objTipoProducto.Activo = TipoProductoContext.Activo;

                return objTipoProducto;
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

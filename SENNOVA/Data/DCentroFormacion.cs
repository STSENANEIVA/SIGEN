using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DCentroFormacion
    {
        private DB_SENNOVAContainer DbContext;

        public DCentroFormacion()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(CentroFormacion objCentroFormacion)
        {
            try
            {
                tblCentroFormacion CentroFormacionContext = new tblCentroFormacion();
                CentroFormacionContext.Id = objCentroFormacion.Id;
                CentroFormacionContext.Codigo = objCentroFormacion.Codigo;
                CentroFormacionContext.Nombre = objCentroFormacion.Nombre.ToUpper();
                CentroFormacionContext.Activo = objCentroFormacion.Activo;
                CentroFormacionContext.tblRegional = DbContext.tblRegional.Single(i => i.Id == objCentroFormacion.Regional.Id);
                DbContext.tblCentroFormacion.Add(CentroFormacionContext);
                DbContext.SaveChanges();
                return CentroFormacionContext.Id;

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

        public int Actualizar(CentroFormacion objCentroFormacion)
        {
            try
            {
                tblCentroFormacion objCentroFormacionContext = DbContext.tblCentroFormacion.First(v => v.Id == objCentroFormacion.Id);
                objCentroFormacionContext.Id = objCentroFormacion.Id;
                objCentroFormacionContext.Codigo = objCentroFormacion.Codigo;
                objCentroFormacionContext.Nombre = objCentroFormacion.Nombre.ToUpper();
                objCentroFormacionContext.Activo = objCentroFormacion.Activo;
                objCentroFormacionContext.tblRegional = DbContext.tblRegional.Single(i => i.Id == objCentroFormacion.Regional.Id);

                DbContext.SaveChanges();
                return objCentroFormacionContext.Id;
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

        public void Eliminar(CentroFormacion objCentroFormacion)
        {
            try
            {
                var Accion = (from p in DbContext.tblCentroFormacion
                              where p.Id == objCentroFormacion.Id
                              select p).First();

                DbContext.tblCentroFormacion.Remove(Accion);
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

        public List<CentroFormacion> Consultar()
        {
            try
            {
                List<CentroFormacion> lstCentroFormacion = new List<CentroFormacion>();

                var query = from i in DbContext.tblCentroFormacion
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstCentroFormacion.Add(Convertir(item));
                    }
                }

                return lstCentroFormacion;

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

        public CentroFormacion ConsultarPorRegional(int id)
        {
            try
            {
                CentroFormacion objCentroFormacion = new CentroFormacion();

                var query = (from i in DbContext.tblCentroFormacion
                             where i.tblRegional.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCentroFormacion = Convertir(query);
                }
                return objCentroFormacion;

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

        public Resultado<List<CentroFormacion>> Consultar(int top, int posicion)
        {
            try
            {

                List<CentroFormacion> lstCentroFormacion = new List<CentroFormacion>();
                Resultado<List<CentroFormacion>> resultado = new Resultado<List<CentroFormacion>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblCentroFormacion
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstCentroFormacion.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstCentroFormacion;
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

        public CentroFormacion Consultar(int id)
        {
            try
            {
                CentroFormacion objCentroFormacion = new CentroFormacion();

                var query = (from i in DbContext.tblCentroFormacion
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCentroFormacion = Convertir(query);
                }
                return objCentroFormacion;

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

        public CentroFormacion Consultar(string codigo)
        {
            try
            {
                CentroFormacion objCentroFormacion = new CentroFormacion();

                var query = (from i in DbContext.tblCentroFormacion
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCentroFormacion = Convertir(query);
                }
                return objCentroFormacion;

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


        public CentroFormacion Convertir(tblCentroFormacion CentroFormacionContext)
        {
            try
            {
                CentroFormacion objCentroFormacion = new CentroFormacion();
                objCentroFormacion.Id = CentroFormacionContext.Id;
                objCentroFormacion.Codigo = CentroFormacionContext.Codigo;
                objCentroFormacion.Nombre = CentroFormacionContext.Nombre.ToUpper();
                objCentroFormacion.Activo = CentroFormacionContext.Activo;
                objCentroFormacion.Regional = new Regional()
                {
                    Id = CentroFormacionContext.tblRegional.Id,
                    Codigo = CentroFormacionContext.tblRegional.Codigo,
                    Nombre = CentroFormacionContext.tblRegional.Nombre,
                    Activo = CentroFormacionContext.tblRegional.Activo,
                };
                return objCentroFormacion;
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

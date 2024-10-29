using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DProcedimiento
    {
        private DB_SENNOVAContainer DbContext;

        public DProcedimiento()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Procedimiento objProcedimiento)
        {
            try
            {
                tblProcedimiento ProcedimientoContext = new tblProcedimiento();
                ProcedimientoContext.Id = objProcedimiento.Id;
                ProcedimientoContext.Codigo = objProcedimiento.Codigo;
                ProcedimientoContext.Nombre = objProcedimiento.Nombre.ToUpper();
                ProcedimientoContext.Activo = objProcedimiento.Activo;
                ProcedimientoContext.tblProcesos = DbContext.tblProcesos.Single(i => i.Id == objProcedimiento.Proceso.Id);
                DbContext.tblProcedimiento.Add(ProcedimientoContext);
                DbContext.SaveChanges();
                return ProcedimientoContext.Id;

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

        public int Actualizar(Procedimiento objProcedimiento)
        {
            try
            {
                tblProcedimiento objProcedimientoContext = DbContext.tblProcedimiento.First(v => v.Id == objProcedimiento.Id);
                objProcedimientoContext.Id = objProcedimiento.Id;
                objProcedimientoContext.Codigo = objProcedimiento.Codigo;
                objProcedimientoContext.Nombre = objProcedimiento.Nombre.ToUpper();
                objProcedimientoContext.Activo = objProcedimiento.Activo;
                objProcedimientoContext.tblProcesos = DbContext.tblProcesos.Single(i => i.Id == objProcedimiento.Proceso.Id);

                DbContext.SaveChanges();
                return objProcedimientoContext.Id;
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

        public void Eliminar(Procedimiento objProcedimiento)
        {
            try
            {
                var Accion = (from p in DbContext.tblProcedimiento
                              where p.Id == objProcedimiento.Id
                              select p).First();

                DbContext.tblProcedimiento.Remove(Accion);
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

        public Procedimiento ConsultarPorProceso(int id)
        {
            try
            {
                Procedimiento objProcedimiento = new Procedimiento();

                var query = (from i in DbContext.tblProcedimiento
                             where i.tblProcesos.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProcedimiento = Convertir(query);
                }
                return objProcedimiento;

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

        public List<Procedimiento> Consultar()
        {
            try
            {
                List<Procedimiento> lstProcedimiento = new List<Procedimiento>();

                var query = from i in DbContext.tblProcedimiento
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstProcedimiento.Add(Convertir(item));
                    }
                }

                return lstProcedimiento;

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

        public Resultado<List<Procedimiento>> Consultar(int top, int posicion)
        {
            try
            {

                List<Procedimiento> lstProcedimiento = new List<Procedimiento>();
                Resultado<List<Procedimiento>> resultado = new Resultado<List<Procedimiento>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblProcedimiento
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstProcedimiento.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstProcedimiento;
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

        public Procedimiento Consultar(int id)
        {
            try
            {
                Procedimiento objProcedimiento = new Procedimiento();

                var query = (from i in DbContext.tblProcedimiento
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProcedimiento = Convertir(query);
                }
                return objProcedimiento;

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

        public Procedimiento Consultar(string codigo)
        {
            try
            {
                Procedimiento objProcedimiento = new Procedimiento();

                var query = (from i in DbContext.tblProcedimiento
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProcedimiento = Convertir(query);
                }
                return objProcedimiento;

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


        public Procedimiento Convertir(tblProcedimiento ProcedimientoContext)
        {
            try
            {
                Procedimiento objProcedimiento = new Procedimiento();
                objProcedimiento.Id = ProcedimientoContext.Id;
                objProcedimiento.Codigo = ProcedimientoContext.Codigo;
                objProcedimiento.Nombre = ProcedimientoContext.Nombre.ToUpper();
                objProcedimiento.Activo = ProcedimientoContext.Activo;
                objProcedimiento.Proceso = new Proceso()
                {
                    Id = ProcedimientoContext.tblProcesos.Id,
                    Codigo = ProcedimientoContext.tblProcesos.Codigo,
                    Nombre = ProcedimientoContext.tblProcesos.Nombre,
                    Activo = ProcedimientoContext.tblProcesos.Activo,
                };
                return objProcedimiento;
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

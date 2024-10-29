using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DProceso
    {
        private DB_SENNOVAContainer DbContext;

        public DProceso()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Proceso objProceso)
        {
            try
            {
                tblProcesos ProcesoContext = new tblProcesos();
                ProcesoContext.Id = objProceso.Id;
                ProcesoContext.Codigo = objProceso.Codigo;
                ProcesoContext.Nombre = objProceso.Nombre.ToUpper();
                ProcesoContext.Activo = objProceso.Activo;
                ProcesoContext.tblMacroProcesos = DbContext.tblMacroProcesos.Single(i => i.Id == objProceso.MacroProceso.Id);
                DbContext.tblProcesos.Add(ProcesoContext);
                DbContext.SaveChanges();
                return ProcesoContext.Id;

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

        public int Actualizar(Proceso objProceso)
        {
            try
            {
                tblProcesos objProcesoContext = DbContext.tblProcesos.First(v => v.Id == objProceso.Id);
                objProcesoContext.Id = objProceso.Id;
                objProcesoContext.Codigo = objProceso.Codigo;
                objProcesoContext.Nombre = objProceso.Nombre.ToUpper();
                objProcesoContext.Activo = objProceso.Activo;
                objProcesoContext.tblMacroProcesos = DbContext.tblMacroProcesos.Single(i => i.Id == objProceso.MacroProceso.Id);

                DbContext.SaveChanges();
                return objProcesoContext.Id;
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

        public void Eliminar(Proceso objProceso)
        {
            try
            {
                var Accion = (from p in DbContext.tblProcesos
                              where p.Id == objProceso.Id
                              select p).First();

                DbContext.tblProcesos.Remove(Accion);
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

        public Proceso ConsultarPorMacroProceso(int id)
        {
            try
            {
                Proceso objProceso = new Proceso();

                var query = (from i in DbContext.tblProcesos
                             where i.tblMacroProcesos.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProceso = Convertir(query);
                }
                return objProceso;

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

        public List<Proceso> Consultar()
        {
            try
            {
                List<Proceso> lstProceso = new List<Proceso>();

                var query = from i in DbContext.tblProcesos
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstProceso.Add(Convertir(item));
                    }
                }

                return lstProceso;

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

        public Resultado<List<Proceso>> Consultar(int top, int posicion)
        {
            try
            {

                List<Proceso> lstProceso = new List<Proceso>();
                Resultado<List<Proceso>> resultado = new Resultado<List<Proceso>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblProcesos
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstProceso.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstProceso;
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

        public Proceso Consultar(int id)
        {
            try
            {
                Proceso objProceso = new Proceso();

                var query = (from i in DbContext.tblProcesos
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProceso = Convertir(query);
                }
                return objProceso;

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

        public Proceso Consultar(string codigo)
        {
            try
            {
                Proceso objProceso = new Proceso();

                var query = (from i in DbContext.tblProcesos
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProceso = Convertir(query);
                }
                return objProceso;

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


        public Proceso Convertir(tblProcesos ProcesoContext)
        {
            try
            {
                Proceso objProceso = new Proceso();
                objProceso.Id = ProcesoContext.Id;
                objProceso.Codigo = ProcesoContext.Codigo;
                objProceso.Nombre = ProcesoContext.Nombre.ToUpper();
                objProceso.Activo = ProcesoContext.Activo;
                objProceso.MacroProceso = new MacroProceso()
                {
                    Id = ProcesoContext.tblMacroProcesos.Id,
                    Codigo = ProcesoContext.tblMacroProcesos.Codigo,
                    Nombre = ProcesoContext.tblMacroProcesos.Nombre,
                    Activo = ProcesoContext.tblMacroProcesos.Activo,
                };
                return objProceso;
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

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
   public  class DMacroProceso
    {
        private DB_SENNOVAContainer DbContext;

        public DMacroProceso()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(MacroProceso objMacroProceso)
        {
            try
            {
                tblMacroProcesos MacroProcesoContext = new tblMacroProcesos();
                MacroProcesoContext.Id = objMacroProceso.Id;
                MacroProcesoContext.Codigo = objMacroProceso.Codigo;
                MacroProcesoContext.Nombre = objMacroProceso.Nombre.ToUpper();
                MacroProcesoContext.Color = objMacroProceso.Color;
                MacroProcesoContext.Icono = objMacroProceso.Icono;
                MacroProcesoContext.Activo = objMacroProceso.Activo;
                DbContext.tblMacroProcesos.Add(MacroProcesoContext);
                DbContext.SaveChanges();
                return MacroProcesoContext.Id;

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

        public int Actualizar(MacroProceso objMacroProceso)
        {
            try
            {
                tblMacroProcesos objMacroProcesoContext = DbContext.tblMacroProcesos.First(v => v.Id == objMacroProceso.Id);
                objMacroProcesoContext.Id = objMacroProceso.Id;
                objMacroProcesoContext.Codigo = objMacroProceso.Codigo;
                objMacroProcesoContext.Nombre = objMacroProceso.Nombre.ToUpper();
                objMacroProcesoContext.Activo = objMacroProceso.Activo;
                DbContext.SaveChanges();
                return objMacroProcesoContext.Id;
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

        public void Eliminar(MacroProceso objMacroProceso)
        {
            try
            {
                var Accion = (from p in DbContext.tblMacroProcesos
                              where p.Id == objMacroProceso.Id
                              select p).First();

                DbContext.tblMacroProcesos.Remove(Accion);
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

        public List<MacroProceso> Consultar()
        {
            try
            {
                List<MacroProceso> lstMacroProceso = new List<MacroProceso>();

                var query = from i in DbContext.tblMacroProcesos
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstMacroProceso.Add(Convertir(item));
                    }
                }

                return lstMacroProceso;

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

        public Resultado<List<MacroProceso>> Consultar(int top, int posicion)
        {
            try
            {

                List<MacroProceso> lstMacroProceso = new List<MacroProceso>();
                Resultado<List<MacroProceso>> resultado = new Resultado<List<MacroProceso>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblMacroProcesos
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstMacroProceso.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstMacroProceso;
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

        public MacroProceso Consultar(int id)
        {
            try
            {
                MacroProceso objMacroProceso = new MacroProceso();

                var query = (from i in DbContext.tblMacroProcesos
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objMacroProceso = Convertir(query);
                }
                return objMacroProceso;

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

        public MacroProceso Consultar(string codigo)
        {
            try
            {
                MacroProceso objMacroProceso = new MacroProceso();

                var query = (from i in DbContext.tblMacroProcesos
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objMacroProceso = Convertir(query);
                }
                return objMacroProceso;

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


        public MacroProceso Convertir(tblMacroProcesos MacroProcesoContext)
        {
            try
            {
                MacroProceso objMacroProceso = new MacroProceso();
                objMacroProceso.Id = MacroProcesoContext.Id;
                objMacroProceso.Codigo = MacroProcesoContext.Codigo;
                objMacroProceso.Nombre = MacroProcesoContext.Nombre.ToUpper();
                objMacroProceso.Activo = MacroProcesoContext.Activo;

                return objMacroProceso;
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

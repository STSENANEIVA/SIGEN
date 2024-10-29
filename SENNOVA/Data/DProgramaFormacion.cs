using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DProgramaFormacion
    {
        private DB_SENNOVAContainer DbContext;

        public DProgramaFormacion()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(ProgramaFormacion objProgramaFormacion)
        {
            try
            {
                tblProgramaFormacion ProgramaFormacionContext = new tblProgramaFormacion();
                ProgramaFormacionContext.Id = objProgramaFormacion.Id;
                ProgramaFormacionContext.Codigo = objProgramaFormacion.Codigo;
                ProgramaFormacionContext.Nombre = objProgramaFormacion.Nombre.ToUpper();
                ProgramaFormacionContext.Activo = objProgramaFormacion.Activo;
                DbContext.tblProgramaFormacion.Add(ProgramaFormacionContext);
                DbContext.SaveChanges();
                return ProgramaFormacionContext.Id;

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

        public int Actualizar(ProgramaFormacion objProgramaFormacion)
        {
            try
            {
                tblProgramaFormacion objProgramaFormacionContext = DbContext.tblProgramaFormacion.First(v => v.Id == objProgramaFormacion.Id);
                objProgramaFormacionContext.Id = objProgramaFormacion.Id;
                objProgramaFormacionContext.Codigo = objProgramaFormacion.Codigo;
                objProgramaFormacionContext.Nombre = objProgramaFormacion.Nombre.ToUpper();
                objProgramaFormacionContext.Activo = objProgramaFormacion.Activo;
                DbContext.SaveChanges();
                return objProgramaFormacionContext.Id;
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

        public void Eliminar(ProgramaFormacion objProgramaFormacion)
        {
            try
            {
                var Accion = (from p in DbContext.tblProgramaFormacion
                              where p.Id == objProgramaFormacion.Id
                              select p).First();

                DbContext.tblProgramaFormacion.Remove(Accion);
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

        public List<ProgramaFormacion> Consultar()
        {
            try
            {
                List<ProgramaFormacion> lstProgramaFormacion = new List<ProgramaFormacion>();

                var query = from i in DbContext.tblProgramaFormacion
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstProgramaFormacion.Add(Convertir(item));
                    }
                }

                return lstProgramaFormacion;

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

        public Resultado<List<ProgramaFormacion>> Consultar(int top, int posicion)
        {
            try
            {

                List<ProgramaFormacion> lstProgramaFormacion = new List<ProgramaFormacion>();
                Resultado<List<ProgramaFormacion>> resultado = new Resultado<List<ProgramaFormacion>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblProgramaFormacion
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstProgramaFormacion.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstProgramaFormacion;
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

        public ProgramaFormacion Consultar(int id)
        {
            try
            {
                ProgramaFormacion objProgramaFormacion = new ProgramaFormacion();

                var query = (from i in DbContext.tblProgramaFormacion
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProgramaFormacion = Convertir(query);
                }
                return objProgramaFormacion;

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

        public ProgramaFormacion Consultar(string codigo)
        {
            try
            {
                ProgramaFormacion objProgramaFormacion = new ProgramaFormacion();

                var query = (from i in DbContext.tblProgramaFormacion
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objProgramaFormacion = Convertir(query);
                }
                return objProgramaFormacion;

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


        public ProgramaFormacion Convertir(tblProgramaFormacion ProgramaFormacionContext)
        {
            try
            {
                ProgramaFormacion objProgramaFormacion = new ProgramaFormacion();
                objProgramaFormacion.Id = ProgramaFormacionContext.Id;
                objProgramaFormacion.Codigo = ProgramaFormacionContext.Codigo;
                objProgramaFormacion.Nombre = ProgramaFormacionContext.Nombre.ToUpper();
                objProgramaFormacion.Activo = ProgramaFormacionContext.Activo;

                return objProgramaFormacion;
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

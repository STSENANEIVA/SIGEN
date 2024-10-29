using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DCargo
    {
        private DB_SENNOVAContainer DbContext;

        public DCargo()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Cargo objCargo)
        {
            try
            {
                tblCargo CargoContext = new tblCargo();
                CargoContext.Id = objCargo.Id;
                CargoContext.Codigo = objCargo.Codigo;
                CargoContext.Nombre = objCargo.Nombre.ToUpper();
                CargoContext.Activo = objCargo.Activo;
                DbContext.tblCargo.Add(CargoContext);
                DbContext.SaveChanges();
                return CargoContext.Id;

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

        public int Actualizar(Cargo objCargo)
        {
            try
            {
                tblCargo objCargoContext = DbContext.tblCargo.First(v => v.Id == objCargo.Id);
                objCargoContext.Id = objCargo.Id;
                objCargoContext.Codigo = objCargo.Codigo;
                objCargoContext.Nombre = objCargo.Nombre.ToUpper();
                objCargoContext.Activo = objCargo.Activo;
                DbContext.SaveChanges();
                return objCargoContext.Id;
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

        public void Eliminar(Cargo objCargo)
        {
            try
            {
                var Accion = (from p in DbContext.tblCargo
                              where p.Id == objCargo.Id
                              select p).First();

                DbContext.tblCargo.Remove(Accion);
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

        public List<Cargo> Consultar()
        {
            try
            {
                List<Cargo> lstCargo = new List<Cargo>();

                var query = from i in DbContext.tblCargo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstCargo.Add(Convertir(item));
                    }
                }

                return lstCargo;

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

        public Resultado<List<Cargo>> Consultar(int top, int posicion)
        {
            try
            {

                List<Cargo> lstCargo = new List<Cargo>();
                Resultado<List<Cargo>> resultado = new Resultado<List<Cargo>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblCargo
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstCargo.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstCargo;
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

        public Cargo Consultar(int id)
        {
            try
            {
                Cargo objCargo = new Cargo();

                var query = (from i in DbContext.tblCargo
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCargo = Convertir(query);
                }
                return objCargo;

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

        public Cargo Consultar(string codigo)
        {
            try
            {
                Cargo objCargo = new Cargo();

                var query = (from i in DbContext.tblCargo
                             where i.Codigo == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objCargo = Convertir(query);
                }
                return objCargo;

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

        public Cargo Convertir(tblCargo CargoContext)
        {
            try
            {
                Cargo objCargo = new Cargo();
                objCargo.Id = CargoContext.Id;
                objCargo.Codigo = CargoContext.Codigo;
                objCargo.Nombre = CargoContext.Nombre.ToUpper();
                objCargo.Activo = CargoContext.Activo;

                return objCargo;
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

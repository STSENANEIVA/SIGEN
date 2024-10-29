using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DComputo
    {
        private DB_SENNOVAContainer DbContext;

        public DComputo()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Computo objComputo)
        {
            try
            {
                tblComputo ComputoContext = new tblComputo();
                ComputoContext.Id = objComputo.Id;
                ComputoContext.Ip = objComputo.Ip.ToUpper();
                ComputoContext.CuentaAdmin = objComputo.CuentaAdmin;
                ComputoContext.Backup = objComputo.Backup;
                ComputoContext.Procesador = objComputo.Procesador.ToUpper();
                ComputoContext.Ram = objComputo.Ram.ToUpper();
                ComputoContext.Disco = objComputo.Disco;
                ComputoContext.Observaciones = objComputo.Observaciones;
                ComputoContext.tblEquipo = DbContext.tblEquipo.Single(i => i.Id == objComputo.Equipo.Id);
                
                if (objComputo.Impresora != null)
                {
                    ComputoContext.tblImpresora = DbContext.tblImpresora.Single(i => i.Id == objComputo.Impresora.Id);
                }
                DbContext.tblComputo.Add(ComputoContext);
                DbContext.SaveChanges();
                return ComputoContext.Id;

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

        public int Actualizar(Computo objComputo)
        {
            try
            {
                tblComputo objComputoContext = DbContext.tblComputo.First(v => v.Id == objComputo.Id);
                objComputoContext.Id = objComputo.Id;
                objComputoContext.Ip = objComputo.Ip.ToUpper();
                objComputoContext.CuentaAdmin = objComputo.CuentaAdmin;
                objComputoContext.Backup = objComputo.Backup;
                objComputoContext.Procesador = objComputo.Procesador.ToUpper();
                objComputoContext.Ram = objComputo.Ram.ToUpper();
                objComputoContext.Disco = objComputo.Disco;
                objComputoContext.Observaciones = objComputo.Observaciones;
                objComputoContext.tblEquipo = DbContext.tblEquipo.Single(i => i.Id == objComputo.Equipo.Id);
                if (objComputo.Impresora.Id != 0)
                {
                    objComputoContext.tblImpresora = DbContext.tblImpresora.Single(i => i.Id == objComputo.Impresora.Id);
                }
                DbContext.SaveChanges();
                return objComputoContext.Id;
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

        public void Eliminar(Computo objComputo)
        {
            try
            {
                var Accion = (from p in DbContext.tblComputo
                              where p.Id == objComputo.Id
                              select p).First();

                DbContext.tblComputo.Remove(Accion);
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

        public List<Computo> Consultar()
        {
            try
            {
                List<Computo> lstComputo = new List<Computo>();

                var query = from i in DbContext.tblComputo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstComputo.Add(Convertir(item));
                    }
                }

                return lstComputo;

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


        public List<Computo> ConsultarEquipo(int idEquipo)
        {
            try
            {
                List<Computo> lstComputo = new List<Computo>();

                var query = from i in DbContext.tblComputo
                            where i.tblEquipo.Id == idEquipo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstComputo.Add(Convertir(item));
                    }
                }

                return lstComputo;

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


        public Resultado<List<Computo>> Consultar(int top, int posicion)
        {
            try
            {

                List<Computo> lstComputo = new List<Computo>();
                Resultado<List<Computo>> resultado = new Resultado<List<Computo>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblComputo
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstComputo.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstComputo;
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

        public Computo Consultar(int id)
        {
            try
            {
                Computo objComputo = new Computo();

                var query = (from i in DbContext.tblComputo
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objComputo = Convertir(query);
                }
                return objComputo;

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

        public Computo ConsultarPorImpresora(int idImpresora)
        {
            try
            {
                Computo objComputo = new Computo();

                var query = (from i in DbContext.tblComputo
                             where i.tblImpresora.Id == idImpresora
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objComputo = Convertir(query);
                }
                return objComputo;

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

        public Computo Consultar(string placa)
        {
            try
            {
                Computo objComputo = new Computo();

                var query = (from i in DbContext.tblComputo
                             where i.tblEquipo.Placa == placa
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objComputo = Convertir(query);
                }
                return objComputo;

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

        public Computo ConsultarNombre(string nombre)
        {
            try
            {
                Computo objComputo = new Computo();

                var query = (from i in DbContext.tblComputo
                             where i.tblEquipo.Nombre.ToString() == nombre.Trim()
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objComputo = Convertir(query);
                }
                return objComputo;

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


        public Computo Convertir(tblComputo ComputoContext)
        {
            try
            {
                Computo objComputo = new Computo();
                objComputo.Id = ComputoContext.Id;
                objComputo.Ip = ComputoContext.Ip.ToUpper();
                objComputo.CuentaAdmin = (bool) ComputoContext.CuentaAdmin;
                objComputo.Backup = (bool)ComputoContext.Backup;
                objComputo.Procesador = ComputoContext.Procesador.ToUpper();
                objComputo.Ram = ComputoContext.Ram.ToUpper();
                objComputo.Disco = ComputoContext.Disco;
                objComputo.Observaciones = ComputoContext.Observaciones;
                objComputo.Equipo = new Equipo()
                {
                    Id = ComputoContext.tblEquipo.Id,
                    Nombre = ComputoContext.tblEquipo.Nombre,
                    Responsable = new Empleado()
                    {
                        Id = ComputoContext.tblEquipo.Responsable.Id,
                        NombreCompleto = ComputoContext.tblEquipo.Responsable.tblPersona.Nombres + " " + ComputoContext.tblEquipo.Responsable.tblPersona.Apellidos,
                    },
                    AreaTecnica = new AreaTecnica()
                    {
                        Id = ComputoContext.tblEquipo.tblAreaTecnica.Id,
                        Nombre = ComputoContext.tblEquipo.tblAreaTecnica.Nombre,
                        Activo = ComputoContext.tblEquipo.tblAreaTecnica.Activo,
                    },
                    TipoEquipo = new TipoEquipo()
                    {
                        Id = ComputoContext.tblEquipo.tblTipoEquipo.Id,
                        Nombre = ComputoContext.tblEquipo.tblTipoEquipo.Nombre,
                        Activo = ComputoContext.tblEquipo.tblTipoEquipo.Activo,
                    }
                };
                if (objComputo.Impresora != null)
                {
                    objComputo.Impresora = new Impresora()
                    {
                        Id = ComputoContext.tblImpresora.Id,
                        Nombre = ComputoContext.tblImpresora.Nombre,
                        Activo = ComputoContext.tblImpresora.Activo,
                    };
                }
               

                return objComputo;
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

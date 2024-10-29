using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DEquipoSoftware
    {
        private DB_SENNOVAContainer DbContext;

        public DEquipoSoftware()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(EquipoSoftware objEquipoSoftware)
        {
            try
            {
                tblEquipoSoftware EquipoSoftwareContext = new tblEquipoSoftware();
                EquipoSoftwareContext.tblSoftware = DbContext.tblSoftware.Single(i => i.Id == objEquipoSoftware.Software.Id);
                EquipoSoftwareContext.tblComputo = DbContext.tblComputo.Single(i => i.Id == objEquipoSoftware.Computo.Id);
                DbContext.tblEquipoSoftware.Add(EquipoSoftwareContext);
                DbContext.SaveChanges();
                return EquipoSoftwareContext.Id;

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

        public int Actualizar(EquipoSoftware objEquipoSoftware)
        {
            try
            {
                tblEquipoSoftware objEquipoSoftwareContext = DbContext.tblEquipoSoftware.First(v => v.Id == objEquipoSoftware.Id);
                objEquipoSoftwareContext.Id = objEquipoSoftware.Id;
                objEquipoSoftwareContext.tblSoftware = DbContext.tblSoftware.Single(i => i.Id == objEquipoSoftware.Software.Id);
                objEquipoSoftwareContext.tblComputo = DbContext.tblComputo.Single(i => i.Id == objEquipoSoftware.Computo.Id);

                DbContext.SaveChanges();
                return objEquipoSoftwareContext.Id;
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

        public void Eliminar(EquipoSoftware objEquipoSoftware)
        {
            try
            {
                var Accion = (from p in DbContext.tblEquipoSoftware
                              where p.Id == objEquipoSoftware.Id
                              select p).First();

                DbContext.tblEquipoSoftware.Remove(Accion);
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

        public EquipoSoftware ConsultarPorSoftware(int id)
        {
            try
            {
                EquipoSoftware objEquipoSoftware = new EquipoSoftware();

                var query = (from i in DbContext.tblEquipoSoftware
                             where i.tblSoftware.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipoSoftware = Convertir(query);
                }
                return objEquipoSoftware;

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

        public List<EquipoSoftware> ConsultarEquipo(int idcomputo)
        {
            try
            {
                List<EquipoSoftware> lstEquipoSoftware = new List<EquipoSoftware>();

                var query = from i in DbContext.tblEquipoSoftware
                            where i.tblComputo.Id == idcomputo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstEquipoSoftware.Add(Convertir(item));
                    }
                }

                return lstEquipoSoftware;

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

        public List<EquipoSoftware> Consultar()
        {
            try
            {
                List<EquipoSoftware> lstEquipoSoftware = new List<EquipoSoftware>();

                var query = from i in DbContext.tblEquipoSoftware
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstEquipoSoftware.Add(Convertir(item));
                    }
                }

                return lstEquipoSoftware;

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

        public Resultado<List<EquipoSoftware>> Consultar(int top, int posicion)
        {
            try
            {

                List<EquipoSoftware> lstEquipoSoftware = new List<EquipoSoftware>();
                Resultado<List<EquipoSoftware>> resultado = new Resultado<List<EquipoSoftware>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblEquipoSoftware
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstEquipoSoftware.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstEquipoSoftware;
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

        public EquipoSoftware Consultar(int id)
        {
            try
            {
                EquipoSoftware objEquipoSoftware = new EquipoSoftware();

                var query = (from i in DbContext.tblEquipoSoftware
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipoSoftware = Convertir(query);
                }
                return objEquipoSoftware;

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

        public EquipoSoftware Convertir(tblEquipoSoftware EquipoSoftwareContext)
        {
            try
            {
                EquipoSoftware objEquipoSoftware = new EquipoSoftware();
                objEquipoSoftware.Id = EquipoSoftwareContext.Id;
                objEquipoSoftware.Software = new Software()
                {
                    Id = EquipoSoftwareContext.tblSoftware.Id,
                    Codigo = EquipoSoftwareContext.tblSoftware.Codigo,
                    Nombre = EquipoSoftwareContext.tblSoftware.Nombre,
                    Version = EquipoSoftwareContext.tblSoftware.Version,
                    Activo = EquipoSoftwareContext.tblSoftware.Activo,
                    TipoLicencia = new TipoLicencia()
                    {
                        Id = EquipoSoftwareContext.tblSoftware.tblTipoLicencia.Id,
                        Codigo = EquipoSoftwareContext.tblSoftware.tblTipoLicencia.Codigo,
                        Nombre = EquipoSoftwareContext.tblSoftware.tblTipoLicencia.Nombre,
                        Activo = EquipoSoftwareContext.tblSoftware.tblTipoLicencia.Activo,
                    },
                };
                objEquipoSoftware.Computo = new Computo()
                {
                    Id = EquipoSoftwareContext.tblComputo.Id,
                    Ip = EquipoSoftwareContext.tblComputo.Ip,
                    CuentaAdmin = (bool)EquipoSoftwareContext.tblComputo.CuentaAdmin,
                    Backup = (bool)EquipoSoftwareContext.tblComputo.Backup,
                    Procesador = EquipoSoftwareContext.tblComputo.Procesador,
                    Ram = EquipoSoftwareContext.tblComputo.Ram,
                    Disco = EquipoSoftwareContext.tblComputo.Disco,
                    Observaciones = EquipoSoftwareContext.tblComputo.Observaciones,
                    Equipo = new Equipo()
                    {
                        Id = EquipoSoftwareContext.tblComputo.tblEquipo.Id,
                        Nombre = EquipoSoftwareContext.tblComputo.tblEquipo.Nombre,
                        Placa = EquipoSoftwareContext.tblComputo.tblEquipo.Placa,
                        Serial = EquipoSoftwareContext.tblComputo.tblEquipo.Serial,
                        Marca = EquipoSoftwareContext.tblComputo.tblEquipo.Marca,
                        TipoEquipo = new TipoEquipo()
                        {
                            Id = EquipoSoftwareContext.tblComputo.tblEquipo.tblTipoEquipo.Id,
                            Codigo = EquipoSoftwareContext.tblComputo.tblEquipo.tblTipoEquipo.Codigo,
                            Nombre = EquipoSoftwareContext.tblComputo.tblEquipo.tblTipoEquipo.Nombre,
                            Activo = EquipoSoftwareContext.tblComputo.tblEquipo.tblTipoEquipo.Activo,
                        }
                    },
                };
                return objEquipoSoftware;
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

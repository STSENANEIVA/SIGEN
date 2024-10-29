using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DEquipoAccesorio
    {
        private DB_SENNOVAContainer DbContext;

        public DEquipoAccesorio()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(EquipoAccesorio objEquipoAccesorio)
        {
            try
            {
                tblEquipoAccesorio EquipoAccesorioContext = new tblEquipoAccesorio();
                EquipoAccesorioContext.tblAccesorios = DbContext.tblAccesorios.Single(i => i.Id == objEquipoAccesorio.Accesorios.Id);
                EquipoAccesorioContext.tblEquipo = DbContext.tblEquipo.Single(i => i.Id == objEquipoAccesorio.Equipo.Id);
                DbContext.tblEquipoAccesorio.Add(EquipoAccesorioContext);
                DbContext.SaveChanges();
                return EquipoAccesorioContext.Id;

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

        public int Actualizar(EquipoAccesorio objEquipoAccesorio)
        {
            try
            {
                tblEquipoAccesorio objEquipoAccesorioContext = DbContext.tblEquipoAccesorio.First(v => v.Id == objEquipoAccesorio.Id);
                objEquipoAccesorioContext.Id = objEquipoAccesorio.Id;
                objEquipoAccesorioContext.tblAccesorios = DbContext.tblAccesorios.Single(i => i.Id == objEquipoAccesorio.Accesorios.Id);
                objEquipoAccesorioContext.tblEquipo = DbContext.tblEquipo.Single(i => i.Id == objEquipoAccesorio.Equipo.Id);

                DbContext.SaveChanges();
                return objEquipoAccesorioContext.Id;
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

        public void Eliminar(EquipoAccesorio objEquipoAccesorio)
        {
            try
            {
                var Accion = (from p in DbContext.tblEquipoAccesorio
                              where p.Id == objEquipoAccesorio.Id
                              select p).First();

                DbContext.tblEquipoAccesorio.Remove(Accion);
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

        public EquipoAccesorio ConsultarPorAccesorio(int id)
        {
            try
            {
                EquipoAccesorio objEquipoAccesorio = new EquipoAccesorio();

                var query = (from i in DbContext.tblEquipoAccesorio
                             where i.tblAccesorios.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipoAccesorio = Convertir(query);
                }
                return objEquipoAccesorio;

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

        public List<EquipoAccesorio> Consultar()
        {
            try
            {
                List<EquipoAccesorio> lstEquipoAccesorio = new List<EquipoAccesorio>();

                var query = from i in DbContext.tblEquipoAccesorio
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstEquipoAccesorio.Add(Convertir(item));
                    }
                }

                return lstEquipoAccesorio;

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

        public List<EquipoAccesorio> ConsultarEquipo(int idEquipo)
        {
            try
            {
                List<EquipoAccesorio> lstEquipoAccesorio = new List<EquipoAccesorio>();

                var query = from i in DbContext.tblEquipoAccesorio
                            where i.tblEquipo.Id == idEquipo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstEquipoAccesorio.Add(Convertir(item));
                    }
                }

                return lstEquipoAccesorio;

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

        public Resultado<List<EquipoAccesorio>> Consultar(int top, int posicion)
        {
            try
            {

                List<EquipoAccesorio> lstEquipoAccesorio = new List<EquipoAccesorio>();
                Resultado<List<EquipoAccesorio>> resultado = new Resultado<List<EquipoAccesorio>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblEquipoAccesorio
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstEquipoAccesorio.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstEquipoAccesorio;
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

        public EquipoAccesorio Consultar(int id)
        {
            try
            {
                EquipoAccesorio objEquipoAccesorio = new EquipoAccesorio();

                var query = (from i in DbContext.tblEquipoAccesorio
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipoAccesorio = Convertir(query);
                }
                return objEquipoAccesorio;

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

        public EquipoAccesorio Convertir(tblEquipoAccesorio EquipoAccesorioContext)
        {
            try
            {
                EquipoAccesorio objEquipoAccesorio = new EquipoAccesorio();
                objEquipoAccesorio.Id = EquipoAccesorioContext.Id;
                objEquipoAccesorio.Accesorios = new Accesorios()
                {
                    Id = EquipoAccesorioContext.tblAccesorios.Id,
                    Codigo = EquipoAccesorioContext.tblAccesorios.Codigo,
                    Nombre = EquipoAccesorioContext.tblAccesorios.Nombre,
                    Descripcion = EquipoAccesorioContext.tblAccesorios.Descripcion,
                    Activo = EquipoAccesorioContext.tblAccesorios.Activo,
                };
                objEquipoAccesorio.Equipo = new Equipo()
                {
                    Id = EquipoAccesorioContext.tblEquipo.Id,
                    Nombre = EquipoAccesorioContext.tblEquipo.Nombre,
                    Responsable = new Empleado()
                    {
                        Id = EquipoAccesorioContext.tblEquipo.Responsable.Id,
                        NombreCompleto = EquipoAccesorioContext.tblEquipo.Responsable.tblPersona.Nombres + " " + EquipoAccesorioContext.tblEquipo.Responsable.tblPersona.Apellidos,
                    },
                    AreaTecnica = new AreaTecnica()
                    {
                        Id = EquipoAccesorioContext.tblEquipo.tblAreaTecnica.Id,
                        Nombre = EquipoAccesorioContext.tblEquipo.tblAreaTecnica.Nombre,
                        Activo = EquipoAccesorioContext.tblEquipo.tblAreaTecnica.Activo,
                    },
                    TipoEquipo = new TipoEquipo()
                    {
                        Id = EquipoAccesorioContext.tblEquipo.tblTipoEquipo.Id,
                        Nombre = EquipoAccesorioContext.tblEquipo.tblTipoEquipo.Nombre,
                        Activo = EquipoAccesorioContext.tblEquipo.tblTipoEquipo.Activo,
                    }
                };
                return objEquipoAccesorio;
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

using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DEquipoTecnico
    {
        private DB_SENNOVAContainer DbContext;

        public DEquipoTecnico()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(EquipoTecnico objEquipoTecnico)
        {
            try
            {
                tblEquipoTecnico EquipoTecnicoContext = new tblEquipoTecnico();
                EquipoTecnicoContext.Id = objEquipoTecnico.Id;
                EquipoTecnicoContext.ClaseEquipo = objEquipoTecnico.ClaseEquipo;
                EquipoTecnicoContext.Caracteristicas = objEquipoTecnico.Caracteristicas;
                EquipoTecnicoContext.Aire = objEquipoTecnico.Aire;
                EquipoTecnicoContext.Electricidad = objEquipoTecnico.Electricidad;
                EquipoTecnicoContext.Gas = objEquipoTecnico.Gas;
                EquipoTecnicoContext.Aceite = objEquipoTecnico.Aceite;
                EquipoTecnicoContext.Otros = objEquipoTecnico.Otros;
                EquipoTecnicoContext.PresionAire = objEquipoTecnico.PresionAire;
                EquipoTecnicoContext.Caudal = objEquipoTecnico.Caudal;
                EquipoTecnicoContext.Voltaje = objEquipoTecnico.Voltaje;
                EquipoTecnicoContext.Amperaje = objEquipoTecnico.Amperaje;
                EquipoTecnicoContext.Potencia = objEquipoTecnico.Potencia;
                EquipoTecnicoContext.TipoGas = objEquipoTecnico.TipoGas;
                EquipoTecnicoContext.PresionGas = objEquipoTecnico.PresionGas;
                EquipoTecnicoContext.TipoAceite = objEquipoTecnico.TipoAceite;
                EquipoTecnicoContext.Especifique = objEquipoTecnico.Especifique;
                EquipoTecnicoContext.Observaciones = objEquipoTecnico.Observaciones;
                EquipoTecnicoContext.tblEquipo = DbContext.tblEquipo.Single(i => i.Id == objEquipoTecnico.Equipo.Id);
                EquipoTecnicoContext.tblTipoPatron = DbContext.tblTipoPatron.Single(i => i.Id == objEquipoTecnico.TipoPatron.Id);

                DbContext.tblEquipoTecnico.Add(EquipoTecnicoContext);
                DbContext.SaveChanges();
                return EquipoTecnicoContext.Id;

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

        public int Actualizar(EquipoTecnico objEquipoTecnico)
        {
            try
            {
                tblEquipoTecnico objEquipoTecnicoContext = DbContext.tblEquipoTecnico.First(v => v.Id == objEquipoTecnico.Id);
                objEquipoTecnicoContext.ClaseEquipo = objEquipoTecnico.ClaseEquipo;
                objEquipoTecnicoContext.Caracteristicas = objEquipoTecnico.Caracteristicas;
                objEquipoTecnicoContext.Aire = objEquipoTecnico.Aire;
                objEquipoTecnicoContext.Electricidad = objEquipoTecnico.Electricidad;
                objEquipoTecnicoContext.Gas = objEquipoTecnico.Gas;
                objEquipoTecnicoContext.Aceite = objEquipoTecnico.Aceite;
                objEquipoTecnicoContext.Otros = objEquipoTecnico.Otros;
                objEquipoTecnicoContext.PresionAire = objEquipoTecnico.PresionAire;
                objEquipoTecnicoContext.Caudal = objEquipoTecnico.Caudal;
                objEquipoTecnicoContext.Voltaje = objEquipoTecnico.Voltaje;
                objEquipoTecnicoContext.Amperaje = objEquipoTecnico.Amperaje;
                objEquipoTecnicoContext.Potencia = objEquipoTecnico.Potencia;
                objEquipoTecnicoContext.TipoGas = objEquipoTecnico.TipoGas;
                objEquipoTecnicoContext.PresionGas = objEquipoTecnico.PresionGas;
                objEquipoTecnicoContext.TipoAceite = objEquipoTecnico.TipoAceite;
                objEquipoTecnicoContext.Especifique = objEquipoTecnico.Especifique;
                objEquipoTecnicoContext.Observaciones = objEquipoTecnico.Observaciones;
                objEquipoTecnicoContext.tblEquipo = DbContext.tblEquipo.Single(i => i.Id == objEquipoTecnico.Equipo.Id);
                objEquipoTecnicoContext.tblTipoPatron = DbContext.tblTipoPatron.Single(i => i.Id == objEquipoTecnico.TipoPatron.Id);
                DbContext.SaveChanges();
                return objEquipoTecnicoContext.Id;
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

        public void Eliminar(EquipoTecnico objEquipoTecnico)
        {
            try
            {
                var Accion = (from p in DbContext.tblEquipoTecnico
                              where p.Id == objEquipoTecnico.Id
                              select p).First();

                DbContext.tblEquipoTecnico.Remove(Accion);
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

        public List<EquipoTecnico> Consultar()
        {
            try
            {
                List<EquipoTecnico> lstEquipoTecnico = new List<EquipoTecnico>();

                var query = from i in DbContext.tblEquipoTecnico
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstEquipoTecnico.Add(Convertir(item));
                    }
                }

                return lstEquipoTecnico;

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

        public List<EquipoTecnico> ConsultarEquipo(int idEquipo)
        {
            try
            {
                List<EquipoTecnico> lstEquipoTecnico = new List<EquipoTecnico>();

                var query = from i in DbContext.tblEquipoTecnico
                            where i.tblEquipo.Id == idEquipo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstEquipoTecnico.Add(Convertir(item));
                    }
                }

                return lstEquipoTecnico;

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

        public Resultado<List<EquipoTecnico>> Consultar(int top, int posicion)
        {
            try
            {

                List<EquipoTecnico> lstEquipoTecnico = new List<EquipoTecnico>();
                Resultado<List<EquipoTecnico>> resultado = new Resultado<List<EquipoTecnico>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblEquipoTecnico
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstEquipoTecnico.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstEquipoTecnico;
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

        public EquipoTecnico Consultar(int id)
        {
            try
            {
                EquipoTecnico objEquipoTecnico = new EquipoTecnico();

                var query = (from i in DbContext.tblEquipoTecnico
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipoTecnico = Convertir(query);
                }
                return objEquipoTecnico;

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

        public EquipoTecnico ConsultarPorTipoPatron(int idTipoPatron)
        {
            try
            {
                EquipoTecnico objEquipoTecnico = new EquipoTecnico();

                var query = (from i in DbContext.tblEquipoTecnico
                             where i.tblTipoPatron.Id == idTipoPatron
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipoTecnico = Convertir(query);
                }
                return objEquipoTecnico;

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

        public EquipoTecnico Consultar(string placa)
        {
            try
            {
                EquipoTecnico objEquipoTecnico = new EquipoTecnico();

                var query = (from i in DbContext.tblEquipoTecnico
                             where i.tblEquipo.Placa == placa
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipoTecnico = Convertir(query);
                }
                return objEquipoTecnico;

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

        public EquipoTecnico ConsultarNombre(string nombre)
        {
            try
            {
                EquipoTecnico objEquipoTecnico = new EquipoTecnico();

                var query = (from i in DbContext.tblEquipoTecnico
                             where i.tblEquipo.Nombre.ToString() == nombre.Trim()
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipoTecnico = Convertir(query);
                }
                return objEquipoTecnico;

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

        public EquipoTecnico Convertir(tblEquipoTecnico EquipoTecnicoContext)
        {
            try
            {
                EquipoTecnico objEquipoTecnico = new EquipoTecnico();
                objEquipoTecnico.Id = EquipoTecnicoContext.Id;
                objEquipoTecnico.ClaseEquipo = objEquipoTecnico.ClaseEquipo;
                objEquipoTecnico.Caracteristicas = objEquipoTecnico.Caracteristicas;
                objEquipoTecnico.Aire = objEquipoTecnico.Aire;
                objEquipoTecnico.Electricidad = objEquipoTecnico.Electricidad;
                objEquipoTecnico.Gas = objEquipoTecnico.Gas;
                objEquipoTecnico.Aceite = objEquipoTecnico.Aceite;
                objEquipoTecnico.Otros = objEquipoTecnico.Otros;
                objEquipoTecnico.PresionAire = objEquipoTecnico.PresionAire;
                objEquipoTecnico.Caudal = objEquipoTecnico.Caudal;
                objEquipoTecnico.Voltaje = objEquipoTecnico.Voltaje;
                objEquipoTecnico.Amperaje = objEquipoTecnico.Amperaje;
                objEquipoTecnico.Potencia = objEquipoTecnico.Potencia;
                objEquipoTecnico.TipoGas = objEquipoTecnico.TipoGas;
                objEquipoTecnico.PresionGas = objEquipoTecnico.PresionGas;
                objEquipoTecnico.TipoAceite = objEquipoTecnico.TipoAceite;
                objEquipoTecnico.Especifique = objEquipoTecnico.Especifique;
                objEquipoTecnico.Observaciones = EquipoTecnicoContext.Observaciones;

                objEquipoTecnico.Equipo = new Equipo()
                {
                    Id = EquipoTecnicoContext.tblEquipo.Id,
                    Nombre = EquipoTecnicoContext.tblEquipo.Nombre,
                    Responsable = new Empleado()
                    {
                        Id = EquipoTecnicoContext.tblEquipo.Responsable.Id,
                        NombreCompleto = EquipoTecnicoContext.tblEquipo.Responsable.tblPersona.Nombres + " " + EquipoTecnicoContext.tblEquipo.Responsable.tblPersona.Apellidos,
                    },
                    AreaTecnica = new AreaTecnica()
                    {
                        Id = EquipoTecnicoContext.tblEquipo.tblAreaTecnica.Id,
                        Nombre = EquipoTecnicoContext.tblEquipo.tblAreaTecnica.Nombre,
                        Activo = EquipoTecnicoContext.tblEquipo.tblAreaTecnica.Activo,
                    },
                    TipoEquipo = new TipoEquipo()
                    {
                        Id = EquipoTecnicoContext.tblEquipo.tblTipoEquipo.Id,
                        Nombre = EquipoTecnicoContext.tblEquipo.tblTipoEquipo.Nombre,
                        Activo = EquipoTecnicoContext.tblEquipo.tblTipoEquipo.Activo,
                    }
                };

                if (objEquipoTecnico.TipoPatron != null)
                {
                    objEquipoTecnico.TipoPatron = new TipoPatron()
                    {
                        Id = EquipoTecnicoContext.tblTipoPatron.Id,
                        Nombre = EquipoTecnicoContext.tblTipoPatron.Nombre,
                        Activo = EquipoTecnicoContext.tblTipoPatron.Activo,
                    };
                }

                return objEquipoTecnico;
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

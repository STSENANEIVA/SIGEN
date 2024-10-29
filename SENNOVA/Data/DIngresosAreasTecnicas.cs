using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DIngresosAreasTecnicas
    {
        private DB_SENNOVAContainer DbContext;

        public DIngresosAreasTecnicas()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(IngresosAreasTecnicas objIngresosAreasTecnicas)
        {
            try
            {
                tblIngresosAreasTecnicas IngresosAreasTecnicasContext = new tblIngresosAreasTecnicas();
                IngresosAreasTecnicasContext.tblAreaTecnica = DbContext.tblAreaTecnica.Single(i => i.Id == objIngresosAreasTecnicas.AreaTecnica.Id);
                IngresosAreasTecnicasContext.tblIngreso = DbContext.tblIngreso.Single(i => i.Id == objIngresosAreasTecnicas.Ingreso.Id);
                DbContext.tblIngresosAreasTecnicas.Add(IngresosAreasTecnicasContext);
                DbContext.SaveChanges();
                return IngresosAreasTecnicasContext.Id;

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

        public int Actualizar(IngresosAreasTecnicas objIngresosAreasTecnicas)
        {
            try
            {
                tblIngresosAreasTecnicas objIngresosAreasTecnicasContext = DbContext.tblIngresosAreasTecnicas.First(v => v.Id == objIngresosAreasTecnicas.Id);
                objIngresosAreasTecnicasContext.Id = objIngresosAreasTecnicas.Id;
                objIngresosAreasTecnicasContext.tblAreaTecnica = DbContext.tblAreaTecnica.Single(i => i.Id == objIngresosAreasTecnicas.AreaTecnica.Id);
                objIngresosAreasTecnicasContext.tblIngreso = DbContext.tblIngreso.Single(i => i.Id == objIngresosAreasTecnicas.Ingreso.Id);

                DbContext.SaveChanges();
                return objIngresosAreasTecnicasContext.Id;
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

        public void Eliminar(IngresosAreasTecnicas objIngresosAreasTecnicas)
        {
            try
            {
                var Accion = (from p in DbContext.tblIngresosAreasTecnicas
                              where p.Id == objIngresosAreasTecnicas.Id
                              select p).First();

                DbContext.tblIngresosAreasTecnicas.Remove(Accion);
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

        public IngresosAreasTecnicas ConsultarPorAreaTecnica(int id)
        {
            try
            {
                IngresosAreasTecnicas objIngresosAreasTecnicas = new IngresosAreasTecnicas();

                var query = (from i in DbContext.tblIngresosAreasTecnicas
                             where i.tblAreaTecnica.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objIngresosAreasTecnicas = Convertir(query);
                }
                return objIngresosAreasTecnicas;

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

        public List<IngresosAreasTecnicas> Consultar()
        {
            try
            {
                List<IngresosAreasTecnicas> lstIngresosAreasTecnicas = new List<IngresosAreasTecnicas>();

                var query = from i in DbContext.tblIngresosAreasTecnicas
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstIngresosAreasTecnicas.Add(Convertir(item));
                    }
                }

                return lstIngresosAreasTecnicas;

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

        public Resultado<List<IngresosAreasTecnicas>> Consultar(int top, int posicion)
        {
            try
            {

                List<IngresosAreasTecnicas> lstIngresosAreasTecnicas = new List<IngresosAreasTecnicas>();
                Resultado<List<IngresosAreasTecnicas>> resultado = new Resultado<List<IngresosAreasTecnicas>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblIngresosAreasTecnicas
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstIngresosAreasTecnicas.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstIngresosAreasTecnicas;
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

        public IngresosAreasTecnicas Consultar(int id)
        {
            try
            {
                IngresosAreasTecnicas objIngresosAreasTecnicas = new IngresosAreasTecnicas();

                var query = (from i in DbContext.tblIngresosAreasTecnicas
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objIngresosAreasTecnicas = Convertir(query);
                }
                return objIngresosAreasTecnicas;

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

        public IngresosAreasTecnicas Convertir(tblIngresosAreasTecnicas IngresosAreasTecnicasContext)
        {
            try
            {
                IngresosAreasTecnicas objIngresosAreasTecnicas = new IngresosAreasTecnicas();
                objIngresosAreasTecnicas.Id = IngresosAreasTecnicasContext.Id;
                objIngresosAreasTecnicas.AreaTecnica = new AreaTecnica()
                {
                    Id = IngresosAreasTecnicasContext.tblAreaTecnica.Id,
                    Codigo = IngresosAreasTecnicasContext.tblAreaTecnica.Codigo,
                    Nombre = IngresosAreasTecnicasContext.tblAreaTecnica.Nombre,
                    Activo = IngresosAreasTecnicasContext.tblAreaTecnica.Activo,
                };
                objIngresosAreasTecnicas.Ingreso = new Ingreso()
                {
                    Id = IngresosAreasTecnicasContext.tblIngreso.Id,
                    Fecha = IngresosAreasTecnicasContext.tblIngreso.Fecha,
                    PoliticaDatos = (bool)IngresosAreasTecnicasContext.tblIngreso.PoliticaDatos,
                    Ficha = IngresosAreasTecnicasContext.tblIngreso.Ficha,
                    Visitante = new Visitante()
                    {
                        Id = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.Id,
                        Persona = new Persona()
                        {
                            Id = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblPersona.Id,
                            Codigo = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblPersona.Codigo,
                            Nombres = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblPersona.Nombres,
                            Apellidos = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblPersona.Apellidos,
                            NombreCompleto = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblPersona.Nombres + " " + IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblPersona.Apellidos,
                            Telefono = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblPersona.Telefono,
                            Email = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblPersona.Email,
                        },
                        TipoVisitante = new TipoVisitante()
                        {
                            Id = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblTipoVisitante.Id,
                            Codigo = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblTipoVisitante.Codigo,
                            Nombre = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblTipoVisitante.Nombre,
                            Activo = IngresosAreasTecnicasContext.tblIngreso.tblVisitante.tblTipoVisitante.Activo,
                        }
                    },
                    Empresa = new Empresa()
                    {
                        Id = IngresosAreasTecnicasContext.tblIngreso.tblEmpresa.Id,
                        RazonSocial = IngresosAreasTecnicasContext.tblIngreso.tblEmpresa.RazonSocial,
                    },

                };
                if (IngresosAreasTecnicasContext.tblIngreso.tblProgramaFormacion != null)
                {
                    objIngresosAreasTecnicas.Ingreso.ProgramaFormacion = new ProgramaFormacion()
                    {
                        Id = IngresosAreasTecnicasContext.tblIngreso.tblProgramaFormacion.Id,
                        Nombre = IngresosAreasTecnicasContext.tblIngreso.tblProgramaFormacion.Nombre,
                    };
                }
                return objIngresosAreasTecnicas;
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

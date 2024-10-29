using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Data
{
    public class DEquipo
    {
        private DB_SENNOVAContainer DbContext;

        public DEquipo()
        {
            DbContext = new DB_SENNOVAContainer();
        }

        public int Guardar(Equipo objEquipo)
        {
            try
            {
                tblEquipo EquipoContext = new tblEquipo();
                EquipoContext.Id = objEquipo.Id;
                EquipoContext.Placa = objEquipo.Placa.ToUpper();
                EquipoContext.Nombre = objEquipo.Nombre.ToUpper();
                EquipoContext.Serial = objEquipo.Serial.ToUpper();
                EquipoContext.Marca = objEquipo.Marca.ToUpper();
                EquipoContext.Estado = objEquipo.Estado.ToUpper();
                EquipoContext.FechaCompra = objEquipo.FechaCompra;
                EquipoContext.Valor = objEquipo.Valor;
                EquipoContext.NumeroContrato = objEquipo.NumeroContrato.ToUpper();
                EquipoContext.FechaFuncionamiento = objEquipo.FechaFuncionamiento;
                EquipoContext.tblTipoEquipo = DbContext.tblTipoEquipo.Single(i => i.Id == objEquipo.TipoEquipo.Id);
                EquipoContext.Responsable = DbContext.tblEmpleado.Single(i => i.Id == objEquipo.Responsable.Id);
                EquipoContext.tblAreaTecnica = DbContext.tblAreaTecnica.Single(i => i.Id == objEquipo.AreaTecnica.Id);
                DbContext.tblEquipo.Add(EquipoContext);
                DbContext.SaveChanges();
                return EquipoContext.Id;

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

        public int Actualizar(Equipo objEquipo)
        {
            try
            {
                tblEquipo objEquipoContext = DbContext.tblEquipo.First(v => v.Id == objEquipo.Id);
                objEquipoContext.Id = objEquipo.Id;
                objEquipoContext.Placa = objEquipo.Placa;
                objEquipoContext.Nombre = objEquipo.Nombre.ToUpper();
                objEquipoContext.Serial = objEquipo.Serial.ToUpper();
                objEquipoContext.Placa = objEquipo.Placa.ToUpper();
                objEquipoContext.Marca = objEquipo.Marca.ToUpper();
                objEquipoContext.Estado = objEquipo.Estado.ToUpper();
                objEquipoContext.FechaCompra = objEquipo.FechaCompra;
                objEquipoContext.Valor = objEquipo.Valor;
                objEquipoContext.NumeroContrato = objEquipo.NumeroContrato.ToUpper();
                objEquipoContext.FechaFuncionamiento = objEquipo.FechaFuncionamiento;
                objEquipoContext.tblTipoEquipo = DbContext.tblTipoEquipo.Single(i => i.Id == objEquipo.TipoEquipo.Id);
                objEquipoContext.Responsable = DbContext.tblEmpleado.Single(i => i.Id == objEquipo.Responsable.Id);
                objEquipoContext.tblAreaTecnica = DbContext.tblAreaTecnica.Single(i => i.Id == objEquipo.AreaTecnica.Id);
                DbContext.SaveChanges();
                return objEquipoContext.Id;
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

        public void Eliminar(Equipo objEquipo)
        {
            try
            {
                var Accion = (from p in DbContext.tblEquipo
                              where p.Id == objEquipo.Id
                              select p).First();

                DbContext.tblEquipo.Remove(Accion);
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

        public List<Equipo> Consultar()
        {
            try
            {
                List<Equipo> lstEquipo = new List<Equipo>();

                var query = from i in DbContext.tblEquipo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstEquipo.Add(Convertir(item));
                    }
                }

                return lstEquipo;

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

        public Equipo ConsultarPorAreaTecnica(int idAreaTecnica)
        {
            try
            {
                Equipo objEquipo = new Equipo();

                var query = (from i in DbContext.tblEquipo
                             where i.tblAreaTecnica.Id == idAreaTecnica
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipo = Convertir(query);
                }
                return objEquipo;

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

        public List<Equipo> ConsultarTipoEquipo(int idTipoEquipo)
        {
            try
            {
                List<Equipo> lstEquipo = new List<Equipo>();

                var query = from i in DbContext.tblEquipo
                            where i.tblTipoEquipo.Id == idTipoEquipo
                            select i;

                if (query != null)
                {
                    foreach (var item in query)
                    {
                        lstEquipo.Add(Convertir(item));
                    }
                }

                return lstEquipo;

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


        public Resultado<List<Equipo>> Consultar(int top, int posicion)
        {
            try
            {

                List<Equipo> lstEquipo = new List<Equipo>();
                Resultado<List<Equipo>> resultado = new Resultado<List<Equipo>>();

                int index = posicion == 0 ? posicion : posicion * top;
                var query = (from i in DbContext.tblEquipo
                             select i).OrderBy(z => z.Id);

                int count = query.Count();
                var queryFiltrado = query.Skip(index).Take(top).ToList();

                if (queryFiltrado != null)
                {
                    foreach (var item in queryFiltrado)
                    {
                        lstEquipo.Add(Convertir(item));
                    }
                }
                resultado.count = count;
                resultado.data = lstEquipo;
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

        public Equipo Consultar(int id)
        {
            try
            {
                Equipo objEquipo = new Equipo();

                var query = (from i in DbContext.tblEquipo
                             where i.Id == id
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipo = Convertir(query);
                }
                return objEquipo;

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

        public Equipo Consultar(string codigo)
        {
            try
            {
                Equipo objEquipo = new Equipo();

                var query = (from i in DbContext.tblEquipo
                             where i.Placa == codigo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipo = Convertir(query);
                }
                return objEquipo;

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

        public Equipo ConsultarNombre(string nombre)
        {
            try
            {
                Equipo objEquipo = new Equipo();

                var query = (from i in DbContext.tblEquipo
                             where i.Nombre == nombre.Trim()
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipo = Convertir(query);
                }
                return objEquipo;

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

        public Equipo ConsultarPorTipoEquipo(int idTipoEquipo)
        {
            try
            {
                Equipo objEquipo = new Equipo();

                var query = (from i in DbContext.tblEquipo
                             where i.tblTipoEquipo.Id == idTipoEquipo
                             select i).FirstOrDefault();

                if (query != null)
                {
                    objEquipo = Convertir(query);
                }
                return objEquipo;

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

        public Equipo Convertir(tblEquipo EquipoContext)
        {
            try
            {
                Equipo objEquipo = new Equipo();
                objEquipo.Id = EquipoContext.Id;
                objEquipo.Placa = EquipoContext.Placa;
                objEquipo.Nombre = EquipoContext.Nombre;
                objEquipo.Serial = EquipoContext.Serial;
                objEquipo.Marca = EquipoContext.Marca;
                objEquipo.Estado = EquipoContext.Estado;
                objEquipo.FechaCompra = EquipoContext.FechaCompra;
                objEquipo.Valor = EquipoContext.Valor;
                objEquipo.NumeroContrato = EquipoContext.NumeroContrato;
                objEquipo.FechaFuncionamiento = EquipoContext.FechaFuncionamiento;
                objEquipo.Responsable = new Empleado()
                {
                    Id = EquipoContext.Responsable.Id,
                    NombreCompleto = EquipoContext.Responsable.tblPersona.Nombres + " " + EquipoContext.Responsable.tblPersona.Apellidos,
                };
                objEquipo.TipoEquipo = new TipoEquipo()
                {
                    Id = EquipoContext.tblTipoEquipo.Id,
                    Nombre = EquipoContext.tblTipoEquipo.Nombre,
                    Activo = EquipoContext.tblTipoEquipo.Activo,
                };
                objEquipo.AreaTecnica = new AreaTecnica()
                {
                    Id = EquipoContext.tblAreaTecnica.Id,
                    Nombre = EquipoContext.tblAreaTecnica.Nombre,
                    Activo = EquipoContext.tblAreaTecnica.Activo,
                };
                if (EquipoContext.lstComputos != null)
                {
                    objEquipo.lstComputos = new List<Computo>();
                    foreach (var objComputo in EquipoContext.lstComputos)
                    {
                        objEquipo.lstComputos.Add(new Computo()
                        {
                            Id = objComputo.Id,
                            Ip = objComputo.Ip,
                            CuentaAdmin = (bool)objComputo.CuentaAdmin,
                            Backup = (bool)objComputo.Backup,
                            Procesador = objComputo.Procesador,
                            Ram = objComputo.Ram,
                            Disco = objComputo.Disco,
                            Observaciones = objComputo.Observaciones,

                        });
                    }
                    if (EquipoContext.lstEquipoAccesorios != null)
                    {
                        objEquipo.lstEquipoAccesorios = new List<EquipoAccesorio>();
                        foreach (var objEquipoAccesorio in EquipoContext.lstEquipoAccesorios)
                        {
                            objEquipo.lstEquipoAccesorios.Add(new EquipoAccesorio()
                            {
                                Id = objEquipoAccesorio.Id,
                                Accesorios = new Accesorios()
                                {
                                    Id = objEquipoAccesorio.tblAccesorios.Id,
                                    Codigo= objEquipoAccesorio.tblAccesorios.Codigo,
                                    Nombre = objEquipoAccesorio.tblAccesorios.Nombre,
                                    Descripcion = objEquipoAccesorio.tblAccesorios.Descripcion
                                }
                            });
                        }
                    }
                    //if (EquipoContext.lst != null)
                    //{
                    //    objEquipo.lstEquipoAccesorios = new List<EquipoAccesorio>();
                    //    foreach (var objEquipoAccesorio in EquipoContext.lstEquipoAccesorios)
                    //    {
                    //        objEquipo.lstEquipoAccesorios.Add(new EquipoAccesorio()
                    //        {
                    //            Id = objEquipoAccesorio.Id,
                    //            Accesorios = new Accesorios()
                    //            {
                    //                Id = objEquipoAccesorio.tblAccesorios.Id,
                    //                Codigo = objEquipoAccesorio.tblAccesorios.Codigo,
                    //                Nombre = objEquipoAccesorio.tblAccesorios.Nombre,
                    //                Descripcion = objEquipoAccesorio.tblAccesorios.Descripcion
                    //            }
                    //        });
                    //    }
                    //}
                }
                return objEquipo;
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

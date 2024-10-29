using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Model;
using Logic;
using System.Web.Script.Services;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;
using Web.Views;

namespace Web.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class SEliminar : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarEmpresa(string idEmpresa)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LEmpresa objLEmpresa = new LEmpresa();
                Empresa Empresa = objLEmpresa.Consultar(int.Parse(idEmpresa));
                LIngreso objLIngreso = new LIngreso();
                Ingreso objIngreso = objLIngreso.ConsultarPorEmpresa(Empresa.Id);

                if (objIngreso.Id == 0)
                {
                    objLEmpresa.Eliminar(int.Parse(idEmpresa));
                }
                else
                {
                    execpcion =  "Asociada";
                    message = $"La Empresa <label style='color:#FF6B00;'>{Empresa.RazonSocial}</label> no se puede Eliminar, ya que se encuentra asociada.";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarSectorEconomico(string idSectorEconomico)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LSectorEconomico objLSectorEconomico = new LSectorEconomico();
                SectorEconomico SectorEconomico = objLSectorEconomico.Consultar(int.Parse(idSectorEconomico));
                LEmpresa objLEmpresa = new LEmpresa();
                Empresa Empresa = objLEmpresa.ConsultarPorSectorEconomico(SectorEconomico.Id);

                if (Empresa.Id == 0)
                {
                    objLSectorEconomico.Eliminar(int.Parse(idSectorEconomico));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Sector Económico <label style='color:#FF6B00;'>{SectorEconomico.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un Producto";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarAreaTecnica(string idAreaTecnica)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LAreaTecnica objLAreaTecnica = new LAreaTecnica();
                AreaTecnica AreaTecnica = objLAreaTecnica.Consultar(int.Parse(idAreaTecnica));
                LEquipo objLEquipo = new LEquipo();
                LServicio objlServicio = new LServicio();
                Equipo Equipo = objLEquipo.ConsultarPorAreaTecnica(AreaTecnica.Id);
                Servicio Servicio = objlServicio.ConsultarAreaTecnica(AreaTecnica.Id);
                LIngresosAreasTecnicas objLIngresoAreasTecnicas = new LIngresosAreasTecnicas();
                IngresosAreasTecnicas IngresosAreasTecnicas = objLIngresoAreasTecnicas.ConsultarPorAreaTecnica(AreaTecnica.Id);
                LOrdenTrabajo objLOrdenTrabajo = new LOrdenTrabajo();
                OrdenTrabajo OrdenTrabajo = objLOrdenTrabajo.ConsultarPorAreaTecnica(AreaTecnica.Id);
                if (Equipo.Id == 0 && Servicio.Id == 0 && IngresosAreasTecnicas.Id == 0 && OrdenTrabajo.Id == 0)
                {
                    objLAreaTecnica.Eliminar(int.Parse(idAreaTecnica));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Área Técnica <label style='color:#FF6B00;'>{AreaTecnica.Nombre}</label> no se puede Eliminar, ya que se encuentra asociada";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarFamiliaServicio(string idFamilia)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LFamilia objLFamilia = new LFamilia();
                Familia Familia = objLFamilia.Consultar(int.Parse(idFamilia));
                LServicio objLServicio = new LServicio();
                Servicio Servicio = objLServicio.ConsultarFamilia(Familia.Id);

                if (Servicio.Id == 0)
                {
                    objLFamilia.Eliminar(int.Parse(idFamilia));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"La familia <label style='color:#FF6B00;'>{Familia.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un Servicio";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarServicio(string idServicio)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LServicio objLServicio = new LServicio();
                Servicio Servicio = objLServicio.Consultar(int.Parse(idServicio));
                LCotizacionDetalle objLCotizacionDetalle = new LCotizacionDetalle();

                CotizacionDetalle CotizacionDetalle = objLCotizacionDetalle.ConsultarPorServicio(Servicio.Id);

                if (CotizacionDetalle.Id == 0)
                {
                    objLServicio.Eliminar(int.Parse(idServicio));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Servicio <label style='color:#FF6B00;'>{Servicio.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a una cotización";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarTipoAreaTecnica(string idTipoAreaTecnica)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LTipoAreaTecnica objLTipoAreaTecnica = new LTipoAreaTecnica();
                TipoAreaTecnica TipoAreaTecnica = objLTipoAreaTecnica.Consultar(int.Parse(idTipoAreaTecnica));
                LAreaTecnica objLAreaTecnica = new LAreaTecnica();
                List<AreaTecnica> lstAreaTecnica = objLAreaTecnica.ConsultarTipoAreaTecnica(TipoAreaTecnica.Id);

                if (lstAreaTecnica.Count == 0)
                {
                    objLTipoAreaTecnica.Eliminar(int.Parse(idTipoAreaTecnica));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Tipo de Area Tecnica <label style='color:#FF6B00;'>{TipoAreaTecnica.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un Área Técnica";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarPersona(string idPersona)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LPersona objLPersona = new LPersona();
                Persona Persona = objLPersona.Consultar(int.Parse(idPersona));
                LProyecto objLProyecto = new LProyecto();
                Proyecto objProyecto = objLProyecto.ConsultarPorPersona(Persona.Id);

                if (objProyecto.Id == 0)
                {
                    objLPersona.Eliminar(int.Parse(idPersona));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Persona <label style='color:#FF6B00;'>{Persona.Nombres} {Persona.Apellidos}</label> no se puede Eliminar, ya que se encuentra asociada a un proyecto.";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarEmpleado(string idEmpleado)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LEmpleado objLEmpleado = new LEmpleado();
                Empleado Empleado = objLEmpleado.Consultar(int.Parse(idEmpleado));
                LProyecto objLProyecto = new LProyecto();
                Proyecto objProyecto = objLProyecto.ConsultarPorPersona(Empleado.Persona.Id);

                if (objProyecto.Id == 0)
                {
                    objLEmpleado.Eliminar(int.Parse(idEmpleado));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Empleado <label style='color:#FF6B00;'>{Empleado.NombreCompleto}</label> no se puede Eliminar, ya que se encuentra asociado a un proyecto.";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarCargo(string idCargo)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LCargo objLCargo = new LCargo();
                Cargo Cargo = objLCargo.Consultar(int.Parse(idCargo));
                LEmpleado objLEmpleado = new LEmpleado();
                Empleado objEmpleado = objLEmpleado.ConsultarPorCargo(Cargo.Id);

                if (objEmpleado.Id == 0)
                {
                    objLCargo.Eliminar(int.Parse(idCargo));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Cargo <label style='color:#FF6B00;'>{Cargo.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un empleado";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarRolSennova(string idRolSennova)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LRolSennova objLRolSennova = new LRolSennova();
                RolSennova RolSennova = objLRolSennova.Consultar(int.Parse(idRolSennova));
                LEmpleado objLEmpleado = new LEmpleado();
                Empleado objEmpleado = objLEmpleado.ConsultarPorRolSennova(RolSennova.Id);

                if (objEmpleado.Id == 0)
                {
                    objLRolSennova.Eliminar(int.Parse(idRolSennova));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El RolSennova <label style='color:#FF6B00;'>{RolSennova.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un empleado";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarTiposDocumentos(string idTiposDocumentos)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LTiposDocumentos objLTiposDocumentos = new LTiposDocumentos();
                TiposDocumentos TiposDocumentos = objLTiposDocumentos.Consultar(int.Parse(idTiposDocumentos));
                LDocumento objLDocumento = new LDocumento();
                Documento Documento = objLDocumento.ConsultarPorTiposDocumentos(TiposDocumentos.Id);

                if (Documento.Id == 0)
                {
                    objLTiposDocumentos.Eliminar(int.Parse(idTiposDocumentos));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Tipo DE Documento <label style='color:#FF6B00;'>{TiposDocumentos.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un Documento";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarTipoDocumento(string idTipoDocumento)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LTipoDocumento objLTipoDocumento = new LTipoDocumento();
                TipoDocumento TipoDocumento = objLTipoDocumento.Consultar(int.Parse(idTipoDocumento));
                LPersona objLPersona = new LPersona();
                Persona Persona = objLPersona.ConsultarPorTipoDocumento(TipoDocumento.Id);

                if (Persona.Id == 0)
                {
                    objLTipoDocumento.Eliminar(int.Parse(idTipoDocumento));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Tipo de identificación <label style='color:#FF6B00;'>{TipoDocumento.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un usuario";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarProgramaFormacion(string idProgramaFormacion)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LProgramaFormacion objLProgramaFormacion = new LProgramaFormacion();
                ProgramaFormacion ProgramaFormacion = objLProgramaFormacion.Consultar(int.Parse(idProgramaFormacion));
                LIngreso objLIngreso = new LIngreso();
                Ingreso Ingreso = objLIngreso.ConsultarPorProgramaFormacion(ProgramaFormacion.Id);
                LCotizacion objLCotizacion = new LCotizacion();
                Cotizacion Cotizacion = objLCotizacion.ConsultarPorProgramaFormacion(ProgramaFormacion.Id);
                if (Ingreso.Id == 0 && Cotizacion.Id == 0)
                {
                    objLProgramaFormacion.Eliminar(int.Parse(idProgramaFormacion));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El programa de formación <label style='color:#FF6B00;'>{ProgramaFormacion.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un Producto";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarTipoVisitante(string idTipoVisitante)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LTipoVisitante objLTipoVisitante = new LTipoVisitante();
                TipoVisitante TipoVisitante = objLTipoVisitante.Consultar(int.Parse(idTipoVisitante));
                LVisitante objLVisitante = new LVisitante();
                Visitante Visitante = objLVisitante.ConsultarPorTipoVisitante(TipoVisitante.Id);

                if (Visitante.Id == 0)
                {
                    objLTipoVisitante.Eliminar(int.Parse(idTipoVisitante));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Tipo de visitante <label style='color:#FF6B00;'>{TipoVisitante.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un visitante";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarTipoLicencia(string idTipoLicencia)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LTipoLicencia objLTipoLicencia = new LTipoLicencia();
                TipoLicencia TipoLicencia = objLTipoLicencia.Consultar(int.Parse(idTipoLicencia));
                LSoftware objLSoftware = new LSoftware();
                Software software = objLSoftware.ConsultarPorTipoLicencia(TipoLicencia.Id);

                if (software.Id == 0)
                {
                    objLTipoLicencia.Eliminar(int.Parse(idTipoLicencia));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El tipo de licencia <label style='color:#FF6B00;'>{TipoLicencia.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un software!";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarTipoEquipo(string idTipoEquipo)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LTipoEquipo objLTipoEquipo = new LTipoEquipo();
                TipoEquipo TipoEquipo = objLTipoEquipo.Consultar(int.Parse(idTipoEquipo));
                LEquipo objLEquipo = new LEquipo();
                Equipo equipo = objLEquipo.ConsultarPorTipoEquipo(TipoEquipo.Id);

                if (equipo.Id == 0)
                {
                    objLTipoEquipo.Eliminar(int.Parse(idTipoEquipo));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Tipo de equipo <label style='color:#FF6B00;'>{TipoEquipo.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un equipo!";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarAccesorio(string idAccesorios)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LEquipoAccesorio objLEquipoAccesorio = new LEquipoAccesorio();
                LAccesorios objLAccesorios = new LAccesorios();
                Accesorios Accesorios = objLAccesorios.Consultar(int.Parse(idAccesorios));
                EquipoAccesorio objEquipoAccesorio = objLEquipoAccesorio.ConsultarPorAccesorio(Accesorios.Id);

                if (objEquipoAccesorio.Id == 0)
                {
                    objLAccesorios.Eliminar(int.Parse(idAccesorios));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Accesorio <label style='color:#FF6B00;'>{Accesorios.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un equipo!";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarImpresora(string idImpresora)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LImpresora objLImpresora = new LImpresora();
                LComputo objLComputo = new LComputo();
                Impresora Impresora = objLImpresora.Consultar(int.Parse(idImpresora));
                Computo Computo = objLComputo.ConsultarPorImpresora(Impresora.Id);

                if (Computo.Id == 0)
                {
                    objLImpresora.Eliminar(int.Parse(idImpresora));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"La Impresora <label style='color:#FF6B00;'>{Impresora.Nombre}</label> no se puede Eliminar, ya que se encuentra asociada a un Equipo";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarSoftware(string idSoftware)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LSoftware objLSoftware = new LSoftware();
                Software Software = objLSoftware.Consultar(int.Parse(idSoftware));
                LEquipoSoftware objLEquipoSoftware = new LEquipoSoftware();
                EquipoSoftware objEquipoSoftware = objLEquipoSoftware.ConsultarPorSoftware(Software.Id);

                if (objEquipoSoftware.Id == 0)
                {
                    objLSoftware.Eliminar(int.Parse(idSoftware));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Software <label style='color:#FF6B00;'>{Software.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado.";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarTipoPatron(string idTipoPatron)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LTipoPatron objLTipoPatron = new LTipoPatron();
                TipoPatron TipoPatron = objLTipoPatron.Consultar(int.Parse(idTipoPatron));

                LEquipoTecnico objLEquipoTecnico = new LEquipoTecnico();
                EquipoTecnico EquipoTecnico = objLEquipoTecnico.ConsultarPorTipoPatron(TipoPatron.Id);

                if (EquipoTecnico.Id == 0)
                {
                    objLTipoPatron.Eliminar(int.Parse(idTipoPatron));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Tipo de Patron <label style='color:#FF6B00;'>{TipoPatron.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado!";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarDocumento(string idDocumento)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LDocumento objLDocumento = new LDocumento();
                Documento Documento = objLDocumento.Consultar(int.Parse(idDocumento));
                LDetallesDocumento objLDetallesDocumento = new LDetallesDocumento();
                DetallesDocumento objDetallesDocumento = objLDetallesDocumento.ConsultarPorDocumento(Documento.Id);

                if (objDetallesDocumento.Id == 0)
                {
                    objLDocumento.Eliminar(int.Parse(idDocumento));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Documento <label style='color:#FF6B00;'>{Documento.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado.";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarProcedimiento(string idProcedimiento)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LProcedimiento objLProcedimiento = new LProcedimiento();
                Procedimiento Procedimiento = objLProcedimiento.Consultar(int.Parse(idProcedimiento));
                LDocumento objLDocumento = new LDocumento();
                Documento objDocumento = objLDocumento.ConsultarPorProcedimiento(Procedimiento.Id);

                if (objDocumento.Id == 0)
                {
                    objLProcedimiento.Eliminar(int.Parse(idProcedimiento));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Procedimiento <label style='color:#FF6B00;'>{Procedimiento.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado.";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarProceso(string idProceso)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LProceso objLProceso = new LProceso();
                Proceso Proceso = objLProceso.Consultar(int.Parse(idProceso));
                LProcedimiento objLProcedimiento = new LProcedimiento();
                Procedimiento objProcedimiento = objLProcedimiento.ConsultarPorProceso(Proceso.Id);

                if (objProcedimiento.Id == 0)
                {
                    objLProceso.Eliminar(int.Parse(idProceso));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Proceso <label style='color:#FF6B00;'>{Proceso.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado.";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarMacroProceso(string idMacroProceso)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LMacroProceso objLMacroProceso = new LMacroProceso();
                MacroProceso MacroProceso = objLMacroProceso.Consultar(int.Parse(idMacroProceso));
                LProceso objLProceso = new LProceso();
                Proceso objProceso = objLProceso.ConsultarPorMacroProceso(MacroProceso.Id);

                if (objProceso.Id == 0)
                {
                    objLMacroProceso.Eliminar(int.Parse(idMacroProceso));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Macro Proceso <label style='color:#FF6B00;'>{MacroProceso.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un Proceso";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarTerminoCondicion(string idTerminoCondicion)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LTerminoCondicion objLTerminoCondicion = new LTerminoCondicion();
                TerminoCondicion TerminoCondicion = objLTerminoCondicion.Consultar(int.Parse(idTerminoCondicion));
                LTerminoCotizacion objLTerminoCotizacion = new LTerminoCotizacion();
                TerminoCotizacion TerminoCotizacion = objLTerminoCotizacion.ConsultarPorTerminoCondicion(TerminoCondicion.Id);

                if (TerminoCotizacion.Id == 0)
                {
                    objLTerminoCondicion.Eliminar(int.Parse(idTerminoCondicion));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Termino y Condición <label style='color:#FF6B00;'>{TerminoCondicion.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un Producto";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] EliminarRubro(string idRubro)
        {
            string execpcion = "";
            string message = "";
            List<string> result = new List<string>();
            try
            {
                LRubro objLRubro = new LRubro();
                Rubro Rubro = objLRubro.Consultar(int.Parse(idRubro));
                LProyectoRubro objLProyectoRubros = new LProyectoRubro();
                ProyectoRubro objProyectoRubros = objLProyectoRubros.ConsultarPorRubro(Rubro.Id);

                if (objProyectoRubros.Id == 0)
                {
                    objLRubro.Eliminar(int.Parse(idRubro));
                }
                else
                {
                    execpcion = "Asociada";
                    message = $"El Rubro <label style='color:#FF6B00;'>{Rubro.Nombre}</label> no se puede Eliminar, ya que se encuentra asociado a un Producto";
                    result.Add(execpcion);
                    result.Add(message);
                }
            }
            catch (ApplicationException exe)
            {
                execpcion = "Warning";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            catch (Exception exe)
            {
                execpcion = "Error";
                message = exe.Message;
                result.Add(execpcion);
                result.Add(message);

            }
            return result.ToArray();
        }
    }
}
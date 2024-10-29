
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/13/2022 18:38:39
-- Generated from EDMX file: C:\Users\SEBASTIAN\Documents\Visual Studio 2022\Projects\SENNOVA\SENNOVA\Data\DB_SENNOVA.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SENNOVA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_tblProyectotblCentroFormacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProyecto] DROP CONSTRAINT [FK_tblProyectotblCentroFormacion];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProyectotblLineaProgramatica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProyecto] DROP CONSTRAINT [FK_tblProyectotblLineaProgramatica];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProyectotblRedConocimientoSectorial]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProyecto] DROP CONSTRAINT [FK_tblProyectotblRedConocimientoSectorial];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProyectotblAreaConocimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProyecto] DROP CONSTRAINT [FK_tblProyectotblAreaConocimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_tblPersonatblTipoDocumento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblPersona] DROP CONSTRAINT [FK_tblPersonatblTipoDocumento];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductotblTipoProducto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProducto] DROP CONSTRAINT [FK_tblProductotblTipoProducto];
GO
IF OBJECT_ID(N'[dbo].[FK_tblObjetivoEspecificotblProyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblObjetivoEspecifico] DROP CONSTRAINT [FK_tblObjetivoEspecificotblProyecto];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProductotblActividad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProducto] DROP CONSTRAINT [FK_tblProductotblActividad];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAvanceProyectotblActividad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAvanceProyecto] DROP CONSTRAINT [FK_tblAvanceProyectotblActividad];
GO
IF OBJECT_ID(N'[dbo].[FK_tblRegionaltblRegion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblRegional] DROP CONSTRAINT [FK_tblRegionaltblRegion];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCentroFormaciontblRegional]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCentroFormacion] DROP CONSTRAINT [FK_tblCentroFormaciontblRegional];
GO
IF OBJECT_ID(N'[dbo].[FK_tblActividadtblObjetivoEspecifico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblActividad] DROP CONSTRAINT [FK_tblActividadtblObjetivoEspecifico];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProyectoRubrotblProyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProyectoRubro] DROP CONSTRAINT [FK_tblProyectoRubrotblProyecto];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProyectoRubrotblRubro]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProyectoRubro] DROP CONSTRAINT [FK_tblProyectoRubrotblRubro];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAreaTecnicatblTipoAreaTecnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAreaTecnica] DROP CONSTRAINT [FK_tblAreaTecnicatblTipoAreaTecnica];
GO
IF OBJECT_ID(N'[dbo].[FK_tblServiciotblAreaTecnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblServicio] DROP CONSTRAINT [FK_tblServiciotblAreaTecnica];
GO
IF OBJECT_ID(N'[dbo].[FK_tblIngresosAreasTecnicastblAreaTecnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblIngresosAreasTecnicas] DROP CONSTRAINT [FK_tblIngresosAreasTecnicastblAreaTecnica];
GO
IF OBJECT_ID(N'[dbo].[FK_tblIngresosAreasTecnicastblIngreso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblIngresosAreasTecnicas] DROP CONSTRAINT [FK_tblIngresosAreasTecnicastblIngreso];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProyectotblEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProyecto] DROP CONSTRAINT [FK_tblProyectotblEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_tblVisitantetblTipoVisitante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblVisitante] DROP CONSTRAINT [FK_tblVisitantetblTipoVisitante];
GO
IF OBJECT_ID(N'[dbo].[FK_tblIngresotblVisitante]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblIngreso] DROP CONSTRAINT [FK_tblIngresotblVisitante];
GO
IF OBJECT_ID(N'[dbo].[FK_tblIngresotblProgramaFormacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblIngreso] DROP CONSTRAINT [FK_tblIngresotblProgramaFormacion];
GO
IF OBJECT_ID(N'[dbo].[FK_tblIngresotblEmpresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblIngreso] DROP CONSTRAINT [FK_tblIngresotblEmpresa];
GO
IF OBJECT_ID(N'[dbo].[FK_tblAreaTecnicatblEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblAreaTecnica] DROP CONSTRAINT [FK_tblAreaTecnicatblEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmpresatblSectorEconomico]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmpresa] DROP CONSTRAINT [FK_tblEmpresatblSectorEconomico];
GO
IF OBJECT_ID(N'[dbo].[FK_tblVisitantetblPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblVisitante] DROP CONSTRAINT [FK_tblVisitantetblPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmpleadotblPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmpleado] DROP CONSTRAINT [FK_tblEmpleadotblPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_tblIngresotblEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblIngreso] DROP CONSTRAINT [FK_tblIngresotblEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDocumentotblTiposDocumentos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDocumento] DROP CONSTRAINT [FK_tblDocumentotblTiposDocumentos];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDetallesDocumentotblDocumento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetallesDocumento] DROP CONSTRAINT [FK_tblDetallesDocumentotblDocumento];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDocumentotblProcedimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDocumento] DROP CONSTRAINT [FK_tblDocumentotblProcedimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDetallesDocumentotblEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetallesDocumento] DROP CONSTRAINT [FK_tblDetallesDocumentotblEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDetallesDocumentotblEmpleado1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetallesDocumento] DROP CONSTRAINT [FK_tblDetallesDocumentotblEmpleado1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDetallesDocumentotblEmpleado2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetallesDocumento] DROP CONSTRAINT [FK_tblDetallesDocumentotblEmpleado2];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProcedimientotblProcesos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProcedimiento] DROP CONSTRAINT [FK_tblProcedimientotblProcesos];
GO
IF OBJECT_ID(N'[dbo].[FK_tblProcesostblMacroProcesos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblProcesos] DROP CONSTRAINT [FK_tblProcesostblMacroProcesos];
GO
IF OBJECT_ID(N'[dbo].[FK_tblSoftwaretblTipoLicencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblSoftware] DROP CONSTRAINT [FK_tblSoftwaretblTipoLicencia];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEquipotblTipoEquipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEquipo] DROP CONSTRAINT [FK_tblEquipotblTipoEquipo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEquipoSoftwaretblSoftware]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEquipoSoftware] DROP CONSTRAINT [FK_tblEquipoSoftwaretblSoftware];
GO
IF OBJECT_ID(N'[dbo].[FK_tblMantenimientoEuipotblEquipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblMantenimientoEuipo] DROP CONSTRAINT [FK_tblMantenimientoEuipotblEquipo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblMantenimientoEuipotblMantenimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblMantenimientoEuipo] DROP CONSTRAINT [FK_tblMantenimientoEuipotblMantenimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCalibracionEquipotblCalibracion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCalibracionEquipo] DROP CONSTRAINT [FK_tblCalibracionEquipotblCalibracion];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCalibracionEquipotblEquipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCalibracionEquipo] DROP CONSTRAINT [FK_tblCalibracionEquipotblEquipo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEquipotblEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEquipo] DROP CONSTRAINT [FK_tblEquipotblEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_tblMantenimientotblEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblMantenimiento] DROP CONSTRAINT [FK_tblMantenimientotblEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmpleadotblMantenimiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblMantenimiento] DROP CONSTRAINT [FK_tblEmpleadotblMantenimiento];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEquipotblAreaTecnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEquipo] DROP CONSTRAINT [FK_tblEquipotblAreaTecnica];
GO
IF OBJECT_ID(N'[dbo].[FK_tblComputotblEquipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblComputo] DROP CONSTRAINT [FK_tblComputotblEquipo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblComputotblImpresora]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblComputo] DROP CONSTRAINT [FK_tblComputotblImpresora];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEquipoSoftwaretblComputo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEquipoSoftware] DROP CONSTRAINT [FK_tblEquipoSoftwaretblComputo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEquipoTecnicotblEquipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEquipoTecnico] DROP CONSTRAINT [FK_tblEquipoTecnicotblEquipo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEquipoTecnicotblTipoPatron]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEquipoTecnico] DROP CONSTRAINT [FK_tblEquipoTecnicotblTipoPatron];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEquipoAccesoriotblEquipo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEquipoAccesorio] DROP CONSTRAINT [FK_tblEquipoAccesoriotblEquipo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEquipoAccesoriotblAccesorios]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEquipoAccesorio] DROP CONSTRAINT [FK_tblEquipoAccesoriotblAccesorios];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDetallesDocumentotblDocumento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetallesDocumentoSet] DROP CONSTRAINT [FK_tblDetallesDocumentotblDocumento];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDetallesDocumentotblEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetallesDocumentoSet] DROP CONSTRAINT [FK_tblDetallesDocumentotblEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDetallesDocumentotblEmpleado1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetallesDocumentoSet] DROP CONSTRAINT [FK_tblDetallesDocumentotblEmpleado1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblDetallesDocumentotblEmpleado2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblDetallesDocumentoSet] DROP CONSTRAINT [FK_tblDetallesDocumentotblEmpleado2];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTerminoCotizaciontblTerminoCondicion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTerminoCotizacion] DROP CONSTRAINT [FK_tblTerminoCotizaciontblTerminoCondicion];
GO
IF OBJECT_ID(N'[dbo].[FK_tblTerminoCotizaciontblCotizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblTerminoCotizacion] DROP CONSTRAINT [FK_tblTerminoCotizaciontblCotizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCotizaciontblProgramaFormacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCotizacion] DROP CONSTRAINT [FK_tblCotizaciontblProgramaFormacion];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCotizaciontblEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCotizacion] DROP CONSTRAINT [FK_tblCotizaciontblEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCotizaciontblEmpleado1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCotizacion] DROP CONSTRAINT [FK_tblCotizaciontblEmpleado1];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCotizaciontblEmpleado2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCotizacion] DROP CONSTRAINT [FK_tblCotizaciontblEmpleado2];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCotizacionDetalletblCotizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCotizacionDetalle] DROP CONSTRAINT [FK_tblCotizacionDetalletblCotizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_tblServiciotblCotizacionDetalle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCotizacionDetalle] DROP CONSTRAINT [FK_tblServiciotblCotizacionDetalle];
GO
IF OBJECT_ID(N'[dbo].[FK_tblClientetblPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCliente] DROP CONSTRAINT [FK_tblClientetblPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_tblCotizaciontblCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblCotizacion] DROP CONSTRAINT [FK_tblCotizaciontblCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmpleadotblCargo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmpleado] DROP CONSTRAINT [FK_tblEmpleadotblCargo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblEmpleadotblRolSennova]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblEmpleado] DROP CONSTRAINT [FK_tblEmpleadotblRolSennova];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOrdenTrabajotblAreaTecnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrdenTrabajo] DROP CONSTRAINT [FK_tblOrdenTrabajotblAreaTecnica];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOrdenTrabajotblCotizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrdenTrabajo] DROP CONSTRAINT [FK_tblOrdenTrabajotblCotizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOrdenTrabajotblEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrdenTrabajo] DROP CONSTRAINT [FK_tblOrdenTrabajotblEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_tblOrdenTrabajoDetallestblOrdenTrabajo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblOrdenTrabajoDetalles] DROP CONSTRAINT [FK_tblOrdenTrabajoDetallestblOrdenTrabajo];
GO
IF OBJECT_ID(N'[dbo].[FK_tblServiciotblFamilia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tblServicio] DROP CONSTRAINT [FK_tblServiciotblFamilia];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[tblProyecto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProyecto];
GO
IF OBJECT_ID(N'[dbo].[tblRegion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRegion];
GO
IF OBJECT_ID(N'[dbo].[tblRegional]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRegional];
GO
IF OBJECT_ID(N'[dbo].[tblCentroFormacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCentroFormacion];
GO
IF OBJECT_ID(N'[dbo].[tblLineaProgramatica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblLineaProgramatica];
GO
IF OBJECT_ID(N'[dbo].[tblAreaConocimiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAreaConocimiento];
GO
IF OBJECT_ID(N'[dbo].[tblRolSennova]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRolSennova];
GO
IF OBJECT_ID(N'[dbo].[tblRedConocimientoSectorial]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRedConocimientoSectorial];
GO
IF OBJECT_ID(N'[dbo].[tblPersona]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblPersona];
GO
IF OBJECT_ID(N'[dbo].[tblTipoDocumento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTipoDocumento];
GO
IF OBJECT_ID(N'[dbo].[tblObjetivoEspecifico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblObjetivoEspecifico];
GO
IF OBJECT_ID(N'[dbo].[tblActividad]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblActividad];
GO
IF OBJECT_ID(N'[dbo].[tblProducto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProducto];
GO
IF OBJECT_ID(N'[dbo].[tblTipoProducto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTipoProducto];
GO
IF OBJECT_ID(N'[dbo].[tblAvanceProyecto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAvanceProyecto];
GO
IF OBJECT_ID(N'[dbo].[tblRubro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblRubro];
GO
IF OBJECT_ID(N'[dbo].[tblProyectoRubro]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProyectoRubro];
GO
IF OBJECT_ID(N'[dbo].[tblIngreso]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblIngreso];
GO
IF OBJECT_ID(N'[dbo].[tblAreaTecnica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAreaTecnica];
GO
IF OBJECT_ID(N'[dbo].[tblTipoAreaTecnica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTipoAreaTecnica];
GO
IF OBJECT_ID(N'[dbo].[tblServicio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblServicio];
GO
IF OBJECT_ID(N'[dbo].[tblIngresosAreasTecnicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblIngresosAreasTecnicas];
GO
IF OBJECT_ID(N'[dbo].[tblProgramaFormacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProgramaFormacion];
GO
IF OBJECT_ID(N'[dbo].[tblEmpleado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEmpleado];
GO
IF OBJECT_ID(N'[dbo].[tblVisitante]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblVisitante];
GO
IF OBJECT_ID(N'[dbo].[tblTipoVisitante]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTipoVisitante];
GO
IF OBJECT_ID(N'[dbo].[tblEmpresa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEmpresa];
GO
IF OBJECT_ID(N'[dbo].[tblSectorEconomico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSectorEconomico];
GO
IF OBJECT_ID(N'[dbo].[tblDocumento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDocumento];
GO
IF OBJECT_ID(N'[dbo].[tblTiposDocumentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTiposDocumentos];
GO
IF OBJECT_ID(N'[dbo].[tblMacroProcesos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblMacroProcesos];
GO
IF OBJECT_ID(N'[dbo].[tblProcesos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProcesos];
GO
IF OBJECT_ID(N'[dbo].[tblProcedimiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblProcedimiento];
GO
IF OBJECT_ID(N'[dbo].[tblDetallesDocumento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDetallesDocumento];
GO
IF OBJECT_ID(N'[dbo].[tblImpresora]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblImpresora];
GO
IF OBJECT_ID(N'[dbo].[tblSoftware]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblSoftware];
GO
IF OBJECT_ID(N'[dbo].[tblTipoLicencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTipoLicencia];
GO
IF OBJECT_ID(N'[dbo].[tblTipoEquipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTipoEquipo];
GO
IF OBJECT_ID(N'[dbo].[tblEquipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEquipo];
GO
IF OBJECT_ID(N'[dbo].[tblEquipoSoftware]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEquipoSoftware];
GO
IF OBJECT_ID(N'[dbo].[tblCalibracion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCalibracion];
GO
IF OBJECT_ID(N'[dbo].[tblMantenimiento]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblMantenimiento];
GO
IF OBJECT_ID(N'[dbo].[tblMantenimientoEuipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblMantenimientoEuipo];
GO
IF OBJECT_ID(N'[dbo].[tblCalibracionEquipo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCalibracionEquipo];
GO
IF OBJECT_ID(N'[dbo].[tblComputo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblComputo];
GO
IF OBJECT_ID(N'[dbo].[tblEquipoTecnico]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEquipoTecnico];
GO
IF OBJECT_ID(N'[dbo].[tblTipoPatron]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTipoPatron];
GO
IF OBJECT_ID(N'[dbo].[tblAccesorios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblAccesorios];
GO
IF OBJECT_ID(N'[dbo].[tblEquipoAccesorio]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblEquipoAccesorio];
GO
IF OBJECT_ID(N'[dbo].[C__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[C__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[tblDetallesDocumentoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblDetallesDocumentoSet];
GO
IF OBJECT_ID(N'[dbo].[tblCotizacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCotizacion];
GO
IF OBJECT_ID(N'[dbo].[tblTerminoCondicion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTerminoCondicion];
GO
IF OBJECT_ID(N'[dbo].[tblTerminoCotizacion]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblTerminoCotizacion];
GO
IF OBJECT_ID(N'[dbo].[tblCotizacionDetalle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCotizacionDetalle];
GO
IF OBJECT_ID(N'[dbo].[tblCliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCliente];
GO
IF OBJECT_ID(N'[dbo].[tblCargo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblCargo];
GO
IF OBJECT_ID(N'[dbo].[tblOrdenTrabajo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOrdenTrabajo];
GO
IF OBJECT_ID(N'[dbo].[tblOrdenTrabajoDetalles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblOrdenTrabajoDetalles];
GO
IF OBJECT_ID(N'[dbo].[tblFamilia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tblFamilia];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'tblProyecto'
CREATE TABLE [dbo].[tblProyecto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TituloProyecto] nvarchar(max)  NOT NULL,
    [CodigoSGPS] nvarchar(max)  NOT NULL,
    [AnoEjecucion] smallint  NOT NULL,
    [FechaDiligenciamiento] datetime  NOT NULL,
    [ObjetivoGeneral] nvarchar(max)  NOT NULL,
    [AsignacionInicial] decimal(18,2)  NOT NULL,
    [TotalAdiciones] decimal(18,2)  NULL,
    [TotalDisminucionesCentralizaciones] decimal(18,2)  NULL,
    [TotalEjecutado] decimal(18,2)  NULL,
    [PresupuestoFinal] decimal(18,2)  NULL,
    [tblCentroFormacion_Id] int  NOT NULL,
    [tblLineaProgramatica_Id] int  NOT NULL,
    [tblRedConocimientoSectorial_Id] int  NOT NULL,
    [tblAreaConocimiento_Id] int  NOT NULL,
    [tblEmpleado_Id] int  NOT NULL
);
GO

-- Creating table 'tblRegion'
CREATE TABLE [dbo].[tblRegion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblRegional'
CREATE TABLE [dbo].[tblRegional] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL,
    [tblRegion_Id] int  NOT NULL
);
GO

-- Creating table 'tblCentroFormacion'
CREATE TABLE [dbo].[tblCentroFormacion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL,
    [tblRegional_Id] int  NOT NULL
);
GO

-- Creating table 'tblLineaProgramatica'
CREATE TABLE [dbo].[tblLineaProgramatica] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblAreaConocimiento'
CREATE TABLE [dbo].[tblAreaConocimiento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblRolSennova'
CREATE TABLE [dbo].[tblRolSennova] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblRedConocimientoSectorial'
CREATE TABLE [dbo].[tblRedConocimientoSectorial] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblPersona'
CREATE TABLE [dbo].[tblPersona] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombres] nvarchar(max)  NOT NULL,
    [Apellidos] nvarchar(max)  NOT NULL,
    [NumeroIdentificacion] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [tblTipoDocumento_Id] int  NOT NULL
);
GO

-- Creating table 'tblTipoDocumento'
CREATE TABLE [dbo].[tblTipoDocumento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblObjetivoEspecifico'
CREATE TABLE [dbo].[tblObjetivoEspecifico] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL,
    [tblProyecto_Id] int  NOT NULL
);
GO

-- Creating table 'tblActividad'
CREATE TABLE [dbo].[tblActividad] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL,
    [tblObjetivoEspecifico_Id] int  NOT NULL
);
GO

-- Creating table 'tblProducto'
CREATE TABLE [dbo].[tblProducto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL,
    [tblTipoProducto_Id] int  NOT NULL,
    [tblActividad_Id] int  NOT NULL
);
GO

-- Creating table 'tblTipoProducto'
CREATE TABLE [dbo].[tblTipoProducto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblAvanceProyecto'
CREATE TABLE [dbo].[tblAvanceProyecto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Mes] nvarchar(max)  NOT NULL,
    [Proyectado] decimal(18,2)  NOT NULL,
    [Ejecutado] decimal(18,2)  NULL,
    [EjecutadoPresupuesto] decimal(18,2)  NULL,
    [Adicion] decimal(18,2)  NULL,
    [Disminucion] decimal(18,2)  NULL,
    [Saldo] decimal(18,2)  NULL,
    [Observaciones] nvarchar(max)  NULL,
    [ObservacionesPresupuestales] nvarchar(max)  NULL,
    [tblActividad_Id] int  NOT NULL
);
GO

-- Creating table 'tblRubro'
CREATE TABLE [dbo].[tblRubro] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblProyectoRubro'
CREATE TABLE [dbo].[tblProyectoRubro] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Objeto] nvarchar(max)  NOT NULL,
    [Valor] decimal(18,2)  NULL,
    [tblProyecto_Id] int  NOT NULL,
    [tblRubro_Id] int  NOT NULL
);
GO

-- Creating table 'tblIngreso'
CREATE TABLE [dbo].[tblIngreso] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [PoliticaDatos] bit  NULL,
    [Ficha] nvarchar(max)  NULL,
    [tblVisitante_Id] int  NOT NULL,
    [tblProgramaFormacion_Id] int  NULL,
    [tblEmpresa_Id] int  NOT NULL,
    [tblEmpleado_Id] int  NOT NULL
);
GO

-- Creating table 'tblAreaTecnica'
CREATE TABLE [dbo].[tblAreaTecnica] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL,
    [tblTipoAreaTecnica_Id] int  NOT NULL,
    [tblEmpleado_Id] int  NOT NULL
);
GO

-- Creating table 'tblTipoAreaTecnica'
CREATE TABLE [dbo].[tblTipoAreaTecnica] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblServicio'
CREATE TABLE [dbo].[tblServicio] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Requisitos] nvarchar(max)  NOT NULL,
    [Alcance] nvarchar(max)  NOT NULL,
    [Valor] decimal(18,2)  NULL,
    [Activo] bit  NOT NULL,
    [tblAreaTecnica_Id] int  NOT NULL,
    [tblFamilia_Id] int  NOT NULL
);
GO

-- Creating table 'tblIngresosAreasTecnicas'
CREATE TABLE [dbo].[tblIngresosAreasTecnicas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tblAreaTecnica_Id] int  NOT NULL,
    [tblIngreso_Id] int  NOT NULL
);
GO

-- Creating table 'tblProgramaFormacion'
CREATE TABLE [dbo].[tblProgramaFormacion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblEmpleado'
CREATE TABLE [dbo].[tblEmpleado] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmailLaboral] nvarchar(max)  NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Ip] nvarchar(max)  NULL,
    [tblPersona_Id] int  NOT NULL,
    [tblCargo_Id] int  NULL,
    [tblRolSennova_Id] int  NULL
);
GO

-- Creating table 'tblVisitante'
CREATE TABLE [dbo].[tblVisitante] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tblTipoVisitante_Id] int  NOT NULL,
    [tblPersona_Id] int  NOT NULL
);
GO

-- Creating table 'tblTipoVisitante'
CREATE TABLE [dbo].[tblTipoVisitante] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblEmpresa'
CREATE TABLE [dbo].[tblEmpresa] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RazonSocial] nvarchar(max)  NOT NULL,
    [Nit] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [tblSectorEconomico_Id] int  NOT NULL
);
GO

-- Creating table 'tblSectorEconomico'
CREATE TABLE [dbo].[tblSectorEconomico] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblDocumento'
CREATE TABLE [dbo].[tblDocumento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL,
    [tblTiposDocumentos_Id] int  NOT NULL,
    [tblProcedimiento_Id] int  NOT NULL
);
GO

-- Creating table 'tblTiposDocumentos'
CREATE TABLE [dbo].[tblTiposDocumentos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblMacroProcesos'
CREATE TABLE [dbo].[tblMacroProcesos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Icono] nvarchar(max)  NOT NULL,
    [Color] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblProcesos'
CREATE TABLE [dbo].[tblProcesos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL,
    [tblMacroProcesos_Id] int  NOT NULL
);
GO

-- Creating table 'tblProcedimiento'
CREATE TABLE [dbo].[tblProcedimiento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL,
    [tblProcesos_Id] int  NOT NULL
);
GO

-- Creating table 'tblDetallesDocumento'
CREATE TABLE [dbo].[tblDetallesDocumento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Version] nvarchar(max)  NOT NULL,
    [RutaDoc] nvarchar(max)  NOT NULL,
    [Descargable] bit  NOT NULL,
    [Fisico] bit  NOT NULL,
    [Digital] bit  NOT NULL,
    [TipoSolicitud] nvarchar(max)  NOT NULL,
    [FechaSolicitud] datetime  NOT NULL,
    [FechaRevision] datetime  NULL,
    [FechaAprovacion] datetime  NULL,
    [CopiaControlada] nvarchar(max)  NOT NULL,
    [FechaCopiaControlada] datetime  NULL,
    [Activo] bit  NOT NULL,
    [tblDocumento_Id] int  NOT NULL,
    [tblSolicitante_Id] int  NULL,
    [tblRevisor_Id] int  NULL,
    [tblAprovador_Id] int  NULL
);
GO

-- Creating table 'tblImpresora'
CREATE TABLE [dbo].[tblImpresora] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblSoftware'
CREATE TABLE [dbo].[tblSoftware] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Version] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL,
    [tblTipoLicencia_Id] int  NOT NULL
);
GO

-- Creating table 'tblTipoLicencia'
CREATE TABLE [dbo].[tblTipoLicencia] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblTipoEquipo'
CREATE TABLE [dbo].[tblTipoEquipo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblEquipo'
CREATE TABLE [dbo].[tblEquipo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Placa] nvarchar(max)  NULL,
    [Serial] nvarchar(max)  NULL,
    [Marca] nvarchar(max)  NULL,
    [Estado] nvarchar(max)  NOT NULL,
    [FechaCompra] datetime  NOT NULL,
    [Valor] decimal(18,0)  NOT NULL,
    [NumeroContrato] nvarchar(max)  NOT NULL,
    [FechaFuncionamiento] datetime  NOT NULL,
    [tblTipoEquipo_Id] int  NOT NULL,
    [Responsable_Id] int  NOT NULL,
    [tblAreaTecnica_Id] int  NOT NULL
);
GO

-- Creating table 'tblEquipoSoftware'
CREATE TABLE [dbo].[tblEquipoSoftware] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tblSoftware_Id] int  NULL,
    [tblComputo_Id] int  NOT NULL
);
GO

-- Creating table 'tblCalibracion'
CREATE TABLE [dbo].[tblCalibracion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [TipoCalibracion] nvarchar(max)  NOT NULL,
    [TipoServicio] nvarchar(max)  NOT NULL,
    [NumeroCertificado] nvarchar(max)  NOT NULL,
    [Resultados] nvarchar(max)  NOT NULL,
    [Conforme] nvarchar(max)  NOT NULL,
    [FechaProxima] datetime  NOT NULL,
    [Observaciones] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'tblMantenimiento'
CREATE TABLE [dbo].[tblMantenimiento] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [TipoMantenimiento] nvarchar(max)  NOT NULL,
    [Actividad] nvarchar(max)  NOT NULL,
    [NumeroReporte] nvarchar(max)  NOT NULL,
    [ClaseMantenimiento] nvarchar(max)  NOT NULL,
    [AceptacionOferta] nvarchar(max)  NOT NULL,
    [Observaciones] nvarchar(max)  NOT NULL,
    [Ejecutor_Id] int  NOT NULL,
    [Revisor_Id] int  NOT NULL
);
GO

-- Creating table 'tblMantenimientoEuipo'
CREATE TABLE [dbo].[tblMantenimientoEuipo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tblEquipo_Id] int  NOT NULL,
    [tblMantenimiento_Id] int  NOT NULL
);
GO

-- Creating table 'tblCalibracionEquipo'
CREATE TABLE [dbo].[tblCalibracionEquipo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tblCalibracion_Id] int  NOT NULL,
    [tblEquipo_Id] int  NOT NULL
);
GO

-- Creating table 'tblComputo'
CREATE TABLE [dbo].[tblComputo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Ip] nvarchar(max)  NOT NULL,
    [CuentaAdmin] bit  NULL,
    [Backup] bit  NULL,
    [Procesador] nvarchar(max)  NOT NULL,
    [Ram] nvarchar(max)  NOT NULL,
    [Disco] nvarchar(max)  NOT NULL,
    [Observaciones] nvarchar(max)  NOT NULL,
    [tblEquipo_Id] int  NOT NULL,
    [tblImpresora_Id] int  NULL
);
GO

-- Creating table 'tblEquipoTecnico'
CREATE TABLE [dbo].[tblEquipoTecnico] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClaseEquipo] nvarchar(max)  NOT NULL,
    [Caracteristicas] nvarchar(max)  NOT NULL,
    [Aire] bit  NOT NULL,
    [Electricidad] bit  NOT NULL,
    [Gas] bit  NOT NULL,
    [Aceite] bit  NOT NULL,
    [Otros] bit  NOT NULL,
    [PresionAire] nvarchar(max)  NOT NULL,
    [Caudal] nvarchar(max)  NOT NULL,
    [Voltaje] nvarchar(max)  NOT NULL,
    [Amperaje] nvarchar(max)  NOT NULL,
    [Potencia] nvarchar(max)  NOT NULL,
    [TipoGas] nvarchar(max)  NOT NULL,
    [PresionGas] nvarchar(max)  NOT NULL,
    [TipoAceite] nvarchar(max)  NOT NULL,
    [Especifique] nvarchar(max)  NOT NULL,
    [Observaciones] nvarchar(max)  NOT NULL,
    [tblEquipo_Id] int  NOT NULL,
    [tblTipoPatron_Id] int  NULL
);
GO

-- Creating table 'tblTipoPatron'
CREATE TABLE [dbo].[tblTipoPatron] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblAccesorios'
CREATE TABLE [dbo].[tblAccesorios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblEquipoAccesorio'
CREATE TABLE [dbo].[tblEquipoAccesorio] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tblEquipo_Id] int  NOT NULL,
    [tblAccesorios_Id] int  NOT NULL
);
GO

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'tblDetallesDocumentoSet'
CREATE TABLE [dbo].[tblDetallesDocumentoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Version] nvarchar(max)  NOT NULL,
    [RutaDoc] nvarchar(max)  NOT NULL,
    [Descargable] bit  NOT NULL,
    [Fisico] bit  NOT NULL,
    [Digital] bit  NOT NULL,
    [TipoSolicitud] nvarchar(max)  NOT NULL,
    [FechaSolicitud] datetime  NOT NULL,
    [FechaRevision] datetime  NULL,
    [FechaAprovacion] datetime  NULL,
    [CopiaControlada] nvarchar(max)  NOT NULL,
    [FechaCopiaControlada] datetime  NULL,
    [Activo] bit  NOT NULL,
    [tblDocumento_Id] int  NOT NULL,
    [tblSolicitante_Id] int  NULL,
    [tblRevisor_Id] int  NULL,
    [tblAprovador_Id] int  NULL
);
GO

-- Creating table 'tblCotizacion'
CREATE TABLE [dbo].[tblCotizacion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Fecha] datetime  NOT NULL,
    [ValorTotal] decimal(18,2)  NULL,
    [ValidezOferta] nvarchar(max)  NOT NULL,
    [NumeroFicha] nvarchar(max)  NULL,
    [TipoCotizacion] nvarchar(max)  NOT NULL,
    [Observaciones] nvarchar(max)  NULL,
    [tblProgramaFormacion_Id] int  NULL,
    [tblElaborador_Id] int  NULL,
    [tblAutorizador_Id] int  NULL,
    [tblRevisador_Id] int  NULL,
    [tblCliente_Id] int  NOT NULL
);
GO

-- Creating table 'tblTerminoCondicion'
CREATE TABLE [dbo].[tblTerminoCondicion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblTerminoCotizacion'
CREATE TABLE [dbo].[tblTerminoCotizacion] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tblTerminoCondicion_Id] int  NOT NULL,
    [tblCotizacion_Id] int  NOT NULL
);
GO

-- Creating table 'tblCotizacionDetalle'
CREATE TABLE [dbo].[tblCotizacionDetalle] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PrecioServicio] decimal(18,2)  NULL,
    [Cantidad] decimal(18,0)  NOT NULL,
    [ValorUnitario] decimal(18,2)  NULL,
    [Observaciones] nvarchar(max)  NULL,
    [tblCotizacion_Id] int  NOT NULL,
    [tblServicio_Id] int  NOT NULL
);
GO

-- Creating table 'tblCliente'
CREATE TABLE [dbo].[tblCliente] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [tblPersona_Id] int  NOT NULL
);
GO

-- Creating table 'tblCargo'
CREATE TABLE [dbo].[tblCargo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'tblOrdenTrabajo'
CREATE TABLE [dbo].[tblOrdenTrabajo] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AutorizaIngreso] bit  NOT NULL,
    [NumeroOT] nvarchar(max)  NOT NULL,
    [FechaEmision] datetime  NOT NULL,
    [FechaLimite] datetime  NOT NULL,
    [FechaIngresoItem] datetime  NOT NULL,
    [Observaciones] nvarchar(max)  NULL,
    [tblAreaTecnica_Id] int  NULL,
    [tblCotizacion_Id] int  NULL,
    [tblResponsable_Id] int  NOT NULL
);
GO

-- Creating table 'tblOrdenTrabajoDetalles'
CREATE TABLE [dbo].[tblOrdenTrabajoDetalles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Cantidad] decimal(18,0)  NOT NULL,
    [CodigoItem] nvarchar(max)  NOT NULL,
    [Servicio] nvarchar(max)  NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFinal] datetime  NOT NULL,
    [Observaciones] nvarchar(max)  NULL,
    [tblOrdenTrabajo_Id] int  NOT NULL
);
GO

-- Creating table 'tblFamilia'
CREATE TABLE [dbo].[tblFamilia] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Activo] bit  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'tblProyecto'
ALTER TABLE [dbo].[tblProyecto]
ADD CONSTRAINT [PK_tblProyecto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblRegion'
ALTER TABLE [dbo].[tblRegion]
ADD CONSTRAINT [PK_tblRegion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblRegional'
ALTER TABLE [dbo].[tblRegional]
ADD CONSTRAINT [PK_tblRegional]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblCentroFormacion'
ALTER TABLE [dbo].[tblCentroFormacion]
ADD CONSTRAINT [PK_tblCentroFormacion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblLineaProgramatica'
ALTER TABLE [dbo].[tblLineaProgramatica]
ADD CONSTRAINT [PK_tblLineaProgramatica]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblAreaConocimiento'
ALTER TABLE [dbo].[tblAreaConocimiento]
ADD CONSTRAINT [PK_tblAreaConocimiento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblRolSennova'
ALTER TABLE [dbo].[tblRolSennova]
ADD CONSTRAINT [PK_tblRolSennova]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblRedConocimientoSectorial'
ALTER TABLE [dbo].[tblRedConocimientoSectorial]
ADD CONSTRAINT [PK_tblRedConocimientoSectorial]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblPersona'
ALTER TABLE [dbo].[tblPersona]
ADD CONSTRAINT [PK_tblPersona]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblTipoDocumento'
ALTER TABLE [dbo].[tblTipoDocumento]
ADD CONSTRAINT [PK_tblTipoDocumento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblObjetivoEspecifico'
ALTER TABLE [dbo].[tblObjetivoEspecifico]
ADD CONSTRAINT [PK_tblObjetivoEspecifico]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblActividad'
ALTER TABLE [dbo].[tblActividad]
ADD CONSTRAINT [PK_tblActividad]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblProducto'
ALTER TABLE [dbo].[tblProducto]
ADD CONSTRAINT [PK_tblProducto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblTipoProducto'
ALTER TABLE [dbo].[tblTipoProducto]
ADD CONSTRAINT [PK_tblTipoProducto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblAvanceProyecto'
ALTER TABLE [dbo].[tblAvanceProyecto]
ADD CONSTRAINT [PK_tblAvanceProyecto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblRubro'
ALTER TABLE [dbo].[tblRubro]
ADD CONSTRAINT [PK_tblRubro]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblProyectoRubro'
ALTER TABLE [dbo].[tblProyectoRubro]
ADD CONSTRAINT [PK_tblProyectoRubro]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblIngreso'
ALTER TABLE [dbo].[tblIngreso]
ADD CONSTRAINT [PK_tblIngreso]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblAreaTecnica'
ALTER TABLE [dbo].[tblAreaTecnica]
ADD CONSTRAINT [PK_tblAreaTecnica]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblTipoAreaTecnica'
ALTER TABLE [dbo].[tblTipoAreaTecnica]
ADD CONSTRAINT [PK_tblTipoAreaTecnica]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblServicio'
ALTER TABLE [dbo].[tblServicio]
ADD CONSTRAINT [PK_tblServicio]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblIngresosAreasTecnicas'
ALTER TABLE [dbo].[tblIngresosAreasTecnicas]
ADD CONSTRAINT [PK_tblIngresosAreasTecnicas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblProgramaFormacion'
ALTER TABLE [dbo].[tblProgramaFormacion]
ADD CONSTRAINT [PK_tblProgramaFormacion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblEmpleado'
ALTER TABLE [dbo].[tblEmpleado]
ADD CONSTRAINT [PK_tblEmpleado]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblVisitante'
ALTER TABLE [dbo].[tblVisitante]
ADD CONSTRAINT [PK_tblVisitante]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblTipoVisitante'
ALTER TABLE [dbo].[tblTipoVisitante]
ADD CONSTRAINT [PK_tblTipoVisitante]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblEmpresa'
ALTER TABLE [dbo].[tblEmpresa]
ADD CONSTRAINT [PK_tblEmpresa]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblSectorEconomico'
ALTER TABLE [dbo].[tblSectorEconomico]
ADD CONSTRAINT [PK_tblSectorEconomico]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblDocumento'
ALTER TABLE [dbo].[tblDocumento]
ADD CONSTRAINT [PK_tblDocumento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblTiposDocumentos'
ALTER TABLE [dbo].[tblTiposDocumentos]
ADD CONSTRAINT [PK_tblTiposDocumentos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblMacroProcesos'
ALTER TABLE [dbo].[tblMacroProcesos]
ADD CONSTRAINT [PK_tblMacroProcesos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblProcesos'
ALTER TABLE [dbo].[tblProcesos]
ADD CONSTRAINT [PK_tblProcesos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblProcedimiento'
ALTER TABLE [dbo].[tblProcedimiento]
ADD CONSTRAINT [PK_tblProcedimiento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblDetallesDocumento'
ALTER TABLE [dbo].[tblDetallesDocumento]
ADD CONSTRAINT [PK_tblDetallesDocumento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblImpresora'
ALTER TABLE [dbo].[tblImpresora]
ADD CONSTRAINT [PK_tblImpresora]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblSoftware'
ALTER TABLE [dbo].[tblSoftware]
ADD CONSTRAINT [PK_tblSoftware]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblTipoLicencia'
ALTER TABLE [dbo].[tblTipoLicencia]
ADD CONSTRAINT [PK_tblTipoLicencia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblTipoEquipo'
ALTER TABLE [dbo].[tblTipoEquipo]
ADD CONSTRAINT [PK_tblTipoEquipo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblEquipo'
ALTER TABLE [dbo].[tblEquipo]
ADD CONSTRAINT [PK_tblEquipo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblEquipoSoftware'
ALTER TABLE [dbo].[tblEquipoSoftware]
ADD CONSTRAINT [PK_tblEquipoSoftware]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblCalibracion'
ALTER TABLE [dbo].[tblCalibracion]
ADD CONSTRAINT [PK_tblCalibracion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblMantenimiento'
ALTER TABLE [dbo].[tblMantenimiento]
ADD CONSTRAINT [PK_tblMantenimiento]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblMantenimientoEuipo'
ALTER TABLE [dbo].[tblMantenimientoEuipo]
ADD CONSTRAINT [PK_tblMantenimientoEuipo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblCalibracionEquipo'
ALTER TABLE [dbo].[tblCalibracionEquipo]
ADD CONSTRAINT [PK_tblCalibracionEquipo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblComputo'
ALTER TABLE [dbo].[tblComputo]
ADD CONSTRAINT [PK_tblComputo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblEquipoTecnico'
ALTER TABLE [dbo].[tblEquipoTecnico]
ADD CONSTRAINT [PK_tblEquipoTecnico]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblTipoPatron'
ALTER TABLE [dbo].[tblTipoPatron]
ADD CONSTRAINT [PK_tblTipoPatron]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblAccesorios'
ALTER TABLE [dbo].[tblAccesorios]
ADD CONSTRAINT [PK_tblAccesorios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblEquipoAccesorio'
ALTER TABLE [dbo].[tblEquipoAccesorio]
ADD CONSTRAINT [PK_tblEquipoAccesorio]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblDetallesDocumentoSet'
ALTER TABLE [dbo].[tblDetallesDocumentoSet]
ADD CONSTRAINT [PK_tblDetallesDocumentoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblCotizacion'
ALTER TABLE [dbo].[tblCotizacion]
ADD CONSTRAINT [PK_tblCotizacion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblTerminoCondicion'
ALTER TABLE [dbo].[tblTerminoCondicion]
ADD CONSTRAINT [PK_tblTerminoCondicion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblTerminoCotizacion'
ALTER TABLE [dbo].[tblTerminoCotizacion]
ADD CONSTRAINT [PK_tblTerminoCotizacion]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblCotizacionDetalle'
ALTER TABLE [dbo].[tblCotizacionDetalle]
ADD CONSTRAINT [PK_tblCotizacionDetalle]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblCliente'
ALTER TABLE [dbo].[tblCliente]
ADD CONSTRAINT [PK_tblCliente]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblCargo'
ALTER TABLE [dbo].[tblCargo]
ADD CONSTRAINT [PK_tblCargo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblOrdenTrabajo'
ALTER TABLE [dbo].[tblOrdenTrabajo]
ADD CONSTRAINT [PK_tblOrdenTrabajo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblOrdenTrabajoDetalles'
ALTER TABLE [dbo].[tblOrdenTrabajoDetalles]
ADD CONSTRAINT [PK_tblOrdenTrabajoDetalles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'tblFamilia'
ALTER TABLE [dbo].[tblFamilia]
ADD CONSTRAINT [PK_tblFamilia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [tblCentroFormacion_Id] in table 'tblProyecto'
ALTER TABLE [dbo].[tblProyecto]
ADD CONSTRAINT [FK_tblProyectotblCentroFormacion]
    FOREIGN KEY ([tblCentroFormacion_Id])
    REFERENCES [dbo].[tblCentroFormacion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProyectotblCentroFormacion'
CREATE INDEX [IX_FK_tblProyectotblCentroFormacion]
ON [dbo].[tblProyecto]
    ([tblCentroFormacion_Id]);
GO

-- Creating foreign key on [tblLineaProgramatica_Id] in table 'tblProyecto'
ALTER TABLE [dbo].[tblProyecto]
ADD CONSTRAINT [FK_tblProyectotblLineaProgramatica]
    FOREIGN KEY ([tblLineaProgramatica_Id])
    REFERENCES [dbo].[tblLineaProgramatica]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProyectotblLineaProgramatica'
CREATE INDEX [IX_FK_tblProyectotblLineaProgramatica]
ON [dbo].[tblProyecto]
    ([tblLineaProgramatica_Id]);
GO

-- Creating foreign key on [tblRedConocimientoSectorial_Id] in table 'tblProyecto'
ALTER TABLE [dbo].[tblProyecto]
ADD CONSTRAINT [FK_tblProyectotblRedConocimientoSectorial]
    FOREIGN KEY ([tblRedConocimientoSectorial_Id])
    REFERENCES [dbo].[tblRedConocimientoSectorial]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProyectotblRedConocimientoSectorial'
CREATE INDEX [IX_FK_tblProyectotblRedConocimientoSectorial]
ON [dbo].[tblProyecto]
    ([tblRedConocimientoSectorial_Id]);
GO

-- Creating foreign key on [tblAreaConocimiento_Id] in table 'tblProyecto'
ALTER TABLE [dbo].[tblProyecto]
ADD CONSTRAINT [FK_tblProyectotblAreaConocimiento]
    FOREIGN KEY ([tblAreaConocimiento_Id])
    REFERENCES [dbo].[tblAreaConocimiento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProyectotblAreaConocimiento'
CREATE INDEX [IX_FK_tblProyectotblAreaConocimiento]
ON [dbo].[tblProyecto]
    ([tblAreaConocimiento_Id]);
GO

-- Creating foreign key on [tblTipoDocumento_Id] in table 'tblPersona'
ALTER TABLE [dbo].[tblPersona]
ADD CONSTRAINT [FK_tblPersonatblTipoDocumento]
    FOREIGN KEY ([tblTipoDocumento_Id])
    REFERENCES [dbo].[tblTipoDocumento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblPersonatblTipoDocumento'
CREATE INDEX [IX_FK_tblPersonatblTipoDocumento]
ON [dbo].[tblPersona]
    ([tblTipoDocumento_Id]);
GO

-- Creating foreign key on [tblTipoProducto_Id] in table 'tblProducto'
ALTER TABLE [dbo].[tblProducto]
ADD CONSTRAINT [FK_tblProductotblTipoProducto]
    FOREIGN KEY ([tblTipoProducto_Id])
    REFERENCES [dbo].[tblTipoProducto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductotblTipoProducto'
CREATE INDEX [IX_FK_tblProductotblTipoProducto]
ON [dbo].[tblProducto]
    ([tblTipoProducto_Id]);
GO

-- Creating foreign key on [tblProyecto_Id] in table 'tblObjetivoEspecifico'
ALTER TABLE [dbo].[tblObjetivoEspecifico]
ADD CONSTRAINT [FK_tblObjetivoEspecificotblProyecto]
    FOREIGN KEY ([tblProyecto_Id])
    REFERENCES [dbo].[tblProyecto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblObjetivoEspecificotblProyecto'
CREATE INDEX [IX_FK_tblObjetivoEspecificotblProyecto]
ON [dbo].[tblObjetivoEspecifico]
    ([tblProyecto_Id]);
GO

-- Creating foreign key on [tblActividad_Id] in table 'tblProducto'
ALTER TABLE [dbo].[tblProducto]
ADD CONSTRAINT [FK_tblProductotblActividad]
    FOREIGN KEY ([tblActividad_Id])
    REFERENCES [dbo].[tblActividad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProductotblActividad'
CREATE INDEX [IX_FK_tblProductotblActividad]
ON [dbo].[tblProducto]
    ([tblActividad_Id]);
GO

-- Creating foreign key on [tblActividad_Id] in table 'tblAvanceProyecto'
ALTER TABLE [dbo].[tblAvanceProyecto]
ADD CONSTRAINT [FK_tblAvanceProyectotblActividad]
    FOREIGN KEY ([tblActividad_Id])
    REFERENCES [dbo].[tblActividad]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAvanceProyectotblActividad'
CREATE INDEX [IX_FK_tblAvanceProyectotblActividad]
ON [dbo].[tblAvanceProyecto]
    ([tblActividad_Id]);
GO

-- Creating foreign key on [tblRegion_Id] in table 'tblRegional'
ALTER TABLE [dbo].[tblRegional]
ADD CONSTRAINT [FK_tblRegionaltblRegion]
    FOREIGN KEY ([tblRegion_Id])
    REFERENCES [dbo].[tblRegion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblRegionaltblRegion'
CREATE INDEX [IX_FK_tblRegionaltblRegion]
ON [dbo].[tblRegional]
    ([tblRegion_Id]);
GO

-- Creating foreign key on [tblRegional_Id] in table 'tblCentroFormacion'
ALTER TABLE [dbo].[tblCentroFormacion]
ADD CONSTRAINT [FK_tblCentroFormaciontblRegional]
    FOREIGN KEY ([tblRegional_Id])
    REFERENCES [dbo].[tblRegional]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCentroFormaciontblRegional'
CREATE INDEX [IX_FK_tblCentroFormaciontblRegional]
ON [dbo].[tblCentroFormacion]
    ([tblRegional_Id]);
GO

-- Creating foreign key on [tblObjetivoEspecifico_Id] in table 'tblActividad'
ALTER TABLE [dbo].[tblActividad]
ADD CONSTRAINT [FK_tblActividadtblObjetivoEspecifico]
    FOREIGN KEY ([tblObjetivoEspecifico_Id])
    REFERENCES [dbo].[tblObjetivoEspecifico]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblActividadtblObjetivoEspecifico'
CREATE INDEX [IX_FK_tblActividadtblObjetivoEspecifico]
ON [dbo].[tblActividad]
    ([tblObjetivoEspecifico_Id]);
GO

-- Creating foreign key on [tblProyecto_Id] in table 'tblProyectoRubro'
ALTER TABLE [dbo].[tblProyectoRubro]
ADD CONSTRAINT [FK_tblProyectoRubrotblProyecto]
    FOREIGN KEY ([tblProyecto_Id])
    REFERENCES [dbo].[tblProyecto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProyectoRubrotblProyecto'
CREATE INDEX [IX_FK_tblProyectoRubrotblProyecto]
ON [dbo].[tblProyectoRubro]
    ([tblProyecto_Id]);
GO

-- Creating foreign key on [tblRubro_Id] in table 'tblProyectoRubro'
ALTER TABLE [dbo].[tblProyectoRubro]
ADD CONSTRAINT [FK_tblProyectoRubrotblRubro]
    FOREIGN KEY ([tblRubro_Id])
    REFERENCES [dbo].[tblRubro]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProyectoRubrotblRubro'
CREATE INDEX [IX_FK_tblProyectoRubrotblRubro]
ON [dbo].[tblProyectoRubro]
    ([tblRubro_Id]);
GO

-- Creating foreign key on [tblTipoAreaTecnica_Id] in table 'tblAreaTecnica'
ALTER TABLE [dbo].[tblAreaTecnica]
ADD CONSTRAINT [FK_tblAreaTecnicatblTipoAreaTecnica]
    FOREIGN KEY ([tblTipoAreaTecnica_Id])
    REFERENCES [dbo].[tblTipoAreaTecnica]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAreaTecnicatblTipoAreaTecnica'
CREATE INDEX [IX_FK_tblAreaTecnicatblTipoAreaTecnica]
ON [dbo].[tblAreaTecnica]
    ([tblTipoAreaTecnica_Id]);
GO

-- Creating foreign key on [tblAreaTecnica_Id] in table 'tblServicio'
ALTER TABLE [dbo].[tblServicio]
ADD CONSTRAINT [FK_tblServiciotblAreaTecnica]
    FOREIGN KEY ([tblAreaTecnica_Id])
    REFERENCES [dbo].[tblAreaTecnica]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblServiciotblAreaTecnica'
CREATE INDEX [IX_FK_tblServiciotblAreaTecnica]
ON [dbo].[tblServicio]
    ([tblAreaTecnica_Id]);
GO

-- Creating foreign key on [tblAreaTecnica_Id] in table 'tblIngresosAreasTecnicas'
ALTER TABLE [dbo].[tblIngresosAreasTecnicas]
ADD CONSTRAINT [FK_tblIngresosAreasTecnicastblAreaTecnica]
    FOREIGN KEY ([tblAreaTecnica_Id])
    REFERENCES [dbo].[tblAreaTecnica]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblIngresosAreasTecnicastblAreaTecnica'
CREATE INDEX [IX_FK_tblIngresosAreasTecnicastblAreaTecnica]
ON [dbo].[tblIngresosAreasTecnicas]
    ([tblAreaTecnica_Id]);
GO

-- Creating foreign key on [tblIngreso_Id] in table 'tblIngresosAreasTecnicas'
ALTER TABLE [dbo].[tblIngresosAreasTecnicas]
ADD CONSTRAINT [FK_tblIngresosAreasTecnicastblIngreso]
    FOREIGN KEY ([tblIngreso_Id])
    REFERENCES [dbo].[tblIngreso]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblIngresosAreasTecnicastblIngreso'
CREATE INDEX [IX_FK_tblIngresosAreasTecnicastblIngreso]
ON [dbo].[tblIngresosAreasTecnicas]
    ([tblIngreso_Id]);
GO

-- Creating foreign key on [tblEmpleado_Id] in table 'tblProyecto'
ALTER TABLE [dbo].[tblProyecto]
ADD CONSTRAINT [FK_tblProyectotblEmpleado]
    FOREIGN KEY ([tblEmpleado_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProyectotblEmpleado'
CREATE INDEX [IX_FK_tblProyectotblEmpleado]
ON [dbo].[tblProyecto]
    ([tblEmpleado_Id]);
GO

-- Creating foreign key on [tblTipoVisitante_Id] in table 'tblVisitante'
ALTER TABLE [dbo].[tblVisitante]
ADD CONSTRAINT [FK_tblVisitantetblTipoVisitante]
    FOREIGN KEY ([tblTipoVisitante_Id])
    REFERENCES [dbo].[tblTipoVisitante]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblVisitantetblTipoVisitante'
CREATE INDEX [IX_FK_tblVisitantetblTipoVisitante]
ON [dbo].[tblVisitante]
    ([tblTipoVisitante_Id]);
GO

-- Creating foreign key on [tblVisitante_Id] in table 'tblIngreso'
ALTER TABLE [dbo].[tblIngreso]
ADD CONSTRAINT [FK_tblIngresotblVisitante]
    FOREIGN KEY ([tblVisitante_Id])
    REFERENCES [dbo].[tblVisitante]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblIngresotblVisitante'
CREATE INDEX [IX_FK_tblIngresotblVisitante]
ON [dbo].[tblIngreso]
    ([tblVisitante_Id]);
GO

-- Creating foreign key on [tblProgramaFormacion_Id] in table 'tblIngreso'
ALTER TABLE [dbo].[tblIngreso]
ADD CONSTRAINT [FK_tblIngresotblProgramaFormacion]
    FOREIGN KEY ([tblProgramaFormacion_Id])
    REFERENCES [dbo].[tblProgramaFormacion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblIngresotblProgramaFormacion'
CREATE INDEX [IX_FK_tblIngresotblProgramaFormacion]
ON [dbo].[tblIngreso]
    ([tblProgramaFormacion_Id]);
GO

-- Creating foreign key on [tblEmpresa_Id] in table 'tblIngreso'
ALTER TABLE [dbo].[tblIngreso]
ADD CONSTRAINT [FK_tblIngresotblEmpresa]
    FOREIGN KEY ([tblEmpresa_Id])
    REFERENCES [dbo].[tblEmpresa]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblIngresotblEmpresa'
CREATE INDEX [IX_FK_tblIngresotblEmpresa]
ON [dbo].[tblIngreso]
    ([tblEmpresa_Id]);
GO

-- Creating foreign key on [tblEmpleado_Id] in table 'tblAreaTecnica'
ALTER TABLE [dbo].[tblAreaTecnica]
ADD CONSTRAINT [FK_tblAreaTecnicatblEmpleado]
    FOREIGN KEY ([tblEmpleado_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblAreaTecnicatblEmpleado'
CREATE INDEX [IX_FK_tblAreaTecnicatblEmpleado]
ON [dbo].[tblAreaTecnica]
    ([tblEmpleado_Id]);
GO

-- Creating foreign key on [tblSectorEconomico_Id] in table 'tblEmpresa'
ALTER TABLE [dbo].[tblEmpresa]
ADD CONSTRAINT [FK_tblEmpresatblSectorEconomico]
    FOREIGN KEY ([tblSectorEconomico_Id])
    REFERENCES [dbo].[tblSectorEconomico]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmpresatblSectorEconomico'
CREATE INDEX [IX_FK_tblEmpresatblSectorEconomico]
ON [dbo].[tblEmpresa]
    ([tblSectorEconomico_Id]);
GO

-- Creating foreign key on [tblPersona_Id] in table 'tblVisitante'
ALTER TABLE [dbo].[tblVisitante]
ADD CONSTRAINT [FK_tblVisitantetblPersona]
    FOREIGN KEY ([tblPersona_Id])
    REFERENCES [dbo].[tblPersona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblVisitantetblPersona'
CREATE INDEX [IX_FK_tblVisitantetblPersona]
ON [dbo].[tblVisitante]
    ([tblPersona_Id]);
GO

-- Creating foreign key on [tblPersona_Id] in table 'tblEmpleado'
ALTER TABLE [dbo].[tblEmpleado]
ADD CONSTRAINT [FK_tblEmpleadotblPersona]
    FOREIGN KEY ([tblPersona_Id])
    REFERENCES [dbo].[tblPersona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmpleadotblPersona'
CREATE INDEX [IX_FK_tblEmpleadotblPersona]
ON [dbo].[tblEmpleado]
    ([tblPersona_Id]);
GO

-- Creating foreign key on [tblEmpleado_Id] in table 'tblIngreso'
ALTER TABLE [dbo].[tblIngreso]
ADD CONSTRAINT [FK_tblIngresotblEmpleado]
    FOREIGN KEY ([tblEmpleado_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblIngresotblEmpleado'
CREATE INDEX [IX_FK_tblIngresotblEmpleado]
ON [dbo].[tblIngreso]
    ([tblEmpleado_Id]);
GO

-- Creating foreign key on [tblTiposDocumentos_Id] in table 'tblDocumento'
ALTER TABLE [dbo].[tblDocumento]
ADD CONSTRAINT [FK_tblDocumentotblTiposDocumentos]
    FOREIGN KEY ([tblTiposDocumentos_Id])
    REFERENCES [dbo].[tblTiposDocumentos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDocumentotblTiposDocumentos'
CREATE INDEX [IX_FK_tblDocumentotblTiposDocumentos]
ON [dbo].[tblDocumento]
    ([tblTiposDocumentos_Id]);
GO

-- Creating foreign key on [tblDocumento_Id] in table 'tblDetallesDocumento'
ALTER TABLE [dbo].[tblDetallesDocumento]
ADD CONSTRAINT [FK_tblDetallesDocumentotblDocumento]
    FOREIGN KEY ([tblDocumento_Id])
    REFERENCES [dbo].[tblDocumento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDetallesDocumentotblDocumento'
CREATE INDEX [IX_FK_tblDetallesDocumentotblDocumento]
ON [dbo].[tblDetallesDocumento]
    ([tblDocumento_Id]);
GO

-- Creating foreign key on [tblProcedimiento_Id] in table 'tblDocumento'
ALTER TABLE [dbo].[tblDocumento]
ADD CONSTRAINT [FK_tblDocumentotblProcedimiento]
    FOREIGN KEY ([tblProcedimiento_Id])
    REFERENCES [dbo].[tblProcedimiento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDocumentotblProcedimiento'
CREATE INDEX [IX_FK_tblDocumentotblProcedimiento]
ON [dbo].[tblDocumento]
    ([tblProcedimiento_Id]);
GO

-- Creating foreign key on [tblSolicitante_Id] in table 'tblDetallesDocumento'
ALTER TABLE [dbo].[tblDetallesDocumento]
ADD CONSTRAINT [FK_tblDetallesDocumentotblEmpleado]
    FOREIGN KEY ([tblSolicitante_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDetallesDocumentotblEmpleado'
CREATE INDEX [IX_FK_tblDetallesDocumentotblEmpleado]
ON [dbo].[tblDetallesDocumento]
    ([tblSolicitante_Id]);
GO

-- Creating foreign key on [tblRevisor_Id] in table 'tblDetallesDocumento'
ALTER TABLE [dbo].[tblDetallesDocumento]
ADD CONSTRAINT [FK_tblDetallesDocumentotblEmpleado1]
    FOREIGN KEY ([tblRevisor_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDetallesDocumentotblEmpleado1'
CREATE INDEX [IX_FK_tblDetallesDocumentotblEmpleado1]
ON [dbo].[tblDetallesDocumento]
    ([tblRevisor_Id]);
GO

-- Creating foreign key on [tblAprovador_Id] in table 'tblDetallesDocumento'
ALTER TABLE [dbo].[tblDetallesDocumento]
ADD CONSTRAINT [FK_tblDetallesDocumentotblEmpleado2]
    FOREIGN KEY ([tblAprovador_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDetallesDocumentotblEmpleado2'
CREATE INDEX [IX_FK_tblDetallesDocumentotblEmpleado2]
ON [dbo].[tblDetallesDocumento]
    ([tblAprovador_Id]);
GO

-- Creating foreign key on [tblProcesos_Id] in table 'tblProcedimiento'
ALTER TABLE [dbo].[tblProcedimiento]
ADD CONSTRAINT [FK_tblProcedimientotblProcesos]
    FOREIGN KEY ([tblProcesos_Id])
    REFERENCES [dbo].[tblProcesos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProcedimientotblProcesos'
CREATE INDEX [IX_FK_tblProcedimientotblProcesos]
ON [dbo].[tblProcedimiento]
    ([tblProcesos_Id]);
GO

-- Creating foreign key on [tblMacroProcesos_Id] in table 'tblProcesos'
ALTER TABLE [dbo].[tblProcesos]
ADD CONSTRAINT [FK_tblProcesostblMacroProcesos]
    FOREIGN KEY ([tblMacroProcesos_Id])
    REFERENCES [dbo].[tblMacroProcesos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblProcesostblMacroProcesos'
CREATE INDEX [IX_FK_tblProcesostblMacroProcesos]
ON [dbo].[tblProcesos]
    ([tblMacroProcesos_Id]);
GO

-- Creating foreign key on [tblTipoLicencia_Id] in table 'tblSoftware'
ALTER TABLE [dbo].[tblSoftware]
ADD CONSTRAINT [FK_tblSoftwaretblTipoLicencia]
    FOREIGN KEY ([tblTipoLicencia_Id])
    REFERENCES [dbo].[tblTipoLicencia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblSoftwaretblTipoLicencia'
CREATE INDEX [IX_FK_tblSoftwaretblTipoLicencia]
ON [dbo].[tblSoftware]
    ([tblTipoLicencia_Id]);
GO

-- Creating foreign key on [tblTipoEquipo_Id] in table 'tblEquipo'
ALTER TABLE [dbo].[tblEquipo]
ADD CONSTRAINT [FK_tblEquipotblTipoEquipo]
    FOREIGN KEY ([tblTipoEquipo_Id])
    REFERENCES [dbo].[tblTipoEquipo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEquipotblTipoEquipo'
CREATE INDEX [IX_FK_tblEquipotblTipoEquipo]
ON [dbo].[tblEquipo]
    ([tblTipoEquipo_Id]);
GO

-- Creating foreign key on [tblSoftware_Id] in table 'tblEquipoSoftware'
ALTER TABLE [dbo].[tblEquipoSoftware]
ADD CONSTRAINT [FK_tblEquipoSoftwaretblSoftware]
    FOREIGN KEY ([tblSoftware_Id])
    REFERENCES [dbo].[tblSoftware]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEquipoSoftwaretblSoftware'
CREATE INDEX [IX_FK_tblEquipoSoftwaretblSoftware]
ON [dbo].[tblEquipoSoftware]
    ([tblSoftware_Id]);
GO

-- Creating foreign key on [tblEquipo_Id] in table 'tblMantenimientoEuipo'
ALTER TABLE [dbo].[tblMantenimientoEuipo]
ADD CONSTRAINT [FK_tblMantenimientoEuipotblEquipo]
    FOREIGN KEY ([tblEquipo_Id])
    REFERENCES [dbo].[tblEquipo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblMantenimientoEuipotblEquipo'
CREATE INDEX [IX_FK_tblMantenimientoEuipotblEquipo]
ON [dbo].[tblMantenimientoEuipo]
    ([tblEquipo_Id]);
GO

-- Creating foreign key on [tblMantenimiento_Id] in table 'tblMantenimientoEuipo'
ALTER TABLE [dbo].[tblMantenimientoEuipo]
ADD CONSTRAINT [FK_tblMantenimientoEuipotblMantenimiento]
    FOREIGN KEY ([tblMantenimiento_Id])
    REFERENCES [dbo].[tblMantenimiento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblMantenimientoEuipotblMantenimiento'
CREATE INDEX [IX_FK_tblMantenimientoEuipotblMantenimiento]
ON [dbo].[tblMantenimientoEuipo]
    ([tblMantenimiento_Id]);
GO

-- Creating foreign key on [tblCalibracion_Id] in table 'tblCalibracionEquipo'
ALTER TABLE [dbo].[tblCalibracionEquipo]
ADD CONSTRAINT [FK_tblCalibracionEquipotblCalibracion]
    FOREIGN KEY ([tblCalibracion_Id])
    REFERENCES [dbo].[tblCalibracion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCalibracionEquipotblCalibracion'
CREATE INDEX [IX_FK_tblCalibracionEquipotblCalibracion]
ON [dbo].[tblCalibracionEquipo]
    ([tblCalibracion_Id]);
GO

-- Creating foreign key on [tblEquipo_Id] in table 'tblCalibracionEquipo'
ALTER TABLE [dbo].[tblCalibracionEquipo]
ADD CONSTRAINT [FK_tblCalibracionEquipotblEquipo]
    FOREIGN KEY ([tblEquipo_Id])
    REFERENCES [dbo].[tblEquipo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCalibracionEquipotblEquipo'
CREATE INDEX [IX_FK_tblCalibracionEquipotblEquipo]
ON [dbo].[tblCalibracionEquipo]
    ([tblEquipo_Id]);
GO

-- Creating foreign key on [Responsable_Id] in table 'tblEquipo'
ALTER TABLE [dbo].[tblEquipo]
ADD CONSTRAINT [FK_tblEquipotblEmpleado]
    FOREIGN KEY ([Responsable_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEquipotblEmpleado'
CREATE INDEX [IX_FK_tblEquipotblEmpleado]
ON [dbo].[tblEquipo]
    ([Responsable_Id]);
GO

-- Creating foreign key on [Ejecutor_Id] in table 'tblMantenimiento'
ALTER TABLE [dbo].[tblMantenimiento]
ADD CONSTRAINT [FK_tblMantenimientotblEmpleado]
    FOREIGN KEY ([Ejecutor_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblMantenimientotblEmpleado'
CREATE INDEX [IX_FK_tblMantenimientotblEmpleado]
ON [dbo].[tblMantenimiento]
    ([Ejecutor_Id]);
GO

-- Creating foreign key on [Revisor_Id] in table 'tblMantenimiento'
ALTER TABLE [dbo].[tblMantenimiento]
ADD CONSTRAINT [FK_tblEmpleadotblMantenimiento]
    FOREIGN KEY ([Revisor_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmpleadotblMantenimiento'
CREATE INDEX [IX_FK_tblEmpleadotblMantenimiento]
ON [dbo].[tblMantenimiento]
    ([Revisor_Id]);
GO

-- Creating foreign key on [tblAreaTecnica_Id] in table 'tblEquipo'
ALTER TABLE [dbo].[tblEquipo]
ADD CONSTRAINT [FK_tblEquipotblAreaTecnica]
    FOREIGN KEY ([tblAreaTecnica_Id])
    REFERENCES [dbo].[tblAreaTecnica]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEquipotblAreaTecnica'
CREATE INDEX [IX_FK_tblEquipotblAreaTecnica]
ON [dbo].[tblEquipo]
    ([tblAreaTecnica_Id]);
GO

-- Creating foreign key on [tblEquipo_Id] in table 'tblComputo'
ALTER TABLE [dbo].[tblComputo]
ADD CONSTRAINT [FK_tblComputotblEquipo]
    FOREIGN KEY ([tblEquipo_Id])
    REFERENCES [dbo].[tblEquipo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblComputotblEquipo'
CREATE INDEX [IX_FK_tblComputotblEquipo]
ON [dbo].[tblComputo]
    ([tblEquipo_Id]);
GO

-- Creating foreign key on [tblImpresora_Id] in table 'tblComputo'
ALTER TABLE [dbo].[tblComputo]
ADD CONSTRAINT [FK_tblComputotblImpresora]
    FOREIGN KEY ([tblImpresora_Id])
    REFERENCES [dbo].[tblImpresora]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblComputotblImpresora'
CREATE INDEX [IX_FK_tblComputotblImpresora]
ON [dbo].[tblComputo]
    ([tblImpresora_Id]);
GO

-- Creating foreign key on [tblComputo_Id] in table 'tblEquipoSoftware'
ALTER TABLE [dbo].[tblEquipoSoftware]
ADD CONSTRAINT [FK_tblEquipoSoftwaretblComputo]
    FOREIGN KEY ([tblComputo_Id])
    REFERENCES [dbo].[tblComputo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEquipoSoftwaretblComputo'
CREATE INDEX [IX_FK_tblEquipoSoftwaretblComputo]
ON [dbo].[tblEquipoSoftware]
    ([tblComputo_Id]);
GO

-- Creating foreign key on [tblEquipo_Id] in table 'tblEquipoTecnico'
ALTER TABLE [dbo].[tblEquipoTecnico]
ADD CONSTRAINT [FK_tblEquipoTecnicotblEquipo]
    FOREIGN KEY ([tblEquipo_Id])
    REFERENCES [dbo].[tblEquipo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEquipoTecnicotblEquipo'
CREATE INDEX [IX_FK_tblEquipoTecnicotblEquipo]
ON [dbo].[tblEquipoTecnico]
    ([tblEquipo_Id]);
GO

-- Creating foreign key on [tblTipoPatron_Id] in table 'tblEquipoTecnico'
ALTER TABLE [dbo].[tblEquipoTecnico]
ADD CONSTRAINT [FK_tblEquipoTecnicotblTipoPatron]
    FOREIGN KEY ([tblTipoPatron_Id])
    REFERENCES [dbo].[tblTipoPatron]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEquipoTecnicotblTipoPatron'
CREATE INDEX [IX_FK_tblEquipoTecnicotblTipoPatron]
ON [dbo].[tblEquipoTecnico]
    ([tblTipoPatron_Id]);
GO

-- Creating foreign key on [tblEquipo_Id] in table 'tblEquipoAccesorio'
ALTER TABLE [dbo].[tblEquipoAccesorio]
ADD CONSTRAINT [FK_tblEquipoAccesoriotblEquipo]
    FOREIGN KEY ([tblEquipo_Id])
    REFERENCES [dbo].[tblEquipo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEquipoAccesoriotblEquipo'
CREATE INDEX [IX_FK_tblEquipoAccesoriotblEquipo]
ON [dbo].[tblEquipoAccesorio]
    ([tblEquipo_Id]);
GO

-- Creating foreign key on [tblAccesorios_Id] in table 'tblEquipoAccesorio'
ALTER TABLE [dbo].[tblEquipoAccesorio]
ADD CONSTRAINT [FK_tblEquipoAccesoriotblAccesorios]
    FOREIGN KEY ([tblAccesorios_Id])
    REFERENCES [dbo].[tblAccesorios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEquipoAccesoriotblAccesorios'
CREATE INDEX [IX_FK_tblEquipoAccesoriotblAccesorios]
ON [dbo].[tblEquipoAccesorio]
    ([tblAccesorios_Id]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [tblDocumento_Id] in table 'tblDetallesDocumentoSet'
ALTER TABLE [dbo].[tblDetallesDocumentoSet]
ADD CONSTRAINT [FK_tblDetallesDocumentotblDocumento]
    FOREIGN KEY ([tblDocumento_Id])
    REFERENCES [dbo].[tblDocumento]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDetallesDocumentotblDocumento'
CREATE INDEX [IX_FK_tblDetallesDocumentotblDocumento]
ON [dbo].[tblDetallesDocumentoSet]
    ([tblDocumento_Id]);
GO

-- Creating foreign key on [tblSolicitante_Id] in table 'tblDetallesDocumentoSet'
ALTER TABLE [dbo].[tblDetallesDocumentoSet]
ADD CONSTRAINT [FK_tblDetallesDocumentotblEmpleado]
    FOREIGN KEY ([tblSolicitante_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDetallesDocumentotblEmpleado'
CREATE INDEX [IX_FK_tblDetallesDocumentotblEmpleado]
ON [dbo].[tblDetallesDocumentoSet]
    ([tblSolicitante_Id]);
GO

-- Creating foreign key on [tblRevisor_Id] in table 'tblDetallesDocumentoSet'
ALTER TABLE [dbo].[tblDetallesDocumentoSet]
ADD CONSTRAINT [FK_tblDetallesDocumentotblEmpleado1]
    FOREIGN KEY ([tblRevisor_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDetallesDocumentotblEmpleado1'
CREATE INDEX [IX_FK_tblDetallesDocumentotblEmpleado1]
ON [dbo].[tblDetallesDocumentoSet]
    ([tblRevisor_Id]);
GO

-- Creating foreign key on [tblAprovador_Id] in table 'tblDetallesDocumentoSet'
ALTER TABLE [dbo].[tblDetallesDocumentoSet]
ADD CONSTRAINT [FK_tblDetallesDocumentotblEmpleado2]
    FOREIGN KEY ([tblAprovador_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblDetallesDocumentotblEmpleado2'
CREATE INDEX [IX_FK_tblDetallesDocumentotblEmpleado2]
ON [dbo].[tblDetallesDocumentoSet]
    ([tblAprovador_Id]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [tblTerminoCondicion_Id] in table 'tblTerminoCotizacion'
ALTER TABLE [dbo].[tblTerminoCotizacion]
ADD CONSTRAINT [FK_tblTerminoCotizaciontblTerminoCondicion]
    FOREIGN KEY ([tblTerminoCondicion_Id])
    REFERENCES [dbo].[tblTerminoCondicion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblTerminoCotizaciontblTerminoCondicion'
CREATE INDEX [IX_FK_tblTerminoCotizaciontblTerminoCondicion]
ON [dbo].[tblTerminoCotizacion]
    ([tblTerminoCondicion_Id]);
GO

-- Creating foreign key on [tblCotizacion_Id] in table 'tblTerminoCotizacion'
ALTER TABLE [dbo].[tblTerminoCotizacion]
ADD CONSTRAINT [FK_tblTerminoCotizaciontblCotizacion]
    FOREIGN KEY ([tblCotizacion_Id])
    REFERENCES [dbo].[tblCotizacion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblTerminoCotizaciontblCotizacion'
CREATE INDEX [IX_FK_tblTerminoCotizaciontblCotizacion]
ON [dbo].[tblTerminoCotizacion]
    ([tblCotizacion_Id]);
GO

-- Creating foreign key on [tblProgramaFormacion_Id] in table 'tblCotizacion'
ALTER TABLE [dbo].[tblCotizacion]
ADD CONSTRAINT [FK_tblCotizaciontblProgramaFormacion]
    FOREIGN KEY ([tblProgramaFormacion_Id])
    REFERENCES [dbo].[tblProgramaFormacion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCotizaciontblProgramaFormacion'
CREATE INDEX [IX_FK_tblCotizaciontblProgramaFormacion]
ON [dbo].[tblCotizacion]
    ([tblProgramaFormacion_Id]);
GO

-- Creating foreign key on [tblElaborador_Id] in table 'tblCotizacion'
ALTER TABLE [dbo].[tblCotizacion]
ADD CONSTRAINT [FK_tblCotizaciontblEmpleado]
    FOREIGN KEY ([tblElaborador_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCotizaciontblEmpleado'
CREATE INDEX [IX_FK_tblCotizaciontblEmpleado]
ON [dbo].[tblCotizacion]
    ([tblElaborador_Id]);
GO

-- Creating foreign key on [tblAutorizador_Id] in table 'tblCotizacion'
ALTER TABLE [dbo].[tblCotizacion]
ADD CONSTRAINT [FK_tblCotizaciontblEmpleado1]
    FOREIGN KEY ([tblAutorizador_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCotizaciontblEmpleado1'
CREATE INDEX [IX_FK_tblCotizaciontblEmpleado1]
ON [dbo].[tblCotizacion]
    ([tblAutorizador_Id]);
GO

-- Creating foreign key on [tblRevisador_Id] in table 'tblCotizacion'
ALTER TABLE [dbo].[tblCotizacion]
ADD CONSTRAINT [FK_tblCotizaciontblEmpleado2]
    FOREIGN KEY ([tblRevisador_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCotizaciontblEmpleado2'
CREATE INDEX [IX_FK_tblCotizaciontblEmpleado2]
ON [dbo].[tblCotizacion]
    ([tblRevisador_Id]);
GO

-- Creating foreign key on [tblCotizacion_Id] in table 'tblCotizacionDetalle'
ALTER TABLE [dbo].[tblCotizacionDetalle]
ADD CONSTRAINT [FK_tblCotizacionDetalletblCotizacion]
    FOREIGN KEY ([tblCotizacion_Id])
    REFERENCES [dbo].[tblCotizacion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCotizacionDetalletblCotizacion'
CREATE INDEX [IX_FK_tblCotizacionDetalletblCotizacion]
ON [dbo].[tblCotizacionDetalle]
    ([tblCotizacion_Id]);
GO

-- Creating foreign key on [tblServicio_Id] in table 'tblCotizacionDetalle'
ALTER TABLE [dbo].[tblCotizacionDetalle]
ADD CONSTRAINT [FK_tblServiciotblCotizacionDetalle]
    FOREIGN KEY ([tblServicio_Id])
    REFERENCES [dbo].[tblServicio]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblServiciotblCotizacionDetalle'
CREATE INDEX [IX_FK_tblServiciotblCotizacionDetalle]
ON [dbo].[tblCotizacionDetalle]
    ([tblServicio_Id]);
GO

-- Creating foreign key on [tblPersona_Id] in table 'tblCliente'
ALTER TABLE [dbo].[tblCliente]
ADD CONSTRAINT [FK_tblClientetblPersona]
    FOREIGN KEY ([tblPersona_Id])
    REFERENCES [dbo].[tblPersona]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblClientetblPersona'
CREATE INDEX [IX_FK_tblClientetblPersona]
ON [dbo].[tblCliente]
    ([tblPersona_Id]);
GO

-- Creating foreign key on [tblCliente_Id] in table 'tblCotizacion'
ALTER TABLE [dbo].[tblCotizacion]
ADD CONSTRAINT [FK_tblCotizaciontblCliente]
    FOREIGN KEY ([tblCliente_Id])
    REFERENCES [dbo].[tblCliente]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblCotizaciontblCliente'
CREATE INDEX [IX_FK_tblCotizaciontblCliente]
ON [dbo].[tblCotizacion]
    ([tblCliente_Id]);
GO

-- Creating foreign key on [tblCargo_Id] in table 'tblEmpleado'
ALTER TABLE [dbo].[tblEmpleado]
ADD CONSTRAINT [FK_tblEmpleadotblCargo]
    FOREIGN KEY ([tblCargo_Id])
    REFERENCES [dbo].[tblCargo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmpleadotblCargo'
CREATE INDEX [IX_FK_tblEmpleadotblCargo]
ON [dbo].[tblEmpleado]
    ([tblCargo_Id]);
GO

-- Creating foreign key on [tblRolSennova_Id] in table 'tblEmpleado'
ALTER TABLE [dbo].[tblEmpleado]
ADD CONSTRAINT [FK_tblEmpleadotblRolSennova]
    FOREIGN KEY ([tblRolSennova_Id])
    REFERENCES [dbo].[tblRolSennova]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblEmpleadotblRolSennova'
CREATE INDEX [IX_FK_tblEmpleadotblRolSennova]
ON [dbo].[tblEmpleado]
    ([tblRolSennova_Id]);
GO

-- Creating foreign key on [tblAreaTecnica_Id] in table 'tblOrdenTrabajo'
ALTER TABLE [dbo].[tblOrdenTrabajo]
ADD CONSTRAINT [FK_tblOrdenTrabajotblAreaTecnica]
    FOREIGN KEY ([tblAreaTecnica_Id])
    REFERENCES [dbo].[tblAreaTecnica]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrdenTrabajotblAreaTecnica'
CREATE INDEX [IX_FK_tblOrdenTrabajotblAreaTecnica]
ON [dbo].[tblOrdenTrabajo]
    ([tblAreaTecnica_Id]);
GO

-- Creating foreign key on [tblCotizacion_Id] in table 'tblOrdenTrabajo'
ALTER TABLE [dbo].[tblOrdenTrabajo]
ADD CONSTRAINT [FK_tblOrdenTrabajotblCotizacion]
    FOREIGN KEY ([tblCotizacion_Id])
    REFERENCES [dbo].[tblCotizacion]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrdenTrabajotblCotizacion'
CREATE INDEX [IX_FK_tblOrdenTrabajotblCotizacion]
ON [dbo].[tblOrdenTrabajo]
    ([tblCotizacion_Id]);
GO

-- Creating foreign key on [tblResponsable_Id] in table 'tblOrdenTrabajo'
ALTER TABLE [dbo].[tblOrdenTrabajo]
ADD CONSTRAINT [FK_tblOrdenTrabajotblEmpleado]
    FOREIGN KEY ([tblResponsable_Id])
    REFERENCES [dbo].[tblEmpleado]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrdenTrabajotblEmpleado'
CREATE INDEX [IX_FK_tblOrdenTrabajotblEmpleado]
ON [dbo].[tblOrdenTrabajo]
    ([tblResponsable_Id]);
GO

-- Creating foreign key on [tblOrdenTrabajo_Id] in table 'tblOrdenTrabajoDetalles'
ALTER TABLE [dbo].[tblOrdenTrabajoDetalles]
ADD CONSTRAINT [FK_tblOrdenTrabajoDetallestblOrdenTrabajo]
    FOREIGN KEY ([tblOrdenTrabajo_Id])
    REFERENCES [dbo].[tblOrdenTrabajo]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblOrdenTrabajoDetallestblOrdenTrabajo'
CREATE INDEX [IX_FK_tblOrdenTrabajoDetallestblOrdenTrabajo]
ON [dbo].[tblOrdenTrabajoDetalles]
    ([tblOrdenTrabajo_Id]);
GO

-- Creating foreign key on [tblFamilia_Id] in table 'tblServicio'
ALTER TABLE [dbo].[tblServicio]
ADD CONSTRAINT [FK_tblServiciotblFamilia]
    FOREIGN KEY ([tblFamilia_Id])
    REFERENCES [dbo].[tblFamilia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tblServiciotblFamilia'
CREATE INDEX [IX_FK_tblServiciotblFamilia]
ON [dbo].[tblServicio]
    ([tblFamilia_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
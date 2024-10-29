<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOrdenTrabajo.aspx.cs" Inherits="Web.Views.Configurations.frmOrdenTrabjo"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel" style="margin-bottom:0px!important">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6 mt-2">
                                <h4>Ordenes de Trabajo</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2 pull-right">
                                <div class="btn-group">
                                    <asp:LinkButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" class="btn btn-outline-primary btn-lg">Guardar</asp:LinkButton>
                                    <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-outline-success btn-lg">Nuevo</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="panel-body">
                        <div class="row">
                            <div id="advertencia" runat="server" class="alert alert-warning alert-dismissable" visible="false">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                <asp:Label Text="Advertencia!" runat="server" Font-Bold="true" />
                                <asp:Label ID="txtMensajeAdvertencia" Text="" runat="server" />
                            </div>
                            <div id="correcto" runat="server" class="alert alert-success alert-dismissable" visible="false">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                <asp:Label Text="Correcto!" runat="server" Font-Bold="true" />
                                <asp:Label ID="txtMensajeCorrecto" Text="" runat="server" />
                            </div>
                            <div id="error" runat="server" class="alert alert-danger alert-dismissable" visible="false">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                <asp:Label Text="Error!" runat="server" Font-Bold="true" />
                                <asp:Label ID="txtMensajeError" Text="" runat="server" />
                            </div>
                        </div>
                        <h4 class="my-3"><label>Generalidades</label></h4>
                        <hr />
                        <asp:TextBox ID="txtIdCotizacion" runat="server" class="form-control" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="txtIdOrdenTrabajo" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>

                        <div class="d-flex">
                            <div class="col-md-3">
                                <label for="txtOtro">Número de Cotización</label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtCodigoCotizacion" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
                                    <asp:LinkButton ID="lnkCotizacion" Text='<i class="fas fa-info mt-2"></i>' CssClass="btn" CommandArgument='<%# Eval("txtIdCotizacion") %>' runat="server" OnClick="lnkCotizacion_Click" ToolTip="Ver cotización." ItemStyle-Width="5%" />
                                </div>
                            </div>

                            <div class="col-md-3">
                                <label for="ddlAreaTecnica">Lugar de ejecución del servicio *</label>
                                <asp:DropDownList ID="ddlAreaTecnica" runat="server" CssClass="form-control" />
                            </div>

                            <div class="col-md-3">
                                <label for="txtOtro">Si escogió Otro especifique cúal *</label>
                                <asp:TextBox ID="txtOtro" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            
                            <asp:TextBox ID="txtNumeroOT" runat="server" class="form-control" Visible="false"></asp:TextBox>
 
                           
                           <div class="col-md-3">
                                <label for="txtFechaEmision">Fecha Emisión *</label>
                                <asp:TextBox ID="txtFechaEmision" TextMode="DateTimeLocal" CssClass="form-control" runat="server" />
                            </div>
                        </div>

                        <div class="d-flex mt-5">

                            <div class="col-md-3">
                                <label for="txtFechaEjecucion">Fecha Límite ejecución *</label>
                                <asp:TextBox ID="txtFechaEjecucion" TextMode="DateTimeLocal" CssClass="form-control" runat="server" />
                            </div>

                            <div class="col-md-3">
                                <label for="txtFechaIngresoItem">Fecha de ingreso de OT e ítem *</label>
                                <asp:TextBox ID="txtFechaIngresoItem" runat="server" TextMode="DateTimeLocal" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-3">
                                <label for="ddlResponsable">Responsable ejecución *</label>
                                <asp:DropDownList ID="ddlResponsable" runat="server" CssClass="form-control" />
                            </div>

                            <div class="col-md-3">
                                <label for="txtObservaciones">Observaciones generales</label>
                                <asp:TextBox ID="txtObservacionOT" TextMode="MultiLine" Rows="2" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="d-flex">
                            <div class="col-md-3">
                                <br />
                                <asp:CheckBox ID="chkAutoriza" Text="&nbsp; Se autoriza ingreso del cliente al área técnica" runat="server" CssClass="" />
                            </div>
                        </div>

                        <h4 class="mb-3 mt-5"><label>Especificaciones</label></h4>
                        <hr /><br />
                        <div class="row">
                            <div class="table-responsive">
                                <asp:GridView ID="grdDetalleOrdenTrabajo"  runat="server"  AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100 text-center" EmptyDataText='No hay especificaciones cargadas'>
				                <Columns>
					                <asp:BoundField HeaderText="No." DataField="Cantidad" ItemStyle-HorizontalAlign="Center" />
                                    
                                    <asp:TemplateField HeaderText="Codigo del ítem" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCodigoItem" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

					                <asp:BoundField HeaderText="Tipo de Servicio" DataField="Servicio.Nombre" ItemStyle-HorizontalAlign="Center" />

                                    <asp:TemplateField HeaderText="Fecha Inicio" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFechaInicio" TextMode="DateTimeLocal" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Fecha Final" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFechaFinal" TextMode="DateTimeLocal" CssClass="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Observación" ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtObservacion" CssClass="form-control" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                    </asp:TemplateField>

				                </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="panel" style="margin-top: -39px!important;">
            <div class="panel-body">
                <h4 class="mb-3 mt-5"><label>Adjuntar Documentos</label></h4>
                <hr /><br />
                <div class="row">
                    <div class="btn-group col-md-4">
                        <asp:FileUpload ID="upFile" runat="server" CssClass="form-control"/>
                        <asp:LinkButton ID="lnkSubir" Text="Subir" CssClass="btn btn-outline-success" runat="server" OnClick="btnSubir_Click"  ToolTip="Subir Documento." />
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="table-responsive mt-3">
                        <asp:GridView ID="grdDocumentos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay documentos asociados a esta OT.">
                            <Columns>
                                <asp:BoundField HeaderText="Archivo" DataField="Nombre" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField HeaderText="Url" DataField="Url" ItemStyle-HorizontalAlign="Justify" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:TemplateField HeaderText='<i class="fas fa-trash-alt"></i>' ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" Text='<i class="fas fa-trash-alt"></i>' CssClass="btn text-danger btn-lg" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="Delete" ToolTip="Eliminar Documento." />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText='<i class="fas fa-file-download"></i>' ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Download" Text='<i class="fas fa-file-download"></i>' CssClass="btn text-primary btn-lg" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="DownloadFile" ToolTip="Descargar Documento." />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <style>
        #MainContent_grdDetalleOrdenTrabajo, #MainContent_grdDocumentos{
            font-size:11.5px!important;
        }
        #MainContent_grdDocumentos tr td i{
            font-size:15px!important;
        }
        #MainContent_upFile{
            height:30px!important;
            font-size: 14px;
        }
        #MainContent_lnkSubir{
            font-size: 12px!important;
        }
    </style>
</asp:Content>
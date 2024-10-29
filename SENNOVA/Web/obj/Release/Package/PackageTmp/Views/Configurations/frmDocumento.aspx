<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDocumento.aspx.cs" Inherits="Web.Views.Configurations.frmDocumento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Gestionar Documentos.</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <div class="btn-group pull-right">
                                    <asp:LinkButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" class="btn btn-outline-info">Guardar</asp:LinkButton>
                                    <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-outline-warning">Nuevo</asp:LinkButton>
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
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtCodigo">Codigo *</label>
                                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="txtNombre">Nombre *</label>
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtIdDocumento" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlProcedimiento">Procedimiento</label>
                                    <asp:DropDownList Width="180px" ID="ddlProcedimiento" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlTipoDocumento">Tipo de Documento</label>
                                    <asp:DropDownList Width="180px" ID="ddlTipoDocumento" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkActivo">Activo</label><br />
                                    <asp:CheckBox ID="chkActivo" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <%--<div class="col-md-8">
                                <div class="input-group">
                                    <div class="input-group-btn search-panel">
                                        <asp:DropDownList ID="cboFiltros" runat="server" CssClass="form-control" Width="150px">
                                            <asp:ListItem Text="Todos" Value="Todos"></asp:ListItem>
                                            <asp:ListItem Text="Codigo" Value="Codigo"></asp:ListItem>
                                            <asp:ListItem Text="Nombre" Value="Nombre"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtValorBusqueda" runat="server" CssClass="form-control" placeholder="Buscar Termino..." />
                                    </div>
                                </div>
                            </div>--%>
                            <div class="col-md-8">
                                <h3>
                                    <span style="float: right;"><small>Total Registros:</small>
                                        <asp:Label ID="lblTotalRegistros" runat="server" CssClass="label label-warning" Text="" />
                                    </span>
                                </h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <div class="table-responsive-sm">
                                    <asp:GridView ID="grdDocumento" runat="server" OnSelectedIndexChanged="grdDocumento_SelectedIndexChanged" OnDataBound="grdDocumento_DataBound" Height="50px" PageSize="10" AutoGenerateColumns="False" AllowPaging="true" class="table table-bordered table-responsive-sm" HorizontalAlign="Center" Font-Size="Small" EmptyDataText="No hay Activos creados." Width="100%">
                                        <EmptyDataTemplate>
                                            ¡No hay Activos seleccionados!  
                                        </EmptyDataTemplate>
                                        <PagerTemplate>
                                            <div class="row" style="margin-top: 20px;">
                                                <div class="col-lg-2" style="text-align: right;">
                                                    <h5>
                                                        <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                                                </div>
                                                <div class="col-lg-1" style="text-align: left;">
                                                    <asp:DropDownList ID="PageDropDownList" Width="80px" OnSelectedIndexChanged="PageDropDownList_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="form-control" /></h3>
                                                </div>
                                                <div class="col-lg-9" style="text-align: right;">
                                                    <h4>
                                                        <asp:Label ID="CurrentPageLabel" runat="server" CssClass="label label-warning" Text="" /></h4>
                                                </div>
                                            </div>
                                        </PagerTemplate>
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Nombre " DataField="Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Procedimiento " DataField="Procedimiento.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Tipo de Documento " DataField="TiposDocumentos.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />
                                            <asp:CommandField HeaderText="Editar" ShowSelectButton="True" SelectText="Sel" ControlStyle-CssClass="btn btn-outline-info btn-sm" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                            <asp:TemplateField HeaderText="Detalles" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDetalles" Text="Detalles" CssClass="btn btn-outline-secondary btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkDetalles_Click" ToolTip="Gestionar Detalles del Documento." ItemStyle-Width="5%" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEliminar" Text="Eliminar" CssClass="btn btn-outline-danger btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkEliminar_Click" ToolTip="Eliminar Costo." ItemStyle-Width="5%" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Modal Detalles-->
                <div class="modal" id="myModalDocumentos" role="dialog" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div class="modal-dialog modal-xs">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h4>
                                            <span style="float: right;"><small>Total Detalles por Documento:</small>
                                                <asp:Label ID="lblTotalDetallesDocumento" runat="server" CssClass="label label-warning" />
                                            </span>
                                        </h4>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="modal-header text-primary">
                                            <h4 class="modal-title">Adjuntar Archivo</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <p>Por favor antes de adjuntar el archivo verifique lo siguiente :</p>
                                                <i class="icon-next"></i>
                                                <p>El archivo no debe superar los 2 Mb de tamaño</p>
                                                <i class="icon-next"></i>
                                                <p>Solo se permiten archivos con la extensión <span>jpg, png, pdf, docx, xlsx </span> - Se deben convertir antes de enviar.</p>
                                                <hr />
                                                <div class="col-md-8">
                                                    <asp:FileUpload ID="fuAdjunto" CssClass="form-control" runat="server" BorderStyle="Outset" />
                                                </div>
                                                <div class="col-md-4">
                                                    <asp:LinkButton ID="lnkSubir" Text="Subir" CssClass="btn btn-outline-success" runat="server" OnClick="btnSubir_Click" ToolTip="Subir Evidencia." />
                                                </div>
                                                <br />
                                                <br />
                                                <hr />
                                                <asp:Label Text="" runat="server" ID="txtMensaje" CssClass="label-success" />
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="grdDetallesDocumento" runat="server" Height="50px" PageSize="10" AutoGenerateColumns="False" CssClass="table table-bordered" EmptyDataText="No hay Documentos creados." Width="100%">
                                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle Font-Size="XX-Small" />
                                                        <EditRowStyle BackColor="#ffffcc" />
                                                        <SelectedRowStyle BackColor="#ffffcc" />
                                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                        <EmptyDataTemplate>
                                                            ¡No hay Documentos asociados a este Producto!  
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Id" DataField="Id"  ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"></asp:BoundField>
                                                            <asp:BoundField HeaderText="Version" DataField="Version" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                                            <asp:BoundField HeaderText="Url" DataField="RutaDoc"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkDelete" Text="Eliminar" CssClass="btn btn-outline-warning btn-sm" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="Delete" ToolTip="Eliminar Soporte." />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Descargar" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="Download" Text="Download" CssClass="btn btn-outline-info btn-sm" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="DownloadFile" ToolTip="Descargar Soporte." />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                 <button type="button" class="btn btn-secondary" onclick="initializer();">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal Detalles-->

                <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="Update">
                    <ProgressTemplate>
                        <div id="dvProgress" runat="server" style="position: absolute; top: 300px; left: 550px; text-align: center;">
                            <asp:Image ID="Image2" runat="server" Height="46px" Width="47px"
                                ImageUrl="~/Img/loading.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lnkSubir" />
                <asp:PostBackTrigger ControlID="grdDetallesDocumento" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">


        initializer();

        function initializer() {
            $('#myModalDocumentos').modal('hide');
            if ($('.modal-backdrop').is(':visible')) {
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();
            };

        }
    </script>
</asp:Content>

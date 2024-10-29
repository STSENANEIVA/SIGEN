<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEmpresa.aspx.cs" Inherits="Web.Views.Configurations.frmEmpresa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Gestionar Empresal.</h4>
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
                            <asp:TextBox ID="txtIdEmpresa" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtNit">Nit *</label>
                                    <asp:TextBox ID="txtNit" TextMode="Number" OnTextChanged="txtNit_TextChanged" AutoPostBack="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="txtRazonSocial">RazonSocial *</label>
                                    <asp:TextBox ID="txtRazonSocial" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtTelefono">Telefono *</label>
                                    <asp:TextBox ID="txtTelefono" TextMode="Number" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtEmail">Email *</label>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlSectorEconomico">Sector Economico</label>
                                    <asp:DropDownList Width="180px" ID="ddlSectorEconomico" runat="server" CssClass="form-control" />
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
                            <div class="col-md-12">
                                <h3>
                                    <span style="float: right;"><small>Total Registros:</small>
                                        <asp:Label ID="lblTotalRegistros" runat="server" CssClass="label label-warning" Text="" />
                                    </span>
                                </h3>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive-sm">
                                    <asp:GridView ID="grdEmpresa" runat="server" OnSelectedIndexChanged="grdEmpresa_SelectedIndexChanged" OnDataBound="grdEmpresa_DataBound" Height="50px" PageSize="10" AutoGenerateColumns="False" AllowPaging="true" class="table table-bordered table-responsive-sm" HorizontalAlign="Center" Font-Size="X-Small" EmptyDataText="No hay Activos creados." Width="100%">
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
                                            <asp:BoundField HeaderText="Nit" DataField="Nit" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="RazonSocial" DataField="RazonSocial" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Telefono " DataField="Telefono" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Email " DataField="Email" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Sector Economico " DataField="SectorEconomico.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CommandField HeaderText="Editar" ShowSelectButton="True" SelectText="Sel" ControlStyle-CssClass="btn btn-outline-info btn-sm" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
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
                <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="Update">
                    <ProgressTemplate>
                        <div id="dvProgress" runat="server" style="position: absolute; top: 300px; left: 550px; text-align: center;">
                            <asp:Image ID="Image2" runat="server" Height="46px" Width="47px"
                                ImageUrl="~/Img/loading.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

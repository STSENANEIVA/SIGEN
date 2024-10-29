<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"   AutoEventWireup="true" CodeBehind="frmRegistrosIngresos.aspx.cs" Inherits="Web.Views.GetInto.frmRegistrosIngresos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Control de Acceso a Areas Tecnicas.</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <div class="btn-group pull-right">
                                   <asp:LinkButton ID="btnBuscarFiltroSuperior" runat="server" OnClick="btnBuscarFiltroSuperior_Click" class="btn btn-outline-secondary"><span class="glyphicon glyphicon-search"></span>Buscar</asp:LinkButton>
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
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtFechaInicial">Fecha Inicial</label>
                                    <asp:TextBox ID="txtFechaInicial" TextMode="DateTimeLocal" CssClass="form-control w-75" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtFechaFinal">Fecha Final</label>
                                    <asp:TextBox ID="txtFechaFinal" TextMode="DateTimeLocal" CssClass="form-control w-75" runat="server" />
                                </div>
                            </div>

                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-8">
                                <div class="input-group">
                                    <div class="btn-group search-panel">
                                        <asp:DropDownList ID="cboFiltros" runat="server" CssClass="form-control" Width="150px">
                                            <asp:ListItem Text="Todos" Value="Todos"></asp:ListItem>
                                            <asp:ListItem Text="Visitante" Value="Visitante"></asp:ListItem>
                                            <asp:ListItem Text="Empresa" Value="Empresa"></asp:ListItem>
                                            <asp:ListItem Text="Tipo de Visitante" Value="TipoVisitante"></asp:ListItem>
                                            <asp:ListItem Text="Programa de Formación" Value="ProgramaFormacion"></asp:ListItem>
                                            <asp:ListItem Text="Ficha" Value="Ficha"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtValorBusqueda" runat="server" CssClass="form-control" placeholder="Buscar Termino..." />

                                        <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-outline-secondary" OnClick="btnBuscar_Click">Buscar</asp:LinkButton>


                                        <asp:LinkButton ID="btnExportar" runat="server" CssClass="btn btn-outline-success" OnClick="btnExportar_Click">Exportar</asp:LinkButton>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
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
                                    <asp:GridView ID="grdIngresos" runat="server" Height="50px" PageSize="10" AutoGenerateColumns="False" AllowPaging="true" OnRowDataBound="grdIngresos_RowDataBound" class="table table-bordered table-responsive-sm" HorizontalAlign="Center" Font-Size="X-Small" EmptyDataText="No hay Activos creados." Width="100%">
                                        <EmptyDataTemplate>
                                            ¡No hay Ingresos seleccionados!  
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
                                            <asp:BoundField HeaderText="Fecha" DataField="Fecha" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Nombre" DataField="Visitante.Persona.NombreCompleto" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Empresa" DataField="Empresa.RazonSocial" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Tipo Visitante " DataField="Visitante.TipoVisitante.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="ProgramaFormacion " DataField="ProgramaFormacion.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Ficha" DataField="Ficha" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CheckBoxField HeaderText="Politica de Datos" DataField="PoliticaDatos" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%" />
                                            <asp:TemplateField HeaderText="Areas Tecnicas">
                                                <ItemTemplate>
                                                    <asp:CheckBoxList ID="chklAreasTecnicas" runat="server"></asp:CheckBoxList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Responsable" DataField="Empleado.Persona.NombreCompleto" ItemStyle-HorizontalAlign="Center" />
                                           
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
             <Triggers>
                <asp:PostBackTrigger ControlID="btnExportar" />
             </Triggers>

        </asp:UpdatePanel>
    </div>
</asp:Content>

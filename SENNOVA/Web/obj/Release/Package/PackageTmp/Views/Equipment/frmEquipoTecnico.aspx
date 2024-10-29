<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEquipoTecnico.aspx.cs" Inherits="Web.Views.Equipment.frmEquipoTecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>
                                    <label>Gestionar Equipos Técnicos.</label></h4>
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
                        <h4>
                            <label>Generalidades</label></h4>
                        <hr />

                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtPlaca">Placa *</label>
                                    <asp:TextBox ID="txtPlaca" OnTextChanged="txtPlaca_TextChanged" AutoPostBack="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <asp:TextBox ID="txtIdEquipo" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlTipoEquipo">Tipo de Equipo</label>
                                    <asp:DropDownList placeholder="Seleccione" ID="ddlTipoEquipo" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtNombre">Nombre del Equipo *</label>
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <asp:TextBox ID="txtIdResponsable" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlResponsable">Responsable</label>
                                    <asp:DropDownList placeholder="Seleccione" ID="ddlResponsable" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtSerial">Serial *</label>
                                    <asp:TextBox ID="txtSerial" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtMarca">Marca *</label>
                                    <asp:TextBox ID="txtMarca" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaCompra">Fecha de Compra *</label>
                                    <asp:TextBox ID="txtFechaCompra" TextMode="Date" runat="server" DataFormatString="{0:dd/MM/yyyy}" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtValor">Valor de Compra *</label>
                                    <asp:TextBox ID="txtValor" TextMode="Number" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtNumeroContrato">Numero de Contrato</label>
                                    <asp:TextBox ID="txtNumeroContrato" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaFuncionamiento">Puesta en Marcha *</label>
                                    <asp:TextBox ID="txtFechaFuncionamiento" TextMode="Date" DataFormatString="{0:dd/MM/yyyy}" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlAreaTecnica">Area Tecnica</label>
                                    <asp:DropDownList ID="ddlAreaTecnica" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlEstado">Estado</label>
                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <hr />
                        <h4>
                            <label>Especificaciones Técnicas</label></h4>
                        <hr />
                        <div class="row">
                            <asp:TextBox ID="txtIdTecnico" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlClaseEquipo">Clase de Equipo</label>
                                    <asp:DropDownList ID="ddlClaseEquipo" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlTipoPatron">Tipo de Patron</label>
                                    <asp:DropDownList ID="ddlTipoPatron" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="txtCaracteristicas">Caracteristicas</label>
                                    <asp:TextBox ID="txtCaracteristicas" TextMode="MultiLine" Rows="3" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkAire">Aire</label><br />
                                    <asp:CheckBox ID="chkAire" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtPresionAire">Presion de Aire</label>
                                    <asp:TextBox ID="txtIp" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtCaudal">Caudal</label>
                                    <asp:TextBox ID="txtCaudal" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkElectricidad">Electricidad</label><br />
                                    <asp:CheckBox ID="chkElectricidad" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtVoltaje">Voltaje</label>
                                    <asp:TextBox ID="txtVoltaje" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtAmperaje">Amperaje</label>
                                    <asp:TextBox ID="txtAmperaje" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtPotencia">Potencia</label>
                                    <asp:TextBox ID="txtPotencia" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkGas">Gas</label><br />
                                    <asp:CheckBox ID="chkGas" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtTipoGas">Tipo Gas</label>
                                    <asp:TextBox ID="txtTipoGas" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtPresionGas">Presion de Gas</label>
                                    <asp:TextBox ID="txtPresionGas" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkAceite">Aceite</label><br />
                                    <asp:CheckBox ID="chkAceite" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtTipoAceite">Tipo de Aceite</label>
                                    <asp:TextBox ID="txtTipoAceite" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>

                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkOtros">Otros</label><br />
                                    <asp:CheckBox ID="chkOtros" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtEspecifique">Especifique</label>
                                    <asp:TextBox ID="txtEspecifique" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="txtObservaciones">Observaciones</label>
                                    <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" Rows="3" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>

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
                            </div>
                            <div class="col-md-12">
                                <h3>
                                    <span style="float: right;"><small>Total Registros:</small>
                                        <asp:Label ID="lblTotalRegistros" runat="server" CssClass="label label-warning" Text="" />
                                    </span>
                                </h3>
                            </div>
                        </div>
                        <%--<div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive-sm">
                                    <asp:GridView ID="grdEquipoTecnico" runat="server" OnSelectedIndexChanged="grdEquipoTecnico_SelectedIndexChanged" OnDataBound="grdEquipoTecnico_DataBound" Height="50px" PageSize="10" AutoGenerateColumns="False" AllowPaging="true" class="table table-bordered table-responsive-sm" HorizontalAlign="Center" Font-Size="X-Small" EmptyDataText="No hay Activos creados." Width="100%">
                                        <EmptyDataTemplate>
                                            ¡No hay Equipos seleccionados!  
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
                                            <asp:BoundField HeaderText="Codigo" DataField="EquipoTecnico.Codigo" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Tipo de Equipo " DataField="EquipoTecnico.TipoEquipo.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Numero de Equipo" DataField="EquipoTecnico.Placa" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Nombres" DataField="EquipoTecnico.Nombres" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Serial " DataField="EquipoTecnico.Serial" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Marca " DataField="EquipoTecnico.Marca" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="FechaCompra " DataField="EquipoTecnico.FechaCompra" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Valor " DataField="Valor" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="FechaFuncionamiento " DataField="FechaFuncionamiento" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="AreaTecnica " DataField="AreaTecnica.Nombre" ItemStyle-HorizontalAlign="Center" />
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
                        </div>--%>
                        </div>
                    </div>
                    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="Update">
                        <ProgressTemplate>
                            <div id="dvProgress" runat="server" style="position: absolute; top: 300px; left: 550px; text-align: center;">
                                <asp:Image ID="Image2" runat="server" Height="460px" Width="470px"
                                    ImageUrl="~/Img/loading.gif" />
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

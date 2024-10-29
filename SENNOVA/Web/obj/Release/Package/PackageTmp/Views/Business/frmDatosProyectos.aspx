<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDatosProyectos.aspx.cs" Inherits="Web.Views.Business.frmDatosProyectos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="//cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.css" rel="stylesheet" />
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Proyectos Asignados.</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <div class="btn-group pull-right">
                                    <asp:LinkButton ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" class="btn btn-outline-info">Buscar</asp:LinkButton>
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
                            <asp:TextBox ID="txtIdProyecto" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:HiddenField ID="hidProyectoId" Value="" runat="server" />
                                    <label for="txtProyecto">Centros de Formación</label>
                                    <asp:TextBox ID="txtProyecto" CssClass="form-control" placeholder="Nombre de los Centros de Formación" runat="server"></asp:TextBox>
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
                                    <asp:GridView ID="grdProyecto" runat="server" OnDataBound="grdProyecto_DataBound" Height="50px" PageSize="10" AutoGenerateColumns="False" AllowPaging="true" class="table table-bordered table-responsive-sm" HorizontalAlign="Center" Font-Size="XX-Small" EmptyDataText="No hay Activos creados." Width="100%">
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
                                            <asp:BoundField HeaderText="Titulo del Proyecto" DataField="TituloProyecto" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Codigo SGPS" DataField="CodigoSGPS" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Año de Ejecución " DataField="AnoEjecucion" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Fecha " DataField="FechaDiligenciamiento" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Objetivo General " DataField="ObjetivoGeneral" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Centro Formacion " DataField="CentroFormacion.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Linea Programatica " DataField="LineaProgramatica.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Red Conocimiento Sectorial " DataField="RedConocimientoSectorial.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Area Conocimiento " DataField="AreaConocimiento.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Lider Proyecto " DataField="Empresa.NombreCompleto" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Asignacion Inicial " DataField="AsignacionInicial" ItemStyle-Width="7%" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="Center" />
                                            <%--<asp:CommandField HeaderText="Editar" ShowSelectButton="True" SelectText="Sel" ControlStyle-CssClass="btn btn-outline-info btn-sm" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />--%>
                                            <asp:TemplateField HeaderText="Detalles" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDetalles" Text="Detalles" CssClass="btn btn-outline-secondary btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkDetalles_Click" ToolTip="Gestionar Proyecto." ItemStyle-Width="5%" />
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
                        <div id="dvProgress" runat="server" style="position: absolute; top: 300px; left: 450px; text-align: center;">
                            <asp:Image ID="Image2" runat="server" Height="360px" Width="370px"
                                ImageUrl="~/Img/loading.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <br />
    <br />
    <script type="text/javascript">

        $(function () {
            initializer();

        });

        var prmInstance = Sys.WebForms.PageRequestManager.getInstance();

        prmInstance.add_endRequest(function () {
            //you need to re-bind your jquery events here
            initializer();
        });

        function initializer() {
            $("#<%=txtProyecto.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Services/SProyecto.asmx/GetProyectos") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split(',')[0],
                                    val: item.split(',')[1]
                                }
                            }))
                        },
                    });
                },
                select: function (e, i) {
                    $("#<%=hidProyectoId.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });
        };
    </script>
</asp:Content>

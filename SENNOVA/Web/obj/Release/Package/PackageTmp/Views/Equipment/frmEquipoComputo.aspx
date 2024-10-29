<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEquipoComputo.aspx.cs" Inherits="Web.Views.Equipment.frmEquipoComputo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.css" rel="stylesheet" />
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>
                                    <label>Gestionar Equipos Administrativos.</label>
                                </h4>
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
                            <asp:TextBox ID="txtIdComputo" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="chkCuentaAdmin">¿Requiere Cuenta Administrador?</label><br />
                                    <asp:CheckBox ID="chkCuentaAdmin" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="chkBackup">¿Requiere Backup?</label><br />
                                    <asp:CheckBox ID="chkBackup" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtIp">Dirección Ip</label>
                                    <asp:TextBox ID="txtIp" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtProcesador">Procesador</label>
                                    <asp:TextBox ID="txtProcesador" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtRam">Memoria Ram (GB)</label>
                                    <asp:TextBox ID="txtRam" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtDisco">Disco Duro (GB)</label>
                                    <asp:TextBox ID="txtDisco" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="txtObservaciones">Observaciones</label>
                                    <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" Rows="3" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <h4>
                            <label>Accesorios</label></h4>
                        <hr />
                        <div class="row">
                            <asp:HiddenField ID="hidAccesorioId" Value="" runat="server" />
                            <label for="txtAccesorio">Accesorio</label>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtAccesorio" runat="server" CssClass="form-control" placeholder="Nombre de los Accesorio"></asp:TextBox>
                                <asp:LinkButton ID="btnAgregarAccesorios" runat="server" OnClick="btnAgregarAccesorios_Click" class="btn btn-outline-success">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-lg" viewBox="0 0 16 16">
                                                <path fill-rule="evenodd" d="M8 2a.5.5 0 0 1 .5.5v5h5a.5.5 0 0 1 0 1h-5v5a.5.5 0 0 1-1 0v-5h-5a.5.5 0 0 1 0-1h5v-5A.5.5 0 0 1 8 2Z"/>
                                            </svg>
                                </asp:LinkButton>
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-2">
                                    <div class="btn-group pull-right">
                                        <asp:LinkButton ID="btnGuardarAccesorios" runat="server" OnClick="btnGuardarAccesorios_Click" class="btn btn-outline-secondary">Guardar</asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <div class="table-responsive-sm">
                                    <asp:GridView ID="grdAccesorios" runat="server" OnDataBound="grdAccesorios_DataBound" Height="50px" PageSize="10" AutoGenerateColumns="False" AllowPaging="true" class="table table-bordered table-responsive-sm" HorizontalAlign="Center" Font-Size="Small" EmptyDataText="No hay Accesorios creados." Width="100%">
                                        <EmptyDataTemplate>
                                            ¡No hay Accesorios seleccionados!  
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
                                            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" ItemStyle-HorizontalAlign="Center" />
                                            <%--<asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEliminar" Text="Eliminar" CssClass="btn btn-outline-danger btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkEliminar_Click" ToolTip="Eliminar Costo." ItemStyle-Width="5%" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <h4>
                            <label>Aplicaciones</label></h4>
                        <hr />
                        <div class="row">
                            <asp:HiddenField ID="hidSoftwareId" Value="" runat="server" />
                            </br>
                                <label for="txtSoftware">Aplicativo</label>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtSoftware" runat="server" CssClass="form-control" placeholder="Nombre de los Aplicativos"></asp:TextBox>
                                <asp:LinkButton ID="btnAgregarSoftware" runat="server" OnClick="btnAgregarSoftware_Click" class="btn btn-outline-success">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-lg" viewBox="0 0 16 16">
                                                <path fill-rule="evenodd" d="M8 2a.5.5 0 0 1 .5.5v5h5a.5.5 0 0 1 0 1h-5v5a.5.5 0 0 1-1 0v-5h-5a.5.5 0 0 1 0-1h5v-5A.5.5 0 0 1 8 2Z"/>
                                            </svg>
                                </asp:LinkButton>
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-2">
                                    <div class="btn-group pull-right">
                                        <asp:LinkButton ID="btnGuardarSoftware" runat="server" OnClick="btnGuardarSoftware_Click" class="btn btn-outline-secondary">Guardar</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-8">
                                <div class="table-responsive-sm">
                                    <asp:GridView ID="grdSoftware" runat="server" OnDataBound="grdSoftware_DataBound" Height="50px" PageSize="10" AutoGenerateColumns="False" AllowPaging="true" class="table table-bordered table-responsive-sm" HorizontalAlign="Center" Font-Size="Small" EmptyDataText="No hay Software creados." Width="100%">
                                        <EmptyDataTemplate>
                                            ¡No hay Software seleccionados!  
                                        </EmptyDataTemplate>
                                        <PagerTemplate>
                                            <div class="row" style="margin-top: 20px;">
                                                <div class="col-lg-2" style="text-align: right;">
                                                    <h5>
                                                        <asp:Label ID="MessageLabel" Text="Ir a la pág." runat="server" /></h5>
                                                </div>
                                                <div class="col-lg-1" style="text-align: left;">
                                                    <asp:DropDownList ID="PageSoftwareDropDownList" Width="80px" OnSelectedIndexChanged="PageSoftwareDropDownList_SelectedIndexChanged" runat="server" AutoPostBack="true" CssClass="form-control" /></h3>
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
                                            <asp:BoundField HeaderText="Version" DataField="Version" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Tipo Licencia" DataField="TipoLicencia.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <%--<asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEliminar" Text="Eliminar" CssClass="btn btn-outline-danger btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkEliminar_Click" ToolTip="Eliminar Costo." ItemStyle-Width="5%" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <hr />

                        <div class="row">
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
            $("#<%=txtSoftware.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Services/SSoftware.asmx/GetSoftware") %>',
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
                    $("#<%=hidSoftwareId.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });

            $("#<%=txtAccesorio.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Services/SAccesorios.asmx/GetAccesorios") %>',
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
                    $("#<%=hidAccesorioId.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });
        };
    </script>
</asp:Content>

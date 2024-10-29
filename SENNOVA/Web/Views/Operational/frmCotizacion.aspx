<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCotizacion.aspx.cs" Inherits="Web.Views.Configurations.frmCotizacion" %>

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
                                <h4>Gestionar Cotizaciones.</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <div class="btn-group pull-right">
                                    <%--<asp:LinkButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" class="btn btn-outline-primary btn-lg">Guardar</asp:LinkButton>--%>
                                    <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-outline-success btn-lg">Nuevo</asp:LinkButton>
                                    <asp:LinkButton ID="btnRegistros" runat="server" OnClick="btnRegistros_Click" class="btn btn-outline-info btn-lg">Registros</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtCodigo">Código *</label>
                                    <asp:TextBox ID="txtCodigo" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <asp:TextBox ID="txtIdCotizacion" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlTipoCotizacion">Tipo Cotización</label>
                                    <asp:DropDownList ID="ddlTipoCotizacion" OnSelectedIndexChanged="ddlTipoCotizacion_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:HiddenField ID="hidSolicitanteId" Value="" runat="server" />
                                <label for="txtSolicitante">Solicitante</label>
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="txtSolicitante" runat="server" CssClass="form-control" OnTextChanged="txtSolicitante_TextChanged" AutoPostBack="true" placeholder="Nombre del Solicitante"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtTelefono">Teléfono *</label>
                                    <asp:TextBox ID="txtTelefono" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtEmail">Email *</label>
                                    <asp:TextBox ID="txtEmail" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2" id="idCargo" runat="server">
                                <div class="form-group">
                                    <label for="txtCargo">Cargo *</label>
                                    <asp:TextBox ID="txtCargo" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="idTelefonoLaboral" runat="server">
                                <div class="form-group">
                                    <label for="txtTelefonoLaboral">Telefono Laboral *</label>
                                    <asp:TextBox ID="txtTelefonoLaboral" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" id="idEmailLaboral" runat="server">
                                <div class="form-group">
                                    <label for="txtEmailLaboral">Email Laboral *</label>
                                    <asp:TextBox ID="txtEmailLaboral" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3" id="idProgramaFormacion" runat="server">
                                <asp:HiddenField ID="hidProgramaFormacionId" Value="" runat="server" />
                                <label for="txtProgramaFormacion">Programa de Formacion</label>
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="txtProgramaFormacion" runat="server" CssClass="form-control" placeholder="Nombre del Programa de Formacion"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="idFicha" visible="false">
                                <div class="form-group">
                                    <label for="txtFicha">Ficha *</label>
                                    <asp:TextBox ID="txtFicha" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="txtObservaciones">Observaciones *</label>
                                    <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" Rows="3" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2" runat="server" id="Div1" visible="false">
                                <div class="form-group">
                                    <label for="txtTotal">Total </label>
                                    <asp:TextBox ID="txtTotal" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <h4 class="mb-3 mt-4"><label>Terminos y Condiciones.</label></h4>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:HiddenField ID="hidTerminoCondicionId" Value="" runat="server" />
                                <div class="input-group mb-10">
                                    <asp:TextBox ID="txtTerminoCondicion" runat="server" CssClass="form-control" placeholder="Nombre del Termino o Condición"></asp:TextBox>
                                    <asp:LinkButton ID="btnAgregarTerminosCondiciones" runat="server" OnClick="btnAgregarTerminosCondiciones_Click" class="btn btn-outline-secondary">Agregar</asp:LinkButton>
                                    <asp:LinkButton ID="btnLimpiarTerminos" runat="server" OnClick="btnLimpiarTerminos_Click" class="btn btn-outline-secondary">Limpiar</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="grdTerminos" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover table-striped w-100">
                                    <Columns>
                                        <asp:BoundField HeaderText="idTermino" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:TemplateField HeaderText='<i class="fas fa-trash-alt"></i>' ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEliminarTermino" CssClass="btn text-danger btn-sm" ItemStyle-HorizontalAlign="Center" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="btnEliminarTermino_Click" ToolTip="Eliminar."><i class="fas fa-trash-alt"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <hr />
                        <h4 class="mb-3 mt-5"><label>Servicios</label></h4>
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlAreaTecnica">Area Tecnica</label>
                                    <asp:DropDownList ID="ddlAreaTecnica" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:HiddenField ID="hidServicioId" Value="" runat="server" />
                                <label for="txtServicio">Servicio</label>
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="txtServicio" runat="server" CssClass="form-control" placeholder="Nombre del Servicio"></asp:TextBox>
                                    <asp:LinkButton ID="btnAgregarServicio" runat="server" OnClick="btnAgregarServicio_Click" class="btn btn-outline-secondary">Agregar</asp:LinkButton>
                                    <asp:LinkButton ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" class="btn btn-outline-secondary">Limpiar</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="grdCotizacionDetalles" OnRowDataBound="grdCotizacionDetalles_RowDataBound" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover table-striped w-100">
                                    <Columns>
                                        <asp:BoundField HeaderText="idServicio" DataField="Servicio.Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField DataField="Servicio.Codigo" HeaderText="Codigo" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />
                                        <asp:BoundField DataField="Servicio.Nombre" HeaderText="Servicio" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center" />

                                        <asp:TemplateField HeaderText="Cantidad" ItemStyle-Width="8%" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCantidad" min="0" Text='<%#Eval("Cantidad") %>' CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valor Unitario" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtValorUnitario" Text='<%#Eval("PrecioServicio") %>' CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valor Total" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtValorTotal" Text='<%#Eval("ValorUnitario") %>' CssClass="form-control" TextMode="Number" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Observación" ItemStyle-Width="30%" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtObservacion" Text='<%#Eval("Observaciones") %>' CssClass="form-control" TextMode="MultiLine" Rows="2" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="3%" HeaderText='<i class="fas fa-trash-alt"></i>' ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEliminarDetalle" CssClass="btn text-danger btn-sm" ItemStyle-HorizontalAlign="Center" CommandArgument='<%# Eval("Servicio.Id") %>' runat="server" OnClick="btnEliminarDetalle_Click" ToolTip="Eliminar."><i class="fas fa-trash-alt"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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
    <style>
        #MainContent_grdTerminos, #MainContent_grdCotizacionDetalles{
            font-size:11.5px!important;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            initializer();
            dataTable();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();

            prmInstance.add_endRequest(function () {
                //you need to re-bind your jquery events here
                initializer();
            });
        });

        function initializer() {
            $("#<%=txtSolicitante.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Services/SPersona.asmx/GetPersonas") %>',
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
                    $("#<%=hidSolicitanteId.ClientID %>").val(i.item.val);
                },
                minLength: 1,
            });

            $("#<%=txtProgramaFormacion.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Services/SProgramaFormacion.asmx/GetProgramasFormacion") %>',
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
                    $("#<%=hidProgramaFormacionId.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });

            $("#<%=txtServicio.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({

                        url: '<%=ResolveUrl("~/Services/SServicios.asmx/GetServicios") %>',
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
                    $("#<%=hidServicioId.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });

            $("#<%=txtTerminoCondicion.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({

                        url: '<%=ResolveUrl("~/Services/STerminosCondiciones.asmx/GetTerminosCondiciones") %>',
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
                     $("#<%=hidTerminoCondicionId.ClientID %>").val(i.item.val);
                 },
                 minLength: 1
             });
        }

        function dataTable() {
            $('#<%=grdCotizacionDetalles.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
                buttons: [
                    'colvis',
                    {
                        extend: 'copy',
                        exportOptions: {
                            columns: ':visible',
                            rows: ':visible'
                        }
                    },
                    {
                        extend: 'collection',
                        className: 'custom-html-collection',
                        buttons: [
                            {
                                extend: 'excelHtml5',
                                text: '<center><i class="far fa-file-excel"></i> Excel</center>',
                                exportOptions: {
                                    columns: ':visible'
                                }
                            },
                            {
                                extend: 'print',
                                text: '<center><i class="far fa-file-pdf"></i> Pdf</center>',
                                exportOptions: {
                                    columns: [1,2,3,4,5,6]
                                }
                            }
                        ]
                    },

                ],
                language: {
                    "processing": "Procesando...",
                    "lengthMenu": "Mostrar _MENU_ registros",
                    "zeroRecords": "No se encontraron resultados",
                    "emptyTable": "Ningún dato disponible en esta tabla",
                    "infoEmpty": "No hay registros",
                    "infoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "search": "Buscar:",
                    "infoThousands": ",",
                    "loadingRecords": "Cargando...",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ registros",
                    "paginate": {
                        "first": "Primero",
                        "last": "Último",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    },
                    "Copy": "Copiado en el portapapeles",
                    "buttons": {
                        "colvis": "Ocultar columnas",
                        "collection": 'Exportar',
                        "copy": "Copiar",
                        "copyTitle": 'Copiar al portapapeles',
                        "copySuccess": {
                            _: 'Copiado %d filas al portapapeles',
                            1: '1 línea copiada'
                        }
                    }
                }
            });
        }
    </script>
</asp:Content>

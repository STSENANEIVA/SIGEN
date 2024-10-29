<%@ Page Title="REPOSITORIO DOCUMENTO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDocumentos.aspx.cs" Inherits="Web.Views.Configurations.frmDocumentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Consultar Documentos.</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <div class="btn-group pull-right">
                                    <%--<asp:LinkButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" class="btn btn-outline-info">Guardar</asp:LinkButton>
                                    <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-outline-warning">Nuevo</asp:LinkButton>--%>
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
                             <div class="col-md-8">
                                <div class="input-group">
                                    <div class="btn-group search-panel">
                                        <asp:DropDownList ID="cboFiltros" runat="server" CssClass="form-control" Width="150px">
                                            <asp:ListItem Text="Todos" Value="Todos"></asp:ListItem>
                                            <asp:ListItem Text="Codigo" Value="Código"></asp:ListItem>
                                            <asp:ListItem Text="Nombre" Value="Nombre"></asp:ListItem>
                                            <asp:ListItem Text="Procedimiento" Value="Procedimiento"></asp:ListItem>
                                            <asp:ListItem Text="Tipo Documento" Value="TipoDocumento"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtValorBusqueda" runat="server" CssClass="form-control" placeholder="Buscar Termino..." />
                                        <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn btn-outline-secondary" OnClick="btnBuscar_Click">Buscar</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                            <div class="row">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdDocumento" runat="server" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Código" DataField="Codigo" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Nombre " DataField="Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Procedimiento " DataField="Procedimiento.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Tipo de Documento " DataField="TiposDocumentos.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Documento " DataField="DetallesDocumento.RutaDoc" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />
                                        </Columns>
                                    </asp:GridView>
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
    <script type="text/javascript">
        $(document).ready(function () {
            dataTable();
        });
        function dataTable() {
            $('#<%=grdDocumento.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
                buttons: [
                    'colvis',
                    {
                        extend: 'copy',
                        exportOptions: {
                            columns: ':visible'
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
                                    columns: [1,2,3,4,5]
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

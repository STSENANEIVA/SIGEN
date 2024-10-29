<%@ Page Title="CENTRO DE FORMACIÓN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCentroFormacion.aspx.cs" Inherits="Web.Views.Configurations.frmCentroFormacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Gestionar CentroFormaciones.</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <div class="btn-group pull-right">
                                    <asp:LinkButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" class="btn btn-outline-primary btn-lg">Guardar</asp:LinkButton>
                                    <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-outline-success btn-lg">Nuevo</asp:LinkButton>
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
                                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="txtNombre">Nombre *</label>
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtIdCentroFormacion" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtRegional">Regional</label>
                                    <asp:DropDownList Width="180px" ID="ddlRegional" runat="server" CssClass="form-control" />
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
                                <div class="table-responsive">
                                    <asp:GridView ID="grdCentroFormacion" runat="server" OnSelectedIndexChanged="grdCentroFormacion_SelectedIndexChanged" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100"  EmptyDataText="No hay datos disponibles en la tabla">
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Código" DataField="Codigo" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Nombre " DataField="Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Regional " DataField="Regional.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />
                                            <asp:CommandField HeaderText="Editar" ShowSelectButton="True" SelectText='<i class="fas fa-edit"></i>' ControlStyle-CssClass="btn text-warning btn-sm" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%" />
                                            <asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEliminar" Text='<i class="fas fa-trash-alt"></i>' CssClass="btn text-danger btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkEliminar_Click" ToolTip="Eliminar Costo." ItemStyle-Width="5%" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
            $('#<%=grdCentroFormacion.ClientID%>').DataTable({
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
                                    columns: [1,2,3]
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

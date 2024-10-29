<%@ Page Title="EQUIPOS DE CÓMMPUTO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrosEquipoComputo.aspx.cs" Inherits="Web.Views.Equipment.frmRegistrosEquipoComputo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel">

                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6 mt-2">
                                <h4>Registros Equipos de Cómputo.</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <div class="pull-right">
                                    <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-outline-success btn-lg">Nuevo</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="panel-body">
                        <div class="row">
                            <div class="table-responsive">
                                <asp:GridView ID="grdEquiposComputo" runat="server" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
                                    <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Placa" DataField="Placa" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Tipo de Equipo" DataField="TipoEquipo.Nombre" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Serial" DataField="Serial" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Marca" DataField="Marca" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Estado" DataField="Estado" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Fecha de Compra" DataField="FechaCompra" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Valor" DataField="Valor" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Número de Contrato" DataField="NumeroContrato" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Fecha Funcionamiento" DataField="FechaFuncionamiento" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Responzable" DataField="Responsable.NombreCompleto" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:BoundField HeaderText="Área Técnica" DataField="AreaTecnica.Nombre" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:TemplateField HeaderText='<i class="fas fa-edit"></i>' ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEditar" Text='<i class="fas fa-edit"></i>' CssClass="btn text-warning btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkEditar_Click" ToolTip="Editar" />
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
    </div>
        <script type="text/javascript">
        $(document).ready(function () {
            dataTable()
        });
        function dataTable() {
            $('#<%=grdEquiposComputo.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
                columnDefs: [{ orderable: false, targets: [13] }],
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
                                    columns: [1,2, 3, 4, 5, 6, 7, 8, 9, 10, 11,12]
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
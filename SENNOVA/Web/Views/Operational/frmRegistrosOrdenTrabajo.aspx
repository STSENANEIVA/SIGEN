<%@ Page Title="ORDEN DE TRABAJO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrosOrdenTrabajo.aspx.cs" Inherits="Web.Views.Configurations.frmRegistrosOrdenTrabajo"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6 mt-2">
                                <h4>Registros Ordenes de Trabajo.</h4>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="panel-body">
                        <div class="d-flex justify-content-start align-items-center ">
                            <div class="col-md-4">
                                <label for="txtFechaInicial">Fecha Emisi&oacute;n</label>
                                <asp:TextBox ID="txtFechaInicial" TextMode="DateTimeLocal" CssClass="form-control w-75" runat="server" />
                            </div>
                            <div class="col-md-4">
                                <label for="txtFechaFinal">Fecha Ejecuci&oacute;n</label>
                                <asp:TextBox ID="txtFechaFinal" TextMode="DateTimeLocal" CssClass="form-control w-75" runat="server" />
                            </div>
                            <div class="mt-4">
                                <asp:LinkButton ID="btnBuscarFiltroSuperior" runat="server" OnClick="btnBuscarFiltroSuperior_Click" class="btn btn-outline-secondary btn-lg"><i class="fas fa-search"></i> Buscar</asp:LinkButton>
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
        <hr />
        <div class="container my-5">
            <div class="table-responsive">
                <asp:GridView ID="grdOrdenesTrabajo" runat="server" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                        <asp:BoundField HeaderText="N&uacute;mero Orden" DataField="NumeroOT" ItemStyle-HorizontalAlign="Center"  />
                        <asp:BoundField HeaderText="Fecha Emisi&oacute;n" DataField="FechaEmision" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Fecha L&iacute;mite ejecuci&oacute;n" DataField="FechaLimite" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Fecha y hora de ingreso de OT e &iacute;tem de servicio al &aacute;rea t&eacute;cnica" DataField="FechaIngresoItem" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="160px"/>
                        <asp:CheckBoxField HeaderText="Autoriza Ingreso" DataField="AutorizaIngreso" ItemStyle-HorizontalAlign="Center"  />
                        <asp:BoundField HeaderText="Observaciones" DataField="Observaciones" ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderText="Detalles" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDetalles"  Text='<i class="fas fa-info"></i>' CssClass="btn text-secondary btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkDetalles"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    <%--Modal Detalle Orden de Trabajo--%>
        <div class="modal" id="modalDetalleOrdenTrabajo" tabindex="-1">
            <div class="modal-dialog" style="max-width: 650px; margin-top: 10%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">DETALLES ORDEN DE TRABAJO</h4>
                    <asp:LinkButton ID="btnCerarModal" Text="x" CssClass="btn-close" runat="server" OnClick="lnkCerrarModal" style="text-decoration:none" />
                </div>
                <div class="modal-body">
                    <div class="table-responsive">
                        <asp:GridView ID="grdDetalleOrdenTrabajo" runat="server"  AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
				        <Columns>
					        <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
					        <asp:BoundField HeaderText="No." DataField="Cantidad" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="C&oacute;digo del &iacute;tem" DataField="CodigoItem" ItemStyle-HorizontalAlign="Center" />
					        <asp:BoundField HeaderText="Tipo de Servicio" DataField="Servicio" ItemStyle-HorizontalAlign="Center" />
					        <asp:BoundField HeaderText="Fecha Inicio" DataField="FechaInicio" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Fecha Final" DataField="FechaFinal" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Observaciones" DataField="Observaciones" ItemStyle-HorizontalAlign="Center" />
				        </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <style>
        th, td{
            vertical-align: middle!important;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            dataTable()
            dataTableDetalles()
        });
        function warningalert() {
            Swal.fire({
                position: 'center',
                icon: 'warning',
                title: 'Seleccione un rango de fecha para buscar',
                showConfirmButton: true,
            })
        }
        function dataTable() {
            $('#<%=grdOrdenesTrabajo.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
                columnDefs: [{ orderable: false, targets: [7] }],
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
                    "emptyTable": "Ning�n dato disponible en esta tabla",
                    "infoEmpty": "No hay registros",
                    "infoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "search": "Buscar:",
                    "infoThousands": ",",
                    "loadingRecords": "Cargando...",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ registros",
                    "paginate": {
                        "first": "Primero",
                        "last": "�ltimo",
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
                            1: '1 l�nea copiada'
                        }
                    }
                }
            });
        }
        function dataTableDetalles() {
            $('#<%=grdDetalleOrdenTrabajo.ClientID%>').DataTable({
                "destroy": true,
                "searching": false,
                "info": false,
                "lengthChange": false,
                language: {
                    "processing": "Procesando...",
                    "lengthMenu": "Mostrar _MENU_ registros",
                    "zeroRecords": "No se encontraron resultados",
                    "emptyTable": "Ning�n dato disponible en esta tabla",
                    "infoEmpty": "No hay registros",
                    "infoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "search": "Buscar:",
                    "infoThousands": ",",
                    "loadingRecords": "Cargando...",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ registros",
                    "paginate": {
                        "first": "Primero",
                        "last": "�ltimo",
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
                            1: '1 l�nea copiada'
                        }
                    }
                }
            });
        }
    </script>
</asp:Content>
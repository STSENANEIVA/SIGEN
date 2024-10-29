<%@ Page Title="REGISTROS COTIZACIÓN" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRegistrosCotizacion.aspx.cs" Inherits="Web.Views.Configurations.frmRegistrosCotizacion"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6 mt-2">
                                <h4>Registros Cotizaciones.</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2 pull-right">
                                <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-outline-success btn-lg">Nuevo</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-4">
                                <label for="txtFechaInicial">Fecha Emisión</label>
                                <asp:TextBox ID="txtFechaInicial" TextMode="DateTimeLocal" CssClass="form-control w-75" runat="server" />
                            </div>
                            <div class="col-md-4">
                                <label for="txtFechaFinal">Fecha Ejecución</label>
                                <asp:TextBox ID="txtFechaFinal" TextMode="DateTimeLocal" CssClass="form-control w-75" runat="server" />
                            </div>
                            <div class="col-md-4 mt-4">
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
                <asp:GridView ID="grdCotizaciones" runat="server" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
                    <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                            <asp:BoundField HeaderText="Código" DataField="Codigo" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Fecha" DataField="Fecha" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField HeaderText="Valor Total" DataField="ValorTotal" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Validez Oferta" DataField="ValidezOferta" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField HeaderText="Número de Ficha" DataField="NumeroFicha" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField HeaderText="Tipo de Cotización" DataField="TipoCotizacion" ItemStyle-HorizontalAlign="Center"/>
                            <asp:BoundField HeaderText="Observaciones" DataField="Observaciones" ItemStyle-HorizontalAlign="Center"/>
                            <asp:TemplateField HeaderText="Generar Orden de Trabajo" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkOrdenTrabajo" Text='<i class="fas fa-file-contract"></i>' CssClass="btn text-primary" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkOrdenTrabjo_Click" ToolTip="Crear Orden de trabajo." ItemStyle-Width="5%" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Soportes" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkSoportes" Text='<i class="fas fa-file-upload"></i>' CssClass="btn text-success" runat="server" CommandArgument='<%# Eval("Id") %>' OnClick="lnkSoportes_Click" ToolTip="Subir Soportes."/>
                                </ItemTemplate>
                            </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <%--Modal Subir Soporte--%>
        <div class="modal" id="modalSubirSoporte" tabindex="-1">
            <div class="modal-dialog" style="max-width: 650px; margin-top: 10%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">SOPORTES</h4>
                    <asp:LinkButton ID="btnCerarModal" Text="x" CssClass="btn-close" runat="server" OnClick="lnkCerrarModal" style="text-decoration:none"/>
                </div>
                <div class="modal-body" style="border-bottom: 1px solid #dee2e6;">
                    <h4 class="modal-title text-center text-primary mb-3">Adjuntar Archivo como Soporte</h4>
                    <p>Por favor antes de adjuntar el archivo verifique lo siguiente :</p>
                    <p>El archivo no debe superar los 2 Mb de tamaño</p>
                    <p>Solo se permiten archivos con la extensión <span>jpg, png, pdf, docx, xlsx </span> - Se deben convertir antes de subir.</p>
                    <div class="btn-group my-3">
                        <asp:TextBox ID="txtIdCotizacion" runat="server" class="form-control" Visible="false"></asp:TextBox>
                        <asp:FileUpload ID="upFile" runat="server" CssClass="form-control"/>
                        <asp:LinkButton ID="lnkSubir" Text="Subir" CssClass="btn btn-outline-success" runat="server" OnClick="btnSubir_Click" ToolTip="Subir Documento." />
                    </div>
                </div>
                <div class="modal-body">
                    <div class="table-responsive">
                        <asp:GridView ID="grdDocumentos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay documentos asociados a esta Cotización">
                            <Columns>
                                <asp:BoundField HeaderText="Archivo" DataField="Nombre" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                <asp:BoundField HeaderText="Url" DataField="Url" ItemStyle-HorizontalAlign="Justify" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                <asp:TemplateField HeaderText='<i class="fas fa-trash-alt"></i>' ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" Text='<i class="fas fa-trash-alt"></i>' CssClass="btn text-danger btn-lg" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="Delete" ToolTip="Eliminar Documento." />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText='<i class="fas fa-file-download"></i>' ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="Download" Text='<i class="fas fa-file-download"></i>' CssClass="btn text-primary btn-lg" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="DownloadFile" ToolTip="Descargar Documento." />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <style>
        td>a>i{
            font-size: 16px!important;
        }
        th, td{
            vertical-align: middle!important;
        }
        #MainContent_upFile{
            height:30px!important;
            font-size: 14px;
        }
        #MainContent_lnkSubir{
            font-size: 12px!important;
        }
        #MainContent_grdDocumentos{
            font-size:11.5px!important;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            dataTable()
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
            $('#<%=grdCotizaciones.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
                columnDefs: [{ orderable: false, targets: [8,9] }],
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
                                    columns: [1,2, 3, 4, 5, 6, 7]
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
        function dataTableSoportes() {
            $('#<%=grdDocumentos.ClientID%>').DataTable({
                "destroy": true,
                "pageLength": 5,
                "searching": false,
                "info": false,
                "lengthChange": false,
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
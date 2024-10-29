<%@ Page Title="CONTROL DE ACCESO" Language="C#" MasterPageFile="~/Site.Master"   AutoEventWireup="true" CodeBehind="frmRegistrosIngresos.aspx.cs" Inherits="Web.Views.GetInto.frmRegistrosIngresos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6 mt-2">
                                <h4>Control de Acceso a Areas Tecnicas.</h4>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="panel-body">
                        <div class="d-flex justify-content-start align-items-center mb-5">
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
                            <div class="col-md-4">
                                <asp:LinkButton ID="btnBuscarFiltroSuperior" runat="server" OnClick="btnBuscarFiltroSuperior_Click" class="btn btn-outline-secondary btn-lg"><i class="fas fa-search"></i> Buscar</asp:LinkButton>
                            </div>

                        </div>
                        <hr />
                            <div class="container">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdIngresos" runat="server" AutoGenerateColumns="False" OnRowDataBound="grdIngresos_RowDataBound" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Fecha" DataField="Fecha" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Número de Documento" DataField="Visitante.Persona.NumeroIdentificacion" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Nombre" DataField="Visitante.Persona.NombreCompleto" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Teléfono" DataField="Visitante.Persona.Telefono" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Email" DataField="Visitante.Persona.Email" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Empresa" DataField="Empresa.RazonSocial" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Tipo Visitante " DataField="Visitante.TipoVisitante.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Programa Formación " DataField="ProgramaFormacion.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Ficha" DataField="Ficha" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CheckBoxField HeaderText="Politica de Datos" DataField="PoliticaDatos" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="7%" />
                                            
                                            <asp:TemplateField HeaderText="Áreas Técnicas">
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
        .aspNetDisabled{
            border-color: #ffffff00!important;
            border-style:none!important;
        }

        td, th{
            vertical-align: middle!important;
            font-size:11px!important;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            dataTable();
        });
        function dataTable() {
            $('#<%=grdIngresos.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
                order: [[0, 'desc']],
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
                                    columns: [1,2, 3, 4, 5, 6, 7, 8, 9, 11,12]
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

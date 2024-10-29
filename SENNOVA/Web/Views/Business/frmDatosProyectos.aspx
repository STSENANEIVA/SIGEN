<%@ Page Title="PROYECTOS ASIGNADOS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmDatosProyectos.aspx.cs" Inherits="Web.Views.Business.frmDatosProyectos" %>

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
                                    <asp:LinkButton ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" class="btn btn-outline-primary btn-lg">Buscar</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="panel-body">
                        <div class="row">
                            <asp:TextBox ID="txtIdProyecto" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:HiddenField ID="hidProyectoId" Value="" runat="server" />
                                    <label for="txtProyecto">Título del proyecto</label>
                                    <asp:TextBox ID="txtProyecto" CssClass="form-control" placeholder="Título del proyecto" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr />
                            <div class="row">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdProyecto" runat="server" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla.">
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Título del Proyecto" DataField="TituloProyecto" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Código SGPS" DataField="CodigoSGPS" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Año de Ejecución " DataField="AnoEjecucion" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Fecha " DataField="FechaDiligenciamiento" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Objetivo General " DataField="ObjetivoGeneral" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Centro Formación " DataField="CentroFormacion.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Linea Programatica " DataField="LineaProgramatica.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Red Conocimiento Sectorial " DataField="RedConocimientoSectorial.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Área Conocimiento " DataField="AreaConocimiento.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Lider Proyecto " DataField="Empleado.NombreCompleto" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Asignación Inicial " DataField="AsignacionInicial" ItemStyle-Width="7%" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="Center" />
                                            <%--<asp:CommandField HeaderText="Editar" ShowSelectButton="True" SelectText="Sel" ControlStyle-CssClass="btn btn-outline-info btn-sm" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />--%>
                                            <asp:TemplateField HeaderText="Detalles" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDetalles" Text='<i class="fas fa-info"></i>' CssClass="btn text-secondary btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkDetalles_Click" ToolTip="Gestionar Proyecto." />
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
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscar" />
                <asp:AsyncPostBackTrigger ControlID="grdProyecto" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <br />
    <br />
    <br />
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
        }

        function dataTable() {
            $('#<%=grdProyecto.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
                columnDefs: [{ orderable: false, targets: [12] }],
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
                                    columns: [1,2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
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

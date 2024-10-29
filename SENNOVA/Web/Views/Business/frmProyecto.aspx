<%@ Page Title="PROYECTO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmProyecto.aspx.cs" Inherits="Web.Views.Business.frmProyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.css" rel="stylesheet"/>
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Gestionar Proyecto.</h4>
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
                            <asp:TextBox ID="txtIdProyecto" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label for="txtTituloProyecto">Título del Proyecto *</label>
                                    <asp:TextBox ID="txtTituloProyecto" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtCodigoSGPS">Código SGPS *</label>
                                    <asp:TextBox ID="txtCodigoSGPS" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtAnoEjecucion">Año de Ejecución *</label>
                                    <asp:TextBox ID="txtAnoEjecucion" placeholder="2021" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFecha">Fecha Diligenciamiento *</label>
                                    <asp:TextBox ID="txtFecha" TextMode="Date" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:HiddenField ID="hidCentroFormacionId" Value="" runat="server" />
                                    <label for="txtCentroFormacion">Centros de Formación</label>
                                    <asp:TextBox ID="txtCentroFormacion" runat="server"  CssClass="form-control" placeholder="Nombre de los Centros de Formación" ></asp:TextBox>
                                </div>
                            </div>                            
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlLineaProgramatica">Linea Programatica</label>
                                    <asp:DropDownList Width="180px" ID="ddlLineaProgramatica" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlRedConocimientoSectorial">Red de Conocimiento Sectorial</label>
                                    <asp:DropDownList Width="180px" ID="ddlRedConocimientoSectorial" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlAreaConocimiento">Área de Conocimiento</label>
                                    <asp:DropDownList Width="180px" ID="ddlAreaConocimiento" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:HiddenField ID="hidPersonaId" Value="" runat="server" />
                                    <label for="txtPersona">Lider Proyecto</label>
                                    <asp:TextBox ID="txtPersona"  ReadOnly="true"  CssClass="form-control" placeholder="Nombre del Lider Proyecto" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtAsigancionInicial">Asiganción Inicial *</label>
                                    <asp:TextBox ID="txtAsigancionInicial" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group">
                                    <label for="txtObjetivoGeneral">Objetivo General *</label>
                                    <asp:TextBox TextMode="multiline" Columns="100" Rows="2" ID="txtObjetivoGeneral" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr />
                            <div class="row">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdProyecto" runat="server" OnSelectedIndexChanged="grdProyecto_SelectedIndexChanged" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
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
                                            <asp:BoundField HeaderText="Asignacion Inicial " DataField="AsignacionInicial" DataFormatString="{0:C0}" ItemStyle-Width="7%" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="IdCentroFormacion" DataField="CentroFormacion.Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />                                            
                                            <asp:CommandField HeaderText='<i class="fas fa-edit"></i>' ShowSelectButton="True" SelectText='<i class="fas fa-edit"></i>' ControlStyle-CssClass="btn text-warning btn-sm" ItemStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField HeaderText="Objetivos" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkObjetivos" Text='<i class="fas fa-clipboard-check"></i>' CssClass="btn text-secondary btn-lg" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkObjetivos_Click" ToolTip="Gestionar Objetivos." />
                                                    <%--<asp:LinkButton ID="lnkEliminar" Text="Eliminar" CssClass="btn btn-outline-danger btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkEliminar_Click" ToolTip="Eliminar Costo." ItemStyle-Width="5%" />--%>
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
                            <asp:Image ID="Image2" runat="server" Height="360px" Width="370px"
                                ImageUrl="~/Img/loading.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

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
            $("#<%=txtCentroFormacion.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Services/SCentroFormacion.asmx/GetCentrosFormacion") %>',
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
                    $("#<%=hidCentroFormacionId.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });

        }

        function dataTable() {
            $('#<%=grdProyecto.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
                columnDefs: [{ orderable: false, targets: [13,14] }],
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

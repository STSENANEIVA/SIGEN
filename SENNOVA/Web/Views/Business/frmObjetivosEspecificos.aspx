<%@ Page Title="OBJETIVOS ESPECÍFFICOS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmObjetivosEspecificos.aspx.cs" Inherits="Web.Views.Business.frmObjetivosEspecificos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Gestionar Objetivos Específicos.</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <div class="btn-group pull-right">
                                    <asp:LinkButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" class="btn btn-outline-primary btn-lg">Guardar</asp:LinkButton>
                                    <%--<asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-outline-warning">Nuevo</asp:LinkButton>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtCodigoSGPS">Cósdigo SGPS*</label>
                                    <asp:TextBox ID="txtCodigoSGPS" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtCodigo">Item *</label>
                                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="txtNombre">Objetivo Específico*</label>
                                    <asp:TextBox TextMode="multiline" Columns="100" Rows="3" ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                </div>
                                <asp:TextBox ID="txtIdProyecto" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="txtIdObjetivoEspecifico" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
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
                                    <asp:GridView ID="grdObjetivoEspecifico" runat="server" OnSelectedIndexChanged="grdObjetivoEspecifico_SelectedIndexChanged" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100"  EmptyDataText="No hay datos disponibles en la tabla">
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Item" DataField="Codigo" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Objetivo Especifico" DataField="Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:CommandField HeaderText='<i class="fas fa-edit"></i>' ShowSelectButton="True" SelectText='<i class="fas fa-edit"></i>' ControlStyle-CssClass="btn text-warning btn-sm" ItemStyle-HorizontalAlign="Center"/>
                                            <asp:TemplateField HeaderText="Actividades" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkActividades" Text='<i class="fas fa-plus"></i>' CssClass="btn text-success btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkActividades_Click" ToolTip="Gestionar Actividades." />
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

    <script type="text/javascript">
        $(document).ready(function () {
            dataTable();
        });
        function dataTable() {
            $('#<%=grdObjetivoEspecifico.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
                columnDefs: [{ orderable: false, targets: [3,4,5] }],
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
                                    columns: [1,2]
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

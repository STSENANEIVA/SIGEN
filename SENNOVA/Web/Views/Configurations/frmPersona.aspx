<%@ Page Title="PERSONAS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPersona.aspx.cs" Inherits="Web.Views.Configurations.frmPersona" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Gestión de Usuario</h4>
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
                    <div class="row">
                    <div class="col-md-12">
                        <div class="btn-group mb-3 pull-right">
                            <a href="http://10.192.65.10:8083/Files/Formato_Personas.xlsx" download="Formato_Personas.xlsx" class="btn btn-outline-secondary btn-lg">Descargar Formato</a>
                            <asp:LinkButton ID="lnkCargarExcel" Text="Cargar Excel" CssClass="btn btn-outline-success btn-lg" runat="server" OnClick="lnkCargarExcel_Click"/>
                        </div>
                    </div>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <asp:TextBox ID="txtIdPersona" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="ddlTipoDocumento">Tipo de Documento</label>
                                    <asp:DropDownList placeholder="Seleccione" ID="ddlTipoDocumento" runat="server" CssClass="form-control"/>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtNumeroIdentificacion">Número de Identificación *</label>
                                    <asp:TextBox TextMode="Number" ID="txtNumeroIdentificacion" OnTextChanged="txtNumeroIdentificacion_TextChanged" AutoPostBack="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtNombres">Nombres *</label>
                                    <asp:TextBox ID="txtNombres" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtApellidos">Apellidos *</label>
                                    <asp:TextBox ID="txtApellidos" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtTelefono">Teléfono *</label>
                                    <asp:TextBox ID="txtTelefono" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtEmail">Email *</label>
                                    <asp:TextBox ID="txtEmail" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr />
                            <div class="container">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdPersona" runat="server" OnSelectedIndexChanged="grdPersona_SelectedIndexChanged" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Tipo de Documento " DataField="TipoDocumento.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Número de Documento" DataField="NumeroIdentificacion" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Nombres" DataField="Nombres" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Apellidos " DataField="Apellidos" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Teléfono " DataField="Telefono" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Email " DataField="Email" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CommandField HeaderText='<i class="fas fa-edit"></i>' ShowSelectButton="True" SelectText='<i class="fas fa-edit"></i>' ControlStyle-CssClass="btn text-warning btn-sm" ItemStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField HeaderText='<i class="fas fa-trash-alt"></i>' ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEliminar" Text='<i class="fas fa-trash-alt"></i>' CssClass="btn text-danger btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkEliminar_Click" ToolTip="Eliminar" />
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
        <%--Modal Cargar Excel--%>
        <div class="modal" id="modalCargarExcel" tabindex="-1">
            <div class="modal-dialog" style="max-width: 650px; margin-top: 10%;">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">CARGAR EXCEL</h4>
                    <asp:LinkButton ID="btnCerarModal" Text="x" CssClass="btn-close" runat="server" OnClick="lnkCerrarModal" />
                </div>
                <div class="modal-body" style="border-bottom: 1px solid #dee2e6;">
                    <asp:FileUpload ID="upFile" runat="server" CssClass="form-control" style="font-size:12px!important;"/>
                    <asp:LinkButton ID="btnUpload" name="upload"  runat="server" OnClick="btnLeer_Click" class="btn btn-success mt-3" style="font-size:12px!important;">Cargar Excel</asp:LinkButton>
                </div>
                <div class="modal-body">
                    <div class="table-responsive">
                        <asp:GridView ID="grdCargarExcel" runat="server"  AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
				        <Columns>
					        <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                            <asp:BoundField HeaderText="Codigo" DataField="Codigo" ItemStyle-HorizontalAlign="Center" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
					        <asp:BoundField HeaderText="Tipo de Documento" DataField="TipoDocumento.Nombre" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Número de Documento " DataField="NumeroIdentificacion" ItemStyle-HorizontalAlign="Center" />
					        <asp:BoundField HeaderText="Nombres" DataField="Nombres" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Apellidos " DataField="Apellidos" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Teléfono " DataField="Telefono" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="Email " DataField="Email" ItemStyle-HorizontalAlign="Center" />
				        </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="btnGuardarExcel" runat="server" OnClick="btnGuardarExcel_Click" class="btn btn-primary" style="font-size:12px!important;">Guardar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            dataTable();
            dataTableExcel();
        });

        function dataTable() {
            $('#<%=grdPersona.ClientID%>').DataTable({
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
                                    columns: [2, 3, 4, 5, 6, 7]
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
        function dataTableExcel() {
            $('#<%=grdCargarExcel.ClientID%>').DataTable({
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
        function confirmAlert(idPersona) {
            Swal.fire({
                title: '¿Estas seguro de eliminar la persona?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, Eliminar!'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Services/SEliminar.asmx/EliminarPersona") %>',
                        data: "{ 'idPersona': '" + idPersona + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                    }).done(function (data) {
                        var excepcion = data['d'][0]
                        var message = data['d'][1]

                        if (excepcion == "Asociada") {
                            warningalert(message);
                        } else if (excepcion == "Warning") {
                            warningalert(message);
                        } else if (excepcion == "Error") {
                            erroralert(message)
                        } else {
                            Swal.fire({
                                position: 'center',
                                icon: 'success',
                                title: 'Se ha eliminado correctamente',
                                showConfirmButton: false,
                                timer: 1500
                            })
                            setTimeout(function () {
                                location.reload()
                            }, 2000);
                        }
                    }).fail(function () {
                        Swal.fire({
                            icon: 'error',
                            title: 'Oops...',
                            text: 'No se pudo eliminar la persona!',
                        })
                    });
                }
            })
        }
    </script>
</asp:Content>
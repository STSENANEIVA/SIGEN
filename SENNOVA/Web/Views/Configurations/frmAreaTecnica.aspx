<%@ Page Title="ÁREA TÉCNICA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAreaTecnica.aspx.cs" Inherits="Web.Views.Configurations.frmAreaTecnica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.2/jquery-ui.css" rel="stylesheet" />
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Gestionar Áreas Técnicas.</h4>
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
                                <asp:TextBox ID="txtIdAreaTecnica" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlTipoAreaTecnica">Tipo Área Técnica</label>
                                    <asp:DropDownList Width="180px" ID="ddlTipoAreaTecnica" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:HiddenField ID="hidResponsableId" Value="" runat="server" />
                                <label for="txtResponsable">Responsable</label>
                                <div class="input-group mb-3">
                                    <asp:TextBox ID="txtResponsable" runat="server" CssClass="form-control" placeholder="Nombre del Responsable"></asp:TextBox>
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
                            <div class="container">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdAreaTecnica" runat="server" OnSelectedIndexChanged="grdAreaTecnica_SelectedIndexChanged" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Código" DataField="Codigo" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Nombre " DataField="NombreSin" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Tipo Área Técnica" DataField="TipoAreaTecnica.Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Responsable " DataField="Empleado.NombreCompleto" ItemStyle-HorizontalAlign="Center" />
                                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />
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

            function initializer() {
                $("#<%=txtResponsable.ClientID %>").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: '<%=ResolveUrl("~/Services/SPersona.asmx/GetPersonas") %>',
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
                        $("#<%=hidResponsableId.ClientID %>").val(i.item.val);
                    },
                    minLength: 1
                });
            }

        });

        function dataTable() {
            $('#<%=grdAreaTecnica.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
                columnDefs: [{ orderable: false, targets: [5, 6, 7] }],
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
                                    columns: [1, 2, 3, 4]
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
        function confirmAlert(idAreaTecnica) {
            Swal.fire({
                title: '¿Estas seguro de eliminar el Área Técnica?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, Eliminar!'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Services/SEliminar.asmx/EliminarAreaTecnica") %>',
                        data: "{ 'idAreaTecnica': '" + idAreaTecnica + "'}",
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
                        text: 'No se pudo eliminar el área técnica!',
                    })
                });
                }
            })
        }    

    </script>
</asp:Content>

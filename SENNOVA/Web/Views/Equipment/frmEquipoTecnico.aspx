<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEquipoTecnico.aspx.cs" Inherits="Web.Views.Equipment.frmEquipoTecnico" %>

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
                                <h4>
                                    <label>Gestionar Equipos Técnicos.</label></h4>
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
                        <h4>
                            <label>Generalidades</label></h4>
                        <hr />

                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtPlaca">Placa *</label>
                                    <asp:TextBox ID="txtPlaca" OnTextChanged="txtPlaca_TextChanged" AutoPostBack="true" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <asp:TextBox ID="txtIdEquipo" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlTipoEquipo">Tipo de Equipo</label>
                                    <asp:DropDownList placeholder="Seleccione" ID="ddlTipoEquipo" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtNombre">Nombre del Equipo *</label>
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <asp:TextBox ID="txtIdResponsable" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlResponsable">Responsable</label>
                                    <asp:DropDownList placeholder="Seleccione" ID="ddlResponsable" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtSerial">Serial *</label>
                                    <asp:TextBox ID="txtSerial" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtMarca">Marca *</label>
                                    <asp:TextBox ID="txtMarca" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaCompra">Fecha de Compra *</label>
                                    <asp:TextBox ID="txtFechaCompra" TextMode="Date" runat="server" DataFormatString="{0:dd/MM/yyyy}" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtValor">Valor de Compra *</label>
                                    <asp:TextBox ID="txtValor" TextMode="Number" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtNumeroContrato">Número de Contrato</label>
                                    <asp:TextBox ID="txtNumeroContrato" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtFechaFuncionamiento">Puesta en Marcha *</label>
                                    <asp:TextBox ID="txtFechaFuncionamiento" TextMode="Date" DataFormatString="{0:dd/MM/yyyy}" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlAreaTecnica">Área Técnica</label>
                                    <asp:DropDownList ID="ddlAreaTecnica" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlEstado">Estado</label>
                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <hr />
                        <h4>
                            <label>Especificaciones Técnicas</label></h4>
                        <hr />
                        <div class="row">
                            <asp:TextBox ID="txtIdTecnico" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtClaseEquipo">Clase de Equipo</label>
                                    <asp:TextBox ID="txtClaseEquipo" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="ddlTipoPatron">Tipo de Patrón</label>
                                    <asp:DropDownList ID="ddlTipoPatron" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="txtCaracteristicas">Caracteristicas</label>
                                    <asp:TextBox ID="txtCaracteristicas" TextMode="MultiLine" Rows="3" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkAire">Aire</label><br />
                                    <asp:CheckBox ID="chkAire" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtPresionAire">Presión de Aire</label>
                                    <asp:TextBox ID="txtPresionAire" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtCaudal">Caudal</label>
                                    <asp:TextBox ID="txtCaudal" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkElectricidad">Electricidad</label><br />
                                    <asp:CheckBox ID="chkElectricidad" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtVoltaje">Voltaje</label>
                                    <asp:TextBox ID="txtVoltaje" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtAmperaje">Amperaje</label>
                                    <asp:TextBox ID="txtAmperaje" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtPotencia">Potencia</label>
                                    <asp:TextBox ID="txtPotencia" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkGas">Gas</label><br />
                                    <asp:CheckBox ID="chkGas" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtTipoGas">Tipo Gas</label>
                                    <asp:TextBox ID="txtTipoGas" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtPresionGas">Presión de Gas</label>
                                    <asp:TextBox ID="txtPresionGas" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkAceite">Aceite</label><br />
                                    <asp:CheckBox ID="chkAceite" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtTipoAceite">Tipo de Aceite</label>
                                    <asp:TextBox ID="txtTipoAceite" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>

                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkOtros">Otros</label><br />
                                    <asp:CheckBox ID="chkOtros" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <label for="txtEspecifique">Especifique</label>
                                    <asp:TextBox ID="txtEspecifique" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                            </div>
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label for="txtObservaciones">Observaciones</label>
                                    <asp:TextBox ID="txtObservaciones" TextMode="MultiLine" Rows="3" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <h4>
                            <label>Accesorios</label></h4>
                        <hr />
                        <div class="row">
                            <asp:HiddenField ID="hidAccesorioId" Value="" runat="server" />
                            <label for="txtAccesorio">Accesorio</label>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtAccesorio" runat="server" CssClass="form-control" placeholder="Nombre de los Accesorio"></asp:TextBox>
                                <asp:LinkButton ID="btnAgregarAccesorios" runat="server" OnClick="btnAgregarAccesorios_Click" class="btn btn-outline-success">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-lg" viewBox="0 0 16 16">
                                                <path fill-rule="evenodd" d="M8 2a.5.5 0 0 1 .5.5v5h5a.5.5 0 0 1 0 1h-5v5a.5.5 0 0 1-1 0v-5h-5a.5.5 0 0 1 0-1h5v-5A.5.5 0 0 1 8 2Z"/>
                                            </svg>
                                </asp:LinkButton>
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-2">
                                    <div class="btn-group pull-right">
                                        <asp:LinkButton ID="btnGuardarAccesorios" runat="server" OnClick="btnGuardarAccesorios_Click" class="btn btn-outline-secondary btn-lg">Guardar</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="table-responsive-sm">
                                <asp:GridView ID="grdAccesorios" runat="server" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
                                    <Columns>
                                        <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                        <asp:BoundField HeaderText="Código" DataField="Codigo" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Nombre " DataField="Nombre" ItemStyle-HorizontalAlign="Center" />
                                        <asp:BoundField HeaderText="Descripción" DataField="Descripcion" ItemStyle-HorizontalAlign="Center" />
                                        <%--<asp:TemplateField HeaderText="Eliminar" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEliminar" Text="Eliminar" CssClass="btn btn-outline-danger btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkEliminar_Click" ToolTip="Eliminar Costo." ItemStyle-Width="5%" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <hr />
                        <h4>
                            <label>Adjuntar Documentos</label></h4>
                        <h5>
                            <label>Extenciones permitidas (.xlsx, .pdf, .docx)</label></h5>
                        <hr />
                        <div class="row">
                            <div class="btn-group col-md-4">
                                <asp:FileUpload ID="upDocument" runat="server" CssClass="form-control" />
                                <asp:LinkButton ID="lnkSubirDocumento" Text='<i class="fas fa-plus mt-2"></i>' CssClass="btn btn-outline-success" runat="server" OnClick="lnkSubirDocumento_Click" ToolTip="Subir Documento." />
                            </div>
                        </div>
                        <div class="row">
                            <div class="table-responsive mt-3">
                                <asp:GridView ID="grdDocumentos" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay documentos asociados a este equipo de computo.">
                                    <Columns>
                                        <asp:BoundField HeaderText="Archivo" DataField="Nombre" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:BoundField HeaderText="Url" DataField="Url" ItemStyle-HorizontalAlign="Justify" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                        <asp:TemplateField HeaderText='<i class="fas fa-trash-alt"></i>' ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDeleteDocument" Text='<i class="fas fa-trash-alt"></i>' CssClass="btn text-danger btn-lg" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="Delete" ToolTip="Eliminar Documento." />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText='<i class="fas fa-file-download"></i>' ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="DownloadDocument" Text='<i class="fas fa-file-download"></i>' CssClass="btn text-primary btn-lg" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="Download" ToolTip="Descargar Documento." />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <hr />
                        <h4>
                            <label>Adjuntar Imagenes</label></h4>
                        <h5>
                            <label>Extenciones permitidas (.png, .jpeg, .jpg)</label></h5>
                        <hr />
                        <div class="row">
                            <div class="btn-group col-md-4">
                                <asp:FileUpload ID="upImage" runat="server" CssClass="form-control" />
                                <asp:LinkButton ID="lnkSubirImagen" Text='<i class="fas fa-plus mt-2"></i>' CssClass="btn btn-outline-success" runat="server" OnClick="lnkSubirImagen_Click" ToolTip="Subir Imagen." />
                            </div>
                        </div>
                        <div class="row">
                            <div class="table-responsive mt-3">
                                <asp:GridView ID="grdImagenes" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay imagenes asociadas a este equipo de computo">
                                    <Columns>
                                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
                                        <asp:TemplateField HeaderText="Imagen" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:Image ID="image" runat="server" Width="200px" Height="200px" ImageUrl='<%# Eval("Descripcion") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Url" DataField="Url" ItemStyle-HorizontalAlign="Justify" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                        <asp:TemplateField HeaderText='<i class="fas fa-trash-alt"></i>' ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" Text='<i class="fas fa-trash-alt"></i>' CssClass="btn text-danger btn-lg" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="Delete" ToolTip="Eliminar Documento." />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText='<i class="fas fa-file-download"></i>' ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="Download" Text='<i class="fas fa-file-download"></i>' CssClass="btn text-primary btn-lg" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="Download" ToolTip="Descargar Documento." />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="lnkSubirDocumento" />
                <asp:PostBackTrigger ControlID="lnkSubirImagen" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <style>
        #MainContent_lnkSubirDocumento, #MainContent_lnkSubirImagen {
            width: 33px !important;
        }

        #MainContent_grdDocumentos, #MainContent_grdImagenes {
            font-size: 11.5px !important;
        }

            #MainContent_grdDocumentos tr td i, #MainContent_grdImagenes tr td i {
                font-size: 15px !important;
            }

        #MainContent_upDocument, #MainContent_upImage {
            height: 30px !important;
            font-size: 14px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            initializer();

            var prmInstance = Sys.WebForms.PageRequestManager.getInstance();

            prmInstance.add_endRequest(function () {
                //you need to re-bind your jquery events here
                initializer();
                dataTableAccesorios();
            });

        });
        function initializer() {
            $("#<%=txtAccesorio.ClientID %>").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Services/SAccesorios.asmx/GetAccesorios") %>',
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
                    $("#<%=hidAccesorioId.ClientID %>").val(i.item.val);
                },
                minLength: 1
            });
        }

        function dataTableAccesorios() {
            $('#<%=grdAccesorios.ClientID%>').DataTable({
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

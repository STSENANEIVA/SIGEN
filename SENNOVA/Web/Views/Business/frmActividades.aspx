<%@ Page Title="ACTIVIDADES" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmActividades.aspx.cs" Inherits="Web.Views.Business.frmActividades" %>

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
                                <h4>Gestionar Actividades.</h4>
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
                            <div id="advertencia" runat="server" class="alert alert-warning alert-dismissable" visible="false">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                <asp:Label Text="Advertencia!" runat="server" Font-Bold="true" />
                                <asp:Label ID="txtMensajeAdvertencia" Text="" runat="server" />
                            </div>
                            <div id="correcto" runat="server" class="alert alert-success alert-dismissable" visible="false">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                <asp:Label Text="Correcto!" runat="server" Font-Bold="true" />
                                <asp:Label ID="txtMensajeCorrecto" Text="" runat="server" />
                            </div>
                            <div id="error" runat="server" class="alert alert-danger alert-dismissable" visible="false">
                                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                <asp:Label Text="Error!" runat="server" Font-Bold="true" />
                                <asp:Label ID="txtMensajeError" Text="" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <asp:TextBox ID="txtIdObjetivo" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <asp:TextBox ID="txtIdActividad" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="txtCodigo">Código *</label>
                                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control" AutoCompleteType="None"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="txtNombre">Actividad *</label>
                                    <asp:TextBox ID="txtNombre" TextMode="multiline" Columns="100" Rows="5" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group">
                                    <label for="chkActivo">Activo</label><br />
                                    <asp:CheckBox ID="chkActivo" runat="server" Width="35px" CssClass="form-control" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="txtObjetivoEspecifico">Objetivo Específico</label>
                                    <asp:TextBox TextMode="multiline" Columns="100" Rows="5" ReadOnly="true" ID="txtObjetivo" runat="server" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <hr />
                            <div class="row">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdActividad" runat="server" OnSelectedIndexChanged="grdActividad_SelectedIndexChanged"  AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100"  EmptyDataText="No hay datos disponibles en la tabla">
                                        <Columns>
                                            <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                            <asp:BoundField HeaderText="Código" DataField="Codigo" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Actividad " DataField="Nombre" ItemStyle-HorizontalAlign="Center" />
                                            <%--<asp:BoundField HeaderText="ObjetivoEspecifico " DataField="ObjetivoEspecifico.Nombre" ItemStyle-HorizontalAlign="Center" />--%>
                                            <asp:CheckBoxField HeaderText="Activo" DataField="Activo" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />
                                            <asp:CommandField HeaderText='<i class="fas fa-edit"></i>' ShowSelectButton="True" SelectText='<i class="fas fa-edit"></i>' ControlStyle-CssClass="btn text-warning btn-sm" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />
                                            <asp:TemplateField HeaderText="Desarrollo" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkAvances" Text="Avances" CssClass="btn btn-outline-secondary btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkAvances_Click" ToolTip="Registrar Avances." ItemStyle-Width="5%" />
                                                    <hr />
                                                    <asp:LinkButton ID="lnkProductos" Text="Productos" CssClass="btn btn-outline-secondary btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkProductos_Click" ToolTip="Agregar Productos." ItemStyle-Width="5%" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                    </div>
                </div>

                <!-- Modal Gestionar Productos -->
                <div class="modal" id="ModalProductos" data-backdrop="false" data-bs-backdrop="false" role="dialog">
                    <div class="modal-dialog modal-dialog-centered modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="row">
                                    <div class="col-md-8">
                                        <h5 class="modal-title" id="staticBackdropLabel">Gestione los Productos</h5>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:LinkButton ID="btnGuardarProducto" Text="Guardar Producto" CssClass="btn btn-outline-primary btn-lg" runat="server" OnClick="btnGuardarProducto_Click" ToolTip="Guardar Producto." />
                                    </div>
                                    <div class="col-md-1">
                                        <%--<button type="button" class="btn btn-outline-success" id="btnGuardarProducto" runat="server" onclick="btnGuardarProducto_Click">Guardar</button>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-body">
                                <div class="container-fluid">
                                    <div class="row">
                                        <asp:TextBox ID="txtIdProducto" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtIdActividadProducto" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                        <div class="col-md-1">
                                            <div class="form-group">
                                                <label for="txtCodigoProducto">Codigo *</label>
                                                <asp:TextBox ID="txtCodigoProducto" runat="server" class="form-control" AutoCompleteType="None"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="txtNombreProducto">Producto *</label>
                                                <asp:TextBox ID="txtNombreProducto" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="ddlTipoProducto">Tipo de Producto</label>
                                                <asp:DropDownList Width="180px" ID="ddlTipoProducto" runat="server" CssClass="form-control" />
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <div class="form-group">
                                                <label for="chkActivoProducto">Activo</label><br />
                                                <asp:CheckBox ID="chkActivoProducto" runat="server" Width="35px" CssClass="form-control" />
                                            </div>
                                        </div>
                                    </div>
                                        <div class="row">
                                            <div class="table-responsive-sm">
                                                <asp:GridView ID="grdProducto" runat="server" OnSelectedIndexChanged="grdProducto_SelectedIndexChanged" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                        <asp:BoundField HeaderText="Codigo" DataField="Codigo" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Producto " DataField="Nombre" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Tipo Producto " DataField="TipoProducto.Nombre" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:CheckBoxField HeaderText="Activo" DataField="Activo" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />
                                                        <asp:CommandField HeaderText='<i class="fas fa-edit"></i>' ShowSelectButton="True" SelectText='<i class="fas fa-edit"></i>' ControlStyle-CssClass="btn text-warning btn-sm" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />
                                                        <asp:TemplateField HeaderText="Soportes" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkSoportes" Text='<i class="fas fa-file-upload"></i>' CssClass="btn text-success btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkSoprtes_Click" ToolTip="Agregar Soportes." ItemStyle-Width="5%" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary btn-lg" onclick="initializer();">Cerrar</button>
                                <%--<asp:LinkButton ID="lnkCerrarModalProductos" Text="Cerrar" CssClass="btn btn-outline-secondary" runat="server" OnClick="lnkCerrarModal_Click" ToolTip="Cerrar Modal." />--%>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal Gestionar Productos -->

                <!-- Modal Soportes-->
                <div class="modal" id="myModalSoportes" role="dialog" data-bs-backdrop="false" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
                    <div class="modal-dialog modal-xs">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h4>
                                            <span style="float: right;"><small>Total Soportes por Productos:</small>
                                                <asp:Label ID="lblTotalSoportesProductos" runat="server" CssClass="label label-warning" />
                                            </span>
                                        </h4>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="modal-header text-primary">
                                            <h4 class="modal-title">Adjuntar Archivo</h4>
                                        </div>
                                        <div class="modal-body">
                                            <div class="row">
                                                <p>Por favor antes de adjuntar el archivo verifique lo siguiente :</p>
                                                <i class="icon-next"></i>
                                                <p>El archivo no debe superar los 2 Mb de tamaño</p>
                                                <i class="icon-next"></i>
                                                <p>Solo se permiten archivos con la extensión <span>jpg, png, pdf</span> - Se deben convertir antes de enviar.</p>
                                                <hr />
                                                <div class="input-group mb-3 w-75">
                                                    <asp:FileUpload ID="fuAdjunto" CssClass="form-control" runat="server" style="font-size: 12.5px;" />
                                                    <asp:LinkButton ID="lnkSubir" Text="Subir" CssClass="btn btn-outline-success btn-lg" runat="server" OnClick="btnSubir_Click" ToolTip="Subir Evidencia." />
                                                </div>
                                                <br />
                                                <br />
                                                <hr />
                                                <asp:Label Text="" runat="server" ID="txtMensaje" CssClass="label-success" />
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:GridView ID="grdSoportes" runat="server" Height="50px" PageSize="10" AutoGenerateColumns="False" CssClass="table table-bordered" EmptyDataText="No hay Soportes creados." Width="100%">
                                                        <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                        <RowStyle Font-Size="XX-Small" />
                                                        <EditRowStyle BackColor="#ffffcc" />
                                                        <SelectedRowStyle BackColor="#ffffcc" />
                                                        <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                        <EmptyDataTemplate>
                                                            ¡No hay Soportes asociados a este Producto!  
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Archivo" DataField="Nombre" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                                                            <asp:BoundField HeaderText="Url" DataField="Url" ItemStyle-HorizontalAlign="Justify" ItemStyle-CssClass="hidden" HeaderStyle-CssClass="hidden"></asp:BoundField>
                                                            <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkDelete" Text='<i class="fas fa-trash-alt"></i>' CssClass="btn text-danger btn-sm" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="Delete" ToolTip="Eliminar Soporte." />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Descargar" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="Download" Text='<i class="fas fa-file-download"></i>' CssClass="btn text-primary btn-sm" CommandArgument='<%# Eval("Url") %>' runat="server" OnClick="DownloadFile" ToolTip="Descargar Soporte." />
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
                            <div class="modal-footer">
                                <%--<button type="button" class="btn btn-secondary" runat="server" onclick="lnkCerrarModal_Click">Close</button>--%>
                                <asp:LinkButton ID="lnkCerrarModalSoportes" Text="Cerrar" CssClass="btn btn-outline-secondary btn-lg" runat="server" OnClick="lnkCerrarModal_Click" ToolTip="Cerrar Modal." />
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal Soportes -->

                <!-- Modal Gestionar Avances -->
                <div class="modal" id="ModalAvances" data-backdrop="false" data-bs-backdrop="false"   role="dialog">
                    <div class="modal-dialog modal-dialog-centered modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <div class="row">
                                    <div class="col-md-10">
                                        <h5 class="modal-title" id="staticBackdropLabelAvances">Gestione los Avances Tecnicos y Presupuestales</h5>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:LinkButton ID="lnkGuardarAvance" Text="Guardar Avance" CssClass="btn btn-outline-primary btn-lg" runat="server" OnClick="lnkGuardarAvance_Click" ToolTip="Guardar Avance." />
                                    </div>
                                </div>
                            </div>
                            <div class="modal-body">
                                <div class="container-fluid">
                                    <div class="row" id="divTecnico" runat="server">
                                        <asp:TextBox ID="txtSaldo" runat="server" Text="0" CssClass="form-control" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtIdAvance" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                        <asp:TextBox ID="txtIdAtividadAvance" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                        <div class="col-md-1">
                                            <div class="form-group">
                                                <label for="ddlMes">Mes</label>
                                                <asp:DropDownList ID="ddlMes" runat="server" CssClass="form-control">
                                                    <asp:ListItem Selected="True" Value="Enero"> Enero </asp:ListItem>
                                                    <asp:ListItem Value="Febrero"> Febrero </asp:ListItem>
                                                    <asp:ListItem Value="Marzo"> Marzo </asp:ListItem>
                                                    <asp:ListItem Value="Abril"> Abril </asp:ListItem>
                                                    <asp:ListItem Value="Mayo"> Mayo </asp:ListItem>
                                                    <asp:ListItem Value="Junio"> Junio </asp:ListItem>
                                                    <asp:ListItem Value="Julio"> Julio </asp:ListItem>
                                                    <asp:ListItem Value="Agosto"> Agosto </asp:ListItem>
                                                    <asp:ListItem Value="Septiembre"> Septiembre </asp:ListItem>
                                                    <asp:ListItem Value="Octubre"> Octubre </asp:ListItem>
                                                    <asp:ListItem Value="Noviembre"> Noviembre </asp:ListItem>
                                                    <asp:ListItem Value="Diciembre"> Diciembre </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="txtProyectado">% Proyectado *</label> 
                                                <asp:TextBox ID="txtProyectado" Text="0"  runat="server" class="form-control" AutoCompleteType="None"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="txtEjecutado">% Ejecutado </label>
                                                <asp:TextBox ID="txtEjecutado" Text="0" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="form-group">
                                                <label for="txtObservacionTecnica">Observación Tecnica </label>
                                                <asp:TextBox ID="txtObservacionTecnica" TextMode="MultiLine" Rows="2" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="divPresupuestal" runat="server">
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="txtEjecutadoPresupuestal">Presupuesto Ejecutado </label>
                                                <asp:TextBox ID="txtEjecutadoPresupuestal"  Text="0"  runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="txtAdicion">%  Adición </label>
                                                <asp:TextBox ID="txtAdicion" runat="server"  Text="0"  class="form-control" AutoCompleteType="None"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-2">
                                            <div class="form-group">
                                                <label for="txtDisminucion">Disminución / Centralización </label>
                                                <asp:TextBox ID="txtDisminucion" runat="server"  Text="0"  class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtObservacionPresupuestal">Observación Presupuestal </label>
                                                <asp:TextBox ID="txtObservacionPresupuestal" TextMode="MultiLine" Rows="2" runat="server" class="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                        <div class="row">
                                            <div class="table-responsive">
                                                <asp:GridView ID="grdAvance" runat="server" OnSelectedIndexChanged="grdAvance_SelectedIndexChanged" AutoGenerateColumns="False" class="table table-bordered table-hover table-striped w-100" EmptyDataText="No hay datos disponibles en la tabla">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Id" DataField="Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                        <asp:BoundField HeaderText="Mes" DataField="Mes" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Proyectado " DataField="Proyectado" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Ejecutado" DataField="Ejecutado" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Observaciones Tenicas" DataField="Observaciones" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Presupuesto Ejecutado" DataField="EjecutadoPresupuesto" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Adicion" DataField="Adicion" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Disminucion" DataField="Disminucion" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Observaciones Presupuestales" DataField="ObservacionesPresupuestales" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="Saldo" DataField="Saldo" DataFormatString="{0:C0}" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:BoundField HeaderText="IdActividad" DataField="Actividad.Id" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                        
                                                        <asp:CommandField HeaderText='<i class="fas fa-edit"></i>' ShowSelectButton="True" SelectText='<i class="fas fa-edit"></i>' ControlStyle-CssClass="btn text-warning btn-sm" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="5%" />
                                                        <%--<asp:TemplateField HeaderText="Soportes" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkSoportes" Text="Agregar" CssClass="btn btn-outline-secondary btn-sm" CommandArgument='<%# Eval("Id") %>' runat="server" OnClick="lnkSoprtes_Click" ToolTip="Agregar Soportes." ItemStyle-Width="5%" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-secondary btn-lg" onclick="initializer();">Cerrar</button>
                                <%--<asp:LinkButton ID="lnkCerrarModalProductos" Text="Cerrar" CssClass="btn btn-outline-secondary" runat="server" OnClick="lnkCerrarModal_Click" ToolTip="Cerrar Modal." />--%>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- Modal Gestionar Avances -->

                <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="Update">
                    <ProgressTemplate>
                        <div id="dvProgress" runat="server" style="position: absolute; top: 100px; left: 350px; text-align: center;">
                            <asp:Image ID="Image2" runat="server" Height="360px" Width="470px"
                                ImageUrl="~/Img/loading.gif" />
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnGuardarProducto" />
                <asp:PostBackTrigger ControlID="lnkGuardarAvance" />
                <asp:PostBackTrigger ControlID="grdSoportes" />
                <asp:PostBackTrigger ControlID="lnkSubir" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            dataTable();
            initializer();
        });

        function initializer() {
            $('#myModalSoportes').modal('hide');
            if ($('.modal-backdrop').is(':visible')) {
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();
            };

            $('#ModalProductos').modal('hide');
            if ($('.modal-backdrop').is(':visible')) {
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();
            };

            $('#ModalAvances').modal('hide');
            if ($('.modal-backdrop').is(':visible')) {
                $('body').removeClass('modal-open');
                $('.modal-backdrop').remove();
            };


        }

        function dataTable() {
            $('#<%=grdActividad.ClientID%>').DataTable({
                "destroy": true,
                dom: 'lBfrtip',
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

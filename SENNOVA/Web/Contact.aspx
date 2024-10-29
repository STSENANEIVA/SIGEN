<%@ Page Title="Contactenos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function successalert() {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Correo enviado correctamente',
                showConfirmButton: false,
                timer: 1500
            })
        }
        function warningalert() {
            Swal.fire({
                position: 'center',
                icon: 'warning',
                title: 'Los campos con (*) son obligatorios',
                showConfirmButton: true,
            })
        }
    </script>

    <br />
    <br />
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h1 class="text-center">CONTACTENOS</h1>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <div class="btn-group pull-right">
                                    <%--<asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-outline-warning">Nuevo</asp:LinkButton>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
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
                        <div class="d-flex align-items-center">
                            <div class="w-50" style="padding:20px">
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <label for="ddlTipoDocumento" style="font-size: 16px;">Tipo de Documento</label>
                                        <asp:DropDownList  placeholder="Seleccione" ID="ddlTipoDocumento" runat="server" CssClass="form-control" style="font-size: 16px;" />
                                    </div>
                                    <div class="col-md-6">
                                        <label for="txtNumeroIdentificacion" style="font-size: 16px;">Número de Identificación <label style="color:red"> *</label></label>
                                        <asp:TextBox ID="txtNumeroIdentificacion" runat="server" class="form-control" style="font-size: 16px;"></asp:TextBox>
                                    </div>
                                </div>
                                
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <label style="font-size: 16px;" for="txtNombres">Nombres <label style="color:red"> *</label></label>
                                        <asp:TextBox ID="txtNombres" runat="server" class="form-control" style="font-size: 16px;"></asp:TextBox>
                                    </div>

                                    <div class="col-md-6">
                                        <label style="font-size: 16px;" for="txtApellidos">Apellidos <label style="color:red"> *</label></label>
                                        <asp:TextBox ID="txtApellidos" runat="server" class="form-control" style="font-size: 16px;"></asp:TextBox>
                                    </div>
                                </div>
                                
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <label style="font-size: 16px;" for="txtTelefono">Télefono <label style="color:red"> *</label></label>
                                        <asp:TextBox ID="txtTelefono" runat="server" class="form-control" style="font-size: 16px;"></asp:TextBox>
                                    </div>

                                    <div class="col-md-6">
                                        <label style="font-size: 16px;" for="txtEmail">Correo electrónico <label style="color:red"> *</label></label>
                                        <asp:TextBox ID="txtEmail" runat="server" class="form-control" style="font-size: 16px;"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <label style="font-size: 16px;" for="txtEmail">Mensaje <label style="color:red"> *</label></label>
                                        <asp:TextBox ID="txtMensaje" TextMode="MultiLine" Rows="3" runat="server" class="form-control" style="font-size: 16px;"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-md-12 text-center">
                                        <asp:LinkButton ID="btnEnviar" runat="server" OnClick="btnGuardar_Click" class="btn" style="font-size: 17px; border-radius:20px; width:18%; background-color: #FF6B00; color: #fff">Enviar</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            
                            <div class="w-50" style="padding:20px">
                                <h1 class="mb-4"><i class="fas fa-map-marker-alt" style="color:#FF6B00"></i> <a href="https://www.google.com/maps/dir//SENA+INDUSTRIAL+Cra.+9+%2333+50+Neiva,+Huila+Colombia/@2.9623721,-75.2859007,16z/data=!4m8!4m7!1m0!1m5!1m1!1s0x8e3b746668a5f7f7:0x3fcec03b9c2c0e85!2m2!1d-75.2859007!2d2.9623721" target="_blank" class="text-decoration-none" style="color:#000;">Carrera 9 No. 68 - 50, Neiva (SENA Industrial) Regional Huila</a></h1>
                                <h1 class="mb-4"><i class="fas fa-envelope" style="color:#FF6B00"></i> <a href="mailto:servtecnologiconeiva@sena.edu.co" target="_blank" class="text-decoration-none" style="color:#000;">servtecnologiconeiva@sena.edu.co</a></h1>
                                <h1 class="mb-4"><i class="fas fa-phone-alt" style="color:#FF6B00"></i><a href="tel:0388757040" target="_blank" class="text-decoration-none" style="color:#000;"> (608) 8757040 Ext. 83410</a> </h1>
                                <h1 class="mb-4"><i class="fab fa-blogger" style="color:#FF6B00"></i> <a href="http://industriaempresayservicios.blogspot.com/p/servicios-tecnologicos.html" target="_blank" class="text-decoration-none" style="color:#000;">industriaempresayservicios.blogspot.com</a></h1>
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
    <div class="d-flex justify-content-center">
        <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d7968.964770628191!2d-75.285011!3d2.963567!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x3fcec03b9c2c0e85!2sSENA%20INDUSTRIAL!5e0!3m2!1ses!2sus!4v1655128483673!5m2!1ses!2sus" width="1200" height="550" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
    </div>
    <br /><br /><br />
</asp:Content>
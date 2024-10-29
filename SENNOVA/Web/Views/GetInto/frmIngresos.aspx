<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIngresos.aspx.cs" Inherits="Web.Views.Configurations.frmIngresos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="panel ">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-md-6">
                                <h4>Registro de Visitas.</h4>
                            </div>
                            <div class="col-md-4"></div>
                            <div class="col-md-2">
                                <div class="btn-group pull-right">
                                    <asp:LinkButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" class="btn btn-outline-warning">Nuevo</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="panel-body">
                        <asp:TextBox ID="txtIdPersona" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                        <div class="d-flex" style="margin-bottom: 15px;">
                            <div class="col-md-3">
                                <label for="ddlTipoDocumento">Tipo de Documento</label>
                                <asp:DropDownList placeholder="Seleccione" ID="ddlTipoDocumento" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-3">
                                <label for="txtNumeroIdentificacion">Número de Identificación *</label>
                                <asp:TextBox ID="txtNumeroIdentificacion" TextMode="Number" OnTextChanged="txtNumeroIdentificacion_TextChanged" AutoPostBack="true" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="col-md-3">
                                <label for="txtNombres">Nombres *</label>
                                <asp:TextBox ID="txtNombres" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label for="txtApellidos">Apellidos *</label>
                                <asp:TextBox ID="txtApellidos" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="d-flex" style="margin-bottom: 20px;">
                            <div class="col-md-3">
                                <label for="txtTelefono">Teléfono *</label>
                                <asp:TextBox ID="txtTelefono" runat="server" TextMode="Number" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label for="txtEmail">Email *</label>
                                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label for="ddlEmpresa">Empresa</label>
                                <asp:DropDownList placeholder="Seleccione" ID="ddlEmpresa" runat="server" CssClass="form-control" />
                            </div>
                            <div class="col-md-3">
                                <label for="ddlTipoVisitante">Tipo de Visitante</label>
                                <asp:DropDownList  placeholder="Seleccione" ID="ddlTipoVisitante" OnSelectedIndexChanged="ddlTipoVisitante_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="d-flex" style="margin-bottom: 20px;">
                            <div class="col-md-3" id="Aprendiz1" runat="server">
                                <label for="txtFicha">Número de Ficha *</label>
                                <asp:TextBox ID="txtFicha" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-3" id="Aprendiz2" runat="server">
                                <label for="ddlProgramaFormacion">Programa de Formación</label>
                                <asp:DropDownList Width="180px" placeholder="Seleccione" ID="ddlProgramaFormacion" runat="server" CssClass="form-control" />
                            </div>
                        </div>


                        <div class="row justify-content-center">

                            <div class="col-4">
                                <div class="form-group">
                                    <label for="chklAreasTecnicas">
                                        <h3>Seleccione las áreas técnicas visitadas</h3>
                                    </label>
                                    <asp:CheckBoxList ID="chklAreasTecnicas" runat="server" Width="280px" CssClass="">
                                    </asp:CheckBoxList>
                                </div>
                            </div>

                            <div class="col-8">
                                <div class="form-group">
                                    <label for="txtPolitica" style="text-align: justify">
                                        <h2>¿Acepta la política del tratamiento de datos?</h2>
                                           <P>En cumplimiento de Ley 1581 de 2012, protección de datos personales: “La autorización suministrada en el presente formato faculta al SENA para que dé a sus datos aquí recopilados, 
                                                    el tratamiento señalado en la política de privacidad para el tratamiento de datos personales del SENA. La autorización contempla el envío de información de eventos, actividades o servicios de la entidad. 
                                                    El titular de los datos podrá, en cualquier momento, solicitar al SENA que la información sea modificada, actualizada o retirada de las bases de datos, si así está almacenada”.</P>
                                                <p>Política SENA de tratamiento de datos personales. </P>
                                                <a runat="server" href="https://compromiso.sena.edu.co/mapa/descarga.php?id=3628" target="_blank">https://compromiso.sena.edu.co/mapa/descarga.php?id=3628</a>
                                                
                                    </label>
                                    <asp:CheckBox ID="chkPolitica" Text="&nbsp; Acepto" runat="server" Width="80px" CssClass="mt-3" />
                                    <asp:LinkButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" class="btn btn-outline-success btn-lg mt-2">Guardar</asp:LinkButton>

                                </div>
                            </div>
                            <div class="col-2">
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
    <br />
</asp:Content>

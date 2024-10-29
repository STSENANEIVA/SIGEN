<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Account.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="container" id="frmLogin">
        <div class="d-flex justify-content-center flex-column align-items-center">
            <div>
                <h2 class="my-4">Iniciar sesión</h2>
            </div>
            <div>
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" placeholder="Correo Electrónico"/>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email" CssClass="text-danger" ErrorMessage="El campo de correo electrónico es obligatorio." />
            </div>
            <div class="mt-3">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Contraseña" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
            </div>
            <div class="mt-3">
                <asp:Button runat="server" OnClick="LogIn" Text="Iniciar sesión" CssClass="btn" ID="btnLogin"/>
            </div>
            <div class="checkbox">
                <asp:CheckBox runat="server" ID="RememberMe"/>
                <asp:Label runat="server" AssociatedControlID="RememberMe">¿Recordar cuenta?</asp:Label>
            </div>
        </div>
        
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
    </div>
    <%--<p>
        <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registrarse como usuario nuevo</asp:HyperLink>
    </p>--%>
    <p>
        <%-- Enable this once you have account confirmation enabled for password reset functionality
            <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
            --%>
    </p>
    <div class="col-md-4">
        <section id="socialLoginForm">
            <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
        </section>
    </div>
</asp:Content>

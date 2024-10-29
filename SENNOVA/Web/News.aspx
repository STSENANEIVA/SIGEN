<%@ Page Title="Noticias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Web.News" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1 class="text-center" style="margin-top: 35px; font-size: 30px; color: #FF6B00;">Noticias</h1>

    <div class="d-flex align-items-center justify-content-center">

        <div class="w-50 perfil" style="padding: 50px">
            <asp:Image ID="news1" class="d-block m-auto" runat="server"  ImageUrl="~/Img/news1.jpg" Width="618px" Height="310px" style="border-radius: 10px" />
        </div>
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px; color: #FF6B00;" class="mb-3">Campaña de Socialización y Sensibilización </h1>
            <h1 style="font-size:27px; " class="mb-3">Electrónica e Instrumentación</h1>
            <p style="font-size:25px;" align="justify">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
        </div>

    </div>

    <div class="d-flex align-items-center justify-content-center">
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px; color: #FF6B00;" class="mb-3">Plan de Sensibilización</h1>
            <h1 style="font-size:27px;" class="mb-3">Tecnologías de la Información</h1>
            <p style="font-size:25px;" align="justify">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>
        </div>

        <div class="w-50 perfil" style="padding: 50px">
            <asp:Image ID="news2" class="d-block m-auto" runat="server"  ImageUrl="~/Img/news2.jpg" style="border-radius: 10px" />
        </div>

    </div>

</asp:Content>

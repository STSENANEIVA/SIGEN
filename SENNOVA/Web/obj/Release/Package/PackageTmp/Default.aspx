<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="carouselExampleInterval" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <%--<div class="carousel-item active" data-bs-interval="2000">
                <asp:Image ID="Image4" class="d-block w-100" runat="server" Width="1000px" Height="400px" ImageUrl="~/Img/Fondo-4.png" />
            </div>--%>
            <div class="carousel-item active" data-bs-interval="3000">
                <asp:Image ID="Image1" class="d-block w-100" runat="server" Width="1000px" Height="400px" ImageUrl="~/Img/Fondo-1.jpg" style="border-radius: 6px;" />
            </div>
            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image2" class="d-block w-100" runat="server" Width="1000px" Height="400px" ImageUrl="~/Img/Fondo-2.jpg" style="border-radius: 6px;" />
            </div>
            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image3" class="d-block w-100" runat="server" Width="1000px" Height="400px" ImageUrl="~/Img/Fondo-3.jpg" style="border-radius: 6px;" />
            </div>
            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image5" class="d-block w-100" runat="server" Width="1000px" Height="400px" ImageUrl="~/Img/Fondo-5.jpg" style="border-radius: 6px;" />
            </div>
            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image6" class="d-block w-100" runat="server" Width="1000px" Height="400px" ImageUrl="~/Img/Fondo-6.jpg" style="border-radius: 6px;" />
            </div>
            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image7" class="d-block w-100" runat="server" Width="1000px" Height="400px" ImageUrl="~/Img/Fondo-7.jpg" style="border-radius: 6px;" />
            </div>
            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image10" class="d-block w-100" runat="server" Width="1000px" Height="400px" ImageUrl="~/Img/Fondo-10.png" style="border-radius: 6px;" />
            </div>
            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image11" class="d-block w-100" runat="server" Width="1000px" Height="400px" ImageUrl="~/Img/Fondo-11.png" style="border-radius: 6px;" />
            </div>
            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image12" class="d-block w-100" runat="server" Width="1000px" Height="400px" ImageUrl="~/Img/Fondo-12.png" style="border-radius: 6px;" />
            </div>
        </div>
        <button class="carousel-control-prev" type="button" style="filter: invert(100%);" data-bs-target="#carouselExampleInterval" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" style="filter: invert(100%);" data-bs-target="#carouselExampleInterval" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
    <div id="st" class="row justify-content-center mt-5 align-items-center">
       <div class="col-12 col-md-6 mr-5">
           <h1 style="color: #FF6B00;">Servicios tecnológicos</h1><br />
           <p style="font-size: 23px;" align="justify" class="text-decoration-none">Escenario de apoyo al sector productivo y a la formación con servicios especializados técnicos y de laboratorios, que apoya temas asociados a la calidad, la normalización, acreditación, metrología e investigación aplicada para aportar soluciones asociadas a problemáticas de mercadeo, articulación y formación.</p>
       </div>
        <div class="col-12 col-md-6">
            <asp:Image ID="stImage" class="d-block w-100" runat="server" Height="400px" ImageUrl="~/Img/serviciosTecnologicos.jpeg" style="border-radius: 6px;" />
       </div>
    </div>
    <br />
    <div id="clientes" style="margin-top: 30px;">
        <h1 class="text-center" style="font-size: 30px; color: #FF6B00;">Quienes confían en Nosotros</h1>
        <div class="row justify-content-center mt-5 align-items-center" style="margin-bottom: 50px;">
            <div class="col-md-3">
                <asp:Image ID="enterprise1" class="d-block m-auto" runat="server" style="vertical-align: middle;" Width="170px" ImageUrl="~/Img/enterprise-1.jpeg"/>
            </div>
            <div class="col-md-3">
                <asp:Image ID="enterprise2" class="d-block m-auto" runat="server" style="vertical-align: middle;" Width="170px" ImageUrl="~/Img/enterprise-2.png"/>
            </div>
            <div class="col-md-3">
                <asp:Image ID="enterprise3" class="d-block m-auto" runat="server" style="vertical-align: middle;" Width="170px" ImageUrl="~/Img/enterprise-3.png"/>
            </div>
            <div class="col-md-3">
                <asp:Image ID="enterprise4" class="d-block m-auto" runat="server" style="vertical-align: middle;" Width="170px" ImageUrl="~/Img/enterprise-4.png"/>
            </div>
        </div>
    </div>
    <div id="redes" style="margin-top: 35px;">
        <h1 class="text-center" style="font-size: 20px;">Síguenos en nuestras redes sociales</h1>
        <div class="d-flex justify-content-center mt-5 align-items-center" style="margin-bottom: 50px;">
            <div>
                <a  class="btn" style="font-size: 30px;  color: #FF6B00;" target="_blank" href="https://web.facebook.com/SENA/?_rdc=1&_rdr"><i class="fab fa-facebook"></i></a>
            </div>
            <div>
                <a class="btn" style="font-size: 30px;  color: #FF6B00;" target="_blank" href="https://www.instagram.com/senacomunica/"><i class="fab fa-twitter"></i></a>
            </div>
            <div>
                <a class="btn" style="font-size: 30px;  color: #FF6B00;" target="_blank" href="https://twitter.com/SENAComunica"><i class="fab fa-instagram"></i></a>
            </div>
        </div>
    </div>
</asp:Content>

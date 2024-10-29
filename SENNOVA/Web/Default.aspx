<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="Banner" ContentPlaceHolderID="BannerContent" runat="server">

    <div id="carouselExampleInterval" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">

            <div class="carousel-item active" data-bs-interval="3000">
                <asp:Image ID="Image1" class="d-block w-100" runat="server" Height="280px" ImageUrl="~/Img/bannerMateriales.jpg" />
            </div>
            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image2" class="d-block w-100" runat="server" Height="280px" ImageUrl="~/Img/bannerMetrologia.jpg" />
            </div>

            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image5" class="d-block w-100" runat="server" Height="280px" ImageUrl="~/Img/bannerTecnologiasInformacion.jpg" />
            </div>

            <div class="carousel-item" data-bs-interval="3000">
                <asp:Image ID="Image3" class="d-block w-100" runat="server" Height="280px" ImageUrl="~/Img/bannerElectronica.jpg" />
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
    <div id="st" class="d-flex justify-content-around mt-5 align-items-center">
       <div class="">
           <h1 style="color: #FF6B00; font-size: 30px;">Servicios Tecnológicos</h1><br/>
           <p style="font-size: 23px;" align="justify" class="text-decoration-none">Escenario de apoyo al sector productivo y a la formación con</p>
           <p style="font-size: 23px;" align="justify" class="text-decoration-none">servicios especializados técnicos y de laboratorios, que apoya</p>
           <p style="font-size: 23px;" align="justify" class="text-decoration-none">temas asociados a la calidad, la normalización, acreditación,</p>
           <p style="font-size: 23px;" align="justify" class="text-decoration-none">metrología e investigación aplicada para aportar soluciones</p>
           <p style="font-size: 23px;" align="justify" class="text-decoration-none">asociadas a problemáticas de mercadeo, articulación y formación.</p>
       </div>
        <div class="">
            <asp:Image ID="stImage" class="d-block" runat="server" Height="400px" ImageUrl="~/Img/serviciosTecnologicos.jpeg" style="border-radius: 6px; width:100%" />
       </div>
    </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    <br />
    <div id="clientes" style="margin-top: 30px; margin-bottom:50px;">
        <h1 class="text-center" style="font-size: 32px; color: #FF6B00;">Quienes Confían en Nosotros</h1>
        <div class="row justify-content-center mt-5 align-items-center" style="margin-bottom: 50px;">
            <div class="col-md-3" style="opacity: 0.7">
                <asp:Image ID="enterprise1" class="d-block m-auto" runat="server" style="vertical-align: middle;" Width="170px" ImageUrl="~/Img/enterprise-1.jpeg"/>
            </div>
            <div class="col-md-3" style="opacity: 0.7">
                <asp:Image ID="enterprise2" class="d-block m-auto" runat="server" style="vertical-align: middle;" Width="170px" ImageUrl="~/Img/enterprise-2.png"/>
            </div>
            <div class="col-md-3" style="opacity: 0.7">
                <asp:Image ID="enterprise3" class="d-block m-auto" runat="server" style="vertical-align: middle;" Width="170px" ImageUrl="~/Img/enterprise-3.png"/>
            </div>
            <div class="col-md-3" style="opacity: 0.7">
                <asp:Image ID="enterprise4" class="d-block m-auto" runat="server" style="vertical-align: middle;" Width="170px" ImageUrl="~/Img/enterprise-4.png"/>
            </div>
        </div>
    </div>
</asp:Content>

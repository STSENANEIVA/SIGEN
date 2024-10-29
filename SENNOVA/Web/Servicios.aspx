<%@ Page Title="Protafolio de Servicios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="Web.Servicios" %>

<asp:Content ID="Banner" ContentPlaceHolderID="BannerContent" runat="server">

    <div id="carouselExampleInterval" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">

            <div class="carousel-item active" data-bs-interval="3000">
                <asp:Image ID="Image1" class="d-block w-100" runat="server" Height="340px" ImageUrl="~/Img/bannerPortafolioServicios.jpg" />
            </div>

        </div>
    </div>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <style>
        #listadoServicios:hover{
            transform: rotate(-2deg);
            -webkit-transition: all 0.7s;
        }

        #listadoServicios{
            transition: all 0.7s ease-out;
            -webkit-transition: all 0.7s;
        }

        #portafolioServicios:hover{
            transform: rotate(-2deg);
            -webkit-transition: all 0.7s;
        }

        #portafolioServicios{
            transition: all 0.7s ease-out;
            -webkit-transition: all 0.7s;
        }
    </style>
    <h1 class="text-uppercase" style="margin-top: 35px; font-size: 30px; color: #FF6B00;">¿Qué es  servicios tecnológicos</h1>
    <h1 class="text-uppercase" style="font-size: 30px; color:#00324d;">para las empresas?</h1>
    <div class="d-flex justify-content-around align-items-center" style="margin-top: 20px; background-color: #00324d;">
        <div style="padding:10px">
            <h1 class="text-white text-center" style="font-size: 50px"><i  class="far fa-lightbulb"></i></h1>
            <h3 class="text-white">INNOVACIÓN</h3>
        </div>
        <hr / style="height:11vh; width:0.2vw; color: white; opacity:inherit">
        <div style="padding:10px">
            <h1 class="text-white text-center" style="font-size: 50px"><i class="fas fa-microscope"></i></h1>
            <h3 class="text-white">INVESTIGACIÓN</h3>
        </div>
        <hr / style="height:11vh; width:0.2vw; color: white; opacity:inherit">
        <div style="padding:10px">
            <h1 class="text-white text-center" style="font-size: 50px"><i class="fas fa-code-branch"></i></h1>
            <h3 class="text-white">TECNOLOGÍA</h3>
        </div>
        <hr / style="height:11vh; width:0.2vw; color: white; opacity:inherit">
        <div style="padding:10px">
            <h1 class="text-white text-center" style="font-size: 50px"><i class="fas fa-chart-line"></i></h1>
            <h3 class="text-white">COMPETITIVIDAD</h3>
        </div>
        <hr / style="height:11vh; width:0.2vw; color: white; opacity:inherit">
        <div style="padding:10px">
            <h1 class="text-white text-center" style="font-size: 50px"><i class="fas fa-cogs"></i></h1>
            <h3 class="text-white">PRODUCTIVIDAD</h3>
        </div>
        <hr / style="height:11vh; width:0.2vw; color: white; opacity:inherit">
        <div style="padding:10px">
            <h1 class="text-white text-center" style="font-size: 50px"><i class="fas fa-chart-bar"></i></h1>
            <h3 class="text-white">CRECIMIENTO</h3>
        </div>
    </div>
    <h1 class="text-uppercase" style="margin-top: 35px; font-size: 30px; color: #FF6B00;">Nuestros</h1>
    <h1 class="text-uppercase" style="font-size: 30px; color:#00324d;">Servicios Tecnológicos</h1>
    <div class="d-flex justify-content-center" style="margin-top: 20px;">
        <div style="background-color: #00324d; padding:45px; width:324px">
            <h3 class="text-white text-center">LABORATORIO DE</h3>
            <h3 class="text-white text-center">MATERIALES</h3>
            <br />
            <hr class="text-white" style="opacity:inherit"/>

            <p class="text-white" style="font-size:16px"><i class="fas fa-angle-double-right"></i> Análisis de fallas</p>
            <p class="text-white" style="font-size:16px"><i class="fas fa-angle-double-right"></i> Análisis de superficies</p>
            <p class="text-white" style="font-size:16px"><i class="fas fa-angle-double-right"></i> Análisis metalográfico</p>
            <p class="text-white" style="font-size:16px"><i class="fas fa-angle-double-right"></i> Resistencia mecánica de materiales</p>

        </div>
        <div style="background-color:#0095ff; padding:45px; width:324px">
            <h3 class="text-center">LABORATORIO DE</h3>
            <h3 class="text-center">METROLOGÍA</h3>
            <br />
            <hr class="text-white" style="opacity:inherit"/>

            <p style="font-size:16px"><i class="fas fa-angle-double-right"></i> Calibración de balanzas</p>
            <p style="font-size:16px"><i class="fas fa-angle-double-right"></i> Mediciones industriales</p>

        </div>
        <div style="background-color: #00324d; padding:45px; width:324px">
            <h3 class="text-white text-center">AMBIENTE DE</h3>
            <h3 class="text-white text-center">TECNOLOGÍAS DE LA</h3>
            <h3 class="text-white text-center">INFORMACIÓN</h3>
            <hr class="text-white" style="opacity:inherit"/>

            <p class="text-white" style="font-size:16px"><i class="fas fa-angle-double-right"></i> Desarrollo de software a la medida</p>
            <p class="text-white" style="font-size:16px"><i class="fas fa-angle-double-right"></i> Impresión 3D</p>
            <p class="text-white" style="font-size:16px"><i class="fas fa-angle-double-right"></i> Certificación de redes de datos</p>
            <p class="text-white" style="font-size:16px"><i class="fas fa-angle-double-right"></i> Asesoría en licenciamiento de software</p>
            <p class="text-white" style="font-size:16px"><i class="fas fa-angle-double-right"></i> Revisión técnica en seguridad de la información</p>
            <p class="text-white" style="font-size:16px"><i class="fas fa-angle-double-right"></i> Hardening</p>

        </div>

        <div style="background-color:#0095ff; padding:45px; width:324px">
            <h3 class="text-center">AMBIENTE DE</h3>
            <h3 class="text-center">ELECTRÓNICA E</h3>
            <h3 class="text-center">INSTRUMENTACIÓN</h3>
            <hr class="text-white" style="opacity:inherit"/>

            <p style="font-size:16px"><i class="fas fa-angle-double-right"></i> Desarrollo y consultoría de sistemas inteligentes de visión artificial</p>
            <p style="font-size:16px"><i class="fas fa-angle-double-right"></i> Desarrollo de soluciones IoT</p>
            <p style="font-size:16px"><i class="fas fa-angle-double-right"></i> Diseño y fabricación de tarjetas electrónicas (PCB)</p>
            <p style="font-size:16px"><i class="fas fa-angle-double-right"></i> Parametrización de sensores electrónicos</p>
            <p style="font-size:16px"><i class="fas fa-angle-double-right"></i> Diseño y configuración de sistemas de control</p>

        </div>
    </div>
    <h1 class="text-uppercase" style="margin-top: 35px; font-size: 30px; color: #FF6B00;">Por qué adquirir</h1>
    <h1 class="text-uppercase" style="font-size: 30px; color:#00324d;">Nuestros servicios</h1>
    <asp:Image ID="nustrosServicios" class="d-block m-auto w-100" runat="server" style="vertical-align: middle;"  ImageUrl="~/Img/nuestrosServicios.png"/>

    <div class="d-flex justify-content-around align-items-center" style="margin-bottom: 45px;">
        <a id="listadoServicios" href="https://drive.google.com/file/d/1FuZj6GZLiMFldDvexnQ-o79rv0JPr6Hg/view" target="_blank" class="text-decoration-none align-items-center" style="width: 310px; height: 60px; border-radius: 50px; color: #000; background: #fff; font-size: 20px; box-shadow: 0px 1px 10px rgba(0,0,0,0.3); text-align: center;"><i class="fas fa-clipboard-list" style="margin-top: 12px;margin-left: 2px; font-size:30px; color: #57af00"></i> LISTADO DE SERVICIOS</a>
        <a id="portafolioServicios" href="https://drive.google.com/file/d/1n7HRY3Etq5KMiGSiWl2hA8edYxuNjztu/view" target="_blank" class="text-decoration-none align-items-center" style="width: 310px; height: 60px; border-radius: 50px; color: #000; background: #fff; font-size: 20px; box-shadow: 0px 1px 10px rgba(0,0,0,0.3); text-align: center;"><i class="fas fa-file-download" style="margin-top: 12px;margin-left: 2px; font-size:30px; color: #57af00"></i> PORTAFOLIO DE SERVICIOS</a>
    </div>
</asp:Content>
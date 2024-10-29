<%@ Page Title="Nosotros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-center align-items-center">
        <div id="mision" class="w-100" style="padding:20px">
            <h1 class="text-uppercase" style="margin-top: 35px; font-size: 30px; color: #FF6B00;">Misión</h1>
            <hr / style="width:108px; color: #FF6B00; opacity:inherit">
            <p style="font-size: 23px;" align="justify" class="text-decoration-none">Prestación de servicios especializados, técnicos y de laboratorios en temas relacionados a calidad, normalización, acreditación, metrología e investigación aplicada dirigido a los sectores productivos, educativos y a la comunidad en general.</p>
            <p style="font-size: 23px;" align="justify" class="text-decoration-none">Asegurar la prestación del servicio con estándares de calidad, oportunidad, pertinencia y alineados con los objetivos estratégicos del SENA.</p>
            <p style="font-size: 23px;" align="justify" class="text-decoration-none">Generar soluciones a problemáticas de mercado, articulación y de la formación profesional integral.</p>
        </div>

        <div class="w-100" style="padding:20px">
            <asp:Image ID="misionImage" class="d-block m-auto w-50" runat="server" ImageUrl="~/Img/mision.jpeg"/>
        </div>
    </div>
    <div class="d-flex justify-content-center align-items-center">
        <div class="w-100" style="padding:20px">
            <asp:Image ID="visionImage" class="d-block m-auto w-50" runat="server"  ImageUrl="~/Img/vision.jpeg"/>
        </div>

        <div id="vision" class="w-100" style="padding:20px">
            <h1 class="text-uppercase" style="margin-top: 35px; font-size: 30px; color: #FF6B00;">Visión</h1>
            <hr / style="width:100px; color: #FF6B00; opacity:inherit">
            <p style="font-size: 23px;" align="justify" class="text-decoration-none">La estrategia fortalecimiento de la oferta de servicios tecnológicos para las empresas del Ecosistema SENNOVA será reconocida en el año 2024 por mantener una Red Nacional de Servicios Tecnológicos SENA-SENNOVA, articulada y consolidada interna y externamente ofreciendo servicios especializados, técnicos y de laboratorio para el mejoramiento de la productividad, la gestión, la competitividad del sector productivo y el aporte en el desarrollo de habilidades para los aprendices con calidad y pertinencia en los temas asociados a nuestros servicios.</p>
        </div>
    </div>
    <h1 class="text-uppercase text-center mb-4" style="margin-top: 35px; font-size: 30px; color: #FF6B00;">Perfil del Personal</h1>

    <div class="d-flex justify-content-center flex-wrap" style="margin-bottom: 50px;">
        <div style="border: solid 1px #FF6B00; width: 35%; padding:20px">
            <asp:Image ID="personal1" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-1.png"/>
            <h1 class="text-center">Luis Carlos Gutiérrez Peña</h1>
            <h3 class="text-center">Responsable Servicios Tecnológicos</h3>
            <h3 class="text-center">Ingeniero Químico</h3>
            <h3 class="text-center mb-5">Especialista en estadistica.</h3>
        </div>
        <div  style="border: solid 1px #FF6B00; width: 35%; padding:20px">
            <asp:Image ID="personal2" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-2.png"/>
            <h1 class="text-center">Myriam Adrianna Mary Suárez Sierra</h1>
            <h3 class="text-center">Responsable Gestión Técnica Laboratorio de Materiales</h3>
            <h3 class="text-center">Ingeniera Metalúrgica</h3>
            <h3 class="text-center mb-5">Magister en ingeniería-materiales y procesos</h3>
        </div>
        <div  style="border: solid 1px #FF6B00; width: 35%; padding:20px">
            <asp:Image ID="personal3" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-3.png"/>
            <h1 class="text-center">Waldemar Medina Arévalo</h1>
            <h3 class="text-center">Personal Técnico Laboratorio de Materiales</h3>
            <h3 class="text-center">Ingeniero Metalúrgico</h3>
            <h3 class="text-center mb-5">Especialista en Ensayos no Destructivos y Magister en Ingeniería Materiales y Procesos.</h3>
        </div>
        <div  style="border: solid 1px #FF6B00; width: 35%; padding:20px">
            <asp:Image ID="personal4" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-4.png"/>
            <h1 class="text-center">Roberto Miguel Sánchez Moreno</h1>
            <h3 class="text-center">Responsable Gestión Técnica Laboratorio de Metrología</h3>
            <h3 class="text-center mb-5">Ingeniero Industrial</h3>
        </div>
        
        <div  style="border: solid 1px #FF6B00; width: 35%; padding:20px">
            <asp:Image ID="personal5" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-5.png"/>
            <h1 class="text-center">Gustavo Enrique Gamarra Correa</h1>
            <h3 class="text-center">Personal Técnico Laboratorio de Metrologia</h3>
            <h3 class="text-center mb-5">Tecnólogo en Aseguramiento Metrológico Industrial.</h3>
        </div>

        <div  style="border: solid 1px #FF6B00; width: 35%; padding:20px">
            <asp:Image ID="personal6" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-6.png"/>
            <h1 class="text-center">Edgar Eduardo Olarte Cruz</h1>
            <h3 class="text-center">Responsable Gestión Técnica  Ambiente de Tecnologias de  la Información</h3>
            <h3 class="text-center mb-5">Ingeniero de Sistemas</h3>
        </div>
        <div  style="border: solid 1px #FF6B00; width: 35%; padding:20px">
            <asp:Image ID="personal7" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-7.png"/>
            <h1 class="text-center">Jhon Wilson Corredor Araujo</h1>
            <h3 class="text-center">Personal Técnico Ambiente de Tecnologias de  la Información</h3>
            <h3 class="text-center mb-5">Tecnólogo en Desarrollo de Software.</h3>
        </div>
        <div  style="border: solid 1px #FF6B00; width: 35%; padding:20px">
            <asp:Image ID="personal8" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-8.png"/>
            <h1 class="text-center">Carlos Julio Pardo Herrera</h1>
            <h3 class="text-center">Responsable Gestión Técnica Ambiente Electrónica e Instrumentación</h3>
            <h3 class="text-center mb-5">Ingeniero Electrónico.</h3>
        </div>
        
        <div  style="border: solid 1px #FF6B00; width: 35%; padding:20px">
            <asp:Image ID="personal9" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-9.png"/>
            <h1 class="text-center">Jhon Gerardo Vera Fria</h1>
            <h3 class="text-center">Personal Técnico Ambiente Electrónica e Instrumentación</h3>
            <h3 class="text-center mb-5">Tecnólogo en Mantenimiento Electrónico e Industrial.</h3>
        </div>
        <div  style="border: solid 1px #FF6B00; width: 35%; padding:20px">
            <asp:Image ID="persona10" class="d-block m-auto" runat="server"  ImageUrl="~/Img/personal-10.png"/>
            <h1 class="text-center">Johana Andrea Pinzón Saavedra</h1>
            <h3 class="text-center">Responsable  de Calidad Servicios Técnologicos</h3>
            <h3 class="text-center mb-5">Ingeniera Industrial</h3>
        </div>
    </div>
</asp:Content>

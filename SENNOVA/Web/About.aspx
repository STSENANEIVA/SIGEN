<%@ Page Title="Nosotros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Web.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <style>
        .justify-content-evenly div{
            border-radius:15px!important;
            border: solid 2px #FF6B00!important;
        }
        .justify-content-center .perfil:hover{
            transform: rotate(-2deg);
            -webkit-transition: all 0.7s;
        }

        .justify-content-center .perfil{
            transition: all 0.7s ease-out;
            -webkit-transition: all 0.7s;
        }

        .justify-content-center .perfil div:hover{
            box-shadow: #ff6b0061 0px 50px 100px 5px;
        }

        .justify-content-center .perfil div{
            box-shadow: rgba(17, 12, 46, 0.15) 0px 50px 100px 5px;
        }

        #imparcialidad:hover{
            transform: rotate(-2deg);
            -webkit-transition: all 0.7s;
        }

        #imparcialidad{
            transition: all 0.7s ease-out;
            -webkit-transition: all 0.7s;
        }

        #objetivoCalidad:hover{
            transform: rotate(-2deg);
            -webkit-transition: all 0.7s;
        }

        #objetivoCalidad{
            transition: all 0.7s ease-out;
            -webkit-transition: all 0.7s;
        }

        #politicaCalidad:hover{
            transform: rotate(-2deg);
            -webkit-transition: all 0.7s;
        }

        #politicaCalidad{
            transition: all 0.7s ease-out;
            -webkit-transition: all 0.7s;
        }
    </style>
    <div class="d-flex justify-content-center align-items-center">
        <div id="mision" class="w-100" style="padding:20px">
            <h1 style="margin-top: 35px; font-size: 30px; color: #FF6B00;">Misión</h1>
            <hr style="width:108px; color: #FF6B00; opacity:inherit; height:3px " />
            <p style="font-size: 23px;" align="justify" class="text-decoration-none">Prestación de servicios especializados, técnicos y de laboratorios en temas relacionados a calidad, normalización, acreditación, metrología e investigación aplicada dirigido a los sectores productivos, educativos y a la comunidad en general.</p>
            <p style="font-size: 23px;" align="justify" class="text-decoration-none">Asegurar la prestación del servicio con estándares de calidad, oportunidad, pertinencia y alineados con los objetivos estratégicos del SENA.</p>
            <p style="font-size: 23px;" align="justify" class="text-decoration-none">Generar soluciones a problemáticas de mercado, articulación y de la formación profesional integral.</p>
        </div>

        <div class="w-100 text-center" style="padding:20px; color: #FF6B00;">
            <i class="fas fa-vials" style="font-size:200px"></i>
            <!-- <asp:Image ID="misionImage" class="d-block m-auto w-50" runat="server" ImageUrl="~/Img/mision.jpeg"/> -->
        </div>
    </div>
    <div class="d-flex justify-content-center align-items-center">
        <div class="w-100 text-center" style="padding:20px; color: #FF6B00;">
            <i class="far fa-eye" style="font-size:200px"></i>
            <!-- <asp:Image ID="visionImage" class="d-block m-auto w-50" runat="server"  ImageUrl="~/Img/vision.jpeg"/> -->
        </div>

        <div id="vision" class="w-100" style="padding:20px">
            <h1 style="margin-top: 35px; font-size: 30px; color: #FF6B00;">Visión</h1>
            <hr style="width:100px; color: #FF6B00; opacity:inherit; height:3px;" />
            <p style="font-size: 23px;" align="justify" class="text-decoration-none">La estrategia fortalecimiento de la oferta de servicios tecnológicos para las empresas del Ecosistema SENNOVA será reconocida en el año 2024 por mantener una Red Nacional de Servicios Tecnológicos SENA-SENNOVA, articulada y consolidada interna y externamente ofreciendo servicios especializados, técnicos y de laboratorio para el mejoramiento de la productividad, la gestión, la competitividad del sector productivo y el aporte en el desarrollo de habilidades para los aprendices con calidad y pertinencia en los temas asociados a nuestros servicios.</p>
        </div>
    </div>
    <h1 class="text-center mb-4" style="margin-top: 35px; font-size: 32px; color: #FF6B00;">Nuestro Equipo</h1>

    <div class="d-flex align-items-center justify-content-center">

        <div class="w-50 perfil" style="padding: 50px">
            <div style="padding:30px; border-radius:10px">
                <asp:Image ID="personal1" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-1.png" style="border-radius:50px" />
                <h1 class="text-center">Luis Carlos Gutiérrez Peña</h1>
                <hr style="color: #FF6B00; opacity:inherit; height: 3px; width:50%; margin-left:25% !important; margin-right:25% !important;" />
                <h3 class="text-center">Ingeniero Químico</h3>
                <h3 class="text-center mb-5">Especialista en estadistica.</h3>
            </div>
        </div>
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px" class="mb-5">Responsable Servicios Tecnológicos</h1>
            <p style="font-size:25px" align="justify">Profesional especializado con conocimientos y experiencia en montaje, verificación y realización de ensayos fisicoquímicos en múltiples matrices e implementación de sistemas de gestión en laboratorios de ensayo y calibración según criterios norma ISO/IEC 17025</p>
        </div>

    </div>

    <div class="d-flex align-items-center justify-content-center">
        
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px" class="mb-5">Responsable Gestión Técnica Laboratorio de Materiales</h1>
            <p style="font-size:25px" align="justify">Con conocimiento en ensayos de resistencia mecánica, tales como tracción, flexión, dureza, análisis metalográfico y cupones de corrosión en operaciones petroleras. Formación en NTC ISO/IEC 17025 - 2017.</p>
        </div>

        <div class="w-50 perfil" style="padding: 50px">
            <div style="padding:30px; border-radius:10px">
                <asp:Image ID="personal2" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-2.png"  style="border-radius:50px" />
                <h1 class="text-center">Myriam Adrianna Mary Suárez Sierra</h1>
                <hr style="color: #FF6B00; opacity:inherit; height: 3px; width:50%; margin-left:25% !important; margin-right:25% !important;" />
                <h3 class="text-center">Ingeniera Metalúrgica</h3>
                <h3 class="text-center mb-5">Magister en ingeniería-materiales y procesos</h3>
            </div>
        </div>
    </div>

    <div class="d-flex align-items-center justify-content-center">
        <div class="w-50 perfil" style="padding: 50px;">
            <div style="padding:30px; border-radius:10px">
                <asp:Image ID="personal3" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-3.png" style="border-radius:50px" />
                <h1 class="text-center">Waldemar Medina Arévalo</h1>
                <hr style="color: #FF6B00; opacity:inherit; height: 3px; width:50%; margin-left:25% !important; margin-right:25% !important;" />
                <h3 class="text-center">Ingeniero Metalúrgico</h3>
                <h3 class="text-center mb-5">Especialista en Ensayos no Destructivos y Magister en Ingeniería Materiales y Procesos.</h3>
            </div>
        </div>
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px" class="mb-5">Personal Técnico Laboratorio de Materiales</h1>
            <p style="font-size:25px" align="justify">Con experiencia en el área de Análisis de fallos, caracterización de materiales, pruebas electroquímicas y en ensayos no destructivos y mecánicos. Formación en la Norma ISO/IEC 17025 - 2017</p>
        </div>
    </div>

    <div class="d-flex align-items-center justify-content-center">
        
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px" class="mb-5">Responsable Gestión Técnica Laboratorio de Metrología</h1>
            <p style="font-size:25px" align="justify">Cuenta con más de 15 años de experiencia en el campo de la metrología, ha laborado en empresas del sector insdustrial, textil, alimentos y en laboratorios acreditados de metrología en magnitudes como: Masa, Volumen, Densidad y Temperatura. Ha implementado el sistema de aseguramiento metrológico en plantas de producción y el sistema de gestión de calidad en laboratorios de metrología.</p>
        </div>

        <div class="w-50 perfil" style="padding: 50px">
            <div style="padding:30px; border-radius:10px">
                <asp:Image ID="personal4" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-4.png"  style="border-radius:50px" />
                <h1 class="text-center">Roberto Miguel Sánchez Moreno</h1>
                <hr style="color: #FF6B00; opacity:inherit; height: 3px; width:50%; margin-left:25% !important; margin-right:25% !important;" />
                <h3 class="text-center">Ingeniero Industrial</h3>
            </div>
        </div>
    </div>

    <div class="d-flex align-items-center justify-content-center">
        <div class="w-50 perfil" style="padding: 50px;">
            <div style="padding:30px; border-radius:10px">
                <asp:Image ID="personal5" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-5.png" style="border-radius:50px" />
                <h1 class="text-center">Gustavo Enrique Gamarra Correa</h1>
                <hr style="color: #FF6B00; opacity:inherit; height: 3px; width:50%; margin-left:25% !important; margin-right:25% !important;" />
                <h3 class="text-center">Tecnólogo en Aseguramiento Metrológico Industrial</h3>
            </div>
        </div>
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px" class="mb-5">Personal Técnico Laboratorio de Metrología</h1>
            <p style="font-size:25px" align="justify">Con 9 años de experiencia en laboratorios de metrología acreditados bajo la norma ISO/IEC 17025 - 2017, aplicada en las magnitudes de Masas y Balanzas, Temperatura, Presión y volumen. Con conocimientos en el vocabulario internacional de metrología (vim), desempeñando el cargo de Metrólogo de campo en el sector industrial.</p>
        </div>
    </div>

    <div class="d-flex align-items-center justify-content-center">
        
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px" class="mb-5">Responsable Gestión Técnica  Ambiente de Tecnologias de  la Información</h1>
            <p style="font-size:25px" align="justify">Diplomado en arquitectura de redes Cliente - Servidor, Formación academica en Norma ISO 9001, gestión de redes de datos, seguridad informatica, certificación y seguridad en redes, con habilidades para adaptarse al cambio, trabajo en equipo e innovación.</p>
        </div>

        <div class="w-50 perfil" style="padding: 50px">
            <div style="padding:30px; border-radius:10px">
                <asp:Image ID="personal6" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-6.png"  style="border-radius:50px" />
                <h1 class="text-center">Edgar Eduardo Olarte Cruz</h1>
                <hr style="color: #FF6B00; opacity:inherit; height: 3px; width:50%; margin-left:25% !important; margin-right:25% !important;" />
                <h3 class="text-center">Ingeniero de Sistemas</h3>
            </div>
        </div>
    </div>

    <div class="d-flex align-items-center justify-content-center">
        <div class="w-50 perfil" style="padding: 50px;">
            <div style="padding:30px; border-radius:10px">
                <asp:Image ID="personal7" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-7.png" style="border-radius:50px" />
                <h1 class="text-center">Jhon Wilson Corredor Araujo</h1>
                <hr style="color: #FF6B00; opacity:inherit; height: 3px; width:50%; margin-left:25% !important; margin-right:25% !important;" />
                <h3 class="text-center">Tecnólogo en Desarrollo de Software</h3>
            </div>
        </div>
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px" class="mb-5">Personal Técnico Ambiente de Tecnologias de  la Información</h1>
            <p style="font-size:25px" align="justify">Con más de 7 años de experiencia en desarrollo de aplicaciones a la medida, especialista en análisis de requerimientos y base de datos, en constante capacitación para brindar soluciones más eficientes.</p>
        </div>
    </div>

    <div class="d-flex align-items-center justify-content-center">
        
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px" class="mb-5">Responsable Gestión Técnica Ambiente Electrónica e Instrumentación</h1>
            <p style="font-size:24px" align="justify">Con 7 años de experiencia en el análisis, diseño y desarrollo de sistemas inteligentes impulsados por visióm por computador (Inteligencia Artificial).</p>
            <p style="font-size:24px" align="justify">Con experiencia en la elaboración de soluciones tecnológicas según las necesidades de diseño, integración, actualización y administración de equipos y sistemas de control industrial, telecomunicaciones e instrumentación electrónica.</p>
        </div>

        <div class="w-50 perfil" style="padding: 50px">
            <div style="padding:30px; border-radius:10px">
                <asp:Image ID="personal8" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-8.png"  style="border-radius:50px" />
                <h1 class="text-center">Carlos Julio Pardo Herrera</h1>
                <hr style="color: #FF6B00; opacity:inherit; height: 3px; width:50%; margin-left:25% !important; margin-right:25% !important;" />
                <h3 class="text-center">Ingeniero Electrónico</h3>
            </div>
        </div>
    </div>

    <div class="d-flex align-items-center justify-content-center">
        <div class="w-50 perfil" style="padding: 50px;">
            <div style="padding:30px; border-radius:10px">
                <asp:Image ID="personal9" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-9.png" style="border-radius:50px" />
                <h1 class="text-center">Jhon Gerardo Vera Fria</h1>
                <hr style="color: #FF6B00; opacity:inherit; height: 3px; width:50%; margin-left:25% !important; margin-right:25% !important;" />
                <h3 class="text-center">Tecnólogo en Mantenimiento Electrónico e Industrial</h3>
            </div>
        </div>
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px" class="mb-5">Personal Técnico Ambiente Electrónica e Instrumentación</h1>
            <p style="font-size:25px" align="justify">Con conocimientos en IoT, programación en lenguaje C++, programación bajo plataforma Arduino y Qt Creator y en mantenimiento de equipos electrónicos industriales, con manejo en controladores lógicos programables (PLC) y Rasberry pi, con capacidad de realizar diagnóstico de fallas en distintivos equipos electrónicos industriales.</p>
        </div>
    </div>

    <div class="d-flex align-items-center justify-content-center">
        
        <div class="w-50" style="padding: 50px">
            <h1 style="font-size:32px" class="mb-5">Responsable  de Calidad Servicios Técnologicos</h1>
            <p style="font-size:25px" align="justify">Magister en Sistemas Integrados de Gestión, formación en ISO 9001:2015, ISO 45001:2018, NTC ISO/IEC 17025:2017, Auditor Interno y experiencia en la implementación, Mantenimiento y mejora de los Sistemas de Gestión.</p>
        </div>

        <div class="w-50 perfil" style="padding: 50px">
            <div style="padding:30px; border-radius:10px">
                <asp:Image ID="personal10" class="d-block m-auto mb-5" runat="server"  ImageUrl="~/Img/personal-10.png"  style="border-radius:50px" />
                <h1 class="text-center">Johana Andrea Pinzón Saavedra</h1>
                <hr style="color: #FF6B00; opacity:inherit; height: 3px; width:50%; margin-left:25% !important; margin-right:25% !important;" />
                <h3 class="text-center">Ingeniera Industrial</h3>
            </div>
        </div>
    </div>
    <div class="d-flex justify-content-around align-items-center mt-5" style="margin-bottom: 45px;">
        <a id="imparcialidad" href="https://1.bp.blogspot.com/-4o8g5W3Jn_c/XaYfp8TGnbI/AAAAAAAADP8/whWUWF-_l0Mo96FbPwx6U4hlPgOmwwqCQCLcBGAsYHQ/s1600/ECARD%2BIMPARCIALIDAD-01.jpg" target="_blank" class="text-decoration-none align-items-center" style="width: 420px; height: 60px; border-radius: 50px; color: #000; background: #fff; font-size: 20px; box-shadow: 0px 1px 10px rgba(0,0,0,0.3); text-align: center;"><i class="fas fa-clipboard-list" style="margin-top: 12px;margin-left: 2px; font-size:30px; color: #FF6B00"></i> IMPARCIALIDAD Y CONFIDENCIALIDAD</a>
        <a id="objetivoCalidad" href="https://drive.google.com/file/d/1gVBd73IusnI848W5s4o6KQXBTfUJ1TjA/view" target="_blank" class="text-decoration-none align-items-center" style="width: 310px; height: 60px; border-radius: 50px; color: #000; background: #fff; font-size: 20px; box-shadow: 0px 1px 10px rgba(0,0,0,0.3); text-align: center;"><i class="fas fa-file-download" style="margin-top: 12px;margin-left: 2px; font-size:30px; color: #FF6B00"></i> OBJETIVOS DE CALIDAD</a>
        <a id="politicaCalidad" href="https://drive.google.com/file/d/1SRGqYRQC0jyfD37-7dkolurxyO4IPPdM/view" target="_blank" class="text-decoration-none align-items-center" style="width: 310px; height: 60px; border-radius: 50px; color: #000; background: #fff; font-size: 20px; box-shadow: 0px 1px 10px rgba(0,0,0,0.3); text-align: center;"><i class="fas fa-file-download" style="margin-top: 12px;margin-left: 2px; font-size:30px; color: #FF6B00"></i> POLÍTICA DE CALIDAD</a>
    </div>
</asp:Content>

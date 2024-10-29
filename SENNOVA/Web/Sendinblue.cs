﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Sendinblue
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://api.sendinblue.com/v3/smtp/email"),
                Headers =
                {
                    { "Accept", "application/json" }, 
                    { "api-key", "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" },
                },
                Content = new StringContent("{\"sender\":{\"name\":\"Servicios Tecnológicos\",\"email\":\"jszambrano11@misena.edu.co\"},\"to\":[{\"name\":\"Servicios Tecnológicos\",\"email\":\"josepoza125@gmail.com\"}],\"subject\":\"Notificación vía página web\",\"htmlContent\":\"<!DOCTYPE html PUBLIC \\\"-//W3C//DTD XHTML 1.0 Strict//EN\\\" \\\"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\\\"><html xmlns=\\\"http://www.w3.org/1999/xhtml\\\" xmlns:v=\\\"urn:schemas-microsoft-com:vml\\\" xmlns:o=\\\"urn:schemas-microsoft-com:office:office\\\"><head><meta http-equiv=\\\"Content-Type\\\" content=\\\"text/html; charset=utf-8\\\"><meta http-equiv=\\\"X-UA-Compatible\\\" content=\\\"IE=edge\\\"><meta name=\\\"format-detection\\\" content=\\\"telephone=no\\\"><meta name=\\\"viewport\\\" content=\\\"width=device-width, initial-scale=1.0\\\"><title>Notificación vía pagina web</title><style type=\\\"text/css\\\" emogrify=\\\"no\\\">#outlook a { padding:0; } .ExternalClass { width:100%; } .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div { line-height: 100%; } table td { border-collapse: collapse; mso-line-height-rule: exactly; } .editable.image { font-size: 0 !important; line-height: 0 !important; } .nl2go_preheader { display: none !important; mso-hide:all !important; mso-line-height-rule: exactly; visibility: hidden !important; line-height: 0px !important; font-size: 0px !important; } body { width:100% !important; -webkit-text-size-adjust:100%; -ms-text-size-adjust:100%; margin:0; padding:0; } img { outline:none; text-decoration:none; -ms-interpolation-mode: bicubic; } a img { border:none; } table { border-collapse:collapse; mso-table-lspace:0pt; mso-table-rspace:0pt; } th { font-weight: normal; text-align: left; } *[class=\\\"gmail-fix\\\"] { display: none !important; } </style><style type=\\\"text/css\\\" emogrify=\\\"no\\\"> @media (max-width: 600px) { .gmx-killpill { content: ' \\\\03D1';} } </style><style type=\\\"text/css\\\" emogrify=\\\"no\\\">@media (max-width: 600px) { .gmx-killpill { content: ' \\\\03D1';} .r0-c { box-sizing: border-box !important; width: 100% !important } .r1-o { border-style: solid !important; width: 100% !important } .r2-i { background-color: #ffffff !important } .r3-c { box-sizing: border-box !important; text-align: center !important; valign: top !important; width: 320px !important } .r4-o { border-style: solid !important; margin: 0 auto 0 auto !important; width: 320px !important } .r5-i { padding-bottom: 0px !important; padding-left: 15px !important; padding-right: 15px !important; padding-top: 0px !important } .r6-c { box-sizing: border-box !important; display: block !important; valign: top !important; width: 100% !important } .r7-i { padding-left: 0px !important; padding-right: 0px !important } .r8-c { box-sizing: border-box !important; text-align: center !important; valign: top !important; width: 200px !important } .r9-o { background-size: auto !important; border-style: solid !important; margin: 0 auto 0 auto !important; width: 200px !important } .r10-i { padding-bottom: 15px !important; padding-top: 15px !important } .r11-c { box-sizing: border-box !important; text-align: center !important; width: 100% !important } .r12-o { border-style: solid !important; margin: 0 auto 0 auto !important; width: 100% !important } .r13-i { padding-bottom: 0px !important; padding-left: 0px !important; padding-right: 0px !important; padding-top: 0px !important } .r14-c { box-sizing: border-box !important; text-align: center !important; valign: top !important; width: 100% !important } .r15-o { border-style: solid !important; margin: 0 auto 0 auto !important; margin-bottom: 0px !important; margin-top: 0px !important; width: 100% !important } .r16-i { background-color: #ffffff !important; padding-bottom: 0px !important; padding-left: 0px !important; padding-right: 0px !important; padding-top: 15px !important } .r17-c { box-sizing: border-box !important; text-align: left !important; valign: top !important; width: 100% !important } .r18-o { border-style: solid !important; margin: 0 auto 0 0 !important; width: 100% !important } .r19-i { padding-top: 15px !important; text-align: center !important } .r20-i { background-color: #ffffff !important; padding-bottom: 20px !important; padding-left: 15px !important; padding-right: 15px !important; padding-top: 20px !important } .r21-i { padding-bottom: 15px !important; padding-top: 15px !important; text-align: left !important } .r22-i { padding-bottom: 30px !important; padding-top: 30px !important } .r23-i { padding-bottom: 15px !important; padding-top: 15px !important; text-align: center !important } body { -webkit-text-size-adjust: none } .nl2go-responsive-hide { display: none } .nl2go-body-table { min-width: unset !important } .mobshow { height: auto !important; overflow: visible !important; max-height: unset !important; visibility: visible !important; border: none !important } .resp-table { display: inline-table !important } .magic-resp { display: table-cell !important } } </style><!--[if !mso]><!--><style type=\\\"text/css\\\" emogrify=\\\"no\\\">@import url(\\\"https://fonts.googleapis.com/css2?family=Montserrat\\\"); </style><!--<![endif]--><style type=\\\"text/css\\\">p, h1, h2, h3, h4, ol, ul { margin: 0; } a, a:link { color: #0092ff; text-decoration: underline } .nl2go-default-textstyle { color: #3b3f44; font-family: arial,helvetica,sans-serif; font-size: 16px; line-height: 1.5 } .default-button { border-radius: 4px; color: #ffffff; font-family: arial,helvetica,sans-serif; font-size: 16px; font-style: normal; font-weight: normal; line-height: 1.15; text-decoration: none; width: 50% } .default-heading1 { color: #1F2D3D; font-family: arial,helvetica,sans-serif; font-size: 36px } .default-heading2 { color: #1F2D3D; font-family: arial,helvetica,sans-serif; font-size: 32px } .default-heading3 { color: #1F2D3D; font-family: arial,helvetica,sans-serif; font-size: 24px } .default-heading4 { color: #1F2D3D; font-family: arial,helvetica,sans-serif; font-size: 18px } a[x-apple-data-detectors] { color: inherit !important; text-decoration: inherit !important; font-size: inherit !important; font-family: inherit !important; font-weight: inherit !important; line-height: inherit !important; } .no-show-for-you { border: none; display: none; float: none; font-size: 0; height: 0; line-height: 0; max-height: 0; mso-hide: all; overflow: hidden; table-layout: fixed; visibility: hidden; width: 0; } </style><!--[if mso]><xml> <o:OfficeDocumentSettings> <o:AllowPNG/> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml><![endif]--></head><body text=\\\"#3b3f44\\\" link=\\\"#0092ff\\\" yahoo=\\\"fix\\\" style=\\\"\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" class=\\\"nl2go-body-table\\\" width=\\\"100%\\\" style=\\\"width: 100%;\\\"><tr><td align=\\\"\\\" class=\\\"r0-c\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r1-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><!-- --><tr><td valign=\\\"top\\\" class=\\\"r2-i\\\" style=\\\"background-color: #ffffff;\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><td class=\\\"r3-c\\\" align=\\\"center\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"600\\\" class=\\\"r4-o\\\" style=\\\"table-layout: fixed; width: 600px;\\\"><!-- --><tr><td class=\\\"r5-i\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><th width=\\\"100%\\\" valign=\\\"top\\\" class=\\\"r6-c\\\" style=\\\"font-weight: normal;\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r1-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><!-- --><tr><td class=\\\"nl2go-responsive-hide\\\" width=\\\"15\\\" style=\\\"font-size: 0px; line-height: 1px;\\\">­ </td> <td valign=\\\"top\\\" class=\\\"r7-i\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><td class=\\\"r8-c\\\" align=\\\"center\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"248\\\" class=\\\"r9-o\\\" style=\\\"table-layout: fixed; width: 248px;\\\"><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"15\\\" style=\\\"font-size: 15px; line-height: 15px;\\\">­</td> </tr><tr><td class=\\\"r10-i\\\" style=\\\"font-size: 0px; line-height: 0px;\\\"> <img src=\\\"https://img.mailinblue.com/4926138/images/content_library/original/62cedad284c01503787c43f8.png\\\" width=\\\"248\\\" border=\\\"0\\\" class=\\\"\\\" style=\\\"display: block; width: 100%;\\\"></td> </tr><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"15\\\" style=\\\"font-size: 15px; line-height: 15px;\\\">­</td> </tr></table></td> </tr></table></td> <td class=\\\"nl2go-responsive-hide\\\" width=\\\"15\\\" style=\\\"font-size: 0px; line-height: 1px;\\\">­ </td> </tr></table></th> </tr></table></td> </tr></table></td> </tr></table></td> </tr></table></td> </tr><tr><td align=\\\"\\\" class=\\\"r0-c\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r1-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><!-- --><tr><td valign=\\\"top\\\" class=\\\"r2-i\\\" style=\\\"background-color: #ffffff;\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><td class=\\\"r3-c\\\" align=\\\"center\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"600\\\" class=\\\"r4-o\\\" style=\\\"table-layout: fixed; width: 600px;\\\"><!-- --><tr><td class=\\\"r5-i\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><th width=\\\"100%\\\" valign=\\\"top\\\" class=\\\"r6-c\\\" style=\\\"font-weight: normal;\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r1-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><!-- --><tr><td class=\\\"nl2go-responsive-hide\\\" width=\\\"15\\\" style=\\\"font-size: 0px; line-height: 1px;\\\">­ </td> <td valign=\\\"top\\\" class=\\\"r7-i\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><td class=\\\"r11-c\\\" align=\\\"center\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"570\\\" class=\\\"r12-o\\\" style=\\\"table-layout: fixed;\\\"><tr><td class=\\\"r13-i\\\" style=\\\"height: 3px;\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><td><table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" valign=\\\"\\\" class=\\\"r13-i\\\" height=\\\"3\\\" style=\\\"border-top-style: solid; background-clip: border-box; border-top-color: #ff6b00; border-top-width: 3px; font-size: 3px; line-height: 3px;\\\"><tr><td height=\\\"0\\\" style=\\\"font-size: 0px; line-height: 0px;\\\">­</td> </tr></table></td> </tr></table></td> </tr></table></td> </tr></table></td> <td class=\\\"nl2go-responsive-hide\\\" width=\\\"15\\\" style=\\\"font-size: 0px; line-height: 1px;\\\">­ </td> </tr></table></th> </tr></table></td> </tr></table></td> </tr></table></td> </tr></table></td> </tr><tr><td align=\\\"center\\\" class=\\\"r3-c\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"600\\\" class=\\\"r4-o\\\" style=\\\"table-layout: fixed; width: 600px;\\\"><tr><td valign=\\\"top\\\" class=\\\"\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><td class=\\\"r14-c\\\" align=\\\"center\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r15-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><!-- --><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"15\\\" style=\\\"font-size: 15px; line-height: 15px; background-color: #ffffff;\\\">­</td> </tr><tr><td class=\\\"r16-i\\\" style=\\\"background-color: #ffffff;\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><th width=\\\"100%\\\" valign=\\\"top\\\" class=\\\"r6-c\\\" style=\\\"font-weight: normal;\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r1-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><!-- --><tr><td class=\\\"nl2go-responsive-hide\\\" width=\\\"15\\\" style=\\\"font-size: 0px; line-height: 1px;\\\">­ </td> <td valign=\\\"top\\\" class=\\\"r7-i\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><td class=\\\"r17-c\\\" align=\\\"left\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r18-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"15\\\" style=\\\"font-size: 15px; line-height: 15px;\\\">­</td> </tr><tr><td align=\\\"center\\\" valign=\\\"top\\\" class=\\\"r19-i nl2go-default-textstyle\\\" style=\\\"color: #3b3f44; font-family: arial,helvetica,sans-serif; font-size: 16px; line-height: 1.5; text-align: center;\\\"> <div><h1 class=\\\"default-heading1\\\" style=\\\"margin: 0; color: #1F2D3D; font-family: arial,helvetica,sans-serif; font-size: 36px;\\\">Notificación de contacto</h1></div> </td> </tr></table></td> </tr></table></td> <td class=\\\"nl2go-responsive-hide\\\" width=\\\"15\\\" style=\\\"font-size: 0px; line-height: 1px;\\\">­ </td> </tr></table></th> </tr></table></td> </tr></table></td> </tr><tr><td class=\\\"r14-c\\\" align=\\\"center\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r12-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><!-- --><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"20\\\" style=\\\"font-size: 20px; line-height: 20px; background-color: #ffffff;\\\">­</td> </tr><tr><td class=\\\"r20-i\\\" style=\\\"background-color: #ffffff;\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><th width=\\\"100%\\\" valign=\\\"top\\\" class=\\\"r6-c\\\" style=\\\"font-weight: normal;\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r1-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><!-- --><tr><td class=\\\"nl2go-responsive-hide\\\" width=\\\"15\\\" style=\\\"font-size: 0px; line-height: 1px;\\\">­ </td> <td valign=\\\"top\\\" class=\\\"r7-i\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><td class=\\\"r17-c\\\" align=\\\"left\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r18-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"15\\\" style=\\\"font-size: 15px; line-height: 15px;\\\">­</td> </tr><tr><td align=\\\"left\\\" valign=\\\"top\\\" class=\\\"r21-i nl2go-default-textstyle\\\" style=\\\"color: #3b3f44; font-family: arial,helvetica,sans-serif; font-size: 16px; line-height: 1.5; text-align: left;\\\"> <div><p style=\\\"margin: 0;\\\">Número de Identificación: "+ args[2] + " </p><p style=\\\"margin: 0;\\\">Nombres y Apellidos: " + args[0] + " " +  args[1] + " </p><p style=\\\"margin: 0;\\\">Número de Télefono: " + args[3] + " </p><p style=\\\"margin: 0;\\\">Correo Electronico: " + args[4] +" </p><p style=\\\"margin: 0;\\\">Mensaje: " + args[5] + " </p></div> </td> </tr><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"15\\\" style=\\\"font-size: 15px; line-height: 15px;\\\">­</td> </tr></table></td> </tr><tr><td class=\\\"r11-c\\\" align=\\\"center\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"570\\\" class=\\\"r12-o\\\" style=\\\"table-layout: fixed;\\\"><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"30\\\" style=\\\"font-size: 30px; line-height: 30px;\\\">­</td> </tr><tr><td class=\\\"r22-i\\\" style=\\\"height: 3px;\\\"> <table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\"><tr><td><table width=\\\"100%\\\" cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" valign=\\\"\\\" class=\\\"r22-i\\\" height=\\\"3\\\" style=\\\"border-top-style: solid; background-clip: border-box; border-top-color: #ff6b00; border-top-width: 3px; font-size: 3px; line-height: 3px;\\\"><tr><td height=\\\"0\\\" style=\\\"font-size: 0px; line-height: 0px;\\\">­</td> </tr></table></td> </tr></table></td> </tr><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"30\\\" style=\\\"font-size: 30px; line-height: 30px;\\\">­</td> </tr></table></td> </tr><tr><td class=\\\"r14-c\\\" align=\\\"center\\\"> <table cellspacing=\\\"0\\\" cellpadding=\\\"0\\\" border=\\\"0\\\" role=\\\"presentation\\\" width=\\\"100%\\\" class=\\\"r12-o\\\" style=\\\"table-layout: fixed; width: 100%;\\\"><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"15\\\" style=\\\"font-size: 15px; line-height: 15px;\\\">­</td> </tr><tr><td align=\\\"center\\\" valign=\\\"top\\\" class=\\\"r23-i nl2go-default-textstyle\\\" style=\\\"color: #3b3f44; font-family: arial,helvetica,sans-serif; font-size: 16px; line-height: 1.5; text-align: center;\\\"> <div><p style=\\\"margin: 0;\\\"><strong>Servicio Nacional de Aprendizaje SENA</strong></p><p style=\\\"margin: 0;\\\"><strong>Centro de la Industria, la Empresa y los Servicios</strong></p><p style=\\\"margin: 0;\\\"><strong>Cra 9 # 68 50 - Sede Industria</strong></p><p style=\\\"margin: 0;\\\"><strong>© SENA 2022 | Todos los derechos reservados</strong></p></div> </td> </tr><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"15\\\" style=\\\"font-size: 15px; line-height: 15px;\\\">­</td> </tr></table></td> </tr></table></td> <td class=\\\"nl2go-responsive-hide\\\" width=\\\"15\\\" style=\\\"font-size: 0px; line-height: 1px;\\\">­ </td> </tr></table></th> </tr></table></td> </tr><tr class=\\\"nl2go-responsive-hide\\\"><td height=\\\"20\\\" style=\\\"font-size: 20px; line-height: 20px; background-color: #ffffff;\\\">­</td> </tr></table></td> </tr></table></td> </tr></table></td> </tr></table></body></html>\"}")
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/json")
                    },
                }
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        }
    }
}

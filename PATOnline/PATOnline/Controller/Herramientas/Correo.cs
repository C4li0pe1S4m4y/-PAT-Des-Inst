using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace PATOnline.Controller.Herramientas
{
    public class Correo
    {
        public void CorreoResetPassword(string receptor, string verificador)
        {
            var fromAddress = new MailAddress("emisor.tarea@gmail.com", "Bienvenido");
            var toAddress = new MailAddress(receptor, "To Name");
            const string fromPassword = "comunicacionesa";
            const string subject = "PATOnline";
            string body = String.Format("BIENVENIDO al sistema PAT, " + 
                "para activar su usuario dentro del sistema es necesario que usted " +
                "ingrese al siguiente link e ingrese el correo electrónico que le proporciono " +
                "a la CDAG (Confederación Deportiva Autonóma de Guatemala) y también es necesario " +
                "que ingrese el siguiente código: {0} \n" +
                "LINK: http://143.208.180.250:21887/patonline/ConfirmarUsuario", verificador);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
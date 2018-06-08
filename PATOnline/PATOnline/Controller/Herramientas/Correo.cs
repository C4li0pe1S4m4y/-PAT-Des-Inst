using MySql.Data.MySqlClient;
using System;
using System.Net;
using System.Net.Mail;

namespace PATOnline.Controller.Herramientas
{
    public class Correo
    {
        public string email;
        public void CorreoResetPassword(string receptor, string verificador)
        {
            var fromAddress = new MailAddress("emisor.tarea@gmail.com", "Bienvenido al Sistema PATOnline");
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

        public void CorreoBienvenida(string receptor)
        {
            var mysql = new DBConnection.ConexionMysql();
            mysql.AbrirConexion();
            string query = String.Format("SELECT correo_electronico FROM seg_usuario WHERE username = '{0}'", receptor);
            MySqlCommand cmd = new MySqlCommand(query, mysql.conectar);
            MySqlDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read())
                {
                    email = reader["correo_electronico"].ToString();
                }
            }
            mysql.CerrarConexion();

            var fromAddress = new MailAddress("emisor.tarea@gmail.com", "Sistema PATOnline");
            var toAddress = new MailAddress(email, "To Name");
            const string fromPassword = "comunicacionesa";
            const string subject = "Bienvenido a PATOnline";
            string body = String.Format("BIENVENIDO al sistema PAT, " +
                "su cuenta fue activada exitosamente, por favor ingresar al siguiente link " +
                "para hacer uso del sistema \n" +
                "LINK: http://143.208.180.250:21887/patonline/(S(c2snoci5f3lc0wnktz1v2teg))/Login");

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
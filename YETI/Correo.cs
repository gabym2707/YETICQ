using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace YETI
{
    public static class Correo
    {
        static MailMessage mail = new MailMessage();//587 465
        static SmtpClient SmtpServer = new SmtpClient("secure.emailsrvr.com", 587);
        static MailAddress mailAddress = new MailAddress("soporte@cargoquin.com", "Evaluaciones TI", Encoding.UTF8);
        static NetworkCredential netCredentials = new NetworkCredential("gabriela.molina@cargoquin.com", "xrlNBHUQPy90");

        public static void enviarCorreo(string correo, string email, string archivo)
        {
            mail.To.Clear();
            SmtpServer.Credentials = netCredentials;
            SmtpServer.EnableSsl = true;
            mail.From = mailAddress;

            mail.To.Add(email);
            mail.Subject = "Evaluacion Mensual.";
            mail.IsBodyHtml = Regex.IsMatch(correo, @"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");
            mail.Attachments.Add(new Attachment(archivo));
            mail.Body = correo;
            SmtpServer.Send(mail);
            mail.To.Clear();
        }
        public static void enviarCorreoDiploma(string correo, string destino)
        {
            mail.To.Clear();
            SmtpServer.Credentials = netCredentials;
            SmtpServer.EnableSsl = true;
            mail.From = mailAddress;

            mail.To.Add(destino);
            mail.Subject = "Evaluacion Mensual.";
            mail.IsBodyHtml = Regex.IsMatch(correo, @"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");
            mail.Body = correo;
            SmtpServer.Send(mail);
            mail.To.Clear();
        }
    }
}
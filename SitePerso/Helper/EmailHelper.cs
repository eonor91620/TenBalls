using System;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Text;

namespace SitePerso.Helper
{
    public class EmailHelpers
    {
        public static void SendMail(string sujet, string message)
        {

            new SmtpClient
            {
                Host = "Smtp.Gmail.com",
                Port = 587,
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("thomasm282@Gmail.com", "mathi2816")
            }.Send(new MailMessage { From = new MailAddress("thomasm282@Gmail.com", "Ten Balls"),
                To = { "t.brethiot@free.fr" },
                Subject = sujet,
                Body = message,
                BodyEncoding = Encoding.UTF8
            });

        }
    }
}
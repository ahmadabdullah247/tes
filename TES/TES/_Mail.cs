using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace TES
{
    public class _Mail
    {
        private string Sender = "info.thesisevaluationsystem@gmail.com";
        private string Password = "asadhaq123";
        public string Reciver { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }

        public _Mail()
        {
            Reciver = "";
            Subject = "";
            Message = "";
        }

        public bool Send()
        {
            try
            {
                //Generate Email
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(this.Sender);
                msg.To.Add(this.Reciver);
                msg.Subject = this.Subject;

                StringBuilder stremail = new StringBuilder();
                stremail.Append(this.Message);
                msg.Body = stremail.ToString();
                msg.IsBodyHtml = true;

                SmtpClient smt = new SmtpClient("smtp.gmail.com");
                smt.Port = 587;
                smt.Credentials = new NetworkCredential(this.Sender, this.Password);
                smt.EnableSsl = true;
                smt.Send(msg);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return true;
        }
    }
}
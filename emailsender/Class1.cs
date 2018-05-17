using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;


namespace emailsender
{
    class Sending
    {
        private string server;
        private string port;
        private string user;
        private string password;
        private string sender;
        private string receiver;
        private string subject;
        private string body;
        public Sending()
        {
          
        }

        public void info(string sv,string pt,string un, string pw,string se,string re,string sub,string bd,string att)
        {
            server = sv;
            port = pt;
            user = un;
            password = pw;
            sender = se;
            receiver = re;
            string [] receivers;
            subject = sub;
            body = bd;        
            receivers = re.Split(',');
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(sender);
            foreach (string rec in receivers)
            {
                msg.To.Add(new MailAddress(rec));
            }
            msg.Subject = sub.Trim().ToString();
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = body.Trim().ToString();
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.Priority = MailPriority.High;
            if (att.Length > 0)
            {
                msg.Attachments.Add(new Attachment(att, MediaTypeNames.Application.Octet));
            }
            SmtpClient client = new SmtpClient(server, int.Parse(port));
            client.Credentials = new System.Net.NetworkCredential(user, password);
            client.EnableSsl = true;
            client.Send(msg);


        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace emailsender
{
    class Saving
    {
        private string sender;
        private string receiver;
        public string subject;
        private string body;

        public Saving()
        {

        }

        public string Saving1(string se,string re,string sub,string bd)
        {
            sender = se;
            receiver = re;
            subject = sub;
            body = bd;
            string draftcontent="";      
            draftcontent = "From:" + sender + "\r\n\r\nTo:" + receiver + "\r\n\r\nSubject:\n" + sub + "\r\n\r\nBody:\r\n\r\n" + body;
            return draftcontent;

        }
    }
}


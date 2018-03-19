using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace WpfTestMailSender
{
    public class EmailSendServiceClass
    {
        private string _senderEmail;
        private List<string> _emailList;
        private string _password;
        private string _smtpServer;
        private int _smtpPort;
        private string _subject;
        private string _body;

        public EmailSendServiceClass(string senderEmail, List<string> emailList, string smtpServer, int smtpPort, string password)
        {
            _senderEmail = senderEmail;
            _emailList = emailList;
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _password = password;
        }

        public void SendEmail(string subject, string body)
        {
            _subject = subject;
            _body = body;

            foreach (string mail in _emailList)
            {
                using (MailMessage mm = new MailMessage(_senderEmail, mail))
                {
                    mm.Subject = _subject; 
                    mm.Body = _body;      
                    mm.IsBodyHtml = false;  
                    
                    using (SmtpClient sc = new SmtpClient(_smtpServer, _smtpPort))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential(_senderEmail, _password);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                           new SendErrorWindow("Невозможно отправить письмо " + ex.ToString()).Show();
                        }
                    }
                }
            }
            SendEndWindow sew = new SendEndWindow();
            sew.Show();
        }
    }
}

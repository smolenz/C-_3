using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MailSender
{
    public class EmailSendServiceClass
    {
        #region vars
        private string strLogin; // email, c которого будет рассылаться почта
        private string strPassword; // пароль к email, с которого будет рассылаться почта
        private string strSmtp = "smtp.yandex.ru"; // smtp - server
        private int iSmtpPort = 25; // порт для smtp-server
        private string strBody; // текст письма для отправки
        private string strSubject; // тема письма для отправки

        public string Body
        {
            get { return strBody; }
            set { strBody = value; }
        }
        public string Subject
        {
            get { return strSubject; }
            set { strSubject = value; }
        }


        #endregion

        public EmailSendServiceClass(string sLogin, string sPassword, string subject, string body)
        {
            strLogin = sLogin;
            strPassword = sPassword;
            strSubject = subject;
            strBody = body;
        }


        public void SendMail(string mail,string name) // Отправка email конкретному адресату
        { 
            using (MailMessage mm = new MailMessage(strLogin, mail))
            {
                mm.Subject = strSubject;
                mm.Body = strBody;
                mm.IsBodyHtml = false;
                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort)
                {
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(strLogin, strPassword)
                };
                try
                {
                    sc.Send(mm);

                }
                catch (Exception ex)
                {
                    new Exception("Невозможно отправить письмо " + ex.ToString());
                }
            }
        }

        public void SendMails(List<Email> emails)
        {
            foreach (var email in emails)
            {
                SendMail(email.Address, email.Name);
            }
        }

    }

}


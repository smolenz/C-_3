using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EmailSendDerviceDLL
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
        #endregion
        public EmailSendServiceClass(string sLogin, string sPassword, string subject, string body)
        {
            strLogin = sLogin;
            strPassword = sPassword;
            strSubject = subject;
            strBody = body;
        }


        public void SendMail(object Emails) // Отправка email конкретному адресату
        {
            Emails= (Emails)objEmails2;
            string mail = objEmails2.Email;
            string name = objEmails2.Name;

            using (MailMessage mm = new MailMessage(strLogin, mail))
            {
                mm.Subject = strSubject;
                mm.Body = strBody;
                mm.IsBodyHtml = false;
                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort);
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(strLogin, strPassword);
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

        public void SendMails(IQueryable<Emails> emails)
        {
            foreach (Emails email in emails)
            {
                Thread thread = new Thread(new ParameterizedThreadStart(SendMail));
                thread.Start(email);
            }
        }
    }

}
}

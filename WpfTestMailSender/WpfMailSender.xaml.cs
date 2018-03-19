using System.Collections.Generic;
using System.Windows;

namespace WpfTestMailSender
{
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            List<string> listStrMails = new List<string> { "testEmail@gmail.com", "email@yandex.ru" };  // Список email'ов //кому мы отправляем письмо
            EmailSendServiceClass essc = new EmailSendServiceClass("test@test.com", listStrMails, VariableClass.smtpServer, VariableClass.smtpPort, passwordBox.Password);
            essc.SendEmail(subjectTextBox.Text, bodyTextBox.Text);
        }
    }
}

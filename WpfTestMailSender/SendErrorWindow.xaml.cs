using System.Windows;

namespace WpfTestMailSender
{
    public partial class SendErrorWindow : Window
    {
        public SendErrorWindow(string message)
        {
            InitializeComponent();
            lSendError.Content = message;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

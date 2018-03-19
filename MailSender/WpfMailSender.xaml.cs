using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ListViewItemScheduler;
using Microsoft.Reporting.WinForms;
using MailSender.MailsAndSendersDataSetTableAdapters;

namespace MailSender
{ 
    public partial class WpfMailSender : Window
    {
        string strLogin;
        string strPassword;

        public WpfMailSender()
        {
            InitializeComponent();

            senderComboToolBar.ComboItems= VariablesClass.Senders;
            smtpComboToolBar.ComboItems = VariablesClass.Smtp;

            DBClass db = new DBClass();
            dgEmails.ItemsSource = db.Emails;
        }

        private void btnSendAtOnce_Click(object sender, RoutedEventArgs e)
        {
            strLogin = senderComboToolBar.Key;
            strPassword = senderComboToolBar.Value;

            if (string.IsNullOrEmpty(strLogin) || string.IsNullOrEmpty(strPassword))
            {
                MessageBox.Show("Выберите отправителя");
                return;
            }

            string text = new TextRange(rtbBody.Document.ContentStart, rtbBody.Document.ContentEnd).Text;

            if (!String.IsNullOrWhiteSpace(text))
            {
                EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin, strPassword,"Смоленцев Сергей", text);
                emailSender.SendMails(dgEmails.ItemsSource as List<Email>);
                MessageBox.Show("Письма разосланы");
            }
            else
            {
                tcMain.SelectedIndex = 2;
                MessageBox.Show("Письмо не заполнено");
            } 

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            strLogin = senderComboToolBar.Key;
            strPassword = senderComboToolBar.Value;

            SchedulerClass sc = new SchedulerClass();
  
            Dictionary<DateTime, string> dic = new Dictionary<DateTime, string>();

            foreach(ListViewItemSchedulerControl item in emailListView.Items)
            {
                dic.Add(item.SchedulerDateTime, item.SchedulerMessage);
            }

                EmailSendServiceClass emailSender = new EmailSendServiceClass(strLogin,
                strPassword, "Смоленцев Сергей", "");
                sc.DatesEmailTexts = dic;
                sc.SendEmails(emailSender, (List<Email>)dgEmails.ItemsSource);
                MessageBox.Show("Письма разосланы");
        }

        public class EmailParameters
        {
            private string _email;
            private string _name;
            public EmailParameters(string email, string name)
            {
                _email = email;
                _name = name;
            }
        }

        private void btnSch_Click(object sender, RoutedEventArgs e)
        {
            tcMain.SelectedIndex = 2;
        }

        private void tscTabSwitcher_btnNextClick(object sender, RoutedEventArgs e)
        {
            tcMain.SelectedIndex = 1;
        }

        private void tscTabSwitcher_1_btnPreviosClick(object sender, RoutedEventArgs e)
        {
            tcMain.SelectedIndex = 0;
        }

        private void tscTabSwitcher_1_btnNextClick(object sender, RoutedEventArgs e)
        {
            tcMain.SelectedIndex = 2;
        }

        private void tscTabSwitcher_3_btnPreviosClick(object sender, RoutedEventArgs e)
        {
            tcMain.SelectedIndex = 2;
        }

        private void tscTabSwitcher_2_btnNextClick(object sender, RoutedEventArgs e)
        {
            tcMain.SelectedIndex = 3;
        }

        private void tscTabSwitcher_2_btnPreviosClick(object sender, RoutedEventArgs e)
        {
            tcMain.SelectedIndex = 1;
        }

        private void senderComboToolBar_btnAddClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sender Add");
        }

        private void senderComboToolBar_btnDeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sender Delete");
        }

        private void senderComboToolBar_btnEditClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sender Edit");
        }

        private void smtpComboToolBar_btnAddClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Smtp Add");
        }

        private void smtpComboToolBar_btnDeleteClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Smtp Delete");
        }

        private void smtpComboToolBar_btnEditClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Smtp Edit");
        }

        private void addSend_Click(object sender, RoutedEventArgs e) => emailListView.Items.Add(new ListViewItemSchedulerControl());

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            MailsAndSendersDataSet dataset = new MailsAndSendersDataSet();
            dataset.BeginInit();
            reportDataSource.Name = "DataSet1";
            reportDataSource.Value = dataset.Emails;
            ReportViewer.LocalReport.DataSources.Add(reportDataSource);
            ReportViewer.LocalReport.ReportPath = "../../Report.rdlc";
            dataset.EndInit();
            EmailsTableAdapter tracksTableAdapter = new EmailsTableAdapter { ClearBeforeFill = true };
            tracksTableAdapter.Fill(dataset.Emails);
            ReportViewer.RefreshReport();
        }
    }
}

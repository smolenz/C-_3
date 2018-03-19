using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace ListViewItemScheduler
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class ListViewItemSchedulerControl : UserControl
    {
        string _message;

        public String SchedulerMessage => _message;


        public DateTime SchedulerDateTime => DateTime.Parse(dateTimeTextBox.Text);



        public ListViewItemSchedulerControl()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы действительно хотите удалить элемент из планировщика?","Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question)==MessageBoxResult.Yes)
            (Parent as ListView).Items.Remove(this);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageWindow mw = new MessageWindow(_message);
            mw.ShowDialog();
            _message = mw.Message;
        }
    }
}

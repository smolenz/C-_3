using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ComboToolBar
{
    public partial class ComboToolBarControl : UserControl
    {
        public event RoutedEventHandler btnAddClick;
        public event RoutedEventHandler btnEditClick;
        public event RoutedEventHandler btnDeleteClick;

        public ComboToolBarControl()
        {
            InitializeComponent();
            cbSelect.ItemsSource = new Dictionary<string, string>() { { "", "" } };
        }

        public string LabelText
        {
            get { return lSender.Content.ToString(); }
            set
            {
                lSender.Content = value;
            }
        }

        public string Key
        {
            get { return cbSelect.Text; }
        }

        public string Value
        {
            get { return cbSelect.SelectedValue.ToString(); }
        }

        public IEnumerable ComboItems
        {
            set
            {
                cbSelect.ItemsSource = value;
                cbSelect.SelectedIndex = 0;
               
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            btnAddClick?.Invoke(sender, e);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnEditClick?.Invoke(sender, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            btnDeleteClick?.Invoke(sender, e);
        }
    }
}

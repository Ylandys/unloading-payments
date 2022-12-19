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
using System.Windows.Shapes;

namespace Registr
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        PaymentDB_PPEntities database = new PaymentDB_PPEntities();
        public WorkWindow()
        {
            InitializeComponent();
            TablePayments.ItemsSource = database.Payments.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void refreshdatagrid()
        {
            TablePayments.ItemsSource = database.Payments.ToList();
            TablePayments.Items.Refresh();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

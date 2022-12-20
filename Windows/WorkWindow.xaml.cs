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
//using
using OfficeOpenXml;
using System.IO;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        private void refreshdatagrid()
        {
            TablePayments.ItemsSource = database.Payments.ToList();
            TablePayments.Items.Refresh();
        }

        private void Update_Table_Click(object sender, object e)
        {
            refreshdatagrid();
        }

        private void Receive_Payments_Click(object sender, RoutedEventArgs e)
        {
            TablePayments.ItemsSource = database.Payments.ToList();
            DateTime? selectedDate = dp.SelectedDate;
            if (selectedDate.HasValue)
            {
                string formatted = selectedDate.Value.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                //Фильтр календарь
            TablePayments.ItemsSource = database.Payments.Where(d => formatted == d.DateOfAdmission.ToString()).ToList();
            }

        }
    }
}

using DocumentFormat.OpenXml.Bibliography;
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

namespace Registr.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPayment.xaml
    /// </summary>
    public partial class AddPayment : Window
    {
            PaymentDB_PPEntities database = new PaymentDB_PPEntities();
        public AddPayment()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Payment PM = new Payment();

            //Добавление вводимых данных в базу
            PM.Amount = double.Parse(Amount.Text);
            PM.DateOfAdmission = DateTime.Parse(Date_Admission.Text);
            PM.PersonalAccount = Personal_Account.Text;

            MessageBox.Show("Платеж упешно добавлен!");

            try
            {
                database.Payments.Add(PM);
                database.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

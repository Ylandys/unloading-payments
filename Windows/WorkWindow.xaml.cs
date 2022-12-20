using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
//using
using Syncfusion.UI.Xaml.Grid.Converter;
using Microsoft.Win32;
using System.Windows.Input;
using ClosedXML.Excel;
using System.Diagnostics;
using System.IO;
using Registr.Windows;

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
            ExportToExcel();
        }

        private void ExportToExcel()
        {
            this.TablePayments.SelectAllCells();
            this.TablePayments.ClipboardCopyMode = DataGridClipboardCopyMode.IncludeHeader;
            ApplicationCommands.Copy.Execute(null, this.TablePayments);
            this.TablePayments.UnselectAllCells();
            String result = (string)Clipboard.GetData(DataFormats.CommaSeparatedValue);
            try
            {
                StreamWriter sw = new StreamWriter("wpfdata.csv");
                sw.WriteLine(result);
                sw.Close();
                Process.Start("wpfdata.csv");
            }
            catch (Exception ex)
            { }
        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            Payment item = TablePayments.SelectedItem as Payment;
            try
            {
                Payment PM = database.Payments.Where(c => c.id == item.id).Single();
                database.Payments.Remove(PM);
                database.SaveChanges();

                MessageBox.Show("Клиент успешно удалён!");
                //Метод обновления таблицы после удаления
                refreshdatagrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                string output = TablePayments.Items.Count.ToString();
                int result = int.Parse(output) - 1;
                MessageBox.Show($"Кол-во платежей: {result}");

        }

        private void Search_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Search_txt.Text != "")
            {
                TablePayments.ItemsSource = database.Payments.Where(s => Search_txt.Text == s.PersonalAccount).ToList();
            }
            else
            {
                TablePayments.ItemsSource = database.Payments.ToList();
            }
        }

        private void Open_Folder_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            {
                string dn = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Платежи";

                openFile.InitialDirectory = dn;

                openFile.ShowDialog();

                PathToFile_txt.Text = dn;
            }
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            AddPayment AP = new AddPayment();
            AP.ShowDialog();
        }
    }
}

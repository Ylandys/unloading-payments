using System;
using System.Collections.Generic;
using System.IO;
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

namespace Registr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PaymentDB_PPEntities database = new PaymentDB_PPEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Worker fio = new Worker();
            if (database.WorkerLogins.Any(u => u.username == UserName.Text && u.password == UserPass.Password))
            {
                foreach (var worker in database.WorkerLogins)
                {
                    if (worker.username == UserName.Text && worker.password == UserPass.Password)
                    {
                        this.Visibility = Visibility.Collapsed;
                        WorkWindow workWindow = new WorkWindow();
                        workWindow.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неправильный пароль/Пользователь не найден");
            }
        }
    }
}

using RestManage.Views.Pages;
using RestManage.Views.Windows;
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

namespace RestManage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            LoginWindow.ContentChanged += LoginWindow_ContentChanged;
        }

        private void LoginWindow_ContentChanged(object sender, EventArgs e)
        {
            MainFrame.Navigate(new AdminMenuPage()); // Замените Page1 на нужную вам страницу
        }
    }
}

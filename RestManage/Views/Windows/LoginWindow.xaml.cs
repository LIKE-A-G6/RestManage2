using RestManage.Models;
using RestManage.Views.Pages;
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

namespace RestManage.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public static event EventHandler ContentChanged;

        private void Registration_window_open(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            var CurrentUserAdmin = AppData.db.Employee.FirstOrDefault(u => u.Login == LoginTxt.Text && u.Password == PasswordTxt.Password && u.IdRole == 1);
            var CurrentUser = AppData.db.Employee.FirstOrDefault(u => u.Login == LoginTxt.Text && u.Password == PasswordTxt.Password && u.IdRole == 2);
            if (CurrentUserAdmin != null)
            {
                ContentChanged?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            //else if (CurrentUser != null)
            //{
            //    UserWindow userWindow = new UserWindow();
            //    userWindow.Show();
            //    this.Close();
            //}
            else if (LoginTxt.Text == "" || PasswordTxt.Password == "")
            {
                MessageBox.Show("Заполните все пустые поля", "Поля пустые!");
            }
            else
            {
                if (MessageBox.Show("Аккаунта с таким логином или паролем не существует!\nПройти регистрацию?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    RegistrationWindow regist = new RegistrationWindow();
                    regist.Show();
                    this.Close();
                }
                else
                {
                    LoginTxt.Text = "";
                    PasswordTxt.Password = "";
                    LoginTxt.Focus();
                }
            }
        }
    }
}

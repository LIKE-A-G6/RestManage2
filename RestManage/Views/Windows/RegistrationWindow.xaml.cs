using RestManage.Models;
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

namespace RestManage.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Login_window_open(object sender, MouseButtonEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        public Boolean CheckPass()//проверка пароля на спец.символы
        {
            string password = PasswordTxt.Password;
            if (password.Length > 5
                && password.Any(char.IsLetter)
                && password.Any(char.IsDigit)
                && password.Any(char.IsPunctuation)
                && password.Any(char.IsLower)
                && password.Any(char.IsUpper))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string firstname = FirstNameTxt.Text;
            string lastname = LastNameTxt.Text;
            string login = LoginTxt.Text;
            string password = PasswordTxt.Password;
            string confpass = ConfirmPasswordTxt.Password;

            {
                if (FirstNameTxt.Text == "" || LastNameTxt.Text == "" || PatronymicTxt.Text == "" || LoginTxt.Text == "" || PasswordTxt.Password == "" || ConfirmPasswordTxt.Password == "")
                {
                    MessageBox.Show("Поля пустые!", "Регистрация не завершена");
                }
                else if (AppData.db.Employee.Count(u => u.Login == LoginTxt.Text) > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже есть!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!(PasswordTxt.Password == ConfirmPasswordTxt.Password))
                {
                    MessageBox.Show("Пароли не совпадают!\nВведите снова", "Регистрация не завершена");
                    PasswordTxt.Password = "";
                    ConfirmPasswordTxt.Password = "";
                    PasswordTxt.Focus();
                }
                else if (!CheckPass())
                {
                    MessageBox.Show("Пароль может содержать только символы a-z, A-Z, нижний и верхний регистр, знаки пунктуации, цифры\nВведите снова", "Регистрация не завершена");
                    PasswordTxt.Password = "";
                    ConfirmPasswordTxt.Password = "";
                    PasswordTxt.Focus();
                }
                else
                {
                    Employee employee = new Employee()
                    {
                        FirstName = FirstNameTxt.Text,
                        LastName = LastNameTxt.Text,
                        Patronymic = PatronymicTxt.Text,
                        Login = LoginTxt.Text,
                        Password = PasswordTxt.Password,
                        IdRole = 2
                    };
                    AppData.db.Employee.Add(employee);
                    AppData.db.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}

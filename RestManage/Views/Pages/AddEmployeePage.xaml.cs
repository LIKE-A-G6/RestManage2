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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RestManage.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        public AddEmployeePage()
        {
            InitializeComponent();
            RoleCmb.ItemsSource = AppData.db.Roles.ToList();
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

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            {
                if (FirstNameTxt.Text == "" || LastNameTxt.Text == "" || PatronymicTxt.Text == "" || LoginTxt.Text == "" || PasswordTxt.Password == "" || RoleCmb.SelectedItem == null)
                {
                    MessageBox.Show("Поля пустые!", "Регистрация не завершена");
                }
                else if (AppData.db.Employee.Count(u => u.Login == LoginTxt.Text) > 0)
                {
                    MessageBox.Show("Пользователь с таким логином уже есть!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (!CheckPass())
                {
                    MessageBox.Show("Пароль может содержать только символы a-z, A-Z, нижний и верхний регистр, знаки пунктуации, цифры\nВведите снова", "Регистрация не завершена");
                    PasswordTxt.Password = "";
                    PasswordTxt.Focus();
                }
                else
                {
                    Employee employee = new Employee();

                    employee.FirstName = FirstNameTxt.Text;
                    employee.LastName = LastNameTxt.Text;
                    employee.Patronymic = PatronymicTxt.Text;
                    employee.Login = LoginTxt.Text;
                    employee.Password = PasswordTxt.Password;

                    var CurrentRole = RoleCmb.SelectedItem as Roles;
                    employee.IdRole = CurrentRole.Id;

                    AppData.db.Employee.Add(employee);
                    AppData.db.SaveChanges();
                    NavigationService.GoBack();
                }
            }

        }
    }
}


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
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        public EmployeePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeGrid.ItemsSource = AppData.db.Employee.ToList();
        }

        private void AddEmployeeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployeePage());
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var CurrentEmployee = EmployeeGrid.SelectedItem as Employee;
                AppData.db.Employee.Remove(CurrentEmployee);
                AppData.db.SaveChanges();

                EmployeeGrid.ItemsSource = AppData.db.Employee.ToList();
                MessageBox.Show("Запись удалена!");
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            // Обновление данных
            EmployeeGrid.ItemsSource = AppData.db.Employee.ToList();
            // Сохранение изменений в базе данных
            AppData.db.SaveChanges();
        }
    }
}

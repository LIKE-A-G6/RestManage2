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
    /// Логика взаимодействия для AddRolePage.xaml
    /// </summary>
    public partial class AddRolePage : Page
    {
        public AddRolePage()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoleTxt.Text == "")
            {
                MessageBox.Show("Поля пустые!");
            }
            else if (AppData.db.Roles.Count(u => u.Role == RoleTxt.Text) > 0)
            {
                MessageBox.Show("Эта роль уже существует!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Roles role = new Roles();

                role.Role = RoleTxt.Text;

                AppData.db.Roles.Add(role);
                AppData.db.SaveChanges();
                NavigationService.GoBack();
            }
        }
    }
}

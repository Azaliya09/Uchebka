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
using Uchebnaya_Azaliya.Base;

namespace Uchebnaya_Azaliya.Pages
{
    /// <summary>
    /// Логика взаимодействия для ListEmployeePage.xaml
    /// </summary>
    public partial class ListEmployeePage : Page
    {
        public ListEmployeePage()
        {
            InitializeComponent();
            EmployeeList.ItemsSource = App.db.Employee.ToList();
            if (App.IsAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            Navigation.NextPage(new PageComponent("Добавление новой записи", new EditEmloyeeList(employee)));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = EmployeeList.SelectedItem as Employee;
            if (employee != null)
                Navigation.NextPage(new PageComponent("Редактирование записи", new EditEmloyeeList(employee)));
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
            Refresh();
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
            Employee employee = EmployeeList.SelectedItem as Employee;
            if (employee != null)
            {
                App.db.Employee.Remove(employee);
                App.db.SaveChanges();
                EmployeeList.ItemsSource = App.db.Employee.ToList();
                MessageBox.Show("Удалено!");
            }
        }
        public void Refresh()
        {
            IEnumerable<Employee> Sort = App.db.Employee;
            if (SortCb.SelectedIndex == 0)
            {
                Sort = Sort;
            }
            else if (SortCb.SelectedIndex == 1)
            {
                Sort = Sort.OrderBy(x => x.Id_Employee);
            }
            else if (SortCb.SelectedIndex == 2)
            {
                Sort = Sort.OrderByDescending(x => x.Id_Employee);
            }

            if (SearchTb.Text != null)
            {
                Sort = Sort.Where(x => x.Surname.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            EmployeeList.ItemsSource = Sort.ToList();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}

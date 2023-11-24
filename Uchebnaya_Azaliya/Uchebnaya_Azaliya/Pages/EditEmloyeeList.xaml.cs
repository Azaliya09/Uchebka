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
using System.Xml.Linq;
using Uchebnaya_Azaliya.Base;

namespace Uchebnaya_Azaliya.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditEmloyeeList.xaml
    /// </summary>
    public partial class EditEmloyeeList : Page
    {
        private Employee employee;
        private bool New;
        public EditEmloyeeList(Employee _employee)
        {
            InitializeComponent();
            employee = _employee;
            this.DataContext = employee;
            if (employee.Id_Employee == null || employee.Id_Employee == 0)
                New = true;
            PositionCb.ItemsSource = App.db.Position.ToList();
            if (New != true)
            {
                IdTb.Text = employee.Id_Employee.ToString();
                IdTb.IsEnabled = false;
            }
            else
            {
                IdTb.IsEnabled = true;
            }

            IdTb.Text = employee.Id_Employee.ToString();
            NameTb.Text = employee.Surname;
            PositionCb.SelectedItem = employee.Position;
            
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IdTb.Text == "" || NameTb.Text == "" || PositionCb.SelectedItem == null || SalaryTb.Text == "")
            {
                MessageBox.Show("Вы не заполнили все поля!!");
                return;
            }
            if (New)
                App.db.Employee.Add(new Employee
                {
                    Id_Employee = Convert.ToInt32(IdTb.Text),
                    Surname = NameTb.Text,
                    Id_Position = Convert.ToInt32((PositionCb.SelectedItem as Position).Id_Position),
                    
                });
            else
            {
                var _employee = App.db.Employee.Where(x => x.Id_Employee == employee.Id_Employee).FirstOrDefault();
                if (_employee != null)
                {
                    _employee.Id_Employee = Convert.ToInt32(IdTb.Text);
                    _employee.Surname = NameTb.Text;
                    _employee.Id_Position = Convert.ToInt32((PositionCb.SelectedItem as Position).Id_Position);             
                }
            }
            App.db.SaveChanges();
            MessageBox.Show("Сохранено!");
            Navigation.NextPage(new PageComponent("Сотрудники", new ListEmployeePage()));
        }
    }
}

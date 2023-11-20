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
    /// Логика взаимодействия для EditEmloyeeList.xaml
    /// </summary>
    public partial class EditEmloyeeList : Page
    {
        private Employee employee;
        public EditEmloyeeList(Employee _employee)
        {
            InitializeComponent();
            employee = _employee;
            PositionCb.ItemsSource = App.db.Position.ToList();
            if (employee.Id_Employee == 0)
                IdTb.IsEnabled = true;
            else
                IdTb.IsEnabled = false;
            
            IdTb.Text = employee.Id_Employee.ToString();
            NameTb.Text = employee.Surname;
            PositionCb.SelectedItem = employee.Position;
            SalaryTb.Text = employee.Salary.ToString();
        }
    }
}

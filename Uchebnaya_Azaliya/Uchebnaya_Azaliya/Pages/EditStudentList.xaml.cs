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
    /// Логика взаимодействия для EditStudentList.xaml
    /// </summary>
    public partial class EditStudentList : Page
    {
        private Student student;
        public EditStudentList(Student _student)
        {
            InitializeComponent();
            student = _student;
            SpecsCb.ItemsSource = App.db.Specs.ToList();

            IdTb.Text = student.Id_Student.ToString();
            SpecsCb.SelectedItem = student.Specs;
            NameTb.Text = student.Surname_Student;
        }
    }
}

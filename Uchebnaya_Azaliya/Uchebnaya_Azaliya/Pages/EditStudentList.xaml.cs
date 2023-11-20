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
    /// Логика взаимодействия для EditStudentList.xaml
    /// </summary>
    public partial class EditStudentList : Page
    {
        private Student student;
        private bool New;
        public EditStudentList(Student _student)
        {
            InitializeComponent();
            student = _student;
            if (student.Id_Student == null || student.Id_Student == 0)
                New = true;
            SpecsCb.ItemsSource = App.db.Specs.ToList();
            if (New != true)
            {
                IdTb.Text = student.Id_Student.ToString();
                IdTb.IsEnabled = false;
            }
            else
            {
                IdTb.IsEnabled = true;
            }

            IdTb.Text = student.Id_Student.ToString();
            SpecsCb.SelectedItem = student.Specs;
            NameTb.Text = student.Surname_Student;
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IdTb.Text == "" ||  SpecsCb.SelectedItem == null || NameTb.Text == "" )
            {
                MessageBox.Show("Вы не заполнили все поля!!");
                return;
            }
            if (New)
                App.db.Student.Add(student);
            else
            {
                var _student = App.db.Student.Where(x => x.Id_Student == student.Id_Student).FirstOrDefault();
                if (_student != null)
                {
                    _student.Id_Student = Convert.ToInt32(IdTb.Text);
                    _student.Id_Spec = (SpecsCb.SelectedItem as Specs).Direction;
                    _student.Surname_Student = NameTb.Text;
                }
            }
            App.db.SaveChanges();
            MessageBox.Show("Сохранено!");
            Navigation.NextPage(new PageComponent("Студенты", new ListStudentPage()));
        }
    }
}

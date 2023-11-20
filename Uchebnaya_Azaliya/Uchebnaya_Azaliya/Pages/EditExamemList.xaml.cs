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
    /// Логика взаимодействия для EditExamemList.xaml
    /// </summary>
    public partial class EditExamemList : Page
    {
        private Examen examen;
        private bool New;
        public EditExamemList(Examen _examen)
        {
            InitializeComponent();
            examen = _examen;
            if (examen.Id_Student == null || examen.Id_Student == 0)
                New = true;
            SubjectCb.ItemsSource = App.db.Subject.ToList();
            StudentCb.ItemsSource = App.db.Student.ToList(); 
            EmployeeCb.ItemsSource = App.db.Employee.ToList();
            if (New != true)
                DateDp.SelectedDate = examen.Date_Examen;
            else
                DateDp.SelectedDate = DateTime.Now;
            SubjectCb.SelectedItem = examen.Subject;
            StudentCb.SelectedItem = examen.Student;
            EmployeeCb.SelectedItem = examen.Employee;
            AuditoryTb.Text = examen.Auditory;
            MarkTb.Text = examen.Mark.ToString();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if(MarkTb.Text == "" || AuditoryTb.Text == "" || EmployeeCb.SelectedItem == null || StudentCb.SelectedItem == null || SubjectCb.SelectedItem == null || DateDp.SelectedDate == null)
            {
                MessageBox.Show("Вы не заполнили все поля!!");
                return;
            }
            if(New)
                App.db.Examen.Add(examen);
            else
            {
                var _examen = App.db.Examen.Where(x => x.Date_Examen == examen.Date_Examen && x.Id_Student == examen.Id_Student).FirstOrDefault();
                if(_examen != null)
                {
                    _examen.Date_Examen = Convert.ToDateTime(DateDp.SelectedDate);
                    _examen.Id_Subject = (SubjectCb.SelectedItem as Subject).Id_Subject;
                    _examen.Id_Student = (StudentCb.SelectedItem as Student).Id_Student;
                    _examen.Id_Employee = (EmployeeCb.SelectedItem as Employee).Id_Employee;
                    _examen.Auditory = AuditoryTb.Text;
                    _examen.Mark = Convert.ToInt32(MarkTb.Text);
                }
                
            }
            
            App.db.SaveChanges();
            MessageBox.Show("Сохранено!");
            Navigation.NextPage(new PageComponent("Экзамен", new ListExamenPage()));
        }
    }
}

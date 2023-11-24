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
    /// Логика взаимодействия для EditSubjectList.xaml
    /// </summary>
    public partial class EditSubjectList : Page
    {
        private Subject subject;
        private bool New;
        public EditSubjectList(Subject _subject)
        {
            InitializeComponent();
            subject = _subject;
            if (subject.Id_Subject == null || subject.Id_Subject == 0)
                New = true;
            AbbCb.ItemsSource = App.db.Lectern.ToList();
            if (New != true)
            {
                IdTb.Text = subject.Id_Subject.ToString();
                IdTb.IsEnabled = false;
            }
            else
            {
                IdTb.IsEnabled = true;
            }
            SubjectTb.Text = subject.Name_Subject;
            AbbCb.SelectedItem = subject.Lectern;
            IdTb.Text = subject.Id_Subject.ToString();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SubjectTb.Text == "" || AbbCb.SelectedItem == null || IdTb.Text == "")
            {
                MessageBox.Show("Вы не заполнили все поля!!");
                return;
            }
            if (New)
                App.db.Subject.Add(new Subject
                    {
                        Name_Subject = SubjectTb.Text,
                        Id_Lectern = (AbbCb.SelectedItem as Lectern).Id_Lectern,
                        Id_Subject = Convert.ToInt32(IdTb.Text),
                    });
            else
            {
                var _subject = App.db.Subject.Where(x => x.Id_Subject == subject.Id_Subject).FirstOrDefault();
                if (_subject != null)
                {
                    _subject.Name_Subject = SubjectTb.Text;
                    _subject.Id_Lectern = (AbbCb.SelectedItem as Lectern).Id_Lectern;
                    _subject.Id_Subject = Convert.ToInt32(IdTb.Text);
                }
            }
            App.db.SaveChanges();
            MessageBox.Show("Сохранено!");
            Navigation.NextPage(new PageComponent("Дисциплины", new ListSubjectPage()));
        }
    }
}

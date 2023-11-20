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
        public EditSubjectList(Subject _subject)
        {
            InitializeComponent();
            subject = _subject;
            AbbCb.ItemsSource = App.db.Lectern.ToList();

            SubjectTb.Text = subject.Name_Subject;
            AbbCb.SelectedItem = subject.Lectern;
            IdTb.Text = subject.Id_Subject.ToString();
        }
    }
}

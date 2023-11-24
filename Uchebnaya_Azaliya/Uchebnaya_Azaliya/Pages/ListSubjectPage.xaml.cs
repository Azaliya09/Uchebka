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
    /// Логика взаимодействия для SubjectPage.xaml
    /// </summary>
    public partial class ListSubjectPage : Page
    {
        public ListSubjectPage()
        {
            InitializeComponent();
            ListSubjectList.ItemsSource = App.db.Subject.ToList();
            if (App.IsAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Subject subject = new Subject();
            Navigation.NextPage(new PageComponent("Добавление новой записи", new EditSubjectList(subject)));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Subject subject = ListSubjectList.SelectedItem as Subject;
            if (subject != null)
                Navigation.NextPage(new PageComponent("Редактирование записи", new EditSubjectList(subject)));

        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Subject subject = ListSubjectList.SelectedItem as Subject;
            if (subject != null)
            {
                App.db.Subject.Remove(subject);
                App.db.SaveChanges();
                ListSubjectList.ItemsSource = App.db.Subject.ToList();
                MessageBox.Show("Удалено!");
            }
        }
        public void Refresh()
        {
            IEnumerable<Subject> Sort = App.db.Subject;
            if (SortCb.SelectedIndex == 0)
            {
                Sort = Sort;
            }
            else if (SortCb.SelectedIndex == 1)
            {
                Sort = Sort.OrderBy(x => x.Id_Subject);
            }
            else if (SortCb.SelectedIndex == 2)
            {
                Sort = Sort.OrderByDescending(x => x.Id_Subject);
            }

            if (SearchTb.Text != null)
            {
                Sort = Sort.Where(x => x.Name_Subject.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            ListSubjectList.ItemsSource = Sort.ToList();
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

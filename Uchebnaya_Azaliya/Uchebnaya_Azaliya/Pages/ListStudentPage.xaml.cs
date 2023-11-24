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
    /// Логика взаимодействия для ListStudentPage.xaml
    /// </summary>
    public partial class ListStudentPage : Page
    {
        public ListStudentPage()
        {
            InitializeComponent();
            ListStudentList.ItemsSource = App.db.Student.ToList();
            if (App.IsAdmin == false)
            {
                AddBtn.Visibility = Visibility.Hidden;
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
        }
        private void ListStudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            Navigation.NextPage(new PageComponent("Добавление новой записи", new EditStudentList(student)));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Student student = ListStudentList.SelectedItem as Student;
            if(student != null)
                Navigation.NextPage(new PageComponent("Редактирование записи", new EditStudentList(student)));
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Student student = ListStudentList.SelectedItem as Student;
            if (student != null)
            {
                App.db.Student.Remove(student);
                App.db.SaveChanges();
                ListStudentList.ItemsSource = App.db.Student.ToList();
                MessageBox.Show("Удалено!");
            }
        }
        public void Refresh()
        {
            IEnumerable<Student> Sort = App.db.Student;
            if (SortCb.SelectedIndex == 0)
            {
                Sort = Sort;
            }
            else if (SortCb.SelectedIndex == 1)
            {
                Sort = Sort.OrderBy(x => x.Id_Student);
            }
            else if (SortCb.SelectedIndex == 2)
            {
                Sort = Sort.OrderByDescending(x => x.Id_Student);
            }

            if (SearchTb.Text != null)
            {
                Sort = Sort.Where(x => x.Surname_Student.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            ListStudentList.ItemsSource = Sort.ToList();
        }
        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
    }
}

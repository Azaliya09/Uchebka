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

        }
    }
}

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
    /// Логика взаимодействия для StudentPage.xaml
    /// </summary>
    public partial class ListExamenPage : Page
    {
        public ListExamenPage()
        {
            InitializeComponent();
            MarksList.ItemsSource = App.db.Examen.ToList();
            if (App.IsAdmin == false)
            {
                EditBtn.Visibility = Visibility.Hidden;
                DeleteBtn.Visibility = Visibility.Hidden;
            }
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Examen examem = new Examen();
            Navigation.NextPage(new PageComponent("Добавление новой записи", new EditExamemList(examem)));
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            Examen examen = MarksList.SelectedItem as Examen;
            if(examen != null)
                Navigation.NextPage(new PageComponent("Редактирование записи", new EditExamemList(examen)));
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Examen examen = MarksList.SelectedItem as Examen;
            if (examen != null)
            {
                App.db.Examen.Remove(examen);
                App.db.SaveChanges();
                MarksList.ItemsSource = App.db.Examen.ToList();
            }    
        }
        public void Refresh()
        {
            IEnumerable<Examen> Sort = App.db.Examen;
            if(SortCb.SelectedIndex == 0)
            {
                Sort = Sort;
            }
            else if(SortCb.SelectedIndex == 1)
            {
                Sort = Sort.OrderBy(x => x.Date_Examen);
            }
            else if(SortCb.SelectedIndex == 2)
            {
                Sort = Sort.OrderByDescending(x => x.Date_Examen);
            }

            if (FilterCb.SelectedIndex == 0)
                Sort = Sort;
            if (FilterCb.SelectedIndex == 1)
                Sort = Sort.Where(x => x.Mark == 5);
            if (FilterCb.SelectedIndex == 2)
                Sort = Sort.Where(x => x.Mark == 4);
            if (FilterCb.SelectedIndex == 3)
                Sort = Sort.Where(x => x.Mark == 3);

            if(SearchTb.Text != null)
            {
                Sort = Sort.Where(x => x.Subject.Name_Subject.ToLower().Contains(SearchTb.Text.ToLower()));
            }

            MarksList.ItemsSource = Sort.ToList();
        }

        private void SortCb_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void FilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }
        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }
    }
}

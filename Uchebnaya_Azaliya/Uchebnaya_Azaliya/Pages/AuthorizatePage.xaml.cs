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

namespace Uchebnaya_Azaliya.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizatePage.xaml
    /// </summary>
    public partial class AuthorizatePage : Page
    {
        public AuthorizatePage()
        {
            InitializeComponent();
            
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.RemoveBackEntry();
            if (PasswordPb.Password == "0000")
            {
                App.IsAdmin = true;
                MessageBox.Show("Вы вошли как администратор!");
                Navigation.NextPage(new PageComponent("Добро пожаловать!", new AdminPage()));
            }
            else if(PasswordPb.Password == "1111")
            {
                App.IsEmployee = true;
                MessageBox.Show("Вы вошли как сотрудник!");
                Navigation.NextPage(new PageComponent("Добро пожаловать!", new ListExamenPage()));
            }
            else
            {
                App.IsStudent = true;
                MessageBox.Show("Вы вошли как студент!");
                Navigation.NextPage(new PageComponent("Добро пожаловать!", new ListSubjectPage()));
            }
        }
    }
}

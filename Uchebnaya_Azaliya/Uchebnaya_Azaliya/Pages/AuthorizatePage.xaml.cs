using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using static System.Net.WebRequestMethods;

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
            string soucer_xl = @"https://i.pinimg.com/736x/82/70/6f/82706f7dc2067284e83f7ac21aa41087.jpg";
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData data = qr.CreateQrCode(soucer_xl, QRCoder.QRCodeGenerator.ECCLevel.L);
            QRCoder.QRCode code = new QRCoder.QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                imageQr.Source = bitmapimage;
            }

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
                Navigation.mainWindow.BackBTN.Visibility = Visibility.Hidden;
                MessageBox.Show("Вы вошли как студент!");
                Navigation.NextPage(new PageComponent("Добро пожаловать!", new ListSubjectPage()));
            }
        }
    }
}

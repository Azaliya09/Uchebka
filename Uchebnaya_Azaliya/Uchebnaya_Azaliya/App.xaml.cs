using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Uchebnaya_Azaliya.Base;

namespace Uchebnaya_Azaliya
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Uchebka_SSEntities1 db = new Uchebka_SSEntities1();
        public static bool IsAdmin = false;
        public static bool IsEmployee = false;
        public static bool IsStudent = false;

    }
}

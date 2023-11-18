﻿using System;
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
        }
        
    }
}
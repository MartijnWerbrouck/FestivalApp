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

namespace FestivalApp.View
{
    /// <summary>
    /// Interaction logic for ContactPage.xaml
    /// </summary>
    public partial class ContactPage : UserControl
    {
        public ContactPage()
        {
            InitializeComponent();
            btnNieuw.IsEnabled = false;
            btnAanpassen.IsEnabled = false;
            btnVerwijderen.IsEnabled = false;
            cboVeranderFuncties.IsEnabled = false;
        }

        private void dgContact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnNieuw.IsEnabled = true;
            btnAanpassen.IsEnabled = true;
            btnVerwijderen.IsEnabled = true;
            cboVeranderFuncties.IsEnabled = true;
        }
    }
}

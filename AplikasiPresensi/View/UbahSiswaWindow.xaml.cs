﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AplikasiPresensi.View
{
    /// <summary>
    /// Interaction logic for UbahSiswaWindow.xaml
    /// </summary>
    public partial class UbahSiswaWindow : Window
    {
        public UbahSiswaWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
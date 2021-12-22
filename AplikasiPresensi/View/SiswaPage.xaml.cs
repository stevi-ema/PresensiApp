using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AplikasiPresensi.View
{
    /// <summary>
    /// Interaction logic for SiswaPage.xaml
    /// </summary>
    public partial class SiswaPage : Page
    {
        public SiswaPage()
        {
            InitializeComponent();
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            TambahSiswaWindow tambah = new TambahSiswaWindow();
            tambah.Show();
        }

        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {
            PreviewSiswaWindow detail = new PreviewSiswaWindow();
            detail.Show();
        }

        private void btnUbah_Click(object sender, RoutedEventArgs e)
        {
            UbahSiswaWindow ubah = new UbahSiswaWindow();
            ubah.Show();
        }
    }
}

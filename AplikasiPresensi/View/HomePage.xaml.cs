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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        Controller.Presensi presensi;
        public HomePage()
        {
            InitializeComponent();

            string hariIni = DateTime.Now.ToString("dd MMMM yyyy");
            lblPresensi.Content = "Presensi hari ini, " + hariIni;

            presensi = new Controller.Presensi(this);
            presensi.ShowJumlahPresensiToday();

            presensi.HistoriPresensi();

            presensi.DataSiswaTerlambat();
            presensi.DataSiswaTidakHadir();
        }
    }
}

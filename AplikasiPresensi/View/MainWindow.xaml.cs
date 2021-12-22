using System.Windows;

namespace AplikasiPresensi.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void menuExit_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }

        private void menuHome_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frmMain.Navigate(new View.HomePage());
        }

        private void menuSiswa_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frmMain.Navigate(new View.SiswaPage());
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(MenuPengguna.Visibility == Visibility.Visible)
            {
                MenuPengguna.Visibility = Visibility.Hidden;
            }
            else
            {
                MenuPengguna.Visibility = Visibility.Visible;
            }
        }

        private void lblUser_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (MenuPengguna.Visibility == Visibility.Visible)
            {
                MenuPengguna.Visibility = Visibility.Hidden;
            }
            else
            {
                MenuPengguna.Visibility = Visibility.Visible;
            }
        }

        private void lblLogout_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void menuLaporan_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            frmMain.Navigate(new View.LaporanPage());
        }

        private void menuPresensi_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PresensiWindow presensi = new PresensiWindow();
            presensi.Show();
        }
    }
}

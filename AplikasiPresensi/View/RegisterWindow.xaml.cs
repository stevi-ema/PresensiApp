using System.Windows;

namespace AplikasiPresensi.View
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        //declare controller
        Controller.Pengguna pengguna;

        public RegisterWindow()
        {
            InitializeComponent();
            //instance
            pengguna = new Controller.Pengguna(this);
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            pengguna.Register();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}

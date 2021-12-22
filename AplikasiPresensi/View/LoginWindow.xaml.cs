using System.Windows;

namespace AplikasiPresensi.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        //declare object
        Controller.Pengguna pengguna;

        public LoginWindow()
        {
            InitializeComponent();
            
            //instance
            pengguna = new Controller.Pengguna(this);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            pengguna.Login();
        }

        private void lblSignUp_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.Show();
            this.Close();
        }
    }
}

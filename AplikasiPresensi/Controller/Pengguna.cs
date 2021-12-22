using System.Windows;

namespace AplikasiPresensi.Controller
{
    class Pengguna
    {
        //declare object
        Model.PenggunaModel pengguna;
        View.LoginWindow login;
        
        //instance
        public Pengguna(View.LoginWindow login)
        {
            pengguna = new Model.PenggunaModel();
            this.login = login;
        }

        View.RegisterWindow register;

        public Pengguna(View.RegisterWindow register)
        {
            pengguna = new Model.PenggunaModel();
            this.register = register;
        }

        public void Login()
        {
            pengguna.id = login.txtUsername.Text;
            pengguna.password = login.txtPassword.Password;
            bool result = pengguna.CekLogin();
            if (result)
            {
                View.MainWindow main = new View.MainWindow();
                main.lblUser.Content = Model.PenggunaModel.namaUser;
                main.Show();
                login.Close();
            }
            else
            {
                MessageBox.Show("Maaf, username/password anda salah!");
                login.txtUsername.Text = "";
                login.txtPassword.Password = "";
                login.txtUsername.Focus();
            }
        }

        public void Register()
        {
            pengguna.id = register.txtId.Text;
            pengguna.nama = register.txtNama.Text;
            if(register.rdbLaki.IsChecked == true)
            {
                pengguna.jk = "L";
            }
            else
            {
                pengguna.jk = "P";
            }
            pengguna.telp = register.txtTelp.Text;
            pengguna.password = register.txtPassword.Text;

            bool result = pengguna.InsertPengguna();
            if(result)
            {
                MessageBox.Show("Pembuatan akun baru berhasil, " +
                    "silahkan login menggunakan ID dan password anda");
                View.LoginWindow login = new View.LoginWindow();
                login.Show();
                register.Close();
            }
            else
            {
                MessageBox.Show("Maaf, registrasi akun baru gagal, " +
                    "periksa dan lengkapi data anda");
            }
        }
    }
}

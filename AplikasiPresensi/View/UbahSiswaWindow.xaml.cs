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
using System.Windows.Shapes;

namespace AplikasiPresensi.View
{
    /// <summary>
    /// Interaction logic for UbahSiswaWindow.xaml
    /// </summary>
    public partial class UbahSiswaWindow : Window
    {
        //declare object class Controller Siswa
        private Controller.Siswa siswa;
        //declare object class OpenFileDialog
        private Microsoft.Win32.OpenFileDialog openFile;
        bool updateFoto = false;

        public UbahSiswaWindow()
        {
            InitializeComponent();
            //instance
            siswa = new Controller.Siswa(this);
            openFile = new Microsoft.Win32.OpenFileDialog();

            //show data siswa
            //show data
            txtNISN.Text = SiswaPage.nisn;
            txtNama.Text = SiswaPage.nama;
            if (SiswaPage.jk == "L")
            {
                rdbLaki.IsChecked = true;
            }
            else
            {
                rdbPerempuan.IsChecked = true;
            }
            txtTempatLahir.Text = SiswaPage.tempatLahir;
            dtpTanggal.SelectedDate = DateTime.Parse(SiswaPage.tanggalLahir);
            txtAlamatSiswa.Text = SiswaPage.alamat;
            txtNamaIbu.Text = SiswaPage.namaIbu;
            txtNamaAyah.Text = SiswaPage.namaAyah;
            txtAlamatOrtu.Text = SiswaPage.alamatOrtu;
            txtTelp.Text = SiswaPage.telp;
            string path = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName +
                "\\Foto\\" + SiswaPage.foto;
            if (System.IO.File.Exists(path))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path);
                bitmap.EndInit();
                imgFoto.Source = bitmap;
            }
            else
            {
                string foto = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName +
                "\\Foto\\NoImage.png";
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(foto);
                bitmap.EndInit();
                imgFoto.Source = bitmap;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            openFile.Filter = "Image File (*.jpg)|*.jpg|All Files (*.*)|*.*";
            if (openFile.ShowDialog() == true)
            {
                string selectedName = openFile.FileName;
                //MessageBox.Show(selectedName);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedName);
                bitmap.EndInit();
                imgFoto.Source = bitmap;
            }
            updateFoto = true;
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs : EventArgs
        {
            public string data { get; set; }
        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            if (updateFoto == true)
            {
                //replace gambar ke direktori yg sudah diset
                string filename = txtNISN.Text + ".jpg";
                string path = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName +
                    "\\Foto\\" + filename;

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Copy(openFile.FileName, path, true);
                }
            }
            //insert data ke dbase
            siswa.UbahSiswa();

            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);
        }
    }
}

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
    /// Interaction logic for PreviewSiswaWindow.xaml
    /// </summary>
    public partial class PreviewSiswaWindow : Window
    {
        public PreviewSiswaWindow()
        {
            InitializeComponent();

            //show data
            txtNISN.Text = SiswaPage.nisn;
            txtNama.Text = SiswaPage.nama;
            if(SiswaPage.jk == "L")
            {
                rdbLaki.IsChecked = true;
            }
            else
            {
                rdbPerempuan.IsChecked = true;
            }
            txtTempatLahir.Text = SiswaPage.tempatLahir;
            txtTanggal.Text = SiswaPage.tanggalLahir;
            txtAlamatSiswa.Text = SiswaPage.alamat;
            txtNamaIbu.Text = SiswaPage.namaIbu;
            txtNamaAyah.Text = SiswaPage.namaAyah;
            txtAlamatOrtu.Text = SiswaPage.alamatOrtu;
            txtTelp.Text = SiswaPage.telp;

            /*foto
            string path = "/Foto/" + foto;
            Uri resourceUri = new Uri(path, UriKind.Relative);
            imgFoto.Source = new BitmapImage(resourceUri);
            */

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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

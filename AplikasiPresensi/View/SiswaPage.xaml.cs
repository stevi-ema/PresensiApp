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

        //declare object controller
        private Controller.Siswa siswa;

        //declare static variabel
        public static string nisn;
        public static string nama;
        public static string jk;
        public static string tempatLahir;
        public static string tanggalLahir;
        public static string alamat;
        public static string foto;
        public static string namaIbu;
        public static string namaAyah;
        public static string alamatOrtu;
        public static string telp;

        public SiswaPage()
        {
            InitializeComponent();

            //instance
            siswa = new Controller.Siswa(this);

            //function utk menampilkan data di datagrid
            siswa.DataSiswa();
        }

        public void SetStaticVar()
        {
            nisn = "";
            nama = "";
            jk = "";
            tempatLahir = "";
            tanggalLahir = "";
            alamat = "";
            foto = "";
            namaIbu = "";
            namaAyah = "";
            alamatOrtu = "";
            telp = "";
        }

        private void F2_UpdateEventHandler(object sender, TambahSiswaWindow.UpdateEventArgs args)
        {
            siswa.DataSiswa();
        }

        private void F2_UpdateEventHandler(object sender, UbahSiswaWindow.UpdateEventArgs args)
        {
            siswa.DataSiswa();
        }

        private void btnTambah_Click(object sender, RoutedEventArgs e)
        {
            TambahSiswaWindow tambah = new TambahSiswaWindow();
            tambah.UpdateEventHandler += F2_UpdateEventHandler;
            tambah.Show();
        }

        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {
            object item = dgSiswa.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Pilih data siswa yang ingin ditampilkan terlebih dahulu");
            }
            else
            {
                getData();
                PreviewSiswaWindow detail = new PreviewSiswaWindow();
                detail.Show();
            }
            SetStaticVar();
        }

        private void btnUbah_Click(object sender, RoutedEventArgs e)
        {
            object item = dgSiswa.SelectedItem;
            if (item == null)
            {
                MessageBox.Show("Pilih data siswa yang ingin diubah terlebih dahulu");
            }
            else
            {
                getData();
                UbahSiswaWindow ubah = new UbahSiswaWindow();
                ubah.UpdateEventHandler += F2_UpdateEventHandler;
                ubah.Show();
            }
            SetStaticVar();
        }

        private void txtCari_TextChanged(object sender, TextChangedEventArgs e)
        {
            //show data siswa ke dalam datagrid
            siswa.DataSiswa();
        }

        private void btnCari_Click(object sender, RoutedEventArgs e)
        {
            //show data siswa ke dalam datagrid
            siswa.DataSiswa();
        }

        public void getData()
        {
            object item = dgSiswa.SelectedItem;
            nisn = (dgSiswa.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            nama = (dgSiswa.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            jk = (dgSiswa.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            tempatLahir = (dgSiswa.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            tanggalLahir = (dgSiswa.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            alamat = (dgSiswa.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            foto = (dgSiswa.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
            namaIbu = (dgSiswa.SelectedCells[7].Column.GetCellContent(item) as TextBlock).Text;
            namaAyah = (dgSiswa.SelectedCells[8].Column.GetCellContent(item) as TextBlock).Text;
            alamatOrtu = (dgSiswa.SelectedCells[9].Column.GetCellContent(item) as TextBlock).Text;
            telp = (dgSiswa.SelectedCells[10].Column.GetCellContent(item) as TextBlock).Text;
        }

        

        private void btnHapus_Click(object sender, RoutedEventArgs e)
        {
            object item = dgSiswa.SelectedItem;
            if(item == null)
            {
                MessageBox.Show("Pilih data siswa yang ingin dihapus terlebih dahulu");
            }
            else
            {
                getData();
                if (MessageBox.Show("Yakin ingin menghapus data?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    siswa.HapusSiswa();
                }
            }
            SetStaticVar();
            siswa.DataSiswa();
        }
    }
}

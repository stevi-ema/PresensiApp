using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows;


namespace AplikasiPresensi.Controller
{
    class Siswa
    {
        //declare object utk view dan model
        private Model.SiswaModel siswaModel; //model
        private View.SiswaPage siswaPage; //view
        //object tambah data siswa view
        private View.TambahSiswaWindow tambahSiswa;

        private View.UbahSiswaWindow ubahSiswa;

        //instance
        public Siswa(View.SiswaPage siswaPage)
        {
            siswaModel = new Model.SiswaModel();
            this.siswaPage = siswaPage;
        }

        public Siswa(View.TambahSiswaWindow tambahSiswa)
        {
            siswaModel = new Model.SiswaModel();
            this.tambahSiswa = tambahSiswa;
        }

        public Siswa(View.UbahSiswaWindow ubahSiswa)
        {
            siswaModel = new Model.SiswaModel();
            this.ubahSiswa = ubahSiswa;
        }

        //show data siswa di datagrid (view)
        public void DataSiswa()
        {
            string cari = siswaPage.txtCari.Text;
            DataSet data = siswaModel.SelectSiswa(cari);
            siswaPage.dgSiswa.ItemsSource = data.Tables[0].DefaultView;
        }

        //insert data siswa
        public void TambahSiswa()
        {
            //set data
            siswaModel.nisn = tambahSiswa.txtNISN.Text;
            siswaModel.nama = tambahSiswa.txtNama.Text;
            string jk = "";
            if (tambahSiswa.rdbLaki.IsChecked == true)
            {
                jk = "L";
            }
            else
            {
                jk = "P";
            }
            siswaModel.jk = jk;
            siswaModel.tempatLahir = tambahSiswa.txtTempatLahir.Text;
            siswaModel.tanggalLahir = tambahSiswa.dtpTanggal.SelectedDate.Value.ToString("yyyy-MM-dd");
            siswaModel.alamat = tambahSiswa.txtAlamatSiswa.Text;
            siswaModel.foto = tambahSiswa.txtNISN.Text + ".jpg";
            siswaModel.namaIbu = tambahSiswa.txtNamaIbu.Text;
            siswaModel.namaAyah = tambahSiswa.txtNamaAyah.Text;
            siswaModel.alamatOrtu = tambahSiswa.txtAlamatOrtu.Text;
            siswaModel.telp = tambahSiswa.txtTelp.Text;

            //proses insert
            bool result = siswaModel.InsertSiswa();
            //information
            if (result)
            {
                MessageBox.Show("Data siswa berhasil ditambahkan");
                tambahSiswa.Close();
                View.SiswaPage siswa = new View.SiswaPage();
            }
            else
            {
                MessageBox.Show("Maaf, penambahan data siswa tidak dapat dilakukan, cek kembali dan pastikan data lengkap");
            }

        }

        //update data siswa
        public void UbahSiswa()
        {
            //set data
            siswaModel.nisn = ubahSiswa.txtNISN.Text;
            siswaModel.nama = ubahSiswa.txtNama.Text;
            string jk = "";
            if (ubahSiswa.rdbLaki.IsChecked == true)
            {
                jk = "L";
            }
            else
            {
                jk = "P";
            }
            siswaModel.jk = jk;
            siswaModel.tempatLahir = ubahSiswa.txtTempatLahir.Text;
            siswaModel.tanggalLahir = ubahSiswa.dtpTanggal.SelectedDate.Value.ToString("yyyy-MM-dd");
            siswaModel.alamat = ubahSiswa.txtAlamatSiswa.Text;
            siswaModel.foto = ubahSiswa.txtNISN.Text + ".jpg";
            siswaModel.namaIbu = ubahSiswa.txtNamaIbu.Text;
            siswaModel.namaAyah = ubahSiswa.txtNamaAyah.Text;
            siswaModel.alamatOrtu = ubahSiswa.txtAlamatOrtu.Text;
            siswaModel.telp = ubahSiswa.txtTelp.Text;

            //proses update
            bool result = siswaModel.UpdateSiswa();
            //information
            if (result)
            {
                MessageBox.Show("Data siswa berhasil diubah");
                ubahSiswa.Close();
                View.SiswaPage siswa = new View.SiswaPage();
            }
            else
            {
                MessageBox.Show("Maaf, perubahan data siswa tidak dapat dilakukan, cek kembali dan pastikan data lengkap");
            }

        }

        public void HapusSiswa()
        {
            siswaModel.nisn = View.SiswaPage.nisn;
            //proses delete
            bool result = siswaModel.DeleteSiswa();
            //information
            if (result)
            {
                MessageBox.Show("Data siswa berhasil dihapus");
                string filename = View.SiswaPage.nisn + ".jpg";
                string path = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName +
                    "\\Foto\\" + filename;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            else
            {
                MessageBox.Show("Maaf, hapus data siswa tidak dapat dilakukan");
            }
        }
    }
}

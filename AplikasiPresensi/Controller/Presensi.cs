using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows;

namespace AplikasiPresensi.Controller
{
    class Presensi
    {
        //declare object
        Model.PresensiModel presensi;
        View.HomePage home;

        public Presensi(View.HomePage home)
        {
            presensi = new Model.PresensiModel();
            this.home = home;
        }

        public void ShowJumlahPresensiToday()
        {
            string tanggal = DateTime.Now.ToString("yyyy-MM-dd");
            home.lblTepatWaktu.Content = presensi.JumlahSiswa(tanggal, "Tepat Waktu");
            home.lblTelat.Content = presensi.JumlahSiswa(tanggal, "Terlambat");
            home.lblTidakHadir.Content = presensi.JumlahSiswaTidakHadir(tanggal);
        }

        public void HistoriPresensi()
        {
            //tanggal
            home.lblHistoryTgl1.Content = presensi.HistoryTanggal()[0].Substring(0,2);
            home.lblHistoryBln1.Content = presensi.HistoryTanggal()[0].Substring(3, 3);
            home.lblHistoryThn1.Content = presensi.HistoryTanggal()[0].Substring(7, 2);
            home.lblHistoryTgl2.Content = presensi.HistoryTanggal()[1].Substring(0, 2);
            home.lblHistoryBln2.Content = presensi.HistoryTanggal()[1].Substring(3, 3);
            home.lblHistoryThn2.Content = presensi.HistoryTanggal()[1].Substring(7, 2);
            home.lblHistoryTgl3.Content = presensi.HistoryTanggal()[2].Substring(0, 2);
            home.lblHistoryBln3.Content = presensi.HistoryTanggal()[2].Substring(3, 3);
            home.lblHistoryThn3.Content = presensi.HistoryTanggal()[2].Substring(7, 2);
            home.lblHistoryTgl4.Content = presensi.HistoryTanggal()[3].Substring(0, 2);
            home.lblHistoryBln4.Content = presensi.HistoryTanggal()[3].Substring(3, 3);
            home.lblHistoryThn4.Content = presensi.HistoryTanggal()[3].Substring(7, 2);

            //tepat waktu
            home.lblTepatWaktu1.Content = "Siswa yang hadir tepat waktu : " + presensi.HistorySiswa("Tepat Waktu",1)[0];
            home.lblTepatWaktu2.Content = "Siswa yang hadir tepat waktu : " + presensi.HistorySiswa("Tepat Waktu",1)[1];
            home.lblTepatWaktu3.Content = "Siswa yang hadir tepat waktu : " + presensi.HistorySiswa("Tepat Waktu",1)[2];
            home.lblTepatWaktu4.Content = "Siswa yang hadir tepat waktu : " + presensi.HistorySiswa("Tepat Waktu",1)[3];
            
            //terlambat
            home.lblTelat1.Content = "Siswa yang hadir terlambat : " + presensi.HistorySiswa("Terlambat", 1)[0];
            home.lblTelat2.Content = "Siswa yang hadir terlambat : " + presensi.HistorySiswa("Terlambat", 1)[1];
            home.lblTelat3.Content = "Siswa yang hadir terlambat : " + presensi.HistorySiswa("Terlambat", 1)[2];
            home.lblTelat4.Content = "Siswa yang hadir terlambat : " + presensi.HistorySiswa("Terlambat", 1)[3];

            //tidak hadir
            home.lblTidakHadir1.Content = "Siswa yang tidak hadir : " + presensi.HistorySiswaTidakHadir()[0];
            home.lblTidakHadir2.Content = "Siswa yang tidak hadir : " + presensi.HistorySiswaTidakHadir()[1];
            home.lblTidakHadir3.Content = "Siswa yang tidak hadir : " + presensi.HistorySiswaTidakHadir()[2];
            home.lblTidakHadir4.Content = "Siswa yang tidak hadir : " + presensi.HistorySiswaTidakHadir()[3];
        }

        public void DataSiswaTerlambat()
        {
            DataSet ds = presensi.SiswaTerlambat();
            home.dgTerlambat.ItemsSource = ds.Tables[0].DefaultView;
        }

        public void DataSiswaTidakHadir()
        {
            DataSet ds = presensi.SiswaTidakHadir();
            home.dgTidakHadir.ItemsSource = ds.Tables[0].DefaultView;
        }
    }
}

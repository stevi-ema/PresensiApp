using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace AplikasiPresensi.Model
{
    class PresensiModel
    {
        ModelTemplate temp;

        public string id { get; set; }
        public string tanggal { get; set; }
        public string jam { get; set; }
        public string nisn { get; set; }
        public string ket { get; set; }

        public PresensiModel()
        {
            temp = new ModelTemplate();
        }

        public string JumlahSiswa(string tanggal, string ket)
        {
            string result = "0";
            DataSet ds = new DataSet();
            ds = temp.SelectData("SELECT COUNT(*) FROM presensi WHERE tanggal = '"+tanggal+
                "' AND ket = '"+ket+"'", "presensi");
            result = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }

        public string JumlahSiswaTidakHadir(string tanggal)
        {
            string result = "0";
            DataSet ds = new DataSet();
            ds = temp.SelectData("SELECT COUNT(*) FROM siswa WHERE nisn NOT IN "+
                "(SELECT nisn FROM presensi WHERE tanggal = '"+tanggal+"')", "presensi");
            result = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }

        public string[] HistoryTanggal()
        {
            DataSet dsTanggal = new DataSet();
            dsTanggal = temp.SelectData("SELECT TOP 5 CONVERT(VARCHAR(9),tanggal,6) FROM presensi "+
                "GROUP BY tanggal ORDER BY tanggal DESC", "presensi");
            string[] tanggal = {"","","",""};
            tanggal[0] = dsTanggal.Tables[0].Rows[1][0].ToString();
            tanggal[1] = dsTanggal.Tables[0].Rows[2][0].ToString();
            tanggal[2] = dsTanggal.Tables[0].Rows[3][0].ToString();
            tanggal[3] = dsTanggal.Tables[0].Rows[4][0].ToString();

            return tanggal;
        }

        public string[] HistorySiswa(string ket, int kolom)
        {
            string[] result = { "0", "0", "0", "0" };
            DataSet ds = new DataSet();
            ds = temp.SelectData("SELECT COUNT(*) FROM presensi WHERE ket = '"+ket+
                "' AND tanggal = '" + HistoryTanggal()[0] + "'", "presensi");
            result[0] = ds.Tables[0].Rows[0][0].ToString();
            ds = temp.SelectData("SELECT COUNT(*) FROM presensi WHERE ket = '" + ket + 
                "' AND tanggal = '" + HistoryTanggal()[1] + "'", "presensi");
            result[1] = ds.Tables[0].Rows[0][0].ToString();
            ds = temp.SelectData("SELECT COUNT(*) FROM presensi WHERE ket = '" + ket + 
                "' AND tanggal = '" + HistoryTanggal()[2] + "'", "presensi");
            result[2] = ds.Tables[0].Rows[0][0].ToString();
            ds = temp.SelectData("SELECT COUNT(*) FROM presensi WHERE ket = '" + ket + 
                "' AND tanggal = '" + HistoryTanggal()[3] + "'", "presensi");
            result[3] = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }

        public string[] HistorySiswaTidakHadir()
        {
            string[] result = { "0", "0", "0", "0" };
            DataSet ds = new DataSet();
            ds = temp.SelectData("SELECT COUNT(*) FROM siswa WHERE nisn NOT IN "+
                "(SELECT nisn FROM presensi WHERE tanggal = '" + HistoryTanggal()[0]+"')", "presensi");
            result[0] = ds.Tables[0].Rows[0][0].ToString();
            ds = temp.SelectData("SELECT COUNT(*) FROM siswa WHERE nisn NOT IN "+
                "(SELECT nisn FROM presensi WHERE tanggal = '" + HistoryTanggal()[1] + "')", "presensi");
            result[1] = ds.Tables[0].Rows[0][0].ToString();
            ds = temp.SelectData("SELECT COUNT(*) FROM siswa WHERE nisn NOT IN "+
                "(SELECT nisn FROM presensi WHERE tanggal = '" + HistoryTanggal()[2] + "')", "presensi");
            result[2] = ds.Tables[0].Rows[0][0].ToString();
            ds = temp.SelectData("SELECT COUNT(*) FROM siswa WHERE nisn NOT IN "+
                "(SELECT nisn FROM presensi WHERE tanggal = '" + HistoryTanggal()[3] + "')", "presensi");
            result[3] = ds.Tables[0].Rows[0][0].ToString();
            return result;
        }

        public DataSet SiswaTerlambat()
        {
            string tanggal = DateTime.Now.ToString("yyyy-MM-dd");
            DataSet ds = new DataSet();
            ds = temp.SelectData("SELECT s.nisn, s.nama FROM siswa s JOIN presensi p ON s.nisn = p.nisn "+
                "WHERE p.ket = 'Terlambat' AND p.tanggal = '"+tanggal+"'","presensi");
            
            return ds;
        }

        public DataSet SiswaTidakHadir()
        {
            string tanggal = DateTime.Now.ToString("yyyy-MM-dd");
            DataSet ds = new DataSet();
            
            ds = temp.SelectData("SELECT nisn,nama FROM siswa WHERE nisn NOT IN (SELECT nisn FROM presensi "+
                "WHERE tanggal = '"+tanggal+"')","presensi");
            return ds;
        }
    }
}

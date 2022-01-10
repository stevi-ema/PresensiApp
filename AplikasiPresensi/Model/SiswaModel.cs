using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace AplikasiPresensi.Model
{
    class SiswaModel
    {
        //create object ModelTemplate
        ModelTemplate template;

        //declare var sesuai dgn field di tabel siswa
        public string nisn { get; set; }
        public string nama { get; set; }
        public string jk { get; set; }
        public string tempatLahir { get; set; }
        public string tanggalLahir { get; set; }
        public string alamat { get; set; }
        public string foto { get; set; }
        public string namaIbu { get; set; }
        public string namaAyah { get; set; }
        public string alamatOrtu { get; set; }
        public string telp { get; set; }


        //instance
        public SiswaModel()
        {
            template = new ModelTemplate();
        }

        //select & search data siswa
        public DataSet SelectSiswa(string cari)
        {
            DataSet dsSiswa = new DataSet();
            if(cari == "")
            {
                dsSiswa = template.Select("siswa", null);
            }
            else
            {
                string kondisi = "nisn LIKE '%" + cari + "%' OR nama LIKE '%" + cari + "%' OR alamat LIKE '%" + cari + "%' OR namaIbu LIKE '%" + cari + "%' OR namaAyah LIKE '%" + cari + "%' OR alamatOrtu LIKE '%" + cari + "%'";
                dsSiswa = template.Select("siswa", kondisi);
            }
            return dsSiswa;
        }

        //insert data siswa
        public bool InsertSiswa()
        {
            string data = "'"+ nisn +"','"+ nama +"','"+ jk +"','"+ tempatLahir +"','"+ tanggalLahir 
                +"','"+ alamat +"','"+ foto +"','"+ namaIbu +"','"+ namaAyah +"','"+ alamatOrtu +"','"+ telp +"'";
            return template.Insert("siswa", data);
        }

        //update data siswa
        public bool UpdateSiswa()
        {
            string tabel = "siswa";
            string data = "nama = '"+nama+"', jk='"+jk+"', tempatLahir='"+tempatLahir+"',tanggalLahir='"+tanggalLahir+"',alamat='"+alamat+"',foto='"+foto+"',namaIbu='"+namaIbu+"',namaAyah='"+namaAyah+"',alamatOrtu='"+alamatOrtu+"',telp='"+telp+"'";
            string kondisi = "nisn='"+nisn+"'";
            return template.Update(tabel, data, kondisi);
        }

        public bool DeleteSiswa()
        {
            string tabel = "siswa";
            string kondisi = "nisn='" + nisn + "'";
            return template.Delete(tabel, kondisi);
        }

    }
}

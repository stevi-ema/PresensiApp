using System;
using System.Data;
using System.Windows;

namespace AplikasiPresensi.Model
{
    class PenggunaModel
    {
        ModelTemplate temp;

        public string id { get; set; }
        public string nama { get; set; }
        public string jk { get; set; }
        public string telp { get; set; }
        public string password { get; set; }

        //cache
        public static string namaUser;

        public PenggunaModel()
        {
            temp = new ModelTemplate();
        }

        public Boolean CekLogin()
        {
            bool result;
            DataSet ds = new DataSet();
            ds = temp.Select("pengguna", "id = '" + id + "' AND password = '" + password + "'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                result = true;
                namaUser = ds.Tables[0].Rows[0][1].ToString();
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool InsertPengguna()
        {
            string data = "'"+id+"','"+nama+"','"+jk+"','"+telp+"','"+password+"'";
            return temp.Insert("pengguna", data);
        }
    }
}

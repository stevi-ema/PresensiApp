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
    /// Interaction logic for AddSiswaWindow.xaml
    /// </summary>
    public partial class TambahSiswaWindow : Window
    {
        //declare object class controller
        Controller.Siswa siswa;

        //declare object class OpenFileDialog
        private Microsoft.Win32.OpenFileDialog openFile;

        public TambahSiswaWindow()
        {
            InitializeComponent();

            //instance
            siswa = new Controller.Siswa(this);

            openFile = new Microsoft.Win32.OpenFileDialog();
        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);
        public event UpdateDelegate UpdateEventHandler;

        public class UpdateEventArgs: EventArgs
        {
            public string data { get; set; }
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
        }

        private void btnSimpan_Click(object sender, RoutedEventArgs e)
        {
            //copy gambar ke direktori yg sudah diset
            string filename = txtNISN.Text + ".jpg";
            string path = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + 
                "\\Foto\\" + filename;
            System.IO.File.Copy(openFile.FileName, path, true);

            //insert data ke dbase
            siswa.TambahSiswa();

            UpdateEventArgs args = new UpdateEventArgs();
            UpdateEventHandler.Invoke(this, args);

        }
    }
}

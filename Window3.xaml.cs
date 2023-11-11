using System.Windows;
using System.Windows.Controls;

namespace EatHealthyWPF
{
    public partial class PelacakanCairan : Window
    {
        public PelacakanCairan()
        {
            InitializeComponent();
        }

        private void CatatAsupanCairan_Click(object sender, RoutedEventArgs e)
        {
            // Ambil nilai dari TextBox jumlah air minum
            string jumlahAirMinum = TxtJumlahAirMinum.Text;

            // Ambil nilai dari ComboBox jenis minuman
            ComboBoxItem selectedJenisMinuman = (ComboBoxItem)CmbJenisMinuman.SelectedItem;
            string jenisMinuman = selectedJenisMinuman.Content.ToString();

            // Lakukan logika pencatatan asupan cairan di sini
            MessageBox.Show($"Catatan Asupan Cairan:\nJumlah: {jumlahAirMinum} ml\nJenis: {jenisMinuman}");
        }
    }
}

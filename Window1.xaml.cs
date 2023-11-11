using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EatHealthyWPF
{
    public partial class KalkulatorKesehatan : Window
    {
        public KalkulatorKesehatan()
        {
            InitializeComponent();
        }

        private void HitungButton_Click(object sender, RoutedEventArgs e)
        {

            double beratBadan = double.Parse(BeratBadanTextBox.Text);
            double tinggiBadan = double.Parse(TinggiBadanTextBox.Text);

            double hasil = HitungIndeksMassaTubuh(beratBadan, tinggiBadan);
            MessageBox.Show($"Indeks Massa Tubuh Anda adalah: {hasil}");
        }

        private double HitungIndeksMassaTubuh(double beratBadan, double tinggiBadan)
        {

            return beratBadan / (tinggiBadan * tinggiBadan);
        } 
    }
}


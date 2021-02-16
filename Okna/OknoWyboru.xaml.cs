using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy OknoWyboru.xaml
    /// </summary>
     
    // Ta klasa odpowiada za wbór oraz wyświetlenie tabeli jaką użytkownik chce zobaczyć.
    public partial class OknoWyboru : Window
    {
        
        public OknoWyboru()
        {
            InitializeComponent();
        }

        private void Pracownicy_Click(object sender, RoutedEventArgs e)
        {
           
                
                var w = Application.Current.Windows[1];
                w.Hide();
                
                Okna.TPracownicy signIn = new Okna.TPracownicy();
                signIn.ShowDialog();
                w.Show();
            

        }

        private void Gry_Click(object sender, RoutedEventArgs e)
        {
            var w = Application.Current.Windows[1];
            w.Hide();

            Okna.TGry signIn = new Okna.TGry();
            signIn.ShowDialog();
            w.Show();

        }

        private void Wypozyczenia_Click(object sender, RoutedEventArgs e)
        {

            var w = Application.Current.Windows[1];
            w.Hide();

            Wypozyczenia signIn = new Wypozyczenia();
            signIn.ShowDialog();
            w.Show();
        }

        private void Klienci_Click(object sender, RoutedEventArgs e)
        {
            var w = Application.Current.Windows[1];
            w.Hide();

            Okna.TKlienci signIn = new Okna.TKlienci();
            signIn.ShowDialog();
            w.Show();

        }

        private void Zwroty_Click(object sender, RoutedEventArgs e)
        {
            var w = Application.Current.Windows[1];
            w.Hide();

            Zwroty signIn = new Zwroty();
            signIn.ShowDialog();
            w.Show();

        }
    }
}

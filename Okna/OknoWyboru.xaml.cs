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
     
    
    public partial class OknoWyboru : Window
    {
        /// <summary>
        /// Ta klasa odpowiada za wbór oraz wyświetlenie tabeli jaką użytkownik chce zobaczyć.
        /// </summary>
        public OknoWyboru()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void Pracownicy_Click(object sender, RoutedEventArgs e)
        {


            this.Close();

            Okna.TPracownicy signIn = new Okna.TPracownicy();
                
                signIn.Show();



        }

        private void Gry_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Okna.TGry signIn = new Okna.TGry();
            
            signIn.Show();


        }

        private void Wypozyczenia_Click(object sender, RoutedEventArgs e)
        {

            this.Close();

            Wypozyczenia signIn = new Wypozyczenia();
            
            signIn.Show();

        }

        private void Klienci_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Okna.TKlienci signIn = new Okna.TKlienci();
            
            signIn.Show();

        }

        private void Zwroty_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            Zwroty signIn = new Zwroty();
            
            signIn.Show();


        }

        private void wroc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            MainWindow signIn = new MainWindow();
            signIn.Show();
        }
    }
}

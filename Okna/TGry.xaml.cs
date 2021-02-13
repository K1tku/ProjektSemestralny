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
using System.Data;

namespace ProjektSemestralny.Okna
{
    /// <summary>
    /// Logika interakcji dla klasy TGry.xaml
    /// </summary>
    public partial class TGry : Window
    {
        public String connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog = Database1.mdf; Integrated Security=True; ";
        
        public TGry()
        {
            InitializeComponent();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {

        }

        private void uaktualnij_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridGry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void updateDataGrid()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Gry.dbo", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                DataGridGry.DataContext = dtbl;
            }
        }

        private void DataGridGry_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
    }
}

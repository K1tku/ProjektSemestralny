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

        
         public String connection_String = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security = True";
        public SqlConnection connection;

        public TGry()
        {
            InitializeComponent();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            string Query = "insert into Gry (ID_gry, Nazwa, Kategoria, Kategoria_wiekowa, Data_wydania, Cena_dzien) values('" + this.iD_gryTextBox.Text + "','" + this.nazwaTextBox.Text + "','" + this.kategoriaTextBox.Text + "','" + this.kategoria_wiekowaTextBox.Text + "','" + this.data_wydaniaTextBox.Text + "','" + this.cena_dzienTextBox.Text + "');";
            SqlConnection conDataBase = new SqlConnection(connection_String);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                System.Windows.MessageBox.Show("Zapisano");
                while (myReader.Read()) { }





            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            updateDataGrid();
            
           
            //cmdDataBase.ExecuteNonQuery();
            
        }

        private void uaktualnij_Click(object sender, RoutedEventArgs e)
        {
            string Query = "update Gry set ID_gry='" + this.iD_gryTextBox.Text + "', Nazwa='" + this.nazwaTextBox.Text + "',Kategoria='" + this.kategoriaTextBox.Text + "',Kategoria_wiekowa='" + this.kategoria_wiekowaTextBox.Text + "',Data_wydania='" + this.data_wydaniaTextBox.Text + "',Cena_dzien='" + this.cena_dzienTextBox.Text + "'where ID_gry='" + this.iD_gryTextBox.Text + "'; ";
            SqlConnection conDataBase = new SqlConnection(connection_String);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                System.Windows.MessageBox.Show("Uaktualniono");
                while (myReader.Read()) { }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            updateDataGrid();
            
            conDataBase.Close();
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            string Query = "delete from Gry where ID_gry='" + this.iD_gryTextBox.Text + "';";
            SqlConnection conDataBase = new SqlConnection(connection_String);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                System.Windows.MessageBox.Show("Zapisano");
                while (myReader.Read()) { }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            updateDataGrid();
            
            conDataBase.Close();
        }

        private void DataGridGry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void updateDataGrid()
        {
            connection = new SqlConnection(connection_String); connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT ID_gry, Nazwa, Kategoria, Kategoria_wiekowa, Data_wydania, Cena_dzien from dbo.Gry";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridGry.ItemsSource = dt.DefaultView;
            dr.Close();
        }

        private void DataGridGry_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
    }
}

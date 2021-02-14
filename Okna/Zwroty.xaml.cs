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

namespace ProjektSemestralny

{
    /// <summary>
    /// Logika interakcji dla klasy Zwroty.xaml
    /// </summary>
    public partial class Zwroty : Window
    {
        //public String connection_String = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Projekty\ProjektSemestralny\Database1.mdf;Integrated Security=True";
        //public SqlConnection connection;
        public String connection_String = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security = True";
        public SqlConnection connection;
        public Zwroty()
        {
            InitializeComponent();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            string Query = "insert into Zwroty (ID_wypozyczenia, ID_pracownika, data_zwrotu, doplaty) values('" + this.iD_wypozyczeniaTextBox.Text + "','" + this.iD_pracownikaTextBox.Text + "','" + this.data_zwrotuDatePicker.Text + "','" + this.doplatyTextBox.Text + "' );";
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
        }

        private void uaktualnij_Click(object sender, RoutedEventArgs e)
        {
            string Query = "update Zwroty set ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "',ID_pracownika='" + this.iD_pracownikaTextBox.Text + "',data_zwrotu='" + this.data_zwrotuDatePicker.Text + "',doplaty='" + this.doplatyTextBox.Text + "' whereID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "';";
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
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            string Query = "delete from Zwroty  where ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "';";
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
        }

        private void DataGridZwroty_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
        private void updateDataGrid()
        {  //pobieranie danych z bazy i wyswietlenie w DataGrid
            connection = new SqlConnection(connection_String); connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            //zapytanie sql
            cmd.CommandText = "SELECT ID_wypozyczenia, ID_pracownika, data_zwrotu, doplaty from dbo.Zwroty";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridZwroty.ItemsSource = dt.DefaultView;
            dr.Close();
        }
    }
}

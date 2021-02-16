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
    /// Logika interakcji dla klasy Wypozyczenia.xaml
    /// </summary>
    public partial class Wypozyczenia : Window
    {
        //public String connection_String = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Projekty\ProjektSemestralny\Database1.mdf;Integrated Security=True";
        //public SqlConnection connection;
        public String connection_String = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security = True";
        public SqlConnection connection;
        public Wypozyczenia()
        {
            InitializeComponent();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            string Query = "insert into Wypozyczenia (ID_wypozyczenia, ID_Gry, ID_pracownika, ID_klienta, Data_wypozyczenia) values('" + this.iD_wypozyczeniaTextBox.Text + "','" + this.iD_GryTextBox.Text + "','" + this.iD_pracownikaTextBox.Text + "','" + this.iD_klientaTextBox.Text + "','" + this.data_wypozyczeniaDatePicker.Text + "');";
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
            string Query = "update Wypozyczenia set ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "',ID_Gry='" + this.iD_GryTextBox.Text + "',ID_pracownika='" + this.iD_pracownikaTextBox.Text + "',ID_klienta='" + this.iD_klientaTextBox.Text + "',ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "'where ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "';";
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
            string Query = "delete from Wypozyczenia where ID_wypozyczenia='" + this.iD_wypozyczeniaTextBox.Text + "';";
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

        private void DataGridWypozyczenia_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
        private void updateDataGrid()
        {
            connection = new SqlConnection(connection_String); connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT ID_wypozyczenia, ID_Gry, ID_pracownika, ID_klienta, Data_wypozyczenia from dbo.Wypozyczenia";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridWypozyczenia.ItemsSource = dt.DefaultView;
            dr.Close();
        }
    }
}

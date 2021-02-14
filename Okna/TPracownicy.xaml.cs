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
    /// Logika interakcji dla klasy TPracownicy.xaml
    /// </summary>
    public partial class TPracownicy : Window
    {
        //public String connection_String = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\Projekty\ProjektSemestralny\Database1.mdf;Integrated Security=True";
        //public SqlConnection connection;
        public String connection_String = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security = True";
        public SqlConnection connection;
        public TPracownicy()
        {
            InitializeComponent();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            string Query = "insert into Pracownicy (ID_pracownika, Imie, Nazwisko, Data_urodzenia, Adres, Stanowisko) values('" + this.iD_pracownikaTextBox.Text + "','" + this.imieTextBox.Text + "','" + this.nazwiskoTextBox.Text + "','" + this.data_urodzeniaDatePicker.Text + "','" + this.adresTextBox.Text + "','" + this.stanowiskoTextBox.Text + "');";
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
            string Query = "update Pracownicy set ID_pracownika='" + this.iD_pracownikaTextBox.Text + "',Imie='" + this.imieTextBox.Text + "',Nazwisko='" + this.nazwiskoTextBox.Text + "',Data_urodzenia='" + this.data_urodzeniaDatePicker.Text + "',Adres='" + this.adresTextBox.Text + "',Stanowisko='" + this.stanowiskoTextBox.Text + "' where ID_pracownika='" + this.iD_pracownikaTextBox.Text + "';";
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
            string Query = "delete from Pracownicy where ID_pracownika='" + this.iD_pracownikaTextBox.Text + "';";
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

        private void DataGridPracownicy_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
        private void updateDataGrid()
        {   //pobieranie danych z bazy i wyswietlenie w DataGrid
            connection = new SqlConnection(connection_String); connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT ID_pracownika,Imie, Nazwisko, Data_urodzenia, Adres, Stanowisko from dbo.Pracownicy";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridPracownicy.ItemsSource = dt.DefaultView;
            dr.Close();
        }
    }
}

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
    /// Logika interakcji dla klasy TKlienci.xaml
    /// </summary>
    
    
    public partial class TKlienci : Window
    {
        /// <summary>
        /// Dodanie conneciot_String do połączenia.
        /// </summary>
        public String connection_String = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security = True";
        /// <summary>
        /// Łączenie się z baza danych.
        /// </summary>
        public SqlConnection connection;
        /// <summary>
        /// Ta klasa odpowiada za połączenie się z baza danych.
        /// Wyświetla tabele "Klienci" w DataGrid.
        /// Pozwala modyfikować, dodawać oraz usuwać rekordy w bazie danych.
        /// </summary>
        public TKlienci()
        {
            InitializeComponent();
        }

        private void dodaj_Click(object sender, RoutedEventArgs e)
        {
            string Query = "insert into Klienci (ID_klienta, Nazwisko, Imie, Adres, Kod_pocztowy, Data_urodzenia, Numer_DO) values('" + this.iD_klientaTextBox.Text + "','" + this.nazwiskoTextBox.Text + "','" + this.imieTextBox.Text + "','" + this.adresTextBox.Text + "','" + this.kod_pocztowyTextBox.Text + "','" + this.data_urodzeniaDatePicker + "','" + this.numer_DOTextBox.Text + "');";
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
            string Query = "update Klienci set ID_klienta='" + this.iD_klientaTextBox.Text + "',Nazwisko='" + this.nazwiskoTextBox.Text + "',Imie='" + this.imieTextBox.Text + "',Adres='" + this.adresTextBox.Text + "',Kod_pocztowy='" + this.kod_pocztowyTextBox.Text + "',Data_urodzenia='" + this.data_urodzeniaDatePicker + "',Numer_DO='" + this.numer_DOTextBox.Text + "' where ID_klienta='" + this.iD_klientaTextBox.Text + "';";
            SqlConnection conDataBase = new SqlConnection(connection_String);
            SqlCommand cmdDataBase = new SqlCommand(Query, conDataBase);
            SqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                System.Windows.MessageBox.Show("Uaktualnione");
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
            string Query = "delete from Klienci  where ID_klienta='" + this.iD_klientaTextBox.Text + "';";
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

        private void DataGridKlienci_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
        private void updateDataGrid()
        {

            connection = new SqlConnection(connection_String); connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT ID_klienta, Nazwisko, Imie, Adres, Kod_pocztowy, Data_urodzenia, Numer_DO from dbo.Klienci";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridKlienci.ItemsSource = dt.DefaultView;
            dr.Close();
        }
    }
}

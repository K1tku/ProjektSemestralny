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
        #region connection_String
    /// <summary>
    /// Dodanie conneciot_String do połączenia.
    /// </summary>
    public String connection_String = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security = True";
        /// <summary>
        /// Łączenie się z baza danych.
        /// </summary>
        public SqlConnection connection;
        #endregion

        #region Zwroty
        /// <summary>
        /// Ta klasa odpowiada za połączenie się z baza danych.
        /// Wyświetla tabele "Zwroty" w DataGrid.
        /// Pozwala modyfikować, dodawać oraz usuwać rekordy w bazie danych.
        /// </summary>
        public Zwroty()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }
        #endregion

        #region dodaj_Click
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
        #endregion

        #region uaktualnij_Click
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
        #endregion

        #region Usun_Click
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
        #endregion

        #region DataGridZwroty_Loaded
        private void DataGridZwroty_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }
        #endregion

        #region updateDataGrid
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
        #endregion

        #region wroc_Click
        private void wroc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            OknoWyboru signIn = new OknoWyboru();
            signIn.Show();
        }
        #endregion
    }
}

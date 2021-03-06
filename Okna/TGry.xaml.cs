﻿using System;
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
        #region Connection_String
        /// <summary>
        /// Dodanie conneciot_String do połączenia.
        /// </summary>
        public String connection_String = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security = True";
        /// <summary>
        /// Łączenie się z baza danych.
        /// </summary>
        public SqlConnection connection;
        #endregion

        #region TGry
        /// <summary>
        /// Ta klasa odpowiada za połączenie się z baza danych.
        /// Wyświetla tabele "Gry" w DataGrid.
        /// Pozwala modyfikować, dodawać oraz usuwać rekordy w bazie danych.
        /// </summary>
        public TGry()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            
        }
        #endregion

        #region dodaj_Click
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
                while (myReader.Read()) { };
                


            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            conDataBase.Close();
            updateDataGrid();
            
        }
        #endregion

        #region uaktualnij_Click
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
            conDataBase.Close();
            updateDataGrid();
            
            conDataBase.Close();
        }
        #endregion

        #region Usun_Click
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
            conDataBase.Close();
            updateDataGrid();
            
            conDataBase.Close();
        }
        #endregion

        #region updateDataGrid
        private void updateDataGrid()
        {
            connection = new SqlConnection(connection_String);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT ID_gry, Nazwa, Kategoria, Kategoria_wiekowa, Data_wydania, Cena_dzien from dbo.Gry";
            cmd.CommandType = CommandType.Text;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataGridGry.ItemsSource = dt.DefaultView;
            dr.Close();
            connection.Close();
        }
        #endregion

        #region DataGridGry_Loaded
        private void DataGridGry_Loaded(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
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

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace ProjektSemestralny
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Zaloguj_Click(object sender, RoutedEventArgs e)
        {
            string uzytkownik = this.nazwau.Text;
            string haslo = this.haslou.Password;

            if (SprawdzNazweiHaslo(uzytkownik, haslo))
            {

                var w = Application.Current.Windows[0];
                w.Hide();

                OknoWyboru signIn = new OknoWyboru();
                signIn.ShowDialog();
                w.Show();
            }
            else
            {
                MessageBox.Show("Niepoprawne dane");
                return;
            }
        }
        public bool SprawdzNazweiHaslo(string uzytkownik, string haslo)
        {
            if (uzytkownik == "user" & haslo == "user")
                return true;
            else
            {
                return false;
            }
            
        }



    }
}

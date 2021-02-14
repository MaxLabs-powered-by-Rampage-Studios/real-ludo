using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;

namespace Amazing_Ludo
{
    public partial class Page6 : PhoneApplicationPage
    {
        public Page6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are You Sure ?", "Select", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                MainPage.coin = 0;
                MainPage.kill = 0;
                MainPage.board = "/Amazing Ludo;component/Images/Board1.png";
                MainPage.boardstat = new int[11] { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                MainPage.miles = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                MainPage.select = null;
                IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
                gets["Coin"] = MainPage.coin;
                gets["Kill"] = MainPage.kill;
                gets["Board"] = MainPage.board;
                gets["BoardStatus"] = MainPage.boardstat;
                gets["Miles"] = MainPage.miles;
                gets["Select"] = MainPage.select;
                //For Testing Use These Lines and comment rest all lines
                //MainPage.coin += 1000;
                //MainPage.kill = 21000;
                //MainPage.miles = new int[8] { 1, 1, 1, 1, 1, 1, 1, 1 };
                //IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
                //gets["Coin"] = MainPage.coin;
                //gets["Kill"] = MainPage.kill;
                //gets["Miles"] = MainPage.miles;
            }
        }
    }
}
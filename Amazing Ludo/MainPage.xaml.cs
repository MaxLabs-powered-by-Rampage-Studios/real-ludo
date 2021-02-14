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
    public partial class MainPage : PhoneApplicationPage
    {
        //Universal Variables

        public static int resume, coin, kill;
        public static int[] miles, boardstat;
        public static string[] select;
        public static string board;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
            if (gets.TryGetValue<int>("Resume", out resume))
            {
                textBlock1.Visibility = System.Windows.Visibility.Visible;
            }
            else if (resume == 1)
            {
                textBlock1.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                textBlock1.Visibility = System.Windows.Visibility.Collapsed;
            }
            if (!(gets.TryGetValue<string[]>("Select", out select)))
            {
                select = null;
            }
            if (!(gets.TryGetValue<string>("Board", out board)))
            {
                board = "/Amazing Ludo;component/Images/Board1.png";
            }
            if (!(gets.TryGetValue<int[]>("BoardStatus", out boardstat)))
            {
                boardstat = new int[11] { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            }
            if (!(gets.TryGetValue<int>("Coin", out coin)))
            {
                coin = 0;
            }
            if (!(gets.TryGetValue<int[]>("Milestone", out miles)))
            {
                miles = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
                gets["Milestone"] = miles;
                gets.Save();
            }
            if (!(gets.TryGetValue<int>("Kill", out kill)))
            {
                kill = 0;
                gets["Kill"] = kill;
                gets.Save();
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (resume == 1)
            {
                textBlock1.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                textBlock1.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
        
        private void textBlock5_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page7.xaml", UriKind.Relative));
        }

        private void textBlock4_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page6.xaml", UriKind.Relative));
        }

        private void textBlock3_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page4.xaml", UriKind.Relative));
        }

        private void textBlock2_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
            resume = 0;
            IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
            gets["Resume"] = resume;
            gets.Save();
        }

        private void textBlock1_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
        }
    }
}
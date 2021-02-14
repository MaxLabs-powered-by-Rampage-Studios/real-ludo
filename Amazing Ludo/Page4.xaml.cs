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

namespace Amazing_Ludo
{
    public partial class Page4 : PhoneApplicationPage
    {
        public Page4()
        {
            InitializeComponent();

            textBlock4.Text = MainPage.coin.ToString();
        }

        private void textBlock1_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/page5.xaml",UriKind.Relative));
        }

        private void textBlock2_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PivotPage1.xaml", UriKind.Relative));
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            textBlock4.Text = MainPage.coin.ToString();
        }
    }
}
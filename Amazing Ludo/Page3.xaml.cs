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
    public partial class Page3 : PhoneApplicationPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            int i;

            if (MainPage.resume == 1)
            {
                NavigationService.RemoveBackEntry();
                MainPage.resume = 0;
            }
            else
            {
                NavigationService.RemoveBackEntry();
            }

            if (MainPage.select[Page2.stand[0]] == "1")
            {
                textBlock1.Text = "Player Won";
            }
            else
            {
                textBlock1.Text = "Computer Won";
            }

            switch (Page2.stand[0])
            {
                case 0:
                    textBlock2.Text = "Red";
                    break;
                case 1:
                    textBlock2.Text = "Green";
                    break;
                case 2:
                    textBlock2.Text = "Yellow";
                    break;
                case 3:
                    textBlock2.Text = "Blue";
                    break;
            }
            if (Page2.stand[1] == -1)
            {
                for (i = 0; i < 4; i++)
                {
                    if (i != Page2.stand[0])
                    {
                        if (MainPage.select[i] == "1" || MainPage.select[i] == "-1")
                        {
                            switch (i)
                            {
                                case 0:
                                    textBlock3.Text = "Red";
                                    break;
                                case 1:
                                    textBlock3.Text = "Green";
                                    break;
                                case 2:
                                    textBlock3.Text = "Yellow";
                                    break;
                                case 3:
                                    textBlock3.Text = "Blue";
                                    break;
                            }
                        }
                    }
                }
                textBlock4.Visibility = System.Windows.Visibility.Collapsed;
                image3.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                switch (Page2.stand[1])
                {
                    case 0:
                        textBlock3.Text = "Red";
                        break;
                    case 1:
                        textBlock3.Text = "Green";
                        break;
                    case 2:
                        textBlock3.Text = "Yellow";
                        break;
                    case 3:
                        textBlock3.Text = "Blue";
                        break;
                }
                textBlock4.Visibility = System.Windows.Visibility.Visible;
                image3.Visibility = System.Windows.Visibility.Visible;
                if (Page2.stand[2] == -1)
                {
                    for (i = 0; i < 4 && i != Page2.stand[0] && i != Page2.stand[1]; i++)
                    {
                        if (i != Page2.stand[0] && i != Page2.stand[1])
                        {
                            if (MainPage.select[i] == "1" || MainPage.select[i] == "-1")
                            {
                                switch (i)
                                {
                                    case 0:
                                        textBlock4.Text = "Red";
                                        break;
                                    case 1:
                                        textBlock4.Text = "Green";
                                        break;
                                    case 2:
                                        textBlock4.Text = "Yellow";
                                        break;
                                    case 3:
                                        textBlock4.Text = "Blue";
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    switch (Page2.stand[2])
                    {
                        case 0:
                            textBlock4.Text = "Red";
                            break;
                        case 1:
                            textBlock4.Text = "Green";
                            break;
                        case 2:
                            textBlock4.Text = "Yellow";
                            break;
                        case 3:
                            textBlock4.Text = "Blue";
                            break;
                    }
                }
            }

            Page2.stand = new int[4] { -1, -1, -1, -1 };
            IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
            gets["Stand"] = Page2.stand;
            gets.Save();
        }
    }
}
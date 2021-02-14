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
    public partial class Page1 : PhoneApplicationPage
    {
        //Local Variable
        string[] str;

        public Page1()
        {
            InitializeComponent();
            
            if (MainPage.select == null)
            {
                str = new string[] { "0", "0", "0", "0" };
            }
            else
            {
                str = new string[4];
                str = MainPage.select;
            }

            for (int i = 0; i < 4; i++)
            {
                if (str[i] == "0")
                {
                    switch (i+1)
                    {
                        case 1: checkBox1.IsChecked = false;
                            rectangle1.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                        case 2: checkBox2.IsChecked = false;
                            rectangle2.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                        case 3: checkBox3.IsChecked = false;
                            rectangle3.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                        case 4: checkBox4.IsChecked = false;
                            rectangle4.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                    }                         
                }
                else if (str[i] == "1")
                {
                    switch(i+1)
                    {
                        case 1:checkBox1.IsChecked = true;
                            rectangle1.Margin = new Thickness(328, 84, 0, 0);
                            rectangle1.Width = 100;
                            break;
                        case 2:checkBox2.IsChecked = true;
                            rectangle2.Margin = new Thickness(328, 165, 0, 0);
                            rectangle2.Width = 100;
                            break;
                        case 3:checkBox3.IsChecked = true;
                            rectangle3.Margin = new Thickness(328, 247, 0, 0);
                            rectangle3.Width = 100;
                            break;
                        case 4:checkBox4.IsChecked = true;
                            rectangle4.Margin = new Thickness(328, 329, 0, 0);
                            rectangle4.Width = 100;
                            break;                        
                    }
                }
                else if (str[i] == "-1")
                {
                    switch (i+1)
                    {
                        case 1: checkBox1.IsChecked = true;
                            rectangle1.Margin = new Thickness(174, 84, 0, 0);
                            rectangle1.Width = 134;
                            break;
                        case 2: checkBox2.IsChecked = true;
                            rectangle2.Margin = new Thickness(174, 165, 0, 0);
                            rectangle2.Width = 134;
                            break;
                        case 3: checkBox3.IsChecked = true;
                            rectangle3.Margin = new Thickness(174, 247, 0, 0);
                            rectangle3.Width = 134;
                            break;
                        case 4: checkBox4.IsChecked = true;
                            rectangle4.Margin = new Thickness(174, 329, 0, 0);
                            rectangle4.Width = 134;
                            break;
                    }
                }
            }
        }

        private void checkBox4_Checked(object sender, RoutedEventArgs e)
        {
            if (str[3] == "0")
            {
                rectangle4.Visibility = System.Windows.Visibility.Visible;
                rectangle4.Margin = new Thickness(174, 329, 0, 0);
                rectangle4.Width = 134;
                str[3] = "-1";
            }
        }

        private void checkBox3_Checked(object sender, RoutedEventArgs e)
        {
            if (str[2] == "0")
            {
                rectangle3.Visibility = System.Windows.Visibility.Visible;
                rectangle3.Margin = new Thickness(174, 247, 0, 0);
                rectangle3.Width = 134;
                str[2] = "-1";
            }
        }

        private void checkBox2_Checked(object sender, RoutedEventArgs e)
        {
            if (str[1] == "0")
            {
                rectangle2.Visibility = System.Windows.Visibility.Visible;
                rectangle2.Margin = new Thickness(174, 165, 0, 0);
                rectangle2.Width = 134;
                str[1] = "-1";
            }
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {
            if (str[0] == "0")
            {
                rectangle1.Visibility = System.Windows.Visibility.Visible;
                rectangle1.Margin = new Thickness(174, 84, 0, 0);
                rectangle1.Width = 134;
                str[0] = "-1";
            }
        }

        private void checkBox1_Unchecked(object sender, RoutedEventArgs e)
        {
            rectangle1.Visibility = System.Windows.Visibility.Collapsed;
            str[0] = "0";
        }

        private void checkBox2_Unchecked(object sender, RoutedEventArgs e)
        {
            rectangle2.Visibility = System.Windows.Visibility.Collapsed;
            str[1] = "0";
        }

        private void checkBox3_Unchecked(object sender, RoutedEventArgs e)
        {
            rectangle3.Visibility = System.Windows.Visibility.Collapsed;
            str[2] = "0";
        }

        private void checkBox4_Unchecked(object sender, RoutedEventArgs e)
        {
            rectangle4.Visibility = System.Windows.Visibility.Collapsed;
            str[3] = "0";
        }

        private void textBlock1_Tap(object sender, GestureEventArgs e)
        {
            if (checkBox1.IsChecked == true)
            {
                rectangle1.Width = 100;
                rectangle1.Margin = new Thickness(328, 84, 0, 0);
                str[0] = "1";
            }
        }

        private void textBlock2_Tap(object sender, GestureEventArgs e)
        {
            if (checkBox2.IsChecked == true)
            {
                rectangle2.Width = 100;
                rectangle2.Margin = new Thickness(328, 165, 0, 0);
                str[1] = "1";
            }
        }

        private void textBlock3_Tap(object sender, GestureEventArgs e)
        {
            if (checkBox3.IsChecked == true)
            {
                rectangle3.Width = 100;
                rectangle3.Margin = new Thickness(328, 247, 0, 0);
                str[2] = "1";
            }
        }

        private void textBlock4_Tap(object sender, GestureEventArgs e)
        {
            if (checkBox4.IsChecked == true)
            {
                rectangle4.Width = 100;
                rectangle4.Margin = new Thickness(328, 329, 0, 0);
                str[3] = "1";
            }
        }

        private void textBlock5_Tap(object sender, GestureEventArgs e)
        {
            if (checkBox1.IsChecked == true)
            {
                rectangle1.Width = 134;
                rectangle1.Margin = new Thickness(174, 84, 0, 0);
                str[0] = "-1";
            }
        }

        private void textBlock6_Tap(object sender, GestureEventArgs e)
        {
            if (checkBox2.IsChecked == true)
            {
                rectangle2.Width = 134;
                rectangle2.Margin = new Thickness(174, 165, 0, 0);
                str[1] = "-1";
            }
        }

        private void textBlock7_Tap(object sender, GestureEventArgs e)
        {
            if (checkBox3.IsChecked == true)
            {
                rectangle3.Width = 134;
                rectangle3.Margin = new Thickness(174, 247, 0, 0);
                str[2] = "-1";
            }
        }

        private void textBlock8_Tap(object sender, GestureEventArgs e)
        {
            if (checkBox4.IsChecked == true)
            {
                rectangle4.Width = 134;
                rectangle4.Margin = new Thickness(174, 329, 0, 0);
                str[3] = "-1";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int i, flag = 0, x = 0;
            for (i = 0; i < 4; i++)
            {
                if (str[i] == "-1" || str[i] == "0")
                {
                    flag++;
                }
                if (str[i] == "0")
                {
                    x++;
                }
            }
            if (x == 3 || flag == 4)
            {
                textBlock9.Text = "Select a player";
            }
            else
            {
                MainPage.select = str;
                IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
                gets["Select"] = MainPage.select;
                gets.Save();
                NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
            }
        }
    }
}
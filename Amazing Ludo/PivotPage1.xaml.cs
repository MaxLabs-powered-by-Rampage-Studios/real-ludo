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
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;

namespace Amazing_Ludo
{
    public partial class PivotPage1 : PhoneApplicationPage
    {
        int i;

        public PivotPage1()
        {
            InitializeComponent();

            textBlock1.Text = MainPage.coin.ToString();

            for (i = 0; i < 11; i++)
            {
                if (MainPage.boardstat[i] == 0)
                {
                    switch (i)
                    {
                        case 1 :
                            button2.Content = "Unlock";
                            button2.IsEnabled = true;
                            image3.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Lock1.png", UriKind.Relative));
                            break;
                        case 2:
                            button3.Content = "Unlock";
                            button3.IsEnabled = true;
                            image4.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Lock2.png", UriKind.Relative));
                            break;
                        case 3:
                            button4.Content = "Unlock";
                            button4.IsEnabled = true;
                            image5.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Lock3.png", UriKind.Relative));
                            break;
                        case 4:
                            button5.Content = "Unlock";
                            button5.IsEnabled = true;
                            image6.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Lock4.png", UriKind.Relative));
                            break;
                        case 5:
                            button6.Content = "Unlock";
                            button6.IsEnabled = true;
                            image7.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Lock5.png", UriKind.Relative));
                            break;
                        case 6:
                            button7.Content = "Unlock";
                            button7.IsEnabled = true;
                            image8.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Lock6.png", UriKind.Relative));
                            break;
                        case 7:
                            button8.Content = "Unlock";
                            button8.IsEnabled = true;
                            image9.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Lock7.png", UriKind.Relative));
                            break;
                        case 8:
                            button9.Content = "Unlock";
                            button9.IsEnabled = true;
                            image10.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Lock8.png", UriKind.Relative));
                            break;
                        case 9:
                            button10.Content = "Unlock";
                            button10.IsEnabled = true;
                            image11.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Lock9.png", UriKind.Relative));
                            break;
                        case 10:
                            button11.Content = "Unlock";
                            button11.IsEnabled = true;
                            image12.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Lock10.png", UriKind.Relative));
                            break;
                    }
                }
                else if (MainPage.boardstat[i] == 1)
                {
                    switch (i)
                    {
                        case 0:
                            button1.Content = "Apply";
                            button1.IsEnabled = true;
                            image2.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board1.png", UriKind.Relative));
                            break;
                        case 1:
                            button2.Content = "Apply";
                            button2.IsEnabled = true;
                            image3.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board2.png", UriKind.Relative));
                            break;
                        case 2:
                            button3.Content = "Apply";
                            button3.IsEnabled = true;
                            image4.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board3.png", UriKind.Relative));
                            break;
                        case 3:
                            button4.Content = "Apply";
                            button4.IsEnabled = true;
                            image5.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board4.png", UriKind.Relative));
                            break;
                        case 4:
                            button5.Content = "Apply";
                            button5.IsEnabled = true;
                            image6.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board5.png", UriKind.Relative));
                            break;
                        case 5:
                            button6.Content = "Apply";
                            button6.IsEnabled = true;
                            image7.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board6.png", UriKind.Relative));
                            break;
                        case 6:
                            button7.Content = "Apply";
                            button7.IsEnabled = true;
                            image8.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board7.png", UriKind.Relative));
                            break;
                        case 7:
                            button8.Content = "Apply";
                            button8.IsEnabled = true;
                            image9.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board8.png", UriKind.Relative));
                            break;
                        case 8:
                            button9.Content = "Apply";
                            button9.IsEnabled = true;
                            image10.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board9.png", UriKind.Relative));
                            break;
                        case 9:
                            button10.Content = "Apply";
                            button10.IsEnabled = true;
                            image11.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board10.png", UriKind.Relative));
                            break;
                        case 10:
                            button11.Content = "Apply";
                            button11.IsEnabled = true;
                            image12.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board11.png", UriKind.Relative));
                            break;
                    }
                }
                else if (MainPage.boardstat[i] == 2)
                {
                    switch (i)
                    {
                        case 0:
                            button1.Content = "Apply";
                            button1.IsEnabled = false;
                            image2.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board1.png", UriKind.Relative));
                            break;
                        case 1:
                            button2.Content = "Apply";
                            button2.IsEnabled = false;
                            image3.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board2.png", UriKind.Relative));
                            break;
                        case 2:
                            button3.Content = "Apply";
                            button3.IsEnabled = false;
                            image4.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board3.png", UriKind.Relative));
                            break;
                        case 3:
                            button4.Content = "Apply";
                            button4.IsEnabled = false;
                            image5.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board4.png", UriKind.Relative));
                            break;
                        case 4:
                            button5.Content = "Apply";
                            button5.IsEnabled = false;
                            image6.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board5.png", UriKind.Relative));
                            break;
                        case 5:
                            button6.Content = "Apply";
                            button6.IsEnabled = false;
                            image7.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board6.png", UriKind.Relative));
                            break;
                        case 6:
                            button7.Content = "Apply";
                            button7.IsEnabled = false;
                            image8.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board7.png", UriKind.Relative));
                            break;
                        case 7:
                            button8.Content = "Apply";
                            button8.IsEnabled = false;
                            image9.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board8.png", UriKind.Relative));
                            break;
                        case 8:
                            button9.Content = "Apply";
                            button9.IsEnabled = false;
                            image10.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board9.png", UriKind.Relative));
                            break;
                        case 9:
                            button10.Content = "Apply";
                            button10.IsEnabled = false;
                            image11.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board10.png", UriKind.Relative));
                            break;
                        case 10:
                            button11.Content = "Apply";
                            button11.IsEnabled = false;
                            image12.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board11.png", UriKind.Relative));
                            break;
                    }
                }
            }

            this.BackKeyPress += new EventHandler<System.ComponentModel.CancelEventArgs>(PivotPage1_BackKeyPress);
        }

        void PivotPage1_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
            gets["Coin"] = MainPage.coin;
            gets["BoardStatus"] = MainPage.boardstat;
            gets["Board"] = MainPage.board;
            gets.Save();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            for (i = 0; i < 11; i++)
            {
                if (MainPage.boardstat[i] == 2)
                {
                    MainPage.boardstat[i] = 1;
                    switch (i)
                    {
                        case 0:
                            button1.IsEnabled = true;
                            break;
                        case 1:
                            button2.IsEnabled = true;
                            break;
                        case 2:
                            button3.IsEnabled = true;
                            break;
                        case 3:
                            button4.IsEnabled = true;
                            break;
                        case 4:
                            button5.IsEnabled = true;
                            break;
                        case 5:
                            button6.IsEnabled = true;
                            break;
                        case 6:
                            button7.IsEnabled = true;
                            break;
                        case 7:
                            button8.IsEnabled = true;
                            break;
                        case 8:
                            button9.IsEnabled = true;
                            break;
                        case 9:
                            button10.IsEnabled = true;
                            break;
                        case 10:
                            button11.IsEnabled = true;
                            break;
                    }
                }
            }
            button1.IsEnabled = false;
            MainPage.board = "/Amazing%20Ludo;component/Images/Board1.png";
            MainPage.boardstat[0] = 2;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.boardstat[1] == 0)
            {
                if (MainPage.coin >= 50)
                {
                    button2.Content = "Apply";
                    MainPage.coin -= 50;
                    image3.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board2.png", UriKind.Relative));
                    MainPage.boardstat[1] = 1;
                    textBlock1.Text = MainPage.coin.ToString();
                }
            }
            else if (MainPage.boardstat[1] == 1)
            {
                for (i = 0; i < 11; i++)
                {
                    if (MainPage.boardstat[i] == 2)
                    {
                        MainPage.boardstat[i] = 1;
                        switch (i)
                        {
                            case 0:
                                button1.IsEnabled = true;
                                break;
                            case 1:
                                button2.IsEnabled = true;
                                break;
                            case 2:
                                button3.IsEnabled = true;
                                break;
                            case 3:
                                button4.IsEnabled = true;
                                break;
                            case 4:
                                button5.IsEnabled = true;
                                break;
                            case 5:
                                button6.IsEnabled = true;
                                break;
                            case 6:
                                button7.IsEnabled = true;
                                break;
                            case 7:
                                button8.IsEnabled = true;
                                break;
                            case 8:
                                button9.IsEnabled = true;
                                break;
                            case 9:
                                button10.IsEnabled = true;
                                break;
                            case 10:
                                button11.IsEnabled = true;
                                break;
                        }
                    }
                }
                button2.IsEnabled = false;
                MainPage.board = "/Amazing%20Ludo;component/Images/Board2.png";
                MainPage.boardstat[1] = 2;
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.boardstat[2] == 0)
            {
                if (MainPage.coin >= 100)
                {
                    button3.Content = "Apply";
                    MainPage.coin -= 100;
                    image4.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board3.png", UriKind.Relative));
                    MainPage.boardstat[2] = 1;
                    textBlock1.Text = MainPage.coin.ToString();
                }
            }
            else if (MainPage.boardstat[2] == 1)
            {
                for (i = 0; i < 11; i++)
                {
                    if (MainPage.boardstat[i] == 2)
                    {
                        MainPage.boardstat[i] = 1;
                        switch (i)
                        {
                            case 0:
                                button1.IsEnabled = true;
                                break;
                            case 1:
                                button2.IsEnabled = true;
                                break;
                            case 2:
                                button3.IsEnabled = true;
                                break;
                            case 3:
                                button4.IsEnabled = true;
                                break;
                            case 4:
                                button5.IsEnabled = true;
                                break;
                            case 5:
                                button6.IsEnabled = true;
                                break;
                            case 6:
                                button7.IsEnabled = true;
                                break;
                            case 7:
                                button8.IsEnabled = true;
                                break;
                            case 8:
                                button9.IsEnabled = true;
                                break;
                            case 9:
                                button10.IsEnabled = true;
                                break;
                            case 10:
                                button11.IsEnabled = true;
                                break;
                        }
                    }
                }
                button3.IsEnabled = false;
                MainPage.board = "/Amazing%20Ludo;component/Images/Board3.png";
                MainPage.boardstat[2] = 2;
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.boardstat[3] == 0)
            {
                if (MainPage.coin >= 200)
                {
                    button4.Content = "Apply";
                    MainPage.coin -= 200;
                    image5.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board4.png", UriKind.Relative));
                    MainPage.boardstat[3] = 1;
                    textBlock1.Text = MainPage.coin.ToString();
                }
            }
            else if (MainPage.boardstat[3] == 1)
            {
                for (i = 0; i < 11; i++)
                {
                    if (MainPage.boardstat[i] == 2)
                    {
                        MainPage.boardstat[i] = 1;
                        switch (i)
                        {
                            case 0:
                                button1.IsEnabled = true;
                                break;
                            case 1:
                                button2.IsEnabled = true;
                                break;
                            case 2:
                                button3.IsEnabled = true;
                                break;
                            case 3:
                                button4.IsEnabled = true;
                                break;
                            case 4:
                                button5.IsEnabled = true;
                                break;
                            case 5:
                                button6.IsEnabled = true;
                                break;
                            case 6:
                                button7.IsEnabled = true;
                                break;
                            case 7:
                                button8.IsEnabled = true;
                                break;
                            case 8:
                                button9.IsEnabled = true;
                                break;
                            case 9:
                                button10.IsEnabled = true;
                                break;
                            case 10:
                                button11.IsEnabled = true;
                                break;
                        }
                    }
                }
                button4.IsEnabled = false;
                MainPage.board = "/Amazing%20Ludo;component/Images/Board4.png";
                MainPage.boardstat[3] = 2;
            }
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.boardstat[4] == 0)
            {
                if (MainPage.coin >= 500)
                {
                    button5.Content = "Apply";
                    MainPage.coin -= 500;
                    image6.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board5.png", UriKind.Relative));
                    MainPage.boardstat[4] = 1;
                    textBlock1.Text = MainPage.coin.ToString();
                }
            }
            else if (MainPage.boardstat[4] == 1)
            {
                for (i = 0; i < 11; i++)
                {
                    if (MainPage.boardstat[i] == 2)
                    {
                        MainPage.boardstat[i] = 1;
                        switch (i)
                        {
                            case 0:
                                button1.IsEnabled = true;
                                break;
                            case 1:
                                button2.IsEnabled = true;
                                break;
                            case 2:
                                button3.IsEnabled = true;
                                break;
                            case 3:
                                button4.IsEnabled = true;
                                break;
                            case 4:
                                button5.IsEnabled = true;
                                break;
                            case 5:
                                button6.IsEnabled = true;
                                break;
                            case 6:
                                button7.IsEnabled = true;
                                break;
                            case 7:
                                button8.IsEnabled = true;
                                break;
                            case 8:
                                button9.IsEnabled = true;
                                break;
                            case 9:
                                button10.IsEnabled = true;
                                break;
                            case 10:
                                button11.IsEnabled = true;
                                break;
                        }
                    }
                }
                button5.IsEnabled = false;
                MainPage.board = "/Amazing%20Ludo;component/Images/Board5.png";
                MainPage.boardstat[4] = 2;
            }
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.boardstat[5] == 0)
            {
                if (MainPage.coin >= 700)
                {
                    button6.Content = "Apply";
                    MainPage.coin -= 700;
                    image7.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board6.png", UriKind.Relative));
                    MainPage.boardstat[5] = 1;
                    textBlock1.Text = MainPage.coin.ToString();
                }
            }
            else if (MainPage.boardstat[5] == 1)
            {
                for (i = 0; i < 11; i++)
                {
                    if (MainPage.boardstat[i] == 2)
                    {
                        MainPage.boardstat[i] = 1;
                        switch (i)
                        {
                            case 0:
                                button1.IsEnabled = true;
                                break;
                            case 1:
                                button2.IsEnabled = true;
                                break;
                            case 2:
                                button3.IsEnabled = true;
                                break;
                            case 3:
                                button4.IsEnabled = true;
                                break;
                            case 4:
                                button5.IsEnabled = true;
                                break;
                            case 5:
                                button6.IsEnabled = true;
                                break;
                            case 6:
                                button7.IsEnabled = true;
                                break;
                            case 7:
                                button8.IsEnabled = true;
                                break;
                            case 8:
                                button9.IsEnabled = true;
                                break;
                            case 9:
                                button10.IsEnabled = true;
                                break;
                            case 10:
                                button11.IsEnabled = true;
                                break;
                        }
                    }
                }
                button6.IsEnabled = false;
                MainPage.board = "/Amazing%20Ludo;component/Images/Board6.png";
                MainPage.boardstat[5] = 2;
            }
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.boardstat[6] == 0)
            {
                if (MainPage.coin >= 1000)
                {
                    button7.Content = "Apply";
                    MainPage.coin -= 1000;
                    image8.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board7.png", UriKind.Relative));
                    MainPage.boardstat[6] = 1;
                    textBlock1.Text = MainPage.coin.ToString();
                }
            }
            else if (MainPage.boardstat[6] == 1)
            {
                for (i = 0; i < 11; i++)
                {
                    if (MainPage.boardstat[i] == 2)
                    {
                        MainPage.boardstat[i] = 1;
                        switch (i)
                        {
                            case 0:
                                button1.IsEnabled = true;
                                break;
                            case 1:
                                button2.IsEnabled = true;
                                break;
                            case 2:
                                button3.IsEnabled = true;
                                break;
                            case 3:
                                button4.IsEnabled = true;
                                break;
                            case 4:
                                button5.IsEnabled = true;
                                break;
                            case 5:
                                button6.IsEnabled = true;
                                break;
                            case 6:
                                button7.IsEnabled = true;
                                break;
                            case 7:
                                button8.IsEnabled = true;
                                break;
                            case 8:
                                button9.IsEnabled = true;
                                break;
                            case 9:
                                button10.IsEnabled = true;
                                break;
                            case 10:
                                button11.IsEnabled = true;
                                break;
                        }
                    }
                }
                button7.IsEnabled = false;
                MainPage.board = "/Amazing%20Ludo;component/Images/Board7.png";
                MainPage.boardstat[6] = 2;
            }
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.boardstat[7] == 0)
            {
                if (MainPage.coin >= 1500)
                {
                    button8.Content = "Apply";
                    MainPage.coin -= 1500;
                    image9.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board8.png", UriKind.Relative));
                    MainPage.boardstat[7] = 1;
                    textBlock1.Text = MainPage.coin.ToString();
                }
            }
            else if (MainPage.boardstat[7] == 1)
            {
                for (i = 0; i < 11; i++)
                {
                    if (MainPage.boardstat[i] == 2)
                    {
                        MainPage.boardstat[i] = 1;
                        switch (i)
                        {
                            case 0:
                                button1.IsEnabled = true;
                                break;
                            case 1:
                                button2.IsEnabled = true;
                                break;
                            case 2:
                                button3.IsEnabled = true;
                                break;
                            case 3:
                                button4.IsEnabled = true;
                                break;
                            case 4:
                                button5.IsEnabled = true;
                                break;
                            case 5:
                                button6.IsEnabled = true;
                                break;
                            case 6:
                                button7.IsEnabled = true;
                                break;
                            case 7:
                                button8.IsEnabled = true;
                                break;
                            case 8:
                                button9.IsEnabled = true;
                                break;
                            case 9:
                                button10.IsEnabled = true;
                                break;
                            case 10:
                                button11.IsEnabled = true;
                                break;
                        }
                    }
                }
                button8.IsEnabled = false;
                MainPage.board = "/Amazing%20Ludo;component/Images/Board8.png";
                MainPage.boardstat[7] = 2;
            }
        }

        private void button9_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.boardstat[8] == 0)
            {
                if (MainPage.coin >= 2000)
                {
                    button9.Content = "Apply";
                    MainPage.coin -= 2000;
                    image10.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board9.png", UriKind.Relative));
                    MainPage.boardstat[8] = 1;
                    textBlock1.Text = MainPage.coin.ToString();
                }
            }
            else if (MainPage.boardstat[8] == 1)
            {
                for (i = 0; i < 11; i++)
                {
                    if (MainPage.boardstat[i] == 2)
                    {
                        MainPage.boardstat[i] = 1;
                        switch (i)
                        {
                            case 0:
                                button1.IsEnabled = true;
                                break;
                            case 1:
                                button2.IsEnabled = true;
                                break;
                            case 2:
                                button3.IsEnabled = true;
                                break;
                            case 3:
                                button4.IsEnabled = true;
                                break;
                            case 4:
                                button5.IsEnabled = true;
                                break;
                            case 5:
                                button6.IsEnabled = true;
                                break;
                            case 6:
                                button7.IsEnabled = true;
                                break;
                            case 7:
                                button8.IsEnabled = true;
                                break;
                            case 8:
                                button9.IsEnabled = true;
                                break;
                            case 9:
                                button10.IsEnabled = true;
                                break;
                            case 10:
                                button11.IsEnabled = true;
                                break;
                        }
                    }
                }
                button9.IsEnabled = false;
                MainPage.board = "/Amazing%20Ludo;component/Images/Board9.png";
                MainPage.boardstat[8] = 2;
            }
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.boardstat[9] == 0)
            {
                if (MainPage.coin >= 5000)
                {
                    button10.Content = "Apply";
                    MainPage.coin -= 5000;
                    image11.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board10.png", UriKind.Relative));
                    MainPage.boardstat[9] = 1;
                    textBlock1.Text = MainPage.coin.ToString();
                }
            }
            else if (MainPage.boardstat[9] == 1)
            {
                for (i = 0; i < 11; i++)
                {
                    if (MainPage.boardstat[i] == 2)
                    {
                        MainPage.boardstat[i] = 1;
                        switch (i)
                        {
                            case 0:
                                button1.IsEnabled = true;
                                break;
                            case 1:
                                button2.IsEnabled = true;
                                break;
                            case 2:
                                button3.IsEnabled = true;
                                break;
                            case 3:
                                button4.IsEnabled = true;
                                break;
                            case 4:
                                button5.IsEnabled = true;
                                break;
                            case 5:
                                button6.IsEnabled = true;
                                break;
                            case 6:
                                button7.IsEnabled = true;
                                break;
                            case 7:
                                button8.IsEnabled = true;
                                break;
                            case 8:
                                button9.IsEnabled = true;
                                break;
                            case 9:
                                button10.IsEnabled = true;
                                break;
                            case 10:
                                button11.IsEnabled = true;
                                break;
                        }
                    }
                }
                button10.IsEnabled = false;
                MainPage.board = "/Amazing%20Ludo;component/Images/Board10.png";
                MainPage.boardstat[9] = 2;
            }
        }

        private void button11_Click(object sender, RoutedEventArgs e)
        {
            if (MainPage.boardstat[10] == 0)
            {
                if (MainPage.coin >= 10000)
                {
                    button11.Content = "Apply";
                    MainPage.coin -= 10000;
                    image12.Source = new BitmapImage(new Uri("/Amazing%20Ludo;component/Images/Board11.png", UriKind.Relative));
                    MainPage.boardstat[10] = 1;
                    textBlock1.Text = MainPage.coin.ToString();
                }
            }
            else if (MainPage.boardstat[10] == 1)
            {
                for (i = 0; i < 11; i++)
                {
                    if (MainPage.boardstat[i] == 2)
                    {
                        MainPage.boardstat[i] = 1;
                        switch (i)
                        {
                            case 0:
                                button1.IsEnabled = true;
                                break;
                            case 1:
                                button2.IsEnabled = true;
                                break;
                            case 2:
                                button3.IsEnabled = true;
                                break;
                            case 3:
                                button4.IsEnabled = true;
                                break;
                            case 4:
                                button5.IsEnabled = true;
                                break;
                            case 5:
                                button6.IsEnabled = true;
                                break;
                            case 6:
                                button7.IsEnabled = true;
                                break;
                            case 7:
                                button8.IsEnabled = true;
                                break;
                            case 8:
                                button9.IsEnabled = true;
                                break;
                            case 9:
                                button10.IsEnabled = true;
                                break;
                            case 10:
                                button11.IsEnabled = true;
                                break;
                        }
                    }
                }
                button11.IsEnabled = false;
                MainPage.board = "/Amazing%20Ludo;component/Images/Board11.png";
                MainPage.boardstat[10] = 2;
            }
        }
    }
}
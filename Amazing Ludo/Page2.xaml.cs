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
using System.Windows.Threading;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using System.IO.IsolatedStorage;

namespace Amazing_Ludo
{
    public partial class Page2 : PhoneApplicationPage
    {
        //Local Variable
        double[,] cd = new double[,] {{200,200,200,200,200,200,169,137,106,74,42,10,10,10,42,74,106,137,169,200,200,200,200,200,200,232,263,263,263,263,263,263,295,326,358,390,421,453,453,453,421,390,358,326,295,263,263,263,263,263,263,232},
                                      {633,600,567,534,501,468,435,435,435,435,435,435,402,369,369,369,369,369,369,336,303,270,237,204,171,171,171,204,237,270,303,336,369,369,369,369,369,369,402,435,435,435,435,435,435,468,501,534,567,600,633,633}};
        double[,] ent = new double[,] {{42,74,106,137,169,232,232,232,232,232,421,390,358,326,295,232,232,232,232,232},
                                       {402,402,402,402,402,204,237,270,303,336,402,402,402,402,402,600,567,534,501,468}};
        double[,] initpos = new double[,] {{90,49,90,129,374,334,374,414,374,334,374,414,90,49,90,129},
                                           {212,254,295,254,212,254,295,254,509,550,592,550,509,550,592,550}};
        int[] ini = new int[] { 14, 27, 40, 1 };
        double[] safe = new double[] { 1, 9, 14, 22, 27, 35, 40, 48 };
        int[] end = new int[] { 12, 25, 38, 51 };
        int[] win;
        int[] player = new int[4];
        double[,] eft = new double[,] {{3,287,287,3},
                                       {163,163,459,459}};
        int[] x = new int[3];
        double[,] M = new double[4, 4] { { -1, -1, -1, -1 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 }, { -1, -1, -1, -1 } };
        int i, c = 0, j = 0, t = 0, l, n, times = 0, dice, count = 0, d = 0, z = 1, p;
        public static int[] stand = new int[4] { -1, -1, -1, -1 };
        string[] str;
        DispatcherTimer tmr;
        ApplicationBarIconButton button1, button2, button3, button4;
        
        //Functions
        public Page2()
        {
            InitializeComponent();
            
            ApplicationBar = new ApplicationBar();

            ApplicationBar.Mode = ApplicationBarMode.Default;
            ApplicationBar.Opacity = 0.7;
            ApplicationBar.IsVisible = true;
            ApplicationBar.IsMenuEnabled = true;

            button1 = new ApplicationBarIconButton();
            button1.IconUri = new Uri("/Images/YourImage.png", UriKind.Relative);
            button1.Text = "button 1";
            ApplicationBar.Buttons.Add(button1);
            button1.Click += new EventHandler(button1_Click);

            button2 = new ApplicationBarIconButton();
            button2.IconUri = new Uri("/Images/YourImage.png", UriKind.Relative);
            button2.Text = "button 2";
            ApplicationBar.Buttons.Add(button2);
            button2.Click += new EventHandler(button2_Click);

            button3 = new ApplicationBarIconButton();
            button3.IconUri = new Uri("/Images/YourImage.png", UriKind.Relative);
            button3.Text = "button 3";
            ApplicationBar.Buttons.Add(button3);
            button3.Click += new EventHandler(button3_Click);

            button4 = new ApplicationBarIconButton();
            button4.IconUri = new Uri("/Images/YourImage.png", UriKind.Relative);
            button4.Text = "button 4";
            ApplicationBar.Buttons.Add(button4);
            button4.Click += new EventHandler(button4_Click);
            
            ApplicationBar.Mode = ApplicationBarMode.Minimized;
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            button3.IsEnabled = false;
            button4.IsEnabled = false;

            image1.Source = new BitmapImage(new Uri(MainPage.board, UriKind.Relative));

            this.BackKeyPress += new EventHandler<System.ComponentModel.CancelEventArgs>(Page2_BackKeyPress);
        }

        void Page2_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MainPage.resume == 0)
            {
                MainPage.resume = 1;
                IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
                gets["Resume"] = MainPage.resume;
                gets.Save();
                NavigationService.RemoveBackEntry();
                NavigationService.GoBack();
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            n = 0;
            str = MainPage.select;
            for (i = 0; i < 4; i++)
            {
                if (str[i] == "0")
                {
                    player[i] = 0;
                }
                else if (str[i] == "1")
                {
                    player[i] = 1;
                }
                else if (str[i] == "-1")
                {
                    player[i] = -1;
                }
                n++;
            }
            p = 0;
            for (i = 0; i < 4; i++)
            {
                if (player[i] != 0)
                {
                    p++;
                }
            }

            for (i = 0; i < 4; i++)
            {
                if (player[i] == 0)
                {
                    switch (i)
                    {
                        case 0:
                            red1.Visibility = System.Windows.Visibility.Collapsed;
                            red2.Visibility = System.Windows.Visibility.Collapsed;
                            red3.Visibility = System.Windows.Visibility.Collapsed;
                            red4.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                        case 1:
                            green1.Visibility = System.Windows.Visibility.Collapsed;
                            green2.Visibility = System.Windows.Visibility.Collapsed;
                            green3.Visibility = System.Windows.Visibility.Collapsed;
                            green4.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                        case 2:
                            yellow1.Visibility = System.Windows.Visibility.Collapsed;
                            yellow2.Visibility = System.Windows.Visibility.Collapsed;
                            yellow3.Visibility = System.Windows.Visibility.Collapsed;
                            yellow4.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                        case 3:
                            blue1.Visibility = System.Windows.Visibility.Collapsed;
                            blue2.Visibility = System.Windows.Visibility.Collapsed;
                            blue3.Visibility = System.Windows.Visibility.Collapsed;
                            blue4.Visibility = System.Windows.Visibility.Collapsed;
                            break;
                    }
                }
            }
            if (MainPage.resume == 1)
            {
                double[] pos = new double[16];
                IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
                gets.TryGetValue<int>("Chance", out c);
                gets.TryGetValue<double[]>("Position", out pos);
                gets.TryGetValue<int[]>("Win", out win);
                gets.TryGetValue<int[]>("Stand", out stand);
                
                for (i = 0; i < 4; i++)
                {
                    for (l = 0; l < 4; l++)
                    {
                        M[i, l] = pos[i * 4 + l];
                    }
                }
                set();
                changenum();
            }
            else
            {
                win = new int[4] { 0, 0, 0, 0 };
                squareEffect.Visibility = System.Windows.Visibility.Visible;
            }
            change();
            check();
        }

        void set()
        {
            for (i = 0; i < 4; i++)
            {
                if (player[i] != 0)
                {
                    for (l = 0; l < 4; l++)
                    {
                        if (M[i, l] == -2)
                        {
                            switch (i)
                            {
                                case 0:
                                    {
                                        switch (l)
                                        {
                                            case 0: red1.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 1: red2.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 2: red3.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 3: red4.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                        }
                                    }
                                    break;
                                case 1:
                                    {
                                        switch (l)
                                        {
                                            case 0: green1.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 1: green2.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 2: green3.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 3: green4.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        switch (l)
                                        {
                                            case 0: yellow1.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 1: yellow2.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 2: yellow3.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 3: yellow4.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        switch (l)
                                        {
                                            case 0: blue1.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 1: blue2.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 2: blue3.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                            case 3: blue4.Visibility = System.Windows.Visibility.Collapsed;
                                                break;
                                        }
                                    }
                                    break;
                            }
                        }
                        else if (M[i, l] >= 100)
                        {
                            switch (i)
                            {
                                case 0:
                                    switch (l)
                                    {
                                        case 0: red1.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 1: red2.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 2: red3.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 3: red4.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                    }
                                    break;
                                case 1:
                                    switch (l)
                                    {
                                        case 0: green1.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 1: green2.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 2: green3.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 3: green4.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (l)
                                    {
                                        case 0: yellow1.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 1: yellow2.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 2: yellow3.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 3: yellow4.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (l)
                                    {
                                        case 0: blue1.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 1: blue2.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 2: blue3.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                        case 3: blue4.Margin = new Thickness(ent[0, ((int)M[i, l] % 100) + i * 5], ent[1, ((int)M[i, l] % 100) + i * 5], 0, 0);
                                            break;
                                    }
                                    break;
                            }
                        }
                        else if (M[i, l] != -1)
                        {
                            switch (i)
                            {
                                case 0:
                                    switch (l)
                                    {
                                        case 0: red1.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 1: red2.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 2: red3.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 3: red4.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                    }
                                    break;
                                case 1:
                                    switch (l)
                                    {
                                        case 0: green1.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 1: green2.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 2: green3.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 3: green4.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                    }
                                    break;
                                case 2:
                                    switch (l)
                                    {
                                        case 0: yellow1.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 1: yellow2.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 2: yellow3.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 3: yellow4.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                    }
                                    break;
                                case 3:
                                    switch (l)
                                    {
                                        case 0: blue1.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 1: blue2.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 2: blue3.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                        case 3: blue4.Margin = new Thickness(cd[0, (int)M[i, l]], cd[1, (int)M[i, l]], 0, 0);
                                            break;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        //Running Code ------------------------------------------------------------------------------------------

        private void change()
        {
            while (player[c] == 0 || win[c] == 4)
            {
                c++;
                if (c == 4)
                    c = 0;
            }
            Comment.Text = "";
            changenum();
            squareEffect.Margin = new Thickness(eft[0, c], eft[1, c], 0, 0);
        }

        void check()
        {
            IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
            double[] pos = new double[16];
            for (i = 0; i < 4; i++)
                for (l = 0; l < 4; l++)
                    pos[i * 4 + l] = M[i, l];
            gets["Chance"] = c;
            gets["Position"] = pos;
            gets["Win"] = win;
            gets["Stand"] = stand;
            gets.Save();

            if (player[c] == -1)
            {
                Comment.Text = "Computer Turn!!!";
                i = 0;
                tmr = new DispatcherTimer();
                tmr.Interval = TimeSpan.FromMilliseconds(0);//50);
                tmr.Tick += delay;
                tmr.Start();
            }
            else
            {
                Comment.Text = "Player Turn!!!";
            }
        }

        void delay(object sender, EventArgs args)
        {
            i++;
            if (i == 10)
            {
                tmr.Stop();
                computer();
            }
        }

        //Player Logic-------------------------------------------------------------------------------------------

        private void image_Tap(object sender, GestureEventArgs e)
        {
            i = 0;
            if (j < 3 && t == 0 && player[c] == 1)
            {
                image2.Visibility = System.Windows.Visibility.Collapsed;
                image9.Visibility = System.Windows.Visibility.Collapsed;
                Point.Visibility = System.Windows.Visibility.Collapsed;
                Milestone.Visibility = System.Windows.Visibility.Collapsed;
                if (z == 0)
                {
                    Comment.Text = "";
                    changenum();
                    squareEffect.Margin = new Thickness(eft[0, c], eft[1, c], 0, 0);
                    if (n != 6 || j == 0)
                    {
                        store1.Source = null;
                        store2.Source = null;
                        store3.Source = null;
                    }
                    z++;
                }
                tmr = new DispatcherTimer();
                tmr.Interval = TimeSpan.FromMilliseconds(20);
                tmr.Tick += roll;
                tmr.Start();
            }
        }
        
        void roll(object sender, EventArgs args)
        {
            i++;
            Random die = new Random();
            Comment.Text = "";
            n = die.Next(6) + 1;
            if (i > 49)
            {
                tmr.Stop();
                x[j] = n;

                if (n == 6 && j == 2)
                {
                    store3.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice6.png", UriKind.Relative));
                    Comment.Text = "Turn Discarded";
                    c++;
                    if (c == 4)
                        c = 0;
                    change();
                    z = 0;
                    j = 0;
                    check();
                }
                else if (n == 6 && j < 2)
                {
                    if (j == 0)
                        store1.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice6.png", UriKind.Relative));
                    else if (j == 1)
                        store2.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice6.png", UriKind.Relative));
                    Comment.Text = "Play Again";
                    z = 0;
                    j++;
                }
                else
                {
                    if (j == 0)
                        store1.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice" + n + ".png", UriKind.Relative));
                    else if (j == 1)
                        store2.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice" + n + ".png", UriKind.Relative));
                    else
                        store3.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice" + n + ".png", UriKind.Relative));
                    j++;
                    t++;
                    play();
                }
            }
            image3.Visibility = System.Windows.Visibility.Collapsed;
            image4.Visibility = System.Windows.Visibility.Collapsed;
            image5.Visibility = System.Windows.Visibility.Collapsed;
            image6.Visibility = System.Windows.Visibility.Collapsed;
            image7.Visibility = System.Windows.Visibility.Collapsed;
            image8.Visibility = System.Windows.Visibility.Collapsed;
            if (n % 7 == 1)
                image3.Visibility = System.Windows.Visibility.Visible;
            else if (n % 7 == 2)
                image4.Visibility = System.Windows.Visibility.Visible;
            else if (n % 7 == 3)
                image5.Visibility = System.Windows.Visibility.Visible;
            else if (n % 7 == 4)
                image6.Visibility = System.Windows.Visibility.Visible;
            else if (n % 7 == 5)
                image7.Visibility = System.Windows.Visibility.Visible;
            else if (n % 7 == 6)
                image8.Visibility = System.Windows.Visibility.Visible;
        }

        void play()
        {
            int k, n, o;
            l = 0;
            dice = x[times];

            button1.IsEnabled = true;
            button2.IsEnabled = true;
            button3.IsEnabled = true;
            button4.IsEnabled = true;

            for (k = 0; k < 4; k++)
            {
                n = 0;
                o = 0;
                if (M[c, k] != -1 && M[c, k] != -2 && M[c, k] + dice < 106)
                {
                    n++;
                }
                if (M[c, k] == -2)
                    o++;
                if (n == 0 && (dice != 6 || o != 0 || M[c, k] + dice > 105))
                {
                    switch (k)
                    {
                        case 0: button1.IsEnabled = false; l++;
                            break;
                        case 1: button2.IsEnabled = false; l++;
                            break;
                        case 2: button3.IsEnabled = false; l++;
                            break;
                        case 3: button4.IsEnabled = false; l++;
                            break;
                    }
                }

            }

            if (l == 4)
            {
                Comment.Text = "No Move Available";
                z = 0;
                c++;
                if (c == 4)
                    c = 0;
                change();
                t = 0;
                j = 0;
                times = 0;
                button1.IsEnabled = false;
                button2.IsEnabled = false;
                button3.IsEnabled = false;
                button4.IsEnabled = false;
                ApplicationBar.Mode = ApplicationBarMode.Minimized;
                check();
            }
            else
            {
                ApplicationBar.Mode = ApplicationBarMode.Default;
                times++;
            }            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            move(0);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            move(1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            move(2);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            move(3);
        }

        void move(int x)
        {
            double prev, curr;
            int a, b;
            prev = M[c, x];
            if (M[c, x] == -1 && dice == 6)
                M[c, x] = ini[c];
            else
            {
                M[c, x] += dice;
                if (prev <= end[c] && M[c, x] > end[c])
                    M[c, x] = 100 + (M[c, x] - end[c] - 1);
                if (M[c, x] > 51 && M[c, x] < 100)
                    M[c, x] -= 52;
                if (M[c, x] == 105)
                {
                    M[c, x] = -2;
                    win[c]++;
                    Comment.Text = "Win!!! Play Again";
                    coinupdate(1);
                    milesupdate();
                    z = 0;
                    if (win[c] == 4)
                    {
                        stand[count] = c;
                        count++;
                        if (count == p - 1)
                            finish();
                    }
                    else d++;

                }
            }
            curr = M[c, x];

            if (curr >= 100 || curr == -2)
            {
                if (curr != -2)
                {
                    switch (x)
                    {
                        case 0:
                            switch (c)
                            {
                                case 0: red1.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 1: green1.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 2: yellow1.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 3: blue1.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                            }
                            break;
                        case 1:
                            switch (c)
                            {
                                case 0: red2.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 1: green2.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 2: yellow2.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 3: blue2.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                            }
                            break;
                        case 2:
                            switch (c)
                            {
                                case 0: red3.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 1: green3.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 2: yellow3.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 3: blue3.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                            }
                            break;
                        case 3:
                            switch (c)
                            {
                                case 0: red4.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 1: green4.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 2: yellow4.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 3: blue4.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    switch (x)
                    {
                        case 0:
                            switch (c)
                            {
                                case 0: red1.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 1: green1.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 2: yellow1.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 3: blue1.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                            }
                            break;
                        case 1:
                            switch (c)
                            {
                                case 0: red2.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 1: green2.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 2: yellow2.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 3: blue2.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                            }
                            break;
                        case 2:
                            switch (c)
                            {
                                case 0: red3.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 1: green3.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 2: yellow3.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 3: blue3.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                            }
                            break;
                        case 3:
                            switch (c)
                            {
                                case 0: red4.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 1: green4.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 2: yellow4.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 3: blue4.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                            }
                            break;
                    }
                }
            }
            else
            {
                switch (x)
                {
                    case 0:
                        switch (c)
                        {
                            case 0: red1.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 1: green1.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 2: yellow1.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 3: blue1.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                        }
                        break;
                    case 1:
                        switch (c)
                        {
                            case 0: red2.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 1: green2.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 2: yellow2.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 3: blue2.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                        }
                        break;
                    case 2:
                        switch (c)
                        {
                            case 0: red3.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 1: green3.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 2: yellow3.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 3: blue3.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                        }
                        break;
                    case 3:
                        switch (c)
                        {
                            case 0: red4.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 1: green4.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 2: yellow4.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 3: blue4.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                        }
                        break;
                }
            }
            l = 0;
            for (a = 0; a < 8; a++)
            {
                if (safe[a] == curr)
                {
                    l++;
                }
            }

            for (a = 0; a < 4; a++)
                for (b = 0; b < 4; b++)
                    if ((curr == M[a, b]) && (c != a) && (l == 0) && (curr < 100) && (curr > -1))
                    {
                        M[a, b] = -1;
                        Comment.Text = "Kill!!! Play Again";
                        MainPage.kill += 1;
                        coinupdate(5);
                        milesupdate();
                        z = 0;
                        d++;
                        
                        switch (b)
                        {
                            case 0:
                                switch (a)
                                {
                                    case 0: red1.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 1: green1.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 2: yellow1.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 3: blue1.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                }
                                break;
                            case 1:
                                switch (a)
                                {
                                    case 0: red2.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 1: green2.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 2: yellow2.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 3: blue2.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                }
                                break;
                            case 2:
                                switch (a)
                                {
                                    case 0: red3.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 1: green3.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 2: yellow3.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 3: blue3.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                }
                                break;
                            case 3:
                                switch (a)
                                {
                                    case 0: red4.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 1: green4.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 2: yellow4.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 3: blue4.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                }
                                break;
                        }

                    }
            switch (times)
            {
                case 1: store1.Source = null;
                    break;
                case 2: store2.Source = null;
                    break;
                case 3: store3.Source = null;
                    break;
            }
            changenum();
            if (times == j)
            {
                if (d == 0)
                {
                    c++;
                    if (c == 4)
                        c = 0;
                    change();
                }
                else d--;
                t = 0;
                j = 0;
                times = 0;
                button1.IsEnabled = false;
                button2.IsEnabled = false;
                button3.IsEnabled = false;
                button4.IsEnabled = false;
                ApplicationBar.Mode = ApplicationBarMode.Minimized;
                check();
            }
            else
            {
                play();
            }
        }

        //Marker Positions---------------------------------------------------------------------------------------

        void changenum()
        {
            for (l = 0; l < 4; l++)
            {
                if (M[c, l] >= 0 && M[c, l] < 52)
                {
                    switch (l)
                    {
                        case 0: G1.Margin = new Thickness(cd[0, (int)M[c, l]], cd[1, (int)M[c, l]], 0, 0);
                            break;
                        case 1: G2.Margin = new Thickness(cd[0, (int)M[c, l]], cd[1, (int)M[c, l]], 0, 0);
                            break;
                        case 2: G3.Margin = new Thickness(cd[0, (int)M[c, l]], cd[1, (int)M[c, l]], 0, 0);
                            break;
                        case 3: G4.Margin = new Thickness(cd[0, (int)M[c, l]], cd[1, (int)M[c, l]], 0, 0);
                            break;
                    }
                }
                else if (M[c, l] == -1)
                {
                    switch (l)
                    {
                        case 0: G1.Margin = new Thickness(initpos[0, c * 4 + l], initpos[1, c * 4 + l], 0, 0);
                            break;
                        case 1: G2.Margin = new Thickness(initpos[0, c * 4 + l], initpos[1, c * 4 + l], 0, 0);
                            break;
                        case 2: G3.Margin = new Thickness(initpos[0, c * 4 + l], initpos[1, c * 4 + l], 0, 0);
                            break;
                        case 3: G4.Margin = new Thickness(initpos[0, c * 4 + l], initpos[1, c * 4 + l], 0, 0);
                            break;
                    }
                }
                else if (M[c, l] > 99)
                {
                    switch (l)
                    {
                        case 0: G1.Margin = new Thickness(ent[0, (int)M[c, l] % 100 + c * 5], ent[1, (int)M[c, l] % 100 + c * 5], 0, 0);
                            break;
                        case 1: G2.Margin = new Thickness(ent[0, (int)M[c, l] % 100 + c * 5], ent[1, (int)M[c, l] % 100 + c * 5], 0, 0);
                            break;
                        case 2: G3.Margin = new Thickness(ent[0, (int)M[c, l] % 100 + c * 5], ent[1, (int)M[c, l] % 100 + c * 5], 0, 0);
                            break;
                        case 3: G4.Margin = new Thickness(ent[0, (int)M[c, l] % 100 + c * 5], ent[1, (int)M[c, l] % 100 + c * 5], 0, 0);
                            break;
                    }
                }
                else if (M[c, l] == -2)
                {
                    switch (l)
                    {
                        case 0: G1.Margin = new Thickness(550, 200, 0, 0);
                            break;
                        case 1: G2.Margin = new Thickness(550, 200, 0, 0);
                            break;
                        case 2: G3.Margin = new Thickness(550, 200, 0, 0);
                            break;
                        case 3: G4.Margin = new Thickness(550, 200, 0, 0);
                            break;
                    }
                }
            }
        }

        //Coin Updation------------------------------------------------------------------------------------------

        void coinupdate(int a)
        {
            if (a == 5)
            {
                if (MainPage.miles[0] == 1)
                {
                    if (MainPage.miles[1] == 1)
                    {
                        if (MainPage.miles[2] == 1)
                        {
                            if (MainPage.miles[3] == 1)
                            {
                                a += 40;
                            }
                            else
                            {
                                a += 30;
                            }
                        }
                        else
                        {
                            a += 20;
                        }
                    }
                    else
                    {
                        a += 10;
                    }
                }
                if (MainPage.miles[4] == 1)
                {
                    if (MainPage.miles[5] == 1)
                    {
                        if (MainPage.miles[6] == 1)
                        {
                            if (MainPage.miles[7] == 1)
                            {
                                a += 20;
                            }
                            else
                            {
                                a += 15;
                            }
                        }
                        else
                        {
                            a += 10;
                        }
                    }
                    else
                    {
                        a += 5;
                    }
                }
            }
            else if (a == 1)
            {
                if (MainPage.miles[0] == 1)
                {
                    if (MainPage.miles[1] == 1)
                    {
                        if (MainPage.miles[2] == 1)
                        {
                            if (MainPage.miles[3] == 1)
                            {
                                a += 4;
                            }
                            else
                            {
                                a += 3;
                            }
                        }
                        else
                        {
                            a += 2;
                        }
                    }
                    else
                    {
                        a += 1;
                    }
                }
                if (MainPage.miles[4] == 1)
                {
                    if (MainPage.miles[5] == 1)
                    {
                        if (MainPage.miles[6] == 1)
                        {
                            if (MainPage.miles[7] == 1)
                            {
                                a += 8;
                            }
                            else
                            {
                                a += 7;
                            }
                        }
                        else
                        {
                            a += 6;
                        }
                    }
                    else
                    {
                        a += 5;
                    }
                }                
            }
            MainPage.coin += a;
            image2.Visibility = System.Windows.Visibility.Visible;
            Point.Visibility = System.Windows.Visibility.Visible;
            Point.Text = a.ToString();
            IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
            gets["Coin"] = MainPage.coin;
        }

        //Milestone Updation-------------------------------------------------------------------------------------

        void milesupdate()
        {
            int a = 0;
            if (MainPage.miles[3] == 0)
            {
                if (MainPage.miles[2] == 0)
                {
                    if (MainPage.miles[1] == 0)
                    {
                        if (MainPage.miles[0] == 0)
                        {
                            if (MainPage.coin >= 50)
                            {
                                MainPage.miles[0] = 1;
                                a++;
                            }
                        }
                        else
                        {
                            if (MainPage.coin >= 100)
                            {
                                MainPage.miles[1] = 1;
                                a++;
                            }
                        }
                    }
                    else
                    {
                        if (MainPage.coin >= 1000)
                        {
                            MainPage.miles[2] = 1;
                            a++;
                        }
                    }
                }
                else
                {
                    if (MainPage.coin >= 10000)
                    {
                        MainPage.miles[3] = 1;
                        a++;
                    }
                }
            }
            if (MainPage.miles[7] == 0)
            {
                if (MainPage.miles[6] == 0)
                {
                    if (MainPage.miles[5] == 0)
                    {
                        if (MainPage.miles[4] == 0)
                        {
                            if (MainPage.kill >= 2)
                            {
                                MainPage.miles[4] = 1;
                                a++;
                            }
                        }
                        else
                        {
                            if (MainPage.kill >= 20)
                            {
                                MainPage.miles[5] = 1;
                                a++;
                            }
                        }
                    }
                    else
                    {
                        if (MainPage.kill >= 200)
                        {
                            MainPage.miles[6] = 1;
                            a++;
                        }
                    }
                }
                else
                {
                    if (MainPage.kill >= 2000)
                    {
                        MainPage.miles[7] = 1;
                        a++;
                    }
                }
            }
            if (a != 0)
            {
                image9.Visibility = System.Windows.Visibility.Visible;
                Milestone.Visibility = System.Windows.Visibility.Visible;
                Milestone.Text = a.ToString();
                IsolatedStorageSettings gets = IsolatedStorageSettings.ApplicationSettings;
                gets["Milestone"] = MainPage.miles;
            }
        }

        //For Computer AI----------------------------------------------------------------------------------------
        void computer()
        {
            i = 0;
            if (j < 3 && t == 0)
            {
                if (z == 0)
                {
                    Comment.Text = "";
                    changenum();
                    squareEffect.Margin = new Thickness(eft[0, c], eft[1, c], 0, 0);
                    if (n != 6 || j == 0)
                    {
                        store1.Source = null;
                        store2.Source = null;
                        store3.Source = null;
                    }
                    z++;
                }
                
                tmr = new DispatcherTimer();
                tmr.Interval = TimeSpan.FromMilliseconds(20);
                tmr.Tick += rollc;
                tmr.Start();
            }
        }

        void rollc(object sender, EventArgs args)
        {
            i++;
            Random die = new Random();
            Comment.Text = "";
            n = die.Next(6) + 1;
            if (i > 49)
            {
                tmr.Stop();
                x[j] = n;

                if (n == 6 && j == 2)
                {
                    store3.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice6.png", UriKind.Relative));
                    Comment.Text = "Turn Discarded";
                    c++;
                    if (c == 4)
                        c = 0;
                    change();
                    z = 0;
                    j = 0;
                    check();
                }
                else if (n == 6 && j < 2)
                {
                    if (j == 0)
                        store1.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice6.png", UriKind.Relative));
                    else if (j == 1)
                        store2.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice6.png", UriKind.Relative));
                    Comment.Text = "Play Again";
                    z = 0;
                    j++;
                    computer();
                }
                else
                {
                    if (j == 0)
                        store1.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice" + n + ".png", UriKind.Relative));
                    else if (j == 1)
                        store2.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice" + n + ".png", UriKind.Relative));
                    else
                        store3.Source = new BitmapImage(new Uri("/Ludo;component/Images/dice" + n + ".png", UriKind.Relative));
                    j++;
                    t++;
                    playc();
                }
            }

            image3.Visibility = System.Windows.Visibility.Collapsed;
            image4.Visibility = System.Windows.Visibility.Collapsed;
            image5.Visibility = System.Windows.Visibility.Collapsed;
            image6.Visibility = System.Windows.Visibility.Collapsed;
            image7.Visibility = System.Windows.Visibility.Collapsed;
            image8.Visibility = System.Windows.Visibility.Collapsed;
            if (n % 7 == 1)
                image3.Visibility = System.Windows.Visibility.Visible;
            else if (n % 7 == 2)
                image4.Visibility = System.Windows.Visibility.Visible;
            else if (n % 7 == 3)
                image5.Visibility = System.Windows.Visibility.Visible;
            else if (n % 7 == 4)
                image6.Visibility = System.Windows.Visibility.Visible;
            else if (n % 7 == 5)
                image7.Visibility = System.Windows.Visibility.Visible;
            else if (n % 7 == 6)
                image8.Visibility = System.Windows.Visibility.Visible;
        }

        void playc()
        {
            int k, n, o;
            l = 0;
            dice = x[times];
            for (k = 0; k < 4; k++)
            {
                n = 0;
                o = 0;
                if (M[c, k] != -1 && M[c, k] != -2 && M[c, k] + dice < 106)
                {
                    n++;
                }
                if (M[c, k] == -2)
                    o++;
                if (n == 0 && (dice != 6 || o != 0 || M[c, k] + dice > 105))
                {
                    l++;
                }

            }

            if (l == 4)
            {
                z = 0;
                c++;
                if (c == 4)
                    c = 0;
                change();
                t = 0;
                j = 0;
                times = 0;
                check();
            }
            else
            {
                times++;
                movec();
            }
        }

        void movec()
        {
            int x, a, b;
            double prev, curr;
            x = findc();
            prev = M[c, x];
            if (M[c, x] == -1)
                M[c, x] = ini[c];
            else
            {
                M[c, x] += dice;
                if (prev <= end[c] && M[c, x] > end[c])
                    M[c, x] = 100 + (M[c, x] - end[c] - 1);
                if (M[c, x] > 51 && M[c, x] < 100)
                    M[c, x] -= 52;
                if (M[c, x] == 105)
                {
                    M[c, x] = -2;
                    win[c]++;
                    Comment.Text = "Win!!! Play Again";
                    z = 0;
                    if (win[c] == 4)
                    {
                        stand[count] = c;
                        count++;
                        if (count == p - 1)
                            finish();
                    }
                    else d++;

                }
            }
            curr = M[c, x];

            if (curr >= 100 || curr == -2)
            {
                if (curr != -2)
                {
                    switch (x)
                    {
                        case 0:
                            switch (c)
                            {
                                case 0: red1.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 1: green1.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 2: yellow1.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 3: blue1.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                            }
                            break;
                        case 1:
                            switch (c)
                            {
                                case 0: red2.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 1: green2.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 2: yellow2.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 3: blue2.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                            }
                            break;
                        case 2:
                            switch (c)
                            {
                                case 0: red3.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 1: green3.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 2: yellow3.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 3: blue3.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                            }
                            break;
                        case 3:
                            switch (c)
                            {
                                case 0: red4.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 1: green4.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 2: yellow4.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                                case 3: blue4.Margin = new Thickness(ent[0, ((int)curr % 100) + c * 5], ent[1, ((int)curr % 100) + c * 5], 0, 0);
                                    break;
                            }
                            break;
                    }
                }
                else
                {
                    switch (x)
                    {
                        case 0:
                            switch (c)
                            {
                                case 0: red1.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 1: green1.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 2: yellow1.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 3: blue1.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                            }
                            break;
                        case 1:
                            switch (c)
                            {
                                case 0: red2.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 1: green2.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 2: yellow2.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 3: blue2.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                            }
                            break;
                        case 2:
                            switch (c)
                            {
                                case 0: red3.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 1: green3.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 2: yellow3.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 3: blue3.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                            }
                            break;
                        case 3:
                            switch (c)
                            {
                                case 0: red4.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 1: green4.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 2: yellow4.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                                case 3: blue4.Visibility = System.Windows.Visibility.Collapsed;
                                    break;
                            }
                            break;
                    }
                }
            }
            else
            {
                switch (x)
                {
                    case 0:
                        switch (c)
                        {
                            case 0: red1.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 1: green1.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 2: yellow1.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 3: blue1.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                        }
                        break;
                    case 1:
                        switch (c)
                        {
                            case 0: red2.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 1: green2.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 2: yellow2.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 3: blue2.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                        }
                        break;
                    case 2:
                        switch (c)
                        {
                            case 0: red3.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 1: green3.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 2: yellow3.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 3: blue3.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                        }
                        break;
                    case 3:
                        switch (c)
                        {
                            case 0: red4.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 1: green4.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 2: yellow4.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                            case 3: blue4.Margin = new Thickness(cd[0, (int)curr], cd[1, (int)curr], 0, 0);
                                break;
                        }
                        break;
                }
            }
            l = 0;
            for (a = 0; a < 8; a++)
            {
                if (safe[a] == curr)
                {
                    l++;
                }
            }

            for (a = 0; a < 4; a++)
                for (b = 0; b < 4; b++)
                    if ((curr == M[a, b]) && (c != a) && (l == 0) && (curr < 100) && (curr > -1))
                    {
                        M[a, b] = -1;
                        Comment.Text = "Kill!!! Play Again";
                        z = 0;
                        d++;
                        
                        switch (b)
                        {
                            case 0:
                                switch (a)
                                {
                                    case 0: red1.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 1: green1.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 2: yellow1.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 3: blue1.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                }
                                break;
                            case 1:
                                switch (a)
                                {
                                    case 0: red2.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 1: green2.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 2: yellow2.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 3: blue2.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                }
                                break;
                            case 2:
                                switch (a)
                                {
                                    case 0: red3.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 1: green3.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 2: yellow3.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 3: blue3.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                }
                                break;
                            case 3:
                                switch (a)
                                {
                                    case 0: red4.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 1: green4.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 2: yellow4.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                    case 3: blue4.Margin = new Thickness(initpos[0, a * 4 + b], initpos[1, a * 4 + b], 0, 0);
                                        break;
                                }
                                break;
                        }

                    }
            switch (times)
            {
                case 1: store1.Source = null;
                    break;
                case 2: store2.Source = null;
                    break;
                case 3: store3.Source = null;
                    break;
            }
            changenum();
            if (times == j)
            {
                if (d == 0)
                {
                    c++;
                    if (c == 4)
                        c = 0;
                    change();
                }
                else d--;
                t = 0;
                j = 0;
                times = 0;
                check();
            }
            else
            {
                playc();
            }
        }

        int findc()
        {
            double[] prev = new double[4];
            int a, b, e, flag = 0;
            for (a = 0; a < 4; a++)
                if (M[c, a] == -1)
                    flag++;
            if (flag == 4)
                return 0;
            else
            {
                flag = 0;
                for (a = 0; a < 4; a++)
                    if (M[c, a] != -1 && M[c, a] != -2)
                        flag++;
                if (flag == 0)
                {
                    for (a = 0; a < 4; a++)
                        if (M[c, a] == -1)
                            return a;
                }
                else
                {
                    for (a = 0; a < 4; a++)
                    {
                        if (M[c, a] == -1 || M[c, a] == -2)
                            prev[a] = M[c, a];
                        else
                        {
                            prev[a] = M[c, a];
                            prev[a] += dice;
                            if (M[c, a] <= end[c] && prev[a] > end[c])
                                prev[a] = 100 + (prev[a] - end[c] - 1);
                            if (prev[a] > 51 && prev[a] < 100)
                                prev[a] -= 52;
                        }
                    }
                    for (b = 0; b < 4; b++)
                    {
                        if (c == b)
                            continue;
                        for (e = 0; e < 4; e++)
                        {
                            for (a = 0; a < 4; a++)
                                if (M[b, e] == prev[a] && M[b, e] > -1 && M[b, e] < 100)
                                    return a;
                        }
                    }
                    
                    for (a = 0; a < 4; a++)
                        if (M[c, a] == 105)
                            return a;
                    for (a = 0; a < 4; a++)
                        for (b = 0; b < 8; b++)
                            if (prev[a] == safe[b])
                                return a;
                    for (a = 0; a < 4; a++)
                        if (M[c, a] == -1 && dice == 6)
                            return a;
                    for (a = 0; a < 4; a++)
                        if (M[c, a] != -1 && M[c, a] != -2 && M[c, a] + dice < 106)
                            return a;
                }
            }
            return 0;
        }

        //Final Step-------------------------------------------------------------------------------------------
        void finish()
        {
            NavigationService.Navigate(new Uri("/Page3.xaml",UriKind.Relative));
        }
    }
}
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
    public partial class Page5 : PhoneApplicationPage
    {
        public Page5()
        {
            InitializeComponent();
            if (MainPage.miles[0] == 1)
            {
                M1.IsEnabled = false;
                //code for highlighting M1
                //50 Coins Collected
            }
            if (MainPage.miles[1] == 1)
            {
                M2.IsEnabled = false;
                //code for highlighting M2
                //100 Coins Collected
            }
            if (MainPage.miles[2] == 1)
            {
                M3.IsEnabled = false;
                //code for highlighting M3
                //1000 Coins Collected
            }
            if (MainPage.miles[3] == 1)
            {
                M4.IsEnabled = false;
                //code for highlighting M4
                //10000 Coins Collected
            }
            if (MainPage.miles[4] == 1)
            {
                M5.IsEnabled = false;
                //code for highlighting M5
                //2 Kills of Computer/another player
            }
            if (MainPage.miles[5] == 1)
            {
                M6.IsEnabled = false;
                //code for highlighting M6
                //20 Kills of Computer/another player
            }
            if (MainPage.miles[6] == 1)
            {
                M7.IsEnabled = false;
                //code for highlighting M7
                //200 Kills of Computer/another player
            }
            if (MainPage.miles[7] == 1)
            {
                M8.IsEnabled = false;
                //code for highlighting M8
                //20000 Kills of Computer/another player
            }
            int flag = 0;
            for (int i = 0; i < 8; i++)
            {
                if (MainPage.miles[i] == 0)
                {
                    flag++;
                }
            }
            if (flag == 0)
            {
                M9.IsEnabled = false;
                //code for highlighting M9
                //Completed all Milestones
            }
        }
    }
}
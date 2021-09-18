using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ChefRisingStar.Models;
using System.Diagnostics;

namespace ChefRisingStar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Leaderboards : ContentPage
    {

        public Leaderboards()
        {
            InitializeComponent();

            LeaderboardCarousel.ItemsSource = LeaderboardModel.All;
        }

    }

    
}

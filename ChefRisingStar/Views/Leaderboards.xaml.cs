using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChefRisingStar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChefRisingStar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Leaderboards : ContentPage
    {
        public Leaderboards()
        {
            InitializeComponent();
            //BindingContext = new RankingViewModel();
        }
    }
}
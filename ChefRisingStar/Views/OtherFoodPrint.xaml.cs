using ChefRisingStar.Models;
using ChefRisingStar.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChefRisingStar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtherFootPrint : ContentPage
    {
        GlobalFootPrintViewModel _viewModel;
        public ObservableCollection<FoodPrintCategories> IngredientFoodPrintCategories { get; set; }
        string title;
        public OtherFootPrint(FoodPrintCategories foodPrintCategories)
        {
            InitializeComponent();
            IngredientFoodPrintCategories = new ObservableCollection<FoodPrintCategories>();
            IngredientFoodPrintCategories.Add(foodPrintCategories);
            BindingContext = this;
        }

    }
}


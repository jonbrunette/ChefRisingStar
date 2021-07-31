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
    public partial class FootPrintPage : ContentPage
    {
        GlobalFootPrintViewModel _viewModel;
        public ObservableCollection<FoodPrint> IngredientFoodPrint { get; set; }
        public ObservableCollection<FoodPrintCategories> IngredientFoodPrintCategories { get; set; }
        string ingredient;
        public FootPrintPage(FoodPrint foodprint, FoodPrintCategories foodPrintCategories)
        {
            InitializeComponent();
            IngredientFoodPrint = new ObservableCollection<FoodPrint>();
            IngredientFoodPrintCategories = new ObservableCollection<FoodPrintCategories>();
            ingredient = foodprint.Ingredient;            
            IngredientFoodPrint.Add(foodprint);
            IngredientFoodPrintCategories.Add(foodPrintCategories);
            BindingContext = this;
        }

        public async void Next(object sender, EventArgs e)
        {
            FoodPrintCategories foodPrintCategories = new FoodPrintCategories();
            foreach (var i in IngredientFoodPrintCategories)
            {
                if (i.Ingredient == ingredient)
                {
                    foodPrintCategories = i;
                }                
            }
            await Navigation.PushAsync(new OtherFootPrint(foodPrintCategories));
        }

    }
}


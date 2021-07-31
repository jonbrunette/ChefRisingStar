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
    public partial class GlobalFootPrintPage : ContentPage
    {
        GlobalFootPrintViewModel _viewModel;
        public GlobalFootPrintPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new GlobalFootPrintViewModel();
        }

        private void IngredientLongPressed(object sender, EventArgs e)
        {
        }

        private async void SelectedIngredient(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is ExtendedIngredients selectedRecipe)
            {
                FoodPrint foodPrint = new FoodPrint();
                FoodPrintCategories foodPrintCategories = new FoodPrintCategories();
                foreach(var i in _viewModel.foodPrint)
                {
                    if(i.Ingredient == selectedRecipe.Name)
                    {
                        foodPrint = i;
                    }
                }
                foreach (var i in _viewModel.foodPrintCategories)
                {
                    if (i.Ingredient == selectedRecipe.Name)
                    {
                        foodPrintCategories = i;
                    }
                }
                await Navigation.PushAsync(new FootPrintPage(foodPrint, foodPrintCategories));
            }
        }
    }
}


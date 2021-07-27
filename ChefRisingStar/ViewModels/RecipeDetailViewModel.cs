﻿using ChefRisingStar.Helpers;
using ChefRisingStar.Models;
using ChefRisingStar.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChefRisingStar.ViewModels
{
    public class RecipeDetailViewModel : BaseViewModel
    {
        #region Members
        private bool _isSubstitutionVisible;
        private Recipe _recipe;
        private string _selectedSubstitution;
        #endregion Members

        #region Properties

        public Recipe Recipe
        {
            get => _recipe;
            set
            {
                if (_recipe == value)
                    return;

                _recipe = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Substitutions { get; protected set; }

        public bool IsSubstitutionVisible
        {
            get => _isSubstitutionVisible;
            set
            {
                _isSubstitutionVisible = value;
                OnPropertyChanged();
            }
        }
        
        public string SelectedSubstitution
        {
            get => _selectedSubstitution;
            set
            {
                _selectedSubstitution = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Step> Instructions { get; protected set; }


        #endregion Properties

        #region Commands

        public Command LoadUrlCommand { get; }
        public Command OpenSubstitutionsCommand { get; }

        #endregion 

        #region Constructors

        public RecipeDetailViewModel(Recipe recipe)
        {
            Title = recipe.Title;
            Recipe = recipe;

            Instructions = new ObservableCollection<Step>();
            Substitutions = new ObservableCollection<string>();

            foreach (AnalyzedInstruction ins in Recipe.AnalyzedInstructions)
            {
                foreach (Step step in ins.Steps)
                    Instructions.Add(step);
            }

            //Eventually use commanding
            //OpenSubstitutionsCommand = new Command(async () => await GetSubstitutions<object>(null));
            //OpenSubstitutionsCommand = new Command<Type>(
            //async (Type pageType) =>
            //{
            //    Page page = (Page)Activator.CreateInstance(pageType);
            //    await Navigation.PushAsync(page);
            //});
        }

        #endregion 

        #region Methods

        /*
        async Task ExecuteLoadUrlCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Launcher.OpenAsync(new Uri(recipe.url));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get recipes: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }*/

        internal async Task GetSubstitutions(string ingredientName)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            SubstitutionCache cache = DependencyService.Get<SubstitutionCache>();

            if(cache.Contains(ingredientName))
            {
                Substitutions.Clear();

                foreach (SubstituteIngredient[] substitutes in cache.Get(ingredientName))
                {
                    Substitutions.Add(SubstitutionHelper.StringFormat(substitutes));
                }

                IsBusy = false;
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://api.spoonacular.com/food/ingredients/substitutes");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Add an Accept header for JSON format.
                    var streamTask = client.GetStreamAsync($"?apiKey=61f0c9888f5542a6b3604a030707b8ad&ingredientName={ingredientName}");

                    var substitution = await JsonSerializer.DeserializeAsync<Substitution>(await streamTask);

                    // string strResponse = "{\"status\":\"success\",\"ingredient\":\"butter\",\"substitutes\":[\"1 cup = 7 / 8 cup shortening and 1 / 2 tsp salt\",\"1 cup = 7 / 8 cup vegetable oil + 1 / 2 tsp salt\",\"1 / 2 cup = 1 / 4 cup buttermilk +1 / 4 cup unsweetened applesauce\",\"1 cup = 1 cup margarine\"],\"message\":\"Found 4 substitutes for the ingredient.\"}";
                    // var substitution = JsonSerializer.Deserialize<Substitution>(strResponse);

                    Substitutions.Clear();
                    
                    if(substitution.Status.ToLower() == "failure")
                    {
                        Substitutions.Add(substitution.Message);
                        cache.Add(ingredientName, SubstitutionHelper.GetNoSubstituteItem());
                        IsBusy = false;
                        return;
                    }

                    List<SubstituteIngredient[]> subs = new List<SubstituteIngredient[]>();

                    foreach(string s in substitution.Substitutes)
                    {
                        SubstituteIngredient[] substituteIngredients = SubstitutionHelper.ParseSubstitution(s);
                        subs.Add(substituteIngredients);
                        Substitutions.Add(SubstitutionHelper.StringFormat(substituteIngredients));
                    }
                    
                    cache.Add(ingredientName, subs);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting substitutions: {ex}");
                    await Application.Current.MainPage.DisplayAlert("API Error:", ex.Message, "OK");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
        
        internal async Task GetIngredientByName(string ingredientName)
        {
            if (IsBusy)
                return;

            IsBusy = true;

            IngredientCache cache = DependencyService.Get<IngredientCache>();

            if (cache.Contains(ingredientName))
            {
                Substitutions.Clear();

                cache.Get(ingredientName);
                
                IsBusy = false;
                return;
            }

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("https://api.spoonacular.com/food/ingredients/autocomplete");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Add an Accept header for JSON format.
                    //var streamTask = client.GetStringAsync($"?apiKey=61f0c9888f5542a6b3604a030707b8ad&query={ingredientName}&number=1&metaInformation=true");
                    //var str = await streamTask;
                    var streamTask = client.GetStreamAsync($"?apiKey=61f0c9888f5542a6b3604a030707b8ad&query={ingredientName}&number=1&metaInformation=true");
                    var ingredients = await JsonSerializer.DeserializeAsync<IngredientSearch[]>(await streamTask);

                    if(ingredients != null && ingredients.Length >0)
                        cache.Add(ingredientName, ingredients[0]);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error getting IngredientByName: {ex}");
                    await Application.Current.MainPage.DisplayAlert("API Error:", ex.Message, "OK");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
        #endregion
    }
}
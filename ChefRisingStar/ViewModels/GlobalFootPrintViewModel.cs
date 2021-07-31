using ChefRisingStar.Models;
using ChefRisingStar.Views;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using System.Text.RegularExpressions;

namespace ChefRisingStar.ViewModels
{
    public class GlobalFootPrintViewModel : BaseViewModel
    {
        public List<RecipeItems> recipeLists { get; set; }
        public List<FoodPrint> foodprintData = new List<FoodPrint>();
        public List<FoodPrintCategories> foodprintDataCategories = new List<FoodPrintCategories>();
        public IDictionary<string, FoodPrint> calculatedFoodPrint = new Dictionary<string, FoodPrint>();
        public IDictionary<string, FoodPrintCategories> calculatedFoodPrintCategories = new Dictionary<string, FoodPrintCategories>();

        public ObservableCollection<ExtendedIngredients> Ingredients { get; set; }
        public ObservableCollection<FoodPrint> foodPrint { get; set; }
        public ObservableCollection<FoodPrintCategories> foodPrintCategories { get; set; }

        private bool _isSelectedIngredient;

        public bool IsSelectedIngredient
        {
            get { return _isSelectedIngredient; }
            set { SetProperty(ref _isSelectedIngredient, value); }
        }

        public IDictionary<string, double> tableSpoon = new Dictionary<string, double>
        { { "water", 15 }, {"flour", 7 }, {"almond_flour", 6 }, { "bread_flour", 8 },
            {"wheat", 7 },{"baking_powder", 13 },{"bicarb", 10 }, {"baking_soda", 10 },
            {"brown_sugar", 12 }, {"sugar", 12 }, {"honey", 21 }, {"maple_syrup", 19 },
            {"stevia", 6 },{ "butter", 14 }, {"lard" , 13}, {"margarine", 14 }, {"oil", 13},
            {"milk", 15 }, {"condensed_milk", 19}, {"cream", 15}, {"breadcrumbs", 6}, {"cinnamon", 8},
            {"cocoa", 9 }, {"cumin", 8}, {"coffee", 5}, {"jam", 20}, {"mayonnaise", 13}, {"peanut_butter", 18},
            {"salt", 18 }, {"turmeric", 9}, {"yeast", 14}, {"yogurt", 15}, {"other", 15} };

        public IDictionary<string, double> teaSpoon = new Dictionary<string, double>
        { { "water", 5 }, {"flour", 2 }, {"almond_flour", 2 }, { "bread_flour", 2 },
            {"wheat", 2 },{"baking_powder", 4 },{"bicarb", 4 }, {"baking_soda", 3 },
            {"brown_sugar", 4 }, {"sugar", 4 }, {"honey", 7 }, {"maple_syrup", 6 },
            {"stevia", 2 },{ "butter", 4 }, {"lard", 4 }, {"margarine", 4 }, {"oil", 4},
            {"milk", 5 }, {"condensed_milk", 6 }, {"cream", 5}, {"breadcrumbs", 2}, {"cinnamon", 2},
            {"cocoa", 3 }, {"cumin", 2}, {"coffee", 1}, {"jam", 6}, {"mayonnaise", 4}, {"peanut_butter", 6},
            {"salt", 6 }, {"turmeric", 3}, {"yeast", 4}, {"yogurt", 5}, {"other", 4} };

        public IDictionary<string, double> cup = new Dictionary<string, double>
        { { "water", 250 }, {"flour", 132 }, {"almond_flour", 101 }, { "bread_flour", 137 },
            {"wheat", 119 },{"baking_powder", 225 },{"bicarb", 172 }, {"baking_soda", 172 },
            {"brown_sugar", 205 }, {"sugar", 212 }, {"honey", 355 }, {"maple_syrup", 330 },
            {"stevia", 110 },{ "butter", 239 }, {"lard" , 229 }, {"margarine", 243 }, {"oil", 231 },
            {"milk", 258 }, {"condensed_milk", 323 }, {"cream", 253 }, {"breadcrumbs", 112 }, {"cinnamon", 140 },
            {"cocoa", 160 }, {"cumin", 142 }, {"coffee", 85}, {"jam", 333 }, {"mayonnaise", 227 }, {"peanut_butter", 300 },
            {"salt", 300 }, {"turmeric", 160 }, {"yeast", 237}, {"yogurt", 240 }, {"other", 128} , {"almond", 115 }, {"cashew", 125 },
            {"peanut", 160}, {"pecan", 116 }, {"seeds", 155 }, {"walnut", 123 }, {"apple", 160}, {"avocado", 158 }, {"corn", 180},
            {"potatoes", 192}, {"bran", 64}, {"chocolate", 132 }, {"chocolate_chip", 180}, {"coconut", 88 }, {"dried fruits", 178 },
            {"juice", 265 }, {"oats", 108 }, {"rice", 144 }, {"cheese", 272 }, {"rye", 176 } };

        public IDictionary<string, double> OZ = new Dictionary<string, double>
        {
            {"other", 28 }
        };

        public IDictionary<string, double> ML = new Dictionary<string, double>
        {
            {"other", 1 }
        };

        public GlobalFootPrintViewModel()
        {
            Title = "Your Food Prints";      
            List<ExtendedIngredients> extendedIngredient1 = new List<ExtendedIngredients>()
            {
                new ExtendedIngredients { Image = "apple.jpg", Name = "apples", Amount = 7, Unit = "" },
                new ExtendedIngredients { Image = "apricot.jpg", Name = "apricot", Amount = 4, Unit = "Tbs" },
                new ExtendedIngredients { Image = "butter-sliced.jpg", Name = "butter", Amount = 1, Unit = "stick" },
                new ExtendedIngredients { Image = "cinnamon.jpg", Name = "cinnamon", Amount = 0.5, Unit = "teaspoon" },
                new ExtendedIngredients { Image = "cream-cheese.jpg", Name = "cream cheese", Amount = 2, Unit = "oz" },
                new ExtendedIngredients { Image = "egg.jpg", Name = "egg", Amount = 2, Unit = "" },
                new ExtendedIngredients { Image = "graham-crackers.jpg", Name = "graham crackers", Amount = 8, Unit = "" },
                new ExtendedIngredients { Image = "pecans.jpg", Name = "pecans", Amount = 0.25, Unit = "cup" },
                new ExtendedIngredients { Image = "sugar-in-bowl.jpg", Name = "sugar", Amount = 0.5, Unit = "cup" },
                new ExtendedIngredients { Image = "vanilla-extract.jpg", Name = "vanilla", Amount = 0.5, Unit = "tsp" }

            };

            List<ExtendedIngredients> extendedIngredient2 = new List<ExtendedIngredients>()
            {
                new ExtendedIngredients { Image = "hard-boiled.jpg", Name = "hard boiled", Amount = 12, Unit = "" },
                new ExtendedIngredients { Image = "mayonnaise.jpg", Name = "mayonnaise", Amount = 4, Unit = "tablespoons" },
                new ExtendedIngredients { Image = "regular-mustard.jpg", Name = "yellow mustard", Amount = 2, Unit = "teaspoons" },
                new ExtendedIngredients { Image = "salt.jpg", Name = "salt", Amount = 1, Unit = "teaspoon" },
                new ExtendedIngredients { Image = "granulated-garlic.jpg", Name = "granulated garlic", Amount = 1, Unit = "teaspoons" },
                new ExtendedIngredients { Image = "pepper.jpg", Name = "ground pepper", Amount = 0.5, Unit = "teaspoon" },
                new ExtendedIngredients { Image = "paprika.jpg", Name = "paprika", Amount = 1, Unit = "serving" },
                new ExtendedIngredients { Image = "pecans.jpg", Name = "pecans", Amount = 0.25, Unit = "cup" },
                new ExtendedIngredients { Image = "sugar-in-bowl.jpg", Name = "sugar", Amount = 0.5, Unit = "cup" },
                new ExtendedIngredients { Image = "vanilla-extract.jpg", Name = "vanilla", Amount = 0.5, Unit = "tsp" }

            };

            recipeLists = new List<RecipeItems>()
            {
                new RecipeItems {Vegetarian = true, Vegan = false, DairyFree = false, SpoonacularScore = 24, ExtendedIngredients = extendedIngredient1, Title = "Autumn Cheesecake", Servings = 8, SourceUrl = "http://www.foodista.com/recipe/2HQGVX53/autumn-cheesecake",
                ImageUrl = "https://spoonacular.com/recipeImages/633091-556x370.jpg" },
                new RecipeItems {Vegetarian = true, Vegan = false, DairyFree = true, SpoonacularScore = 93, ExtendedIngredients = extendedIngredient2, Title = "Blasian's Deviled Eggs", Servings = 1, SourceUrl = "https://www.foodista.com/recipe/NWGPVRTM/blasians-deviled-eggs",
                ImageUrl = "https://spoonacular.com/recipeImages/633091-556x370.jpg" }

            };

            Ingredients = fetchIngredients();
            foodPrint = fetchAllFoodPrint();
            foodPrintCategories = fetchAllFoodPrintCategories();

        }

        public GlobalFootPrintViewModel(ExtendedIngredients item)
        {
            fetchfoodPrintByIngredient(item);
        }

        public void fetchfoodPrintByIngredient(ExtendedIngredients item)
        {
            String name = item.Name;
            String unit = item.Unit;
            double amount = item.Amount;
            if(foodPrint != null)
            {
                bool isExist = checkIfExistFoodPrint(name);
                Debug.WriteLine($"step 1 {isExist}");
                if (!isExist)
                {
                    double conversionVal = converToGrams(name, amount, unit);
                    Categories fC = new Categories();
                    IDictionary<string, List<string>> categories = fC.getCategories();
                    OtherCategories OC = new OtherCategories();
                    IDictionary<string, List<string>> othercategories = OC.getCategories();
                    FoodPrint fCData = matchedCategory(categories, name, conversionVal);
                    if(fCData != null)
                    {
                        foodPrint.Add(fCData);
                    }
                    
                    _isSelectedIngredient = true;
                }
            }
        }

        public ObservableCollection<FoodPrint> fetchAllFoodPrint()
        {
            Categories fC = new Categories();
            IDictionary<string, List<string>> categories = fC.getCategories();
            OtherCategories OC = new OtherCategories();
            IDictionary<string, List<string>> othercategories = OC.getCategories();
            ObservableCollection<FoodPrint> allFoodPrints = new ObservableCollection<FoodPrint>();

            recipeLists.ForEach(recipe =>
            {
                recipe.ExtendedIngredients.ForEach(item =>
                {
                    if(foodPrint!= null)
                    {
                        if (!checkIfExistFoodPrint(item.Name))
                        {
                            double conversionVal = converToGrams(item.Name, item.Amount, item.Unit);
                            FoodPrint fc = matchedCategory(categories, item.Name, conversionVal);
                            if (fc != null)
                            {
                                allFoodPrints.Add(fc);
                            }
                        }
                    } else
                    {
                        double conversionVal = converToGrams(item.Name, item.Amount, item.Unit);
                        FoodPrint fc = new FoodPrint();
                        fc = matchedCategory(categories, item.Name, conversionVal);
                        Debug.WriteLine($"{fc}");
                        if (fc != null)
                        {
                            allFoodPrints.Add(fc);
                        }
                    }
                });
            });
            return allFoodPrints;
        }

        public ObservableCollection<FoodPrintCategories> fetchAllFoodPrintCategories()
        { 
            Categories fC = new Categories();
            IDictionary<string, List<string>> categories = fC.getCategories();
            OtherCategories OC = new OtherCategories();
            IDictionary<string, List<string>> othercategories = OC.getCategories();
            ObservableCollection<FoodPrintCategories> allFoodPrints = new ObservableCollection<FoodPrintCategories>();

            recipeLists.ForEach(recipe =>
            {
                recipe.ExtendedIngredients.ForEach(item =>
                {
                    if (foodPrintCategories != null)
                    {
                        if (!checkIfExistFoodPrintCategories(item.Name))
                        {
                            double conversionVal = converToGrams(item.Name, item.Amount, item.Unit);
                            FoodPrintCategories fc = matchedOtherCategory(categories, item.Name, conversionVal);
                            if (fc != null)
                            {
                                allFoodPrints.Add(fc);
                            }
                        }
                    }
                    else
                    {
                        double conversionVal = converToGrams(item.Name, item.Amount, item.Unit);
                        FoodPrintCategories fc = new FoodPrintCategories();
                        fc = matchedOtherCategory(categories, item.Name, conversionVal);
                        Debug.WriteLine($"{fc}");
                        if (fc != null)
                        {
                            allFoodPrints.Add(fc);
                        }
                    }
                });
            });
            return allFoodPrints;
        }

        private bool checkIfExistFoodPrint(string name)
        {
            bool check = foodPrint.Any(i => i.Ingredient == name);
            return check;
        }

        private bool checkIfExistFoodPrintCategories(string name)
        {
            bool check = foodPrintCategories.Any(i => i.Ingredient == name);
            return check;
        }


        private FoodPrintCategories matchedOtherCategory(IDictionary<string, List<string>> categories, string find, double weight)
        {
            foreach (var kvp in categories)
            {
                foreach (var val in kvp.Value)
                {
                    if (findMatching(find, val))
                    {                        
                        FoodPrintCategories data = processOtherFoodPrintCategories(kvp.Key, val, weight);
                        return data;
                    }
                }
            }
            return null;
        }

        private FoodPrint matchedCategory(IDictionary<string, List<string>> categories, string find, double weight)
        {
            foreach (var kvp in categories)
            {
                foreach (var val in kvp.Value)
                {
                    if (findMatching(find, val) && val.Length > 2)
                    {
                        FoodPrint data = processFoodPrint(kvp.Key, val, weight);
                        return data;                        
                    } 
                }
            }
            return null;
        }

        private FoodPrintCategories processOtherFoodPrintCategories(string dietType, string ingredient, double weight)
        {
            foreach (FoodPrintCategories data in foodprintDataCategories)
            {
                if (findMatching(dietType, data.DietType) && (findMatching(ingredient, data.Ingredient)))
                {
                    data.LandUsage = (Math.Floor(data.LandUsage / data.Weight)) * weight;
                    data.AimalFeed = (Math.Floor(data.LandUsage / data.Weight)) * weight;
                    data.Farming = (Math.Floor(data.Farming / data.Weight)) * weight;
                    data.Packaging = (Math.Floor(data.Packaging / data.Weight)) * weight;
                    data.Processing = (Math.Floor(data.Processing / data.Weight)) * weight;
                    data.Retail = (Math.Floor(data.Retail / data.Weight)) * weight;
                    data.TotalCO2 = (Math.Floor(data.TotalCO2 / data.Weight)) * weight;
                    data.Transport = (Math.Floor(data.Transport / data.Weight)) * weight;
                    data.Waste = (Math.Floor(data.Waste / data.Weight)) * weight;
                    return data;
                }
            }
            return null;
        }

        private FoodPrint processFoodPrint(string dietType, string ingredient, double weight)
        {
            foodprintData = getJSONFoodPrintData();
            foreach(FoodPrint data in foodprintData)
            {
                if (findMatching(dietType, data.DietType) && (findMatching(ingredient, data.Ingredient)))
                {
                    data.TotalCO2 = calculateEquivalenceCO2(data, weight);
                    return data;
                }
            }
            return null;
        }

        private double calculateEquivalenceCO2(FoodPrint data, double ingredient_weight)
        {
            double co2_per_gram = Math.Floor(data.TotalCO2 / data.Weight);
            return co2_per_gram * ingredient_weight;
        }

        private double converToGrams(string name, double amount, string unit)
        {
            if(converTableSpoonToGrams(unit))
            {
                if(tableSpoon.ContainsKey(name))
                {
                    double gramsVal = tableSpoon[name];
                    return gramsVal * amount;
                } else
                {
                    double gramsVal = tableSpoon["other"];
                    return gramsVal * amount;
                }
                
            } else if (converTeaspoonToGrams(unit))
            {
                if (teaSpoon.ContainsKey(name))
                {
                    double gramsVal = teaSpoon[name];
                    return gramsVal * amount;
                } else
                {
                    double gramsVal = teaSpoon["other"];
                    return gramsVal * amount;
                }
            } else if (converOzToGrams(unit))
            {
                double gramsVal = OZ["other"];
                return gramsVal * amount;
                
            } else if(converMLToGrams(unit))
            {
                double gramsVal = ML["other"];
                return gramsVal * amount;
            } else if(converCupToGrams(unit))
            {
                if (cup.ContainsKey(name))
                {
                    double gramsVal = cup[name];
                    return gramsVal * amount;
                }
                else
                {
                    double gramsVal = cup["other"];
                    return gramsVal * amount;
                }
            }

            return amount;
        }

        private bool converTableSpoonToGrams(string unit)
        {
            string[] tablespoon = new string[3] { "tablespoon", "tbsps", "tbs" };
            foreach(string str in tablespoon)
            {
                Match match = Regex.Match(unit, str, RegexOptions.IgnoreCase);
                if(match.Success)
                {
                    return match.Success;
                }
            }
            return false;
        }

        private bool converTeaspoonToGrams(string unit)
        {
            string[] teaspoon = new string[3] { "teaspoons", "tsps", "tsp" };
            foreach (string str in teaspoon)
            {
                Match match = Regex.Match(unit, str, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    return match.Success;
                }
            }
            return false;
        }

        private bool converOzToGrams(string unit)
        {
            string[] ounces = new string[2] { "ounces", "oz" };
            foreach (string str in ounces)
            {
                Match match = Regex.Match(unit, str, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    return match.Success;
                }
            }
            return false;
        }

        private bool converMLToGrams(string unit)
        {
            string[] ml = new string[2] { "ml", "milliliters" };
            foreach (string str in ml)
            {
                Match match = Regex.Match(unit, str, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    return match.Success;
                }
            }
            return false;
        }

        private bool converCupToGrams(string unit)
        {
            string[] cup = new string[3] { "cup", "bowl", "glass" };
            foreach (string str in cup)
            {
                Match match = Regex.Match(unit, str, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    return match.Success;
                }
            }
            return false;
        }

        public ObservableCollection<ExtendedIngredients> fetchIngredients()
        {
            ObservableCollection<ExtendedIngredients> allIngredients = new ObservableCollection<ExtendedIngredients>();

            recipeLists.ForEach(recipe =>
            {
                recipe.ExtendedIngredients.ForEach(item =>
                {                    
                    ExtendedIngredients target = allIngredients.Where(i => i.Name == item.Name).FirstOrDefault();
                    int index = allIngredients.IndexOf(target);
                    if (allIngredients.Count == 0 || index == -1)
                    {
                        ExtendedIngredients ingredient = new ExtendedIngredients();
                        ingredient.Amount = item.Amount <= 1 ? 1 : item.Amount;
                        ingredient.Image = item.Image;
                        ingredient.Name = item.Name;
                        ingredient.Unit = item.Unit;
                        allIngredients.Add(ingredient);
                    }
                    else
                    {
                        ExtendedIngredients target1 = allIngredients.Where(i => i.Name == item.Name).FirstOrDefault();
                        int index1 = allIngredients.IndexOf(target1);
                        allIngredients[index1].Amount += item.Amount;
                    }
                });
            });
            return allIngredients;
        }

        public List<FoodPrint> getJSONFoodPrintData()
        {
            var assembly = typeof(GlobalFootPrintPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("ChefRisingStar.sample.foodprint.json");
            List<FoodPrint> data;
            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<FoodPrint>>(json);
            }
            return data;
        }

        public List<FoodPrintCategories> getJSONOtherCategoryData()
        {
            var assembly = typeof(GlobalFootPrintPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("ChefRisingStar.sample.otherCategory.json");
            List<FoodPrintCategories> data;
            using (var reader = new System.IO.StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<FoodPrintCategories>>(json);
            }
            return data;
        }

        private bool findMatching(string find, string val)
        {
            Match match = Regex.Match(find, val, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Success;
            }

            return match.Success;
        }
    }
}

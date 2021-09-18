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
            createListView();
        }
        public List<Rank> getRankData()
        {

            List<Rank> rankResultData = new List<Rank>();

            //string currDir = AppDomain.CurrentDomain.BaseDirectory;
            //string sFile = System.IO.Path.Combine(currDir, @"sample\ranking.json");
            string jstr = @"[
                  {
                    ""Ranking"": ""1"",
                    ""Recipe"": ""Plantain Pizza"",
                    ""Rating"": ""99.9"",
                    ""Link"": ""www.google.com""
                  },
                  {
                    ""Ranking"": ""2"",
                    ""Recipe"": ""Corned Beef"",
                    ""Rating"": ""98"",
                    ""Link"": ""www.google.com""
                  }
                    ,
                  {
                    ""Ranking"": ""3"",
                    ""Recipe"": ""Corn Bread"",
                    ""Rating"": ""92"",
                    ""Link"": ""www.google.com""
                    },
                   {
                    ""Ranking"": ""4"",
                    ""Recipe"": ""Carrot Cake"",
                    ""Rating"": ""91"",
                    ""Link"": ""www.google.com""
                    },
                   {
                    ""Ranking"": ""5"",
                    ""Recipe"": ""Taco"",
                    ""Rating"": ""84.5"",
                    ""Link"": ""www.google.com""
                    },

                    {
                    ""Ranking"": ""6"",
                    ""Recipe"": ""Chilli Soup"",
                    ""Rating"": ""82"",
                    ""Link"": ""www.google.com""
                    },

                    {
                    ""Ranking"": ""7"",
                    ""Recipe"": ""Tomato Soup"",
                    ""Rating"": ""80"",
                    ""Link"": ""www.google.com""
                    },
                    {
                    ""Ranking"": ""8"",
                    ""Recipe"": ""Fried Rice"",
                    ""Rating"": ""79"",
                    ""Link"": ""www.google.com""
                    },
                    {
                    ""Ranking"": ""9"",
                    ""Recipe"": ""Greek Salad"",
                    ""Rating"": ""78"",
                    ""Link"": ""www.google.com""
                    },
                    {
                    ""Ranking"": ""10"",
                    ""Recipe"": ""Greek Moussaka"",
                    ""Rating"": ""78"",
                    ""Link"": ""www.google.com""
                    }]";
            rankResultData = JsonConvert.DeserializeObject<List<Rank>>(jstr);
            //Console.WriteLine(rankResultData);
            return rankResultData;
        }
        public void createListView()
        {
            ListView listView = (ListView)FindByName("dataListView");
            listView.ItemsSource = getRankData(); 


        }



    }

    
}

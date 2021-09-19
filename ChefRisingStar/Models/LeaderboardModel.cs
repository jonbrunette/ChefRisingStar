using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Text;
using Newtonsoft.Json;

namespace ChefRisingStar.Models
{
    class LeaderboardModel
    {
        public string Name { get; set; }
		public Color Color { get; set; }
		public List<Rank> RankList { get; set; }

		public static IList<LeaderboardModel> All { get; set; }

		static LeaderboardModel ()
		{
			All = new ObservableCollection<LeaderboardModel> {
				new LeaderboardModel {
					Name = "Class Leaderboard",
					Color = Color.Red,
                    RankList = JsonConvert.DeserializeObject<List<Rank>>(@"[
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
                    ""Recipe"": ""Cornbread"",
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
                    ""Recipe"": ""Chili Soup"",
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
                    }]")
                }
                ,
                new LeaderboardModel {
                    Name = "School Leaderboard",
                    Color = Color.Green,
                    RankList = JsonConvert.DeserializeObject<List<Rank>>(@"[
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
                    ""Recipe"": ""Cornbread"",
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
                    ""Recipe"": ""Chili Soup"",
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
                    }]")
                }
            };
		}
	}
}

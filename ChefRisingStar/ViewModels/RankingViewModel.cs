using ChefRisingStar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;


namespace ChefRisingStar.ViewModels
{
    public class RankingViewModel : BaseViewModel
    {
   

        public Rank rankData = new Rank();
        public List<object> rankResultData = new List<object>();

        public List<Rank> rankings
        {
            get => rankings;
            set
            {
                if (rankings == value)
                    return;

                var response = File.ReadAllText("sample/ranking.json");


                rankings = JsonConvert.DeserializeObject<List<Rank>>(response);
            }
        }

        public RankingViewModel()
        {
            foreach (Rank r in rankings)
            {
                    rankResultData.Add(r);
                

            }
                
        }


        }

        
    
}
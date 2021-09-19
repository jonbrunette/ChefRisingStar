using Newtonsoft.Json;
using System.Diagnostics;

namespace ChefRisingStar.Models
{

    


    public class rankingModel: BaseNotifyModel
    {
        private string _Id;

        private string _recipeName;

        private string _Rating;

        private string _Link;


        public string Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        public string RecipeName
        {
            get { return _recipeName; }
            set { SetProperty(ref _recipeName, value); }
        }


        public string Rating
        {
            get { return _Rating; }
            set { SetProperty(ref _Rating, value); }
        }

        public string Link
        {
            get { return _Link; }
            set { SetProperty(ref _Link, value); }
        }

    }
}

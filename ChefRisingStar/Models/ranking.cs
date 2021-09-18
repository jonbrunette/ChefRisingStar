using Newtonsoft.Json;
using System.Diagnostics;


namespace ChefRisingStar.Models
{

    [DebuggerDisplay("{GetDebuggerDisplay}")]
    public class Rank
    {
        [JsonProperty("Ranking")]
        public string Ranking { get; set; }

        [JsonProperty("Recipe")]
        public string Recipe { get; set; }

        [JsonProperty("Rating")]
        public string Rating { get; set; }

        [JsonProperty("Link")]
        public string Link { get; set; }
    }
}

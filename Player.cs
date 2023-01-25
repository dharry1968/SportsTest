using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SportsTest
{
    [Serializable]
    internal class Player
    {
        [JsonProperty]
        public int player_id;
        [JsonProperty]
        public string firstname;
        [JsonProperty]
        public string lastname;
        [JsonProperty]
        public string birthday;
        [JsonProperty]
        public int? age;
        [JsonProperty]
        public int? weight;
        [JsonProperty]
        public int? height;
        [JsonProperty]
        public string img;
        [JsonProperty]
        public Country country;
    }

    [Serializable]
    class Country
    {
        [JsonProperty]
        public int country_id;        
        [JsonProperty]
        public string name;
        [JsonProperty]
        public string country_code;
        [JsonProperty]
        public string continent;
    }

    [Serializable]
    class Data
    {
        public List<Player> data;
    }

    [Serializable]
    class Query
    {
        [JsonProperty]
        public int country_id;
        [JsonProperty]
        public int max_age;
        [JsonProperty]
        public string apikey;
    }

    [Serializable]
    class RootObject
    {
        [JsonProperty]
        public Query query;
        [JsonProperty]
        public List<Player> data;
    }
}

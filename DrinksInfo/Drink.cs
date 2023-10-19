using Newtonsoft.Json;
using System.Text.Json;

namespace DrinksInfo
{
    internal class Drink
    {
        public string idDrink {  get; set; }

        public string strDrink { get; set; }
    }

    internal class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinksList { get; set; }
    }
}

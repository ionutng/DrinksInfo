using Newtonsoft.Json;
using RestSharp;
using ConsoleTableExt;
using System.Web;

namespace DrinksInfo
{
    internal class DrinksService
    {
        internal void GetCategories()
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.Get(request);

            var serialize = JsonConvert.DeserializeObject<Categories>(response.Content);

            List<Category> returnedList = serialize.CategoriesList;

            Console.Clear();

            Output.ShowTable(returnedList, "Categories Menu");
        }

        internal void GetDrinksByCategory(string category)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.Get(request);

            var serialize = JsonConvert.DeserializeObject<Drinks>(response.Content);

            List<Drink> returnedList = serialize.DrinksList;

            Output.ShowTable(returnedList, "Drinks Menu");
        }
    }
}

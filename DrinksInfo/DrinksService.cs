using Newtonsoft.Json;
using RestSharp;
using ConsoleTableExt;
using System.Web;
using System.Reflection;

namespace DrinksInfo
{
    internal class DrinksService
    {
        internal List<Category> GetCategories()
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response = client.Get(request);

            List<Category> categories = new();

            var serialize = JsonConvert.DeserializeObject<Categories>(response.Content);

            categories = serialize.CategoriesList;

            Output.ShowTable(categories, "Categories Menu");

            return categories;
        }

        internal List<Drink> GetDrinksByCategory(string category)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"filter.php?c={HttpUtility.UrlEncode(category)}");
            var response = client.Get(request);

            List<Drink> drinks = new();

            var serialize = JsonConvert.DeserializeObject<Drinks>(response.Content);

            drinks = serialize.DrinksList;

            Output.ShowTable(drinks, "Drinks Menu");

            return drinks;
        }

        internal void GetDrink(string drinkId)
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest($"lookup.php?i={drinkId}");
            var response = client.Get(request);

            var serialize = JsonConvert.DeserializeObject<DrinkDetails>(response.Content);

            List<DrinkDetail> returnedList = serialize.DrinkDetailsList;

            DrinkDetail drinkDetail = returnedList[0];

            List<object> prepList = new();

            string formattedName = "";

            foreach (PropertyInfo property in drinkDetail.GetType().GetProperties())
            {
                if (property.Name.Contains("str")) 
                    formattedName = property.Name[3..];

                if (!string.IsNullOrEmpty(property.GetValue(drinkDetail)?.ToString()))
                    prepList.Add(new
                    {
                        Key = formattedName,
                        Value = property.GetValue(drinkDetail)
                    });
            }

            Output.ShowTable(prepList, drinkDetail.strDrink);
        }
    }
}

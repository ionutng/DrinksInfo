using Newtonsoft.Json;
using RestSharp;
using ConsoleTableExt;

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

            ConsoleTableBuilder
                .From(returnedList)
                .WithTitle("Categories Menu", ConsoleColor.Red)
                .WithColumn()
                .ExportAndWriteLine();
            Console.WriteLine("\n\n");
        }
    }
}

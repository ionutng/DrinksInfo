namespace DrinksInfo
{
    internal class UserInput
    {
        DrinksService drinksService = new();

        internal void GetCategoriesInput()
        {
            drinksService.GetCategories();

            Console.WriteLine("Choose a category:");

            string category = Console.ReadLine();

            while (!Validation.IsStringValid(category))
            {
                Console.WriteLine("Category doesn't exist!");
                category = Console.ReadLine();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            drinksService.GetDrinksByCategory(category);
        }
    }
}

namespace DrinksInfo
{
    internal class UserInput
    {
        DrinksService drinksService = new();

        internal void GetCategoriesInput()
        {
            var categories = drinksService.GetCategories();

            Console.WriteLine("Choose a category:");

            string category = Console.ReadLine();

            while (!Validation.IsStringValid(category))
            {
                Console.WriteLine("Incorrect category!");
                category = Console.ReadLine();
            }

            if (!categories.Any(e => e.strCategory.ToLower() == category.ToLower()))
            {
                Console.WriteLine("Category doesn't exist!");
                GetCategoriesInput();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            var drinks = drinksService.GetDrinksByCategory(category);

            Console.WriteLine("Choose the id of a drink or Type 0 to return to the category menu.");

            string drinkId = Console.ReadLine();

            if (drinkId == "0")
                GetCategoriesInput();

            while (!Validation.IsIdValid(drinkId))
            {
                Console.WriteLine("Incorrect id!");
                drinkId = Console.ReadLine();
            }

            if (!drinks.Any(e => e.idDrink == drinkId))
            {
                Console.WriteLine("Drink id doesn't exist!");
                GetDrinksInput(category);
            }

            drinksService.GetDrink(drinkId);

            Console.WriteLine("Press 0 to exit the application or press any other key to go back to the categories menu.");
            if (Console.ReadLine() == "0")
                Environment.Exit(0);
            else
                GetCategoriesInput();
        }
    }
}

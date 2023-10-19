namespace DrinksInfo
{
    internal class Validation
    {
        internal static bool IsStringValid(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput))
                return false;

            foreach (char character in stringInput)
                if (!char.IsLetter(character) && character != '/' && character != ' ')
                    return false;

            return true;
        }
    }
}

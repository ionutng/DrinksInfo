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

        internal static bool IsIdValid(string id)
        {
            if (string.IsNullOrEmpty(id))
                return false;

            foreach (char character in id)
                if (!char.IsDigit(character))
                    return false;

            return true;
        }
    }
}

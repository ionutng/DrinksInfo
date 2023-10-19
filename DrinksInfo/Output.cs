using ConsoleTableExt;

namespace DrinksInfo
{
    internal class Output
    {
        public static void ShowTable<T> (List<T> tableData, string tableName) where T : class
        {
            Console.Clear();

            ConsoleTableBuilder
                .From(tableData)
                .WithTitle($"{tableName}", ConsoleColor.Red)
                .WithColumn()
                .ExportAndWriteLine();
        }
    }
}

namespace Helpers.Array;

public static class ArrayHelper
{
    public static void Print2DArray(int[][] array)
    {
        string[] rows = new string[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            rows[i] = $"[{string.Join(",", array[i])}]";
        }

        Console.WriteLine($"[{string.Join(",\n ", rows)}]");
    }

    public static void Print2DArray(int[,] array)
    {
        string[] rows = new string[array.GetLength(0)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            List<int> values = [];
            for (int j = 0; j < array.GetLength(1); j++)
            {
                values.Add(array[i, j]);
            }
            rows[i] = $"[{string.Join(",", values)}]";
        }

        Console.WriteLine($"[{string.Join(",\n ", rows)}]");
    }

    public static void Print2DArray(IList<IList<int>> array)
    {
        string[] rows = new string[array.Count];
        for (int i = 0; i < array.Count; i++)
        {
            rows[i] = $"[{string.Join(",", array[i])}]";
        }

        Console.WriteLine($"[{string.Join(",\n ", rows)}]");
    }
}
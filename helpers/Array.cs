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

        Console.WriteLine($"[{string.Join(",", rows)}]");
    }

    public static void Print2DArray(IList<IList<int>> array)
    {
        string[] rows = new string[array.Count];
        for (int i = 0; i < array.Count; i++)
        {
            rows[i] = $"[{string.Join(",", array[i])}]";
        }

        Console.WriteLine($"[{string.Join(",", rows)}]");
    }
}
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
}
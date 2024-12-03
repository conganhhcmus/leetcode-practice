namespace Helpers;

public static class ArrayHelper
{
    public static string Print2DArray<T>(T[][] array)
    {
        string[] rows = new string[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            rows[i] = $"[{string.Join(",", array[i])}]";
        }

        return JsonConvert.SerializeObject(rows);
    }

    public static string Print2DArray<T>(T[,] array)
    {
        string[] rows = new string[array.GetLength(0)];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            List<T> values = [];
            for (int j = 0; j < array.GetLength(1); j++)
            {
                values.Add(array[i, j]);
            }
            rows[i] = $"[{string.Join(",", values)}]";
        }

        return JsonConvert.SerializeObject(rows);
    }

    public static string Print2DArray<T>(IList<IList<T>> array)
    {
        string[] rows = new string[array.Count];
        for (int i = 0; i < array.Count; i++)
        {
            rows[i] = $"[{string.Join(",", array[i])}]";
        }

        return JsonConvert.SerializeObject(rows);
    }
}
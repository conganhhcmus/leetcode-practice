namespace Practice_2002;
using System.Text;

public class Solution
{
    public static void Execute()
    {
        var original = new[] { 1, 2, 3, 4 };
        var m = 2;
        var n = 2;
        var solution = new Solution();
        var res = solution.Construct2DArray(original, m, n);

        var builder = new StringBuilder();
        builder.Append('[');
        for (int i = 0; i < res.Length; i++)
        {
            builder.Append('[');
            builder.Append(string.Join(",", res[i]));
            builder.Append(']');
            if (i < res.Length - 1)
            {
                builder.Append(',');
            }
        }
        builder.Append(']');
        Console.WriteLine(builder.ToString());
    }
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        if (m * n != original.Length) return [];
        var res = new int[m][];
        for (int i = 0; i < m; i++)
        {
            res[i] = new int[n];
            for (int j = 0; j < n; j++)
            {
                res[i][j] = original[i * n + j];
            }
        }
        return res;
    }
}
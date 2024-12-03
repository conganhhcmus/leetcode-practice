namespace Problem_2002;
using System.Text;

public class Solution
{
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
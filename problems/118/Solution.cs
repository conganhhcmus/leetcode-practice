public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        int[][] f = new int[numRows][];
        f[0] = [1];
        for (int i = 1; i < numRows; i++)
        {
            int n = f[i - 1].Length;
            f[i] = new int[n + 1];
            f[i][0] = f[i][n] = 1;
            for (int j = 1; j < n; j++)
            {
                f[i][j] = f[i - 1][j - 1] + f[i - 1][j];
            }
        }
        return f;
    }
}
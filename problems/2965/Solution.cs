public class Solution
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        int n = grid.Length;
        bool[] values = new bool[n * n + 1];
        int a = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (values[grid[i][j]]) a = grid[i][j];
                values[grid[i][j]] = true;
            }
        }

        int b = 0;

        for (int i = 1; i <= n * n; i++)
        {
            if (!values[i])
            {
                b = i;
                break;
            }
        }

        return [a, b];
    }
}
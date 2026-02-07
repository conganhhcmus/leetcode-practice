public class Solution
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        long m = grid.Length;
        long n = m * m;
        long sum = n * (n + 1) / 2; // 1 + 2 + 3 + ... + n = n * (n + 1) / 2
        long sumSquared = n * (n + 1) * (2 * n + 1) / 6; // 1^2 + 2^2 + 3^2 + .. + n^2 = n * (n + 1) * (2n + 1) / 6
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                sum -= grid[i][j];
                sumSquared -= grid[i][j] * grid[i][j];
            }
        }

        // sum = b - a
        // sumSquared = b^2 - a^2 = (b + a) * (b - a))
        // b = (sumSquared / sum + sum)/2
        // a = b- sum
        long b = (sumSquared / sum + sum) / 2;
        long a = b - sum;
        return [(int)a, (int)b];
    }
}
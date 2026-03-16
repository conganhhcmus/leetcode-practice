public class Solution
{
    public int[] GetBiggestThree(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        int size = Math.Min(m, n) / 2;
        int t1 = 0, t2 = 0, t3 = 0;

        for (int s = size; s >= 0; s--)
        {
            for (int i = s; i < m - s; i++)
            {
                for (int j = s; j < n - s; j++)
                {
                    // calc rhombus sum
                    // grid[i][j-size] +...+ grid[i-size][j]
                    // grid[i-size][j] +...+ grid[i][j+size]
                    // grid[i][j+size] +...+ grid[i+size][j]
                    // grid[i+size][j] +...+ grid[i][j-size]
                    int sum = 0;
                    if (s == 0) sum = grid[i][j];
                    for (int k = 0; k < s; k++)
                    {
                        sum += grid[i - k][j - s + k];
                        sum += grid[i - s + k][j + k];
                        sum += grid[i + k][j + s - k];
                        sum += grid[i + s - k][j - k];
                    }

                    // update max
                    if (sum == t1 || sum == t2 || sum == t3) continue;
                    if (sum > t1)
                    {
                        t3 = t2;
                        t2 = t1;
                        t1 = sum;
                    }
                    else if (sum > t2)
                    {
                        t3 = t2;
                        t2 = sum;
                    }
                    else if (sum > t3)
                    {
                        t3 = sum;
                    }
                }
            }
        }

        int len = (t1 > 0 ? 1 : 0) + (t2 > 0 ? 1 : 0) + (t3 > 0 ? 1 : 0);
        int[] ans = new int[len];
        if (t1 > 0) ans[0] = t1;
        if (t2 > 0) ans[1] = t2;
        if (t3 > 0) ans[2] = t3;
        return ans;
    }
}
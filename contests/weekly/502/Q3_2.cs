public class Solution
{
    public int CountLocalMaximums(int[][] matrix)
    {
        int n = matrix.Length, m = matrix[0].Length;
        int k = (int)Math.Log2(m) + 1;
        int[,,] ST = new int[n, m, k];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                ST[i, j, 0] = matrix[i][j];
            }
            for (int t = 1; t < k; t++)
            {
                int len = 1 << t;
                int half = 1 << (t - 1);
                for (int j = 0; j < m - len + 1; j++)
                {
                    ST[i, j, t] = Math.Max(ST[i, j, t - 1], ST[i, j + half, t - 1]);
                }
            }
        }
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int x = matrix[i][j];
                if (x == 0) continue;
                bool isLocalMax = true;
                for (int t = Math.Max(0, i - x); t < Math.Min(n, i + x + 1); t++)
                {
                    int st = Math.Max(0, j - x);
                    int ed = Math.Min(m - 1, j + x);
                    if (t == i - x || t == i + x)
                    {
                        if (st == j - x) st++;
                        if (ed == j + x) ed--;
                    }
                    if (st > ed) continue;
                    int len = ed - st + 1;
                    int bit = (int)Math.Log2(len);
                    int max = Math.Max(ST[t, st, bit], ST[t, ed - (1 << bit) + 1, bit]);
                    if (max > x)
                    {
                        isLocalMax = false;
                        break;
                    }
                }
                if (isLocalMax) count++;
            }
        }
        return count;
    }
}

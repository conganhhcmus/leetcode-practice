public class Solution
{
    public int NumberOfRoutes(string[] grid, int d)
    {
        int n = grid.Length, m = grid[0].Length;
        int M = (int)1e9 + 7;
        long[,] up = new long[n, m];
        long[,] same = new long[n, m];
        int sameReach = d;
        int upReach = (int)Math.Sqrt(1L * d * d - 1);
        for (int c = 0; c < m; c++)
        {
            if (grid[n - 1][c] == '.') up[n - 1, c] = 1;
        }

        for (int r = n - 1; r >= 0; r--)
        {
            // move same row
            // up[r][c] => same[r][c]
            long[] prefUp = new long[m];
            prefUp[0] = up[r, 0];
            for (int c = 1; c < m; c++)
            {
                prefUp[c] = (prefUp[c - 1] + up[r, c]) % M;
            }
            for (int c = 0; c < m; c++)
            {
                if (grid[r][c] == '#') continue;
                int st = Math.Max(0, c - sameReach);
                int ed = Math.Min(m - 1, c + sameReach);
                long val = prefUp[ed];
                if (st > 0) val -= prefUp[st - 1];
                // remove self
                val -= up[r, c];
                val %= M;
                if (val < 0) val += M;
                same[r, c] = val;
            }
            if (r == 0) break;
            // move up
            // (up + same)[r][x] => up[r-1][c]
            long[] tot = new long[m];
            for (int c = 0; c < m; c++)
            {
                tot[c] = (up[r, c] + same[r, c]) % M;
            }
            long[] prefTot = new long[m];
            prefTot[0] = tot[0];
            for (int c = 1; c < m; c++)
            {
                prefTot[c] = (prefTot[c - 1] + tot[c]) % M;
            }
            for (int c = 0; c < m; c++)
            {
                if (grid[r - 1][c] == '#') continue;
                int st = Math.Max(0, c - upReach);
                int ed = Math.Min(m - 1, c + upReach);

                long val = prefTot[ed];
                if (st > 0) val -= prefTot[st - 1];
                val %= M;
                if (val < 0) val += M;

                up[r - 1, c] = val;
            }
        }
        long ans = 0;
        for (int c = 0; c < m; c++)
        {
            ans += up[0, c];
            ans += same[0, c];
            ans %= M;
        }
        return (int)ans;
    }
}

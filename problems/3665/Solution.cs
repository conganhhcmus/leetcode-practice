public class Solution
{
    public int UniquePaths(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int MOD = (int)1e9 + 7;
        Dictionary<(int, int, int), long> memo = [];

        long ans = (DP(0, 0, 0)) % MOD;
        return (int)ans;

        //[[0,0,0],
        // [1,1,0]]

        // d => 0: down, 1:right
        long DP(int r, int c, int d)
        {
            if (r >= n || c >= m) return 0L;
            if (r == n - 1 && c == m - 1) return 1L;

            var key = (r, c, d);
            if (memo.TryGetValue(key, out long cache)) return cache;
            long ans = 0L;
            if (grid[r][c] == 1)
            { // mirror
                if (d == 0)
                { // down => right
                    ans = (ans + DP(r, c + 1, 1)) % MOD;
                }
                else
                { // right => down
                    ans = (ans + DP(r + 1, c, 0)) % MOD;
                }
            }
            else
            { // empty
                ans = (ans + DP(r + 1, c, 0)) % MOD;
                ans = (ans + DP(r, c + 1, 1)) % MOD;
            }
            return memo[key] = ans;
        }
    }
}
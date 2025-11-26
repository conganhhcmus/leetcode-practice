#if DEBUG
namespace Problems_2435;
#endif

public class Solution
{
    int mod = (int)1e9 + 7;

    public int NumberOfPaths(int[][] grid, int k)
    {
        return (int)DP(0, 0, 0, grid, k);
    }

    Dictionary<(int, int, int), long> memo = [];

    long DP(int r, int c, int rem, int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;

        if (r >= m || c >= n) return 0;

        if (r == m - 1 && c == n - 1)
        {
            return ((rem + grid[r][c]) % k == 0) ? 1 : 0;
        }

        var key = (r, c, rem);
        if (memo.TryGetValue(key, out long value)) return value;

        long ans = (
            DP(r + 1, c, (rem + grid[r][c]) % k, grid, k) +
            DP(r, c + 1, (rem + grid[r][c]) % k, grid, k)
        ) % mod;

        memo[key] = ans;
        return ans;
    }
}
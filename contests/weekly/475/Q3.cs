public class Solution
{
    public int MaxPathScore(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        int INF = 1 << 30;
        Dictionary<(int, int, int), int> memo = [];
        int ans = DP(0, 0, k);
        return Math.Max(-1, ans);

        int DP(int x, int y, int r)
        {
            int score = grid[x][y];
            int cost = Math.Min(1, grid[x][y]);
            if (r < cost) return -INF;
            if (x == m - 1 && y == n - 1) return grid[x][y];
            var key = (x, y, r);
            if (memo.TryGetValue(key, out int cached)) return cached;
            int ans = -INF;
            if (x + 1 < m) ans = Math.Max(ans, score + DP(x + 1, y, r - cost));
            if (y + 1 < n) ans = Math.Max(ans, score + DP(x, y + 1, r - cost));
            return memo[key] = ans;
        }
    }
}

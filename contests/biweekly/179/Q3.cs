public class Solution
{
    public int MinCost(int[][] grid)
    {
        return DP(0, 0, grid[0][0], grid);
    }

    Dictionary<(int, int, int), int> memo = [];

    int DP(int x, int y, int xor, int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        if (x == m - 1 && y == n - 1)
        {
            return xor;
        }

        var key = (x, y, xor);
        if (memo.TryGetValue(key, out int cache)) return cache;
        int ans = int.MaxValue;
        // down
        if (x + 1 < m)
        {
            ans = Math.Min(ans, DP(x + 1, y, xor ^ grid[x + 1][y], grid));
        }

        // right
        if (y + 1 < n)
        {
            ans = Math.Min(ans, DP(x, y + 1, xor ^ grid[x][y + 1], grid));
        }

        return memo[key] = ans;
    }
}
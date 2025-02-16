#if DEBUG
namespace Contests_437_Q4_2;
#endif

public class Solution
{
    public int LenOfVDiagonal(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 1)
                {
                    for (int d = 0; d < 4; d++)
                    {
                        ans = Math.Max(ans, DP(grid, i, j, d, 1, false));
                    }
                }
                if (ans == Math.Max(n, m)) return ans;
            }
        }

        return ans;
    }
    Dictionary<(int x, int y, int d, int val, bool turned), int> memo = [];
    private int DP(int[][] grid, int x, int y, int d, int val, bool turned)
    {
        int n = grid.Length, m = grid[0].Length;
        if (x < 0 || y < 0 || x >= n || y >= m) return 0;
        if (grid[x][y] != val) return 0;
        var key = (x, y, d, val, turned);
        if (memo.TryGetValue(key, out int value)) return value;
        int[][] dirs = [[1, 1], [1, -1], [-1, -1], [-1, 1]];
        int[] nVals = [2, 2, 0];
        int ans = 1 + DP(grid, x + dirs[d][0], y + dirs[d][1], d, nVals[val], turned);
        if (!turned)
        {
            int d2 = (d + 1) % 4;
            ans = Math.Max(ans, 1 + DP(grid, x + dirs[d2][0], y + dirs[d2][1], d2, nVals[val], !turned));
        }
        memo[key] = ans;
        return ans;
    }
}
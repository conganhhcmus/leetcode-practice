#if DEBUG
namespace Problems_1368_2;
#endif

public class Solution
{
    public int MinCost(int[][] grid)
    {
        // BFS with min weight first
        // keep minimum cost in x,y coordinates

        int n = grid.Length, m = grid[0].Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                dp[i][j] = int.MaxValue;
            }
        }
        dp[0][0] = 0;
        // Use dequeue to save min weight in first iteration
        int[][] dirs = [[0, 1], [0, -1], [1, 0], [-1, 0]];
        LinkedList<(int, int)> dq = new();
        dq.AddFirst((0, 0));
        while (dq.Count > 0)
        {
            var (x, y) = dq.First.Value;
            dq.RemoveFirst();

            for (int i = 0; i < dirs.Length; i++)
            {
                int nX = x + dirs[i][0];
                int nY = y + dirs[i][1];
                int cost = (grid[x][y] != i + 1) ? 1 : 0;
                if (!IsValid(nX, nY, n, m) || dp[x][y] + cost >= dp[nX][nY]) continue;

                dp[nX][nY] = dp[x][y] + cost;
                if (cost == 0) dq.AddFirst((nX, nY));
                else dq.AddLast((nX, nY));
            }
        }

        return dp[n - 1][m - 1];
    }

    private bool IsValid(int x, int y, int n, int m)
    {
        return x >= 0 && x < n && y >= 0 && y < m;
    }
}
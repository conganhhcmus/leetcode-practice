#if DEBUG
namespace Problems_3651;
#endif

public class Solution
{
    public int MinCost(int[][] grid, int k)
    {
        int m = grid.Length, n = grid[0].Length;
        var points = new List<(int x, int y)>();
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                points.Add((i, j));
            }
        }
        points.Sort((p1, p2) => grid[p1.x][p1.y] - grid[p2.x][p2.y]);

        int[,] costs = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                costs[i, j] = int.MaxValue;
            }
        }
        for (int t = 0; t <= k; t++)
        {
            int minCost = int.MaxValue;
            for (int i = 0, j = 0; i < points.Count; i++)
            {
                minCost = Math.Min(minCost, costs[points[i].x, points[i].y]);
                if (i + 1 < points.Count && grid[points[i].x][points[i].y] == grid[points[i + 1].x][points[i + 1].y])
                {
                    continue;
                }

                for (int r = j; r <= i; r++)
                {
                    costs[points[r].x, points[r].y] = minCost;
                }
                j = i + 1;
            }

            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = n - 1; j >= 0; j--)
                {
                    if (i == m - 1 && j == n - 1)
                    {
                        costs[i, j] = 0;
                        continue;
                    }
                    if (i != m - 1)
                    {
                        costs[i, j] = Math.Min(costs[i, j], costs[i + 1, j] + grid[i + 1][j]);
                    }
                    if (j != n - 1)
                    {
                        costs[i, j] = Math.Min(costs[i, j], costs[i, j + 1] + grid[i][j + 1]);
                    }
                }
            }
        }

        return costs[0, 0];
    }
}
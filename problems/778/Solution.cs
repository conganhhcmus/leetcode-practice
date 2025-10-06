#if DEBUG
namespace Problems_778;
#endif

public class Solution
{
    public int SwimInWater(int[][] grid)
    {
        int n = grid.Length;
        int[][] need = new int[n][];
        for (int i = 0; i < n; i++)
        {
            need[i] = new int[n];
            Array.Fill(need[i], int.MaxValue);
        }
        PriorityQueue<(int r, int c, int v), int> pq = new();
        pq.Enqueue((0, 0, grid[0][0]), grid[0][0]);
        need[0][0] = grid[0][0];
        int[] dirs = [1, 0, -1, 0, 1];
        while (pq.Count > 0)
        {
            var (r, c, v) = pq.Dequeue();
            for (int i = 0; i < 4; i++)
            {
                int nR = r + dirs[i];
                int nC = c + dirs[i + 1];
                if (IsValid(nR, nC, n))
                {
                    int nV = Math.Max(v, grid[nR][nC]);
                    if (nV < need[nR][nC])
                    {
                        need[nR][nC] = nV;
                        pq.Enqueue((nR, nC, nV), nV);
                    }
                }
            }
        }
        return need[n - 1][n - 1];
    }

    bool IsValid(int r, int c, int n) => r >= 0 && r < n && c >= 0 && c < n;
}
#if DEBUG
namespace Contests_437_Q4;
#endif

public class Solution
{
    public int LenOfVDiagonal(int[][] grid)
    {
        int n = grid.Length, m = grid[0].Length;
        int ans = 0;
        int[][] dirs = [[1, 1], [1, -1], [-1, -1], [-1, 1]];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (grid[i][j] == 1)
                {
                    Queue<(int x, int y, int pX, int pY, int d, bool canTurn)> queue = [];
                    for (int d = 0; d < dirs.Length; d++)
                    {
                        int nX = i + dirs[d][0], nY = j + dirs[d][1];
                        if (nX < 0 || nY < 0 || nX >= n || nY >= m || grid[nX][nY] != 2) continue;
                        queue.Enqueue((nX, nY, i, j, d, true));
                    }
                    int count = 1;
                    while (queue.Count > 0)
                    {
                        int size = queue.Count;
                        for (int k = 0; k < size; k++)
                        {
                            var (x, y, pX, pY, d, canTurn) = queue.Dequeue();
                            for (int t = 0; t < dirs.Length; t++)
                            {
                                if (t == d)
                                {
                                    int nX = x + dirs[t][0], nY = y + dirs[t][1];
                                    if (nX < 0 || nY < 0 || nX >= n || nY >= m || grid[nX][nY] == 1 || (nX == pX && nY == pY)) continue;
                                    if (grid[x][y] != grid[nX][nY])
                                    {
                                        queue.Enqueue((nX, nY, x, y, t, canTurn));
                                    }
                                }
                                else if (t == (d + 1) % dirs.Length && canTurn)
                                {
                                    int nX = x + dirs[t][0], nY = y + dirs[t][1];
                                    if (nX < 0 || nY < 0 || nX >= n || nY >= m || grid[nX][nY] == 1 || (nX == pX && nY == pY)) continue;
                                    if (grid[x][y] != grid[nX][nY])
                                    {
                                        queue.Enqueue((nX, nY, x, y, t, false));
                                    }
                                }
                            }
                        }
                        count++;
                    }
                    ans = Math.Max(ans, count);
                    if (ans == Math.Max(n, m)) return ans;
                }
            }
        }

        return ans;
    }
}
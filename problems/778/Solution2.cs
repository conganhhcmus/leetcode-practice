#if DEBUG
namespace Problems_778_2;
#endif

public class Solution
{
    public int SwimInWater(int[][] grid)
    {
        int n = grid.Length;
        int l = 0, r = n * n;
        int ans = int.MaxValue;
        bool[,] visited;
        while (l < r)
        {
            int m = l + (r - l) / 2;
            visited = new bool[n, n];
            if (HasPath(grid, 0, 0, m, visited))
            {
                ans = m;
                r--;
            }
            else
            {
                l++;
            }

        }
        return ans;
    }

    bool HasPath(int[][] grid, int r, int c, int t, bool[,] visited)
    {
        int n = grid.Length;
        if (r < 0 || r >= n) return false;
        if (c < 0 || c >= n) return false;
        if (grid[r][c] > t) return false;
        if (visited[r, c]) return false;
        visited[r, c] = true;
        if (r == n - 1 && c == n - 1) return true;
        if (HasPath(grid, r + 1, c, t, visited)) return true;
        if (HasPath(grid, r - 1, c, t, visited)) return true;
        if (HasPath(grid, r, c + 1, t, visited)) return true;
        if (HasPath(grid, r, c - 1, t, visited)) return true;

        return false;
    }
}
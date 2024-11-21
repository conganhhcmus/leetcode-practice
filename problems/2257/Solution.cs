namespace Problem_2257;

using Helpers.Array;
public class Solution
{
    public static void Execute()
    {
        int m = 4;
        int n = 6;
        int[][] guards = [[0, 0], [1, 1], [2, 3]];
        int[][] walls = [[0, 1], [2, 2], [1, 4]];
        var solution = new Solution();
        Console.WriteLine(solution.CountUnguarded(m, n, guards, walls));
    }

    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        int[,] grid = new int[m, n];
        // 0: not guarded cell, 1: guarded cell, -1: wall, 2: guard
        foreach (var guard in guards)
        {
            grid[guard[0], guard[1]] = 2;
        }
        foreach (var wall in walls)
        {
            grid[wall[0], wall[1]] = -1;
        }

        foreach (var guard in guards)
        {
            int r = guard[0];
            int c = guard[1];

            for (int i = r - 1; i >= 0; i--)
            {
                if (grid[i, c] == -1 || grid[i, c] == 2) break;
                grid[i, c] = 1;
            }

            for (int i = r + 1; i < m; i++)
            {
                if (grid[i, c] == -1 || grid[i, c] == 2) break;
                grid[i, c] = 1;
            }

            for (int i = c - 1; i >= 0; i--)
            {
                if (grid[r, i] == -1 || grid[r, i] == 2) break;
                grid[r, i] = 1;
            }

            for (int i = c + 1; i < n; i++)
            {
                if (grid[r, i] == -1 || grid[r, i] == 2) break;
                grid[r, i] = 1;
            }
        }

        int count = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i, j] == 0)
                {
                    count++;
                }
            }
        }

        ArrayHelper.Print2DArray(grid);

        return count;
    }
}
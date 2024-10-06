namespace Problem_2352;

public class Solution
{
    public static void Execute()
    {
        Solution solution = new();
        int[][] grid = [[3, 1, 2, 2], [1, 4, 4, 4], [2, 4, 2, 2], [2, 5, 2, 2]];
        Console.WriteLine(solution.EqualPairs(grid));
        Console.WriteLine(solution.EqualPairs2(grid));
    }
    public int EqualPairs(int[][] grid)
    {
        int len = grid.Length;
        int p = 11;
        long[] rows = new long[len];
        long[] cols = new long[len];

        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                rows[i] = rows[i] * p + grid[i][j];
                cols[j] = cols[j] * p + grid[i][j];
            }
        }

        int count = 0;
        for (int i = 0; i < len; i++)
        {
            for (int j = 0; j < len; j++)
            {
                if (rows[i] == cols[j])
                {
                    count++;
                }
            }
        }

        return count;
    }

    public int EqualPairs2(int[][] grid)
    {
        int len = grid.Length;
        int ans = 0;
        Dictionary<string, int> colsMap = [];
        for (int j = 0; j < len; j++)
        {
            string tmp = "";
            for (int i = 0; i < len; i++)
            {
                tmp += grid[i][j] + "-";
            }
            colsMap[tmp] = colsMap.GetValueOrDefault(tmp, 0) + 1;
        }
        for (int i = 0; i < len; i++)
        {
            ans += colsMap.GetValueOrDefault(string.Join("-", grid[i]) + "-", 0);
        }

        return ans;
    }
}
#if DEBUG
namespace Problems_2017;
#endif

public class Solution
{
    public long GridGame(int[][] grid)
    {
        int m = grid[0].Length;
        long rem1 = 0, rem2 = 0; // rem1 is first row remaining after robot1 traversed, rem2 is second row remaining after robot1 traversed
        for (int i = 1; i < m; i++) rem1 += grid[0][i];

        long ans = rem1;
        for (int i = 1; i < m; i++)
        {
            rem1 -= grid[0][i];
            rem2 += grid[1][i - 1];
            ans = Math.Min(ans, Math.Max(rem1, rem2));
        }

        return ans;
    }
}
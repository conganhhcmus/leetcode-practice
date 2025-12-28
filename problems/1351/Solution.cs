#if DEBUG
namespace Problems_1351;
#endif

public class Solution
{
    public int CountNegatives(int[][] grid)
    {
        int ans = 0;
        foreach (var row in grid)
        {
            foreach (var val in row)
            {
                if (val < 0) ans++;
            }
        }
        return ans;
    }
}
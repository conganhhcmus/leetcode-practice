#if DEBUG
namespace Problems_1981;
#endif

public class Solution
{
    public int MinimizeTheDifference(int[][] mat, int target)
    {
        int n = mat.Length, m = mat[0].Length;
        // max = 70*70 = 4900
        // bool dp[i][j] where can choose i element to sum = j
        // dp[i][s] |= dp[i-1][x] where x = s-nums[i][j]
        int maxSum = 70 * n;
        bool[] prev = new bool[maxSum + 1];

        prev[0] = true;
        for (int i = 0; i < n; i++)
        {
            bool[] curr = new bool[maxSum + 1];
            for (int s = 0; s <= maxSum; s++)
            {
                if (!prev[s]) continue;
                for (int j = 0; j < m; j++)
                {
                    if (mat[i][j] + s <= maxSum)
                    {
                        curr[s + mat[i][j]] = true;
                    }
                }
            }
            prev = curr;
        }

        int ret = int.MaxValue;
        for (int i = 0; i <= maxSum; i++)
        {
            if (prev[i])
            {
                ret = Math.Min(ret, Math.Abs(target - i));
            }
        }
        return ret;
    }
}
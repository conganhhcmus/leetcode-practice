#if DEBUG
namespace Problems_2086_3;
#endif

public class Solution
{
    public int MinimumBuckets(string hamsters)
    {
        int n = hamsters.Length;
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            if (hamsters[i - 1] == '.')
            {
                dp[i] = dp[i - 1];
                continue;
            }
            if (!CanFeed(hamsters, i - 1)) return -1;
            dp[i] = dp[i - 1] + 1;
            if (i + 2 <= n && hamsters[i] == '.' && hamsters[i + 1] == 'H')
            {
                dp[i + 2] = dp[i + 1] = dp[i];
                i += 2;
            }
        }
        return dp[n];
    }

    bool CanFeed(string hamsters, int pos)
    {
        return (pos > 0 && hamsters[pos - 1] == '.') || (pos + 1 < hamsters.Length && hamsters[pos + 1] == '.');
    }
}
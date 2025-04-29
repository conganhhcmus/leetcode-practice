#if DEBUG
namespace Problems_1986;
#endif

public class Solution
{
    public int MinSessions(int[] tasks, int sessionTime)
    {
        // dp[mask][k] = minimum of number session time
        // dp[newMask][newRemain] = min of dp[mask][remain] + task[i]
        int n = tasks.Length;
        int fullMask = (1 << n) - 1;
        int[][] dp = new int[fullMask + 1][];
        for (int i = 0; i <= fullMask; i++)
        {
            dp[i] = new int[sessionTime];
            Array.Fill(dp[i], int.MaxValue / 3);
        }
        dp[0][0] = 0;
        for (int mask = 0; mask <= fullMask; mask++)
        {
            for (int remain = 0; remain < sessionTime; remain++)
            {
                for (int i = 0; i < n; i++)
                {
                    if ((mask & (1 << i)) == 0)
                    {
                        int newMask = mask | (1 << i);
                        int newRemain = tasks[i] > remain ? sessionTime - tasks[i] : remain - tasks[i];
                        int newVal = dp[mask][remain] + (tasks[i] > remain ? 1 : 0);
                        dp[newMask][newRemain] = Math.Min(dp[newMask][newRemain], newVal);
                    }
                }
            }
        }
        int ret = int.MaxValue;
        for (int i = 0; i < sessionTime; i++)
        {
            ret = Math.Min(ret, dp[fullMask][i]);
        }
        return ret;
    }
}
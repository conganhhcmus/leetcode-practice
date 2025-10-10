#if DEBUG
namespace Problems_3147;
#endif

public class Solution
{
    public int MaximumEnergy(int[] energy, int k)
    {
        int n = energy.Length;
        int[] dp = new int[n];
        for (int i = 0; i < k; i++)
        {
            dp[i] = energy[i];
        }
        for (int i = k; i < n; i++)
        {
            dp[i] = Math.Max(0, dp[i - k]) + energy[i];
        }

        int max = int.MinValue;
        for (int i = n - k; i < n; i++)
        {
            max = Math.Max(max, dp[i]);
        }
        return max;
    }
}
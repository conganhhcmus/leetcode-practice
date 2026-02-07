public class Solution
{
    public int MinSpaceWastedKResizing(int[] nums, int k)
    {
        int n = nums.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[k + 1];
            Array.Fill(dp[i], int.MaxValue / 3);
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j <= k; j++)
            {
                int max = 0, sum = 0;
                for (int l = i; l >= 0; l--)
                {
                    max = Math.Max(max, nums[l]);
                    sum += nums[l];
                    int wasted = max * (i - l + 1) - sum;
                    if (i == 0 || j == 0)
                    {
                        dp[i][j] = wasted;
                    }
                    else if (l == 0)
                    {
                        dp[i][j] = Math.Min(dp[i][j], wasted);
                    }
                    else
                    {
                        dp[i][j] = Math.Min(dp[i][j], wasted + dp[l - 1][j - 1]);
                    }
                }
            }
        }

        return dp[n - 1][k];
    }
}
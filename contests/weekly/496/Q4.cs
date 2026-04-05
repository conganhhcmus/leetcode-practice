public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        int n = nums.Length;
        int m = n + 1;
        int INF = int.MaxValue / 2;
        int[] nums1 = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            nums1[i] = nums[i];
        }
        nums1[n] = nums[0];

        int[] nums2 = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            nums2[i + 1] = nums[i];
        }
        nums2[0] = nums[n - 1];

        int a1 = Calc(nums1, k);
        int a2 = Calc(nums2, k);
        if (a1 == -1) return a2;
        if (a2 == -1) return a1;
        return Math.Min(a1, a2);
    }

    int Calc(int[] nums, int k)
    {
        int n = nums.Length;
        int INF = int.MaxValue / 2;
        int[][] dp = new int[k + 1][];
        for (int i = 0; i <= k; i++)
        {
            dp[i] = new int[n];
            Array.Fill(dp[i], i == 0 ? 0 : INF);
        }
        for (int i = 1; i <= k; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i][j] = Math.Min(dp[i][j], dp[i][j - 1]);
                if (j > 1)
                {
                    int needed = Math.Max(0, Math.Max(nums[j - 2], nums[j]) + 1 - nums[j - 1]);
                    dp[i][j] = Math.Min(dp[i][j], dp[i - 1][j - 2] + needed);
                }
            }
        }


        if (dp[k][n - 1] >= INF) return -1;
        return dp[k][n - 1];
    }
}
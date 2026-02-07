public class Solution
{
    public int MaxDotProduct(int[] nums1, int[] nums2)
    {
        int n1 = nums1.Length, n2 = nums2.Length;
        int[,] dp = new int[n1 + 1, n2 + 1];

        for (int i = 0; i <= n1; i++)
        {
            for (int j = 0; j <= n2; j++)
            {
                dp[i, j] = int.MinValue;
            }
        }

        for (int i = 1; i <= n1; i++)
        {
            for (int j = 1; j <= n2; j++)
            {
                int take = nums1[i - 1] * nums2[j - 1] + Math.Max(0, dp[i - 1, j - 1]);
                dp[i, j] = Math.Max(Math.Max(dp[i - 1, j], dp[i, j - 1]), take);
            }
        }

        return dp[n1, n2];
    }
}
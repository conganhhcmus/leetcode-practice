namespace Problem_3277;

public class Solution
{
    public int[] MaximumSubarrayXor(int[] nums, int[][] queries)
    {
        // Key 1: Xor score of nums[i..j] = nums[i..j-1] Xor(^) nums[i+1..j]
        // Key 2: Get Max Xor score of nums[i..j] by using DP stored Xor score of all i->j
        // DP[i][j] = Xor score of nums[i..j]
        // Max Xor score = Max(DP[i][j], DP[i][j-1], DP[i+1][j])

        int[][] dp = new int[nums.Length][];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = new int[nums.Length];
            Array.Fill(dp[i], 0);
            dp[i][i] = nums[i];
        }

        for (int len = 2; len <= nums.Length; len++)
        {
            for (int st = 0; st + len - 1 < nums.Length; st++)
            {
                var end = st + len - 1;
                dp[st][end] = dp[st][end - 1] ^ dp[st + 1][end];
            }
        }

        for (int len = 2; len <= nums.Length; len++)
        {
            for (int st = 0; st + len - 1 < nums.Length; st++)
            {
                var end = st + len - 1;
                dp[st][end] = Math.Max(dp[st][end], Math.Max(dp[st][end - 1], dp[st + 1][end]));

            }
        }

        int[] result = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            result[i] = dp[queries[i][0]][queries[i][1]];
        }

        return result;
    }
}
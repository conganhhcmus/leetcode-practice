namespace Problem_1310;

public class Solution
{
    public int[] XorQueries(int[] arr, int[][] queries)
    {
        // dp[i] = a0 ^ a1 ^ ... ^ ai
        int[] dp = new int[arr.Length];
        dp[0] = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            dp[i] = dp[i - 1] ^ arr[i];
        }

        int[] ans = new int[queries.Length];

        for (int i = 0; i < queries.Length; i++)
        {
            var start = queries[i][0];
            var end = queries[i][1];

            // Key: a2 ^ a3 = (a0 ^ a1) ^ (a0 ^ a1 ^ a2 ^ a3)
            // =>   a2 ^ a3 = dp[1] ^ dp[3]
            ans[i] = start == 0 ? dp[end] : dp[start - 1] ^ dp[end];
        }

        return ans;
    }
}
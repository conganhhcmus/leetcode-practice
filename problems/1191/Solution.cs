public class Solution
{
    int MOD = 1_000_000_007;
    public int KConcatenationMaxSum(int[] arr, int k)
    {
        long[] A = BuildArray(arr, k);
        int n = A.Length;
        long[] dp = new long[n];
        // dp[i] = max val end at i
        // dp[i] = max(nums[i] + dp[i-1], nums[i])
        dp[0] = A[0];
        for (int i = 1; i < n; i++)
        {
            dp[i] = Math.Max(0, Math.Max(A[i], A[i] + dp[i - 1]));
        }
        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (ans < dp[i]) ans = dp[i];
        }
        return (int)(ans % MOD);
    }

    static long[] BuildArray(int[] arr, int k)
    {
        if (k == 1) return [.. arr];
        if (k == 2) return [.. arr, .. arr];
        long sum = 0;
        for (int i = 0; i < arr.Length; i++) sum += arr[i];
        long mid = Math.Max(0, Math.Max(0, k - 2) * sum);
        return [.. arr, mid, .. arr];
    }
}

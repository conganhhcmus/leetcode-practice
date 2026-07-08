public class Solution
{
    public int DivisibleGame(int[] nums)
    {
        int n = nums.Length;
        // if have k, how to max score
        HashSet<int> arr = [2];
        foreach (int x in nums)
        {
            if (x > 1) arr.Add(x);
            for (int i = 2; i * i <= x; i++)
            {
                if (x % i == 0)
                {
                    int j = x / i;
                    arr.Add(i);
                    if (i != j) arr.Add(j);
                }
            }
        }
        List<int> cand = [.. arr];
        cand.Sort();
        int MOD = 1_000_000_007;
        long score = long.MinValue;
        long best = -1;
        foreach (int k in cand)
        {
            long val = BestScore(k);
            if (val > score)
            {
                score = val;
                best = k;
            }
        }
        long ans = score * best % MOD;
        if (ans < 0) ans += MOD;
        return (int)ans;

        long BestScore(int k)
        {
            // dp[i] = max score and at i
            // dp[i] = pick nums[i] + dp[i-1] or nums[i]
            long[] dp = new long[n + 1];
            dp[0] = 0L;
            long ans = long.MinValue;
            for (int i = 1; i <= n; i++)
            {
                int x = nums[i - 1];
                long v = (x % k == 0) ? x : -x;
                dp[i] = Math.Max(v, v + dp[i - 1]);
                if (ans < dp[i]) ans = dp[i];
            }
            return ans;
        }
    }
}

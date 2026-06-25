public class Solution
{
    public int CountEffective(int[] nums)
    {
        // ans = ways(1-bit) - ways(2-bit) + ways(3-bit)-...
        // ways(1-bit) = 2 ^ cnt
        int n = nums.Length;
        int MOD = 1_000_000_007;
        int all = 0;
        for (int i = 0; i < n; i++) all |= nums[i];
        List<int> bits = [];
        for (int b = 0; b < 31; b++)
        {
            if (((all >> b) & 1) != 0) bits.Add(b);
        }
        int m = bits.Count;
        if (m == 0) return 0;
        int N = 1 << m;
        long[] dp = new long[N];
        for (int i = 0; i < n; i++)
        {
            int mask = 0;
            for (int j = 0; j < m; j++)
            {
                if (((nums[i] >> bits[j]) & 1) != 0) mask |= 1 << j;
            }
            dp[mask]++;
        }

        for (int b = 0; b < m; b++)
        {
            for (int mask = 0; mask < N; mask++)
            {
                if ((mask & (1 << b)) != 0)
                {
                    dp[mask] += dp[mask ^ (1 << b)];
                }
            }
        }

        long[] pow2 = new long[n + 1];
        pow2[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            pow2[i] = pow2[i - 1] * 2 % MOD;
        }
        long ans = 0;
        int fullMask = N - 1;
        for (int T = 1; T < N; T++)
        {
            long disjoint = dp[fullMask ^ T];
            long ways = pow2[(int)disjoint];
            if ((BitCount(T) & 1) == 1) ans += ways;
            else ans -= ways;
        }
        ans %= MOD;
        if (ans < 0) ans += MOD;
        return (int)ans;

        int BitCount(int x)
        {
            int r = 0;
            while (x > 0)
            {
                r += x & 1;
                x >>= 1;
            }
            return r;
        }
    }
}

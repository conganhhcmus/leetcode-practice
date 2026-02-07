public class Solution
{
    public int MinimumIncrements(int[] nums, int[] target)
    {
        int n = nums.Length, m = target.Length;
        int maxBitMask = 1 << m;
        long[] map = new long[maxBitMask];
        for (int mask = 1; mask < maxBitMask; mask++)
        {
            List<int> subset = [];
            for (int i = 0; i < m; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    subset.Add(target[i]);
                }
            }
            long lcm = subset[0];
            for (int i = 1; i < subset.Count; i++)
            {
                lcm = LCM(lcm, subset[i]);
            }
            map[mask] = lcm;
        }
        long[] dp = new long[maxBitMask];
        Array.Fill(dp, long.MaxValue);
        dp[0] = 0;
        for (int i = 0; i < n; i++)
        {
            long[] nMap = new long[maxBitMask];
            for (int mask = 1; mask < maxBitMask; mask++)
            {
                long rm = nums[i] % map[mask];
                long cost = (rm == 0) ? 0 : map[mask] - rm;
                nMap[mask] = cost;
            }

            long[] nDP = new long[maxBitMask];
            Array.Copy(dp, nDP, maxBitMask);
            for (int prevMask = 0; prevMask < maxBitMask; prevMask++)
            {
                if (dp[prevMask] == long.MaxValue) continue;
                for (int mask = 1; mask < maxBitMask; mask++)
                {
                    if (prevMask == mask) continue;
                    long nMask = prevMask | mask;
                    long nCost = dp[prevMask] + nMap[mask];
                    nDP[nMask] = Math.Min(nDP[nMask], nCost);
                }
            }
            dp = nDP;
        }

        if (dp[maxBitMask - 1] == long.MaxValue) return -1;
        return (int)dp[maxBitMask - 1];
    }

    private long LCM(long a, long b)
    {
        return a * b / GCD(a, b);
    }

    private long GCD(long a, long b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
}
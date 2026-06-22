public class Solution
{
    public int MaxTotalValue(int[] value, int[] decay, int m)
    {
        // t0 + t1 + t2 + ... + tn <= m
        // sum of is largest
        int MOD = 1_000_000_007;
        int n = value.Length;
        int low = 0, high = value.Max(), best = 0;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            long cnt = 0L;
            for (int i = 0; i < n; i++)
            {
                cnt += CountT(mid, i);
            }
            if (cnt >= m)
            {
                best = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }
        long ans = 0L;
        long tot = 0L;
        for (int i = 0; i < n; i++)
        {
            long t = CountT(best + 1, i);
            tot += t;
            ans = (ans + 1L * value[i] * t - 1L * decay[i] * t * (t - 1) / 2) % MOD;
        }
        ans = (ans + 1L * Math.Max(0, m - tot) * best) % MOD;

        return (int)(ans % MOD);

        long CountT(int X, int i)
        {
            if (value[i] < X) return 0L;
            return (value[i] - X) / decay[i] + 1;
        }
    }
}

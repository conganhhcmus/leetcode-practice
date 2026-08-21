public class Solution
{
    public long FindKthSmallest(int[] coins, int k)
    {
        Array.Sort(coins);
        List<int> vals = [];
        foreach (int c in coins)
        {
            bool redundant = false;
            foreach (int x in vals)
            {
                if (c % x == 0)
                {
                    redundant = true;
                    break;
                }
            }
            if (!redundant) vals.Add(c);
        }
        long ans = 1L * k * vals[0];
        long lo = 1, hi = 1L * k * vals[0];
        while (lo <= hi)
        {
            long mi = lo + (hi - lo) / 2;
            if (Count(mi) >= k)
            {
                ans = mi;
                hi = mi - 1;
            }
            else
            {
                lo = mi + 1;
            }
        }
        return ans;

        long Count(long x)
        {
            long ans = 0;
            int n = vals.Count;
            for (int mask = 1; mask < (1 << n); mask++)
            {
                long lcm = 1;
                int bits = 0;
                for (int i = 0; i < n; i++)
                {
                    if ((mask & (1 << i)) == 0) continue;
                    bits++;
                    long g = GCD(lcm, vals[i]);
                    lcm = lcm / g * vals[i];
                    if (lcm > x) break;
                }
                if (lcm > x) continue;
                long cnt = x / lcm;
                if ((bits & 1) == 1) ans += cnt;
                else ans -= cnt;
            }
            return ans;
        }

        long GCD(long a, long b)
        {
            while (b != 0)
            {
                (a, b) = (b, a % b);
            }
            return a;
        }
    }
}

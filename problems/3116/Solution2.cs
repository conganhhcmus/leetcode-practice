public class Solution
{
    public long FindKthSmallest(int[] coins, int k)
    {
        Array.Sort(coins);
        int n = coins.Length;
        int m = 1 << n;
        long l = k;
        long r = 1L * coins[0] * k;
        int[] bitCount = new int[m];
        long[] lcm = new long[m];
        for (int mask = 1; mask < m; mask++)
        {
            long curLcm = 1;
            for (int i = 0; i < n; i++)
            {
                if (((mask >> i) & 1) == 1)
                {
                    long g = Gcd(curLcm, coins[i]);
                    long tmp = curLcm / g;
                    if (tmp <= r / coins[i])
                    {
                        curLcm = tmp * coins[i];
                    }
                    else
                    {
                        curLcm = r + 1;
                        break;
                    }
                    bitCount[mask]++;
                }
            }
            lcm[mask] = curLcm;
        }

        long ans = r;

        while (l <= r)
        {
            long x = l + (r - l) / 2;
            if (Count(x) >= k)
            {
                ans = x;
                r = x - 1;
            }
            else
            {
                l = x + 1;
            }
        }

        return ans;

        long Count(long x)
        {
            long res = 0;
            for (int mask = 1; mask < m; mask++)
            {
                if (lcm[mask] > x) continue;
                if ((bitCount[mask] & 1) == 1) res += x / lcm[mask];
                else res -= x / lcm[mask];
            }
            return res;
        }

        long Gcd(long a, long b)
        {
            while (b != 0) (a, b) = (b, a % b);
            return a;
        }
    }
}
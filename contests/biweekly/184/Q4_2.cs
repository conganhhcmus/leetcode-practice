public class Solution
{
    public int MaxScore(int[] nums, int maxVal)
    {
        int limit = maxVal;
        foreach (int x in nums) if (x > limit) limit = x;
        int[] freq = new int[limit + 1];
        foreach (int x in nums) freq[x]++;
        int[] count = new int[limit + 1];
        for (int m = 1; m <= limit; m++)
        {
            for (int k = m; k <= limit; k += m)
            {
                count[m] += freq[k];
            }
        }
        int[] spf = new int[limit + 1];
        for (int i = 2; i <= limit; i++)
        {
            if (spf[i] == 0)
            {
                for (int j = i; j <= limit; j += i)
                {
                    spf[j] = i;
                }
            }
        }
        int ans = int.MinValue;
        foreach (int v in nums)
        {
            int bad = Bad(v);
            ans = Math.Max(ans, v - Math.Max(0, bad - 1));
        }
        for (int v = 1; v <= maxVal; v++)
        {
            int bad = Bad(v);
            ans = Math.Max(ans, v - Math.Max(1, bad));
        }
        return ans;

        List<int> Facts(int v)
        {
            List<int> ans = [];
            while (v > 1)
            {
                int x = spf[v];
                ans.Add(x);
                while (v % x == 0) v /= x;
            }
            return ans;
        }

        int Bad(int v)
        {
            List<int> primes = Facts(v);
            int k = primes.Count;
            int bad = 0;
            for (int mask = 1; mask < (1 << k); mask++)
            {
                int prod = 1;
                int bits = 0;
                for (int i = 0; i < k; i++)
                {
                    if ((mask & (1 << i)) != 0)
                    {
                        bits++;
                        prod *= primes[i];
                    }
                }
                if ((bits & 1) == 1) bad += count[prod];
                else bad -= count[prod];
            }
            return bad;
        }
    }
}

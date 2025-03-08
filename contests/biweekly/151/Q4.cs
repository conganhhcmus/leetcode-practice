#if DEBUG
namespace Biweekly_151_Q4;
#endif

public class Solution
{
    public int[] Permute(int n, long k)
    {
        // build factor
        int p = n;
        long[] factor = new long[n + 1];
        factor[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            factor[i] = factor[i - 1] * i;
            if (factor[i] > k)
            {
                p = i;
                break;
            }
        }

        int[] ans = new int[n];
        bool[] used = new bool[n + 1];
        int force = n - p;
        for (int i = p + 1; i <= n; i++)
        {
            int odd = (i + 1) / 2;
            int even = i - odd;
            force = n - i;
            if (factor[odd] * factor[even] > k) break;
        }

        // check k > max permute
        if (force == 0)
        {
            int odd = (n + 1) / 2;
            int even = n - odd;
            long ways = factor[odd] * factor[even];
            if (n % 2 == 0) ways *= 2;
            if (k > ways) return [];
        }

        if (force > 0)
        {
            for (int i = 0; i < force; i++)
            {
                ans[i] = i + 1;
                used[i + 1] = true;
            }
        }

        int start = force + 1;
        int idx = 0;
        if (force == 0 && n % 2 == 0)
        {
            for (int i = (start + idx) % 2 == 0 ? 2 : 1; i <= n; i++)
            {
                if (used[i]) continue;
                int remain = n - 1 - (idx + force);
                int odd = (remain + (i % 2)) / 2;
                int even = remain - odd;
                long ways = factor[odd] * factor[even];
                if (k <= ways)
                {
                    ans[idx + force] = i;
                    used[i] = true;
                    idx++;
                    start = (i % 2) == 0 ? 2 : 1;
                    break;
                }
                else k -= ways;
            }
        }
        while (k > 0 && idx + force < n)
        {
            for (int i = (start + idx) % 2 == 0 ? 2 : 1; i <= n; i += 2)
            {
                if (used[i]) continue;
                int remain = n - 1 - (idx + force);
                int odd = (remain + (i % 2)) / 2;
                int even = remain - odd;
                long ways = factor[odd] * factor[even];
                if (k <= ways)
                {
                    ans[idx + force] = i;
                    used[i] = true;
                    idx++;
                    break;
                }
                else k -= ways;
            }
        }

        return ans;
    }
}
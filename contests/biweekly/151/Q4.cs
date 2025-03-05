#if DEBUG
namespace Biweekly_151_Q4;
#endif

public class Solution
{
    public int[] Permute(int n, long k)
    {
        // build factor
        long[] fact = new long[n + 1];
        fact[0] = 1;
        for (long i = 1; i <= n; i++)
        {
            fact[i] = fact[i - 1] * i;
        }
        int oddNum = (n + 1) / 2;
        int evenNum = n - oddNum;
        long totalWays = (n % 2 == 0 ? 2L : 1L) * fact[oddNum] * fact[evenNum];
        if (k > totalWays) return [];
        int[] ans = new int[n];
        int p = 0;
        bool[] used = new bool[n + 1];
        if (n % 2 != 0)
        {
            while (k > 0)
            {
                for (int i = p % 2 + 1; i <= n; i += 2)
                {
                    if (used[i]) continue;
                    int odd = ((n - p) + 1) / 2;
                    int even = (n - p) - odd;
                    long ways = fact[odd] * fact[even];
                    if (k < ways)
                    {
                        ans[p] = i;
                        used[i] = true;
                        p++;
                        break;
                    }
                    else
                    {
                        k -= ways;
                    }
                }
            }
            while (p < n)
            {
                for (int i = p % 2 + 1; i <= n; i += 2)
                {
                    if (used[i]) continue;
                    ans[p] = i;
                    used[i] = true;
                    p++;
                }
            }
        }
        else
        {
            for (int i = 1; i <= n; i += 1)
            {
                int odd = ((n - p) + 1) / 2;
                int even = (n - p) - odd;
                long ways = fact[odd] * fact[even];
                if (k < ways)
                {
                    ans[p] = i;
                    used[i] = true;
                    p++;
                    break;
                }
                else
                {
                    k -= ways;
                }
            }
            while (k > 0)
            {
                for (int i = GetStart(p, ans[0]); i <= n; i += 2)
                {
                    if (used[i]) continue;
                    int odd = ((n - p) + 1) / 2;
                    int even = (n - p) - odd;
                    long ways = fact[odd] * fact[even];
                    if (k < ways)
                    {
                        ans[p] = i;
                        used[i] = true;
                        p++;
                        break;
                    }
                    else
                    {
                        k -= ways;
                    }
                }
            }
            while (p < n)
            {
                for (int i = GetStart(p, ans[0]); i <= n; i += 2)
                {
                    if (used[i]) continue;
                    ans[p] = i;
                    used[i] = true;
                    p++;
                }
            }
        }
        return ans;
    }

    private int GetStart(int p, int first)
    {
        if ((p + first) % 2 != 0) return 1;
        return 2;
    }
}
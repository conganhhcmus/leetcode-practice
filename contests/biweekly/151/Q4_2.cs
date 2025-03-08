#if DEBUG
namespace Biweekly_151_Q4_2;
#endif

public class Solution
{
    public int[] Permute(int n, long k)
    {
        long[] factor = new long[n + 1];
        factor[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            int odd = (i + 1) / 2;
            if (factor[i - 1] >= k) factor[i] = k;
            else factor[i] = factor[i - 1] * odd;
        }
        if (n % 2 == 0) factor[n] *= 2;
        if (k > factor[n]) return [];
        k--; // decrease 1 due to k is last permute
        int[] ans = new int[n];
        List<int>[] num = [[], []];
        for (int i = 1; i <= n; i++)
        {
            num[i % 2].Add(i);
        }
        // fill first
        if (n % 2 == 0)
        {
            long val = k / factor[n - 1];
            ans[0] = num[(val + 1) % 2][(int)val / 2];
            k -= val * factor[n - 1];
        }
        else
        {
            long val = k / factor[n - 1];
            ans[0] = num[1][(int)val];
            k -= val * factor[n - 1];
        }

        num[ans[0] % 2].Remove(ans[0]);

        // fill remaining
        for (int i = 1; i < n; i++)
        {
            long val = k / factor[n - i - 1];
            ans[i] = num[(ans[0] + i) % 2][(int)val];
            k %= factor[n - i - 1];
            num[ans[i] % 2].Remove(ans[i]);
        }

        return ans;
    }
}
public class Solution
{
    public int[] GcdValues(int[] nums, long[] queries)
    {
        int n = nums.Length, m = queries.Length;
        int MAX = 0;
        for (int i = 0; i < n; i++) if (MAX < nums[i]) MAX = nums[i];
        int[] freq = new int[MAX + 1];
        for (int i = 0; i < n; i++) freq[nums[i]]++;
        int[] cnt = new int[MAX + 1];
        for (int i = 1; i <= MAX; i++)
        {
            for (int j = i; j <= MAX; j += i)
            {
                cnt[i] += freq[j];
            }
        }
        long[] exact = new long[MAX + 1];
        for (int g = MAX; g >= 1; g--)
        {
            if (cnt[g] < 2) continue;
            exact[g] = 1L * cnt[g] * (cnt[g] - 1) / 2;
            for (int k = g + g; k <= MAX; k += g)
            {
                exact[g] -= exact[k];
            }
        }
        long[] pref = new long[MAX + 1];
        for (int i = 1; i <= MAX; i++)
        {
            pref[i] = pref[i - 1] + exact[i];
        }
        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            long kth = queries[i];
            int low = 1, high = MAX, best = 1;
            while (low <= high)
            {
                int mid = (low + high) >> 1;
                if (pref[mid] > kth)
                {
                    best = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            ans[i] = best;
        }
        return ans;
    }
}

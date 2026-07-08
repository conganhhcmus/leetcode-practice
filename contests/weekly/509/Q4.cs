public class Solution
{
    public long GetSum(int[] nums)
    {
        int n = nums.Length;
        long[] pref = new long[n + 1];
        for (int i = 0; i < n; i++) pref[i + 1] = pref[i] + nums[i];

        int[] d1 = new int[n];
        int[] d2 = new int[n];
        int[] d1L = new int[n];
        int[] d1R = new int[n];

        int[] d2L = new int[n];
        int[] d2R = new int[n];
        int l = 0, r = -1;
        for (int i = 0; i < n; i++)
        {
            // check nums[i]
            int k = (i > r) ? 1 : Math.Min(d1[l + r - i], r - i + 1);
            while (i - k >= 0 && i + k < n && nums[i - k] == nums[i + k]) k++;
            d1[i] = k;
            d1L[i] = i - k + 1;
            d1R[i] = i + k - 1;
            if (d1R[i] > r)
            {
                l = d1L[i];
                r = d1R[i];
            }
        }

        l = 0;
        r = -1;
        for (int i = 0; i < n; i++)
        {
            // check nums[i-1], nums[i]
            int k = (i > r) ? 0 : Math.Min(d2[l + r - i + 1], r - i + 1);
            while (i - k - 1 >= 0 && i + k < n && nums[i - k - 1] == nums[i + k]) k++;
            d2[i] = k;
            d2L[i] = i - k;
            d2R[i] = i + k - 1;
            if (d2R[i] > r)
            {
                l = d2L[i];
                r = d2R[i];
            }
        }

        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            long sum1 = pref[d1R[i] + 1] - pref[d1L[i]];
            long sum2 = pref[d2R[i] + 1] - pref[d2L[i]];
            ans = Math.Max(ans, Math.Max(sum1, sum2));
        }
        return ans;
    }
}

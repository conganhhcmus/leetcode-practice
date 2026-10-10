public class Solution
{
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
        int n = nums1.Length;
        long[] cnt = new long[100_001];
        for (int i = 0; i < n; i++)
        {
            int diff = Math.Abs(nums1[i] - nums2[i]);
            cnt[diff]++;
        }

        int left = 0, right = 100_000;
        int best = 0;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (Need(mid) <= k1 + k2)
            {
                best = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        if (best == 0) return 0L;
        long rem = k1 + k2 - Need(best);
        for (int i = 100_000; i > best; i--)
        {
            cnt[best] += cnt[i];
            cnt[i] = 0;
        }
        cnt[best] -= rem;
        cnt[best - 1] += rem;
        long ans = 0L;
        for (int i = 0; i <= best; i++)
        {
            ans += cnt[i] * i * i;
        }

        return ans;

        long Need(int x)
        {
            long need = 0;
            for (int i = x; i <= 100_000; i++)
            {
                need += 1L * cnt[i] * (i - x);
            }
            return need;
        }
    }
}
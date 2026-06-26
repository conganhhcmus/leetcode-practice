public class Solution
{
    public long[] CountStableSubarrays(int[] nums, int[][] queries)
    {
        int n = nums.Length, q = queries.Length;
        List<long> pref = [0];
        List<int[]> arr = [];
        int cnt = 1;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] >= nums[i - 1]) cnt++;
            else
            {
                arr.Add([i - cnt, i - 1]);
                pref.Add(pref[^1] + 1L * cnt * (cnt + 1) / 2);
                cnt = 1;
            }
        }
        arr.Add([n - cnt, n - 1]);
        pref.Add(pref[^1] + 1L * cnt * (cnt + 1) / 2);
        int m = arr.Count;
        long[] ans = new long[q];
        for (int i = 0; i < q; i++)
        {
            int l = queries[i][0], r = queries[i][1];
            int low = 0;
            int high = m - 1;
            int bestL = 0;
            while (low <= high)
            {
                int mid = (low + high) >> 1;
                if (arr[mid][0] <= l)
                {
                    bestL = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            low = 0;
            high = m - 1;
            int bestR = m - 1;
            while (low <= high)
            {
                int mid = (low + high) >> 1;
                if (arr[mid][1] >= r)
                {
                    bestR = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            long v = 0L;
            if (bestR < bestL) continue;
            if (bestR == bestL)
            {
                v += 1L * (r - l + 1) * (r - l + 2) / 2;
            }
            else
            {
                v += pref[bestR] - pref[bestL + 1];
                int kL = arr[bestL][1] - l + 1;
                int kR = r - arr[bestR][0] + 1;
                v += 1L * kL * (kL + 1) / 2 + 1L * kR * (kR + 1) / 2;
            }
            ans[i] = v;
        }

        return ans;
    }
}

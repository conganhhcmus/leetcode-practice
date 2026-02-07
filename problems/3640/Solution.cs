public class Solution
{
    long INF = (long)1e15;

    public long MaxSumTrionic(int[] nums)
    {
        int n = nums.Length;
        long[] prefixSum = new long[n + 1];
        for (int k = 0; k < n; k++)
        {
            prefixSum[k + 1] = prefixSum[k] + nums[k];
        }
        long ans = -INF;
        int i = 0;
        while (i + 3 < n)
        {
            if (nums[i] == nums[i + 1])
            {
                i++;
                continue;
            }
            int l = i;
            int j = i + 1;
            while (j < n && nums[j] > nums[j - 1]) j++;
            int p = j - 1;
            while (j < n && nums[j] < nums[j - 1]) j++;
            int q = j - 1;
            while (j < n && nums[j] > nums[j - 1]) j++;
            int r = j - 1;
            // check valid trionic
            if (p != l && q != p && r != q)
            {
                long sum = prefixSum[r + 1] - prefixSum[l];
                long min = 0;
                for (int k = l; k + 1 < p; k++)
                {
                    min = Math.Min(min, prefixSum[k + 1] - prefixSum[l]);
                }
                sum -= min;
                min = 0;

                for (int k = r; k - 1 > q; k--)
                {
                    min = Math.Min(min, prefixSum[r + 1] - prefixSum[k]);
                }
                sum -= min;

                ans = Math.Max(ans, sum);
            }

            i = q;
        }

        return ans;
    }
}